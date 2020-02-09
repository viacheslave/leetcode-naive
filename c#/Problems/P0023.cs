using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/merge-k-sorted-lists/
	///		Submission: https://leetcode.com/submissions/detail/226140332/
	/// </summary>
	internal class P0023
	{
		public ListNode MergeKLists(ListNode[] lists)
		{
			ListNode node = new ListNode(0);
			ListNode currentNode = node;

			int? index = null;

			do
			{
				index = GetMinListIndex(lists);
				if (index == null)
					break;

				var newNode = new ListNode(lists[index.Value].val);
				currentNode.next = newNode;

				lists[index.Value] = lists[index.Value].next;

				currentNode = currentNode.next;
			}
			while (index != null);

			return node.next;
		}

		private int? GetMinListIndex(ListNode[] lists)
		{
			int? min = null;
			int? index = null;

			for (var i = 0; i < lists.Length; i++)
			{
				if (lists[i] != null)
				{
					if (min == null || min > lists[i].val)
					{
						min = lists[i].val;
						index = i;
					}
				}
			}

			return index;
		}
	}
}
