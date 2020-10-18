using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/defanging-an-ip-address/
  ///    Submission: https://leetcode.com/submissions/detail/241439940/
  /// </summary>
  internal class P1108
  {
    public class Solution
    {
      public string DefangIPaddr(string address)
      {
        return address.Replace(".", "[.]");
      }
    }
	}
}
