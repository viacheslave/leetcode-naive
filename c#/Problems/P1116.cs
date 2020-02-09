using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems.Easy
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/print-zero-even-odd/
	///		Submission: https://leetcode.com/submissions/detail/248399014/
	/// </summary>
	internal class P1116
	{
		public class ZeroEvenOdd
		{
			private int n;
			private volatile int current = 1;

			public ZeroEvenOdd(int n)
			{
				this.n = n;
				_z.Set();
			}

			System.Threading.ManualResetEventSlim _z = new System.Threading.ManualResetEventSlim();
			System.Threading.ManualResetEventSlim _ev = new System.Threading.ManualResetEventSlim();
			System.Threading.ManualResetEventSlim _od = new System.Threading.ManualResetEventSlim();

			// printNumber(x) outputs "x", where x is an integer.
			public void Zero(Action<int> printNumber)
			{
				while (true)
				{
					_z.Wait();

					if (current > n)
						break;

					printNumber(0);

					_z.Reset();

					if (current % 2 == 0)
						_ev.Set();
					else
						_od.Set();

					if (current > n)
						break;
				}

				System.Threading.Interlocked.Increment(ref current);

				_ev.Set();
				_od.Set();
			}

			public void Even(Action<int> printNumber)
			{
				while (true)
				{
					_ev.Wait();
					if (current > n)
						break;



					printNumber(current);
					System.Threading.Interlocked.Increment(ref current);

					_ev.Reset();



					_z.Set();
				}
			}

			public void Odd(Action<int> printNumber)
			{
				while (true)
				{
					_od.Wait();
					if (current > n)
						break;


					printNumber(current);
					System.Threading.Interlocked.Increment(ref current);

					_od.Reset();



					_z.Set();
				}
			}
		}
	}
}
