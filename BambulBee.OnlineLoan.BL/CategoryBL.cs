using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BumbleBee.OnlineLoan.BUSINESS
{
    public class CategoryBL
    {
        public List<CategoryModel> GetAll()
        {
            List<CategoryModel> lstCategoryModel = new List<CategoryModel>();

            try
            {
                using (DataAdapter dataAdapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Category, CategoryModel>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    lstCategoryModel = iMapper.Map<List<Category>, List<CategoryModel>>(dataAdapter.CategoryGenericRepository.GetAll());
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return lstCategoryModel;
        }

        public bool Add(CategoryModel _oCategoryModel)
        {
            bool _Result = false;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CategoryModel, Category>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.CategoryGenericRepository.Add(iMapper.Map<CategoryModel, Category>(_oCategoryModel));
                    _Result = adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _Result;
        }

        public bool Edit(CategoryModel _oCategoryModel)
        {
            bool _Result = false;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CategoryModel, Category>();
                    });

                    IMapper iMapper = config.CreateMapper();

                    adapter.CategoryGenericRepository.Edit(iMapper.Map<CategoryModel, Category>(_oCategoryModel));
                    _Result = adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _Result;
        }

        public bool Delete(int CategoryId)
        {
            bool _Result = false;
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    adapter.CategoryGenericRepository.DeleteByPram(x => x.CategoryId == CategoryId);
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return _Result;
        }

        public CategoryModel GetByPrimaryKey(int _oCategoryId)
        {
            CategoryModel _oCategoryModel = null;

            try
            {
                _oCategoryModel = GetAll().Find(x => x.CategoryId == _oCategoryId);
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return _oCategoryModel;
        }

        public List<ComboModel> GetComboModel()
        {
            List<ComboModel> lstComboModel = new List<ComboModel>();

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    lstComboModel = adapter.CategoryGenericRepository.GetAll().Select(x => new ComboModel
                    {
                        Value = x.CategoryId.ToString(),
                        Text = x.CategoryName
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }

            return lstComboModel;
        }

        public bool BulkDelete(List<CategoryModel> data)
        {
            bool _Result = false;
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CategoryModel, Category>();
                    });

                    IMapper iMapper = config.CreateMapper();
                    adapter.CategoryGenericRepository.BulkDelete(iMapper.Map<List<CategoryModel>, List<Category>>(data));

                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
            }
            return _Result;
        }
    }
}