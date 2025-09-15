using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyeDurham.NameSorter
{
    public abstract class BaseNameSorter : INameSorter
    {
        const int MIN_GIVEN_NAMES = 1;
        const int MAX_GIVEN_NAMES = 3;
        protected abstract IComparer<Name> GetComparer();

        virtual public void SortNames(Stream input, Stream output)
        {
            List<Name> nameList = new();

            using (StreamReader sr = new StreamReader(input))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        continue;

                    line = line.Trim();
                    var names = line.Split(' ');
                    var count = names.Length;
                    if (count > MAX_GIVEN_NAMES + 1 || count < MIN_GIVEN_NAMES + 1)
                    {
                        Console.WriteLine($"Error! Number of given names must be between {MIN_GIVEN_NAMES} and {MAX_GIVEN_NAMES}. There must be one last name.");
                        // skip this line
                        continue;
                    }

                    var lastName = names[count - 1];
                    var given1 = names[0].Trim();
                    var given2 = count > 2 ? names[1].Trim() : string.Empty;
                    var given3 = count > 3 ? names[2].Trim() : string.Empty;

                    var name = new Name(lastName, given1, given2, given3);

                    nameList.Add(name);
                }
            }

            SortNames(nameList, GetComparer());

            StoreResults(nameList, output);

            PrintResults(nameList);
        }     

        virtual protected void PrintResults(List<Name> nameList)
        {
            foreach (var name in nameList)
            {
                Console.WriteLine(name.FullName);
            }
        }
        virtual protected void StoreResults(List<Name> nameList, Stream output)
        {
            using StreamWriter sw = new StreamWriter(output);
            foreach (var name in nameList)
            {
                sw.WriteLine(name.FullName);
            }

            sw.Flush();
        }
        virtual protected void SortNames(List<Name> nameList, IComparer<Name> comparer)
        {
            nameList.Sort(comparer);
        }
    }
}
