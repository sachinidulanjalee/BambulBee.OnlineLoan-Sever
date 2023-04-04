using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CustomerId { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public int CategoryId { get; set; }

        [Column(Order = 3)]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Column(Order = 4)]
        [StringLength(100)]
        public string Brand { get; set; }

        [Column(Order = 5)]
        [StringLength(100)]
        public decimal UnitPrice { get; set; }

        [Column(Order = 6)]
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
