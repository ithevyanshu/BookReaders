using System;
using System.ComponentModel.DataAnnotations;

namespace Shared
{
    public class Login
    {
        [Required]
        [MinLength(5, ErrorMessage = "Min 5 character required")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}

