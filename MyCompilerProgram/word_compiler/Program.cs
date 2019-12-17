using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using word_compiler.Services.Input;
using word_compiler.Services.Process;
using Newtonsoft.Json;

namespace word_compiler
{
    class Anony
    {
        public string data { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            var output = Processor.WordAnalyse(FileManager.ReadFile("test.txt"));
            foreach(var v in output)
            {
                Console.WriteLine($"<{v.type.ToString()} . {v.value}>");
            }
            
            /*
            FileManager.WriteFile("ttttttt.json", JsonConvert.SerializeObject(new Anony{
            data = "aaaa\\\"aaaa"
            }));
            Anony obj = JsonConvert.DeserializeObject<Anony>(FileManager.ReadFile("ttttttt.json"));
            
            Console.WriteLine(obj.data);
            */
        }
    }
}
