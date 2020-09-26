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
        }

        public string read()
        {
            this.contents = ""; 
            if (System.IO.File.Exists(this.filename))
            {
                this.contents = System.IO.File.ReadAllText(this.filename);
            }

            return this.contents;
        }

        public bool write(string contents = "")
        {
            bool success = false;
            System.IO.File.WriteAllText(this.filename, contents);
            
            return success;
        }
    }
}
