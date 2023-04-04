using System;
using System.Collections.Generic;

namespace BumbleBee.OnlineLoan.MODEL
{
    public class UserModel : UserModelExteded
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserType { get; set; }

        public string Email { get; set; }

        public string MobileNo { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int MaximumAttemps { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedUser { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }
    }

    public class UserModelExteded
    {
        public List<string> FuncationIDs { get; set; }
    }
}
