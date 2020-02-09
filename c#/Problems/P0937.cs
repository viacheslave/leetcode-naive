using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reorder-log-files/
	///		Submission: https://leetcode.com/submissions/detail/231285168/
	/// </summary>
	internal class P0937
	{
		public string[] ReorderLogFiles(string[] logs)
		{
			var digitLogs = new List<string>();
			var letterLogs = new List<Letter>();

			foreach (var log in logs)
			{
				var isDigitLog = Digit(log.Split(' ')[1]);
				if (isDigitLog)
				{
					digitLogs.Add(log);
				}
				else
				{
					var id = log.Substring(0, log.IndexOf(' '));
					var ls = log.Substring(log.IndexOf(' ') + 1);

					letterLogs.Add(new Letter { id = id, log = ls });
				}
			}

			return letterLogs
					.OrderBy(_ => _.log)
					.ThenBy(_ => _.id)
					.Select(_ => _.id + " " + _.log)
					.Concat(digitLogs)
					.ToArray();
		}

		private bool Digit(string s)
		{
			return s.All(_ => Char.IsDigit(_));
		}

		public class Letter
		{
			public string id;
			public string log;
		}
	}
}
