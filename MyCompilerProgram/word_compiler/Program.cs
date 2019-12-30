using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using word_compiler.Services.Input;
using word_compiler.Services.Process;
using Newtonsoft.Json;
using word_compiler.Services.WordContainer;

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
            string midString = string.Empty;
            int index = 0;
            foreach(var v in output)
            {
                midString += v.ToString() + '\n';
                Console.WriteLine($"{index++} : {v.ToString()}");
            }
            FileManager.WriteFile("midString.txt", midString);

            WordContainer.InjectData(output);

            //Console.WriteLine();
            //Console.Write(WordContainer.GetString());

            var ll1 = new LL1Processor();
            ll1.StartProcess();
            ll1.StartGenerate();
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
