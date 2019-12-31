using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class StatmentListProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _statementList(this LL1Processor ll1)
        {
            var node = new GATNode();
            node.generator = StatmentList;

            var next = WordContainer.GetWordType();
            while (StatementProc.first.Contains(next))
            {
                var statement = ll1._statement();
                node.AddChild(statement);

                next = WordContainer.GetWordType();
            }
            return node;
        }
        #region generators
        public static void StatmentList(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}
