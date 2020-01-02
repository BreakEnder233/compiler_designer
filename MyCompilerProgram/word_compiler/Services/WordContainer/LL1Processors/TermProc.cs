using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class TermProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _term(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = Term;
            var factor1 = ll1._factor();
            node.AddChild(factor1);
            var next = WordContainer.GetWordType();
            while (next == WordType.MULOP)
            {
                var mulop = WordContainer.Advance(WordType.MULOP);
                node.AddChild(mulop);
                var factor2 = ll1._factor();
                node.AddChild(factor2);
                next = WordContainer.GetWordType();
            }
            return node;
        }
        #region generators
        public static void Term(GATNode node)
        {
            int childnum = node.ChildCount();
            string mulop="";
            GATNode child;

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            child = node.getChild(0);
            node.SetProperty("value", child.GetProperty("value"));
            for (int i = 1; i < childnum; i++)
            {
                child = node.getChild(i);
                if (child.GetProperty("value") == "*")
                {
                    mulop = "*";
                }
                else if(child.GetProperty("value")=="/")
                {
                    mulop = "/";
                }
                else//有待解决如何记录结果
                {
                    CodeGenerator.AddCode(mulop, node.GetProperty("value"), child.GetProperty("value"), "T" + CodeGenerator.tempnum);
                    Console.WriteLine(mulop + " " + node.GetProperty("value") + " " + child.GetProperty("value") + " " + "T" + CodeGenerator.tempnum);
                    node.SetProperty("value", "T" + CodeGenerator.tempnum);
                    CodeGenerator.tempnum++;
                }
            }
        }
        #endregion
    }
}
