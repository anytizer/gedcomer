using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    static class universe
    {
        /**
         * To provide a general purpose identifier
         */
        public static string id()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
            return guid;
        }
    }
}
