using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/integer-to-english-words/
	///		Submission: https://leetcode.com/submissions/detail/228407547/
	/// </summary>
	internal class P0273
	{
		public string NumberToWords(int num)
		{
			if (num == 0)
				return "Zero";

			var plainMap = new string[]
			{
						"",
						"One",
						"Two",
						"Three",
						"Four",
						"Five",
						"Six",
						"Seven",
						"Eight",
						"Nine"
			};

			var decMap = new string[]
			{
						"",
						"",
						"Twenty",
						"Thirty",
						"Forty",
						"Fifty",
						"Sixty",
						"Seventy",
						"Eighty",
						"Ninety"
			};

			var elevMap = new string[]
			{
						"Ten",
						"Eleven",
						"Twelve",
						"Thirteen",
						"Fourteen",
						"Fifteen",
						"Sixteen",
						"Seventeen",
						"Eighteen",
						"Nineteen"
			};

			var triplets = new string[]
			{
						"Thousand",
						"Million",
						"Billion"
			};

			var arr = new List<string>();

			int power = 1;
			var pow = 1;

			while (num / power >= 10)
			{
				power = power * 10;
				pow++;
			}

			var elevFlag = false;

			var hun = false;
			var dec = false;
			var one = false;

			while (true)
			{
				var digit = num / power;

				if (pow % 3 == 0)
				{
					if (digit > 0)
					{
						arr.Add(plainMap[digit]);
						arr.Add("Hundred");
						hun = true;
					}
					else
					{
						hun = false;
					}
				}

				if (pow % 3 == 2)
				{
					if (digit == 1)
					{
						//arr.Add(elevMap[digit]);
						elevFlag = true;
						dec = true;
					}
					else if (digit > 1)
					{
						arr.Add(decMap[digit]);
						dec = true;
					}
					else
					{
						dec = false;
					}
				}

				if (pow % 3 == 1)
				{
					if (elevFlag)
					{
						elevFlag = false;
						arr.Add(elevMap[digit]);
						one = true;
					}
					else
					{
						if (digit > 0)
						{
							arr.Add(plainMap[digit]);
							one = true;
						}
						else
						{
							one = false;
						}
					}

					if (hun || dec || one)
					{
						var triplet = (pow - 1) / 3;
						if (triplet > 0)
							arr.Add(triplets[triplet - 1]);
					}
				}

				num = num - digit * power;

				power = power / 10;
				pow--;
				if (power == 0)
					break;
			}

			return string.Join(" ", arr);
		}
	}
}
