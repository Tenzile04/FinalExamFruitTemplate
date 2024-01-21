using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Core.Models
{
    public class AppUser:IdentityUser
    {
        [StringLength(maximumLength: 100)]
        public string FullName { get; set; }
    }
}
