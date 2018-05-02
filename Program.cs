using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseLog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ParseLog log...");
            Console.WriteLine("Plz Enter Input File Name example: abc.log");
            var inputFileName = Console.ReadLine();
            Console.WriteLine("Plz Enter Filter");
            var filter = Console.ReadLine();
            Console.WriteLine("Plz Enter Output FileName");
            var outputFileName = Console.ReadLine();

            var filePath = AppDomain.CurrentDomain.BaseDirectory + inputFileName;
            using (FileStream fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(filter))
                    {
                        using (StreamWriter sw = new StreamWriter($"{outputFileName}"))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }

            Console.WriteLine("ParseLog Done...");

        }
    }
}
