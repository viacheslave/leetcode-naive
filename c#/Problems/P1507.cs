namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/reformat-date/
	///		Submission: https://leetcode.com/submissions/detail/387150760/
	/// </summary>
	internal class P1507
	{
		public string ReformatDate(string date)
		{
			var parts = date.Split(' ');

			var day = int.Parse(parts[0].Substring(0, parts[0].Length - 2));
			var month = 0;

			switch (parts[1])
			{
				case "Jan": month = 1; break;
				case "Feb": month = 2; break;
				case "Mar": month = 3; break;
				case "Apr": month = 4; break;
				case "May": month = 5; break;
				case "Jun": month = 6; break;
				case "Jul": month = 7; break;
				case "Aug": month = 8; break;
				case "Sep": month = 9; break;
				case "Oct": month = 10; break;
				case "Nov": month = 11; break;
				case "Dec": month = 12; break;
			}

			var year = int.Parse(parts[2]);

			return $"{year:00}-{month:00}-{day:00}";
		}
	}
}
