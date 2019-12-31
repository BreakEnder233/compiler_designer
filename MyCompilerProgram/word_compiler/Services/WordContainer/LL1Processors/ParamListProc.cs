using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ParamListProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _paramList(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = ParamList;

            var param = ll1._param();
            node.AddChild(param);

            var next = WordContainer.GetWordType();
            while (next == WordType.COMMA)
            {
                WordContainer.Advance(WordType.COMMA);

                param = ll1._param();
                node.AddChild(param);
                next = WordContainer.GetWordType();
            }
            return node;
        }
        #region generators
        public static void ParamList(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
