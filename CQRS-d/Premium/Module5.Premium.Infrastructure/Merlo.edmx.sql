
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/19/2021 17:36:53
-- Generated from EDMX file: C:\Users\turibbio\OneDrive - Blexin Srl\Corsi\Microservizi\DEMO\CQRS-d\Premium\Module5.Premium.Infrastructure\Merlo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Matches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Matches];
GO
IF OBJECT_ID(N'[dbo].[MatchEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MatchEvents];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MatchEvents'
CREATE TABLE [dbo].[MatchEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Action] nvarchar(50)  NOT NULL,
    [TeamId] int  NULL,
    [TimeStamp] datetime  NOT NULL,
    [MatchId] nvarchar(10)  NOT NULL,
    [Team1] nvarchar(50)  NULL,
    [Team2] nvarchar(50)  NULL,
    [PlayerId] int  NULL
);
GO

-- Creating table 'Matches'
CREATE TABLE [dbo].[Matches] (
    [Id] nvarchar(10)  NOT NULL,
    [Team1] nvarchar(50)  NOT NULL,
    [Team2] nvarchar(50)  NOT NULL,
    [State] int  NOT NULL,
    [Score1] int  NOT NULL,
    [Score2] int  NOT NULL,
    [Period] int  NOT NULL,
    [Timeouts1] nvarchar(10)  NOT NULL,
    [Timeouts2] nvarchar(10)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MatchEvents'
ALTER TABLE [dbo].[MatchEvents]
ADD CONSTRAINT [PK_MatchEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [PK_Matches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------