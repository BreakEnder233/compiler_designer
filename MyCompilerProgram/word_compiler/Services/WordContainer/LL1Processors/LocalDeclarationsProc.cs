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
                ll1._varDeclaration();
                next = WordContainer.GetWordType(offset);
            }
            return node;
        }
        #region generators
        public static void LocalDeclarations(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
