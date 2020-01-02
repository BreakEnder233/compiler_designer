using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ProgramProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _program(this LL1Processor ll1)
        {
            var node = new GATNode();
            var declarationList = ll1._declarationList();
            node.AddChild(declarationList);
            WordContainer.Advance(WordType.HASHTAG);
            return node;
        }

       
        #region generators
        public static void program(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            //CodeGenerator.AddLabel("global", 0);
        }
        #endregion
    }
}
