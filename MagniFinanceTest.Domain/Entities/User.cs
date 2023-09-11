using MagniFinanceTest.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MagniFinanceTest.Domain.Entities
{
    // User is the user that is logged in the Application
    // As I am not using Auth, ClientUser will not be used properly
    public class User
    {
        public Guid UserId { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(256)]
        [Phone]
        public string ContactNumber { get; set; }
    }
}
