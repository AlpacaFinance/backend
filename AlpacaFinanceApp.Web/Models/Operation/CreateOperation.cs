using System.ComponentModel.DataAnnotations;

namespace AlpacaFinanceApp.Web.Models.Operation
{
    public class CreateOperation
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Currency { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string RateType { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [Required]
        public DateTime OperationDate { get; set; }
    }
}
