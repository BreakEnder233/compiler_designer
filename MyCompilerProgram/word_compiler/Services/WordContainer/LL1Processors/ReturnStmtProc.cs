using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ReturnStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _returnStmt(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = ReturnStmt;
            WordContainer.Advance(WordType.RETURN);
            var next = WordContainer.GetWordType();
            if (ExpressionProc.first.Contains(next))
            {
               var expression =  ll1._expression();
               node.AddChild(expression);
            }
            WordContainer.Advance(WordType.SEMICOLON);
            return node;
        }
        #region generators
        public static void ReturnStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            if(node.ChildCount() == 0)
            {
                CodeGenerator.AddCode("ret","#","#","#");
            }
            else
            {
                var tmpNode = "T" + CodeGenerator.tempnum++;
                CodeGenerator.AddCode("+", "EBP", "12", tmpNode);
                CodeGenerator.AddCode("*", tmpNode, "4", tmpNode);
                CodeGenerator.AddCode("+", "EBP", tmpNode, tmpNode);
                CodeGenerator.AddCode("+", tmpNode, "16", tmpNode);
                CodeGenerator.AddCode("[", tmpNode, "#", tmpNode);
                CodeGenerator.AddCode("[", tmpNode, "#", tmpNode);
                CodeGenerator.AddCode("]", node.getChild(0).GetProperty("value"), "#", tmpNode);
                CodeGenerator.AddCode("ret", "#", "#", "#");
            }
        }
        #endregion
    }
}
