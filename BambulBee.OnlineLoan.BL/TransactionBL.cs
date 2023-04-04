using AutoMapper;
using BambulBee.OnlineLoan.MODEL;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BambulBee.OnlineLoan.BL
{
    public class TransactionBL
    {

        public bool Add(TransactionModel _oTransactionModel)
        {
            bool _Result = false;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TransactionModel, Transaction>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.TransactionGenericRepository.Add(iMapper.Map<TransactionModel, Transaction>(_oTransactionModel));
                    _Result = adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _Result;
        }

        public bool Edit(TransactionModel _oTransactionModel)
        {
            bool _Result = false;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TransactionModel, Transaction>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.TransactionGenericRepository.Edit(iMapper.Map<TransactionModel, Transaction>(_oTransactionModel));
                    _Result = adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _Result;
        }
        public List<TransactionModel> GetAll()
        {
            List<TransactionModel> lstTransactionModel = new List<TransactionModel>();

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {

                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Transaction, TransactionModel>();
                    });
                    IMapper iMapper = config.CreateMapper();
                    List<Transaction> _Transaction = adapter.TransactionGenericRepository.GetAll();
                    List<Product> _Product = adapter.ProductGenericRepository.GetAll();
                    List<Customer> _oCustomer = adapter.CustomerGenericRepository.GetAll();

                    lstTransactionModel = (from a in _Transaction
                                           join b in _Product
                                                on a.ProductId
                                                equals b.ProductId
                                           join c in _oCustomer
                                                on a.UserId equals c.UserID

                                           select new TransactionModel
                                           {
                                               TransactionId = a.TransactionId,
                                               ProductId = a.ProductId,
                                               UserId = a.UserId,
                                               InstallmentPlan = a.InstallmentPlan,
                                               LoanAmount = a.LoanAmount,
                                               UsedAmount = a.UsedAmount,
                                               InterestRate = a.InterestRate,
                                               ProductName = b.ProductName,
                                               UserName = c.ShortName,
                                               CreatedDateTime = a.CreatedDateTime,
                                               CreatedUser = a.CreatedUser,
                                               CreatedMachine = a.CreatedMachine,
                                               ModifiedDateTime = a.ModifiedDateTime,
                                               ModifiedUser = a.ModifiedUser,
                                               ModifiedMachine = a.ModifiedMachine,
                                           }).ToList();
                }

            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return lstTransactionModel;
        }

        public bool Delete(int TransctionId, int ProductId, int userId)
        {
            bool _Result = false;
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    adapter.TransactionGenericRepository.DeleteByPram(x => x.ProductId == ProductId && x.UserId == userId && x.TransactionId == TransctionId);
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return _Result;
        }

        public TransactionModel GetByPrimaryKey(int TransctionId, int ProductId, int userId)
        {
            TransactionModel _oTransactionModel = null;

            try
            {
                _oTransactionModel = GetAll().Find(x => x.TransactionId == TransctionId && x.ProductId == ProductId && x.UserId == userId);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _oTransactionModel;
        }

        public bool BulkDelete(List<TransactionModel> data)
        {
            bool _Result = false;
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<TransactionModel, Transaction>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.TransactionGenericRepository.BulkDelete(iMapper.Map<List<TransactionModel>, List<Transaction>>(data));
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return _Result;
        }

        public List<ComboModel> GetComboModel()
        {
            List<ComboModel> lstComboModel = new List<ComboModel>();

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    lstComboModel = adapter.ProductGenericRepository.GetAll().Select(x => new ComboModel
                    {
                        Value = x.ProductId.ToString(),
                        Text = x.ProductName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return lstComboModel;
        }
    }
}
