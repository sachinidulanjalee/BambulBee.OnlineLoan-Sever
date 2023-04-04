using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BumbleBee.OnlineLoan.REPOSITORY
{
    [Table("UserFunctionAllocation")]
    public class UserFunctionAllocation
    {
        [Key]
        [Column(Order = 0)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int FunctionID { get; set; }

        [Column(Order = 2)]
        public DateTime CreatedDateTime { get; set; }

        [Column(Order = 3)]
        public string CreatedUser { get; set; }

        [Column(Order = 4)]
        public string CreatedMachine { get; set; }
    }
}