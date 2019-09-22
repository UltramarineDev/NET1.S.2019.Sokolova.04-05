using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoubleConverterWeb.Models
{
    public class DoubleTransformModel
    {
        public double InputValue { get; set; }
        public bool IsGetIEEE { get; set; } = true;
    }
}