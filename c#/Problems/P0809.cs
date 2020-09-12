namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///		Problem: https://leetcode.com/problems/expressive-words/
  ///		Submission: https://leetcode.com/submissions/detail/394701576/
  /// </summary>
  internal class P0809
	{
		public int ExpressiveWords(string S, string[] words)
    {
			var ans = 0;

			foreach (var word in words)
				if (Fits(word, S))
					ans++;

			return ans;
    }

    private bool Fits(string word, string s)
    {
			var wordIndex = 0;
			var sIndex = 0;

			while (sIndex < s.Length && wordIndex < word.Length)
			{
				if (word[wordIndex] == s[sIndex])
				{
					var wch = word[wordIndex];
					var sch = s[sIndex];

					var sIndexOriginal = sIndex;
					var wordIndexOriginal = wordIndex;

					while (wordIndex < word.Length && word[wordIndex] == wch)
							wordIndex++;

					while (sIndex < s.Length && s[sIndex] == sch)
							sIndex++;

					var sDiff = sIndex - sIndexOriginal;
					var wDiff = wordIndex - wordIndexOriginal;

					if ((sDiff == wDiff) || (sDiff > wDiff && sDiff >= 3))
							continue;

					return false;
				}

				return false;
      }

      return sIndex >= s.Length && wordIndex >= word.Length;
    }
	}
}
