namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/house-robber-iii/
  ///    Submission: https://leetcode.com/submissions/detail/412298018/
  /// </summary>
  internal class P0337
  {
    public class Solution
    {
      public int Rob(TreeNode root)
      {
        var dict = new Dictionary<(TreeNode, bool), int>();

        Rob(root, dict);

        var ans = Math.Max(
          dict[(root, true)],
          dict[(root, false)]);

        return ans;
      }

      private void Rob(TreeNode node, Dictionary<(TreeNode, bool), int> dict)
      {
        if (node == null)
        {
          dict[(node, true)] = 0;
          dict[(node, false)] = 0;
          return;
        }

        Rob(node.left, dict);
        Rob(node.right, dict);

        // if we take the house, all children should not be taken
        // sum all children and add current
        dict[(node, true)] =
          node.val +
          dict[(node.left, false)] +
          dict[(node.right, false)];

        var c1 = dict[(node.left, false)] + dict[(node.right, false)];
        var c2 = dict[(node.left, false)] + dict[(node.right, true)];
        var c3 = dict[(node.left, true)] + dict[(node.right, false)];
        var c4 = dict[(node.left, true)] + dict[(node.right, true)];

        // if we do not the house - all variants of children are possible
        // calc the max
        dict[(node, false)] =
          Math.Max(
            Math.Max(c1, c2),
            Math.Max(c3, c4)
          );
      }
    }
  }
}
