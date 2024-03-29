﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitTemplate.Business.Exceptions
{
    public class InvalidContentTypeException:Exception
    {
        public string PropertyName { get; set; }
        public InvalidContentTypeException()
        {

        }
        public InvalidContentTypeException(string message) : base(message)
        {

        }
        public InvalidContentTypeException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
