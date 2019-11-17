using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/quad-tree-intersection/
	///		Submission: https://leetcode.com/submissions/detail/230645080/
	/// </summary>
	internal class P0558
	{
		public NodeQuad Intersect(NodeQuad quadTree1, NodeQuad quadTree2)
		{
			if (quadTree1 == null || quadTree2 == null)
				return null;

			return GetIntersection(quadTree1, quadTree2);
		}

		private NodeQuad GetIntersection(NodeQuad quadTree1, NodeQuad quadTree2)
		{
			var node = new NodeQuad();

			if (quadTree1.isLeaf && quadTree2.isLeaf)
			{
				node.isLeaf = true;
				node.val = quadTree1.val || quadTree2.val;
				return node;
			}

			var topLeft = GetIntersection(
					quadTree1.topLeft ?? new NodeQuad { val = quadTree1.val, isLeaf = true },
					quadTree2.topLeft ?? new NodeQuad { val = quadTree2.val, isLeaf = true }
			);

			var topRight = GetIntersection(
					quadTree1.topRight ?? new NodeQuad { val = quadTree1.val, isLeaf = true },
					quadTree2.topRight ?? new NodeQuad { val = quadTree2.val, isLeaf = true }
			);

			var bottomLeft = GetIntersection(
					quadTree1.bottomLeft ?? new NodeQuad { val = quadTree1.val, isLeaf = true },
					quadTree2.bottomLeft ?? new NodeQuad { val = quadTree2.val, isLeaf = true }
			);

			var bottomRight = GetIntersection(
					quadTree1.bottomRight ?? new NodeQuad { val = quadTree1.val, isLeaf = true },
					quadTree2.bottomRight ?? new NodeQuad { val = quadTree2.val, isLeaf = true }
			);

			if (topLeft.isLeaf && topRight.isLeaf && bottomLeft.isLeaf && bottomRight.isLeaf)
			{
				if (topLeft.val && topRight.val && bottomLeft.val && bottomRight.val)
				{
					node.isLeaf = true;
					node.val = true;
					return node;
				}

				if ((topLeft.val || topRight.val || bottomLeft.val || bottomRight.val) == false)
				{
					node.isLeaf = true;
					node.val = false;
					return node;
				}
			}

			node.topLeft = topLeft;
			node.topRight = topRight;
			node.bottomLeft = bottomLeft;
			node.bottomRight = bottomRight;
			return node;
		}
	}
}
