using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/
  ///    Submission: https://leetcode.com/submissions/detail/321784239/
  /// </summary>
  internal class P1404
  {
    public class Solution
    {
      public int NumSteps(string s)
      {
        var arr = s.ToCharArray().ToList();

        var ans = 0;

        while (true)
        {
          if (arr.Count == 1 && arr[0] == '1')
            break;

          if (arr[arr.Count - 1] == '0')
          {
            if (arr.Count > 1)
              arr.RemoveAt(arr.Count - 1);
          }
          else
          {
            arr = Inc(arr);
          }

          ans++;
        }

        return ans;
      }

      private List<char> Inc(List<char> arr)
      {
        var carry = 1;
        for (int i = arr.Count - 1; i >= 0; i--)
        {
          if (carry == 0)
            break;

          var result = carry + int.Parse(arr[i].ToString());
          if (result == 1)
          {
            arr[i] = '1';
            carry = 0;
          }

          if (result == 2)
          {
            arr[i] = '0';
            carry = 1;
          }

          if (result == 3)
          {
            arr[i] = '1';
            carry = 1;
          }
        }

        if (carry == 0)
          return arr;

        arr.Insert(0, '1');
        return arr;
      }
    }
  }
}
