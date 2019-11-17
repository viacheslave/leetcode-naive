/*
Problem: https://leetcode.com/problems/swap-salary/
Submission: https://leetcode.com/submissions/detail/226278059/
*/

/* Write your T-SQL query statement below */
update salary
set sex = (case when sex = 'f' then 'm' else 'f' end)
