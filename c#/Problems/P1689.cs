using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers/
  ///    Submission: https://leetcode.com/submissions/detail/430189501/
  /// </summary>
  internal class P1689
  {
    public class Solution {
      public int MinPartitions(string n) {
        return n.Select(_ => int.Parse(_.ToString())).Max(); 
      }
    }
  }
}
