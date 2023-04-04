using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BumbleBee.OnlineLoan.MODEL
{
    public class CustomerModel : CustomerModelExteded
    {
        public int CustomerID { get; set; }

        public int UserID { get; set; }

        public string NICPassport { get; set; }

        public int Title { get; set; }

        public int Sex { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string ShortName { get; set; }

        public int Nationality { get; set; }

        public string Address01 { get; set; }

        public string Address02 { get; set; }

        public string Address03 { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Telephone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public int Status { get; set; }

        public DateTime? InactiveDate { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedMachine { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedMachine { get; set; }
    }

    public class CustomerModelExteded
    {
        public bool IsPrimaryKeyExist { get; set; }
    }
}