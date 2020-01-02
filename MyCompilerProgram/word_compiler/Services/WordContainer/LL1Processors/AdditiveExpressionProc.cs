using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class AdditiveExpressionProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _additiveExpression(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = AdditiveExpression;
            var term1 = ll1._term();
            node.AddChild(term1);
            var next = WordContainer.GetWordType();
            while (next == WordType.ADDOP)
            {
                var addop = WordContainer.Advance(WordType.ADDOP);
                node.AddChild(addop);
                var  term2 = ll1._term();
                node.AddChild(term2);
                next = WordContainer.GetWordType();
            }
            return node;
        }

        #region generators
        public static void AdditiveExpression(GATNode node)
        {
            int childnum = node.ChildCount();
            string addop="";
            GATNode child;

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            child = node.getChild(0);
            node.SetProperty("value", child.GetProperty("value"));
            for (int i = 1; i < childnum; i++)
            {
                child = node.getChild(i);
                if (child.GetProperty("value") == "+")
                {
                    addop = "+";
                }
                else if (child.GetProperty("value") == "-")
                {
                    addop = "-";
                }
                else//有待解决如何记录结果
                {
                    //Console.WriteLine(node.GetProperty("value") + addop + child.GetProperty("value"));
                    CodeGenerator.AddCode(addop, node.GetProperty("value"), child.GetProperty("value"), "T" + CodeGenerator.tempnum);
                    Console.WriteLine(addop + " " + node.GetProperty("value") + " " + child.GetProperty("value") + " " + "T" + CodeGenerator.tempnum);
                    node.SetProperty("value", "T" + CodeGenerator.tempnum);
                    CodeGenerator.tempnum++;

                }
            }
        }
        #endregion
    }
}