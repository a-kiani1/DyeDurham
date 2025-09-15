using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeDurham.NameSorter
{
    public record Name(string LastName, string GivenName1, string GivenName2 = "", string GivenName3 = "")
    {
        public string GivenNamesCombined => $"{GivenName1} {GivenName2} {GivenName3}";

        public string FullName 
        { 
            get 
            {
                string fullName = GivenName1 + " ";

                if (!string.IsNullOrEmpty(GivenName2))
                    fullName += GivenName2 + " ";

                if (!string.IsNullOrEmpty(GivenName3))
                    fullName += GivenName3 + " ";

                fullName += LastName;

                return fullName;
            } 
        }
    }
}
