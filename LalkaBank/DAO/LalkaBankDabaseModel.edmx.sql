
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/22/2015 17:07:25
-- Generated from EDMX file: C:\Users\Aver\documents\visual studio 2013\Projects\DataBase\DataBase\BankaTest.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BankBase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PaymentsCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentsSet] DROP CONSTRAINT [FK_PaymentsCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageSet] DROP CONSTRAINT [FK_ManagerMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestSet] DROP CONSTRAINT [FK_ManagerRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSet] DROP CONSTRAINT [FK_ManagerCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageSet] DROP CONSTRAINT [FK_PersonMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditCreditTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSet] DROP CONSTRAINT [FK_CreditCreditTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditDebts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSet] DROP CONSTRAINT [FK_CreditDebts];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSet] DROP CONSTRAINT [FK_PersonCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestSet] DROP CONSTRAINT [FK_PersonRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPassport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSet] DROP CONSTRAINT [FK_PersonPassport];
GO
IF OBJECT_ID(N'[dbo].[FK_BankBookCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankBookSet] DROP CONSTRAINT [FK_BankBookCredit];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PaymentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentsSet];
GO
IF OBJECT_ID(N'[dbo].[ManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSet];
GO
IF OBJECT_ID(N'[dbo].[MessageSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[testSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[testSet];
GO
IF OBJECT_ID(N'[dbo].[CreditTypesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditTypesSet];
GO
IF OBJECT_ID(N'[dbo].[DebtsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DebtsSet];
GO
IF OBJECT_ID(N'[dbo].[CreditSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditSet];
GO
IF OBJECT_ID(N'[dbo].[RequestSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequestSet];
GO
IF OBJECT_ID(N'[dbo].[PassportSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PassportSet];
GO
IF OBJECT_ID(N'[dbo].[BankBookSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankBookSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PaymentsSet'
CREATE TABLE [dbo].[PaymentsSet] (
    [PaymentsId] uniqueidentifier  NOT NULL,
    [Time] datetime  NOT NULL,
    [Payment] nvarchar(max)  NOT NULL,
    [Credit_CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [ManagerId] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MessageSet'
CREATE TABLE [dbo].[MessageSet] (
    [MessageId] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [PersonPersonId] uniqueidentifier  NOT NULL,
    [ManagerManagerId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [PersonId] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [SecondName] nvarchar(max)  NULL,
    [DateBirth] datetime  NULL,
    [Passport_PassportId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'testSet'
CREATE TABLE [dbo].[testSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL
);
GO

-- Creating table 'CreditTypesSet'
CREATE TABLE [dbo].[CreditTypesSet] (
    [CreditTypesId] uniqueidentifier  NOT NULL,
    [Percent] float  NOT NULL,
    [StartSumPercent] float  NOT NULL,
    [PayCount] smallint  NOT NULL,
    [Info] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DebtsSet'
CREATE TABLE [dbo].[DebtsSet] (
    [DebtsId] uniqueidentifier  NOT NULL,
    [Debt] smallint  NOT NULL
);
GO

-- Creating table 'CreditSet'
CREATE TABLE [dbo].[CreditSet] (
    [CreditId] uniqueidentifier  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Percent] float  NOT NULL,
    [StartSum] smallint  NOT NULL,
    [AllSum] smallint  NOT NULL,
    [PayCount] smallint  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Penya] float  NOT NULL,
    [PayMounth] smallint  NOT NULL,
    [PersonPersonId] uniqueidentifier  NOT NULL,
    [ManagerManagerId] uniqueidentifier  NOT NULL,
    [CreditTypes_CreditTypesId] uniqueidentifier  NOT NULL,
    [Debts_DebtsId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RequestSet'
CREATE TABLE [dbo].[RequestSet] (
    [RequestId] uniqueidentifier  NOT NULL,
    [CreditInfo] nvarchar(max)  NOT NULL,
    [PassportImage] varbinary(max)  NOT NULL,
    [IncomeImage] varbinary(max)  NOT NULL,
    [PersonPersonId] uniqueidentifier  NOT NULL,
    [ManagerManagerId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PassportSet'
CREATE TABLE [dbo].[PassportSet] (
    [PassportId] uniqueidentifier  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [RUVD] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Validity] datetime  NOT NULL
);
GO

-- Creating table 'BankBookSet'
CREATE TABLE [dbo].[BankBookSet] (
    [BankBookId] uniqueidentifier  NOT NULL,
    [cache] smallint  NOT NULL,
    [Credit_CreditId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [PaymentsId] in table 'PaymentsSet'
ALTER TABLE [dbo].[PaymentsSet]
ADD CONSTRAINT [PK_PaymentsSet]
    PRIMARY KEY CLUSTERED ([PaymentsId] ASC);
GO

-- Creating primary key on [ManagerId] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([ManagerId] ASC);
GO

-- Creating primary key on [MessageId] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [PK_MessageSet]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [PersonId] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([PersonId] ASC);
GO

-- Creating primary key on [Id] in table 'testSet'
ALTER TABLE [dbo].[testSet]
ADD CONSTRAINT [PK_testSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CreditTypesId] in table 'CreditTypesSet'
ALTER TABLE [dbo].[CreditTypesSet]
ADD CONSTRAINT [PK_CreditTypesSet]
    PRIMARY KEY CLUSTERED ([CreditTypesId] ASC);
GO

-- Creating primary key on [DebtsId] in table 'DebtsSet'
ALTER TABLE [dbo].[DebtsSet]
ADD CONSTRAINT [PK_DebtsSet]
    PRIMARY KEY CLUSTERED ([DebtsId] ASC);
GO

-- Creating primary key on [CreditId] in table 'CreditSet'
ALTER TABLE [dbo].[CreditSet]
ADD CONSTRAINT [PK_CreditSet]
    PRIMARY KEY CLUSTERED ([CreditId] ASC);
GO

-- Creating primary key on [RequestId] in table 'RequestSet'
ALTER TABLE [dbo].[RequestSet]
ADD CONSTRAINT [PK_RequestSet]
    PRIMARY KEY CLUSTERED ([RequestId] ASC);
GO

-- Creating primary key on [PassportId] in table 'PassportSet'
ALTER TABLE [dbo].[PassportSet]
ADD CONSTRAINT [PK_PassportSet]
    PRIMARY KEY CLUSTERED ([PassportId] ASC);
GO

-- Creating primary key on [BankBookId] in table 'BankBookSet'
ALTER TABLE [dbo].[BankBookSet]
ADD CONSTRAINT [PK_BankBookSet]
    PRIMARY KEY CLUSTERED ([BankBookId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Credit_CreditId] in table 'PaymentsSet'
ALTER TABLE [dbo].[PaymentsSet]
ADD CONSTRAINT [FK_PaymentsCredit]
    FOREIGN KEY ([Credit_CreditId])
    REFERENCES [dbo].[CreditSet]
        ([CreditId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentsCredit'
CREATE INDEX [IX_FK_PaymentsCredit]
ON [dbo].[PaymentsSet]
    ([Credit_CreditId]);
GO

-- Creating foreign key on [ManagerManagerId] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [FK_ManagerMessage]
    FOREIGN KEY ([ManagerManagerId])
    REFERENCES [dbo].[ManagerSet]
        ([ManagerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerMessage'
CREATE INDEX [IX_FK_ManagerMessage]
ON [dbo].[MessageSet]
    ([ManagerManagerId]);
GO

-- Creating foreign key on [ManagerManagerId] in table 'RequestSet'
ALTER TABLE [dbo].[RequestSet]
ADD CONSTRAINT [FK_ManagerRequest]
    FOREIGN KEY ([ManagerManagerId])
    REFERENCES [dbo].[ManagerSet]
        ([ManagerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerRequest'
CREATE INDEX [IX_FK_ManagerRequest]
ON [dbo].[RequestSet]
    ([ManagerManagerId]);
GO

-- Creating foreign key on [ManagerManagerId] in table 'CreditSet'
ALTER TABLE [dbo].[CreditSet]
ADD CONSTRAINT [FK_ManagerCredit]
    FOREIGN KEY ([ManagerManagerId])
    REFERENCES [dbo].[ManagerSet]
        ([ManagerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerCredit'
CREATE INDEX [IX_FK_ManagerCredit]
ON [dbo].[CreditSet]
    ([ManagerManagerId]);
GO

-- Creating foreign key on [PersonPersonId] in table 'MessageSet'
ALTER TABLE [dbo].[MessageSet]
ADD CONSTRAINT [FK_PersonMessage]
    FOREIGN KEY ([PersonPersonId])
    REFERENCES [dbo].[PersonSet]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMessage'
CREATE INDEX [IX_FK_PersonMessage]
ON [dbo].[MessageSet]
    ([PersonPersonId]);
GO

-- Creating foreign key on [CreditTypes_CreditTypesId] in table 'CreditSet'
ALTER TABLE [dbo].[CreditSet]
ADD CONSTRAINT [FK_CreditCreditTypes]
    FOREIGN KEY ([CreditTypes_CreditTypesId])
    REFERENCES [dbo].[CreditTypesSet]
        ([CreditTypesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditCreditTypes'
CREATE INDEX [IX_FK_CreditCreditTypes]
ON [dbo].[CreditSet]
    ([CreditTypes_CreditTypesId]);
GO

-- Creating foreign key on [Debts_DebtsId] in table 'CreditSet'
ALTER TABLE [dbo].[CreditSet]
ADD CONSTRAINT [FK_CreditDebts]
    FOREIGN KEY ([Debts_DebtsId])
    REFERENCES [dbo].[DebtsSet]
        ([DebtsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditDebts'
CREATE INDEX [IX_FK_CreditDebts]
ON [dbo].[CreditSet]
    ([Debts_DebtsId]);
GO

-- Creating foreign key on [PersonPersonId] in table 'CreditSet'
ALTER TABLE [dbo].[CreditSet]
ADD CONSTRAINT [FK_PersonCredit]
    FOREIGN KEY ([PersonPersonId])
    REFERENCES [dbo].[PersonSet]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCredit'
CREATE INDEX [IX_FK_PersonCredit]
ON [dbo].[CreditSet]
    ([PersonPersonId]);
GO

-- Creating foreign key on [PersonPersonId] in table 'RequestSet'
ALTER TABLE [dbo].[RequestSet]
ADD CONSTRAINT [FK_PersonRequest]
    FOREIGN KEY ([PersonPersonId])
    REFERENCES [dbo].[PersonSet]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRequest'
CREATE INDEX [IX_FK_PersonRequest]
ON [dbo].[RequestSet]
    ([PersonPersonId]);
GO

-- Creating foreign key on [Passport_PassportId] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [FK_PersonPassport]
    FOREIGN KEY ([Passport_PassportId])
    REFERENCES [dbo].[PassportSet]
        ([PassportId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPassport'
CREATE INDEX [IX_FK_PersonPassport]
ON [dbo].[PersonSet]
    ([Passport_PassportId]);
GO

-- Creating foreign key on [Credit_CreditId] in table 'BankBookSet'
ALTER TABLE [dbo].[BankBookSet]
ADD CONSTRAINT [FK_BankBookCredit]
    FOREIGN KEY ([Credit_CreditId])
    REFERENCES [dbo].[CreditSet]
        ([CreditId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBookCredit'
CREATE INDEX [IX_FK_BankBookCredit]
ON [dbo].[BankBookSet]
    ([Credit_CreditId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------