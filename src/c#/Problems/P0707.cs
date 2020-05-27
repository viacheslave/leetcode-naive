using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/design-linked-list/
	///		Submission: https://leetcode.com/submissions/detail/231781714/
	/// </summary>
	internal class P0707
	{
		public class MyLinkedList
		{

			public class Node
			{
				public int val;
				public Node next;

				public Node(int val)
				{
					this.val = val;
				}
			}

			public Node _head;
			public Node _tail;
			public int _length;

			/** Initialize your data structure here. */
			public MyLinkedList()
			{

			}

			/** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
			public int Get(int index)
			{
				if (index >= _length)
					return -1;

				if (index < 0 && _length == 0) index = 0;

				var current = _head;
				var i = 0;
				while (current != null)
				{
					if (i == index)
						return current.val;

					current = current.next;
					i++;
				}

				return -1;
			}

			/** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
			public void AddAtHead(int val)
			{
				if (_head == null)
				{
					_head = new Node(val);
					_tail = _head;
					_length = 1;
					return;
				}

				var added = new Node(val);
				added.next = _head;
				_head = added;
				_length++;
			}

			/** Append a node of value val to the last element of the linked list. */
			public void AddAtTail(int val)
			{
				if (_tail == null)
				{
					_tail = new Node(val);
					_head = _tail;
					_length = 1;
					return;
				}

				var added = new Node(val);
				_tail.next = added;
				_tail = added;
				_length++;
			}

			/** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
			public void AddAtIndex(int index, int val)
			{
				if (index > _length)
					return;

				if (index == _length)
				{
					AddAtTail(val);
					return;
				}

				if (index <= 0)
				{
					AddAtHead(val);
					return;
				}

				var current = _head;

				var i = 0;
				while (current != null)
				{
					if (i == index - 1)
					{
						var added = new Node(val);
						added.next = current.next;
						current.next = added;
						_length++;
						return;
					}

					current = current.next;
					i++;
				}
			}

			/** Delete the index-th node in the linked list, if the index is valid. */
			public void DeleteAtIndex(int index)
			{
				if (index >= _length || index < 0)
					return;

				Node previous = null;
				var current = _head;

				var i = 0;
				while (current != null)
				{
					if (i == index)
					{
						// first
						if (i == 0)
						{
							_head = _head.next;
							_length--;
							return;
						}

						// last
						if (i == _length - 1)
						{
							previous.next = null;
							_tail = previous;
							_length--;
							return;
						}

						if (i != 0 && i != _length - 1)
						{
							previous.next = current.next;
							_length--;
							return;
						}
					}

					previous = current;
					current = current.next;
					i++;
				}
			}
		}
	}
}
