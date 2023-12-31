
GO
ALTER DATABASE [BuildMe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BuildMe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BuildMe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BuildMe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BuildMe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BuildMe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BuildMe] SET ARITHABORT OFF 
GO
ALTER DATABASE [BuildMe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BuildMe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BuildMe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BuildMe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BuildMe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BuildMe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BuildMe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BuildMe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BuildMe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BuildMe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BuildMe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BuildMe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BuildMe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BuildMe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BuildMe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BuildMe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BuildMe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BuildMe] SET RECOVERY FULL 
GO
ALTER DATABASE [BuildMe] SET  MULTI_USER 
GO
ALTER DATABASE [BuildMe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BuildMe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BuildMe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BuildMe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BuildMe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BuildMe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BuildMe', N'ON'
GO
ALTER DATABASE [BuildMe] SET QUERY_STORE = OFF
GO
USE [BuildMe]
GO
/****** Object:  Table [dbo].[Cities]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[VAT] [nvarchar](20) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
	[NumberMonthlyJobs] [int] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Company_VAT] UNIQUE NONCLUSTERED 
(
	[VAT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyBudgets]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyBudgets](
	[TaskId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Value] [float] NOT NULL,
	[IsRejected] [bit] NULL,
 CONSTRAINT [PK_CompanyBudgets] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC,
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyCities]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyCities](
	[CompanyId] [int] NOT NULL,
	[CityId] [int] NOT NULL,
 CONSTRAINT [PK_CompanyCities] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyJobTypes]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyJobTypes](
	[CompanyId] [int] NOT NULL,
	[JobTypesId] [int] NOT NULL,
	[AveragePrice] [float] NOT NULL,
 CONSTRAINT [PK_CompanyJobTypes] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC,
	[JobTypesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JobTypes]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JobTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_JobTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meetings]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meetings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Date] [datetime] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[UserId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[MeetingStatusId] [int] NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Meetings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MeetingStatus]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MeetingStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_MeetingStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[CityId] [int] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[DateBiddingStart] [datetime] NOT NULL,
	[DateBiddingEnd] [datetime] NOT NULL,
	[TaskStatusId] [int] NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_TaskStatuts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[VAT] [nvarchar](20) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[PostalCode] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NOT NULL,
	[CompanyId] [int] NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTypes]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
	[Inactive] [bit] NOT NULL,
	[LastUpdate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Cities] CHECK CONSTRAINT [FK_Cities_CountryId]
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD  CONSTRAINT [Fk1_Company_CountryId] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Companies] CHECK CONSTRAINT [Fk1_Company_CountryId]
GO
ALTER TABLE [dbo].[CompanyBudgets]  WITH CHECK ADD  CONSTRAINT [FK_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyBudgets] CHECK CONSTRAINT [FK_Company]
GO
ALTER TABLE [dbo].[CompanyBudgets]  WITH CHECK ADD  CONSTRAINT [FK_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Tasks] ([Id])
GO
ALTER TABLE [dbo].[CompanyBudgets] CHECK CONSTRAINT [FK_Task]
GO
ALTER TABLE [dbo].[CompanyCities]  WITH CHECK ADD  CONSTRAINT [FK_CompanyCities_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[CompanyCities] CHECK CONSTRAINT [FK_CompanyCities_CityId]
GO
ALTER TABLE [dbo].[CompanyCities]  WITH CHECK ADD  CONSTRAINT [FK_CompanyCities_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyCities] CHECK CONSTRAINT [FK_CompanyCities_CompanyId]
GO
ALTER TABLE [dbo].[CompanyJobTypes]  WITH CHECK ADD  CONSTRAINT [FK1_CompanyJobTypes_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[CompanyJobTypes] CHECK CONSTRAINT [FK1_CompanyJobTypes_CompanyId]
GO
ALTER TABLE [dbo].[CompanyJobTypes]  WITH CHECK ADD  CONSTRAINT [FK2_CompanyJobTypes_JobTypesId] FOREIGN KEY([JobTypesId])
REFERENCES [dbo].[JobTypes] ([Id])
GO
ALTER TABLE [dbo].[CompanyJobTypes] CHECK CONSTRAINT [FK2_CompanyJobTypes_JobTypesId]
GO
ALTER TABLE [dbo].[Meetings]  WITH CHECK ADD  CONSTRAINT [FK_Meetings_Company] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Meetings] CHECK CONSTRAINT [FK_Meetings_Company]
GO
ALTER TABLE [dbo].[Meetings]  WITH CHECK ADD  CONSTRAINT [FK_Meetings_MeetingStatus] FOREIGN KEY([MeetingStatusId])
REFERENCES [dbo].[MeetingStatus] ([Id])
GO
ALTER TABLE [dbo].[Meetings] CHECK CONSTRAINT [FK_Meetings_MeetingStatus]
GO
ALTER TABLE [dbo].[Meetings]  WITH CHECK ADD  CONSTRAINT [FK_Meetings_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Meetings] CHECK CONSTRAINT [FK_Meetings_Users]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_TaskStatusId] FOREIGN KEY([TaskStatusId])
REFERENCES [dbo].[TaskStatus] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_TaskStatusId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Users_CityId] FOREIGN KEY([CityId])
REFERENCES [dbo].[Cities] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Users_CityId]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_CompanyId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserTypes] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_UserTypes]
GO
/****** Object:  StoredProcedure [dbo].[CityDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CityDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM Cities WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Cities WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Cities SET 
    [Inactive] = CAST('TRUE' AS bit),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CityInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CityInsert01]
(@Description nvarchar(50),
@CountryId int)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Cities([Description], [CountryId], [Inactive], [LastUpdate])
    VALUES (@Description, @CountryId, CAST('false' AS bit), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CityUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CityUpdate01]
(@Id int,
@Description nvarchar(50),
@CountryId int,
@Inactive bit,
@LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    IF (SELECT COUNT(1) FROM Cities WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Cities WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Cities SET 
    [Description] = @Description,
    [CountryId] = @CountryId,
	[Inactive] = @Inactive,
    [LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END



GO
/****** Object:  StoredProcedure [dbo].[CompanyBudgetDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyBudgetDelete01]
(@CompanyId int,
@TaskId int)
AS
BEGIN 
    DELETE FROM CompanyBudgets
    WHERE [TaskId] = @TaskId AND [CompanyId] = @CompanyId

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyBudgetInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyBudgetInsert01]
(@TaskId int,
@CompanyId int,
@Value float,
@IsRejected bit)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO CompanyBudgets([CompanyId], [TaskId], [Value], [IsRejected])
    VALUES (@CompanyId, @TaskId, @Value, @IsRejected);

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyBudgetUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyBudgetUpdate01]
    (@TaskId int,
     @CompanyId int,
     @Value float,
     @IsRejected bit)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM CompanyBudgets WHERE CompanyId = @CompanyId AND TaskId = @TaskId) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE CompanyBudgets SET 
        [Value] = @Value,
        [IsRejected] = @IsRejected
    WHERE TaskId = @TaskId AND CompanyId = @CompanyId
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyCityDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyCityDelete01]
(@CompanyId int,
@CityId int)
AS
BEGIN 
    DELETE FROM CompanyCities
    WHERE [CityId] = @CityId AND [CompanyId] = @CompanyId

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyCityInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyCityInsert01]
(@CompanyId int,
@CityId int)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO CompanyCities([CompanyId], [CityId])
    VALUES (@CityId, @CityId);

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyCityUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyCityUpdate01]
    (@CompanyId int,
     @CityId int)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM CompanyCities WHERE CompanyId = @CompanyId AND CityId = @CityId) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE CompanyCities SET 
	[CityId] = @CityId,
	[CompanyId] = @CompanyId
    WHERE CityId = @CityId AND CompanyId = @CompanyId
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM Companies WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Companies WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Companies SET 
    [Name] = 'forgotten_' + [Name],
    [Address] = 'forgotten_' + [Address],
    [VAT] = 'forgotten_' + [VAT],
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyInsert01]
(@Name nvarchar(50),
@Address nvarchar(50),
@VAT nvarchar(50),
@NumberMonthlyJobs int,
@CountryId int)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Companies([Name], [Address], [VAT], [NumberMonthlyJobs], [CountryId], [Inactive], [LastUpdate])
    VALUES (@Name, @Address, @VAT, @NumberMonthlyJobs, @CountryId, CAST('FALSE' AS BIT) , GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyJobTypeDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyJobTypeDelete01]
(@CompanyId int,
@JobTypesId int)
AS
BEGIN 
    DELETE FROM CompanyJobTypes
    WHERE [JobTypesId] = @JobTypesId AND [CompanyId] = @CompanyId

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyJobTypeInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyJobTypeInsert01]
(@CompanyId int,
@JobTypeId int,
@AveragePrice float)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO CompanyJobTypes([CompanyId], [JobTypesId], [AveragePrice])
    VALUES (@CompanyId, @JobTypeId, @AveragePrice);

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyJobTypeUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyJobTypeUpdate01]
    (@CompanyId int,
     @JobTypesId int,
	 @AveragePrice float)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM CompanyJobTypes WHERE CompanyId = @CompanyId AND JobTypesId = @JobTypesId) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE CompanyJobTypes SET 
	[JobTypesId] = @JobTypesId,
	[CompanyId] = @CompanyId,
	[AveragePrice] = @AveragePrice
    WHERE JobTypesId = @JobTypesId AND CompanyId = @CompanyId
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CompanyUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompanyUpdate01]
(@Id int,
@Name nvarchar(50),
@Address nvarchar(50),
@VAT nvarchar(50),
@NumberMonthlyJobs int,
@CountryId int,
@Inactive bit,
@LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    IF (SELECT COUNT(1) FROM Companies WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Companies WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Companies SET 
    [Name] = @Name,
    [Address] = @Address,
    [VAT] = @VAT,
	[NumberMonthlyJobs] = @NumberMonthlyJobs,
    [CountryId] = @CountryId,
    [Inactive] = @Inactive,
    [LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CountryDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountryDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM Countries WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Countries WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Countries SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CountryInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountryInsert01]
(@Description nvarchar(50))
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Countries([Description], [Inactive], [LastUpdate])
    VALUES (@Description, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CountryUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountryUpdate01]
    (@Id int,
     @Description nvarchar(50),
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM Countries WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM Countries WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Countries SET 
	[Description] = @Description,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[JobtypeDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[JobtypeDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM JobTypes WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM JobTypes WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE JobTypes SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[JobTypeInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[JobTypeInsert01]
(@Description nvarchar(50))
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO JobTypes([Description], [Inactive], [LastUpdate])
    VALUES (@Description,CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[JobTypeUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[JobTypeUpdate01]
    (@Id int,
     @Description nvarchar(50),
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM JobTypes WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM JobTypes WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE JobTypes SET 
	[Description] = @Description,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[MeetingDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MeetingDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM Meetings WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Meetings WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Meetings SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[MeetingInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MeetingInsert01]
(@Description nvarchar(50),
@Date datetime,
@Notes  nvarchar(50),
@UserId int,
@CompanyId int,
@MeetingStatusId int)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Meetings([Description], [Date], [Notes], [UserId], [CompanyId], [MeetingStatusId], [Inactive], [LastUpdate])
    VALUES (@Description, @Date, @Notes, @UserId, @CompanyId, @MeetingStatusId, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[MeetingStatusDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MeetingStatusDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM MeetingStatus WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM MeetingStatus WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE MeetingStatus SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[MeetingStatusInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MeetingStatusInsert01]
(@Description nvarchar(50))
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO MeetingStatus([Description], [Inactive], [LastUpdate])
    VALUES (@Description, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[MeetingStatusUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MeetingStatusUpdate01]
    (@Id int,
     @Description nvarchar(50),
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM MeetingStatus WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM MeetingStatus WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE MeetingStatus SET 
	[Description] = @Description,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[MeetingUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MeetingUpdate01]
    (@Id int,
     @Description nvarchar(50),
	 @Date datetime,
	 @Notes nvarchar(50),
	 @UserId int,
	 @CompanyId int,
	 @MeetingStatusId int,
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM Meetings WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM Meetings WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END


    UPDATE Meetings SET 
	[Description] = @Description,
	[Date] = @Date,
	[Notes] = @Notes,
	[UserId] = UserId,
	[CompanyId] = @CompanyId,
	[MeetingStatusId] = @MeetingStatusId,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[TaskDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM Tasks WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Tasks WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Tasks SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[TaskInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskInsert01]
(@UserId int,
@Description  nvarchar(50),
@CityId int,
@DateStart datetime,
@DateEnd datetime,
@DateBiddingStart datetime,
@DateBiddingEnd datetime,
@TaskStatusId int)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Tasks([UserId], [Description], [CityId], [DateStart], [DateEnd], [DateBiddingStart], [DateBiddingEnd], [TaskStatusId], [Inactive], [LastUpdate])
    VALUES (@UserId, @Description, @CityId, @DateStart, @DateEnd, @DateBiddingStart, @DateBiddingEnd, @TaskStatusId, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[TaskStatusDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskStatusDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM TaskStatus WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM TaskStatus WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE TaskStatus SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[TaskStatusInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskStatusInsert01]
(@Description  nvarchar(50))
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Tasks([Description], [Inactive], [LastUpdate])
    VALUES (@Description, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[TaskStatusUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskStatusUpdate01]
    (@Id int,
	 @Description nvarchar(50),
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM TaskStatus WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM TaskStatus WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE TaskStatus SET 
	[Description] = @Description,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[TaskUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TaskUpdate01]
    (@Id int,
	 @UserId int,
     @Description nvarchar(50),
	 @CityId int,
	 @DateStart datetime,
	 @DateEnd datetime,
	 @DateBiddingStart datetime,
	 @DateBiddingEnd datetime,
	 @TakeStatusId int,
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM Tasks WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM Tasks WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Tasks SET 
	[UserId] = @UserId,
	[Description] = @Description,
	[CityId] = @CityId,
	[DateStart] = @DateStart,
	[DateEnd] = @DateEnd,
	[DateBiddingStart] = @DateBiddingStart,
	[DateBiddingEnd] = @DateBiddingEnd,
	[TaskStatusId] = @TakeStatusId,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[UserDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM Users WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Users WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Users SET 
    [UserName] = 'forgotten_' + [UserName],
    [Email] = 'forgotten_' + [Email],
    [Address] = 'forgotten_' + [Address],
    [Phone] = 'forgotten_' + [Phone],
    [PostalCode] = 'forgotten_' + [PostalCode],
    [VAT] = 'forgotten_' + [VAT],
    [Inactive] = CAST('TRUE' AS bit),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[UserInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserInsert01]
(@UserName nvarchar(100),
@Password nvarchar(100),
@UserTypeId int,
@VAT nvarchar(20),
@Phone nvarchar(50),
@Address nvarchar(200),
@PostalCode nvarchar(20),
@Email nvarchar(50),
@CompanyId int = null)
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO Users([UserName], [Password], [UserTypeId], [VAT], [Phone], [Address], [PostalCode], [Email], [CompanyId], [Inactive], [LastUpdate])
    VALUES (@UserName, @Password, @UserTypeId, @VAT, @Phone, @Address, @PostalCode, @Email, @CompanyId, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END

GO
/****** Object:  StoredProcedure [dbo].[UserTypeDelete01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserTypeDelete01]
(@Id int, 
@LastUpdate datetime)
AS
BEGIN 
    IF (SELECT COUNT(1) FROM dbo.UserTypes WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM dbo.UserTypes WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE dbo.UserTypes SET 
    [Inactive] = CAST('TRUE' AS BIT),
    [LastUpdate] = GETDATE()
    WHERE Id = @Id

    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[UserTypeInsert01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserTypeInsert01]
(@Description  nvarchar(50))
AS
BEGIN 
    DECLARE @return_value int;

    INSERT INTO UserTypes([Description], [Inactive], [LastUpdate])
    VALUES (@Description, CAST('FALSE' AS BIT), GETDATE());

    SELECT SCOPE_IDENTITY();

    RETURN 1;
END
GO
/****** Object:  StoredProcedure [dbo].[UserTypeUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserTypeUpdate01]
    (@Id int,
	 @Description nvarchar(50),
	 @Inactive bit,
	 @LastUpdate datetime)
AS
BEGIN 
    DECLARE @return_value int;

    If (SELECT COUNT(1) FROM UserTypes WHERE Id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

	 IF (SELECT LastUpdate FROM UserTypes WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE UserTypes SET 
	[Description] = @Description,
	[Inactive] = @Inactive,
	[LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END
GO
/****** Object:  StoredProcedure [dbo].[UserUpdate01]    Script Date: 07/05/2023 23:52:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserUpdate01]
(@Id int,
@UserName nvarchar(50),
@Password nvarchar(50),
@UserTypeId int,
@VAT nvarchar(50),
@Phone nvarchar(50),
@Address nvarchar(50),
@PostalCode nvarchar(50),
@Email nvarchar(50),
@LastUpdate datetime,
@CompanyId int = null)
AS
BEGIN 
    DECLARE @return_value int;

    IF (SELECT COUNT(1) FROM Users WHERE id = @Id) = 0
    BEGIN
        SELECT 0
        RETURN
    END

    IF (SELECT LastUpdate FROM Users WHERE id = @Id) <> @LastUpdate
    BEGIN
        SELECT 0
        RETURN
    END

    UPDATE Users SET 
    [UserName] = @UserName,
    [Password] = 
	CASE  
		WHEN @Password IS NOT NULL AND @Password <> '' 
		THEN @Password
		ELSE [Password]
	END,
    [UserTypeId] = @UserTypeId,
    [VAT] = @VAT,
    [Phone] = @Phone,
    [Address] = @Address,
    [PostalCode] = @PostalCode,
    [Email] = @Email,
    [CompanyId] = @CompanyId,
    [LastUpdate] = GETDATE()
    WHERE Id = @Id
    
    SELECT 1;
END

GO
USE [master]
GO
ALTER DATABASE [BuildMe] SET  READ_WRITE 
GO
