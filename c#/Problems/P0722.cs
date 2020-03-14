using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/remove-comments/
	///		Submission: https://leetcode.com/submissions/detail/244650321/
	/// </summary>
	internal class P0722
	{
		public IList<string> RemoveComments(string[] source)
		{
			var ans = new List<string>();

			for (int i = 0; i < source.Length; i++)
			{
				var line = source[i];

				while (true)
				{
					var ci = line.IndexOf("//");
					var bi = line.IndexOf("/*");

					if (ci == -1 && bi == -1)
					{
						ans.Add(line);
						break;
					}

					if ((bi != -1 && ci != -1) && (bi < ci) || (ci == -1 && bi != -1))
					{
						var openingIndex = line.IndexOf("/*");
						var closing = GetClosingBlockPos(source, i, openingIndex + 2);

						var closingLineIndex = closing.lineIndex;
						var closingLinePos = closing.linePos + 2;

						var result = new StringBuilder(line.Substring(0, openingIndex));

						if (closingLinePos < source[closingLineIndex].Length)
							result.Append(source[closingLineIndex].Substring(closingLinePos));

						i = closingLineIndex;
						source[i] = result.ToString();
						line = source[i];
						continue;
					}
					else
					{
						ans.Add(line.Substring(0, ci));
						break;
					}
				}
			}

			return ans.Where(_ => !string.IsNullOrEmpty(_)).ToList();
		}

		private (int lineIndex, int linePos) GetClosingBlockPos(string[] source, int lineIndex, int linePos)
		{
			var line = source[lineIndex].Substring(linePos);

			while (lineIndex < source.Length)
			{
				if (line.IndexOf("*/") != -1)
					return (lineIndex, line.IndexOf("*/") + linePos);

				lineIndex++;
				linePos = 0;
				line = source[lineIndex];
			}

			return (-1, -1);
		}
	}
}
