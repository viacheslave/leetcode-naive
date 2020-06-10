using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/design-hashmap/
	///		Submission: https://leetcode.com/submissions/detail/231496276/
	/// </summary>
	internal class P0706
	{
		public class MyHashMap
		{

			public int bucketsCount = 10000000;

			public Node[] buckets;

			public class Node
			{
				public int key;
				public int val;

				public Node next;
				public Node prev;

				public Node() { }

				public Node(int key, int val)
				{
					this.key = key;
					this.val = val;
				}
			}

			private int GetBucket(int key)
			{
				return key % bucketsCount;
			}

			/** Initialize your data structure here. */
			public MyHashMap()
			{
				buckets = new Node[bucketsCount];
			}

			/** value will always be non-negative. */
			public void Put(int key, int value)
			{
				var bucketIndex = GetBucket(key);
				var bucket = buckets[bucketIndex];

				if (bucket == null)
				{
					buckets[bucketIndex] = new Node(key, value);
					return;
				}

				var currentNode = bucket;
				while (currentNode != null)
				{
					if (currentNode.key == key)
					{
						currentNode.val = value;
						return;
					}

					if (currentNode.next == null)
					{
						var newNode = new Node(key, value);
						currentNode.next = newNode;
						newNode.prev = currentNode;
						return;
					}

					currentNode = currentNode.next;
				}
			}

			/** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
			public int Get(int key)
			{
				var bucketIndex = GetBucket(key);
				var bucket = buckets[bucketIndex];

				if (bucket == null)
					return -1;

				var currentNode = bucket;
				while (currentNode != null)
				{
					if (currentNode.key == key)
						return currentNode.val;

					currentNode = currentNode.next;
				}

				return -1;
			}

			/** Removes the mapping of the specified value key if this map contains a mapping for the key */
			public void Remove(int key)
			{
				var bucketIndex = GetBucket(key);
				var bucket = buckets[bucketIndex];

				if (bucket == null)
					return;

				var currentNode = bucket;
				while (currentNode != null)
				{
					if (currentNode.key == key)
					{
						if (currentNode.prev == null)
						{
							buckets[bucketIndex] = currentNode.next;
							return;
						}

						currentNode.prev = currentNode.next;
						return;
					}

					currentNode = currentNode.next;
				}
			}
		}
	}
}
