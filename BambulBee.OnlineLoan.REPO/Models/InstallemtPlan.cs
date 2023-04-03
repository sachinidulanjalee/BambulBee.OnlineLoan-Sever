using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BumbleBee.OnlineLoan.REPOSITORY.Models
{
    [Table("InstallemtPlan")]
    public class InstallemtPlan
    {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Column(Order = 0)]
            public int InstllmentPlanId { get; set; }

            [Column(Order = 1)]
            [StringLength(100)]
            public string Description { get; set; }

            [Column(Order = 2)]
            public decimal InterestRate  { get; set; }

            [Column(Order = 3)]
            public Decimal MaximumLoanAmount { get; set; }
            [Column(Order = 4)]
            public int Duration { get; set; }
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
