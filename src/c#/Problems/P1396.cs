using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/design-underground-system/
	///		Submission: https://leetcode.com/submissions/detail/321327349/
	/// </summary>
	internal class P1396
	{
		public class UndergroundSystem
		{
			Dictionary<int, (string, int)> _map = new Dictionary<int, (string, int)>();
			Dictionary<(string, string), List<int>> _stats = new Dictionary<(string, string), List<int>>();

			public void CheckIn(int id, string stationName, int t)
			{
				_map[id] = (stationName, t);
			}

			public void CheckOut(int id, string stationName, int t)
			{
				var start = _map[id].Item1;

				if (!_stats.ContainsKey((start, stationName)))
					_stats[(start, stationName)] = new List<int>();

				_stats[(start, stationName)].Add(t - _map[id].Item2);
			}

			public double GetAverageTime(string startStation, string endStation)
			{
				if (_stats.ContainsKey((startStation, endStation)))
					return _stats[(startStation, endStation)].Average();

				return 0;
			}
		}

		/**
		 * Your UndergroundSystem object will be instantiated and called as such:
		 * UndergroundSystem obj = new UndergroundSystem();
		 * obj.CheckIn(id,stationName,t);
		 * obj.CheckOut(id,stationName,t);
		 * double param_3 = obj.GetAverageTime(startStation,endStation);
		 */
	}
}
