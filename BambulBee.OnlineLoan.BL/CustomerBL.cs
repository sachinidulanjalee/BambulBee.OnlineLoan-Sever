using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BumbleBee.OnlineLoan.BUSINESS
{
    public class CustomerBL
    {
        public bool Add(CustomerModel _oCustomerModel)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    _oCustomerModel.CustomerID = GetByMaxId();

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CustomerModel, Customer>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.CustomerGenericRepository.Add(iMapper.Map<CustomerModel, Customer>(_oCustomerModel));
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public bool Edit(CustomerModel _oCustomerModel)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CustomerModel, Customer>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.CustomerGenericRepository.Edit(iMapper.Map<CustomerModel, Customer>(_oCustomerModel));
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public bool Delete(int CustomerID)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    adapter.CustomerGenericRepository.DeleteByPram(x => x.CustomerID == CustomerID);
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public CustomerModel GetById(int customerID)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerModel>();
            });

            IMapper iMapper = config.CreateMapper();
            using (DataAdapter adapter = new DataAdapter())
            {
                return iMapper.Map<Customer, CustomerModel>(adapter.CustomerGenericRepository.GetById(x => x.CustomerID == customerID));
            }
        }

        public bool BulkDelete(List<CustomerModel> data)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CustomerModel, Customer>();
                    });

                    IMapper iMapper = config.CreateMapper();
                    adapter.CustomerGenericRepository.BulkDelete(iMapper.Map<List<CustomerModel>, List<Customer>>(data));

                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public List<ComboModel> GetComboModelByStatus(int status)
        {
            try
            {
                List<CustomerModel> lstCustomerModel = GetAll().OrderBy(x => x.FirstName).ToList();
                if (status != 0)
                    lstCustomerModel.FindAll(x => x.Status == status);


                return lstCustomerModel.Select(x => new ComboModel()
                {
                    Value = x.CustomerID.ToString(),
                    Text = x.CustomerID + " - " + x.FirstName
                }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public int GetByMaxId()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<CustomerModel> lstCustomerModel = iMapper.Map<List<Customer>, List<CustomerModel>>(adapter.CustomerGenericRepository.GetAll());
                    int id = lstCustomerModel.Select(p => p.CustomerID).DefaultIfEmpty(0).Max();
                    return id + 1;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public int GetMemberCount()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<CustomerModel> lstCustomerModel = iMapper.Map<List<Customer>, List<CustomerModel>>(adapter.CustomerGenericRepository.GetAll());
                    int count = lstCustomerModel.Count(p => p.Status == 1);
                    return count;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }


        public List<CustomerModel> GetAll()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<CustomerModel> lstCustomerModel = iMapper.Map<List<Customer>, List<CustomerModel>>(adapter.CustomerGenericRepository.GetAll());

                    lstCustomerModel = lstCustomerModel.Select(x => new CustomerModel()
                    {
                        CustomerID = x.CustomerID,
                        UserID = x.UserID,
                        NICPassport = x.NICPassport,
                        Title = x.Title,
                        Sex = x.Sex,
                        Surname = x.Surname,
                        FirstName = x.FirstName,
                        ShortName = x.ShortName,
                        Nationality = x.Nationality,
                        Address01 = x.Address01,
                        Address02 = x.Address02,
                        Address03 = x.Address03,
                        City = x.City,
                        Province = x.Province,
                        PostalCode = x.PostalCode,
                        Country = x.Country,
                        Telephone = x.Telephone,
                        Mobile = x.Mobile,
                        Email = x.Email,
                        Status = x.Status,
                        InactiveDate = x.InactiveDate,
                        CreatedDateTime = x.CreatedDateTime,
                        CreatedBy = x.CreatedBy,
                        CreatedMachine = x.CreatedMachine,
                        ModifiedDateTime = x.ModifiedDateTime,
                        ModifiedBy = x.ModifiedBy,
                        ModifiedMachine = x.ModifiedMachine,
                        IsPrimaryKeyExist = (adapter.ProductGenericRepository.GetAll().FindAll(y => y.CustomerId == x.CustomerID).Count() != 0),
                    }).OrderByDescending(y => y.CreatedDateTime).ToList();

                    return lstCustomerModel;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public List<ComboModel> GetAllComboModel()
        {
            try
            {
                List<CustomerModel> lstCustomerModel = GetAll().OrderBy(x => x.CustomerID).ToList();

                return lstCustomerModel.Select(x => new ComboModel()
                {
                    Value = x.CustomerID.ToString(),
                    Text = x.CustomerID + " - " + x.FirstName
                }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public CustomerModel GetRecordeByFieldValue(string field, string value)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerModel>();
            });

            IMapper iMapper = config.CreateMapper();
            using (DataAdapter adapter = new DataAdapter())
            {
                switch (field)
                {
                    case "NicPassport":
                        return iMapper.Map<Customer, CustomerModel>(adapter.CustomerGenericRepository.GetById(x => x.NICPassport == value));
                    case "Email":
                        return iMapper.Map<Customer, CustomerModel>(adapter.CustomerGenericRepository.GetById(x => x.Email == value));
                    default:
                        return null;
                }

            }
        }

        public string GetUserID(CustomerModel _oCustomerModel)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerModel>();
                });

                IMapper iMapper = config.CreateMapper();

                using (DataAdapter adapter = new DataAdapter())
                {
                    string code = "";

                    int maxId = GetByMaxId();

                    code = _oCustomerModel.FirstName.Substring(0, 1).ToUpper() + maxId.ToString().PadLeft(8, '0');
                    return code;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }
    
}
}