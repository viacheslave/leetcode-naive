using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/available-captures-for-rook/
	///		Submission: https://leetcode.com/submissions/detail/234326667/
	/// </summary>
	internal class P0999
	{
		public int NumRookCaptures(char[][] board)
		{
			var count = 0;

			var row = -1;
			var col = -1;

			for (var i = 0; i < 8; i++)
				for (var j = 0; j < 8; j++)
					if (board[i][j] == 'R')
					{
						row = i;
						col = j;
						break;
					}

			var current = col;

			while (current - 1 >= 0)
			{
				current -= 1;
				if (board[row][current] == '.')
					continue;
				if (board[row][current] == 'B')
					break;

				count++;
				break;
			}

			current = col;

			while (current + 1 < 8)
			{
				current += 1;
				if (board[row][current] == '.')
					continue;
				if (board[row][current] == 'B')
					break;

				count++;
				break;
			}

			current = row;

			while (current - 1 >= 0)
			{
				current -= 1;
				if (board[current][col] == '.')
					continue;
				if (board[current][col] == 'B')
					break;

				count++;
				break;
			}

			current = row;

			while (current + 1 < 8)
			{
				current += 1;
				if (board[current][col] == '.')
					continue;
				if (board[current][col] == 'B')
					break;

				count++;
				break;
			}



			return count;
		}
	}
}
