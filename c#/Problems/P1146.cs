using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/snapshot-array/
	///		Submission: https://leetcode.com/submissions/detail/280852967/
	/// </summary>
	internal class P1146
	{
		public class SnapshotArray
		{
			private readonly SortedDictionary<int, int>[] _data;
			private int _snapId;

			public SnapshotArray(int length)
			{
				_data = new SortedDictionary<int, int>[length];

				for (int i = 0; i < length; i++)
					_data[i] = new SortedDictionary<int, int>();
			}

			public void Set(int index, int val)
			{
				_data[index][_snapId] = val;
			}

			public int Snap()
			{
				return _snapId++;
			}

			public int Get(int index, int snap_id)
			{
				var bank = _data[index];

				var result = bank.TryGetValue(snap_id, out var value);
				if (result) return value;

				foreach (var item in bank)
				{
					if (item.Key > snap_id)
						break;

					value = item.Value;
				}

				return value;
			}
		}
		/**
		 * Your SnapshotArray object will be instantiated and called as such:
		 * SnapshotArray obj = new SnapshotArray(length);
		 * obj.Set(index,val);
		 * int param_2 = obj.Snap();
		 * int param_3 = obj.Get(index,snap_id);
		 */
	}
}
