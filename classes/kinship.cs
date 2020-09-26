using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classes
{
    /**
     * Closest kinship only where 2 people are related directly and immediately, 
     * without third intermediary relationship
     */
    public enum kinship
    {
        SELF = 0,
        FATHER = 1,
        MOTHER = 2,
        SPOUSE = 3,
        CHILD = 4
    }
}
