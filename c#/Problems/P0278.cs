using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/first-bad-version/
  ///    Submission: https://leetcode.com/submissions/detail/226713902/
  /// </summary>
  internal class P0278
  {
    public class Solution
    {
      public int FirstBadVersion(int n)
      {
        int start = 1;
        int end = n;

        while (start != end)
        {
          if (start + 1 == end)
          {
            if (IsBadVersion(start))
              return start;
            else
              return end;
          }

          var middle = start + (end - start) / 2; ;
          var bad = IsBadVersion(middle);

          if (bad)
          {
            end = middle;
          }
          else
          {
            start = middle;
          }
        }


        return start;
      }

      private bool IsBadVersion(int middle)
      {
        throw new NotImplementedException();
      }
    }
  }
}
