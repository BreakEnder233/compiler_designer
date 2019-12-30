using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class VarDeclarationProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static GATNode _varDeclaration(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = varDeclaration;
            var typeSpecifier = ll1._typeSpecifier();
            var id = WordContainer.Advance(WordType.ID);
            node.AddChild(typeSpecifier);
            node.AddChild(id);


            if(WordContainer.GetWordType() == WordType.SQUARE_BRACKET_L)
            {
                WordContainer.Advance(WordType.SQUARE_BRACKET_L);
                var num = WordContainer.Advance(WordType.NUM);
                WordContainer.Advance(WordType.SQUARE_BRACKET_R);

                node.AddChild(num);
            }
            WordContainer.Advance(WordType.SEMICOLON);
            return node;
        }
        #region generators
        public static void varDeclaration(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
