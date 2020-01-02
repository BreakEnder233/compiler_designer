using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class SelectionStmtProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _selectionStmt(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = SelectionStmt;

            WordContainer.Advance(WordType.IF);
            WordContainer.Advance(WordType.BRACKET_L);
            var expression = ll1._expression();
            WordContainer.Advance(WordType.BRACKET_R);
            var statement = ll1._statement();

            node.AddChild(expression);//0
            node.AddChild(GATNode.CodeNode());//1
            node.AddChild(statement);//2

            var next = WordContainer.GetWordType();
            if (next == WordType.ELSE)
            {
                WordContainer.Advance(WordType.ELSE);
                var elseStatement = ll1._statement();
                node.AddChild(GATNode.CodeNode());//3
                node.AddChild(GATNode.LabelNode());//4
                node.AddChild(elseStatement);//5
            }
            node.AddChild(GATNode.LabelNode());//3-6
            return node;
        }
        #region generators
        public static void SelectionStmt(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
            var expression = node.getChild(0);

            switch (node.ChildCount())
            {
                case 4:
                    {
                        var falseLabel = node.getChild(3).GetProperty("LabelName");
                        var jmpLine = Int32.Parse(node.getChild(1).GetProperty("CodeLine"));
                        CodeGenerator.SetCode(jmpLine, "je", expression.GetProperty("value"), "0", "0");
                        CodeGenerator.PutLabel(falseLabel, jmpLine);
                        break;
                    }
                case 7:
                    {
                        var falseLabel = node.getChild(4).GetProperty("LabelName");
                        var jmpLine = Int32.Parse(node.getChild(1).GetProperty("CodeLine"));
                        CodeGenerator.SetCode(jmpLine, "je", expression.GetProperty("value"), "0", "0");
                        CodeGenerator.PutLabel(falseLabel, jmpLine);

                        var endLabel = node.getChild(6).GetProperty("LabelName");
                        var trueEndLine = Int32.Parse(node.getChild(3).GetProperty("CodeLine"));
                        CodeGenerator.SetCode(trueEndLine, "j", "#", "#", "#");
                        CodeGenerator.PutLabel(endLabel, trueEndLine);
                        break;
                    }
            }
        }
        #endregion
    }
}
