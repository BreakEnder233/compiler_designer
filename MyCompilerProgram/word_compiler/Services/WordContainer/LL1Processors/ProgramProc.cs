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
            node.generator = program;
            var declarationList = ll1._declarationList();
            node.AddChild(GATNode.CodeNode());//0
            node.AddChild(declarationList);//1
            WordContainer.Advance(WordType.HASHTAG);
            return node;
        }

       
        #region generators
        public static void program(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            var startLine = Int32.Parse(node.getChild(0).GetProperty("CodeLine"));
            CodeGenerator.SetCode(startLine, "j", "#", "#", "#");
            CodeGenerator.PutLabel("main", startLine);

            //CodeGenerator.AddLabel("global", 0);
        }
        #endregion
    }
}
