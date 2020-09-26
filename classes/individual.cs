using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace classes
{
    public class individual
    {
        private string id = "";

        private string name = "";
        private string name2 = "";

        private sex sex;

        private date BIRTH;
        private date DEATH;

        private List<@event> events;
        private List<note> notes;
        private List<photo> photos;

        private individual father;
        private individual mother;
        private List<individual> spouses;
        private List<individual> children;

        // recursively access the parent family details
        // @todo implement/know the family id only
        private family belongsToFamily;
        private role role;

        public individual(string name = "")
        {
            // look up based on id
            this.id = string.Format("I{0}", universe.id());

            this.name = name;
            this.name2 = ""; // alias

            this.sex = sex.UNKNOWN;

            this.BIRTH = new date(datetype.DEAT, "", "");
            this.DEATH = new date(datetype.BIRT, "", "");

            this.events = new List<@event>();
            this.notes = new List<note>();
            this.photos = new List<photo>();

            // relatives
            this.father = null;
            this.mother = null;
            this.spouses = new List<individual>();
            this.children = new List<individual>();
        }

        public void birth(string _date = "", string place = "", string text = "")
        {
            this.BIRTH = new date(datetype.BIRT, _date, place, text);
        }

        public void death(string _date = "", string place = "", string text = "")
        {
            this.DEATH = new date(datetype.DEAT, _date, place, text);
        }

        // @todo put alias name
        public void alias(string second_name = "")
        {
            this.name2 = second_name;
        }

        internal string _father_id()
        {
            string famc_father = "";
            if (this.father != null)
            {
                famc_father += string.Format(@"
1 FAMC @{0}@
", this.father._id());
            }

            return famc_father;
        }

        internal string _mother_id()
        {
            string famc_mother = "";
            if (this.mother != null)
            {
                famc_mother += string.Format(@"
1 FAMC @{0}@
", this.mother._id());
            }

            return famc_mother;
        }

        internal void belongsto(family family)
        {
            this.belongsToFamily = family;
        }

        public void male()
        {
            this.sex = sex.MALE;
            this.role = role.HUSB;
        }

        public void female()
        {
            this.sex = sex.FEMALE;
            this.role = role.WIFE;
        }

        /**
         * An alternative way to express
         */
        public void marry(individual opposite)
        {
            // @todo Recursion prevention: Cannot marry oneself.
            if (opposite != null)
            {
                if (this.id != opposite.id)
                {
                    if (this.id != opposite.id)
                    {
                        this.relate(kinship.SPOUSE, opposite);
                    }
                }
            }
        }

        public void relate(kinship relationship, individual person)
        {
            if (person.belongsToFamily == null)
            {
                person.belongsToFamily = new family();
            }

            if (person != null)
            {
                if (person.sex == sex.MALE)
                {
                    person.role = role.HUSB;
                }
                else
                {
                    person.role = role.WIFE;
                }

                // sex correction by known relationships
                switch (relationship)
                {
                    case kinship.SELF:
                        this.id = person._id();
                        this.name = person._name();
                        this.sex = person._sex();
                        // this.role = role.SELF;

                        // @todo Copy these records too
                        // @todo Multiple calls should not be available
                        // @todo Must be called and once only
                        break;
                    case kinship.FATHER:
                        person.male();
                        // @todo add spouse
                        person.role = role.HUSB;
                        this.father = person;

                        // @if mother available, marry
                        this.father.marry(this.mother);
                        break;
                    case kinship.MOTHER:
                        person.role = role.WIFE;
                        person.female();
                        // @todo add spouse
                        this.mother = person;

                        // @if father available, marry
                        this.mother.marry(this.father);
                        break;
                    case kinship.SPOUSE:
                        // @todo sex flip
                        // or often allow same sex spousing if there is an adoptation
                        // what if they do not have a child?
                        if (this.belongsToFamily == null)
                        {
                            this.belongsToFamily = new family();
                        }

                        if (person.sex == sex.FEMALE)
                        {
                            person.sex = sex.MALE;
                            person.role = role.HUSB;
                        }
                        else
                        {
                            person.sex = sex.FEMALE;
                            person.role = role.WIFE;
                        }
                        this.spouses.Add(person);
                        break;
                    case kinship.CHILD:
                        person.role = role.CHIL;
                        this.children.Add(person);
                        break;
                }
            }
        }

        private string _id()
        {
            return this.id;
        }

        private string _name()
        {
            return this.name;
        }

        private sex _sex()
        {
            return this.sex;
        }

        public void register_event(string date = "", string name = "", string place = "")
        {
            this.events.Add(new @event()
            {
                date = date,
                name = name,
                place = place,
            });
        }

        public void note(string line)
        {
            this.notes.Add(new note(line));
        }

        public string _birth()
        {
            return this.BIRTH.ToString();
        }

        public string _death()
        {
            return this.DEATH.ToString();
        }

        private string _events()
        {
            string gedcom = "";
            foreach (@event e in this.events)
            {
                gedcom += e.ToString();
            }

            return gedcom;
        }

        private string _notes()
        {
            string gedcom = "";
            foreach (note note in this.notes)
            {
                gedcom += note.ToString();
            }

            return gedcom;
        }

        // @todo Implement photos
        private string _photos()
        {
            string gedcom = "";
            foreach (photo photo in this.photos)
            {
                gedcom += photo.ToString();
            }

            return gedcom;
        }

        private string child_or_sopuse_of()
        {
            string gedcom = string.Format(@"
1 FAMS @{0}@
", this.belongsToFamily.id);
            string family = "";

            if (this.father != null)
            {
                //gedcom += this.father.ToString();
                family += string.Format(@"
1 FAMC @{0}@
", father.belongsToFamily.id);
            }

            if (this.mother != null)
            {
                gedcom += this.mother.ToString();
                family += string.Format(@"
1 FAMC @{0}@
", mother.belongsToFamily.id);
            }

            if (this.spouses.Count >= 1)
            {
                foreach (individual spouse in spouses)
                {
                    gedcom += spouse.ToString();
                    family += string.Format(@"
1 FAMS @{0}@
", spouse.belongsToFamily.id);
                }
            }

            gedcom += family;

            return gedcom;
        }

        public string _families()
        {
            string gedcom = string.Format(@"
0 @{0}@ FAM
", this.belongsToFamily.id);

            if (this.father != null)
            {
                gedcom += this.father.ToString();
                gedcom += string.Format(@"
1 FAMC @{0}@
", father.id);
            }

            if (this.mother != null)
            {
                gedcom += string.Format(@"
1 FAMC @{0}@
", mother.id);
            }

            if (this.spouses.Count >= 1)
            {
                foreach (individual spouse in this.spouses)
                {
                    string role = symbols.role(spouse.role);
                    gedcom += string.Format(@"
1 {0} @{1}@
", role, spouse.id);
                }
            }

            return gedcom;
        }

        public override string ToString()
        {
            symbols symbols = new symbols();
            // @todo split futher
            string gedcom = string.Format(@"
0 @{0}@ INDI
1 NAME /{1}/
1 NAME /{2}/
1 SEX {3}
{4}
{5}
{6}
{7}
{8}
{9}
{10}
",
    this.id, this.name, this.name2,
    symbols.sex(this.sex), this._birth(), this._death(),
    this._events(), this._notes(), this._photos(),
    this.child_or_sopuse_of(), this._families());
            return gedcom;
        }
    }
}