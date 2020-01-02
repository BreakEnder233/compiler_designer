using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.MidCodeGenerate;

namespace word_compiler.Services.WordContainer.LL1Processors
{
    public static class FunDeclarationProc
    {
        public static List<WordType> first = new List<WordType>{ };

        public static GATNode _funDeclaration(this LL1Processor ll1)
        {
            var node = new GATNode();
            var typeSpecifier = ll1._typeSpecifier();
            var id = WordContainer.Advance(WordType.ID);
            WordContainer.Advance(WordType.BRACKET_L);
            var param = ll1._params();
            WordContainer.Advance(WordType.BRACKET_R);
            var compoundStmt = ll1._compoundStmt();
            //
            node.name = id.value;
            //
            node.generator = FunDeclaration;
            node.AddChild(typeSpecifier);//0
            node.AddChild(id);//1
            node.AddChild(param);//2
            node.AddChild(GATNode.LabelNode());//3
            node.AddChild(compoundStmt);//4

            return node;
        }
        #region generators
        public static void FunDeclaration(GATNode node)
        {
            //支持参数表
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName);
            CodeGenerator.AddLabel(node.getChild(1).GetProperty("value"), Int32.Parse(node.getChild(3).GetProperty("CodeLine")));

            var funcName = node.getChild(1).GetProperty("value");
            var returnType = node.getChild(0).GetProperty("value");
            var paramCount = node.getChild(2).ChildCount() == 0 ? 0 : node.getChild(2).getChild(0).ChildCount();
            var paramName = new List<string>();
            if(paramCount != 0)
            {
                var paramList = node.getChild(2).getChild(0);
                for (int i = 0; i < paramList.ChildCount(); i++)
                {
                    var param = paramList.getChild(i);
                    paramName.Add(param.getChild(1).GetProperty("value"));
                }
            }
            CodeGenerator.AddFunction(new FunctionStackFrame
            {
                name = funcName,
                returnType = returnType,
                parameterCount = paramCount,
                parameterName = paramName
            });
        }
        #endregion
    }
}
