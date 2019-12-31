using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ParamsProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _params(this LL1Processor ll1)
        {
            var node = new GATNode();
            var offset = 1;
            if (WordContainer.GetWordType(offset) == WordType.BRACKET_R)
            {
                WordContainer.Advance(WordType.VOID);
            }
            else
            {
                var paramList = ll1._paramList();
                node.AddChild(paramList);
                node.generator = Params;
            }
            return node;
        }
        #region generators
        public static void Params(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
