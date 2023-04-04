using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BambulBee.OnlineLoan.REPOSITORY
{
    [Table("Function")]
    public class Function
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FunctionID { get; set; }

        [Column(Order = 1)]
        public int SystemType { get; set; }

        [Column(Order = 2)]
        public int SortOrder { get; set; }

        [Column(Order = 3)]
        public string FunctionName { get; set; }

        [Column(Order = 4)]
        public string FunctionURL { get; set; }

        [Column(Order = 5)]
        public string Icon { get; set; }

        [Column(Order = 6)]
        public int Status { get; set; }

        [Column(Order = 7)]
        public DateTime CreatedDateTime { get; set; }

        [Column(Order = 8)]
        public string CreatedUser { get; set; }

        [Column(Order = 9)]
        public string CreatedMachine { get; set; }

        [Column(Order = 10)]
        public DateTime? ModifiedDateTime { get; set; }

        [Column(Order = 11)]
        public string ModifiedUser { get; set; }

        [Column(Order = 12)]
        public string ModifiedMachine { get; set; }
    }
}