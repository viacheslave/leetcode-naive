/*
Problem: https://leetcode.com/problems/delete-duplicate-emails/
Submission: https://leetcode.com/submissions/detail/391020942/
*/

# Write your MySQL query statement below
delete from Person
where Id not in (
  select x.Id from
  (
    select min(Id) as Id 
    from Person
    group by Email
  ) as x
)
group by id
