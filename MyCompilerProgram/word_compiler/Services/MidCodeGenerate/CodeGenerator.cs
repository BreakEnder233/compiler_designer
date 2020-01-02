using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace word_compiler.Services.MidCodeGenerate
{
    public class Code
    {
        public string op, arg1, arg2, result;

        public override string ToString()
        {
            string placeHolder = "#";
            return $"{(string.IsNullOrWhiteSpace(op)?placeHolder:op)}\t{(string.IsNullOrWhiteSpace(arg1) ? placeHolder : arg1)}\t{(string.IsNullOrWhiteSpace(arg2) ? placeHolder : arg2)}\t{(string.IsNullOrWhiteSpace(result) ? placeHolder : result)}";
        }
    }
    public class Symbol
    {
        public string name, process, infomation;
    }
    public class Label
    {
        public string name;
        public int position;
    }
    public class BackPatchTask
    {
        public string name;
        public List<int> backPatchIndex; 
    }

    public static class CodeGenerator
    {
        private static List<Code> codes = new List<Code>();
        private static List<Symbol> symbols = new List<Symbol>();
        private static List<Label> labels = new List<Label>();
        private static List<BackPatchTask> backPatchTasks = new List<BackPatchTask>();

        public static int tempnum=1;

        #region Code
        public static int AddCode(string op = null, string arg1 = null, string arg2 = null, string result = null)
        {
            codes.Add(new Code
            {
                op = op,
                arg1 = arg1,
                arg2 = arg2,
                result = result
            });
            return codes.Count - 1;
        }

        public static int SetCode(int line, string op = null, string arg1 = null, string arg2 = null, string result = null)
        {
            codes[line] = new Code
            {
                op = op,
                arg1 = arg1,
                arg2 = arg2,
                result = result
            };
            return line;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Index of next inserted code</returns>
        public static int GetNextQuad()
        {
            return codes.Count;
        }

        public static string CodeToString()
        {
            string codeString = string.Empty;
            codeString += $"INDEX\t:\tOP\tARG1\tARG2\tRESULT\n";
            int index = 0;
            foreach(var code in codes)
            {
                codeString += $"{index++}\t:\t{code.ToString()}\n";
            }
            return codeString;
        }
        #endregion

        #region Symbol
        public static void AddSymbol(string name = null, string process = null, string infomation = null)
        {
            symbols.Add(new Symbol
            {
                name = name,
                process = process,
                infomation = infomation
            });
        }

        #endregion

        #region Label
        /// <summary>
        /// Add the label to labels and backpatch all fit tasks.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="position"></param>
        public static void AddLabel(string name , int position)
        {
            labels.Add(new Label
            {
                name = name,
                position = position
            });

            var task = backPatchTasks.FirstOrDefault((t) => t.name == name);
            if(task != null)
            {
                foreach(var index in task.backPatchIndex)
                {
                    codes[index].result = position.ToString();
                }
            }
        }

        /// <summary>
        /// Put the label into codes[index] if label exists,
        /// otherwise generate a backpatch task to refill later.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        public static string PutLabel(string name, int index)
        {
            if (labels.Exists((t) => t.name == name))
            {
                string line = labels.First((l) => l.name == name).position.ToString();
                codes[index].result = line;
                return line;
            }
            else
            {
                var task = backPatchTasks.FirstOrDefault((t) => t.name == name);
                if (task == null)
                {
                    //attach new task
                    backPatchTasks.Add(new BackPatchTask
                    {
                        name = name,
                        backPatchIndex = new List<int>
                        {
                            index
                        }
                    });
                }
                else
                {
                    //add new task
                    task.backPatchIndex.Add(index);
                }
            }
            return "-";

        }

        public static int GetLabelLength()
        {
            return labels.Count();
        }

        #endregion
    }
}
