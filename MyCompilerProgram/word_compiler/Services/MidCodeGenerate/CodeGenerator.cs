#define ASSEMBLY_MODE

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

        public override string ToString()
        {
            return $"{name}\t{process}\t{infomation}";
        }
    }
    public class Label
    {
        public string name;
        public int position;

        public override string ToString()
        {
            return $"{name}\t{position}";
        }
    }
    public class BackPatchTask
    {
        public string name;
        public List<int> backPatchIndex; 
    }
    public class FunctionStackFrame
    {
        public string name;
        public string returnType;
        public List<string> parameterName;
        public int parameterCount;
    }

    public static class CodeGenerator
    {
        private static List<Code> symbol = new List<Code>();
        private static List<Symbol> symbols = new List<Symbol>();
        private static List<Label> labels = new List<Label>();
        private static List<BackPatchTask> backPatchTasks = new List<BackPatchTask>();
        private static List<FunctionStackFrame> functionStackFrames = new List<FunctionStackFrame>();

        public static int tempnum=1;

        public static bool isClosedCycle()
        {
            return backPatchTasks.Count == 0;
        }

        #region Code
        public static int AddCode(string op = null, string arg1 = null, string arg2 = null, string result = null)
        {
            symbol.Add(new Code
            {
                op = op,
                arg1 = arg1,
                arg2 = arg2,
                result = result
            });
            return symbol.Count - 1;
        }

        public static int SetCode(int line, string op = null, string arg1 = null, string arg2 = null, string result = null)
        {
            symbol[line] = new Code
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
            return symbol.Count;
        }

        public static string CodeToString()
        {
            string codeString = string.Empty;
            codeString += $"INDEX\t:\tOP\tARG1\tARG2\tRESULT\n";
            int index = 0;
            foreach(var code in symbol)
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

        public static string SymbolToString()
        {
            string symbolString = string.Empty;
            symbolString += $"INDEX\t:\tNAME\tPROCESS\tINFO\n";
            int index = 0;
            foreach (var symbol in symbols)
            {
                symbolString += $"{index++}\t:\t{symbol.ToString()}\n";
            }
            return symbolString;
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
                    symbol[index].result = position.ToString();
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
                symbol[index].result = line;
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

        public static string LabelToString()
        {
            string labelString = string.Empty;
            labelString += $"INDEX\t:\tNAME\tLINE\n";
            int index = 0;
            foreach (var label in labels)
            {
                labelString += $"{index++}\t:\t{label.ToString()}\n";
            }
            return labelString;
        }

        #endregion

        #region FunctionStackFrame

        public static void AddFunction(FunctionStackFrame functionStackFrame)
        {
            if(functionStackFrames.FirstOrDefault((fsf) => fsf.name == functionStackFrame.name) == null)
            {
                functionStackFrames.Add(functionStackFrame);
                int index = 0;
                foreach(var paramName in functionStackFrame.parameterName)
                {
                    symbols.Add(new Symbol
                    {
                        name = paramName,
                        process = functionStackFrame.name,
                        infomation = $"[EBP + {16 + 4 * index++}]"
                    });
                }
            }
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcName"></param>
        /// <param name="parameterName"></param>
        /// <returns>name of return temp node</returns>
        public static string CallFunction(string funcName, List<string> parameterName)
        {
            /*调用活动记录结构：
             * reservedPlaceForReturnValue [ebp + [ebp + 12] * 4 + 16] / tmpNode
             * param0
             * param1
             * ...
             * paramx
             * paramCount [ebp + 12]
             * returnAddress
             * oldEbp
             */

            var tempNode = "T" + tempnum++;

            AddCode("push", "#", "#", tempNode);
            //AddCode("push", "#", "#", "#");
            foreach (var param in parameterName)
            {
                AddCode("push", "#", "#", param);
            }
            AddCode("push", "#", "#", parameterName.Count.ToString());
#if ASSEMBLY_MODE
            AddCode("call", "#", "#", funcName);
#else
            AddCode("push", "#", "#", (GetNextQuad() + 1).ToString());//压入返回地址
            var jmpLine = AddCode("jmp", "#", "#", "#");
            PutLabel(funcName, jmpLine);
#endif
            AddCode("pop", "#", "#", "#");//to pop paramCount
            foreach (var param in parameterName)
            {
                AddCode("pop", "#", "#", "#");
            }
            AddCode("pop", "#", "#", "#");//to pop tmpNode
            return tempNode;
        }

#endregion
    }
}
