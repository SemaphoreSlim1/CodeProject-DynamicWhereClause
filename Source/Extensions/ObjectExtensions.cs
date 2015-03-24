using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ObjectExtensions
    {
        public static String ToStringInstance(this Object obj)
        {
            if(obj == null)
            { return String.Empty;}

            return obj.ToString();
        }
    }
}
