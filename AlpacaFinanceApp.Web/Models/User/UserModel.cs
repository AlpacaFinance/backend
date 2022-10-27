using System.ComponentModel.DataAnnotations;

namespace AlpacaFinanceApp.Web.Models.User
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DocumentType { get; set; }

        public string DocumentNumber { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
