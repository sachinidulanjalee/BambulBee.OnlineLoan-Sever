using BumbleBee.OnlineLoan.BUSINESS;
using BumbleBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Customer/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public CustomerBL _oCustomerBL = null;

        public CustomerController()
        {
            this._oCustomerBL = new CustomerBL();
        }


        [HttpPost]
        [ActionName("Add")]
        public bool Add([FromBody] CustomerModel _oCustomerModel)
        {
            return _oCustomerBL.Add(_oCustomerModel);
        }

        [HttpPut]
        [ActionName("Edit")]
        public bool Edit([FromBody] CustomerModel _oCustomerModel)
        {
            return _oCustomerBL.Edit(_oCustomerModel);
        }

        [HttpDelete("{customerId}")]
        [ActionName("Delete")]
        public bool Delete([FromRoute] int customerId)
        {
            return _oCustomerBL.Delete(customerId);
        }

        [HttpPost]
        [ActionName("BulkRemove")]
        public bool BulkRemove([FromBody] List<CustomerModel> data)
        {
            return _oCustomerBL.BulkDelete(data);
        }

        [HttpGet("{userId}")]
        [ActionName("GetById")]
        public CustomerModel GetById([FromRoute] int userId)
        {
            return _oCustomerBL.GetById(userId);
        }

        [HttpGet("{status}")]
        [ActionName("GetComboModelByStatus")]
        public List<ComboModel> GetComboModelByStatus([FromRoute] int status)
        {
            return _oCustomerBL.GetComboModelByStatus(status);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<CustomerModel> GetAll()
        {
            return _oCustomerBL.GetAll();
        }

        [HttpGet]
        [ActionName("GetMemberCount")]
        public int GetMemberCount()
        {
            return _oCustomerBL.GetMemberCount();
        }
        [HttpGet]
        [ActionName("GetAllComboModel")]
        public List<ComboModel> GetAllComboModel()
        {
            return _oCustomerBL.GetAllComboModel();
        }

        [HttpGet("{field}/{value}")]
        [ActionName("GetRecordeByFieldValue")]
        public CustomerModel GetRecordeByFieldValue([FromRoute] string field, string value)
        {
            return _oCustomerBL.GetRecordeByFieldValue(field, value);
        }

    }
}
