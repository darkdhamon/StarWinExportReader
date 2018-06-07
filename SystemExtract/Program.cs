using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var lines = File.ReadAllLines("read.this.txt");
                var systems = new List<string>();
                foreach (var line in lines)
                {
                    if (line.StartsWith("system    : "))
                    {
                        var id = int.Parse(line.Substring(12));
                        systems.Add(id.ToString());
                        Console.WriteLine(id);
                    }
                }
                File.WriteAllLines("systems.txt",systems);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();

        }


    }
}
