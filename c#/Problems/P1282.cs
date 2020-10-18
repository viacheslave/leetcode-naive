using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/group-the-people-given-the-group-size-they-belong-to/
  ///    Submission: https://leetcode.com/submissions/detail/284802613/
  /// </summary>
  internal class P1282
  {
    public class Solution
    {
      public IList<IList<int>> GroupThePeople(int[] groupSizes)
      {
        var buckets = new Dictionary<int, List<int>>();

        for (int index = 0; index < groupSizes.Length; index++)
        {
          if (!buckets.ContainsKey(groupSizes[index]))
            buckets[groupSizes[index]] = new List<int>();

          buckets[groupSizes[index]].Add(index);
        }

        var ans = new List<IList<int>>();

        foreach (var bucket in buckets)
          ans.AddRange(Split(bucket));

        return ans;
      }

      private IEnumerable<IList<int>> Split(KeyValuePair<int, List<int>> bucket)
      {
        var res = new List<IList<int>>();

        for (int i = 0; i < bucket.Value.Count; i += bucket.Key)
          res.Add(bucket.Value.Skip(i).Take(bucket.Key).ToList());

        return res;
      }
    }
  }
}
