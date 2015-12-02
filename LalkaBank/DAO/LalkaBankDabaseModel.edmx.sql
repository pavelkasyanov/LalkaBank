
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/03/2015 01:23:25
-- Generated from EDMX file: E:\pavlik\git_repo\LalkaBank\LalkaBank\DAO\LalkaBankDabaseModel.edmx
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
    ALTER TABLE [dbo].[BankBooks] DROP CONSTRAINT [FK_BankBookCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditCreditTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credits] DROP CONSTRAINT [FK_CreditCreditTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditDebts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credits] DROP CONSTRAINT [FK_CreditDebts];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credits] DROP CONSTRAINT [FK_ManagerCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentsCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Payments] DROP CONSTRAINT [FK_PaymentsCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonCredit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credits] DROP CONSTRAINT [FK_PersonCredit];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_ManagerMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK_ManagerRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_PersonMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPassport]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_PersonPassport];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK_PersonRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditTypesSetRequestSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Requests] DROP CONSTRAINT [FK_CreditTypesSetRequestSet];
GO
IF OBJECT_ID(N'[dbo].[FK_RequestMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Messages] DROP CONSTRAINT [FK_RequestMessage];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BankBooks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BankBooks];
GO
IF OBJECT_ID(N'[dbo].[Credits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Credits];
GO
IF OBJECT_ID(N'[dbo].[CreditTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditTypes];
GO
IF OBJECT_ID(N'[dbo].[Debts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Debts];
GO
IF OBJECT_ID(N'[dbo].[Managers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managers];
GO
IF OBJECT_ID(N'[dbo].[Messages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Messages];
GO
IF OBJECT_ID(N'[dbo].[Passports]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Passports];
GO
IF OBJECT_ID(N'[dbo].[Payments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Payments];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[dbo].[Requests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requests];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BankBooks'
CREATE TABLE [dbo].[BankBooks] (
    [Id] uniqueidentifier  NOT NULL,
    [cache] smallint  NOT NULL,
    [CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Credits'
CREATE TABLE [dbo].[Credits] (
    [Id] uniqueidentifier  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Percent] float  NOT NULL,
    [StartSum] smallint  NOT NULL,
    [AllSum] smallint  NOT NULL,
    [PayCount] smallint  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Penya] float  NOT NULL,
    [PayMounth] smallint  NOT NULL,
    [PersonId] uniqueidentifier  NOT NULL,
    [ManagerId] uniqueidentifier  NOT NULL,
    [CreditTypeId] uniqueidentifier  NOT NULL,
    [DebtsId] uniqueidentifier  NULL
);
GO

-- Creating table 'CreditTypes'
CREATE TABLE [dbo].[CreditTypes] (
    [Id] uniqueidentifier  NOT NULL,
    [Percent] float  NOT NULL,
    [StartSumPercent] float  NOT NULL,
    [PayCount] smallint  NOT NULL,
    [Info] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Debts'
CREATE TABLE [dbo].[Debts] (
    [Id] uniqueidentifier  NOT NULL,
    [Debt] smallint  NOT NULL
);
GO

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [Id] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Messages'
CREATE TABLE [dbo].[Messages] (
    [Id] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [PersonId] uniqueidentifier  NOT NULL,
    [ManagerId] uniqueidentifier  NOT NULL,
    [RequestId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Passports'
CREATE TABLE [dbo].[Passports] (
    [Id] uniqueidentifier  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [RUVD] nvarchar(max)  NOT NULL,
    [Adress] nvarchar(max)  NOT NULL,
    [Validity] datetime  NOT NULL
);
GO

-- Creating table 'Payments'
CREATE TABLE [dbo].[Payments] (
    [Id] uniqueidentifier  NOT NULL,
    [Time] datetime  NOT NULL,
    [Payment] nvarchar(max)  NOT NULL,
    [CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [Id] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [SecondName] nvarchar(max)  NULL,
    [DateBirth] datetime  NULL,
    [PassportId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Requests'
CREATE TABLE [dbo].[Requests] (
    [Id] uniqueidentifier  NOT NULL,
    [CreditInfo] nvarchar(max)  NOT NULL,
    [PassportImage] varbinary(max)  NULL,
    [IncomeImage] varbinary(max)  NULL,
    [PersonId] uniqueidentifier  NOT NULL,
    [ManagerId] uniqueidentifier  NULL,
    [CreditTypeId] uniqueidentifier  NOT NULL,
    [Confirm] int  NOT NULL,
    [Number] int  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BankBooks'
ALTER TABLE [dbo].[BankBooks]
ADD CONSTRAINT [PK_BankBooks]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [PK_Credits]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CreditTypes'
ALTER TABLE [dbo].[CreditTypes]
ADD CONSTRAINT [PK_CreditTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Debts'
ALTER TABLE [dbo].[Debts]
ADD CONSTRAINT [PK_Debts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [PK_Messages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Passports'
ALTER TABLE [dbo].[Passports]
ADD CONSTRAINT [PK_Passports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [PK_Payments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [PK_Requests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CreditId] in table 'BankBooks'
ALTER TABLE [dbo].[BankBooks]
ADD CONSTRAINT [FK_BankBookCredit]
    FOREIGN KEY ([CreditId])
    REFERENCES [dbo].[Credits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBookCredit'
CREATE INDEX [IX_FK_BankBookCredit]
ON [dbo].[BankBooks]
    ([CreditId]);
GO

-- Creating foreign key on [CreditTypeId] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_CreditCreditTypes]
    FOREIGN KEY ([CreditTypeId])
    REFERENCES [dbo].[CreditTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditCreditTypes'
CREATE INDEX [IX_FK_CreditCreditTypes]
ON [dbo].[Credits]
    ([CreditTypeId]);
GO

-- Creating foreign key on [DebtsId] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_CreditDebts]
    FOREIGN KEY ([DebtsId])
    REFERENCES [dbo].[Debts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditDebts'
CREATE INDEX [IX_FK_CreditDebts]
ON [dbo].[Credits]
    ([DebtsId]);
GO

-- Creating foreign key on [ManagerId] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_ManagerCredit]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Managers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerCredit'
CREATE INDEX [IX_FK_ManagerCredit]
ON [dbo].[Credits]
    ([ManagerId]);
GO

-- Creating foreign key on [CreditId] in table 'Payments'
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_PaymentsCredit]
    FOREIGN KEY ([CreditId])
    REFERENCES [dbo].[Credits]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentsCredit'
CREATE INDEX [IX_FK_PaymentsCredit]
ON [dbo].[Payments]
    ([CreditId]);
GO

-- Creating foreign key on [PersonId] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_PersonCredit]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCredit'
CREATE INDEX [IX_FK_PersonCredit]
ON [dbo].[Credits]
    ([PersonId]);
GO

-- Creating foreign key on [ManagerId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_ManagerMessage]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Managers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerMessage'
CREATE INDEX [IX_FK_ManagerMessage]
ON [dbo].[Messages]
    ([ManagerId]);
GO

-- Creating foreign key on [ManagerId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_ManagerRequest]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Managers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerRequest'
CREATE INDEX [IX_FK_ManagerRequest]
ON [dbo].[Requests]
    ([ManagerId]);
GO

-- Creating foreign key on [PersonId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_PersonMessage]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMessage'
CREATE INDEX [IX_FK_PersonMessage]
ON [dbo].[Messages]
    ([PersonId]);
GO

-- Creating foreign key on [PassportId] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_PersonPassport]
    FOREIGN KEY ([PassportId])
    REFERENCES [dbo].[Passports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPassport'
CREATE INDEX [IX_FK_PersonPassport]
ON [dbo].[Persons]
    ([PassportId]);
GO

-- Creating foreign key on [PersonId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_PersonRequest]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Persons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRequest'
CREATE INDEX [IX_FK_PersonRequest]
ON [dbo].[Requests]
    ([PersonId]);
GO

-- Creating foreign key on [CreditTypeId] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [FK_CreditTypesSetRequestSet]
    FOREIGN KEY ([CreditTypeId])
    REFERENCES [dbo].[CreditTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditTypesSetRequestSet'
CREATE INDEX [IX_FK_CreditTypesSetRequestSet]
ON [dbo].[Requests]
    ([CreditTypeId]);
GO

-- Creating foreign key on [RequestId] in table 'Messages'
ALTER TABLE [dbo].[Messages]
ADD CONSTRAINT [FK_RequestMessage]
    FOREIGN KEY ([RequestId])
    REFERENCES [dbo].[Requests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RequestMessage'
CREATE INDEX [IX_FK_RequestMessage]
ON [dbo].[Messages]
    ([RequestId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------