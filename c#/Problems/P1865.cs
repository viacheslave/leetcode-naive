using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/finding-pairs-with-a-certain-sum/
  ///    Submission: https://leetcode.com/submissions/detail/493928401/
  /// </summary>
  internal class P1865
  {
    public class FindSumPairs
    {
      private readonly int[] _nums1;
      private readonly int[] _nums2;
      private readonly Dictionary<int, int> _map;

      public FindSumPairs(int[] nums1, int[] nums2)
      {
        _nums1 = nums1;
        _nums2 = nums2;

        _map = _nums2.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
      }

      public void Add(int index, int val)
      {
        _map[_nums2[index]]--;

        if (_map.ContainsKey(_nums2[index] + val))
          _map[_nums2[index] + val]++;
        else
          _map[_nums2[index] + val] = 1;

        _nums2[index] += val;
      }

      public int Count(int tot)
      {
        var ans = 0;
        foreach (var n in _nums1)
        {
          var target = tot - n;
          if (_map.ContainsKey(target))
            ans += _map[target];
        }

        return ans;
      }
    }

    /**
     * Your FindSumPairs object will be instantiated and called as such:
     * FindSumPairs obj = new FindSumPairs(nums1, nums2);
     * obj.Add(index,val);
     * int param_2 = obj.Count(tot);
     */
  }
}
