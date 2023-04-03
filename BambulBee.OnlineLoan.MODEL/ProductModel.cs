using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.MODEL
{

    public class ProductModel: ProductModelExtended
    {
 
        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string Brand { get; set; }

        public decimal UnitPrice { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }

    }
    public abstract class ProductModelExtended
    {
        public string CategoryName { get; set; }
    }
}
