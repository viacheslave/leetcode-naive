using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/serialize-and-deserialize-bst/
	///		Submission: https://leetcode.com/submissions/detail/406508882/
	/// </summary>
	internal class P0449
	{
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int x) { val = x; }
     * }
     */

    public class Codec
    {

      // Encodes a tree to a single string.
      public string serialize(TreeNode root)
      {
        var list = new List<string>();

        if (root == null)
          return Stringify(list);

        Serialize(root, list, "");
        var res = Stringify(list);

        return res;
      }

      // Decodes your encoded data to tree.
      public TreeNode deserialize(string data)
      {
        if (string.IsNullOrEmpty(data))
          return null;

        var items = data.Split(',');
        var stack = new Stack<(TreeNode node, int level)>();

        TreeNode root = null;

        for (int i = 0; i < items.Length; i++)
        {
          var parts = items[i].Split('-');
          var val = int.Parse(parts[0]);
          var level = parts[1].Length;

          if (stack.Count == 0)
          {
            root = new TreeNode(val);
            stack.Push((root, 0));
            continue;
          }

          while (stack.Peek().level != level - 1)
            stack.Pop();

          var parent = stack.Peek();
          var node = new TreeNode(val);

          if (parts[1].EndsWith("l"))
            parent.node.left = node;
          else
            parent.node.right = node;

          if (i + 1 < items.Length)
          {
            var next = items[i + 1];
            var nextLevel = next.Split('-')[1].Length;

            if (level + 1 == nextLevel)
              stack.Push((node, level));
          }
        }

        return root;
      }

      private void Serialize(TreeNode node, List<string> list, string path)
      {
        if (node == null)
          return;

        list.Add(node.val.ToString() + "-" + path);

        Serialize(node.left, list, path + "l");
        Serialize(node.right, list, path + "r");
      }

      private string Stringify(List<string> list)
      {
        return string.Join(",", list);
      }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.deserialize(codec.serialize(root));
  }
}
