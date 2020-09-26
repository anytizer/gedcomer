using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class note
    {
        public List<string> lines = new List<string>();

        public note(string line="")
        {
            this.lines.Add(line);
        }

        public override string ToString()
        {
            // split \r\n
            // [0] NOTE
            // [1+] CONT note...
            string gedcom = @"
0 NOTE
";
            foreach(string line in this.lines)
            {
                gedcom += string.Format(@"
1 CONT {0}
", line.ToString());
            }
            
            return gedcom;
        }
    }
}
