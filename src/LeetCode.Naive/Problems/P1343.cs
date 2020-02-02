using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/maximum-product-of-splitted-binary-tree/
	///		Submission: https://leetcode.com/submissions/detail/299633859/
	/// </summary>
	internal class P1343
	{
		public int MaxProduct(TreeNode root)
		{
			var list = new List<int>();
			var sum = GetSum(root, list);

			var ans = 0L;
			foreach (var item in list)
			{
				var value = Math.BigMul(item, sum - item);
				if (value > ans)
					ans = value;
			}

			return Convert.ToInt32(ans % 1000000007);
		}

		private int GetSum(TreeNode node, List<int> list)
		{
			if (node == null) return 0;
			var sum = node.val + GetSum(node.left, list) + GetSum(node.right, list);
			list.Add(sum);
			return sum;
		}
	}
}
