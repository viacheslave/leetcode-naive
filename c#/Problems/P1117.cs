using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/building-h2o/
	///		Submission: https://leetcode.com/submissions/detail/251675678/
	/// </summary>
	internal class P1117
	{
		public class H2O
		{
			System.Threading.ManualResetEventSlim _o = new System.Threading.ManualResetEventSlim();
			System.Threading.ManualResetEventSlim _h = new System.Threading.ManualResetEventSlim();

			int _c = 2;

			public H2O()
			{
				_o.Reset();
				_h.Set();
			}

			public void Hydrogen(Action releaseHydrogen)
			{
				_h.Wait();

				// releaseHydrogen() outputs "H". Do not change or remove this line.
				releaseHydrogen();

				System.Threading.Interlocked.Decrement(ref _c);

				if (_c == 0)
				{
					_h.Reset();
					_o.Set();
				}
			}

			public void Oxygen(Action releaseOxygen)
			{
				_o.Wait();

				// releaseOxygen() outputs "O". Do not change or remove this line.
				releaseOxygen();

				_o.Reset();

				_c = 2;
				_h.Set();
			}
		}
	}
}
