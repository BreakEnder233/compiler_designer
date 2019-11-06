using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.Process
{
    public class Processor
    {
        public static List<Word> WordAnalyse(string input)
        {
            var outputs = new List<Word>();
            var ruleManager = new RuleManager();
            while (!string.IsNullOrWhiteSpace(input))
            {
                var output = ruleManager.TryParse(input);
                if(output.type != SymbolType.ERROR)
                {
                    outputs.Add(output);
                    if(input.Length <= output.value.Length)
                    {
                        input = string.Empty;
                    }
                    else
                    {
                        input = input.Substring(output.value.Length);
                    }  
                }
                else
                {
                    throw new Exception("Not parsed");
                }
            }
            return outputs;
        }
        
    }
}
