using BumbleBee.OnlineLoan.BUSINESS;
using BumbleBee.OnlineLoan.MODEL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Category/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        public CategoryBL _oCategoryBL = null;

        public CategoryController()
        {
            this._oCategoryBL = new CategoryBL();
        }

        [HttpPost]
        [ActionName("Add")]
        public bool Add([FromBody] CategoryModel CategoryModel)
        {
            return _oCategoryBL.Add(CategoryModel);
        }

        [HttpPut]
        [ActionName("Edit")]
        public bool Edit([FromBody] CategoryModel CategoryModel)
        {
            return _oCategoryBL.Edit(CategoryModel);
        }

        [HttpDelete("{CategoryId}")]
        [ActionName("Delete")]
        public bool Delete([FromRoute] int CategoryId)
        {
            return _oCategoryBL.Delete(CategoryId);
        }

        [HttpGet("{CategoryId}")]
        [ActionName("GetByPrimaryKey")]
        public CategoryModel GetByPrimaryKey([FromRoute] int CategoryId)
        {
            return _oCategoryBL.GetByPrimaryKey(CategoryId);
        }

        [ActionName("GetComboModel")]
        public List<ComboModel> GetComboModel()
        {
            return _oCategoryBL.GetComboModel();
        }

        [HttpGet]
        [ActionName("GetAll")]
        public List<CategoryModel> GetAll()
        {
            return _oCategoryBL.GetAll();
        }

        [HttpPost]
        [ActionName("BulkRemove")]
        public bool BulkRemove([FromBody] List<CategoryModel> data)
        {
            return _oCategoryBL.BulkDelete(data);
        }
    }
}