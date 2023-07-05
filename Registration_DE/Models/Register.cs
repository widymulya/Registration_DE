using System.ComponentModel.DataAnnotations;

namespace Registration_DE.Models
{
    public class Register
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password and repeat password does not match")]
        public string RepeatPassword { get; set; }
        public int IsApproved { get; set; } // 0 not authorizes, 1 approved, 2 rejected
    }

    public class RegisterVM
    { 
        public List<Register>? ListRegister { get; set; }
    }
}
