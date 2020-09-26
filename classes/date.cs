using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class date
    {
        datetype type;
        string place = "";
        string date_value = "";
        string source = "";
        string data = "";
        string text = "";

        public date(datetype type, string date_value = "", string place="", string text="")
        {
            // @todo Manage source and text data
            this.type = type;
            this.date_value = date_value;
            this.place = "";
            this.source = "";            
        }

        public override string ToString()
        {
            string type = symbols.datetype(this.type);

            string gedcom = string.Format(@"
1 {0}
2 DATE {1}
2 PLAC {2}
2 SOUR {3}
2 DATA {4}
2 TEXT {5}
", type, this.date_value, this.place, this.source, this.data, this.text);

            return gedcom;
        }
    }
}
