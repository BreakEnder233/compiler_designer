using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

using word_compiler.Services.Input;

namespace word_compiler.Services.Rules
{
    public class Word
    {
        public SymbolType type = SymbolType.ERROR;
        public string value = string.Empty;
    }

    public class RuleManager
    {
        public List<Rule> rules;
        public RuleManager()
        {
            
            string rulePath = "Rules.json";
            string ruleJson = FileManager.ReadFile(rulePath);
            rules = JsonConvert.DeserializeObject<List<Rule>>(ruleJson);
            /*
            rules = new List<Rule>
            {
                new Rule{
                    type = SymbolType.CONSTANT,
                    patterns = new List<string>
                    {
                        "[0-9]+"
                    }
                },
                new Rule
                {
                    type = SymbolType.DELEMITER,
                    patterns = new List<string>
                    {
                        @"[\s]+"
                    }
                },
                new Rule
                {
                    type = SymbolType.RESERVED,
                    patterns = new List<string>
                    {
                        "int",
                        "="
                    }
                },
                new Rule
                {
                    type = SymbolType.TAG,
                    patterns = new List<string>
                    {
                        "[a-zA-Z_][a-zA-Z0-9_]*"
                    }
                }
            };
            */
            //string rulesJson = JsonConvert.SerializeObject(rules,Formatting.Indented);
            //FileManager.WriteFile(rulePath, rulesJson);
        }
        
        public Word TryParse(string input)
        {
            Word target = new Word();
            foreach(var rule in rules)
            {
                foreach(var pattern in rule.patterns)
                {
                    var match = Regex.Match(input, "^" + pattern);
                    if (match.Success)
                    {
                        //TODO:匹配规则 存疑
                        if(target.value.Length < match.Length)
                        {
                            target.type = rule.type;
                            target.value = match.Value;
                        }
                    }
                }
            }
            if(target.type == SymbolType.ERROR)
            {
                const int MAX_EXCEPTION_LENGTH = 5;
                if(input.Length < MAX_EXCEPTION_LENGTH)
                {
                    throw new Exception(input);
                }
                else
                {
                    throw new Exception(input.Substring(0,MAX_EXCEPTION_LENGTH));
                }
            }
            return target;
        }
    }
}
