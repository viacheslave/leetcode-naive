using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/open-the-lock/
	///		Submission: https://leetcode.com/submissions/detail/241960614/
	/// </summary>
	internal class P0752
	{
		public int OpenLock(string[] deadends, string target)
		{
			var dead = new HashSet<string>(deadends);

			var queue = new Queue<(string value, int rank)>();
			queue.Enqueue((target, 0));

			var visited = new HashSet<string>();
			var visitedRanks = new Dictionary<string, int>();

			while (queue.Count > 0)
			{
				var (value, rank) = queue.Dequeue();
				if (visited.Contains(value))
					continue;

				if (dead.Contains(value))
					continue;

				visited.Add(value);
				visitedRanks.Add(value, rank);

				foreach (var item in GetNext(visited, value))
					queue.Enqueue((item, rank + 1));
			}

			return visitedRanks.ContainsKey("0000") ? visitedRanks["0000"] : -1;
		}

		private IEnumerable<string> GetNext(HashSet<string> visited, string value)
		{
			var next = new List<string>();
			StringBuilder sb;

			for (int i = 0; i < 4; i++)
			{
				sb = new StringBuilder(value);
				Generate(sb, i, 1);

				//if (!visited.Contains(sb.ToString()))
				next.Add(sb.ToString());

				sb = new StringBuilder(value);
				Generate(sb, i, -1);

				//if (!visited.Contains(sb.ToString()))
				next.Add(sb.ToString());
			}

			return next;
		}

		private void Generate(StringBuilder sb, int i, int shift)
		{
			sb[i] = (shift == 1) ? _nextMap[sb[i]] : _prevMap[sb[i]];
		}

		private Dictionary<char, char> _nextMap = new Dictionary<char, char>
		{
			['0'] = '1',
			['1'] = '2',
			['2'] = '3',
			['3'] = '4',
			['4'] = '5',
			['5'] = '6',
			['6'] = '7',
			['7'] = '8',
			['8'] = '9',
			['9'] = '0',
		};

		private Dictionary<char, char> _prevMap = new Dictionary<char, char>
		{
			['0'] = '9',
			['1'] = '0',
			['2'] = '1',
			['3'] = '2',
			['4'] = '3',
			['5'] = '4',
			['6'] = '5',
			['7'] = '6',
			['8'] = '7',
			['9'] = '8',
		};
	}
}
