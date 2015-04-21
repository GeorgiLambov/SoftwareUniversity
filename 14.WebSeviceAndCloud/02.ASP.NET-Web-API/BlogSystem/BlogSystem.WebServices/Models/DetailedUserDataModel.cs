using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.WebServices.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DetailedUserDataModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }


    }
}