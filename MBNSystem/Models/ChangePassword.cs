using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MBNSystem.Models
{
    public class ChangePassword
    {
        [Required]
        [DataType(DataType.Password)]
        public string OldPw { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPw { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPw { get; set; }
    }
}