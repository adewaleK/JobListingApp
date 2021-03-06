using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string CategoryName { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
