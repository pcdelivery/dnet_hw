﻿using System;

namespace BinaryTreeApp
{
    public class Node
    {
        public int Value;
        public Node Left;
        public Node Right;
    }

    public class BinaryTree
    {
        private Node _root;

        public BinaryTree()
        {
            _root = null;
        }

        public void InsertNode(int key)
        {
            if (_root != null)
                InsertNode(key, _root);
            else
                _root = new Node
                {
                    Value = key,
                    Left = null,
                    Right = null
                };
        }

        private void InsertNode(int key, Node leaf)
        {
            if (leaf == null)
                throw new ArgumentNullException(nameof(leaf));

            while (true)
            {
                if (key < leaf.Value)
                {
                    if (leaf.Left != null)
                    {
                        leaf = leaf.Left;
                        continue;
                    }

                    leaf.Left = new Node
                    {
                        Value = key,
                        Left = null,
                        Right = null
                    };
                }
                else if (key >= leaf.Value)
                {
                    if (leaf.Right != null)
                    {
                        leaf = leaf.Right;
                        continue;
                    }

                    leaf.Right = new Node
                    {
                        Value = key,
                        Right = null,
                        Left = null
                    };
                }

                break;
            }
        }

        public Node SearchNode(int key)
        {
            return SearchNode(key, _root);
        }

        private static Node SearchNode(int key, Node leaf)
        {
            while (true)
            {
                if (leaf != null)
                {
                    if (key == leaf.Value)
                        return leaf;

                    leaf = key < leaf.Value ? leaf.Left : leaf.Right;
                }
                else
                {
                    return null;
                }
            }
        }

        public void RemoveNode(int key)
        {
            RemoveNode(_root, SearchNode(key, _root));
        }

        private static Node RemoveNode(Node root, Node removableNode)
        {
            if (root == null)
                return null;

            if (removableNode == null)
            {
                Console.WriteLine("Not found!");
                return null;
            }

            if (removableNode.Value < root.Value)
                root.Left = RemoveNode(root.Left, removableNode);

            if (removableNode.Value > root.Value)
                root.Right = RemoveNode(root.Right, removableNode);

            if (removableNode.Value != root.Value)
                return root;

            switch (root.Left)
            {
                case null when root.Right == null:
                    {
                        return null;
                    }
                case null:
                    {
                        root = root.Right;
                        break;
                    }
                default:
                    {
                        if (root.Right == null)
                        {
                            root = root.Left;
                        }
                        else
                        {
                            var minimalNode = GetMinimalNode(root.Right);
                            root.Value = minimalNode.Value;
                            root.Right = RemoveNode(root.Right, minimalNode);
                        }

                        break;
                    }
            }

            return root;
        }

        private static Node GetMinimalNode(Node currentNode)
        {
            while (currentNode?.Left != null)
                currentNode = currentNode.Left;

            return currentNode;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var tree = new BinaryTree();

            while (true)
            {
                Console.WriteLine("\t- - - MENU - - -");
                Console.WriteLine("1 - Insert;");
                Console.WriteLine("2 - Remove;");
                Console.WriteLine("3 - Search;");
                Console.WriteLine("0 - Exit.");
                Console.Write(">>> ");

                var data = "";
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.WriteLine("Enter the data to insert:");
                        data = Console.ReadLine();
                        tree.InsertNode(Convert.ToInt32(data));
                        break;
                    case 2:
                        Console.WriteLine("Enter the data to remove:");
                        data = Console.ReadLine();
                        tree.RemoveNode(Convert.ToInt32(data));
                        break;
                    case 3:
                        Console.WriteLine("Enter the data to search in tree:");
                        data = Console.ReadLine();
                        var temp = tree.SearchNode(Convert.ToInt32(data));
                        Console.WriteLine(temp != null ? "Found!" : "Not found!");
                        break;
                    case 0:
                        Console.WriteLine("Terminating...");
                        return;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }
    }
}