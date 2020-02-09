using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/sliding-window-median/
	///		Submission: https://leetcode.com/submissions/detail/244430086/
	/// </summary>
	internal class P0480
	{
		public double[] MedianSlidingWindow(int[] nums, int k)
		{
			MedianFinder finder = new MedianFinder();

			var ans = new List<double>();

			for (int i = 0; i < k; i++)
				finder.AddNum(nums[i]);

			ans.Add(finder.FindMedian());

			var right = k;
			while (right < nums.Length)
			{
				finder.AddNum(nums[right]);
				finder.RemoveNum(nums[right - k]);

				ans.Add(finder.FindMedian());

				right++;
			}

			return ans.ToArray();
		}

		public class MedianFinder
		{
			readonly SortedList<Value, Value> _values = new SortedList<Value, Value>();
			readonly Random _rnd = new Random((int)DateTime.Now.Ticks);

			/** initialize your data structure here. */
			public MedianFinder()
			{
			}

			public void AddNum(int num)
			{
				Value value = new Value { value = num, stamp = DateTime.Now.Ticks + _rnd.Next(1_000_000) };
				_values.Add(value, value);
			}

			public void RemoveNum(int num)
			{
				Value value = _values.Keys.First(_ => _.value == num);
				_values.Remove(value);
			}

			public double FindMedian()
			{
				if (_values.Count % 2 == 1)
					return _values.Keys[(_values.Count - 1) / 2].value;

				return
						_values.Keys[_values.Count / 2 - 1].value +
						((long)(_values.Keys[_values.Count / 2].value) - (long)(_values.Keys[_values.Count / 2 - 1].value)) / 2.0;
			}

			public class Value : IComparable<Value>
			{
				public int value;
				public long stamp;

				public int CompareTo(Value other)
				{
					if (value == other.value)
						return stamp.CompareTo(other.stamp);

					return value.CompareTo(other.value);
				}

				public override bool Equals(object obj)
				{
					var other = (Value)obj;
					return (other.value == this.value) && (other.stamp == this.stamp);
				}

				public override int GetHashCode()
				{
					unchecked
					{
						return value.GetHashCode() ^ stamp.GetHashCode();
					}
				}
			}
		}
	}
}
