using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game/
	///		Submission: https://leetcode.com/submissions/detail/283159782/
	/// </summary>
	internal class P1275
	{
		public string Tictactoe(int[][] moves)
		{
			var map = new int[3][]
			{
						new int[3] { 0, 0, 0 },
						new int[3] { 0, 0, 0 },
						new int[3] { 0, 0, 0 },
			};

			for (int i = 0; i < moves.Length; i++)
			{
				var ch = i % 2 == 0 ? 1 : -1;
				map[moves[i][0]][moves[i][1]] = ch;

				if (i >= 4)
				{
					var winner = GetWinner(map);
					if (winner != null)
						return winner;
				}
			}

			if (moves.Length < 9)
				return "Pending";

			return "Draw";
		}

		private string GetWinner(int[][] map)
		{
			if (IsWinner(map, 1)) return "A";
			if (IsWinner(map, -1)) return "B";
			return null;
		}

		private bool IsWinner(int[][] map, int value)
		{
			for (int i = 0; i < 3; i++)
			{
				if (map[i][0] + map[i][1] + map[i][2] == value * 3)
					return true;

				if (map[0][i] + map[1][i] + map[2][i] == value * 3)
					return true;
			}

			if (map[1][1] == value)
			{
				if (map[0][0] == value && map[2][2] == value)
					return true;
				if (map[2][0] == value && map[0][2] == value)
					return true;
			}

			return false;
		}
	}
}
