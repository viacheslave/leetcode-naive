using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/utf-8-validation/
	///		Submission: https://leetcode.com/submissions/detail/246018778/
	/// </summary>
	internal class P0393
	{
		public bool ValidUtf8(int[] data)
		{
			var index = 0;
			while (index < data.Length)
			{
				if (data[index] < 128)
				{
					index++;
					continue;
				}

				if (192 <= data[index] && data[index] < 224
						&& index + 1 < data.Length
						&& 128 <= data[index + 1] && data[index + 1] < 192)
				{
					index += 2;
					continue;
				}

				if (224 <= data[index] && data[index] < 240
						&& index + 2 < data.Length
						&& 128 <= data[index + 1] && data[index + 1] < 192
						&& 128 <= data[index + 2] && data[index + 2] < 192)
				{
					index += 3;
					continue;
				}

				if (240 <= data[index] && data[index] < 248
						&& index + 3 < data.Length
						&& 128 <= data[index + 1] && data[index + 1] < 192
						&& 128 <= data[index + 2] && data[index + 2] < 192
						&& 128 <= data[index + 3] && data[index + 3] < 192)
				{
					index += 4;
					continue;
				}

				return false;
			}

			return true;
		}
	}
}
