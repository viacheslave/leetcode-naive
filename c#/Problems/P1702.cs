namespace LeetCode.Naive.Problems
{
  /// <summary>
  ///    Problem: https://leetcode.com/problems/maximum-binary-string-after-change/
  ///    Submission: https://leetcode.com/submissions/detail/434818035/
  /// </summary>
  internal class P1702
  {
    public class Solution
    {
      public string MaximumBinaryString(string binary)
      {
        var chs = binary.ToCharArray();
        var zero = binary.IndexOf('0');
        var nextZero = -1;

        if (zero == -1)
          return binary;

        // check character one-by-one
        while (zero < chs.Length)
        {
          if (zero == chs.Length - 1)
            break;

          // "00" case
          // swap with "10"
          if (chs[zero + 1] == '0')
          {
            chs[zero] = '1';
            zero++;
            continue;
          }

          // search for a zero next from current zero
          // but track the last search position
          // otherwise it's TLE
          var nz = -1;
          for (var i = nextZero == -1 ? zero + 1 : nextZero + 1; i < chs.Length; i++)
          {
            if (chs[i] == '0')
            {
              nz = i;
              break;
            }
          }

          if (nz == -1)
            break;

          // make recursive swaps in one step
          chs[nz] = '1';
          chs[zero] = '1';
          chs[zero + 1] = '0';

          // move to next position
          // save last processed zero
          zero++;
          nextZero = nz;
        }

        return new string(chs);
      }
    }
  }
}
