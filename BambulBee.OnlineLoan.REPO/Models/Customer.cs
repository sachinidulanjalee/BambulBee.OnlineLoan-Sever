using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    [Table("Customer")]
    public class Customer
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Column(Order = 1)]
        public int UserID { get; set; }

        [Column(Order = 2)]
        public string NICPassport { get; set; }

        [Column(Order = 3)]
        public int Title { get; set; }

        [Column(Order = 4)]
        public int Sex { get; set; }

        [Column(Order = 5)]
        public string Surname { get; set; }

        [Column(Order = 6)]
        public string FirstName { get; set; }

        [Column(Order = 7)]
        public string ShortName { get; set; }

        [Column(Order = 8)]
        public int Nationality { get; set; }

        [Column(Order = 9)]
        public string Address01 { get; set; }

        [Column(Order = 10)]
        public string Address02 { get; set; }

        [Column(Order = 11)]
        public string Address03 { get; set; }

        [Column(Order = 12)]
        public string City { get; set; }

        [Column(Order = 13)]
        public string Province { get; set; }

        [Column(Order = 14)]
        public string PostalCode { get; set; }

        [Column(Order = 15)]
        public string Country { get; set; }

        [Column(Order = 16)]
        public string Telephone { get; set; }

        [Column(Order = 17)]
        public string Mobile { get; set; }

        [Column(Order = 18)]
        public string Email { get; set; }

        [Column(Order = 19)]
        public int Status { get; set; }

        [Column(Order = 20)]
        public DateTime? InactiveDate { get; set; }

        [Column(Order = 21)]
        public DateTime CreatedDateTime { get; set; }

        [Column(Order = 22)]
        public string CreatedBy { get; set; }

        [Column(Order = 23)]
        public string CreatedMachine { get; set; }

        [Column(Order = 24)]
        public DateTime? ModifiedDateTime { get; set; }

        [Column(Order = 25)]
        public string ModifiedBy { get; set; }

        [Column(Order = 26)]
        public string ModifiedMachine { get; set; }

    }

}
