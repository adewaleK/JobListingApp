using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobListingApp.Models.DTOs
{
    public class CategoryToAddDto
    {

        [Required]
        public string CategoryName { get; set; }
    }
}
