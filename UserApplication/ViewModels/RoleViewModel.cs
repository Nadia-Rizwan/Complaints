using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserApplication.ViewModels
{



    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime AddedTime { get; set; }
        public string Role { get; set; }
      
      
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ManageUserViewModel
    {
        public List<UserViewModel> Users { get; set; }
    }
    public class ForgotPasswordViewModels
    {
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
    }



    public class RoleViewModel
    {
        [Key]
        public string id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "User Role")]
        public string UserRole { get; set; }

        [Display(Name = "CNIC")]
        [NumberHyphen(@"^[0-9]+(?:-[0-9]+)?([0-9]+(?:-[0-9]+)?)*$", ErrorMessage = "Not a valid NIC Format")]
        [CNICRegex(@"^\(?([0-9]{5})\)?[-. ]?([0-9]{7})[-. ]?([0-9]{1})$", ErrorMessage = "Not a valid NIC Number")]
        public string CNIC { get; set; }

        [Display(Name = "Phone Number")]
        [NumberHyphen(@"^[0-9]+(?:-[0-9]+)?([0-9]+(?:-[0-9]+)?)*$", ErrorMessage = "Not a valid Phone Number Format")]
        [PhoneRegex(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }


    }
    public class EditUserViewModel
    {  
        [Key]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [ScaffoldColumn(false)]
        [Display(Name = "Roles")]
        public string RoleId { get; set; }

        [Display(Name = "CNIC")]
        [NumberHyphen(@"^[0-9]+(?:-[0-9]+)?([0-9]+(?:-[0-9]+)?)*$", ErrorMessage = "Not a valid NIC Format")]
        [CNICRegex(@"^\(?([0-9]{5})\)?[-. ]?([0-9]{7})[-. ]?([0-9]{1})$", ErrorMessage = "Not a valid NIC Number")]
        public string CNIC { get; set; }

        [Display(Name = "Phone Number")]
        [NumberHyphen(@"^[0-9]+(?:-[0-9]+)?([0-9]+(?:-[0-9]+)?)*$", ErrorMessage = "Not a valid Phone Number Format")]
        [PhoneRegex(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }
    }
    public class DetailUserViewModel
    {
        [Key]
        public string UserId { get; set; }
      
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

    
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "User Name")]
        public string UserName { get; set; }

      
        [Display(Name = "Email")]
        public string Email { get; set; }
       
        [Display(Name = "Roles")]
        public string RoleName { get; set; }

        [Display(Name = "CNIC")]
       
        public string CNIC { get; set; }

        [Display(Name = "Phone Number")]
       
        public string PhoneNumber { get; set; }
    }

    public class LoginUserViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }


    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class DepartmentForEmail
    {
        [Required]
        [Display(Name = "Departments")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }


    }



    public class ResetPasswordViewModel
    {
        public string Id { get; set; }
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.CompareAttribute("NewPassword", ErrorMessage = "Password Doesn't Match.")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
    public class NumberHyphen : RegularExpressionAttribute
    {
        public NumberHyphen(string pattern) : base(pattern) { }
    }

    public class CNICRegex : RegularExpressionAttribute
    {
        public CNICRegex(string pattern) : base(pattern) { }
    }

    public class PhoneRegex : RegularExpressionAttribute
    {
        public PhoneRegex(string pattern) : base(pattern) { }
    }
}