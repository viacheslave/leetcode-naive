using System.Linq;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/construct-binary-tree-from-inorder-and-postorder-traversal/
  ///    Submission: https://leetcode.com/submissions/detail/418066645/
  /// </summary>
  internal class P0106
  {
    public class Solution
    {
      public TreeNode BuildTree(int[] inorder, int[] postorder)
      {
        if (inorder.Length == 0)
          return null;

        var set = inorder.Select((el, i) => (el, i)).ToDictionary(x => x.el, x => x.i);

        var root = new TreeNode(postorder[^1]);

        for (var i = postorder.Length - 2; i >= 0; i--)
        {
          var el = postorder[i];

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
