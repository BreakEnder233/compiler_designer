using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class IterationStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _iterationStmt(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = IterationStmt;
            WordContainer.Advance(WordType.WHILE);
            WordContainer.Advance(WordType.BRACKET_L);
            node.AddChild(GATNode.LabelNode());//0
            var expression =  ll1._expression();
            node.AddChild(expression);//1
            node.AddChild(GATNode.CodeNode());//2
            WordContainer.Advance(WordType.BRACKET_R);
            var statement = ll1._statement();
            node.AddChild(statement);//3
            node.AddChild(GATNode.CodeNode());//4
            node.AddChild(GATNode.LabelNode());//5
            return node;
        }
        #region generators
        public static void IterationStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);

            var expressionLabel = node.getChild(0).GetProperty("LabelName");
            var endLabel = node.getChild(5).GetProperty("LabelName");
            var jmpLine = Int32.Parse(node.getChild(2).GetProperty("CodeLine"));
            var retLine = Int32.Parse(node.getChild(4).GetProperty("CodeLine"));
            CodeGenerator.SetCode(retLine, "j", "#", "#", "#");
            CodeGenerator.PutLabel(expressionLabel, retLine);

            CodeGenerator.SetCode(jmpLine, "je", node.getChild(1).GetProperty("value"), "0", "#");
            CodeGenerator.PutLabel(endLabel, jmpLine);
        }
        #endregion
    }
}