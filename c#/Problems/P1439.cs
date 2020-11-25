using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/find-the-kth-smallest-sum-of-a-matrix-with-sorted-rows/
  ///    Submission: https://leetcode.com/submissions/detail/424056166/
  /// </summary>
  internal class P1439
  {
    public class Solution
    {
      public class Item : IComparable<Item>
      {
        public int Sum { get; }
        public List<int> Indicies { get; }

        public string IndexKey { get; }

        public Item(int[][] mat, List<int> indicies)
        {
          var sum = 0;
          for (var i = 0; i < mat.Length; i++)
            sum += mat[i][indicies[i]];

          Sum = sum;
          Indicies = indicies;

          IndexKey = string.Join("-", indicies);
        }

        public override bool Equals(object obj)
        {
          var other = (Item)obj;
          return other.Sum == Sum && other.IndexKey == IndexKey;
        }

        public override int GetHashCode() => HashCode.Combine(Sum, IndexKey);

        public int CompareTo(Item other)
        {
          if (Sum < other.Sum)
            return -1;

          if (Sum > other.Sum)
            return 1;

          return IndexKey.CompareTo(other.IndexKey);
        }
      }

      public int KthSmallest(int[][] mat, int k)
      {
        var sd = new SortedList<Item, Item>();

        var first = new Item(mat, Enumerable.Repeat(0, mat.Length).ToList());
        sd.TryAdd(first, first);

        var index = 0;
        Item item = null;

        while (index != k)
        {
          index++;
          item = sd.Keys[0];

          sd.RemoveAt(0);

          for (var i = 0; i < mat.Length; i++)
          {
            var ind = item.Indicies.ToList();

            if (ind[i] + 1 < mat[0].Length)
            {
              ind[i]++;

              var it = new Item(mat, ind);
              sd.TryAdd(it, it);
            }
          }
        }

        return item.Sum;
      }
    }
  }
}
