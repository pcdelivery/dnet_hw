﻿using System;

namespace InsertionSortApp
{
    public static class Program
    {
        /// <summary>
        /// Sort array
        /// </summary>
        /// <param name="array"> Unsorted array to sort </param>
        /// <returns>
        /// Returns array sorted in ascending
        /// </returns>
        private static int[] InsertionSort(int[] array)
        {
            for (var index = 1; index < array.Length; index++)
            {
                var key = array[index];
                var indexOfSorted = index;
                while (indexOfSorted > 0 && array[indexOfSorted - 1] > key)
                {
                    Swap(ref array[indexOfSorted - 1], ref array[indexOfSorted]);
                    indexOfSorted--;
                }

                array[indexOfSorted] = key;
            }
            return array;
        }

        /// <summary>
        /// Method to swap two arguments
        /// </summary>
        /// <remarks>
        /// Linked arguments required
        /// </remarks>
        /// <param name="valueA"> First value to swap </param>
        /// <param name="valueB"> Second value to swap </param>
        private static void Swap(ref int valueA, ref int valueB)
        {
            var temp = valueA;
            valueA = valueB;
            valueB = temp;
        }

        /// <summary>
        /// Program's Main
        /// </summary>
        /// <param name="args"> Terminal args </param>
        public static void Main(string[] args)
        {
            Console.Write("Please, enter the values: ");
            var values = Console.ReadLine()?.Split(new[] { " ", "," },
                                                            StringSplitOptions.RemoveEmptyEntries);
            var array = new int[values.Length];
            for (var index = 0; index < values.Length; index++)
                array[index] = Convert.ToInt32(values[index]);

            Console.WriteLine("Sorted by insertions: {0}", string.Join(" ", InsertionSort(array)));
        }
    }
}