using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Core.Models
{
    public class Setting:BaseEntity
    {
        [StringLength(maximumLength: 100)]
        public string? Key {  get; set; }
        [StringLength(maximumLength: 100),MinLength(5)]
        public string Value { get; set; }
    }
}
