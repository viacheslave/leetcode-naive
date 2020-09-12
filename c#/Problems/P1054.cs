using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/distant-barcodes/
	///		Submission: https://leetcode.com/submissions/detail/394652685/
	/// </summary>
	internal class P1054
	{
		public int[] RearrangeBarcodes(int[] barcodes) 
		{
			var freqs = new Dictionary<int, int>();

			foreach (var barcode in barcodes)
			{
				if (!freqs.ContainsKey(barcode))
					freqs.Add(barcode, 0);

				freqs[barcode]++;
			}

			var list = freqs
				.OrderBy(x => x.Value)
				.Select(x => new Entry { Key = x.Key, Value = x.Value})
				.ToList();

			var ans = new List<int>();

			while (list[list.Count - 1].Value != 0)
			{
				var index = list.Count - 1;

				// first element
				if (ans.Count != 0)
				{
					// search for bucket
					while (list[index].Key == ans[ans.Count - 1])
						index--;
				}

				ans.Add(list[index].Key);
				
				var place = index;
				var key = list[index].Key;
				var value = list[index].Value - 1;
				
				// swap for bigger value on the left
				while (index > 0 && list[index - 1].Value > value)
					index--;
				
				if (place == index)
				{
					list[place].Value--;
					continue;
				}

				var temp = list[index];
				list[index] = new Entry() { Key = key, Value = value };
				list[place] = temp;
			}

			return ans.ToArray();
		}

		class Entry
		{
				public int Key;
				public int Value;
		}
	}
}
