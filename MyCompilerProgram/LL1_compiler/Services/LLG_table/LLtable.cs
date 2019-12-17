using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace LL1_compiler.Services.LLG_table
{
    class LLtableNode
    {
        public char non_terminal;
        public char terminal;
        public string generate;

        public LLtableNode(char nt,char t,string g)
        {
            non_terminal = nt;
            terminal = t;
            generate = g;
        }

    }

    class LLtable
    {
        public List<LLtableNode> table = new List<LLtableNode>();

        public LLtable()
        {
            LLtableNode inputnode = new LLtableNode('E','i',"GT"); //generate逆序存方便入栈
            table.Add(inputnode);
            inputnode = new LLtableNode('E', '(', "GT");
            table.Add(inputnode);

            inputnode = new LLtableNode('G', '+', "GT+");
            table.Add(inputnode);
            inputnode = new LLtableNode('G', ')', "$"); //$表示空
            table.Add(inputnode);
            inputnode = new LLtableNode('G', '#', "$");
            table.Add(inputnode);

            inputnode = new LLtableNode('T', 'i', "HF");
            table.Add(inputnode);
            inputnode = new LLtableNode('T', '(', "HF");
            table.Add(inputnode);

            inputnode = new LLtableNode('H', '*', "HF*");
            table.Add(inputnode);
            inputnode = new LLtableNode('H', '+', "$");
            table.Add(inputnode);
            inputnode = new LLtableNode('H', ')', "$");
            table.Add(inputnode);
            inputnode = new LLtableNode('H', '#', "$");
            table.Add(inputnode);

            inputnode = new LLtableNode('F', 'i', "i");
            table.Add(inputnode);
            inputnode = new LLtableNode('F', '(', ")E(");
            table.Add(inputnode);
        }

        public string getGenerate(char nt,char t)
        {
            string objg;
            objg = table
                .Where((i) => i.non_terminal == nt && i.terminal == t)
                .Select((i) => i.generate)
                .FirstOrDefault();

            return objg;
        }
    }
}
