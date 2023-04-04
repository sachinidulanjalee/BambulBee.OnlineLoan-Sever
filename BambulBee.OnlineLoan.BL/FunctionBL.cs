using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BumbleBee.OnlineLoan.BL
{
    public class FunctionBL
    {
        public List<FunctionModel> GetAll()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Function, FunctionModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    return iMapper.Map<List<Function>, List<FunctionModel>>(adapter.FunctionRepository.GetAll());
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
                List<FunctionModel> lstBooksModel = GetAll().OrderBy(x => x.FunctionID).ToList();

                return lstBooksModel.Select(x => new ComboModel()
                {
                    Value = x.FunctionID.ToString(),
                    Text = x.FunctionID + " - " + x.FunctionName
                }).ToList();
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw;
            }
        }

        public FunctionModel GetByPrimaryKey(int functionID)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Function, FunctionModel>();
            });

            IMapper iMapper = config.CreateMapper();
            using (DataAdapter adapter = new DataAdapter())
            {
                return iMapper.Map<Function, FunctionModel>(adapter.FunctionRepository.GetById(x => x.FunctionID == functionID));
            }
        }

        public List<FunctionModel> GetByUserID(int userId)
        {
            try
            {
                UserFunctionAllocationBL userFunctionAllocationBL = new UserFunctionAllocationBL();
                var userFunctions = userFunctionAllocationBL.GetByUserID(userId);
                var functions = GetAll();

                return (from a in userFunctions
                        join b in functions
                             on a.FunctionID equals b.FunctionID
                        select (b)).OrderBy(x => x.SortOrder).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
