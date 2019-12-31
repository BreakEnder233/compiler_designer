using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ArgsProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _args(this LL1Processor ll1)
        {
            var node = new GATNode();
            var next = WordContainer.GetWordType();
            if (ArgListProc.first.Contains(next))
            {
                var argList = ll1._argList();
                node.AddChild(argList);
            }

            if (node.ChildCount() == 0)
            {
                node.generator = Args2;
            }
            else
            {
                node.generator = Args1;
            }
            return node;
        }
        #region generators
        public static void Args1(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Args2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}