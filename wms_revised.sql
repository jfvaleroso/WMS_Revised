USE [master]
GO
/****** Object:  Database [WMS]    Script Date: 02/10/2014 04:50:34 ******/
CREATE DATABASE [WMS] ON  PRIMARY 
( NAME = N'WMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.DOGBERT\MSSQL\DATA\WMS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.DOGBERT\MSSQL\DATA\WMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [WMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [WMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [WMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [WMS] SET ARITHABORT OFF
GO
ALTER DATABASE [WMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [WMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [WMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [WMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [WMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [WMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [WMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [WMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [WMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [WMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [WMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [WMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [WMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [WMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [WMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [WMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [WMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [WMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [WMS] SET  READ_WRITE
GO
ALTER DATABASE [WMS] SET RECOVERY FULL
GO
ALTER DATABASE [WMS] SET  MULTI_USER
GO
ALTER DATABASE [WMS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [WMS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'WMS', N'ON'
GO
USE [WMS]
GO
/****** Object:  Table [dbo].[StatusMapping]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusMapping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Node_Id] [bigint] NULL,
	[IfApproved] [int] NULL,
	[IfDisapproved] [int] NULL,
	[IfReturned] [int] NULL,
	[IfCancelled] [int] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_StatusMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Process]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Process](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SystemCode] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_Process] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ApiUser]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApiUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NULL,
	[Secret] [nvarchar](100) NULL,
	[AppId] [nvarchar](50) NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_ApiUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActivityLogs]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLogs](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](80) NULL,
	[Description] [nvarchar](500) NULL,
	[Timestamp] [datetime] NULL,
	[ExecutedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_ActivityLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_WorkflowMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workflow]    Script Date: 02/10/2014 04:50:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workflow](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Version] [int] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_Workflow] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[truncate_non_empty_table]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[truncate_non_empty_table]

  @TableToTruncate                 VARCHAR(64)

AS 

BEGIN

SET NOCOUNT ON

-- GLOBAL VARIABLES
DECLARE @i int
DECLARE @Debug bit
DECLARE @Recycle bit
DECLARE @Verbose bit
DECLARE @TableName varchar(80)
DECLARE @ColumnName varchar(80)
DECLARE @ReferencedTableName varchar(80)
DECLARE @ReferencedColumnName varchar(80)
DECLARE @ConstraintName varchar(250)

DECLARE @CreateStatement varchar(max)
DECLARE @DropStatement varchar(max)   
DECLARE @TruncateStatement varchar(max)
DECLARE @CreateStatementTemp varchar(max)
DECLARE @DropStatementTemp varchar(max)
DECLARE @TruncateStatementTemp varchar(max)
DECLARE @Statement varchar(max)

        -- 1 = Will not execute statements 
 SET @Debug = 0
        -- 0 = Will not create or truncate storage table
        -- 1 = Will create or truncate storage table
 SET @Recycle = 0
        -- 1 = Will print a message on every step
 set @Verbose = 1

 SET @i = 1
    SET @CreateStatement = 'ALTER TABLE [dbo].[<tablename>]  WITH NOCHECK ADD  CONSTRAINT [<constraintname>] FOREIGN KEY([<column>]) REFERENCES [dbo].[<reftable>] ([<refcolumn>])'
    SET @DropStatement = 'ALTER TABLE [dbo].[<tablename>] DROP CONSTRAINT [<constraintname>]'
    SET @TruncateStatement = 'TRUNCATE TABLE [<tablename>]'

-- Drop Temporary tables

IF OBJECT_ID('tempdb..#FKs') IS NOT NULL
    DROP TABLE #FKs

-- GET FKs
SELECT ROW_NUMBER() OVER (ORDER BY OBJECT_NAME(parent_object_id), clm1.name) as ID,
       OBJECT_NAME(constraint_object_id) as ConstraintName,
       OBJECT_NAME(parent_object_id) as TableName,
       clm1.name as ColumnName, 
       OBJECT_NAME(referenced_object_id) as ReferencedTableName,
       clm2.name as ReferencedColumnName
  INTO #FKs
  FROM sys.foreign_key_columns fk
       JOIN sys.columns clm1 
         ON fk.parent_column_id = clm1.column_id 
            AND fk.parent_object_id = clm1.object_id
       JOIN sys.columns clm2
         ON fk.referenced_column_id = clm2.column_id 
            AND fk.referenced_object_id= clm2.object_id
 --WHERE OBJECT_NAME(parent_object_id) not in ('//tables that you do not wont to be truncated')
 WHERE OBJECT_NAME(referenced_object_id) = @TableToTruncate
 ORDER BY OBJECT_NAME(parent_object_id)


-- Prepare Storage Table
IF Not EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Internal_FK_Definition_Storage')
   BEGIN
        IF @Verbose = 1
     PRINT '1. Creating Process Specific Tables...'

  -- CREATE STORAGE TABLE IF IT DOES NOT EXISTS
  CREATE TABLE [Internal_FK_Definition_Storage] 
  (
   ID int not null identity(1,1) primary key,
   FK_Name varchar(250) not null,
   FK_CreationStatement varchar(max) not null,
   FK_DestructionStatement varchar(max) not null,
   Table_TruncationStatement varchar(max) not null
  ) 
   END 
ELSE
   BEGIN
        IF @Recycle = 0
            BEGIN
                IF @Verbose = 1
       PRINT '1. Truncating Process Specific Tables...'

    -- TRUNCATE TABLE IF IT ALREADY EXISTS
    TRUNCATE TABLE [Internal_FK_Definition_Storage]    
      END
      ELSE
         PRINT '1. Process specific table will be recycled from previous execution...'
   END


IF @Recycle = 0
   BEGIN

  IF @Verbose = 1
     PRINT '2. Backing up Foreign Key Definitions...'

  -- Fetch and persist FKs             
  WHILE (@i <= (SELECT MAX(ID) FROM #FKs))
   BEGIN
    SET @ConstraintName = (SELECT ConstraintName FROM #FKs WHERE ID = @i)
    SET @TableName = (SELECT TableName FROM #FKs WHERE ID = @i)
    SET @ColumnName = (SELECT ColumnName FROM #FKs WHERE ID = @i)
    SET @ReferencedTableName = (SELECT ReferencedTableName FROM #FKs WHERE ID = @i)
    SET @ReferencedColumnName = (SELECT ReferencedColumnName FROM #FKs WHERE ID = @i)

    SET @DropStatementTemp = REPLACE(REPLACE(@DropStatement,'<tablename>',@TableName),'<constraintname>',@ConstraintName)
    SET @CreateStatementTemp = REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@CreateStatement,'<tablename>',@TableName),'<column>',@ColumnName),'<constraintname>',@ConstraintName),'<reftable>',@ReferencedTableName),'<refcolumn>',@ReferencedColumnName)
    SET @TruncateStatementTemp = REPLACE(@TruncateStatement,'<tablename>',@TableName) 

    INSERT INTO [Internal_FK_Definition_Storage]
                        SELECT @ConstraintName, @CreateStatementTemp, @DropStatementTemp, @TruncateStatementTemp

    SET @i = @i + 1

    IF @Verbose = 1
       PRINT '  > Backing up [' + @ConstraintName + '] from [' + @TableName + ']'

    END   
    END   
    ELSE 
       PRINT '2. Backup up was recycled from previous execution...'

       IF @Verbose = 1
     PRINT '3. Dropping Foreign Keys...'

    -- DROP FOREING KEYS
    SET @i = 1
    WHILE (@i <= (SELECT MAX(ID) FROM [Internal_FK_Definition_Storage]))
          BEGIN
             SET @ConstraintName = (SELECT FK_Name FROM [Internal_FK_Definition_Storage] WHERE ID = @i)
    SET @Statement = (SELECT FK_DestructionStatement FROM [Internal_FK_Definition_Storage] WITH (NOLOCK) WHERE ID = @i)

    IF @Debug = 1 
       PRINT @Statement
    ELSE
       EXEC(@Statement)

    SET @i = @i + 1


    IF @Verbose = 1
       PRINT '  > Dropping [' + @ConstraintName + ']'

             END     


    IF @Verbose = 1
       PRINT '4. Truncating Tables...'

    -- TRUNCATE TABLES
-- SzP: commented out as the tables to be truncated might also contain tables that has foreign keys
-- to resolve this the stored procedure should be called recursively, but I dont have the time to do it...          
 /*
    SET @i = 1
    WHILE (@i <= (SELECT MAX(ID) FROM [Internal_FK_Definition_Storage]))
          BEGIN

    SET @Statement = (SELECT Table_TruncationStatement FROM [Internal_FK_Definition_Storage] WHERE ID = @i)

    IF @Debug = 1 
       PRINT @Statement
    ELSE
       EXEC(@Statement)

    SET @i = @i + 1

    IF @Verbose = 1
       PRINT '  > ' + @Statement
          END
*/          


    IF @Verbose = 1
       PRINT '  > TRUNCATE TABLE [' + @TableToTruncate + ']'

    IF @Debug = 1 
        PRINT 'TRUNCATE TABLE [' + @TableToTruncate + ']'
    ELSE
        EXEC('TRUNCATE TABLE [' + @TableToTruncate + ']')


    IF @Verbose = 1
       PRINT '5. Re-creating Foreign Keys...'

    -- CREATE FOREING KEYS
    SET @i = 1
    WHILE (@i <= (SELECT MAX(ID) FROM [Internal_FK_Definition_Storage]))
          BEGIN
             SET @ConstraintName = (SELECT FK_Name FROM [Internal_FK_Definition_Storage] WHERE ID = @i)
    SET @Statement = (SELECT FK_CreationStatement FROM [Internal_FK_Definition_Storage] WHERE ID = @i)

    IF @Debug = 1 
       PRINT @Statement
    ELSE
       EXEC(@Statement)

    SET @i = @i + 1


    IF @Verbose = 1
       PRINT '  > Re-creating [' + @ConstraintName + ']'

          END

    IF @Verbose = 1
       PRINT '6. Process Completed'


END
GO
/****** Object:  Table [dbo].[SubProcess]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubProcess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Process_Id] [int] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_SubProcess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthToken]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthToken](
	[Id] [int] NOT NULL,
	[Token] [nvarchar](100) NULL,
	[Expiration] [datetime] NULL,
	[ApiUser_Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_AuthToken] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classification]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classification](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubProcess_Id] [int] NULL,
	[Code] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](200) NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_Classification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Node]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Node](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Workflow_Id] [bigint] NOT NULL,
	[Process_Id] [int] NULL,
	[SubProcess_Id] [int] NULL,
	[Classification_Id] [int] NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Node] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkflowMapping]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkflowMapping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Node_Id] [bigint] NULL,
	[LevelId] [int] NULL,
	[SLA] [int] NULL,
	[Operator] [nvarchar](10) NULL,
	[Assignee] [nvarchar](500) NULL,
	[AlertTo] [nvarchar](500) NULL,
	[SMSNotification] [bit] NULL,
	[EmailNotification] [bit] NULL,
	[Active] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_WorkflowMapping_2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationMapping]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationMapping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Node_Id] [bigint] NULL,
	[Status_Id] [int] NULL,
	[EmailContent] [nvarchar](max) NULL,
	[SMSContent] [nvarchar](500) NULL,
	[Active] [bit] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateCreated] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocumentMapping]    Script Date: 02/10/2014 04:50:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentMapping](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Node_Id] [bigint] NULL,
	[Document_Id] [int] NULL,
	[Active] [bit] NULL,
	[Mandatory] [bit] NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](80) NULL,
	[DateModified] [datetime] NULL,
	[ModifiedBy] [nvarchar](80) NULL,
 CONSTRAINT [PK_DocumentMapping] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_SubProcess_Process]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[SubProcess]  WITH NOCHECK ADD  CONSTRAINT [FK_SubProcess_Process] FOREIGN KEY([Process_Id])
REFERENCES [dbo].[Process] ([Id])
GO
ALTER TABLE [dbo].[SubProcess] CHECK CONSTRAINT [FK_SubProcess_Process]
GO
/****** Object:  ForeignKey [FK_AuthToken_AuthToken]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[AuthToken]  WITH CHECK ADD  CONSTRAINT [FK_AuthToken_AuthToken] FOREIGN KEY([ApiUser_Id])
REFERENCES [dbo].[ApiUser] ([Id])
GO
ALTER TABLE [dbo].[AuthToken] CHECK CONSTRAINT [FK_AuthToken_AuthToken]
GO
/****** Object:  ForeignKey [FK_Classification_SubProcess]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[Classification]  WITH CHECK ADD  CONSTRAINT [FK_Classification_SubProcess] FOREIGN KEY([SubProcess_Id])
REFERENCES [dbo].[SubProcess] ([Id])
GO
ALTER TABLE [dbo].[Classification] CHECK CONSTRAINT [FK_Classification_SubProcess]
GO
/****** Object:  ForeignKey [FK_Node_Classification]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_Classification] FOREIGN KEY([Classification_Id])
REFERENCES [dbo].[Classification] ([Id])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_Classification]
GO
/****** Object:  ForeignKey [FK_Node_Process]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_Process] FOREIGN KEY([Process_Id])
REFERENCES [dbo].[Process] ([Id])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_Process]
GO
/****** Object:  ForeignKey [FK_Node_SubProcess]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_SubProcess] FOREIGN KEY([SubProcess_Id])
REFERENCES [dbo].[SubProcess] ([Id])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_SubProcess]
GO
/****** Object:  ForeignKey [FK_Node_Workflow]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[Node]  WITH CHECK ADD  CONSTRAINT [FK_Node_Workflow] FOREIGN KEY([Workflow_Id])
REFERENCES [dbo].[Workflow] ([Id])
GO
ALTER TABLE [dbo].[Node] CHECK CONSTRAINT [FK_Node_Workflow]
GO
/****** Object:  ForeignKey [FK_WorkflowMapping_Node]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[WorkflowMapping]  WITH CHECK ADD  CONSTRAINT [FK_WorkflowMapping_Node] FOREIGN KEY([Node_Id])
REFERENCES [dbo].[Node] ([Id])
GO
ALTER TABLE [dbo].[WorkflowMapping] CHECK CONSTRAINT [FK_WorkflowMapping_Node]
GO
/****** Object:  ForeignKey [FK_Notification_Node]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[NotificationMapping]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Node] FOREIGN KEY([Node_Id])
REFERENCES [dbo].[Node] ([Id])
GO
ALTER TABLE [dbo].[NotificationMapping] CHECK CONSTRAINT [FK_Notification_Node]
GO
/****** Object:  ForeignKey [FK_Notification_Status]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[NotificationMapping]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Status] FOREIGN KEY([Status_Id])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[NotificationMapping] CHECK CONSTRAINT [FK_Notification_Status]
GO
/****** Object:  ForeignKey [FK_DocumentMapping_Document]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[DocumentMapping]  WITH CHECK ADD  CONSTRAINT [FK_DocumentMapping_Document] FOREIGN KEY([Document_Id])
REFERENCES [dbo].[Document] ([Id])
GO
ALTER TABLE [dbo].[DocumentMapping] CHECK CONSTRAINT [FK_DocumentMapping_Document]
GO
/****** Object:  ForeignKey [FK_DocumentMapping_Node]    Script Date: 02/10/2014 04:50:37 ******/
ALTER TABLE [dbo].[DocumentMapping]  WITH CHECK ADD  CONSTRAINT [FK_DocumentMapping_Node] FOREIGN KEY([Node_Id])
REFERENCES [dbo].[Node] ([Id])
GO
ALTER TABLE [dbo].[DocumentMapping] CHECK CONSTRAINT [FK_DocumentMapping_Node]
GO
