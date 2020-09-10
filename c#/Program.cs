﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive
{
	class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class Solution
	{
		public string ModifyString(string s)
		{
			var sb = new StringBuilder(s);

			for (var i = 0; i < sb.Length; i++)
			{
				if (sb[i] != '?')
					continue;

				var constraints = new List<char>();
				if (i - 1 >= 0)
					constraints.Add(sb[i - 1]);

				if (i + 1 < sb.Length && sb[i + 1] != '?')
					constraints.Add(sb[i + 1]);

				for (var ch = 97; ; ch++)
				{
					if (!constraints.Any(c => (int)c == ch))
					{
						sb[i] = (char)ch;
						break;
					}
				}
			}

			return sb.ToString();
		}
	}
}
