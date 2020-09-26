using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace classes
{
    public class gedcomer
    {
        private header header = new header();
        private List<family> clans;

        public gedcomer()
        {
            this.clans = new List<family>();
        }

        /**
         * Read gedcom from file database
         */
        public gedcomer parse(string filename)
        {
            filer f = new filer(filename);
            gedcomer gc = new gedcomer();
            // header
            // people
            // names
            // events
            // photos
            // relationships
            // footer
            // f.contents;
            return gc;
        }

        private string write()
        {
            string gedcom = string.Format(@"
{0}
{1}
{2}
0 TRLR
",
    this.header.ToString(),
    this._people(),
    this._relationships()
);
            // Remove empty lines
            gedcom = Regex.Replace(gedcom, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
            return gedcom;
        }

        private string _people()
        {
            string gedcom = "";
            foreach (family f in this.clans)
            {
                foreach (individual member in f.members)
                {
                    gedcom += member.ToString();
                }

            }

            return gedcom;
        }

        public string _relationships()
        {
            string gedcom = "";
            string families = "";
            foreach (family f in this.clans)
            {
                gedcom += string.Format(@"
0 @{0}@ FAM
", f.id);

                individual self = f.members[0];
                families += self._father_id();
                families += self._mother_id();
            }

            gedcom += families;
            return gedcom;
        }

        public void root(individual whoever)
        {
            family clan = new family();
            whoever.belongsto(clan);
            clan.members.Add(whoever);

            this.clans.Add(clan);
        }

        // https://www.gedcom.org/gedcom.html
        // https://www.gedcom.org/specs/GEDCOM555.zip
        // https://en.wikipedia.org/wiki/GEDCOM
        // https://www.familysearch.org/developers/docs/guides/gedcom-x
        // https://www.tamurajones.net/GEDCOM555JustARevision.xhtml
        // http://phpgedview.sourceforge.net/ged551-5.pdf
        // https://homepages.rootsweb.com/~pmcbride/gedcom/55gctoc.htm
        public override string ToString()
        {
            return this.write();
        }
    }
}
