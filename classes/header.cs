using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    /**
     * GEDCOM file output header
     */
    public class header
    {
        private string lines = @"
0 HEAD
1 SOUR GEDCOMER
2 VERS 0.0.1
1 GEDC
2 VERS 5.5.5
2 FORM LINEAGE-LINKED
1 CHAR UTF-8
";
        public override string ToString()
        {
            return this.lines;
        }
    }
}
