using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/validate-ip-address/
	///		Submission: https://leetcode.com/submissions/detail/234927876/
	/// </summary>
	internal class P0468
	{
		public string ValidIPAddress(string IP)
		{
			var ip4 = false;
			var ip6 = false;

			if (IP.Contains('.'))
				ip4 = ValidateIp4(IP);

			if (IP.Contains(':'))
				ip6 = ValidateIp6(IP);

			if (ip4) return "IPv4";
			if (ip6) return "IPv6";
			return "Neither";
		}

		bool ValidateIp4(string ip)
		{
			var gr = ip.Split('.');
			if (gr.Length != 4)
				return false;

			foreach (var item in gr)
			{
				if (item == "0")
					continue;

				if (item.TrimStart(new[] { '0', '-' }) == item
						&& int.TryParse(item, out int value)
						&& value >= 0
						&& value <= 255)
					continue;

				return false;
			}

			return true;
		}

		bool ValidateIp6(string ip)
		{
			var gr = ip.Split(':');
			if (gr.Length != 8)
				return false;

			foreach (var item in gr)
			{
				if (item.Length > 4)
					return false;

				if (int.TryParse(
						item,
						System.Globalization.NumberStyles.HexNumber,
						System.Globalization.CultureInfo.CurrentCulture,
						out int value))
				{
					continue;
				}

				return false;
			}

			return true;
		}
	}
}
