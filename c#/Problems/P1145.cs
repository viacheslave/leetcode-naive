using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-tree-coloring-game/submissions/
  ///    Submission: https://leetcode.com/submissions/detail/427238478/
  /// </summary>
  internal class P1145
  {
    public class Solution
    {
      public bool BtreeGameWinningMove(TreeNode root, int n, int x)
      {
        var map = new Dictionary<int, (int left, int right)>();
        var count = DFS(root, map);

        var children = map[x];

        var options = new int[] {
      children.left,
      children.right,
      count - map[x].left - map[x].right - 1 }.ToList();

        var winmoves = options.Max();
        options.Remove(winmoves);

        var opponentmoves = options.Sum() + 1;

        return winmoves > opponentmoves;
      }

      private int DFS(TreeNode node, Dictionary<int, (int left, int right)> map)
      {
        if (node == null)
          return 0;

        map[node.val] = (DFS(node.left, map), DFS(node.right, map));

        return map[node.val].left + map[node.val].right + 1;
      }
    }
  }
}
