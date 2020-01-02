using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class TypeSpecifierProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static GATNode _typeSpecifier(this LL1Processor ll1)
        {
            var node = new GATNode();
            var next = WordContainer.GetWordType();
            switch (next)
            {
                case WordType.INT:
                    {
                        var INT = WordContainer.Advance();
                        node.AddChild(INT);
                        node.generator = typeSpecifier1;
                        break;
                    }
                case WordType.VOID:
                    {
                        var VOID = WordContainer.Advance();
                        node.AddChild(VOID);
                        node.generator = typeSpecifier2;
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
        public static void typeSpecifier1(GATNode node)
        {
            node.SetProperty("value", "INT");
            Console.WriteLine("typeSpecifier1");
        }

        public static void typeSpecifier2(GATNode node)
        {
            node.SetProperty("value", "VOID");
            Console.WriteLine("typeSpecifier2");
        }
        #endregion
    }
}
