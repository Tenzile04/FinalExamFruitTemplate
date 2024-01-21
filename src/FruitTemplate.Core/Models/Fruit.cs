using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Core.Models
{
    public class Fruit:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:50,MinimumLength = 3)]
        public string Name {  get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Description { get; set; }
        
        [StringLength(maximumLength: 100)]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
