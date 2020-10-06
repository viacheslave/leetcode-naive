using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Naive.Problems
{
	/// <summary>
	///		Problem: https://leetcode.com/problems/basic-calculator/
	///		Submission: https://leetcode.com/submissions/detail/405384247/
	/// </summary>
	internal class P0224
	{
    private int _pointer = 0;

    public int Calculate(string s)
    {
      var stack = new Stack<Block>();

      var currentBlock = new Block();

      while (_pointer < s.Length)
      {
        var ch = s[_pointer];

        if (ch == '(')
        {
          stack.Push(currentBlock);
          currentBlock = new Block();

          _pointer++;
          continue;
        }

        if (ch == ')')
        {
          var blockValue = currentBlock.Evaluate();
          currentBlock = stack.Pop();
          currentBlock.Push(blockValue);

          _pointer++;
          continue;
        }

        if (ch == '+' || ch == '-')
          currentBlock.Push(ch);

        if (char.IsDigit(ch))
        {
          var temp = _pointer;

          while (temp < s.Length && char.IsDigit(s[temp]))
            temp++;

          var number = s.Substring(_pointer, temp - _pointer);
          currentBlock.Push(int.Parse(number));

          _pointer = temp;
          continue;
        }

        _pointer++;
      }

      return currentBlock.Evaluate();
    }

    private class Block
    {
      private readonly List<object> _items = new List<object>();

      public void Push(object lex)
      {
        _items.Add(lex);
      }

      public int Evaluate()
      {
        var sum = 0;

        if (_items.Count > 0)
          sum += (int)_items[0];

        for (int i = 1; i < _items.Count; i += 2)
        {
          var item = (int)_items[i + 1];
          if ((char)_items[i] == '-')
            item = -item;

          sum += item;
        }

        return sum;
      }
    }
  }
}
