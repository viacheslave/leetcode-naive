namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/corporate-flight-bookings/
  ///    Submission: https://leetcode.com/submissions/detail/437157530/
  /// </summary>
  internal class P1109
  {
    public class Solution
    {
      public int[] CorpFlightBookings(int[][] bookings, int n)
      {
        var diffs = new int[n + 1];

        // for each flight type
        // save the number of seats changed
        // bookings[i][0] - seats go up
        // bookings[i][1] - seats go down
        for (var i = 0; i < bookings.Length; i++)
        {
          diffs[bookings[i][0] - 1] += bookings[i][2];
          diffs[bookings[i][1]] -= bookings[i][2];
        }

        var current = 0;
        var ans = new int[n];

        // iterate over number of flights
        // track current number of seats
        for (var i = 0; i < n; i++)
        {
          current += diffs[i];
          ans[i] = current;
        }

        return ans;
      }
    }
  }
}
