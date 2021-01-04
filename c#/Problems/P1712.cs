namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/ways-to-split-array-into-three-subarrays/
  ///    Submission: https://leetcode.com/submissions/detail/438016147/
  /// </summary>
  internal class P1712
  {
    public class Solution
    {
      public int WaysToSplit(int[] nums)
      {
        var mod = (int)1e9 + 7;

        var prefix = new int[nums.Length + 1];
        for (var i = 0; i < nums.Length; i++)
          prefix[i + 1] = prefix[i] + nums[i];

        var ans = 0;

        // for every left wall position
        // find right wall positions (left and right)
        // using binary search

        for (var l = 0; l < nums.Length - 1; l++)
        {
          var left = prefix[l + 1];
          var right = prefix[nums.Length] - prefix[l + 1];

          if (right >= 2 * left)
          {
            var from = l;
            var to = nums.Length - 1;

            if (to - from == 1)
              continue;

            // get right wall start
            var r1 = BinarySearchStart(prefix, left, from + 1, to);

            // get right wall end
            var r2 = BinarySearchEnd(prefix, left, from + 1, to);

            if (r2 == -1 && r1 == -1)
              continue;

            // right wall start or end can be not found
            if (r2 == -1 || r1 == -1)
            {
              ans++;
              ans %= mod;
              continue;
            }

            ans += (r2 - r1 + 1);
            ans %= mod;
          }
          else
            // limit of left wall
            break;
        }

        return ans;
      }

      private int BinarySearchStart(int[] prefix, int limit, int from, int to)
      {
        if (Fits(prefix, limit, from, to, point: from))
          return from;

        var start = from;
        var end = to;

        while (true)
        {
          if (end - start == 1)
          {
            if (Fits(prefix, limit, from, to, point: start))
              return start;

            if (Fits(prefix, limit, from, to, point: end))
              return end;

            return -1;
          }

          var mid = (start + end) / 2;

          if (Fits(prefix, limit, from, to, point: mid))
          {
            end = mid;
            continue;
          }

          if (!FitsSum(prefix, limit, from, to, point: mid))
            end = mid;
          else
            start = mid;
        }
      }

      private int BinarySearchEnd(int[] prefix, int limit, int from, int to)
      {
        if (Fits(prefix, limit, from, to, point: to))
          return to - 1;

        var start = from;
        var end = to;

        while (true)
        {
          if (end - start == 1)
          {
            if (Fits(prefix, limit, from, to, point: start))
              return start;

            if (Fits(prefix, limit, from, to, point: end))
              return end;

            return -1;
          }

          var mid = (start + end) / 2;

          if (Fits(prefix, limit, from, to, point: mid))
          {
            start = mid;
            continue;
          }

          if (!FitsSum(prefix, limit, from, to, point: mid))
            end = mid;
          else
            start = mid;
        }
      }

      private bool FitsLimit(int[] prefix, int limit, int from, int to, int point)
        => limit <= Sum(prefix, from, point);

      private bool FitsSum(int[] prefix, int limit, int from, int to, int point)
        => Sum(prefix, from, point) <= Sum(prefix, point + 1, to);

      private bool Fits(int[] prefix, int limit, int from, int to, int point) =>
        FitsLimit(prefix, limit, from, to, point) &&
        FitsSum(prefix, limit, from, to, point);

      private int Sum(int[] prefix, int from, int to)
      {
        return prefix[to + 1] - prefix[from];
      }
    }
  }
}
