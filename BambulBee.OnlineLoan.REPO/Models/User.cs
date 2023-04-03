using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.REPOSITORY.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int UserID { get; set; }

        [Column(Order = 1)]
        [StringLength(100)]
        public string UserName { get; set; }

        [Column(Order = 3)]
        [StringLength(250)]
        public string Email { get; set; }


        [Column(Order = 4)]
        [StringLength(100)]
        public string Password { get; set; }

        [Column(Order = 5)]
        [StringLength(100)]
        public string MobileNo { get; set; }

        [Column(Order = 6)]
        public DateTime? ExpiryDate { get; set; }

        [Column(Order = 7)]
        public int? MaximumAttemps { get; set; }

        [Column(Order = 8)]
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
