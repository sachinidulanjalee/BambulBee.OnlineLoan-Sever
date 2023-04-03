using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumbleBee.OnlineLoan.REPOSITORY
{
    [Table("Custormer")]
    public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        public int CustomerId { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Column(Order = 2)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Column(Order = 3)]
        public DateTime DateOfBirth { get; set; }

        [Column(Order = 4)]
        [StringLength(100)]
        public string email { get; set; }

        [Column(Order = 5)]
        public string Mobile { get; set; }

        [Column(Order = 6)]
        public int? Gender { get; set; }

        [Column(Order = 7)]
        [StringLength(10)]
        public string NICNo { get; set; }

        [Column(Order = 8)]
        public DateTime DateOfJoining { get; set; }
        [Column(Order = 9)]
        [StringLength(250)]
        public string Password { get; set; }

        [Column(Order = 10)]
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
