using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
        private Node root;
        public BinaryTree()
        { this.root = null; }

        private Tuple<Node, Node> _Find(int key)
        {
            if (root == null)
            { return new Tuple<Node, Node>(null, null); }
            
            Node current = root;
            Node parent = null;
            while (key != current.GetKey())
            {
                if (key < current.GetKey())
                {
                    if (current.GetLeft() == null)
                    { return new Tuple<Node, Node>(null, current); }
                    parent = current;
                    current = current.GetLeft();
                }
                else
                {
                    if (current.GetRight() == null)
                    { return new Tuple<Node, Node>(null, current); }
                    parent = current;
                    current = current.GetRight();
                }
            }
            return new Tuple<Node,Node>(current, parent);
        }

        public void Add(Node node)
        {
            Tuple<Node, Node> tup = _Find(node.GetKey());
            Node exNode = tup.Item1, parent = tup.Item2;

            if (exNode == null)
            {
                if (true)
                {
                    
                }
            }
        }
    }
}
