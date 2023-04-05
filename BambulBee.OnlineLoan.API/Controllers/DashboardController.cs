using BambulBee.OnlineLoan.BL;
using BambulBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BambulBee.OnlineLoan.API.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Dashboard/[action]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        public DashboardBL _oDashboardBL = null;

        public DashboardController()
        {
            this._oDashboardBL = new DashboardBL();
        }

        [HttpGet]
        [ActionName("GetCountByStatusComboModel")]
        public List<ComboDashboardModel> GetCountByStatusComboModel()
        {
            return _oDashboardBL.GetCountByStatusComboModel();
        }

        [HttpGet]
        [ActionName("GetInactiveProductCount")]
        public int GetInactiveProductCount()
        {

            return _oDashboardBL.GetInactiveProductCount();
        }

        [HttpGet]
        [ActionName("GetAllProductCount")]
        public int GetAllProductCount()
        {

            return _oDashboardBL.GetAllProductCount();
        }


        [HttpGet]
        [ActionName("GetCountByProductComboModel")]
        public List<ComboDashboardModel> GetCountByProductComboModel()
        {
            return _oDashboardBL.GetCountByProductComboModel();
        }

        [HttpGet]
        [ActionName("GetAllCategoryCount")]
        public int GetAllCategoryCount()
        {

            return _oDashboardBL.GetAllCategoryCount();
        }

    }
}
