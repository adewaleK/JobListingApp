using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
