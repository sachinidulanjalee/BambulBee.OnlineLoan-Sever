using AutoMapper;
using BambulBee.OnlineLoan.COMMON;
using BambulBee.OnlineLoan.REPOSITORY;
using BumbleBee.OnlineLoan.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BumbleBee.OnlineLoan.BL
{
    public class UserBL
    {
        public int Add(DataAdapter dataAdapter, UserModel _oUserModel)
        {
            try
            {
                _oUserModel.UserID = GetByMaxId() + 1;

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserModel, User>();
                });

                IMapper iMapper = config.CreateMapper();
                _oUserModel.Password = DMSSWE.CryptoUtil.Encrypt(_oUserModel.UserName.Trim(), _oUserModel.Password);

                dataAdapter.UserRepository.Add(iMapper.Map<UserModel, User>(_oUserModel));
                dataAdapter.Save();
                return _oUserModel.UserID;
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw ex;
            }
        }

        public void Edit(DataAdapter dataAdapter, UserModel _oUserModel)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<UserModel, User>();
                });

                IMapper iMapper = config.CreateMapper();

                dataAdapter.UserRepository.Edit(iMapper.Map<UserModel, User>(_oUserModel));
            }
            catch (Exception ex)
            {
              //  Logger.Write(ex);
                throw ex;
            }
        }

        public bool Delete(int UserID)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    adapter.UserRepository.DeleteByPram(x => x.UserID == UserID);
                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw ex;
            }
        }

        public bool BulkDelete(List<UserModel> data)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<UserModel, User>();
                    });

                    IMapper iMapper = config.CreateMapper();
                    adapter.UserRepository.BulkDelete(iMapper.Map<List<UserModel>, List<User>>(data));

                    return adapter.Save();
                }
            }
            catch (Exception ex)
            {
             //   Logger.Write(ex);
                throw ex;
            }
        }

        public UserModel GetByPrimaryKey(int UserID)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserModel>();
            });

            IMapper iMapper = config.CreateMapper();
            using (DataAdapter adapter = new DataAdapter())
            {
                return iMapper.Map<User, UserModel>(adapter.UserRepository.GetById(x => x.UserID == UserID));
            }
        }

        public int GetByMaxId()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<UserModel> lstBooksModel = iMapper.Map<List<User>, List<UserModel>>(adapter.UserRepository.GetAll());
                    return lstBooksModel.Select(p => p.UserID).DefaultIfEmpty(0).Max();
                }
            }
            catch (Exception ex)
            {
              //  Logger.Write(ex);
                throw;
            }
        }

        public List<ComboModel> GetAllComboModel()
        {
            try
            {
                List<UserModel> lstUserModel = GetAll().OrderByDescending(x => x.UserID).ToList();

                return lstUserModel.Select(x => new ComboModel()
                {
                    Value = x.UserID.ToString(),
                    Text = x.UserID + " - " + x.UserName
                }).ToList();
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw;
            }
        }

        public List<UserModel> GetAll()
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserModel>();
                });

                IMapper iMapper = config.CreateMapper();
                using (DataAdapter adapter = new DataAdapter())
                {
                    List<UserModel> lstUserModel= iMapper.Map<List<User>, List<UserModel>>(adapter.UserRepository.GetAll());
                    
                    lstUserModel = lstUserModel.OrderByDescending(y => y.CreatedDateTime).ToList();

                    return lstUserModel;
                }
            }
            catch (Exception ex)
            {
                //Logger.Write(ex);
                throw;
            }
        }

        public User GetByUserNamePassword(string userName, string Password)
        {
            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {
                    return adapter.UserRepository.GetById(x => x.UserName == userName && x.Password == Password);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object Login(string userName, string password)
        {
            object result = null;

            try
            {
                //var _oUser = GetByUserNamePassword(userName, password);
                  var _oUser = GetByUserNamePassword(userName, DMSSWE.CryptoUtil.Encrypt(userName.Trim(),password));
                if (_oUser == null)
                {
                    return new { result = 0, UserID = 0,UserName="", msg = "Invalid User." };
                }
                else
                {
                    switch (_oUser.Status)
                    {
                        case (int)UserStatus.NewUser:
                            result = new { result = (int)UserStatus.NewUser, UserID = _oUser.UserID, UserName = _oUser.UserName, msg = "New User." };
                            break;

                        case (int)UserStatus.Active:
                            result = new { result = (int)UserStatus.Active, UserID = _oUser.UserID, UserName = _oUser.UserName, msg = "Active User." };
                            break;

                        case (int)UserStatus.PasswordReset:
                            result = new { result = (int)UserStatus.PasswordReset, UserID = _oUser.UserID,UserName=_oUser.UserName, msg = "Password reset required." };
                            break;

                        case (int)UserStatus.AutoInactive:
                            result = new { result = (int)UserStatus.AutoInactive, UserID = _oUser.UserID, UserName = _oUser.UserName, msg = "Account already auto inactivated." };
                            break;

                        case (int)UserStatus.Inactive:
                            result = new { result = (int)UserStatus.AutoInactive, UserID = _oUser.UserID, UserName = _oUser.UserName, msg = "Account already inactivated." };
                            break;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object ChangePassword(string userName, string oldPassword, string newPassword)
        {
            object result = null;

            try
            {
                using (DataAdapter adapter = new DataAdapter())
                {


                    var _oUser = GetByUserNamePassword(userName, DMSSWE.CryptoUtil.Encrypt(userName, oldPassword));
                    if (_oUser == null)
                    {
                        return new { result = false, msg = "Invalid User." };
                    }
                    else
                    {
                        switch (_oUser.Status)
                        {
                            case (int)UserStatus.NewUser:

                                _oUser.Status = (int)UserStatus.Active;
                                _oUser.Password = DMSSWE.CryptoUtil.Encrypt(userName, newPassword);
                                adapter.UserRepository.Edit(_oUser);
                                result = new { result = adapter.Save(), msg = "User Actived." };
                                break;

                            default:
                                result = new { result = false, msg = "Invalid User Status." };
                                break;
                        }
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
