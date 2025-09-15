using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeDurham.NameSorter
{
    public interface INameSorter 
    {
        void SortNames(Stream input, Stream output);
    }
}
