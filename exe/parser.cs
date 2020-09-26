using classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exe
{
    public class parser
    {
        public parser()
        {
            filer f = new filer(@"gedcom.ged");

            gedcomer gc = new gedcomer();
            gc.parse(f.contents);
        }
    }
}
