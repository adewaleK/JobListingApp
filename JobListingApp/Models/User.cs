using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string FirstName { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        public List<UserJob> UserJobs { get; set; }

        public User()
        {
            UserJobs = new List<UserJob>();
        }
    }
}
