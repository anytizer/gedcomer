using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    public class family
    {
        public string id;
        public List<individual> members = new List<individual>();

        public family()
        {
            this.id = string.Format("F{0}", universe.id());
        }
    }
    /*
  // https://stackoverflow.com/questions/857979/please-critique-my-class
  public struct FAM
  {
      public string FamID;
      public string Type; // par chil husb famc fams
      public string IndiID;
  }

  // https://stackoverflow.com/questions/836146/gedcom-reader-for-c-sharp
  struct INDI
  {
      public string ID;
      public string Name;
      public string Sex;
      public string BirthDay;
      public bool Dead;
  }*/
}
