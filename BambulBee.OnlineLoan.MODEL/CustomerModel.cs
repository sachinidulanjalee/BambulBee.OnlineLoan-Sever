using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BumbleBee.OnlineLoan.MODEL
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string email { get; set; }

        public string Mobile { get; set; }


        public int? Gender { get; set; }

        public string NICNo { get; set; }

        public DateTime DateOfJoining { get; set; }
        public string Password { get; set; }

        public int? Status { get; set; }

        public DateTime? CreatedDateTime { get; set; }


        public string CreatedUser { get; set; }


        public string CreatedMachine { get; set; }

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedUser { get; set; }

        public string ModifiedMachine { get; set; }
    }
}