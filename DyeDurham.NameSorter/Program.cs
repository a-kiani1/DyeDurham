namespace DyeDurham.NameSorter
{
    internal class Program
    {
        const string OUTPUT_FILE_NAME = "sorted-names-list.txt";
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify input file.");
                return;
            }

            var inputFileName = args[0];

            try
            {
                using var streamIn = File.OpenRead(inputFileName);

                using var streamOut = File.OpenWrite(OUTPUT_FILE_NAME);

                var ns = new NameSorter();
                ns.SortNames(streamIn, streamOut);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
