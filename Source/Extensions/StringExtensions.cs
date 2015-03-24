using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtensions
    {
        public static Boolean HasValue(this String str)
        {
            return String.IsNullOrWhiteSpace(str) == false;
        }

        public static Boolean Like(this String str, String other)
        {
            return str.ToUpper().Contains(other.ToUpper());
        }

        
    }
}
