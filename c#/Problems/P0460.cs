using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/lfu-cache/
	///		Submission: https://leetcode.com/submissions/detail/245112741/
	/// </summary>
	internal class P0460
	{
		public class LFUCache
		{
			private readonly int _capacity;
			private readonly Dictionary<int, (int value, int freq)> _kv = new Dictionary<int, (int value, int freq)>();

			private readonly SortedList<int, Dictionary<int, long>> _vk =
					new SortedList<int, Dictionary<int, long>>();

			public LFUCache(int capacity)
			{
				_capacity = capacity;
			}

			public int Get(int key)
			{
				if (!_kv.ContainsKey(key))
					return -1;

				Update(key, _kv[key].value, _kv[key]);
				return _kv[key].value;
			}

			public void Put(int key, int value)
			{
				if (_capacity == 0)
					return;

				var exists = _kv.TryGetValue(key, out var oldValue);
				if (!exists)
				{
					if (_kv.Count == _capacity)
						Evict();

					Add(key, value);

					return;
				}

				Update(key, value, oldValue);
			}

			private void Evict()
			{
				var freq = _vk.Keys[0];
				var keyStamps = _vk[freq];

				int evictKey;

				if (keyStamps.Count == 1)
				{
					evictKey = keyStamps.Keys.First();
				}
				else
				{
					evictKey = keyStamps.OrderBy(_ => _.Value).First().Key;
				}

				_vk[freq].Remove(evictKey);
				if (_vk[freq].Count == 0) _vk.Remove(freq);

				_kv.Remove(evictKey);
			}

			private void Update(int key, int newValue, (int value, int freq) oldValue)
			{
				var valFreq = oldValue.freq;
				var newFreq = valFreq + 1;

				_vk[valFreq].Remove(key);
				if (_vk[valFreq].Count == 0) _vk.Remove(valFreq);

				if (!_vk.ContainsKey(newFreq)) _vk[newFreq] = new Dictionary<int, long>();

				_vk[newFreq].Add(key, DateTime.Now.Ticks);

				_kv[key] = (newValue, newFreq);
			}

			private void Add(int key, int value)
			{
				_kv[key] = (value, 0);

				if (!_vk.ContainsKey(0)) _vk[0] = new Dictionary<int, long>();
				_vk[0].Add(key, DateTime.Now.Ticks);
			}
		}
	}
}
