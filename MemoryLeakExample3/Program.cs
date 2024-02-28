using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakExample3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rootNode = new TreeNode();
            while (true)
            {
                // create a new subtree of 10000 nodes
                var newNode = new TreeNode();
                for (int i = 0; i < 10000; i++)
                {
                    var childNode = new TreeNode();
                    newNode.AddChild(childNode);
                }
                rootNode.AddChild(newNode);
            }
        }
    }
    class TreeNode : IDisposable
    {
        private readonly List<TreeNode> _children = new List<TreeNode>();

        public void AddChild(TreeNode child)
        {
            _children.Add(child);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of child nodes
                foreach (var child in _children)
                {
                    child.Dispose();
                }
            }
        }
    }
}
