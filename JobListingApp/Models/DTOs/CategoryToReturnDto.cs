using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models.DTOs
{
    public class CategoryToReturnDto
    {
        public string Id { get; set; }

        public string CategoryName { get; set; }
    }
}
