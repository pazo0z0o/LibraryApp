USE [BookStore]
GO
/****** Object:  User [BookstoreAdmin]    Script Date: 7/17/2024 9:32:19 PM ******/
CREATE USER [BookstoreAdmin] FOR LOGIN [BookstoreAdmin] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [BookstoreAdmin]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 7/17/2024 9:32:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](200) NULL,
	[author] [varchar](200) NULL,
	[isbn] [varchar](10) NULL,
	[publishedDate] [date] NULL,
	[price] [money] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetBookById]    Script Date: 7/17/2024 9:32:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create Table Books
--(
--id int IDENTITY(1,1) PRIMARY KEY,
--title varchar(200),
--author varchar(200),
--isbn varchar(10),
--publishedDate DATE ,
--price MONEY,
--quantity int
--);
--===============================================
--CREATE PROCEDURE sp_Book_Create
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT,
--    @newId INT OUTPUT  
--AS
--BEGIN
--    INSERT INTO Books (title, author, isbn, publishedDate, price, quantity)
--    VALUES (@title, @author, @isbn, @publishedDate, @price, @quantity);

--    SET @newId = SCOPE_IDENTITY();  
--END
--GO
--=================================================
--CREATE PROCEDURE UpdateBook
--    @id INT,
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT
--AS
--BEGIN
--    UPDATE Books
--    SET title = @title,
--        author = @author,
--        isbn = @isbn,
--        publishedDate = @publishedDate,
--        price = @price,
--        quantity = @quantity
--    WHERE id = @id;
--END
--GO
--===============================================

--CREATE PROCEDURE sp_Book_Delete
--    @id INT
--AS
--BEGIN
--    DELETE FROM Books
--    WHERE id = @id;
--END
--GO
--=================================================
--CREATE PROCEDURE sp_Book_Get
--AS
--BEGIN
--    SELECT id, title, author, isbn, publishedDate, price, quantity
--    FROM Books;
--END
--GO
--===================================================
CREATE PROCEDURE [dbo].[GetBookById]
    @id INT
AS
BEGIN
    SELECT id, title, author, isbn, publishedDate, price, quantity
    FROM Books
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Create]    Script Date: 7/17/2024 9:32:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create Table Books
--(
--id int IDENTITY(1,1) PRIMARY KEY,
--title varchar(200),
--author varchar(200),
--isbn varchar(10),
--publishedDate DATE ,
--price MONEY,
--quantity int
--);

CREATE PROCEDURE [dbo].[sp_Book_Create]
    @title VARCHAR(200),
    @author VARCHAR(200),
    @isbn VARCHAR(10),
    @publishedDate DATE,
    @price MONEY,
    @quantity INT,
    @newId INT OUTPUT  -- Adding an OUTPUT parameter to store the newly generated ID
AS
BEGIN
    INSERT INTO Books (title, author, isbn, publishedDate, price, quantity)
    VALUES (@title, @author, @isbn, @publishedDate, @price, @quantity);

    SET @newId = SCOPE_IDENTITY();  -- Assign the last identity value generated to @newId
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Delete]    Script Date: 7/17/2024 9:32:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create Table Books
--(
--id int IDENTITY(1,1) PRIMARY KEY,
--title varchar(200),
--author varchar(200),
--isbn varchar(10),
--publishedDate DATE ,
--price MONEY,
--quantity int
--);
--===============================================
--CREATE PROCEDURE sp_Book_Create
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT,
--    @newId INT OUTPUT  
--AS
--BEGIN
--    INSERT INTO Books (title, author, isbn, publishedDate, price, quantity)
--    VALUES (@title, @author, @isbn, @publishedDate, @price, @quantity);

--    SET @newId = SCOPE_IDENTITY();  
--END
--GO
--=================================================
--CREATE PROCEDURE UpdateBook
--    @id INT,
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT
--AS
--BEGIN
--    UPDATE Books
--    SET title = @title,
--        author = @author,
--        isbn = @isbn,
--        publishedDate = @publishedDate,
--        price = @price,
--        quantity = @quantity
--    WHERE id = @id;
--END
--GO
--===============================================

CREATE PROCEDURE [dbo].[sp_Book_Delete]
    @id INT
AS
BEGIN
    DELETE FROM Books
    WHERE id = @id;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Get]    Script Date: 7/17/2024 9:32:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create Table Books
--(
--id int IDENTITY(1,1) PRIMARY KEY,
--title varchar(200),
--author varchar(200),
--isbn varchar(10),
--publishedDate DATE ,
--price MONEY,
--quantity int
--);
--===============================================
--CREATE PROCEDURE sp_Book_Create
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT,
--    @newId INT OUTPUT  
--AS
--BEGIN
--    INSERT INTO Books (title, author, isbn, publishedDate, price, quantity)
--    VALUES (@title, @author, @isbn, @publishedDate, @price, @quantity);

--    SET @newId = SCOPE_IDENTITY();  
--END
--GO
--=================================================
--CREATE PROCEDURE UpdateBook
--    @id INT,
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT
--AS
--BEGIN
--    UPDATE Books
--    SET title = @title,
--        author = @author,
--        isbn = @isbn,
--        publishedDate = @publishedDate,
--        price = @price,
--        quantity = @quantity
--    WHERE id = @id;
--END
--GO
--===============================================

--CREATE PROCEDURE sp_Book_Delete
--    @id INT
--AS
--BEGIN
--    DELETE FROM Books
--    WHERE id = @id;
--END
--GO
--=================================================
CREATE PROCEDURE [dbo].[sp_Book_Get]
AS
BEGIN
    SELECT id, title, author, isbn, publishedDate, price, quantity
    FROM Books;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Book_Update]    Script Date: 7/17/2024 9:32:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Create Table Books
--(
--id int IDENTITY(1,1) PRIMARY KEY,
--title varchar(200),
--author varchar(200),
--isbn varchar(10),
--publishedDate DATE ,
--price MONEY,
--quantity int
--);
--===============================================
--CREATE PROCEDURE sp_Book_Create
--    @title VARCHAR(200),
--    @author VARCHAR(200),
--    @isbn VARCHAR(10),
--    @publishedDate DATE,
--    @price MONEY,
--    @quantity INT,
--    @newId INT OUTPUT  
--AS
--BEGIN
--    INSERT INTO Books (title, author, isbn, publishedDate, price, quantity)
--    VALUES (@title, @author, @isbn, @publishedDate, @price, @quantity);

--    SET @newId = SCOPE_IDENTITY();  
--END
--GO
--=================================================
CREATE PROCEDURE [dbo].[sp_Book_Update]
    @id INT,
    @title VARCHAR(200),
    @author VARCHAR(200),
    @isbn VARCHAR(10),
    @publishedDate DATE,
    @price MONEY,
    @quantity INT
AS
BEGIN
    UPDATE Books
    SET title = @title,
        author = @author,
        isbn = @isbn,
        publishedDate = @publishedDate,
        price = @price,
        quantity = @quantity
    WHERE id = @id;
END
GO
