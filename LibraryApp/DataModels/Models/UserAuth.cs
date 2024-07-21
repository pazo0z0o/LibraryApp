using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class UserAuth
    {
        [Required]
        [MaxLength(25)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long and contain at least one number, one lowercase letter, one uppercase letter, and one special character (!@#$%).")]
        public string Password { get; set; }

    }
}
