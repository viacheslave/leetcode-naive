using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/count-vowels-permutation/
  ///    Submission: https://leetcode.com/submissions/detail/406188844/
  /// </summary>
  internal class P1220
  {
    public class Solution
    {
      private int m = 1_000_000_007;

      private int[] chi = new int[255];

      public int CountVowelPermutation(int n)
      {
        /*
        Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')
        Each vowel 'a' may only be followed by an 'e'.                        a,i: e
        Each vowel 'e' may only be followed by an 'a' or an 'i'.                e: a,i
        Each vowel 'i' may not be followed by another 'i'.                a,e,o,u: i
        Each vowel 'o' may only be followed by an 'i' or a 'u'.                 o: i, u
        Each vowel 'u' may only be followed by an 'a'.                          u: a


        e <-- a
        i <-- a
        u <-- a

        a <-- e
        i <-- e

        e <-- i
        o <-- i

        i <-- o

        i <-- u
        o <-- u

        */

        chi['a'] = 0;
        chi['e'] = 1;
        chi['i'] = 2;
        chi['o'] = 3;
        chi['u'] = 4;

        var dp = new int[n + 1, 5];
        for (var i = 0; i < n + 1; i++)
          for (var j = 0; j < 5; j++)
            dp[i, j] = -1;

        var ans = 0;
        foreach (var ch in new char[] { 'a', 'e', 'i', 'o', 'u' })
        {
          ans += GetDP(dp, n, ch);
          ans %= m;
        }

        return ans;
      }

      private int GetDP(int[,] dp, int n, char ch)
      {
        if (dp[n, chi[ch]] != -1)
          return dp[n, chi[ch]];

        if (n == 1)
          return 1;

        var ans = 0;

        if (ch == 'a')
        {
          ans += GetDP(dp, n - 1, 'e'); ans %= m;
          ans += GetDP(dp, n - 1, 'i'); ans %= m;
          ans += GetDP(dp, n - 1, 'u'); ans %= m;
        }
        else if (ch == 'e')
        {
          ans += GetDP(dp, n - 1, 'a'); ans %= m;
          ans += GetDP(dp, n - 1, 'i'); ans %= m;
        }
        else if (ch == 'i')
        {
          ans += GetDP(dp, n - 1, 'e'); ans %= m;
          ans += GetDP(dp, n - 1, 'o'); ans %= m;
        }
        else if (ch == 'o')
        {
          ans += GetDP(dp, n - 1, 'i'); ans %= m;
        }
        else
        {
          ans += GetDP(dp, n - 1, 'i'); ans %= m;
          ans += GetDP(dp, n - 1, 'o'); ans %= m;
        }

        dp[n, chi[ch]] = ans;
        return ans;
      }
    }
  }
}
