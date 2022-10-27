using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpacaFinanceApp.Entities
{
    public class Operation
    {
        public int OperationId { get; set; }

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

        public virtual User User { get; set; }
    }
}
