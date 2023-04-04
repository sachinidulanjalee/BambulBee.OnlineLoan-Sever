using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int CategoryId { get; set; }

        [Column(Order = 1)]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [Column(Order = 2)]
        public int? Status { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        [StringLength(50)]
        public string CreatedUser { get; set; }

        [StringLength(50)]
        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        [StringLength(50)]
        public string ModifiedUser { get; set; }

        [StringLength(50)]
        public string ModifiedMachine { get; set; }


    }
}
