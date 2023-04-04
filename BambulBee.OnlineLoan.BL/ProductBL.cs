using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BumbleBee.OnlineLoan.BUSINESS
{
    public class ProductBL
    {
        public List<ProductModel> GetAll(int customerId)
        {

            List<ProductModel> lstProductModel = new List<ProductModel>();

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var _Category = adapter.CategoryGenericRepository.GetAll();
                    var _Product = adapter.ProductGenericRepository.GetByValues(x => x.CustomerId == customerId);

                    lstProductModel = (from a in _Product
                                       join b in _Category
                                      on a.CategoryId equals b.CategoryId
                                       select new ProductModel
                                       {
                                          ProductId = a.ProductId,
                                          ProductName = a.ProductName,
                                          CategoryId = a.CategoryId,
                                          Brand = a.Brand,
                                          UnitPrice = a.UnitPrice,
                                          Status = a.Status,
                                          CategoryName = b.CategoryName,
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

            return lstProductModel;
        }

        public bool Add(ProductModel _oProductModel)
        {
            bool _Result = false;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductModel, Product>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.ProductGenericRepository.Add(iMapper.Map<ProductModel, Product>(_oProductModel));
                    _Result = adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _Result;
        }

        public bool Edit(ProductModel _oProductModel)
        {
            bool _Result = false;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductModel, Product>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.ProductGenericRepository.Edit(iMapper.Map<ProductModel, Product>(_oProductModel));
                    _Result = adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _Result;
        }

        public bool Delete(int ProductId , int customerId)
        {
            bool _Result = false;
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    adapter.ProductGenericRepository.DeleteByPram(x => x.ProductId == ProductId && x.CustomerId == customerId);
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return _Result;
        }

        public ProductModel GetByPrimaryKey(int customerId, int _oProductId)
        {
            ProductModel _oProductModel = null;

            try
            {
                _oProductModel = GetAll(customerId).Find(x => x.ProductId == _oProductId);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _oProductModel;
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

        public bool BulkDelete(List<ProductModel> data)
        {
            bool _Result = false;
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<ProductModel, Product>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.ProductGenericRepository.BulkDelete(iMapper.Map<List<ProductModel>, List<Product>>(data));
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return _Result;
        }

        public List<ProductModel> AllCustomerProductGetAll()
        {

            List<ProductModel> lstProductModel = new List<ProductModel>();

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var _Category = adapter.CategoryGenericRepository.GetAll();
                    var _Product = adapter.ProductGenericRepository.GetAll();

                    lstProductModel = (from a in _Product
                                       join b in _Category
                                      on a.CategoryId equals b.CategoryId
                                       select new ProductModel
                                       {
                                           ProductId = a.ProductId,
                                           ProductName = a.ProductName,
                                           CategoryId = a.CategoryId,
                                           Brand = a.Brand,
                                           UnitPrice = a.UnitPrice,
                                           Status = a.Status,
                                           CategoryName = b.CategoryName,
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

            return lstProductModel;
        }
    }
}