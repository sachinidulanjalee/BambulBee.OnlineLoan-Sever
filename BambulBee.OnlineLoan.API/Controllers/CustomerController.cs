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


        [HttpGet]
        [ActionName("GetAll")]
        public List<CustomerModel> GetAll()
        {
            return _oCustomerBL.GetAll();
        }

    }
}
