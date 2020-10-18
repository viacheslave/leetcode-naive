using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/intersection-of-two-arrays
  ///    Submission: https://leetcode.com/submissions/detail/229748750/
  /// </summary>
  internal class P0349
  {
    public class Solution
    {
      public int[] Intersection(int[] nums1, int[] nums2)
      {
        var hs = new HashSet<int>(nums1);
        var hs2 = new HashSet<int>(nums2);

        var inte = new HashSet<int>();

        foreach (var a in hs2)
          if (hs.Contains(a))
            inte.Add(a);
        //else hs.Add(a);

        return inte.ToArray();
      }
    }
  }
}
