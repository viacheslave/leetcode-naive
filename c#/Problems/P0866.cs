using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/prime-palindrome/
  ///    Submission: https://leetcode.com/submissions/detail/250782802/
  /// </summary>
  internal class P0866
  {
    public class Solution
    {
      public int PrimePalindrome(int N)
      {
        if (N == 1)
          return 2;

        if (N == 4)
          return 5;

        var arr = GetArr(N);
        var next = N;

        if (!IsPalindrome(arr))
        {
          arr = MakePalindrome(arr);
          arr = AdjustLastDigit(arr);
          next = FromArr(arr);
        }

        while (true)
        {
          if (IsPalindrome(arr) && IsPrime(next))
            return next;

          arr = NextPalindrome(arr);
          arr = AdjustLastDigit(arr);
          next = FromArr(arr);
        }
      }

      private int[] AdjustLastDigit(int[] arr)
      {
        if (arr[arr.Length - 1] % 2 == 0)
        {
          arr[arr.Length - 1]++;
          arr[0] = arr[arr.Length - 1];
        }

        if (arr[arr.Length - 1] == 5)
        {
          for (int i = 0; i < arr.Length; i++)
            arr[i] = 0;

          arr[0] = arr[arr.Length - 1] = 7;
        }

        return arr;
      }

      private int[] MakePalindrome(int[] arr)
      {
        var leftPart = arr.Take(arr.Length / 2).ToArray();
        var rightPart = arr.Reverse().Take(arr.Length / 2).Reverse().ToArray();

        if (FromArr(leftPart.Reverse().ToArray()) > FromArr(rightPart))
        {
          var a = new List<int>();
          a.AddRange(leftPart);

          if (arr.Length % 2 != 0)
            a.Add(arr[arr.Length / 2]);

          a.AddRange(leftPart.Reverse());
          return a.ToArray();
        }

        return NextPalindrome(arr);
      }

      private int[] NextPalindrome(int[] arr)
      {
        var greedyLeft = arr.Take(arr.Length / 2 == 0 ? arr.Length : (arr.Length / 2 + 1)).ToArray();
        var greedyLeftNumber = FromArr(greedyLeft);

        var incNumber = greedyLeftNumber + 1;
        if (greedyLeftNumber.ToString().Length == incNumber.ToString().Length)
        {
          var inc = GetArr(incNumber);
          for (int i = 0; i < inc.Length; i++)
            arr[i] = arr[arr.Length - i - 1] = inc[i];

          return arr;
        }
        else
        {
          var newarr = new int[arr.Length + 1];
          newarr[0] = newarr[newarr.Length - 1] = 1;
          return newarr;
        }
      }

      private bool IsPrime(int next)
      {
        for (int i = 2; i <= Math.Sqrt(next); i++)
        {
          if (next % i == 0)
            return false;
        }

        return true;
      }

      private bool IsPalindrome(int[] arr)
      {
        var i = 0;
        var j = arr.Length - 1;
        while (i <= j)
        {
          if (arr[i] != arr[j])
            return false;

          i++; j--;
        }

        return true;
      }

      private int FromArr(int[] arr)
      {
        return int.Parse(string.Concat(arr.Select(_ => _.ToString())));
      }

      private int[] GetArr(int n)
      {
        return n.ToString().Select(_ => int.Parse(_.ToString())).ToArray();
      }
    }
  }
}
