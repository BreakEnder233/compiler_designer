using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class CallProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _call(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = Call;
            var id = WordContainer.Advance(WordType.ID);
            node.AddChild(id);
            WordContainer.Advance(WordType.BRACKET_L);
            var args = ll1._args();
            node.AddChild(args); 
            WordContainer.Advance(WordType.BRACKET_R);
            return node;
        }
        #region generators
        public static void Call(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}