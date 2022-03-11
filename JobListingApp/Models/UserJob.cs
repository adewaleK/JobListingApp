using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class UserJob
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string JobId { get; set; }
        public Job Job { get; set; }
        public User User { get; set; }
    }
}
