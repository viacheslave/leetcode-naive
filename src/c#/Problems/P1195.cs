using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/fizz-buzz-multithreaded/
	///		Submission: https://leetcode.com/submissions/detail/264197439/
	/// </summary>
	internal class P1195
	{
		public class FizzBuzz
		{
			private int n;
			private int current;

			System.Threading.ManualResetEventSlim _e = new System.Threading.ManualResetEventSlim(false);
			System.Threading.ManualResetEventSlim _e3 = new System.Threading.ManualResetEventSlim(false);
			System.Threading.ManualResetEventSlim _e5 = new System.Threading.ManualResetEventSlim(false);
			System.Threading.ManualResetEventSlim _e15 = new System.Threading.ManualResetEventSlim(false);

			public FizzBuzz(int n)
			{
				this.n = n;
			}

			// printFizz() outputs "fizz".
			public void Fizz(Action printFizz)
			{
				while (true)
				{
					_e3.Wait();

					if (current % 3 == 0 && current % 5 != 0)
						printFizz();
					else return;

					_e3.Reset();
					_e.Set();
				}
			}

			// printBuzzz() outputs "buzz".
			public void Buzz(Action printBuzz)
			{
				while (true)
				{
					_e5.Wait();

					if (current % 5 == 0 && current % 3 != 0)
						printBuzz();
					else return;

					_e5.Reset();
					_e.Set();
				}
			}

			// printFizzBuzz() outputs "fizzbuzz".
			public void Fizzbuzz(Action printFizzBuzz)
			{
				while (true)
				{
					_e15.Wait();

					if (current % 15 == 0)
						printFizzBuzz();
					else return;

					_e15.Reset();
					_e.Set();
				}
			}

			// printNumber(x) outputs "x", where x is an integer.
			public void Number(Action<int> printNumber)
			{
				while (true)
				{
					if (current == n) break;

					current++;

					if (current % 15 == 0)
					{
						_e.Reset();
						_e15.Set();
						_e.Wait();

						continue;
					}

					if (current % 3 == 0)
					{
						_e.Reset();
						_e3.Set();
						_e.Wait();

						continue;
					}

					if (current % 5 == 0)
					{
						_e.Reset();
						_e5.Set();
						_e.Wait();

						continue;
					}

					printNumber(current);

				}

				current = 1;

				_e3.Set();
				_e5.Set();
				_e15.Set();
			}
		}
	}
}
