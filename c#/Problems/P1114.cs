using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/print-in-order/
	///		Submission: https://leetcode.com/submissions/detail/247775149/
	/// </summary>
	internal class P1114
	{
		public class Foo
		{
			System.Threading.ManualResetEventSlim _e2 = new System.Threading.ManualResetEventSlim();
			System.Threading.ManualResetEventSlim _e3 = new System.Threading.ManualResetEventSlim();

			public Foo()
			{

			}

			public void First(Action printFirst)
			{

				// printFirst() outputs "first". Do not change or remove this line.
				printFirst();

				_e2.Set();
			}

			public void Second(Action printSecond)
			{

				// printSecond() outputs "second". Do not change or remove this line.
				_e2.Wait();

				printSecond();

				_e3.Set();
			}

			public void Third(Action printThird)
			{

				// printThird() outputs "third". Do not change or remove this line.
				_e3.Wait();

				printThird();
			}
		}
	}
}
