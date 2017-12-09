using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Node
    {
        private int key;
        private Node left;
        private Node right;

        public Node(int key)
        {
            this.key = key;
            this.left = null;
            this.right = null;
        }

        public int GetKey()
        { return key; }
        public Node GetLeft()
        { return left; }
        public Node GetRight()
        { return right; }
        public void SetLeft(Node left)
        { this.left = left; }
        public void SetRight(Node right)
        { this.right = right; }

        public override string ToString()
        { return key.ToString(); }
    }
}
