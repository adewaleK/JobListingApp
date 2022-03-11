using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models.DTOs
{
    public class JobToAddDto
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
    }
}
