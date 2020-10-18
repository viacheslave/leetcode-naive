using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/split-array-into-fibonacci-sequence/
  ///    Submission: https://leetcode.com/submissions/detail/231539551/
  /// </summary>
  internal class P0842
  {
    public class Solution
    {
      public IList<int> SplitIntoFibonacci(string S)
      {
        for (var l1 = 1; l1 <= 10; l1++)
        {
          for (var l2 = 1; l2 <= 10; l2++)
          {
            var res = new List<int>();

            if (l1 > S.Length || l1 + l2 > S.Length)
              continue;

            var n1 = S.Substring(0, l1);
            var n2 = S.Substring(l1, l2);

            if (n1 != "0" && n1.StartsWith("0"))
              continue;

            if (n2 != "0" && n2.StartsWith("0"))
              continue;

            int r0, r1;
            if (!int.TryParse(n1, out r0) || !int.TryParse(n2, out r1))
              continue;

            res.Add(r0);
            res.Add(r1);

            var cand = res[0] + res[1];
            var index = l1 + l2;

            while (index < S.Length)
            {
              var sumStr = cand.ToString();

              if (index + sumStr.Length > S.Length)
                break;

              var sPart = S.Substring(index, sumStr.Length);

              if (sumStr == sPart)
              {
                index += sumStr.Length;

                var newItem = cand + res.Last();
                res.Add(cand);

                cand = newItem;

                continue;
              }

              break;
            }

            if (res.Count > 2 && index >= S.Length)
              return res;
          }
        }

        return new List<int>();
      }
    }
  }
}
