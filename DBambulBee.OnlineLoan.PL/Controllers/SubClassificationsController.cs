using DMS.LIBRAYMANAGMANT.BL;
using DMS.LIBRAYMANAGMANT.MODEL;
using DMS.LIBRAYMANAGMANT.REPOSITORY;
using Microsoft.AspNetCore.Mvc;

namespace DMS.LIBRAYMANAGMANT.PL.Controllers
{
    [Produces("application/json")]
    [Route("api/SubClassifications/[action]")]
    [ApiController]
    public class SubClassificationsController : ControllerBase
    {
        public SubClassificationsBL _oSubClassificationsBL = null;

        public SubClassificationsController()
        {
            this._oSubClassificationsBL = new SubClassificationsBL();
        }

        [HttpPost]
        [ActionName("Add")]
        public bool Add([FromBody] SubClassificationsModel subClassificationsModel)
        {
            return _oSubClassificationsBL.Add(subClassificationsModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public bool Edit([FromBody] SubClassificationsModel subClassificationsModel)
        {
            return _oSubClassificationsBL.Edit(subClassificationsModel);
        }

        [HttpGet("{SubClassificationID}/{ClassificationID}")]
        [ActionName("DeleteByPram")]
        public bool DeleteByPram([FromRoute] int SubClassificationID, int ClassificationID)
        {
            return _oSubClassificationsBL.DeleteByPram(SubClassificationID, ClassificationID);
        }

        [HttpGet("{SubClassificationID}/{ClassificationID}")]
        [ActionName("GetById")]
        public SubClassificationsModel GetById([FromRoute] int SubClassificationID, int ClassificationID)
        {
            return _oSubClassificationsBL.GetById(SubClassificationID, ClassificationID);
        }

    }
}
