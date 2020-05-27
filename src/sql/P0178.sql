/*
https://leetcode.com/problems/rank-scores/
https://leetcode.com/submissions/detail/226300604/
*/

/* Write your T-SQL query statement below */

select 
  s.Score, 
  a.Rank
from 
  Scores s
    join
    (
      select 
        s.Score as Score,
        row_number() over (order by s.Score desc) as Rank
      from Scores s
      group by s.Score
    ) a on s.Score = a.Score
order by a.Rank
