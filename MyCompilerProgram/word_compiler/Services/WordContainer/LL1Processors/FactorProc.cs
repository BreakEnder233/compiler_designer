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
                        ll1._expression();
                        WordContainer.Advance(WordType.BRACKET_R);
                        break;
                    }
                case WordType.ID:
                    {
                        offset = 1;
                        if (WordContainer.GetWordType(offset) == WordType.BRACKET_L)
                        {
                            ll1._call();
                        }
                        else
                        {
                            ll1._var();
                        }
                        break;
                    }
                case WordType.NUM:
                    {
                        WordContainer.Advance(WordType.NUM);
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
        }
        public static void Factor2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Factor3(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Factor4(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}