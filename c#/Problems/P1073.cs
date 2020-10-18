using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/adding-two-negabinary-numbers/
  ///    Submission: https://leetcode.com/submissions/detail/245138763/
  /// </summary>
  internal class P1073
  {
    public class Solution
    {
      public int[] AddNegabinary(int[] arr1, int[] arr2)
      {
        var length = Math.Max(arr1.Length, arr2.Length);

        var list = new int[Math.Max(arr1.Length, arr2.Length)];

        for (int i = 0; i < length; i++)
        {
          var d1 = i < arr1.Length ? arr1[arr1.Length - 1 - i] : 0;
          var d2 = i < arr2.Length ? arr2[arr2.Length - 1 - i] : 0;

          list[length - i - 1] = d1 + d2;
        }

        var map = new SortedDictionary<int, int>();

        for (int i = 0; i < length; i++)
        {
          var value = list[length - 1 - i] + Get(map, i);
          Fix(map, i, value);
        }

        var keyMax = map.Keys.Max();
        for (int i = list.Length; i <= keyMax; i++)
        {
          Fix(map, i, map[i]);
        }

        var ans = map.Select(_ => _.Value).Reverse()
          .SkipWhile(_ => _ == 0).ToArray();

        return ans.Length == 0 ? new int[] { 0 } : ans;
      }

      private void Fix(SortedDictionary<int, int> map, int i, int value)
      {
        var carry = value / 2;

        if (i % 2 == 0)
        {
          value %= 2;

          Set(map, i, value);
          Inc(map, i + 1, -carry);
        }
        else
        {
          value %= 2;

          if (carry > 0)
          {
            Inc(map, i + 1, carry);
            Inc(map, i + 2, carry);
          }
          else
          {
            Inc(map, i + 1, -carry);
          }

          if (value >= 0)
          {
            Set(map, i, value);
          }
          else if (value == -1)
          {
            Set(map, i, 1);
            Inc(map, i + 1, 1);
          }
        }
      }

      private int Get(SortedDictionary<int, int> map, int i)
      {
        if (map.ContainsKey(i)) return map[i];
        return 0;
      }

      private void Inc(SortedDictionary<int, int> map, int i, int carry)
      {
        if (!map.ContainsKey(i))
          map[i] = 0;

        map[i] += carry;
      }

      private void Set(SortedDictionary<int, int> map, int i, int value)
      {
        if (!map.ContainsKey(i))
          map[i] = 0;

        map[i] = value;
      }
    }
  }
}
