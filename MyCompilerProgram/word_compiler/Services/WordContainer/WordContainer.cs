using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer
{
    public class BNFException : Exception
    {

    }

    public static class WordContainer
    {
        private static List<Word> words;
        private static int index = 0;

        public static void InjectData(List<Word> data)
        {
            index = 0;
            words = new List<Word>();
            data.ForEach((t) => words.Add(t));
            words.Add(new Word { type = WordType.HASHTAG, value = "#" });
        }

        public static string GetString()
        {
            string str = string.Empty;
            foreach (var v in words)
            {
                str += v.ToString() + '\n';
            }
            return str;
        }


        public static void Advance(WordType expectedWordType = WordType.IGNORE)
        {
            if(expectedWordType == WordType.IGNORE)
            {
                index++;
            }
            else if (GetWordType() == expectedWordType)
            {
                index++;
            }
            else
            {
                throw new BNFException();
            }
        }

        public static Word GetWord(int offset = 0)
        {
            return words[index + offset];
        }

        public static WordType GetWordType(int offset = 0)
        {
            return GetWord(offset).type;
        }
    }
}
