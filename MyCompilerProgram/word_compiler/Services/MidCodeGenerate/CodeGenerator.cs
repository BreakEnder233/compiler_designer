using System;
using System.Collections.Generic;
using System.Text;

namespace word_compiler.Services.MidCodeGenerate
{
    public class Code
    {
        public string op, arg1, arg2, result;

        public override string ToString()
        {
            return $"{op}\t{arg1}\t{arg2}\t{result}";
        }
    }

    public class Symbol
    {
        public string name, process, infomation;
    }

    public static class CodeGenerator
    {
        private static List<Code> codes = new List<Code>();
        private static List<Symbol> symbols = new List<Symbol>();

        #region Code
        public static void AddCode(string op = null, string arg1 = null, string arg2 = null, string result = null)
        {
            codes.Add(new Code
            {
                op = op,
                arg1 = arg1,
                arg2 = arg2,
                result = result
            });
        }

        public static string CodeToString()
        {
            string codeString = string.Empty;
            foreach(var code in codes)
            {
                codeString += code.ToString();
            }
            return codeString;
        }
        #endregion

        #region Symbol
        public static void AddSymbol(string name = null, string process = null, string infomation = null)
        {
            symbols.Add(new Symbol
            {
                name = name,
                process = process,
                infomation = infomation
            });
        }
        #endregion
    }
}
