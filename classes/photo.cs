using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class photo
    {
        // url eg. facebook and other social media
        // local absolute path
        // relative path
        public string path;

        public override string ToString()
        {
            // split \r\n, [0] ???? [1+] CONT, 
            return this.path;
        }
    }
}
