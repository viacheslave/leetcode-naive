using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Transactions;
using LeetCode.Naive;

namespace LeetCode.Naive
{
  class Program
  {
    static void Main(string[] args)
    {
      var root = new TreeNode(2);
      root.left = new TreeNode(1);
      root.right = new TreeNode(4);

      root.left.left = new TreeNode(5);
      root.right.left = new TreeNode(3);

      //root.left.left = new TreeNode(29);
      //root.left.right = new TreeNode(42);

      //root.right.left = new TreeNode(50);
      //root.right.right = new TreeNode(41);

      //root.right.right = new TreeNode(1);

      //var res = new Solution().RankTeams(new[] { "AXYB', 'AYXB', 'AXYB', 'AYXB" });
      //var res2 = new Solution().MaxSubarraySumCircular(new int[] { 5,4,3,2,1 });


      //var points = new int[][]
      //{
      //  new int[]{-2, 0 },
      //  new int[]{2, 0  },
      //  new int[]{0, 2 },
      //  new int[]{0, -2 }
      //};

      var points = new int[][]
      {
        new int[]{4, 5 },
        new int[]{-4, 1 },
        new int[]{-3, 2 },
        new int[]{-4, 0 },
        new int[]{0, 2 }
      };

      /*
       [[4,5],[-4,1],[-3,2],[-4,0],[0,2]]
5
       
       */
      /*
      var res = new Solution().SmallestSufficientTeam(
        new[] { "algorithms', 'math', 'java', 'reactjs', 'csharp', 'aws" },
        new List<IList<string>>
        {
          new List<string> {"algorithms","math","java"},
          new List<string> {"algorithms","math","reactjs" },
          new List<string> {"java","csharp","aws"},
          new List<string> {"reactjs","csharp" },
          new List<string> {"aws","java" },
        }
      );*/

      //new Solution().ReverseWords(new[] { 't', 'h', 'e', ' ', 's', 'k', 'y', ' ', 'i', 's', ' ', 'b', 'l', 'u', 'e' });

      var r = new Solution().MinAbsoluteSumDiff(
        new[] { 1, 7, 5 },
        new[] { 2,3,5 }
       );
    }

    public class Solution
    {
      public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
      {
        var sum = Enumerable.Range(0, nums1.Length).Select(x => (long)Math.Abs(nums1[x] - nums2[x])).Sum();
        var ans = sum;
        var arr = nums1.OrderBy(x => x).ToArray();
        
        for (var i = 0; i < nums1.Length; ++i)
        {
          var diff = (long)Math.Abs(nums1[i] - nums2[i]);

          var n1 = BinarySearch(arr, nums2[i]);
          var d1 = (long)Math.Abs(n1 - nums2[i]);

          ans = Math.Min(ans, sum - diff + d1);
        }

        return (int)(ans % 1_000_000_007);
      }

      private int BinarySearch(int[] arr, int n2)
      {
        var left = 0;
        var right = arr.Length - 1;

        //var diff = arr[(right + left) / 2] - n2;

        while (true)
        {
          if (right - left <= 1)
          {
            var r = arr[right] - n2;
            var l = arr[left] - n2;

            if (Math.Abs(l) < Math.Abs(r))
              return arr[left];
            else
              return arr[right];
          }

          var mid = (right + left) / 2;
          var d = arr[mid] - n2;

          if (d > 0)
            right = mid;
          else
            left = mid;
        }
      }
    }
  }
}
 
