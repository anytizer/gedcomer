using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class filer
    {
        public string filename = "";
        public string contents = "";

        public filer(string filename = "")
        {
            this.filename = filename;

            if(System.IO.File.Exists(this.filename))
            {
                this.read();
            }
        }

        public void read()
        {
            this.contents = System.IO.File.ReadAllText(this.filename);
        }

        public  void write(string contents="")
        {
            System.IO.File.WriteAllText(this.filename, contents);
        }
    }
}
