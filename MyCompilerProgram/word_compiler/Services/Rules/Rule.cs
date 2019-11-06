using System;
using System.Collections.Generic;
using System.Text;

namespace word_compiler.Services.Rules
{
    public enum SymbolType
    {
        DELEMITER,
        RESERVED,
        CONSTANT,
        TAG,
        OPERATOR,
        ERROR
    }

    public class Rule
    {
        public SymbolType type;
        public List<string> patterns;
    }
}
