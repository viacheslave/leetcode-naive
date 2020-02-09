using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lru-cache/
	///		Submission: https://leetcode.com/submissions/detail/235416093/
	/// </summary>
	internal class P0146
	{
		public class LRUCache
		{
			private readonly int _capacity;

			private Dictionary<int, LinkedListNode<int>> _map = new Dictionary<int, LinkedListNode<int>>();
			private LinkedList<int> _ll = new LinkedList<int>();

			public LRUCache(int capacity)
			{
				_capacity = capacity;
			}

			public int Get(int key)
			{
				if (!_map.TryGetValue(key, out var node))
					return -1;

				TakeOutNode(node);
				InsertNodeAsFirst(node);

				return node.Value;
			}

			public void Put(int key, int value)
			{
				if (_map.TryGetValue(key, out var node))
				{
					node.Value = value;

					TakeOutNode(node);
					InsertNodeAsFirst(node);
				}
				else
				{
					if (_map.Count == _capacity)
						EvictLastNode();

					node = new LinkedListNode<int>(value);

					_map[key] = node;
					InsertNodeAsFirst(node);
				}
			}

			private void TakeOutNode(LinkedListNode<int> node)
			{
				_ll.Remove(node);
			}

			private void InsertNodeAsFirst(LinkedListNode<int> node)
			{
				_ll.AddFirst(node);
			}

			private void EvictLastNode()
			{
				var node = _ll.Last;

				_ll.RemoveLast();

				var key = _map.Where(_ => _.Value == node).Select(_ => _.Key).First();
				_map.Remove(key);
			}
		}
	}
}
