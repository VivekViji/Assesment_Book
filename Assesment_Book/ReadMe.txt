Application info
-------------------------
1.Here in this application three Api methods are added in Controller.
2.Then Repository Design pattern implemented with use of interface in service layer.
3.Then required method are declared in interface
4.Then finally methods are implemented in service class with use of dapper.

Concepts Used
----------------
1.Api Controller
2.Repository Pattern(Design Patten)
3.Interface
4.Dapper
5.Dependancy Injection(for ex IConfiguration Injected in DbContext Class)
6.Stored Procedure.


Db Scripts
----------------------


-- query for create db
CREATE DATABASE Assesment_Book

GO
-- query for create table
CREATE TABLE BOOK
(
BookId INT PRIMARY KEY IDENTITY(1,1),
Publisher NVARCHAR(300),
Title NVARCHAR(300),
AuthorLastName NVARCHAR(300),
AuthorFirstName NVARCHAR(300),
Price DECIMAL(18,2)
)

GO

-- query for create table
CREATE TABLE BookMlaCitation
(
BookMlaCitationId INT PRIMARY KEY IDENTITY(1,1),
BookId INT FOREIGN KEY REFERENCES BOOK(BookId),
TitleofContainer NVARCHAR(300),
PublicationDate DATETIME,
Location NVARCHAR(300)
)

GO

-- query for create table
CREATE TABLE BookChicacoCitation
(
BookChicacoCitationId INT PRIMARY KEY IDENTITY(1,1),
BookId INT FOREIGN KEY REFERENCES BOOK(BookId),
IssueNo NVARCHAR(200),
ValumeNo NVARCHAR(200),
Url NVARCHAR(500),
PageRange NVARCHAR(200)
)

GO



---sample data insert query

DECLARE @Identity INT

INSERT INTO BOOK VALUES('Publisher 1','Title 1','M','Vivek',100)
SET @Identity=(SELECT IDENT_CURRENT('BOOK'))

INSERT INTO BookMlaCitation VALUES(@Identity,'test title of container',GETDATE(),'TEST LOCATION')
INSERT INTO BookChicacoCitation VALUES(@Identity,'(Jan 1972)','1','http://xxx.yyy','100-200')

INSERT INTO BOOK VALUES('Publisher 2','Title 2','M','Sathish',500)
SET @Identity=(SELECT IDENT_CURRENT('BOOK'))

INSERT INTO BookMlaCitation VALUES(@Identity,'test title of container',GETDATE(),'TEST LOCATION')
INSERT INTO BookChicacoCitation VALUES(@Identity,'(FEB 1952)','2','http://abc.yyy','120-200')

INSERT INTO BOOK VALUES('Publisher 3','Title 3','k','yuvaraj',1000)
SET @Identity=(SELECT IDENT_CURRENT('BOOK'))

INSERT INTO BookMlaCitation VALUES(@Identity,'test title of container',GETDATE(),'TEST LOCATION')
INSERT INTO BookChicacoCitation VALUES(@Identity,'(Oct 2002)','2','http://xyz.yyy','10-100')

GO





--QUERY FOR CREATE PROCEDURE
--operation 1 for get list sort by publisher,auther lastname,firstname,title
--operation 2 for get list sort by auther lastname,firstname,title
--operation 3 for get total price of all books

--exec SpGetBookList 3
ALTER PROCEDURE SpGetBookList(@Operation INT)
AS
BEGIN

IF(@Operation=1)
BEGIN

SELECT Publisher,Title,AuthorFirstName,AuthorLastName,Price,
AuthorLastName+','+AuthorFirstName+'.'+'"'+Title+'"'+TitleofContainer+','+Publisher+','+CAST(PublicationDate AS NVARCHAR)+','+Location AS MlaCitation,
Title+','+ValumeNo+IssueNo+':'+PageRange+'.'+Url AS ChicagoCitation
FROM BOOK AS B JOIN BookMlaCitation MC ON B.BookId=MC.BookId JOIN BookChicacoCitation CC ON B.BookId=CC.BookId
ORDER BY Publisher,AuthorLastName,AuthorFirstName,Title

END

ELSE IF(@Operation=2)
BEGIN

SELECT Publisher,Title,AuthorFirstName,AuthorLastName,Price,
AuthorLastName+','+AuthorFirstName+'.'+'"'+Title+'"'+TitleofContainer+','+Publisher+','+CAST(PublicationDate AS NVARCHAR)+','+Location AS MlaCitation,
Title+','+ValumeNo+IssueNo+':'+PageRange+'.'+Url AS ChicagoCitation
FROM BOOK AS B JOIN BookMlaCitation MC ON B.BookId=MC.BookId JOIN BookChicacoCitation CC ON B.BookId=CC.BookId
ORDER BY AuthorLastName,AuthorFirstName,Title

END

ELSE
BEGIN

SELECT SUM(Price) AS TotalPriceofAllBooks FROM BOOK

END

END










