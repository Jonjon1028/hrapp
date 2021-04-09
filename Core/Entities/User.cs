using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hrapp.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Mobile Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage="Invalid mobile number")]
        public string MobilePhone { get; set; }
        
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage="Invalid email")]
        public string Email { get; set; }
    }
}