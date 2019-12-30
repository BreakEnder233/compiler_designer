using System;
using System.Collections.Generic;
using System.Text;

namespace word_compiler.Services.Rules
{
    public enum WordType
    {
        IGNORE,
        ID,
        NUM,
        SQUARE_BRACKET_L, //[
        SQUARE_BRACKET_R, //]
        SEMICOLON, //;
        COMMA, //，
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
        ERROR,
        HASHTAG
    }

    public class Rule
    {
        public WordType type;
        public List<string> patterns;
    }
}
