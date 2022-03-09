using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class Job : BaseEntity
    {
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public int MyProperty { get; set; }
        public string Location { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }
        public string Duration { get; set; }
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
