using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/print-foobar-alternately/
	///		Submission: https://leetcode.com/submissions/detail/247786574/
	/// </summary>
	internal class P1115
	{
		public class FooBar
		{
			System.Threading.ManualResetEventSlim _foo = new System.Threading.ManualResetEventSlim();
			System.Threading.ManualResetEventSlim _bar = new System.Threading.ManualResetEventSlim();

			private int n;

			public FooBar(int n)
			{
				this.n = n;
			}

			public void Foo(Action printFoo)
			{
				_foo.Set();

				for (int i = 0; i < n; i++)
				{
					_foo.Wait();

					// printFoo() outputs "foo". Do not change or remove this line.
					printFoo();

					_foo.Reset();
					_bar.Set();

				}
			}

			public void Bar(Action printBar)
			{

				for (int i = 0; i < n; i++)
				{
					_bar.Wait();

					// printBar() outputs "bar". Do not change or remove this line.
					printBar();

					_bar.Reset();
					_foo.Set();
				}
			}
		}
	}
}
