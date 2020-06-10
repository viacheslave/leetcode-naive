using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/apply-discount-every-n-orders/
	///		Submission: https://leetcode.com/submissions/detail/306159678/
	/// </summary>
	internal class P1357
	{
    public class Cashier
    {

      private int _n;
      private int _current = 0;
      private int _discount;

      private Dictionary<int, int> _prices;

      public Cashier(int n, int discount, int[] products, int[] prices)
      {
        _n = n;
        _discount = discount;
        _prices = new Dictionary<int, int>();

        for (var i = 0; i < products.Length; i++)
          _prices[products[i]] = prices[i];
      }

      public double GetBill(int[] product, int[] amount)
      {
        _current++;

        var bill = 0;
        for (var i = 0; i < product.Length; i++)
          bill += _prices[product[i]] * amount[i];

        if (_current % _n != 0)
          return bill;

        var dis = 1.0 - _discount / 100.0;
        return bill * dis;
      }
    }

    /**
     * Your Cashier object will be instantiated and called as such:
     * Cashier obj = new Cashier(n, discount, products, prices);
     * double param_1 = obj.GetBill(product,amount);
     */
  }
}
