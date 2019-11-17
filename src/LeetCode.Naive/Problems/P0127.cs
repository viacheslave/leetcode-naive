using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/word-ladder/
	///		Submission: https://leetcode.com/submissions/detail/240945045/
	/// </summary>
	internal class P0127
	{
		int min = int.MaxValue;

		public int LadderLength(string beginWord, string endWord, IList<string> wordList)
		{
			var pool = new HashSet<string>(wordList);
			if (!pool.Contains(endWord))
				return 0;

			pool.Add(beginWord);
			pool.Remove(endWord);

			var queue = new Queue<string>();
			queue.Enqueue(endWord);

			var map = new Dictionary<string, int>();
			map[endWord] = 0;

			while (queue.Count > 0)
			{
				var item = queue.Dequeue();

				var processed = new List<string>();

				foreach (var word in pool)
				{
					if (OneLetterOff(word, item))
					{
						//visited.Add(word);
						processed.Add(word);
						map[word] = map[item] + 1;

						queue.Enqueue(word);
					}
				}

				foreach (var pr in processed)
					pool.Remove(pr);
			}

			return map.ContainsKey(beginWord) ? (map[beginWord] + 1) : 0;
		}

		private bool OneLetterOff(string word, string current)
		{
			var diff = 0;

			for (var i = 0; i < word.Length; i++)
				if (word[i] != current[i])
					diff++;

			return diff == 1;
		}
	}
}
