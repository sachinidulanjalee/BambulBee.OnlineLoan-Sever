using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    [Table("User")]
    public class User
    {

            [Key]
            [Column(Order = 0)]
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int UserID { get; set; }

            [Column(Order = 1)]
            public string UserName { get; set; }

            [Column(Order = 2)]
            public string Password { get; set; }


            [Column(Order = 3)]
            public int UserType { get; set; }

            [Column(Order = 4)]
            public string Email { get; set; }

            [Column(Order = 5)]
            public string MobileNo { get; set; }
            [Column(Order = 6)]
            public DateTime? DateOfBirth { get; set; }

            [Column(Order = 7)]
            public DateTime? ExpiryDate { get; set; }

            [Column(Order = 8)]
            public int MaximumAttemps { get; set; }

            [Column(Order = 9)]
            public int Status { get; set; }

            [Column(Order = 10)]
            public DateTime CreatedDateTime { get; set; }

            [Column(Order = 11)]
            public string CreatedUser { get; set; }

            [Column(Order = 12)]
            public string CreatedMachine { get; set; }

            [Column(Order = 13)]
            public DateTime? ModifiedDateTime { get; set; }

            [Column(Order = 14)]
            public string ModifiedUser { get; set; }

            [Column(Order = 15)]
            public string ModifiedMachine { get; set; }
        }

   
}
