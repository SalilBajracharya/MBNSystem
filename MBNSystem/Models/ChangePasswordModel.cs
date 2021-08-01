using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBNSystem.Models
{
    public class ChangePasswordModel
    {
        //[Required(ErrorMessage = "Please enter the old password.")]
        //[DataType(DataType.Password)]
        //[Display(Name = "Current password")]
        //public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter the new password.", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage =("Please enter the confirmation password."), AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("New Password", ErrorMessage = "The new password and confirmation password donot match.")]

        public string ConfirmPassword { get; set; }
    }
}