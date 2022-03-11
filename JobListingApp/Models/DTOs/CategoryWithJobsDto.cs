using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models.DTOs
{
    public class CategoryWithJobsDto
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }

        public List<JobsInCategory> CategoryJobs { get; set; }
    }

    public class JobsInCategory{
        public string JobTitle { get; set; }
  
        public string CompanyName { get; set; }

        public string Location { get; set; }
        public int MinimumSalary { get; set; }
        public int MaximumSalary { get; set; }

    }
}
