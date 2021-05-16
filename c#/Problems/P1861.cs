using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/rotating-the-box/
  ///    Submission: https://leetcode.com/submissions/detail/493620052/
  /// </summary>
  internal class P1861
  {
    public class Solution
    {
      public char[][] RotateTheBox(char[][] box)
      {
        var lists = new List<List<int>>();

        for (var row = 0; row < box.Length; row++)
        {
          var list = new List<int>();
          var chunk = new List<int>();

          for (var col = 0; col <= box[0].Length; col++)
          {
            var item = col == box[0].Length ? '*' : box[row][col];
            if (item == '*')
            {
              var end = col - 1;
              if (chunk.Count == 0)
              {
                list.Add(2);
              }
              else
              {
                list.AddRange(chunk.OrderBy(x => x));
                list.Add(2);
              }

              chunk = new List<int>();
            }
            else if (item == '#')
            {
              chunk.Add(1);
            }
            else
            {
              chunk.Add(0);
            }
          }

          lists.Add(list);
        }

        var rows = lists[0].Count - 1;
        var cols = lists.Count;

        var ans = new char[rows][];

        for (var i = 0; i < rows; i++)
        {
          ans[i] = new char[cols];
          for (var j = 0; j < cols; j++)
          {
            char ch = '.';
            if (lists[cols - j - 1][i] == 2)
              ch = '*';
            else if (lists[cols - j - 1][i] == 1)
              ch = '#';

            ans[i][j] = ch;
          }
        }

        return ans;
      }
    }
  }
}
