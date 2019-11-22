/*
Problem: https://leetcode.com/problems/consecutive-numbers/
Submission: https://leetcode.com/submissions/detail/280812801/
*/

/* Write your T-SQL query statement below */
select distinct(a.Num) as ConsecutiveNums
from Logs a
left join Logs b on a.Id = b.Id - 1
left join Logs c on a.Id = c.Id - 2
where a.Num = b.Num
  and a.Num = c.Num
