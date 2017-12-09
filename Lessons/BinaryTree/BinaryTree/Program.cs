using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Test1()
        {
            BinaryTree tree = new BinaryTree();
            Node node = new Node(0);
            tree.Add(node);
            tree.Add(new Node(3));
            tree.Add(new Node(2));
            tree.Remove(0);
            tree.Add(new Node(7));
            tree.Add(new Node(9));
            //Console.WriteLine(tree.Find(0) != null);
            //Console.WriteLine(tree.Find(2) != null);
            //Console.WriteLine(tree.Find(7) != null);
            //Console.WriteLine(tree.Find(3) != null);
            //Console.WriteLine(tree.Find(8) != null);
            tree.PreOrderTraversal();
            Console.WriteLine();
            tree.InOrderTraversal();
            Console.WriteLine();
            tree.PostOrderTraversal();
        }
        static void Test2()
        {
            BinaryTree tree = new BinaryTree();
            Node node = new Node(6);
            tree.Add(node);
            tree.Add(new Node(2));
            tree.Add(new Node(8));
            tree.Add(new Node(1));
            tree.Add(new Node(4));
            tree.Add(new Node(7));
            tree.Add(new Node(9));
            tree.Add(new Node(3));
            tree.Add(new Node(5));
            tree.Remove(2);
            Console.WriteLine(tree.Find(2) != null);
            Console.WriteLine(tree.Find(8) != null);
            Console.WriteLine(tree.Find(1) != null);
            Console.WriteLine(tree.Find(4) != null);
            Console.WriteLine(tree.Find(7) != null);
            Console.WriteLine(tree.Find(9) != null);
            Console.WriteLine(tree.Find(3) != null);
            Console.WriteLine(tree.Find(5) != null);
            tree.PreOrderTraversal();
            Console.WriteLine();
            tree.InOrderTraversal();
            Console.WriteLine();
            tree.PostOrderTraversal();
        }
        static void Main(string[] args)
        {
            Test2();
        }
    }
}
