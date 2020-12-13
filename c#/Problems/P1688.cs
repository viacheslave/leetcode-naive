namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-of-matches-in-tournament/
  ///    Submission: https://leetcode.com/submissions/detail/430190564/
  /// </summary>
  internal class P1688
  {
    public class Solution
    {
      public int NumberOfMatches(int n)
      {
        var ans = 0;

        while (n > 1)
        {
          ans += n % 2 == 0 ? n / 2 : (n / 2) + 1;
          n /= 2;
        }

        return ans;
      }
    }
  }
}
