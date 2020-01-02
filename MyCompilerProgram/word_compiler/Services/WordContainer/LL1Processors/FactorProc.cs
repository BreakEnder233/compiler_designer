using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class FactorProc
    {
        public static List<WordType> first = new List<WordType> { };
        public static GATNode _factor(this LL1Processor ll1)
        {
            var node = new GATNode();
            var offset = 0;
            switch (WordContainer.GetWordType(offset))
            {
                case WordType.BRACKET_L:
                    {
                        WordContainer.Advance(WordType.BRACKET_L);
                        var expression = ll1._expression();
                        node.AddChild(expression);
                        node.generator = Factor1;
                        WordContainer.Advance(WordType.BRACKET_R);
                        break;
                    }
                case WordType.ID:
                    {
                        offset = 1;
                        if (WordContainer.GetWordType(offset) == WordType.BRACKET_L)
                        {
                            var CALL = ll1._call();
                            node.AddChild(CALL);
                            node.generator = Factor2;
                        }
                        else
                        {
                            var VAR = ll1._var();
                            node.AddChild(VAR);
                            node.generator = Factor3;
                        }
                        break;
                    }
                case WordType.NUM:
                    {
                        var num = WordContainer.Advance(WordType.NUM);
                        node.AddChild(num);
                        node.generator = Factor4;
                        break;
                    }
                default:
                    {
                        throw new BNFException();
                    }
            }
            return node;
        }
        #region generators
        public static void Factor1(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
            node.SetProperty("value", node.getChild(0).GetProperty("value"));
        }
        public static void Factor2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
            node.SetProperty("value", node.getChild(0).GetProperty("value"));
        }
        public static void Factor3(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
            node.SetProperty("value", node.getChild(0).GetProperty("value"));

        }
        public static void Factor4(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
            node.SetProperty("value", node.getChild(0).GetProperty("value"));

        }
        #endregion
    }
}