using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/implement-magic-dictionary/
	///		Submission: https://leetcode.com/submissions/detail/239724591/
	/// </summary>
	internal class P0676
	{
		public class MagicDictionary
		{
			Dictionary<int, HashSet<string>> _map;

			/** Initialize your data structure here. */
			public MagicDictionary()
			{

			}

			/** Build a dictionary through a list of words */
			public void BuildDict(string[] dict)
			{
				_map = dict.GroupBy(word => word.Length).ToDictionary(_ => _.Key, _ => new HashSet<string>(_));
			}

			/** Returns if there is any word in the trie that equals to the given word after modifying exactly one character */
			public bool Search(string word)
			{
				_map.TryGetValue(word.Length, out var list);
				if (list == null)
					return false;

				var length = word.Length;
				foreach (var listItem in list)
				{
					var count = 0;
					for (var i = 0; i < length; i++)
					{
						if (listItem[i] == word[i])
							continue;

						count++;
					}

					if (count == 1)
						return true;
				}

				return false;
			}
		}
	}
}
