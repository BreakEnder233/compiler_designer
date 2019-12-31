using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class LocalDeclarationsProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _localDeclarations(this LL1Processor ll1)
        {
            var node = new GATNode();
            var offset = 1;

            var next = WordContainer.GetWordType(offset);
            while(next == WordType.ID)
            {
                var varDeclaration = ll1._varDeclaration();
                node.AddChild(varDeclaration);
                next = WordContainer.GetWordType(offset);
            }

            if(node.ChildCount() == 0)
            {
                node.generator = LocalDeclarations2;
            }
            else
            {
                node.generator = LocalDeclarations1;
            }

            return node;
        }
        #region generators
        public static void LocalDeclarations1(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }

        public static void LocalDeclarations2(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
