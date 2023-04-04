using System;
using System.Collections.Generic;
using System.Text;

namespace BambulBee.OnlineLoan.MODEL
{
    public class TransactionModel : TransactionModelExtended
    {

        public int TransactionId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int InstallmentPlan { get; set; }

        public decimal InterestRate { get; set; }

        public Decimal LoanAmount { get; set; }

        public Decimal UsedAmount { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }
        public string ModifiedMachine { get; set; }

    }
    public abstract class TransactionModelExtended
    {
        public string ProductName { get; set; }
        public string UserName { get; set; }
    }
}
