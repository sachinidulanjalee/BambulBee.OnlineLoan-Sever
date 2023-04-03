
using BumbleBee.OnlineLoan.BL;
using BumbleBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BambulBee.OnlineLoan.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Function/[action]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        public FunctionBL _oFunctionBL = null;

        public FunctionController()
        {
            this._oFunctionBL = new FunctionBL();
        }

        [HttpGet("{functionID}")]
        [ActionName("GetById")]
        public FunctionModel GetByPrimaryKey([FromRoute] int functionID)
        {
            return _oFunctionBL.GetByPrimaryKey(functionID);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<FunctionModel> GetAll()
        {
            return _oFunctionBL.GetAll();
        }

        [HttpGet]
        [ActionName("GetAllComboModel")]
        public List<ComboModel> GetAllComboModel()
        {
            return _oFunctionBL.GetAllComboModel();
        }

        [HttpGet("{UserId}")]
        [ActionName("GetByUserID")]
        public List<FunctionModel> GetByUserID([FromRoute] int UserId)
        {
            return _oFunctionBL.GetByUserID(UserId);
        }
    }
}