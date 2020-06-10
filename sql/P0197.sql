/*
Problem: https://leetcode.com/problems/rising-temperature/
Submission: https://leetcode.com/submissions/detail/226324089/
*/

/* Write your T-SQL query statement below */
/* {"headers": {"Weather": ["Id", "RecordDate", "Temperature"]}, "rows": {"Weather": [[1, "2000-12-16", 3], [2, "2000-12-15", -1]]}} */
/* {"headers": {"Weather": ["Id", "RecordDate", "Temperature"]}, "rows": {"Weather": [[1, "2000-12-14", 3], [2, "2000-12-16", 5]]}} */
/*
select a.id as Id
from
(
select id,
  row_number() over (order by RecordDate asc) as rownum,
  Temperature
from Weather
    
) a
left join 
(
select id,
  row_number() over (order by RecordDate asc) as rownum,
  Temperature
from Weather
) b on a.rownum = (b.rownum + 1)
where a.Temperature > b.Temperature
*/

select a.id as Id
from
(select id, RecordDate, Temperature from Weather) a
left join 
(select id, RecordDate, Temperature from Weather) b 
on a.RecordDate = dateadd(dd, 1, b.RecordDate)
where a.Temperature > b.Temperature