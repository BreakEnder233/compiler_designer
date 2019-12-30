using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class StatementProc
    {
        public static List<WordType> first = new List<WordType> {
            WordType.BRACE_L, 
            WordType.IF,
            WordType.WHILE,
            WordType.RETURN,
            WordType.BRACKET_L,
            WordType.NUM,
            WordType.ID
        };

        public static GATNode _statement(this LL1Processor ll1)
        {
            var node = new GATNode();
            var next = WordContainer.GetWordType();
            if (ExpressionStmtProc.first.Contains(next))
            {
                ll1._expressionStmt();
                return node;
            }
            var offset = 0;
            switch (WordContainer.GetWordType(offset))
            {
                case WordType.BRACE_L:
                    {
                        ll1._compoundStmt();
                        break;
                    }
                case WordType.IF:
                    {
                        ll1._selectionStmt();
                        break;
                    }
                case WordType.WHILE:
                    {
                        ll1._iterationStmt();
                        break;
                    }
                case WordType.RETURN:
                    {
                        ll1._returnStmt();
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
        public static void Statement1(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Statement2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Statement3(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Statement4(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Statement5(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
