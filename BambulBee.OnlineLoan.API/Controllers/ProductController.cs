using BumbleBee.OnlineLoan.BUSINESS;
using BumbleBee.OnlineLoan.MODEL;
using BumbleBee.OnlineLoan.REPOSITORY;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Product/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        public ProductBL _oProductBL = null;

        public ProductController()
        {
            this._oProductBL = new ProductBL();
        }

        [HttpPost]
        [ActionName("Add")]
        public bool Add([FromBody] ProductModel ProductModel)
        {
            return _oProductBL.Add(ProductModel);
        }

        [HttpPut]
        [ActionName("Edit")]
        public bool Edit([FromBody] ProductModel ProductModel)
        {
            return _oProductBL.Edit(ProductModel);
        }

        [HttpDelete("{ProductId}/{customerId}")]
        [ActionName("Delete")]
        public bool Delete([FromRoute] int ProductId, int customerId)
        {
            return _oProductBL.Delete(ProductId, customerId);
        }

        [HttpGet("{ProductId}/{customerId}")]
        [ActionName("GetByPrimaryKey")]
        public ProductModel GetByPrimaryKey([FromRoute] int ProductId, int customerId)
        {
            return _oProductBL.GetByPrimaryKey(ProductId, customerId);
        }

        [ActionName("GetComboModel")]
        public List<ComboModel> GetComboModel()
        {
            return _oProductBL.GetComboModel();
        }

        [HttpGet("{customerId}")]
        [ActionName("GetAll")]
        public List<ProductModel> GetAll(int customerId)
        {
            return _oProductBL.GetAll(customerId);
        }

        [HttpPost]
        [ActionName("BulkRemove")]
        public bool BulkRemove([FromBody] List<ProductModel> data)
        {
            return _oProductBL.BulkDelete(data);
        }
    }
}