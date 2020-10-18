using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/binary-search-tree-iterator/
  ///    Submission: https://leetcode.com/submissions/detail/240532896/
  /// </summary>
  internal class P0173
  {
    public class Solution
    {
      public class BSTIterator
      {
        TreeNode _root;
        Stack<TreeNode> _st = new Stack<TreeNode>();

        public BSTIterator(TreeNode root)
        {
          _root = root;

          Traverse(root, _st);
        }

        private void Traverse(TreeNode node, Stack<TreeNode> st)
        {
          if (node == null) return;

          Traverse(node.right, st);
          st.Push(node);
          Traverse(node.left, st);
        }

        /** @return the next smallest number */
        public int Next()
        {
          return _st.Pop().val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
          return _st.Count > 0;
        }
      }

    }
  }
}
