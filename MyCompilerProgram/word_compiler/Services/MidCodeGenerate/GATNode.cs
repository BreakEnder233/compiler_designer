using System;
using System.Collections.Generic;
using System.Text;
using word_compiler.Services.Rules;
using word_compiler.Services.WordContainer.LL1Processors;

namespace word_compiler.Services.MidCodeGenerate
{
    public class GATNode//Grammer Analyze Tree Node
    {
        public string name;
        private GATNode parent;
        private Dictionary<string, string> properties = new Dictionary<string, string>();
        private List<GATNode> children = new List<GATNode>();
        public Action<GATNode> generator = (node) => { };

        public void SetParent(GATNode node)
        {
            parent = node;
        }
        public void SetProperty(string name, string value)
        {
            if (properties.ContainsKey(name))
            {
                properties[name] = value;
            }
            else
            {
                properties.Add(name, value);
            }
        }

        public void AddChild(GATNode node)
        {
            if (children.Contains(node)) return;
            node.SetParent(this);
            children.Add(node);
        }

        public int ChildCount()
        {
            return children.Count;
        }

        public void enumChild()
        {
            foreach(var child in children)
            {
                child.enumChild();
            }
            generator(this);
        }


        public static implicit operator GATNode(Word word)
        {
            var node = new GATNode();
            //node.name = Guid.NewGuid().ToString();
            node.SetProperty("value", word.value);
            node.SetProperty("type", word.type.ToString());
            return node;
        }

    }
}
