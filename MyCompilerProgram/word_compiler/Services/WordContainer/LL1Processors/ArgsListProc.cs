using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ArgListProc
    {
        public static List<WordType> first = new List<WordType> {
            WordType.ID,
            WordType.BRACKET_L,
            WordType.NUM
        };
        public static GATNode _argList(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = ArgList;
            var expression1 = ll1._expression();
            node.AddChild(expression1);
            var next = WordContainer.GetWordType();
            while (next == WordType.COMMA)
            {
                WordContainer.Advance(WordType.COMMA);
                var expression2 = ll1._expression();
                node.AddChild(expression2);
                next = WordContainer.GetWordType();
            }

            return node;
        }

        #region generators
        public static void ArgList(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}