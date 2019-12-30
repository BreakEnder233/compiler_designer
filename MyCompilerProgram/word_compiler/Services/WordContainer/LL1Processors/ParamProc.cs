﻿using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class ParamProc
    {
        public static List<WordType> first = new List<WordType> { };

        public static GATNode _param(this LL1Processor ll1)
        {
            var node = new GATNode();

            ll1._typeSpecifier();
            WordContainer.Advance(WordType.ID);
            var next = WordContainer.GetWordType();
            if (next == WordType.SQUARE_BRACKET_L)
            {
                WordContainer.Advance(WordType.SQUARE_BRACKET_L);
                WordContainer.Advance(WordType.SQUARE_BRACKET_R);
            }
            return node;
        }
        #region generators
        public static void Param(GATNode node)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
        }
        #endregion
    }
}

