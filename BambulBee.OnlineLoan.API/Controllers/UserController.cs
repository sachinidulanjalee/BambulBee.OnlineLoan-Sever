using BumbleBee.OnlineLoan.BL;
using BumbleBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BambulBee.OnlineLoan.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/User/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserBL _oUserBL = null;
        public UserEntityBL _oUserEntityBL = null;

    public UserController()
    {
      this._oUserBL = new UserBL();
      this._oUserEntityBL = new UserEntityBL();
    }

        [HttpPost]
        [ActionName("Add")]
        public bool Add([FromBody] UserModel _oUserModel)
        {
            return _oUserEntityBL.Add(_oUserModel);
        }

    [HttpPut]
    [ActionName("Edit")]
    public bool Edit([FromBody] UserModel _oUserModel)
    {
      return _oUserEntityBL.Edit(_oUserModel);
    }

    [HttpGet("{userID}")]
    [ActionName("GetByPrimaryKey")]
    public UserModel GetByPrimaryKey([FromRoute] int userID)
    {
      return _oUserEntityBL.GetByPrimaryKey(userID);
    }

    [HttpGet]
    [ActionName("GetAll")]
    public List<UserModel> GetAll()
    {
      return _oUserEntityBL.GetAll();
    }


        #region Authentication

        [HttpGet("{UserName}/{Password}")]
        [ActionName("Login")]
        public object Login([FromRoute] string UserName, string password)
        {
            return _oUserBL.Login(UserName, password);
        }

        [HttpGet("{UserName}/{oldPassword}/{newPassword}")]
        [ActionName("ChangePassword")]
        public object ChangePassword([FromRoute] string UserName, string oldPassword, string newPassword)
        {
            return _oUserBL.ChangePassword(UserName, oldPassword, newPassword);
        }

        #endregion 
    }
}
