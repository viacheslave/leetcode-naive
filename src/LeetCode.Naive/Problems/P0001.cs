namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/roman-to-integer/
	///		Submission: https://leetcode.com/submissions/detail/223533378/
	/// </summary>
	internal class P0001
	{
		public int RomanToInt(string s)
		{
			int m = 0,
					d = 0,
					c = 0, l = 0, x = 0, v = 0, i = 0;

			for (var a = 0; a < s.Length; a++)
			{
				if (s[a] == 'M') m += 1000;
				if (s[a] == 'D') d += 500;

				if (s[a] == 'C')
				{
					if ((a + 1) < s.Length && (s[a + 1] == 'D' || s[a + 1] == 'M'))
					{
						c -= 100;
					}
					else
					{
						c += 100;
					}
				}

				if (s[a] == 'L') l += 50;

				if (s[a] == 'X')
				{
					if ((a + 1) < s.Length && (s[a + 1] == 'L' || s[a + 1] == 'C'))
					{
						x -= 10;
					}
					else
					{
						x += 10;
					}
				}


				if (s[a] == 'V') v += 5;
				if (s[a] == 'I')
				{
					if ((a + 1) < s.Length && (s[a + 1] == 'V' || s[a + 1] == 'X'))
					{
						i -= 1;
					}
					else
					{
						i += 1;
					}
				}
			}

			return (m + d + c + l + x + v + i);
		}
	}
}
