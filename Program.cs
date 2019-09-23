using System.Linq;
using System;
using System.Collections.Generic;

namespace QueueMergeSort
{
    class Program
    {
        static Random gen = new Random();
        static List<int> GetListOfNumbers(int size, int min = 0, int max = 100)
        {
            var nums = new List<int>();

            for (int i = 0; i < size; i++)
            {
                nums.Add(gen.Next(min, max));
            }

            return nums;
        }

        static Queue<int> GetSetWithSmallestVal(Queue<int>[] sets)
        {
            Queue<int> min = sets[0];

            // handle min being empty
            for (int i = 0; i < sets.Length; i++)
            {
                if (sets[i].Count > 0)
                {
                    min = sets[i];
                }
            }

            foreach (var set in sets)
            {
                if (set.Count > 0 && set.Peek() < min.Peek())
                {
                    min = set;
                }
            }

            return min;
        }

        static bool AreAllSetsEmpty(Queue<int>[] sets)
        {
            foreach (var set in sets)
            {
                if (set.Count > 0)
                {
                    return false;
                }
            }

            return true;

        }
        static List<int> KWayMerge(params Queue<int>[] sets)
        {
            List<int> mergedList = new List<int>();

            while (!AreAllSetsEmpty(sets))
            {
                var set = GetSetWithSmallestVal(sets);

                mergedList.Add(set.Dequeue());
            }

            return mergedList;
        }
        static void Main(string[] args)
        {
            int size = 10;
            Queue<int>[] sets = new Queue<int>[size];

            for (int i = 0; i < sets.Length; i++)
            {
                var nums = GetListOfNumbers(size: gen.Next(5, 10));

                nums.Sort();

                sets[i] = new Queue<int>(nums);
            }

            // sum of all the size of the sets
            System.Console.WriteLine(sets.Sum(x => x.Count));

            var merged = KWayMerge(sets);

            // sum of the final merged set

            System.Console.WriteLine(merged.Count);

        }
    }
}
