USE [2mmanga]
GO
/****** Object:  StoredProcedure [dbo].[sp_Cart_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Cart_Delete]
    @FK_ProductId UNIQUEIDENTIFIER ,
    @FK_UserId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.[Cart]
        WHERE   FK_ProductId = @FK_ProductId
                AND FK_UserId = @FK_UserId
     
    END



GO
/****** Object:  StoredProcedure [dbo].[sp_Cart_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Cart_InsertOrUpdate]
    @FK_ProductId UNIQUEIDENTIFIER ,
    @Quantity INT ,
    @FK_UserId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [FK_ProductId]
                    FROM    [Cart]
                    WHERE   FK_ProductId = @FK_ProductId
                            AND FK_UserId = @FK_UserId )
            BEGIN
                UPDATE  [Cart]
                SET     Quantity = @Quantity
                WHERE   FK_ProductId = @FK_ProductId
                        AND FK_UserId = @FK_UserId
            END
        ELSE
            BEGIN
                INSERT  INTO [Cart]
                        ( FK_ProductId ,
                          Quantity ,
                          FK_UserId
                        )
                VALUES  ( @FK_ProductId ,
                          @Quantity ,
                          @FK_UserId
                        )
            END
    END

GO
/****** Object:  StoredProcedure [dbo].[sp_Category_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Category_Delete] @PK_CategoryId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.Category
        WHERE   PK_CategoryId = @PK_CategoryId
     
    END


GO
/****** Object:  StoredProcedure [dbo].[sp_Category_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Category_InsertOrUpdate]
    @PK_CategoryId UNIQUEIDENTIFIER ,
    @Name NVARCHAR(100)
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [PK_CategoryId]
                    FROM    [Category]
                    WHERE   PK_CategoryId = @PK_CategoryId )
            BEGIN
                UPDATE  [Category]
                SET     Name = @Name
                WHERE   PK_CategoryId = @PK_CategoryId;
            END
        ELSE
            BEGIN
                INSERT  INTO [Category]
                        ( PK_CategoryId, Name )
                VALUES  ( @PK_CategoryId, @Name )
            END
    END

GO
/****** Object:  StoredProcedure [dbo].[sp_Order_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Order_Delete] @PK_OrderId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.[Order]
        WHERE   PK_OrderId = @PK_OrderId
     
    END


GO
/****** Object:  StoredProcedure [dbo].[sp_Order_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Order_InsertOrUpdate]
    @PK_OrderId UNIQUEIDENTIFIER ,
    @FK_UserId UNIQUEIDENTIFIER ,
    @Phone NCHAR(100) ,
    @Address NVARCHAR(512) ,
    @TotalPrice INT ,
    @Status INT ,
    @IsCancel BIT
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [PK_OrderId]
                    FROM    [Order]
                    WHERE   PK_OrderId = @PK_OrderId )
            BEGIN
                UPDATE  [Order]
                SET     [FK_UserId] = @FK_UserId ,
                        [Phone] = @Phone ,
                        [Address] = @Address ,
                        [TotalPrice] = @TotalPrice ,
                        [Status] = @Status ,
                        [IsCancel] = @IsCancel
                WHERE   PK_OrderId = @PK_OrderId
            END
        ELSE
            BEGIN
                INSERT  INTO [Order]
                        ( [PK_OrderId] ,
                          [FK_UserId] ,
                          [Phone] ,
                          [Address] ,
                          [TotalPrice] ,
                          [Status] ,
                          [IsCancel] 
                        )
                VALUES  ( @PK_OrderId ,
                          @FK_UserId ,
                          @Phone ,
                          @Address ,
                          @TotalPrice ,
                          @Status ,
                          @IsCancel
                        )
            END
    END


GO
/****** Object:  StoredProcedure [dbo].[sp_OrderProduct_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderProduct_Delete]
    @FK_OrderId UNIQUEIDENTIFIER ,
    @FK_ProductId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.[OrderProduct]
        WHERE   FK_OrderId = @FK_OrderId
                AND FK_ProductId = @FK_ProductId
     
    END



GO
/****** Object:  StoredProcedure [dbo].[sp_OrderProduct_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_OrderProduct_InsertOrUpdate]
    @FK_OrderId UNIQUEIDENTIFIER ,
    @FK_ProductId UNIQUEIDENTIFIER ,
    @Quantity INT ,
    @Price INT ,
    @Discount INT ,
    @Payments INT
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [FK_OrderId]
                    FROM    [OrderProduct]
                    WHERE   FK_OrderId = @FK_OrderId
                            AND FK_ProductId = @FK_ProductId )
            BEGIN
                UPDATE  [OrderProduct]
                SET     Quantity = @Quantity ,
                        Price = @Price ,
                        Discount = @Discount ,
                        Payments = @Payments
                WHERE   FK_OrderId = @FK_OrderId
                        AND FK_ProductId = @FK_ProductId
            END
        ELSE
            BEGIN
                INSERT  INTO [OrderProduct]
                        ( FK_OrderId ,
                          FK_ProductId ,
                          Quantity ,
                          Price ,
                          Discount ,
                          Payments
                        )
                VALUES  ( @FK_OrderId ,
                          @FK_ProductId ,
                          @Quantity ,
                          @Price ,
                          @Discount ,
                          @Payments
                        )
            END
    END

GO
/****** Object:  StoredProcedure [dbo].[sp_Product_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Product_Delete] @PK_ProductId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.Product
        WHERE   PK_ProductId = @PK_ProductId
     
    END


GO
/****** Object:  StoredProcedure [dbo].[sp_Product_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Product_InsertOrUpdate]
    @PK_ProductId UNIQUEIDENTIFIER ,
    @Name NVARCHAR(512) ,
    @TagName VARCHAR(512) ,
    @SignName VARCHAR(512) ,
    @Images VARCHAR(MAX) ,
    @Quantity INT ,
    @Price INT ,
    @Discount INT ,
    @Weight INT ,
    @Details NTEXT ,
    @BarCode VARCHAR(50) ,
    @SapoCode VARCHAR(50) ,
    @FK_PublishedId UNIQUEIDENTIFIER ,
    @FK_CategoryId UNIQUEIDENTIFIER ,
    @ReleaseDate DATETIME ,
    @CreatedDate DATETIME ,
    @IsSoldAll BIT
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [PK_ProductId]
                    FROM    [Product]
                    WHERE   PK_ProductId = @PK_ProductId )
            BEGIN
                UPDATE  [Product]
                SET     [Name] = @Name ,
                        [TagName] = @TagName ,
                        [SignName] = @SignName ,
                        [Images] = @Images ,
                        [Quantity] = @Quantity ,
                        [Price] = @Price ,
                        [Discount] = @Discount ,
                        [Weight] = @Weight ,
                        [Details] = @Details ,
                        [BarCode] = @BarCode ,
                        [SapoCode] = @SapoCode ,
                        [FK_PublishedId] = @FK_PublishedId ,
                        [FK_CategoryId] = @FK_CategoryId ,
                        [ReleaseDate] = @ReleaseDate ,
                        [IsSoldAll] = @IsSoldAll
                WHERE   PK_ProductId = @PK_ProductId
            END
        ELSE
            BEGIN
                INSERT  INTO [Product]
                        ( [PK_ProductId] ,
                          [Name] ,
                          [TagName] ,
                          [SignName] ,
                          [Images] ,
                          [Quantity] ,
                          [Price] ,
                          [Discount] ,
                          [Weight] ,
                          [Details] ,
                          [BarCode] ,
                          [SapoCode] ,
                          [FK_PublishedId] ,
                          [FK_CategoryId] ,
                          [ReleaseDate] ,
                          [CreatedDate] ,
                          [IsSoldAll]
                        )
                VALUES  ( @PK_ProductId ,
                          @Name ,
                          @TagName ,
                          @SignName ,
                          @Images ,
                          @Quantity ,
                          @Price ,
                          @Discount ,
                          @Weight ,
                          @Details ,
                          @BarCode ,
                          @SapoCode ,
                          @FK_PublishedId ,
                          @FK_CategoryId ,
                          @ReleaseDate ,
                          @CreatedDate ,
                          @IsSoldAll
                        )
            END


        
    END


GO
/****** Object:  StoredProcedure [dbo].[sp_Published_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Published_Delete] @PK_PublishedId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.Published
        WHERE   PK_PublishedId = @PK_PublishedId
     
    END



GO
/****** Object:  StoredProcedure [dbo].[sp_Published_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Published_InsertOrUpdate]
    @PK_PublishedId UNIQUEIDENTIFIER ,
    @Name NVARCHAR(100)
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [PK_PublishedId]
                    FROM    [Published]
                    WHERE   PK_PublishedId = @PK_PublishedId )
            BEGIN
                UPDATE  [Published]
                SET     Name = @Name
                WHERE   PK_PublishedId = @PK_PublishedId;
            END
        ELSE
            BEGIN
                INSERT  INTO [Published]
                        ( PK_PublishedId, Name )
                VALUES  ( @PK_PublishedId, @Name )
            END
    END



GO
/****** Object:  StoredProcedure [dbo].[sp_User_Delete]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_Delete] @PK_UserId UNIQUEIDENTIFIER
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        DELETE  FROM dbo.[User]
        WHERE   PK_UserId = @PK_UserId
     
    END



GO
/****** Object:  StoredProcedure [dbo].[sp_User_InsertOrUpdate]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_User_InsertOrUpdate]
    @PK_UserId UNIQUEIDENTIFIER ,
    @Name NVARCHAR(100) ,
    @UserName NCHAR(100) ,
    @Password NVARCHAR(MAX) ,
    @Phone NCHAR(100) ,
    @Address NVARCHAR(512) ,
    @CreatedDate DATETIME ,
    @UpdatedDate DATETIME ,
    @Active BIT ,
    @PermissionId INT
AS
    BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
        SET NOCOUNT ON;

        IF EXISTS ( SELECT  [PK_UserId]
                    FROM    [User]
                    WHERE   PK_UserId = @PK_UserId )
            BEGIN
                UPDATE  [User]
                SET     [Name] = @Name ,
                        [UserName] = @UserName ,
                        [Password] = @Password ,
                        [Phone] = @Phone ,
                        [Address] = @Address ,
                        [UpdatedDate] = @UpdatedDate ,
                        [Active] = @Active ,
                        [PermissionId] = @PermissionId
                WHERE   [PK_UserId] = @PK_UserId
            END
        ELSE
            BEGIN
                INSERT  INTO [User]
                        ( [PK_UserId] ,
                          [Name] ,
                          [UserName] ,
                          [Password] ,
                          [Phone] ,
                          [Address] ,
                          [CreatedDate] ,
                          [Active] ,
                          [PermissionId]
                        )
                VALUES  ( @PK_UserId ,
                          @Name ,
                          @UserName ,
                          @Password ,
                          @Phone ,
                          @Address ,
                          @CreatedDate ,
                          @Active ,
                          @PermissionId
                        )
            END
    END


GO
/****** Object:  Table [dbo].[Cart]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[FK_ProductId] [uniqueidentifier] NULL,
	[Quantity] [int] NULL,
	[FK_UserId] [uniqueidentifier] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Category]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[PK_CategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED 
(
	[PK_CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[PK_OrderId] [uniqueidentifier] NOT NULL,
	[FK_UserId] [uniqueidentifier] NULL,
	[Phone] [nchar](100) NULL,
	[Address] [nvarchar](512) NULL,
	[TotalPrice] [int] NULL,
	[Status] [int] NULL,
	[IsCancel] [bit] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[PK_OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[FK_OrderId] [uniqueidentifier] NOT NULL,
	[FK_ProductId] [uniqueidentifier] NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[Discount] [int] NULL,
	[Payments] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
	[PK_ProductId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](512) NULL,
	[TagName] [varchar](512) NULL,
	[SignName] [varchar](512) NULL,
	[Images] [nvarchar](max) NULL,
	[Quantity] [int] NULL,
	[Price] [int] NULL,
	[Discount] [int] NULL,
	[Weight] [int] NULL,
	[Details] [ntext] NULL,
	[BarCode] [varchar](50) NULL,
	[SapoCode] [varchar](50) NULL,
	[FK_PublishedId] [uniqueidentifier] NULL,
	[FK_CategoryId] [uniqueidentifier] NULL,
	[ReleaseDate] [datetime] NULL,
	[CreatedDate] [datetime] NULL,
	[IsSoldAll] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PK_ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Published]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Published](
	[PK_PublishedId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Published_1] PRIMARY KEY CLUSTERED 
(
	[PK_PublishedId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/4/2024 5:46:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[PK_UserId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NULL,
	[UserName] [nchar](100) NULL,
	[Password] [nvarchar](max) NULL,
	[Phone] [nchar](100) NULL,
	[Address] [nvarchar](512) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[Active] [bit] NULL,
	[PermissionId] [int] NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[PK_UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
