SELECT cpu FROM PC WHERE memory = 3000

GO

SELECT U.UserName, D.Name
FROM Users U JOIN PC P ON U.PCId = P.Id
JOIN Departaments D ON U.DepartamentId = D.Id
WHERE P.hdd > 500

GO

SELECT D.Name, COUNT(U.Id)
FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
GROUP BY D.Id, D.Name

GO

SELECT D.Name, COUNT(U.Id), SUM(U.Salary)
FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
GROUP BY D.Id, D.Name

GO

SELECT DISTINCT P.*
FROM PC P JOIN USERS U ON P.Id = U.PCId,
	(SELECT D.Id id, SUM(U.Salary) AS sm
	FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
	GROUP BY D.Id, D.Name) AS T1
WHERE U.DepartamentId = T1.id AND T1.sm = (SELECT MAX(T2.sm) FROM (SELECT D.Id id, SUM(U.Salary) AS sm
										FROM Users U JOIN Departaments D ON U.DepartamentId = D.Id
										GROUP BY D.Id, D.Name) T2)
	

