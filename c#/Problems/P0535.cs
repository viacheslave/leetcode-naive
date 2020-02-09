using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/encode-and-decode-tinyurl/
	///		Submission: https://leetcode.com/submissions/detail/237115960/
	/// </summary>
	internal class P0535
	{
		public class Codec
		{

			// Encodes a URL to a shortened URL
			public string encode(string longUrl)
			{
				return "http://tinyurl.com/" + Convert.ToBase64String(Encoding.Unicode.GetBytes(longUrl));
			}

			// Decodes a shortened URL to its original URL.
			public string decode(string shortUrl)
			{
				var encoded = shortUrl.Substring(19);
				return Encoding.Unicode.GetString(Convert.FromBase64String(encoded));
			}
		}
	}
}
