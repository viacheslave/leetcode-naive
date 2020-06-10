using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/linked-list-cycle-ii/
	///		Submission: https://leetcode.com/submissions/detail/228369303/
	/// </summary>
	internal class P0142
	{
		public ListNode DetectCycle(ListNode head)
		{

			if (head == null)
				return null;

			var map = new Dictionary<ListNode, int>();

			var node = head;

			for (var i = 0; ; i++)
			{
				if (node == null)
					return null;

				if (map.ContainsKey(node))
				{
					return node;
				}
				else
				{
					map.Add(node, i);
				}

				if (node.next != null)
				{
					node = node.next;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
