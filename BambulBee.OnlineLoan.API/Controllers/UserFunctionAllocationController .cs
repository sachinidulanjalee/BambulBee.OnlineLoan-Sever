using BumbleBee.OnlineLoan.BL;
using BumbleBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BambulBee.OnlineLoan.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/UserFunctionAllocation/[action]")]
    [ApiController]
    public class UserFunctionAllocationController : ControllerBase
    {
        public UserFunctionAllocationBL _oUserFunctionAllocationBL = null;

        public UserFunctionAllocationController()
        {
            this._oUserFunctionAllocationBL = new UserFunctionAllocationBL();
        }

        [HttpPost]
        [ActionName("BulkRemove")]
        public bool BulkRemove([FromBody] List<UserFunctionAllocationModel> data)
        {
            return _oUserFunctionAllocationBL.BulkDelete(data);
        }

        [HttpGet("{userID}/{funcatinID}")]
        [ActionName("GetById")]
        public UserFunctionAllocationModel GetByPrimaryKey([FromRoute] int userID, int funcatinID)
        {
            return _oUserFunctionAllocationBL.GetByPrimaryKey(userID, funcatinID);
        }



        [HttpGet]
        [ActionName("GetAll")]
        public List<UserFunctionAllocationModel> GetAll()
        {
            return _oUserFunctionAllocationBL.GetAll();
        }
    }
}
