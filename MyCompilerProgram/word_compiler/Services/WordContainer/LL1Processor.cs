using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.MidCodeGenerate;
using word_compiler.Services.WordContainer.LL1Processors;

namespace word_compiler.Services.WordContainer
{
    public class LL1Processor
    {
        private GATNode root = null;
        public void StartProcess()
        {
            root = this._program();
        }

        public void StartGenerate()
        {
            if (root == null)
            {
                Console.WriteLine("Root Null Error!");
            }
            else
            {
                root.enumChild();
            }

            if (CodeGenerator.isClosedCycle())
            {
                Console.WriteLine("Code Generation is not a closed cycle!");
            }
        }


    }
}
