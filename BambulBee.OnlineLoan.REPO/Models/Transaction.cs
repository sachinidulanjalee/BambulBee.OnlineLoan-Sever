using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    [Table("Transaction")]
    public class Transaction
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Column(Order = 0)]
            public int TransactionId { get; set; }

            [Column(Order = 1)]
            [StringLength(100)]
            public int ProductId { get; set; }

            [Column(Order = 2)]
            [StringLength(100)]
            public int UserId { get; set; }

            [Column(Order = 3)]
            public int InstallmentPlan { get; set; }

            [Column(Order = 4)]
            public decimal InterestRate  { get; set; }

            [Column(Order = 5)]
            public Decimal LoanAmount { get; set; }

            [Column(Order = 6)]
            public Decimal UsedAmount { get; set; }
     
            public DateTime CreatedDateTime { get; set; }

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
