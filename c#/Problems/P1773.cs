using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-items-matching-a-rule/
  ///    Submission: https://leetcode.com/submissions/detail/491303979/
  /// </summary>
  internal class P1773
  {
    public class Solution
    {
      public int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue)
      {
        return
          items.Count(item =>
            (ruleKey == "type" && item[0] == ruleValue) ||
            (ruleKey == "color" && item[1] == ruleValue) ||
            (ruleKey == "name" && item[2] == ruleValue));
      }
    }
  }
}
