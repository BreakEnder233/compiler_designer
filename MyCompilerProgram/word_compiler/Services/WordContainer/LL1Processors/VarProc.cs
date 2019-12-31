using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class VarProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _var(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = Var;
            var id = WordContainer.Advance(WordType.ID);
            node.AddChild(id);
            var next = WordContainer.GetWordType();
            if (next == WordType.SQUARE_BRACKET_L)
            {
                WordContainer.Advance(WordType.SQUARE_BRACKET_L);
                var expression = ll1._expression();
                node.AddChild(expression);
                WordContainer.Advance(WordType.SQUARE_BRACKET_R);
            }
            return node;
        }
        #region generators
        public static void Var(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
