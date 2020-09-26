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
            individual self = new individual("Self You");
            individual grandfather = new individual("Grand Father");
            individual gotra = new individual("Gotra");
            individual father = new individual("Father");
            individual mother = new individual("Mother");
            individual spouse = new individual("Spouse");
            individual child1 = new individual("Son #1");
            individual child2 = new individual("Daughter");
            individual child3 = new individual("Unmarried");
            individual daughterinlaw = new individual("Daugher In-Law");
            individual grandson = new individual("Grand Son");

            self.birth("1980", "", "");
            father.birth("1955", "", "");
            mother.birth("1960", "", "");
            spouse.birth("1984", "", "");
            child1.birth("1987", "", "");
            child2.birth("1990", "", "");

            grandfather.death("2004", "", "");

            // generation #2
            daughterinlaw.birth("1995", "", "");
            child1.marry(daughterinlaw);
            
            // generation #3
            grandson.birth("1999", "", "");

            self.male();
            child1.male();
            child2.female();

            self.alias("Alias 2");

            mother.marry(father);
            father.note("Seniorly respected");
            father.note("Social worker");
            father.register_event("2010", "Migrate", "City 1");
            father.register_event("2011", "Teaching", "City 2");

            mother.birth("1960", "Place", "");
            mother.death("2001", "Home", "");

            // just: values change
            self.relate(kinship.SELF, self);
            
            // assignment of a new individual defined separately
            self.relate(kinship.FATHER, father);
            self.relate(kinship.MOTHER, mother);
            self.relate(kinship.SPOUSE, spouse);
            self.relate(kinship.CHILD, child1);
            self.relate(kinship.CHILD, child2);
            self.relate(kinship.CHILD, child3);

            father.relate(kinship.FATHER, grandfather);
            grandfather.relate(kinship.FATHER, gotra);            
            grandson.relate(kinship.CHILD, child1);

            gedcomer gc = new gedcomer();
            gc.root(self);
            // gc.root(self); // case 1
            // gc.root(grandfather); // case 2
            // gc.root(grandson); // case 3
            // gc.root(mother); // case 4

            // gc.show(self);

            string gedcom = gc.ToString();
            return gedcom;
        }
    }
}
