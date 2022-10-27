using System.ComponentModel.DataAnnotations;

namespace AlpacaFinanceApp.Web.Models.Operation
{
    public class OperationModel
    {
        public int OperationId { get; set; }

        public int UserId { get; set; }

        public string Currency { get; set; }

        public decimal Amount { get; set; }

        public string RateType { get; set; }

        public decimal InterestRate { get; set; }

        public DateTime OperationDate { get; set; }
    }
}
