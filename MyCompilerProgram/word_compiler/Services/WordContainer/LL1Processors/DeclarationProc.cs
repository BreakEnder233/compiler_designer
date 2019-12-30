using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class DeclarationProc
    {
        public static List<WordType> first = new List<WordType> {
            WordType.INT,
            WordType.VOID
        };
        public static GATNode _declaration(this LL1Processor ll1)
        {
            var node = new GATNode();
            var offset = 2;
            switch (WordContainer.GetWordType(offset))
            {
                case WordType.SEMICOLON:
                    {
                        var varDeclaration = ll1._varDeclaration();
                        node.AddChild(varDeclaration);
                        node.generator = declaration;
                        break;
                    }
                case WordType.BRACKET_L:
                    {
                        var funDeclaration = ll1._funDeclaration();
                        node.AddChild(funDeclaration);
                        node.generator = declaration;
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
        public static void Declaration1(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        public static void Declaration2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion

    }
}
