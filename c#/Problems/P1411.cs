using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/number-of-ways-to-paint-n-3-grid/
	///		Submission: https://leetcode.com/submissions/detail/323801215/
	/// </summary>
	internal class P1411
	{
    public int NumOfWays(int n)
    {
      var mem = new Dictionary<(int, int, int), List<(int, int, int)>>
      {
        // 5
        [(0, 1, 0)] = new List<(int, int, int)>
      {
        (1,0,1),
        (1,0,2),
        (2,0,1),
        (2,0,2),
        (1,2,1),
      },

        [(0, 2, 0)] = new List<(int, int, int)>
      {
        (1,0,1),
        (1,0,2),
        (2,0,1),
        (2,0,2),
        (2,1,2),
      },

        [(1, 0, 1)] = new List<(int, int, int)>
      {
        (2,1,2),
        (2,1,0),
        (0,1,2),
        (0,1,0),
        (0,2,0),
      },

        [(1, 2, 1)] = new List<(int, int, int)>
      {
        (2,1,2),
        (2,1,0),
        (0,1,2),
        (0,1,0),
        (2,1,2),
      },

        [(2, 0, 2)] = new List<(int, int, int)>
      {
        (0,2,0),
        (0,2,1),
        (1,2,0),
        (1,2,1),
        (0,1,0),
      },

        [(2, 1, 2)] = new List<(int, int, int)>
      {
        (0,2,0),
        (0,2,1),
        (1,2,0),
        (1,2,1),
        (1,0,1),
      },

        // 4
        [(0, 1, 2)] = new List<(int, int, int)>
      {
        (1,0,1),
        (1,2,0),
        (1,2,1),
        (2,0,1),
      },

        [(0, 2, 1)] = new List<(int, int, int)>
      {
        (2,0,2),
        (2,1,0),
        (2,1,2),
        (1,0,2),
      },

        [(1, 0, 2)] = new List<(int, int, int)>
      {
        (0,1,0),
        (0,2,1),
        (0,2,0),
        (2,1,0),
      },

        [(1, 2, 0)] = new List<(int, int, int)>
      {
        (2,1,2),
        (2,0,1),
        (2,0,2),
        (0,1,2),
      },

        [(2, 1, 0)] = new List<(int, int, int)>
      {
        (1,2,1),
        (1,0,2),
        (1,0,1),
        (0,2,1),
      },

        [(2, 0, 1)] = new List<(int, int, int)>
      {
        (0,2,0),
        (0,1,2),
        (0,1,0),
        (1,2,0),
      },
      };

      var map = new Dictionary<(int, (int, int, int)), int>();
      var ans = 0;
      var mod = 1_000_000_007;

      foreach (var key in mem.Keys)
        map[(1, key)] = 1;

      for (var row = 2; row <= n; row++)
      {
        foreach (var key in mem.Keys)
        {
          var a = 0;
          foreach (var k in mem[key])
          {
            a = (a % mod) + (map[(row - 1, k)] % mod);
            a %= mod;
          }

          map[(row, key)] = a;
        }
      }

      foreach (var key in mem.Keys)
      {
        ans = (ans % mod) + (map[(n, key)] % mod);
        ans %= mod;
      }

      return ans;
    }
  }
}
