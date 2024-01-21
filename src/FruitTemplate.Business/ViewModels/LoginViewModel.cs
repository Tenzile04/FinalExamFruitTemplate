﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.ViewModels
{
    public class LoginViewModel
    {
        [StringLength(maximumLength: 50)]
        public string UserName {  get; set; }
        [StringLength(maximumLength: 50),MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
