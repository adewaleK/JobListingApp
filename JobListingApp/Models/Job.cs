using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class Job : BaseEntity
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string JobTitle { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string CompanyName { get; set; }
        public int MyProperty { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Must be between 3 and 15")]
        public string Location { get; set; }
        [Required]
        public int MinimumSalary { get; set; }
        [Required]
        public int MaximumSalary { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public List<UserJob> UserJobs { get; set; }

        public Job()
        {
            UserJobs = new List<UserJob>();
        }

    }
}
