/*
https://leetcode.com/problems/combine-two-tables/
https://leetcode.com/submissions/detail/226173104/
*/

Select p.FirstName, p.LastName, a.City, a.State
From Person p
	LEFT JOIN Address a on p.PersonId = a.PersonId
