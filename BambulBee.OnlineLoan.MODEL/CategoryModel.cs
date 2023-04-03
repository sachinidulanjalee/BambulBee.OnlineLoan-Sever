using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.MODEL
{
   
    public class CategoryModel
    {
   
        public int CategoryId { get; set; }     
        public string CategoryName { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }


    }
}
