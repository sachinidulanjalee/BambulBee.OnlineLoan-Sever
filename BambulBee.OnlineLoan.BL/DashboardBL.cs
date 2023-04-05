using AutoMapper;
using BambulBee.OnlineLoan.COMMON;
using BambulBee.OnlineLoan.MODEL;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BambulBee.OnlineLoan.BL
{
   public class DashboardBL
    {
        public List<ComboDashboardModel> GetCountByStatusComboModel()
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

                    return lstCustomerModel.GroupBy(x => x.Sex).
                    Select(x => new ComboDashboardModel()
                    {
                        Value = x.Count(),
                        Name = Enum.GetName(typeof(sex), Convert.ToInt32(x.First().Sex))

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public int GetInactiveProductCount()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<ProductModel> lstProductModel = iMapper.Map<List<Product>, List<ProductModel>>(adapter.ProductGenericRepository.GetAll().Where(y => y.Status == (int)Status.Inactive).ToList());

                    int var = (from p in lstProductModel

                               select new
                               {
                                   Count = p.ProductId,

                               }).Count();


                    return var;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public int GetAllProductCount()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<ProductModel> lstProductModel = iMapper.Map<List<Product>, List<ProductModel>>(adapter.ProductGenericRepository.GetAll().Where(y => y.Status == (int)Status.Active).ToList());

                    int var = (from p in lstProductModel

                               select new
                               {
                                   Count = p.ProductId,

                               }).Count();


                    return var;
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public List<ComboDashboardModel> GetCountByProductComboModel()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Product, ProductModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<ProductModel> lstProductModel = iMapper.Map<List<Product>, List<ProductModel>>(adapter.ProductGenericRepository.GetAll());

                    List<CategoryModel> lstCategoryModel = ((new MapperConfiguration(cfg =>
                    { cfg.CreateMap<Category, CategoryModel>(); }))
                      .CreateMapper()).Map<List<Category>, List<CategoryModel>>(adapter.CategoryGenericRepository.GetAll());


                    lstProductModel = (from a in lstProductModel
                                     join b in lstCategoryModel
                                     on a.CategoryId equals b.CategoryId

                                       select new ProductModel()
                                     {
                                         ProductId = a.ProductId,
                                         CategoryId = a.CategoryId,
                                         CategoryName = b.CategoryName,
                                     }).ToList();

                    return lstProductModel.GroupBy(x => x.CategoryId).
                    Select(x => new ComboDashboardModel()
                    {
                        Value = x.Count(),
                        Name = x.First().CategoryName,

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public int GetAllCategoryCount()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Category, CategoryModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<CategoryModel> lstCategoryModel = iMapper.Map<List<Category>, List<CategoryModel>>(adapter.CategoryGenericRepository.GetAll().Where(y => y.Status == (int)Status.Active).ToList());

                    int var = (from p in lstCategoryModel

                               select new
                               {
                                   Count = p.CategoryId,

                               }).Count();


                    return var;
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
