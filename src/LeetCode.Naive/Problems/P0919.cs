using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/complete-binary-tree-inserter/
	///		Submission: https://leetcode.com/submissions/detail/290264366/
	/// </summary>
	internal class P0919
	{
		public class CBTInserter
		{
			private readonly TreeNode root;
			private int currentParent = -1;
			private readonly List<TreeNode> nodes;

			public CBTInserter(TreeNode root)
			{
				if (root == null)
					return;

				this.root = root;

				SortedDictionary<int, List<TreeNode>> map = new SortedDictionary<int, List<TreeNode>>();
				Traverse(map, 0, root);

				nodes = map.Values.SelectMany(v => v).ToList();
				if (nodes.Count == 1)
				{
					currentParent = 0;
					return;
				}

				currentParent = (nodes.Count / 2) - 1;

				var parentNode = nodes[currentParent];
				if (parentNode.right != null)
					currentParent++;
			}

			private void Traverse(SortedDictionary<int, List<TreeNode>> map, int index, TreeNode node)
			{
				if (node == null)
					return;

				if (!map.ContainsKey(index)) map[index] = new List<TreeNode>();
				map[index].Add(node);

				Traverse(map, index + 1, node.left);
				Traverse(map, index + 1, node.right);
			}

			public int Insert(int v)
			{
				var parentNode = nodes[currentParent];
				var newNode = new TreeNode(v);

				if (parentNode.left == null)
				{
					parentNode.left = newNode;
					nodes.Add(newNode);
					return parentNode.val;
				}

				parentNode.right = newNode;
				nodes.Add(newNode);
				currentParent++;
				return parentNode.val;
			}

			public TreeNode Get_root()
			{
				return root;
			}
		}
	}
}
