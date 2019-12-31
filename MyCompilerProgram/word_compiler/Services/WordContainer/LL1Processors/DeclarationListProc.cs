using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class DeclarationListProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static GATNode _declarationList(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = DeclarationList;
            var declaration = ll1._declaration();
            node.AddChild(declaration);
            var next = WordContainer.GetWordType();
            while (DeclarationProc.first.Contains(next))
            {
                declaration = ll1._declaration();
                node.AddChild(declaration);
                next = WordContainer.GetWordType();
            }
            return node;
        }

        #region generators
        public static void DeclarationList(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
