using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/additive-number/
	///		Submission: https://leetcode.com/submissions/detail/231540664/
	/// </summary>
	internal class P0306
	{
		public bool IsAdditiveNumber(string num)
		{
			for (var l1 = 1; l1 <= 10; l1++)
			{
				for (var l2 = 1; l2 <= 10; l2++)
				{
					var res = new List<BigInteger>();

					if (l1 > num.Length || l1 + l2 > num.Length)
						continue;

					var n1 = num.Substring(0, l1);
					var n2 = num.Substring(l1, l2);

					if (n1 != "0" && n1.StartsWith("0"))
						continue;

					if (n2 != "0" && n2.StartsWith("0"))
						continue;

					BigInteger r0, r1;
					if (!BigInteger.TryParse(n1, out r0) || !BigInteger.TryParse(n2, out r1))
						continue;

					res.Add(r0);
					res.Add(r1);

					var cand = res[0] + res[1];
					var index = l1 + l2;

					while (index < num.Length)
					{
						var sumStr = cand.ToString();

						if (index + sumStr.Length > num.Length)
							break;

						var sPart = num.Substring(index, sumStr.Length);

						if (sumStr == sPart)
						{
							index += sumStr.Length;

							var newItem = cand + res.Last();
							res.Add(cand);

							cand = newItem;

							continue;
						}

						break;
					}

					if (res.Count > 2 && index >= num.Length)
						return true;
				}
			}

			return false;
		}
	}
}
