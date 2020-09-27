using classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exe
{
    class tester
    {
        public string test()
        {
            return this.test_family();
        }

        public string test_family()
        {
            individual self = new individual("Self You");
            individual grandfather = new individual("Grand Father");
            individual grandmother = new individual("Grand Mother");
            individual gotra = new individual("Gotra");
            individual father = new individual("Father");
            individual mother = new individual("Mother");
            individual spouse = new individual("Spouse");
            individual child1 = new individual("Son #1");
            individual child2 = new individual("Daughter");
            individual child3 = new individual("Unmarried");
            individual daughterinlaw = new individual("Daugher In-Law");
            individual grandson = new individual("Grand Son");

            self.birth("1980");
            father.birth("1955");
            mother.birth("1960");
            spouse.birth("1984");
            child1.birth("1987");
            child2.birth("1990");

            grandfather.marry(grandmother);
            grandfather.death("2004");
            grandmother.death("2006");

            // generation #2
            daughterinlaw.birth("1995");
            child1.marry(daughterinlaw);
            
            // generation #3
            grandson.birth("1999");

            self.male();
            child1.male();
            child2.female();

            self.alias("Alias 2");

            mother.marry(father);
            father.note("Seniorly respected");
            father.note("Social worker");
            father.register_event("2010", "Migrate", "City 1");
            father.register_event("2011", "Teaching", "City 2");

            mother.birth("1960");
            mother.death("2001");

            father.relate(kinship.FATHER, grandfather);
            father.relate(kinship.CHILD, self);
            grandfather.relate(kinship.FATHER, gotra);
            child1.relate(kinship.CHILD, grandson);

            // just: values change
            self.relate(kinship.SELF, self);
            
            // assignment of a new individual defined separately
            //self.relate(kinship.FATHER, father);
            self.relate(kinship.MOTHER, mother);
            self.relate(kinship.SPOUSE, spouse);
            self.relate(kinship.CHILD, child1);
            self.relate(kinship.CHILD, child2);
            self.relate(kinship.CHILD, child3);

            gedcomer gc = new gedcomer();
            gc.root(self);
            // self // case 1
            // grandfather // case 2
            // grandson // case 3
            // mother // case 4

            string gedcom = gc.ToString();
            return gedcom;
        }

        public string test_self()
        {
            individual self = new individual("Self");
           
            gedcomer gc = new gedcomer();
            gc.root(self);

            string gedcom = gc.ToString();
            return gedcom;
        }

        // @todo Spousal relationship should be drawn
        // Create FAM record
        public string test_spouse()
        {
            individual self = new individual("Self");
            individual spouse = new individual("Spouse");
            self.relate(kinship.SPOUSE, spouse);

            gedcomer gc = new gedcomer();
            gc.root(self);

            string gedcom = gc.ToString();
            return gedcom;
        }

        // Test spouse and child
        public string test_child()
        {
            individual self = new individual("Self");
            individual spouse = new individual("Spouse");
            individual child = new individual("Spouse");
            self.relate(kinship.SPOUSE, spouse);
            self.relate(kinship.CHILD, child);

            gedcomer gc = new gedcomer();
            gc.root(self);

            string gedcom = gc.ToString();
            return gedcom;
        }

        // Test father
        public string test_father()
        {
            individual self = new individual("Self");
            individual father = new individual("Father");
            self.relate(kinship.FATHER, father);

            gedcomer gc = new gedcomer();
            gc.root(self);

            string gedcom = gc.ToString();
            return gedcom;
        }
    }
}
