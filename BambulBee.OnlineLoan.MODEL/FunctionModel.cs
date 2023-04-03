using System;

namespace BumbleBee.OnlineLoan.MODEL
{
    public class FunctionModel
    {
        public int FunctionID { get; set; }

        public int SystemType { get; set; }

        public int SortOrder { get; set; }

        public string FunctionName { get; set; }

        public string FunctionURL { get; set; }

        public string Icon { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedMachine { get; set; }
    }
}