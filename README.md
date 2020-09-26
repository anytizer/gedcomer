# gedcomer
To write simple GEDCOM format files in C#.NET.

* Programatically create individuals.
* Apply personal details, dates and events.
* Attach media and notes.

The purpose is to create a .ged file format that a gedcom software understands.
Instead of opening a new gedcom project and entering the data in the software, you can programatically create the details.

## @todo
The output string needs to be GEDCOM complaint.

## Examples

### How to create individuals

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

### How to edit the details

	self.birth("1980", "", "");
	father.birth("1955", "", "");
	mother.birth("1960", "", "");
  
	self.male();
	child1.male();
	child2.female();

### How to relate direct kinship

	self.relate(kinship.FATHER, father);
	self.relate(kinship.MOTHER, mother);
	self.relate(kinship.SPOUSE, spouse);
	self.relate(kinship.CHILD, child1);
	self.relate(kinship.CHILD, child2);
	self.relate(kinship.CHILD, child3);
  
### How to relate other kinship

	father.relate(kinship.FATHER, grandfather);
	grandfather.relate(kinship.FATHER, gotra);            
	grandson.relate(kinship.CHILD, child1);

### How to obtain the gedcom format text
	gedcomer gc = new gedcomer();
	gc.root(self);

	string gedcom = gc.ToString();

# Inspirations
* Simple Family Tree 1.32 at [jdmcox.com](http://www.jdmcox.com).
* [GEDCOM.org specifications](https://www.gedcom.org/gedcom.html).

## But,,,
I ended up with unusual relationships in the output due to a programming flaw. Can you help me please? See [images](/unusual) pictures that need fixing.