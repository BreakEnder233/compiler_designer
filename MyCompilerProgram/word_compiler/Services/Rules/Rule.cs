using System;
using System.Collections.Generic;
using System.Text;

namespace word_compiler.Services.Rules
{
    public enum SymbolType
    {
        IGNORE,
        ID,
        NUM,
        SQUARE_BRACKET_L, //[
        SQUARE_BRACKET_R, //]
        SEMICOLON, //;
        BRACE_L, //{
        BRACE_R, //}
        EQUAL, //=
        BRACKET_L, //(
        BRACKET_R, //)
        ADDOP,
        MULOP,
        RELOP,
        INT,
        VOID,
        IF,
        ELSE,
        RETURN,
        WHILE,
        ERROR
    }

    public class Rule
    {
        public SymbolType type;
        public List<string> patterns;
    }
}
