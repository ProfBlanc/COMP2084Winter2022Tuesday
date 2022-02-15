using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COMP2084Winter2022Tuesday.Models
{
    public class Login
    {
        [Required]
        [MinLength(5, ErrorMessage = "Username needs to be at least 5 characters")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address!")]
        public string Username { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password too weak! Needs at least 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}