using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeDurham.NameSorter
{
    internal class NameComparer : IComparer<Name>
    {
        public int Compare(Name? x, Name? y)
        {
            var result = String.Compare(x?.LastName, y?.LastName, true);

            if (result != 0)
            {
                return result;
            }

            // if last names are equal then compare given names

            return String.Compare(x?.GivenNamesCombined, y?.GivenNamesCombined, true);
        }
    }
    public class NameSorter : BaseNameSorter , INameSorter
    {
        protected override IComparer<Name> GetComparer()
        {
            return new NameComparer();
        } 
    }
}
