using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ExpressionProc
    {
        public static List<WordType> first = new List<WordType> {
            WordType.ID,
            WordType.BRACKET_L,
            WordType.NUM

    };
        public static GATNode _expression(this LL1Processor ll1)
        {
            var node = new GATNode();
            var offset = 0;
            var search = WordContainer.GetWordType(offset);
            var depth = 0;
            var finishSearch = false;
            while (search != WordType.IGNORE)
            {
                switch (search)
                {
                    case WordType.SEMICOLON:
                        {
                            var simpleExpression = ll1._simpleExpression();
                            node.AddChild(simpleExpression);
                            node.generator = Expression1;
                            finishSearch = true;
                            break;
                        }
                    case WordType.EQUAL:
                        {
                            var VAR = ll1._var();
                            node.AddChild(VAR);
                            node.generator = Expression2;
                            WordContainer.Advance(WordType.EQUAL);
                            var expression = ll1._expression();
                            node.AddChild(expression);
                            finishSearch = true;
                            break;
                        }
                    case WordType.BRACKET_L:
                        {
                            depth++;
                            break;
                        }
                    case WordType.BRACKET_R:
                        {
                            depth--;
                            if(depth < 0)
                            {
                                ll1._simpleExpression();
                                finishSearch = true;
                            }
                            break;
                        }
                }
                if (finishSearch)
                {
                    break;
                }
                offset++;
                search = WordContainer.GetWordType(offset);

            }

            return node;
        }
        #region generators
        public static void Expression1(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Expression2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
