--  Database  =======================================================================================================================
CREATE DATABASE [Avx_TestDb] 
GO
USE [Avx_TestDb] 
GO
--  Schema  =======================================================================================================================
CREATE SCHEMA cts;
GO
-- Data Tables =======================================================================================================================
IF NOT EXISTS(SELECT 1
FROM sys.tables t
where t.name = 'Study')
CREATE TABLE [cts].[Study]
(
    [StudyId] [int] IDENTITY(1,1) NOT NULL,
    [StudyIdentifier] [varchar](50) NOT NULL,
    [StudyName] [nvarchar](100) NULL,
    [ProjectNumber] [nvarchar](50) NULL,
    [Type] [nvarchar](50) NULL
        CONSTRAINT [PK_StudyId] PRIMARY KEY CLUSTERED 
(
	[StudyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [cts].[Study] 
DROP CONSTRAINT IF EXISTS [UQ_Study_StudyIdentifier]
ALTER  TABLE  [cts].[Study] WITH CHECK 
ADD CONSTRAINT UQ_Study_StudyIdentifier UNIQUE (StudyIdentifier)

IF NOT EXISTS(SELECT 1
FROM sys.tables t
where t.name = 'TreatmentGroup')
CREATE TABLE [cts].[TreatmentGroup]
(
    [TreatmentId] [int] IDENTITY(1,1) NOT NULL,
    [TreatmentCode] [varchar](20) NOT NULL,
    [TreatmentName] [varchar](50) NOT NULL,
    [TreatmentColor] [nvarchar](100) NULL,
    CONSTRAINT [PK_TreatmentCode] PRIMARY KEY CLUSTERED 
(
	[TreatmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

IF NOT EXISTS(SELECT 1
FROM sys.tables t
where t.name = 'Patient')
CREATE TABLE [cts].[Patient]
(
    [PatientId] [int] IDENTITY(1,1) NOT NULL,
    [Age] INT CHECK (Age >= 20 AND Age <= 100),
    [Gender] [int] NOT NULL,
    [StudyId] [int] NOT NULL,
    [TreatmentId] [int] NOT NULL,
    CONSTRAINT [PK_PatientId] PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE  [cts].[Patient]  WITH CHECK ADD FOREIGN KEY([StudyId])
REFERENCES  [cts].[Study] ([StudyId])
GO
ALTER TABLE  [cts].[Patient]  WITH CHECK ADD FOREIGN KEY([TreatmentId])
REFERENCES  [cts].[TreatmentGroup] ([TreatmentId])
GO

-- UserDefined Data Table type ==========================================================================================================

IF NOT EXISTS(SELECT 1
FROM sys.types t
where t.name = 'StudyTableType')
BEGIN
    PRINT('Creating type')
    CREATE TYPE [cts].[StudyTableType] AS TABLE
    (
        [StudyId] [int],
        [StudyIdentifier] [varchar](50),
        [StudyName] [nvarchar](100),
        [ProjectNumber] [nvarchar](50),
        [Type] [nvarchar](50)
    )
END

IF NOT EXISTS(SELECT 1
FROM sys.types t
where t.name = 'TreatmentGroupTableType')
BEGIN
    PRINT('Creating type')
    CREATE TYPE  [cts].[TreatmentGroupTableType] AS TABLE
    (
        [TreatmentId] [int],
        [TreatmentCode] [varchar](20),
        [TreatmentName] [varchar](50),
        [TreatmentColor] [nvarchar](100)
   
    
    )
END

IF NOT EXISTS(SELECT 1
FROM sys.types t
where t.name = 'PatientTableType')
BEGIN
    PRINT('Creating type')
    CREATE TYPE  [cts].[PatientTableType] AS TABLE
    (
        [PatientId] [int],
        [Age] INT CHECK (Age >= 20 AND Age <= 100),
        [Gender] [int],
        [StudyId] [int],
        [TreatmentId] [int] 
    )
END



SELECT *
from [cts].[Study]
SELECT *
from [cts].[TreatmentGroup]
SELECT *
from [cts].[Patient]

-- drop TYPE [cts].[StudyTableType]
-- drop TYPE [cts].[PatientTableType]
-- drop TYPE [cts].[TreatmentGroupTableType]



-- DECLARE @tblTypeEmployee  [cts].[StudyTableType]  
  
-- --Inserting some records  
-- INSERT INTO @tblTypeEmployee ([StudyIdentifier],[StudyName],[ProjectNumber],[Type])   
-- VALUES ('SI1', 'StudyName 1' , 'STC0029' , 'XX') ,
--         ('SI2', 'StudyName 2' , 'STC00100' , 'XX1')   
     
-- -- Executing procedure  
-- exec [cts].[StudyImport]   @tblTypeEmployee  




-- DECLARE @tblTypeEmployee [cts].[TreatmentGroupTableType]
-- --Inserting some records  
-- INSERT INTO @tblTypeEmployee (TreatmentCode,TreatmentName,TreatmentColor)   
-- VALUES ('TR1', 'Endoscopy 1' , 'RED') ,
--         ('TR2', 'Charuscopy 2' , 'RED')   
     
-- -- Executing procedure  
-- exec [cts].[TreatmentGroupImport]   @tblTypeEmployee  


-- DECLARE @tblTypeEmployee [cts].[PatientTableType]
-- --Inserting some records  
-- INSERT INTO @tblTypeEmployee (Age,Gender,StudyId,TreatmentId)   
-- VALUES 
-- (28, 1 , 1,1),
-- (80, 2 , 2,1),
-- (90, 1 , 1,2)  
-- -- Executing procedure  
-- exec [cts].[Sp_PatientSet]   @tblTypeEmployee  


