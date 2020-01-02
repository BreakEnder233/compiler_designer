using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

using word_compiler.Services.Input;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.Rules
{
    public class Word
    {
        public WordType type = WordType.ERROR;
        public string value = string.Empty;

        public override string ToString()
        {
            return $"<{type.ToString()} . {value}>";
        }
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
            rules = new List<Rule>();
            for(int type = 0;type < (int)SymbolType.ERROR; type++)
            {
                rules.Add(new Rule
                {
                    type = (SymbolType)type,
                    patterns = new List<string> { 
                        "..."
                    }
                });
            }
            string rulesJson = JsonConvert.SerializeObject(rules,Formatting.Indented);
            FileManager.WriteFile(rulePath, rulesJson);
            */
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
                        //注释等短距离贪心除外
                        if(target.value.Length <= match.Length)
                        {
                            target.type = rule.type;
                            target.value = match.Value;
                        }
                    }
                }
            }
            if(target.type == WordType.ERROR)
            {
                const int MAX_EXCEPTION_LENGTH = 10;
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
