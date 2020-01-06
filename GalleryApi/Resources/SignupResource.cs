using System;
using System.ComponentModel.DataAnnotations;

namespace GalleryApi.Resources
{
    public class SignupResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
