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
                var expressionStmt = ll1._expressionStmt();
                node.AddChild(expressionStmt);
                node.generator = Statement1;
                return node;
            }
            var offset = 0;
            switch (WordContainer.GetWordType(offset))
            {
                case WordType.BRACE_L:
                    {
                        var compoundStmt = ll1._compoundStmt();
                        node.AddChild(compoundStmt);
                        node.generator = Statement2;
                        break;
                    }
                case WordType.IF:
                    {
                        var selectionStmt = ll1._selectionStmt();
                        node.AddChild(selectionStmt);
                        node.generator = Statement3;
                        break;
                    }
                case WordType.WHILE:
                    {
                        var iterationStmt = ll1._iterationStmt();
                        node.AddChild(iterationStmt);
                        node.generator = Statement4;
                        break;
                    }
                case WordType.RETURN:
                    {
                        var returnStmt = ll1._returnStmt();
                        node.AddChild(returnStmt);
                        node.generator = Statement5;
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
