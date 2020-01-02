using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class SimpleExpressionProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _simpleExpression(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = SimpleExpression;
            var additiveExpression1 = ll1._additiveExpression();
            node.AddChild(additiveExpression1);
            var next = WordContainer.GetWordType();
            while(next == WordType.RELOP)
            { 
                var relop  = WordContainer.Advance(WordType.RELOP);
                node.AddChild(relop);
                var additiveExpression2 = ll1._additiveExpression();
                node.AddChild(additiveExpression2);
                next = WordContainer.GetWordType();
            }
            return node;
        }
        #region generators
        public static void SimpleExpression(GATNode node)
        {
            int childnum = node.ChildCount();
            string relop="";
            GATNode child;

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            child = node.getChild(0);
            node.SetProperty("value", child.GetProperty("value"));
            for (int i = 1; i < childnum; i++)
            {
                child = node.getChild(i);
                if (child.GetProperty("value") == "<=")
                {
                    relop = "<=";
                }
                else if (child.GetProperty("value") == ">=")
                {
                    relop = ">=";
                }
                else if (child.GetProperty("value") == "==")
                {
                    relop = "==";
                }
                else if (child.GetProperty("value") == "!=")
                {
                    relop = "!=";
                }
                else if (child.GetProperty("value") == "<")
                {
                    relop = "<";
                }
                else if (child.GetProperty("value") == ">")
                {
                    relop = ">";
                }
                else//有待解决如何记录结果
                {
                    CodeGenerator.AddCode(relop, node.GetProperty("value"), child.GetProperty("value"), "T" + CodeGenerator.tempnum);
                    Console.WriteLine(relop + " " + node.GetProperty("value") + " " + child.GetProperty("value") + " " + "T" + CodeGenerator.tempnum);
                    node.SetProperty("value", "T" + CodeGenerator.tempnum);
                    CodeGenerator.tempnum++;
                }
            }
        }
        #endregion
    }
}
