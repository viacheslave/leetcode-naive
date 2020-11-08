using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/418061209/
  /// </summary>
  internal class P0105
  {
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
      public TreeNode BuildTree(int[] preorder, int[] inorder)
      {
        if (preorder.Length == 0)
          return null;

        var set = inorder.Select((el, i) => (el, i)).ToDictionary(x => x.el, x => x.i);

        var root = new TreeNode(preorder[0]);

        for (var i = 1; i < preorder.Length; i++)
        {
          var el = preorder[i];

          TreeNode parent = null;
          var current = root;
          var left = true;

          while (current != null)
          {
            parent = current;

            if (set[el] < set[current.val])
            {
              current = current.left;
              left = true;
            }
            else
            {
              current = current.right;
              left = false;
            }
          }

          if (left)
            parent.left = new TreeNode(el);
          else
            parent.right = new TreeNode(el);
        }

        return root;
      }
    }
  }
}
