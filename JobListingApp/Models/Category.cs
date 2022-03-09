using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
