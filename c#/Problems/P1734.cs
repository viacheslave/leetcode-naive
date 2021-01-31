namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/decode-xored-permutation/
  ///    Submission: https://leetcode.com/submissions/detail/448182581/
  /// </summary>
  internal class P1734
  {
    public class Solution
    {
      public int[] Decode(int[] encoded)
      {
        var xorAll = 0;
        for (var i = 1; i <= encoded.Length + 1; i++)
          xorAll ^= i;

        var ans = new int[encoded.Length + 1];

        var perm0 = xorAll;
        for (var i = 1; i < encoded.Length; i += 2)
          perm0 ^= encoded[i];

        ans[0] = perm0;
        for (var i = 1; i < ans.Length; i++)
          ans[i] = ans[i - 1] ^ encoded[i - 1];

        return ans;
      }
    }
  }
}
