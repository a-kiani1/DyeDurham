namespace DyeDurham.NameSorter.Test
{
    using DyeDurham.NameSorter;
    using System.IO;
    using System.Text;

    public class NameSorterTest
    {
        [Fact]
        public void SortNamesTest()
        {
            // setup
            string inputText = "Vaughn Lewis\r\nJulius Archer\r\nAlex Archer";
            const string expected = "Alex Archer\r\nJulius Archer\r\nVaughn Lewis\r\n";
            byte[] byteArray = Encoding.UTF8.GetBytes(inputText);
            
            using Stream streamIn = new MemoryStream(byteArray);
            using var streamOut = new MemoryStream();

            var sw  = new StringWriter();
            Console.SetOut(sw);

            // action
            var ns = new NameSorter();
            ns.SortNames(streamIn, streamOut);

            //Verify
            string result = Encoding.UTF8.GetString(streamOut.ToArray());

            Assert.Equal(expected, result);
            Assert.Equal(expected, sw.ToString());

            // restoring Console out
            var stdOut = new StreamWriter(Console.OpenStandardOutput());
            stdOut.AutoFlush = true;
            Console.SetOut(stdOut);
        }
    }
}