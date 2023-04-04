using BambulBee.OnlineLoan.BL;
using BambulBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.BUSINESS;
using BumbleBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Transaction/[action]")]
    [ApiController]
    public class TransactionController : Controller
    {
        public TransactionBL _oTransactionBL = null;

        public TransactionController()
        {
            this._oTransactionBL = new TransactionBL();
        }

        [HttpPost]
        [ActionName("Add")]
        public bool Add([FromBody] TransactionModel TransactionModel)
        {
            return _oTransactionBL.Add(TransactionModel);
        }

        [HttpPut]
        [ActionName("Edit")]
        public bool Edit([FromBody] TransactionModel TransactionModel)
        {
            return _oTransactionBL.Edit(TransactionModel);
        }

        [HttpDelete("{TransactionId}/{ProductId}/{UserId}")]
        [ActionName("Delete")]
        public bool Delete([FromRoute] int TransactionId, int ProductId, int UserId)
        {
            return _oTransactionBL.Delete(TransactionId, ProductId, UserId);
        }

        [HttpGet("{TransactionId}/{ProductId}/{UserId}")]
        [ActionName("GetByPrimaryKey")]
        public TransactionModel GetByPrimaryKey([FromRoute] int TransactionId, int ProductId, int UserId)
        {
            return _oTransactionBL.GetByPrimaryKey(TransactionId, ProductId, UserId);
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<TransactionModel> GetAll()
        {
            return _oTransactionBL.GetAll();
        }

        [HttpPost]
        [ActionName("BulkDelete")]
        public bool BulkRemove([FromBody] List<TransactionModel> data)
        {
            return _oTransactionBL.BulkDelete(data);
        }
    }
}