namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/decode-xored-array/
  ///    Submission: https://leetcode.com/submissions/detail/441134002/
  /// </summary>
  internal class P1720
  {
    public class Solution
    {
      public int[] Decode(int[] encoded, int first)
      {
        var ans = new int[encoded.Length + 1];
        ans[0] = first;

        for (var i = 1; i < encoded.Length + 1; i++)
          ans[i] = ans[i - 1] ^ encoded[i - 1];

        return ans;
      }
    }
  }
}
