using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Helper
{
    class CSVTools
    {

        public static List<List<string>> Process(string path)
        {
            using (var reader = new StreamReader(@path))
            {
                List<List<string>> list = new List<List<string>>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var processedLine = line.Split(',').ToList();
                    list.Add(processedLine);
                }
                return list;
            }
        }
    }
}
