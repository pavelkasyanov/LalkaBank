
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/28/2015 21:31:19
-- Generated from EDMX file: D:\dev\git_repo\LalkaBank\LalkaBank\DAO\LalkaBankDabaseModel.edmx
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

IF OBJECT_ID(N'[dbo].[FK_BankBookCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BankBookSets] DROP CONSTRAINT [FK_BankBookCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditCreditTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSets] DROP CONSTRAINT [FK_CreditCreditTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditDebts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSets] DROP CONSTRAINT [FK_CreditDebts];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSets] DROP CONSTRAINT [FK_ManagerCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentsCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentsSets] DROP CONSTRAINT [FK_PaymentsCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditSets] DROP CONSTRAINT [FK_PersonCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageSets] DROP CONSTRAINT [FK_ManagerMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestSets] DROP CONSTRAINT [FK_ManagerRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageSets] DROP CONSTRAINT [FK_PersonMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPassport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSets] DROP CONSTRAINT [FK_PersonPassport];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestSets] DROP CONSTRAINT [FK_PersonRequest];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BankBookSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankBookSets];
GO
IF OBJECT_ID(N'[dbo].[CreditSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditSets];
GO
IF OBJECT_ID(N'[dbo].[CreditTypesSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditTypesSets];
GO
IF OBJECT_ID(N'[dbo].[DebtsSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DebtsSets];
GO
IF OBJECT_ID(N'[dbo].[ManagerSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSets];
GO
IF OBJECT_ID(N'[dbo].[MessageSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageSets];
GO
IF OBJECT_ID(N'[dbo].[PassportSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PassportSets];
GO
IF OBJECT_ID(N'[dbo].[PaymentsSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentsSets];
GO
IF OBJECT_ID(N'[dbo].[PersonSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSets];
GO
IF OBJECT_ID(N'[dbo].[RequestSets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RequestSets];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BankBookSets'
CREATE TABLE [dbo].[BankBookSets] (
    [BankBookId] uniqueidentifier  NOT NULL,
    [cache] smallint  NOT NULL,
    [Credit_CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'CreditSets'
CREATE TABLE [dbo].[CreditSets] (
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

-- Creating table 'CreditTypesSets'
CREATE TABLE [dbo].[CreditTypesSets] (
    [CreditTypesId] uniqueidentifier  NOT NULL,
    [Percent] float  NOT NULL,
    [StartSumPercent] float  NOT NULL,
    [PayCount] smallint  NOT NULL,
    [Info] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DebtsSets'
CREATE TABLE [dbo].[DebtsSets] (
    [DebtsId] uniqueidentifier  NOT NULL,
    [Debt] smallint  NOT NULL
);
GO

-- Creating table 'ManagerSets'
CREATE TABLE [dbo].[ManagerSets] (
    [ManagerId] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MessageSets'
CREATE TABLE [dbo].[MessageSets] (
    [MessageId] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [PersonPersonId] uniqueidentifier  NOT NULL,
    [ManagerManagerId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PassportSets'
CREATE TABLE [dbo].[PassportSets] (
    [PassportId] uniqueidentifier  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [RUVD] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Validity] datetime  NOT NULL
);
GO

-- Creating table 'PaymentsSets'
CREATE TABLE [dbo].[PaymentsSets] (
    [PaymentsId] uniqueidentifier  NOT NULL,
    [Time] datetime  NOT NULL,
    [Payment] nvarchar(max)  NOT NULL,
    [Credit_CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PersonSets'
CREATE TABLE [dbo].[PersonSets] (
    [PersonId] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [SecondName] nvarchar(max)  NULL,
    [DateBirth] datetime  NULL,
    [Passport_PassportId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RequestSets'
CREATE TABLE [dbo].[RequestSets] (
    [RequestId] uniqueidentifier  NOT NULL,
    [CreditInfo] nvarchar(max)  NOT NULL,
    [PassportImage] varbinary(max)  NOT NULL,
    [IncomeImage] varbinary(max)  NOT NULL,
    [PersonPersonId] uniqueidentifier  NOT NULL,
    [ManagerManagerId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BankBookId] in table 'BankBookSets'
ALTER TABLE [dbo].[BankBookSets]
ADD CONSTRAINT [PK_BankBookSets]
    PRIMARY KEY CLUSTERED ([BankBookId] ASC);
GO

-- Creating primary key on [CreditId] in table 'CreditSets'
ALTER TABLE [dbo].[CreditSets]
ADD CONSTRAINT [PK_CreditSets]
    PRIMARY KEY CLUSTERED ([CreditId] ASC);
GO

-- Creating primary key on [CreditTypesId] in table 'CreditTypesSets'
ALTER TABLE [dbo].[CreditTypesSets]
ADD CONSTRAINT [PK_CreditTypesSets]
    PRIMARY KEY CLUSTERED ([CreditTypesId] ASC);
GO

-- Creating primary key on [DebtsId] in table 'DebtsSets'
ALTER TABLE [dbo].[DebtsSets]
ADD CONSTRAINT [PK_DebtsSets]
    PRIMARY KEY CLUSTERED ([DebtsId] ASC);
GO

-- Creating primary key on [ManagerId] in table 'ManagerSets'
ALTER TABLE [dbo].[ManagerSets]
ADD CONSTRAINT [PK_ManagerSets]
    PRIMARY KEY CLUSTERED ([ManagerId] ASC);
GO

-- Creating primary key on [MessageId] in table 'MessageSets'
ALTER TABLE [dbo].[MessageSets]
ADD CONSTRAINT [PK_MessageSets]
    PRIMARY KEY CLUSTERED ([MessageId] ASC);
GO

-- Creating primary key on [PassportId] in table 'PassportSets'
ALTER TABLE [dbo].[PassportSets]
ADD CONSTRAINT [PK_PassportSets]
    PRIMARY KEY CLUSTERED ([PassportId] ASC);
GO

-- Creating primary key on [PaymentsId] in table 'PaymentsSets'
ALTER TABLE [dbo].[PaymentsSets]
ADD CONSTRAINT [PK_PaymentsSets]
    PRIMARY KEY CLUSTERED ([PaymentsId] ASC);
GO

-- Creating primary key on [PersonId] in table 'PersonSets'
ALTER TABLE [dbo].[PersonSets]
ADD CONSTRAINT [PK_PersonSets]
    PRIMARY KEY CLUSTERED ([PersonId] ASC);
GO

-- Creating primary key on [RequestId] in table 'RequestSets'
ALTER TABLE [dbo].[RequestSets]
ADD CONSTRAINT [PK_RequestSets]
    PRIMARY KEY CLUSTERED ([RequestId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Credit_CreditId] in table 'BankBookSets'
ALTER TABLE [dbo].[BankBookSets]
ADD CONSTRAINT [FK_BankBookCredit]
    FOREIGN KEY ([Credit_CreditId])
    REFERENCES [dbo].[CreditSets]
        ([CreditId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBookCredit'
CREATE INDEX [IX_FK_BankBookCredit]
ON [dbo].[BankBookSets]
    ([Credit_CreditId]);
GO

-- Creating foreign key on [CreditTypes_CreditTypesId] in table 'CreditSets'
ALTER TABLE [dbo].[CreditSets]
ADD CONSTRAINT [FK_CreditCreditTypes]
    FOREIGN KEY ([CreditTypes_CreditTypesId])
    REFERENCES [dbo].[CreditTypesSets]
        ([CreditTypesId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditCreditTypes'
CREATE INDEX [IX_FK_CreditCreditTypes]
ON [dbo].[CreditSets]
    ([CreditTypes_CreditTypesId]);
GO

-- Creating foreign key on [Debts_DebtsId] in table 'CreditSets'
ALTER TABLE [dbo].[CreditSets]
ADD CONSTRAINT [FK_CreditDebts]
    FOREIGN KEY ([Debts_DebtsId])
    REFERENCES [dbo].[DebtsSets]
        ([DebtsId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditDebts'
CREATE INDEX [IX_FK_CreditDebts]
ON [dbo].[CreditSets]
    ([Debts_DebtsId]);
GO

-- Creating foreign key on [ManagerManagerId] in table 'CreditSets'
ALTER TABLE [dbo].[CreditSets]
ADD CONSTRAINT [FK_ManagerCredit]
    FOREIGN KEY ([ManagerManagerId])
    REFERENCES [dbo].[ManagerSets]
        ([ManagerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerCredit'
CREATE INDEX [IX_FK_ManagerCredit]
ON [dbo].[CreditSets]
    ([ManagerManagerId]);
GO

-- Creating foreign key on [Credit_CreditId] in table 'PaymentsSets'
ALTER TABLE [dbo].[PaymentsSets]
ADD CONSTRAINT [FK_PaymentsCredit]
    FOREIGN KEY ([Credit_CreditId])
    REFERENCES [dbo].[CreditSets]
        ([CreditId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentsCredit'
CREATE INDEX [IX_FK_PaymentsCredit]
ON [dbo].[PaymentsSets]
    ([Credit_CreditId]);
GO

-- Creating foreign key on [PersonPersonId] in table 'CreditSets'
ALTER TABLE [dbo].[CreditSets]
ADD CONSTRAINT [FK_PersonCredit]
    FOREIGN KEY ([PersonPersonId])
    REFERENCES [dbo].[PersonSets]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCredit'
CREATE INDEX [IX_FK_PersonCredit]
ON [dbo].[CreditSets]
    ([PersonPersonId]);
GO

-- Creating foreign key on [ManagerManagerId] in table 'MessageSets'
ALTER TABLE [dbo].[MessageSets]
ADD CONSTRAINT [FK_ManagerMessage]
    FOREIGN KEY ([ManagerManagerId])
    REFERENCES [dbo].[ManagerSets]
        ([ManagerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerMessage'
CREATE INDEX [IX_FK_ManagerMessage]
ON [dbo].[MessageSets]
    ([ManagerManagerId]);
GO

-- Creating foreign key on [ManagerManagerId] in table 'RequestSets'
ALTER TABLE [dbo].[RequestSets]
ADD CONSTRAINT [FK_ManagerRequest]
    FOREIGN KEY ([ManagerManagerId])
    REFERENCES [dbo].[ManagerSets]
        ([ManagerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerRequest'
CREATE INDEX [IX_FK_ManagerRequest]
ON [dbo].[RequestSets]
    ([ManagerManagerId]);
GO

-- Creating foreign key on [PersonPersonId] in table 'MessageSets'
ALTER TABLE [dbo].[MessageSets]
ADD CONSTRAINT [FK_PersonMessage]
    FOREIGN KEY ([PersonPersonId])
    REFERENCES [dbo].[PersonSets]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMessage'
CREATE INDEX [IX_FK_PersonMessage]
ON [dbo].[MessageSets]
    ([PersonPersonId]);
GO

-- Creating foreign key on [Passport_PassportId] in table 'PersonSets'
ALTER TABLE [dbo].[PersonSets]
ADD CONSTRAINT [FK_PersonPassport]
    FOREIGN KEY ([Passport_PassportId])
    REFERENCES [dbo].[PassportSets]
        ([PassportId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPassport'
CREATE INDEX [IX_FK_PersonPassport]
ON [dbo].[PersonSets]
    ([Passport_PassportId]);
GO

-- Creating foreign key on [PersonPersonId] in table 'RequestSets'
ALTER TABLE [dbo].[RequestSets]
ADD CONSTRAINT [FK_PersonRequest]
    FOREIGN KEY ([PersonPersonId])
    REFERENCES [dbo].[PersonSets]
        ([PersonId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRequest'
CREATE INDEX [IX_FK_PersonRequest]
ON [dbo].[RequestSets]
    ([PersonPersonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------