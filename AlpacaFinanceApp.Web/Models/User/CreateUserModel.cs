using System.ComponentModel.DataAnnotations;

namespace AlpacaFinanceApp.Web.Models.User
{
    public class CreateUserModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string DocumentType { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string DocumentNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Country { get; set; }

        [Required]
        public DateTime RegisterDate { get; set; }
    }
}
