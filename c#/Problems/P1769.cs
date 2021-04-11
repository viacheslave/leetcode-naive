namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box/
  ///    Submission: https://leetcode.com/submissions/detail/479308895/
  /// </summary>
  internal class P1769
  {
    public class Solution
    {
      public int[] MinOperations(string boxes)
      {
        var countleft = new int[boxes.Length];
        var countright = new int[boxes.Length];

        var onleft = new int[boxes.Length];
        var onright = new int[boxes.Length];

        countleft[0] = boxes[0] == '1' ? 1 : 0;
        countright[boxes.Length - 1] = boxes[^1] == '1' ? 1 : 0;

        for (var i = 1; i < boxes.Length; i++)
        {
          onleft[i] = onleft[i - 1] + countleft[i - 1];
          countleft[i] = countleft[i - 1] + (boxes[i] == '1' ? 1 : 0);
        }

        for (var i = boxes.Length - 2; i >= 0; i--)
        {
          onright[i] = onright[i + 1] + countright[i + 1];
          countright[i] = countright[i + 1] + (boxes[i] == '1' ? 1 : 0);
        }

        var ans = new int[boxes.Length];

        for (var i = 0; i < boxes.Length; i++)
          ans[i] = onright[i] + onleft[i];

        return ans;
      }
    }
  }
}
