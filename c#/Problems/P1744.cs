namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/can-you-eat-your-favorite-candy-on-your-favorite-day/
  ///    Submission: https://leetcode.com/submissions/detail/450215843/
  /// </summary>
  internal class P1744
  {
    public class Solution
    {
      public bool[] CanEat(int[] candiesCount, int[][] queries)
      {
        var ans = new bool[queries.Length];

        var prefixSum = new long[candiesCount.Length];
        for (var i = 0; i < candiesCount.Length; i++)
          prefixSum[i] = i == 0 ? candiesCount[0] : candiesCount[i] + prefixSum[i - 1];

        for (var i = 0; i < queries.Length; i++)
        {
          var favoriteType = queries[i][0];
          var favoriteDay = queries[i][1];
          var cap = queries[i][2];

          var maxDay = (favoriteType == 0 ? 0 : prefixSum[favoriteType - 1]) + candiesCount[favoriteType] - 1;
          var minDay = (favoriteType == 0 ? 0 : (prefixSum[favoriteType - 1] / cap));

          ans[i] = favoriteDay >= minDay && favoriteDay <= maxDay;
        }

        return ans;
      }
    }
  }
}
