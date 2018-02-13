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
            tree.Add(new Node(7));
            tree.Add(new Node(3));
            tree.Add(new Node(2));
            tree.Add(new Node(9));
            //Console.WriteLine(tree.Find(0) != null);
            //Console.WriteLine(tree.Find(2) != null);
            //Console.WriteLine(tree.Find(7) != null);
            //Console.WriteLine(tree.Find(3) != null);
            //Console.WriteLine(tree.Find(9) != null);
            tree.PreOrderTraversal();
            Console.WriteLine();
            tree.InOrderTraversal();
            Console.WriteLine();
            tree.PostOrderTraversal();
        }
        static void Test2()
        {
            BinaryTree tree = new BinaryTree();
            Node node = new Node(1);
            tree.Add(node);
            tree.Add(new Node(2));
            tree.Add(new Node(7));
            tree.Add(new Node(3));
            tree.Add(new Node(4));
            tree.Add(new Node(5));
            tree.Add(new Node(6));
            tree.Add(new Node(8));
            tree.Add(new Node(9));
            //tree.Remove(2);
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
            BinaryTree tree = new BinaryTree();

            Console.WriteLine("Enter \"add <value>\" to add node;");
            Console.WriteLine("Enter \"find <value>\" to find node;");
            Console.WriteLine("Enter \"remove <value>\" to remove node;");
            Console.WriteLine("Enter \"pre\" to PreOrder traversal;");
            Console.WriteLine("Enter \"in\" to InOrder traversal;");
            Console.WriteLine("Enter \"post\" to PostOrder traversal;");
            Console.WriteLine("Enter \"exit\" to terminate a programm.");
            do
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                string[] data = command.Split(new char[] {' '},
                    StringSplitOptions.RemoveEmptyEntries);
                switch (data[0])
                {
                    case "add":
                    case "find":
                    case "remove":
                        if (data.Length != 2)
                        { Console.WriteLine("Invalid parameters count"); break; }
                        int value; bool isParse = int.TryParse(data[1], out value);
                        if (!isParse)
                        { Console.WriteLine("Not valid number"); break; }
                        if (data[0] == "add") tree.Add(new Node(value));
                        else if (data[0] == "find")
                        {
                            Node node = tree.Find(value);
                            if (node != null)
                            { Console.WriteLine("Found {0} node", node.GetKey()); }
                            else  Console.WriteLine("Node is not found"); 
                        }
                        else
                        {
                            Node node = tree.Remove(value);
                            if (node != null)
                            { Console.WriteLine("Removed {0} node", node.GetKey()); }
                            else Console.WriteLine("Node is not found"); 
                        }
                        break;
                    case "pre": tree.PreOrderTraversal(); break;
                    case "in": tree.InOrderTraversal(); break;
                    case "post": tree.PostOrderTraversal(); break;
                    case "exit": return;
                    default: Console.WriteLine("Command is not recognised"); break;
                }
            } while (true);
        }
    }
}
