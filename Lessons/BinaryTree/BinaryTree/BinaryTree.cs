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
        
        //возвращает кортеж из 2 элементов (узел, родитель)
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
                    current = current.GetLeft(); //спуск
                }
                else
                {
                    if (current.GetRight() == null)
                    { return new Tuple<Node, Node>(null, current); }
                    parent = current;
                    current = current.GetRight(); //спуск
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
                if (parent == null) root = node;
                else if (parent.GetKey() > node.GetKey())
                { parent.SetLeft(node); }
                else parent.SetRight(node);
            }
            else
            {
                node.SetLeft(exNode.GetLeft());
                node.SetRight(exNode.GetRight());
                if (parent.GetLeft() == exNode)
                { parent.SetLeft(node); }
                else parent.SetRight(node);
            }
        }

        public Node Find(int key)
        { return _Find(key).Item1; }

        public Node Remove(int key)
        {
            Tuple<Node, Node> tup = _Find(key);
            Node node = tup.Item1, parent = tup.Item2;
            if (node == null) return null;
            
            //leaf case
            if (node.GetLeft() == null && node.GetRight() == null)
            {
                if (parent != null)
                {
                    if (parent.GetLeft() == node)
                    { parent.SetLeft(null); }
                    else parent.SetRight(null);
                }
                else root = null;
            }
            //signle child case
            else if (node.GetLeft() == null || node.GetRight() == null)
            {
                bool nodeHasLeft = node.GetLeft() != null;
                if (parent != null)
                {
                    if (parent.GetLeft() == node)
                    {
                        if (nodeHasLeft) parent.SetLeft(node.GetLeft());
                        else parent.SetLeft(node.GetRight());
                    }
                    else
                    {
                        if (nodeHasLeft) parent.SetRight(node.GetLeft());
                        else parent.SetRight(node.GetRight());
                    }
                }
                else
                {
                    if (nodeHasLeft) root = node.GetLeft();
                    else root = node.GetRight();
                }
            }
            //two childs case
            else
            {
                Node currParent = node;
                Node current = node.GetRight();
                while (current.GetLeft() != null)
                {
                    currParent = current; //спуск
                    current = current.GetLeft();
                }
                if (parent != null)
                {
                    if (parent.GetLeft() == node)
                    { parent.SetLeft(current); }
                    else parent.SetRight(current);
                }
                else root = current;
                current.SetLeft(node.GetLeft());
                if (currParent != node)
                {
                    currParent.SetLeft(current.GetRight());
                    current.SetRight(node.GetRight());
                }
            }

            node.SetLeft(null);
            node.SetRight(null);
            return node;
        }

        private void _PreOrderTraversal(Node node)
        {
            if (node == null) return;
            Console.WriteLine(node);
            _PreOrderTraversal(node.GetLeft());
            _PreOrderTraversal(node.GetRight());
        }
        public void PreOrderTraversal()
        { _PreOrderTraversal(root); }

        private void _InOrderTraversal(Node node)
        {
            if (node == null) return;
            _InOrderTraversal(node.GetLeft());
            Console.WriteLine(node);
            _InOrderTraversal(node.GetRight());
        }
        public void InOrderTraversal()
        { _InOrderTraversal(root); }

        private void _PostOrderTraversal(Node node)
        {
            if (node == null) return;
            _PostOrderTraversal(node.GetLeft());
            _PostOrderTraversal(node.GetRight());
            Console.WriteLine(node);
        }
        public void PostOrderTraversal()
        { _PostOrderTraversal(root); }
    }
}
