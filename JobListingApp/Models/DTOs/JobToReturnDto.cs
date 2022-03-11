using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models.DTOs
{
    public class JobToReturnDto
    {
        public string Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public int MyProperty { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int MinimumSalary { get; set; }
        [Required]
        public int MaximumSalary { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
