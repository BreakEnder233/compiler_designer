using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;

namespace word_compiler.Services.WordContainer
{
    public class BNFException : Exception
    {
        string message;
        public BNFException()
        {
            var index = WordContainer.index;
            message = $"Exception at index: {index} , word is {WordContainer.GetWord().value}";
            Console.WriteLine(message);
        }
    }

    public static class WordContainer
    {
        private static List<Word> words;
        public static int index = 0;

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


        public static Word Advance(WordType expectedWordType = WordType.IGNORE)
        {
            var next = GetWord();
            if(expectedWordType == WordType.IGNORE)
            {
                index++;
            }
            else if (next.type == expectedWordType)
            {
                index++;
            }
            else
            {
                throw new BNFException();
            }
            return next;
        }

        public static Word GetWord(int offset = 0)
        {
            if(words.Count < index + offset)
            {
                return null;
            }
            return words[index + offset];
        }

        public static WordType GetWordType(int offset = 0)
        {
            return GetWord(offset)?.type ?? WordType.IGNORE;
        }
    }
}
