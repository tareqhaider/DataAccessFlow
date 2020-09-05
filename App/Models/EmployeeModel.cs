using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Employee ID")]
        [Range(10000,999999,ErrorMessage = "Please enter valid Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "This Information is mandatory")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This Information is mandatory")]
        public string Lastname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This Information is mandatory")]
        public string Email { get; set; }

        [Display(Name = "Confirm Email Address")]
        [Compare("Email",ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A strong password is mandatory")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "A password of 10 or more digits is mandatory")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must match")]
        public string ConfirmPassword { get; set; }

    }
}