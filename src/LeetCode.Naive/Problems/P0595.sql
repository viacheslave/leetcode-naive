/*
Problem: https://leetcode.com/problems/big-countries/
Submission: https://leetcode.com/submissions/detail/226275879/
*/

select w.name, w.population, w.area
from World w
where w.area > 3000000 || w.population > 25000000