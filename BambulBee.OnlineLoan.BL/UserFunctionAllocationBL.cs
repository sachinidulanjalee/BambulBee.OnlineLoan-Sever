using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.REPOSITORY;
using System;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.BL
{
    public class UserFunctionAllocationBL
    {
        public void Add(DataAdapter dataAdapter, UserFunctionAllocationModel _oUserFunctionAllocationModel)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserFunctionAllocationModel, UserFunctionAllocation>();
                });

                IMapper iMapper = config.CreateMapper();

                dataAdapter.UserFunctionAllocationRepository.Add(iMapper.Map<UserFunctionAllocationModel, UserFunctionAllocation>(_oUserFunctionAllocationModel));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void Edit(DataAdapter dataAdapter, UserFunctionAllocationModel _oUserFunctionAllocationModel)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserFunctionAllocationModel, UserFunctionAllocation>();
                });

                IMapper iMapper = config.CreateMapper();

                dataAdapter.UserFunctionAllocationRepository.Edit(iMapper.Map<UserFunctionAllocationModel, UserFunctionAllocation>(_oUserFunctionAllocationModel));
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public void Delete(DataAdapter dataAdapter,  int userID)
        {
            try
            {

              dataAdapter.UserFunctionAllocationRepository.DeleteByPram(x => x.UserID == userID);
               
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public bool BulkDelete(List<UserFunctionAllocationModel> data)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<UserFunctionAllocationModel, UserFunctionAllocation>();
                    });

                    IMapper iMapper = config.CreateMapper();
                    adapter.UserFunctionAllocationRepository.BulkDelete(iMapper.Map<List<UserFunctionAllocationModel>, List<UserFunctionAllocation>>(data));

                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }

        public UserFunctionAllocationModel GetByPrimaryKey(int userID, int functionID)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserFunctionAllocation, UserFunctionAllocationModel>();
            });

            IMapper iMapper = config.CreateMapper();
            using (DataAdapter adapter = new DataAdapter())
            {
                return iMapper.Map<UserFunctionAllocation, UserFunctionAllocationModel>(adapter.UserFunctionAllocationRepository.GetById(x => x.UserID == userID && x.FunctionID == functionID));
            }
        }

    public List<UserFunctionAllocationModel> GetByUserID(int userID)
    {
      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<UserFunctionAllocation, UserFunctionAllocationModel>();
      });

      IMapper iMapper = config.CreateMapper();
      using (DataAdapter adapter = new DataAdapter())
      {
        return iMapper.Map<List<UserFunctionAllocation>, List<UserFunctionAllocationModel>>(adapter.UserFunctionAllocationRepository.GetByValues(x => x.UserID == userID));
      }
    }

    public List<UserFunctionAllocationModel> GetAll()
    {
      try
      {
        var config = new MapperConfiguration(cfg =>
        {
          cfg.CreateMap<UserFunctionAllocation, UserFunctionAllocationModel>();
        });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    return iMapper.Map<List<UserFunctionAllocation>, List<UserFunctionAllocationModel>>(adapter.UserFunctionAllocationRepository.GetAll());
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
