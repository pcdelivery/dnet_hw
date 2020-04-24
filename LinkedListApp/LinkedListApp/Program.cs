using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListApp
{
    /// <summary>
    /// Object of page of list
    /// </summary>
    /// <remarks>
    /// Each page has r-link to the next one
    /// </remarks>
    public class Node<T>
    {
        public T Data { get; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
        }
    }

    /// <summary>
    /// Singly linked list object
    /// </summary>
    /// <remarks>
    /// Implements class IEnumerable.
    /// Private variables:
    /// * fst - First page of the list (head)
    /// * lst - Last page of the list
    /// * n - Contains amount of pages in list
    /// Methods:
    /// * Add(page) - Add as last page of the list
    /// * AddFirst(page) - Add as first page of the list
    /// * Remove(page) - Remove page
    /// * Reverse() - Reverse list
    /// * Clear() - Clear list
    /// * IsEmpty() - Return "true" if list has 0 pages
    /// * Count() - Return n variable
    /// </remarks>
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> fst;
        private Node<T> lst;
        private int n;

        /// <summary>
        /// Add as last page of the list
        /// </summary>
        /// <param name="data"> Page to add </param>
        public void Add(T data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var node = new Node<T>(data);
            if (fst == null)
                fst = node;
            else
                lst.Next = node;

            lst = node;
            n++;
        }

        /// <summary>
        /// Add as first page of the list
        /// </summary>
        /// <param name="data"> Page to add </param>
        public void AddFirst(T data)
        {
            var node = new Node<T>(data);
            node.Next = fst;
            fst = node;
            if (IsEmpty)
                lst = fst;

            n++;
        }

        /// <summary>
        /// Remove page
        /// </summary>
        /// <remarks>
        /// Removes first detected page
        /// </remarks>
        /// <param name="data"> Page to remove from list </param>
        public bool Remove(T data)
        {
            Node<T> current = fst;
            Node<T> previous = null;
            while (current != null)
            {
                if (data != null && current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            lst = previous;
                    }
                    else
                    {
                        fst = fst.Next;
                        if (fst == null)
                            lst = null;
                    }

                    n--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Reverse this list
        /// </summary>
        public void Reverse()
        {
            Node<T> current = fst;
            Node<T> previous = null;
            Node<T> next;

            while (current != null)
            {
                next = current.Next;
                if (previous != null)
                {
                    current.Next = previous;
                }
                else
                {
                    current.Next = lst.Next;
                    lst = current;
                }

                previous = current;
                current = next;
            }

            fst = previous;
        }

        /// <summary>
        /// Clear this list
        /// </summary>
        public void Clear()
        {
            fst = null;
            lst = null;
            n = 0;
        }

        /// <summary>
        /// To check if list is empty
        /// </summary>
        public bool IsEmpty => n == 0;
        /// <summary>
        /// To check number of pages in list
        /// </summary>
        public int Count => n;

        /// <summary>
        /// Return IEnumerator which enumerates pages in list
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var current = fst;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Return IEnumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable).GetEnumerator();
        }
    }

    public static class Program
    {
        /// <summary>
        /// Program's Main foo
        /// </summary>
        /// <param name="args"> Terminal args </param>
        public static void Main(string[] args)
        {
            var listToBuy = new LinkedList<string>();

            // Fill the list
            listToBuy.Add("Butter");
            listToBuy.Add("Milk");
            listToBuy.Add("Apricot");
            listToBuy.Add("Cigarettes");
            listToBuy.Add("Baby");

            // Display list content
            Console.WriteLine("List: ");
            foreach (var item in listToBuy)
                Console.Write(item + " | ");
            Console.WriteLine("\nCOUNT: " + listToBuy.Count);

            // Remove something and display
            listToBuy.Remove("Baby");
            Console.WriteLine("\nList (without \"Baby\"): ");
            foreach (var item in listToBuy)
                Console.Write(item + " | ");
            Console.WriteLine("\nCOUNT: " + listToBuy.Count);

            // Add to head of list
            listToBuy.AddFirst("Potato Chips");
            Console.WriteLine("\nList (with \"Potato Chips\"): ");
            foreach (var item in listToBuy)
                Console.Write(item + " | ");
            Console.WriteLine("\nCOUNT: " + listToBuy.Count);

            // Reverse and display
            listToBuy.Reverse();
            Console.WriteLine("\nReversed list: ");
            foreach (var item in listToBuy)
                Console.Write(item + " | ");
            Console.WriteLine("\nCOUNT: " + listToBuy.Count);

            // Clear and display
            listToBuy.Clear();
            Console.WriteLine("\nEmpty list: ");
            foreach (var item in listToBuy)
                Console.Write(item + " | ");
            Console.WriteLine("\nCOUNT: " + listToBuy.Count);
        }
    }
}
