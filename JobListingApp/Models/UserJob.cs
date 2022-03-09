using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models
{
    public class UserJob
    {
        public string UserId { get; set; }
        public string JobId { get; set; }
        public Job Job { get; set; }
        public User User { get; set; }
    }
}
