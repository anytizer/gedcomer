using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    class symbols
    {
        internal static string role(sex sex)
        {
            string role = "";

            switch (sex)
            {
                //case classes.role.CHIL:
                //    role = "CHIL";
                //    break;
                case classes.sex.MALE:
                    role = "HUSB";
                    break;
                case sex.FEMALE:
                    role = "WIFE";
                    break;
                default:
                    // should NOT arrive here
                    role = "UNKN";
                    break;
            }

            return role;
        }

        internal static string datetype(datetype datetype)
        {
            // Fully convert date type into type string
            string type = "";
            switch (datetype)
            {
                case classes.datetype.BIRT:
                    type = "BIRT";
                    break;
                case classes.datetype.DEAT:
                    type = "DEAT";
                    break;
                case classes.datetype.MARR:
                    // apply only to family creation
                    type = "MARR";
                    break;
                default:
                    type = "UNKW";
                    break;
            }

            return type;
        }

        public static string sex(sex sex)
        {
            string gedcom = "";
            switch (sex)
            {
                case sex.FEMALE:
                    gedcom = "F";
                    break;
                case sex.MALE:
                    gedcom = "M";
                    break;
                default:
                    gedcom = "O";
                    break;
            }

            return gedcom;
        }
    }
}
