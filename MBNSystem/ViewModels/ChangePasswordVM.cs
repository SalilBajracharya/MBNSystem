using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MBNSystem.ViewModels
{
    [NotMapped]
    public class ChangePasswordVM
    {

        [Required(ErrorMessage = "Current password is required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password do not match")]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
    }
}