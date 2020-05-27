/*
https://leetcode.com/problems/customers-who-never-order/
https://leetcode.com/submissions/detail/226175896/
*/

/* Write your T-SQL query statement below */
select c.name  as Customers from customers c left join orders o on c.id = o.customerid where o.customerid is null