using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class @event
    {
        public string name = "";
        public string date = "";
        public string place = "";

        public override string ToString()
        {
            string gedcom = string.Format(@"
1 EVEN
2 TYPE {0}
2 DATE {1}
2 PLAC {2}
",
    this.name,
    this.date,
    this.place
);
            return gedcom;
        }
    }
}
