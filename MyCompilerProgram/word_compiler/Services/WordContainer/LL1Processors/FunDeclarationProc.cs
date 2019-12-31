using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class FunDeclarationProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static GATNode _funDeclaration(this LL1Processor ll1)
        {
            var node = new GATNode();
            var typeSpecifier = ll1._typeSpecifier();
            var id = WordContainer.Advance(WordType.ID);
            WordContainer.Advance(WordType.BRACKET_L);
            var param = ll1._params();
            WordContainer.Advance(WordType.BRACKET_R);
            var compoundStmt = ll1._compoundStmt();

            node.generator = FunDeclaration;
            node.AddChild(typeSpecifier);
            node.AddChild(id);
            node.AddChild(param);
            node.AddChild(compoundStmt);

            return node;
        }
        #region generators
        public static void FunDeclaration(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
