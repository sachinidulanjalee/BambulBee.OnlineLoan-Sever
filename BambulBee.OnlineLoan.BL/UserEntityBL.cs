using AutoMapper;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BumbleBee.OnlineLoan.BL
{
  public class UserEntityBL
  {
    private UserBL _oUserBL = new UserBL();
    private UserFunctionAllocationBL _oUserFunctionAllocationBL = new UserFunctionAllocationBL();

    private UserFunctionAllocationModel _oUserFunctionAllocationModel = new UserFunctionAllocationModel();

    public bool Add(UserModel _oUserModel)
    {
      try
      {
              bool status = false;

                using (DataAdapter adapter = new DataAdapter())
                {
                    int UserID = _oUserBL.Add(adapter, _oUserModel);

          if (_oUserModel.FuncationIDs.Count > 0)
          {
            int count = 0;
            while (count < _oUserModel.FuncationIDs.Count)
            {
              _oUserFunctionAllocationModel.UserID = UserID;
              _oUserFunctionAllocationModel.FunctionID = Convert.ToInt32(_oUserModel.FuncationIDs[count]);
              _oUserFunctionAllocationModel.CreatedDateTime = _oUserModel.CreatedDateTime;
              _oUserFunctionAllocationModel.CreatedUser = _oUserModel.CreatedUser;
              _oUserFunctionAllocationModel.CreatedMachine = _oUserModel.CreatedMachine;

              _oUserFunctionAllocationBL.Add(adapter, _oUserFunctionAllocationModel);

              count++;
            }
          }
          status = adapter.Save();
        }
        return status;
      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw ex;
      }
    }

    public bool Edit(UserModel _oUserModel)
        {
      try
      {
        bool status = false;

        using (DataAdapter adapter = new DataAdapter())
        {
          _oUserBL.Edit(adapter, _oUserModel);

          if (_oUserModel.FuncationIDs.Count > 0)
          {
            _oUserFunctionAllocationBL.Delete(adapter, _oUserModel.UserID);
            int count = 0;
            while (count < _oUserModel.FuncationIDs.Count)
            {
              _oUserFunctionAllocationModel.UserID = _oUserModel.UserID;
              _oUserFunctionAllocationModel.FunctionID = Convert.ToInt32(_oUserModel.FuncationIDs[count]);
              _oUserFunctionAllocationModel.CreatedDateTime = _oUserModel.CreatedDateTime;
              _oUserFunctionAllocationModel.CreatedUser = _oUserModel.CreatedUser;
              _oUserFunctionAllocationModel.CreatedMachine = _oUserModel.CreatedMachine;

              _oUserFunctionAllocationBL.Add(adapter, _oUserFunctionAllocationModel);

              count++;
            }
          }
          status = adapter.Save();
        }
        return status;
      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw ex;
      }
    }

    public UserModel GetByPrimaryKey(int userID)
    {
      try
      {
        UserModel _oUserModel = _oUserBL.GetByPrimaryKey(userID);
        List<UserFunctionAllocationModel> lstUserFunctionAllocationModel = _oUserFunctionAllocationBL.GetByUserID(userID);
        _oUserModel.FuncationIDs = lstUserFunctionAllocationModel.Select(x => x.FunctionID.ToString()).ToList();
       // _oUserModel.FuncationIDs = null;

        return _oUserModel;
      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

    public List<UserModel> GetAll()
    {
      try
      {
        List<UserModel> lstUserModel = _oUserBL.GetAll();
        List<UserFunctionAllocationModel> lstUserFunctionAllocationModel = _oUserFunctionAllocationBL.GetAll();


        lstUserModel = lstUserModel.Select (a => new UserModel()
                                      {
                                          UserID = a.UserID,
                                          UserName = a.UserName,
                                          Password = a.Password,
                                          UserType = a.UserType,
                                          Email = a.Email,
                                          MobileNo = a.MobileNo,
                                          ExpiryDate = a.ExpiryDate,
                                          MaximumAttemps = a.MaximumAttemps,
                                          Status = a.Status,
                                          CreatedDateTime = a.CreatedDateTime,
                                          CreatedUser = a.CreatedUser,
                                          CreatedMachine = a.CreatedMachine,
                                          ModifiedDateTime = a.ModifiedDateTime,
                                          ModifiedUser = a.ModifiedUser,
                                          ModifiedMachine = a.ModifiedMachine,
                                          FuncationIDs = lstUserFunctionAllocationModel.FindAll(x => x.UserID == a.UserID).Select(x => x.FunctionID.ToString()).ToList(),
                                          }).ToList();


          return lstUserModel;

      }
      catch (Exception ex)
      {
        Logger.Write(ex);
        throw;
      }
    }

        public bool UserAdd(UserModel _oUserModel)
        {
            try
            {
                bool status = false;

                using (DataAdapter adapter = new DataAdapter())
                {
                    int UserID = _oUserBL.Add(adapter, _oUserModel);

                    
                    status = adapter.Save();
                }
                return status;
            }
            catch (Exception ex)
            {
                Logger.Write(ex);
                throw ex;
            }
        }


    }
}
