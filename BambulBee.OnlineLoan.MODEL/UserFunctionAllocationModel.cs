using System;

namespace BumbleBee.OnlineLoan.MODEL
{
    public class UserFunctionAllocationModel
    {
        public int UserID { get; set; }

        public int FunctionID { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }
    }
}