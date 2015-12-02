
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/02/2015 23:18:49
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
IF OBJECT_ID(N'[dbo].[FK_CreditTypesSetRequestSet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RequestSets] DROP CONSTRAINT [FK_CreditTypesSetRequestSet];
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
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BankBook'
CREATE TABLE [dbo].[BankBook] (
    [Id] uniqueidentifier  NOT NULL,
    [cache] smallint  NOT NULL,
    [CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Credit'
CREATE TABLE [dbo].[Credit] (
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

-- Creating table 'CreditType'
CREATE TABLE [dbo].[CreditType] (
    [Id] uniqueidentifier  NOT NULL,
    [Percent] float  NOT NULL,
    [StartSumPercent] float  NOT NULL,
    [PayCount] smallint  NOT NULL,
    [Info] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Debt'
CREATE TABLE [dbo].[Debt] (
    [Id] uniqueidentifier  NOT NULL,
    [Debt] smallint  NOT NULL
);
GO

-- Creating table 'Manager'
CREATE TABLE [dbo].[Manager] (
    [Id] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Position] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Message'
CREATE TABLE [dbo].[Message] (
    [Id] uniqueidentifier  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [PersonId] uniqueidentifier  NOT NULL,
    [ManagerId] uniqueidentifier  NOT NULL,
    [RequestId] uniqueidentifier  NULL
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

-- Creating table 'Payment'
CREATE TABLE [dbo].[Payment] (
    [Id] uniqueidentifier  NOT NULL,
    [Time] datetime  NOT NULL,
    [Payment] nvarchar(max)  NOT NULL,
    [CreditId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NULL,
    [SecondName] nvarchar(max)  NULL,
    [DateBirth] datetime  NULL,
    [PassportId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Request'
CREATE TABLE [dbo].[Request] (
    [Id] uniqueidentifier  NOT NULL,
    [CreditInfo] nvarchar(max)  NOT NULL,
    [PassportImage] varbinary(max)  NULL,
    [IncomeImage] varbinary(max)  NULL,
    [PersonId] uniqueidentifier  NOT NULL,
    [ManagerId] uniqueidentifier  NULL,
    [CreditTypeId] uniqueidentifier  NOT NULL,
    [Confirm] bit  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [MessageId] uniqueidentifier  NOT NULL
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

-- Creating primary key on [Id] in table 'BankBook'
ALTER TABLE [dbo].[BankBook]
ADD CONSTRAINT [PK_BankBook]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Credit'
ALTER TABLE [dbo].[Credit]
ADD CONSTRAINT [PK_Credit]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CreditType'
ALTER TABLE [dbo].[CreditType]
ADD CONSTRAINT [PK_CreditType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Debt'
ALTER TABLE [dbo].[Debt]
ADD CONSTRAINT [PK_Debt]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Manager'
ALTER TABLE [dbo].[Manager]
ADD CONSTRAINT [PK_Manager]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [PK_Message]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Passports'
ALTER TABLE [dbo].[Passports]
ADD CONSTRAINT [PK_Passports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [PK_Payment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [PK_Request]
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

-- Creating foreign key on [CreditId] in table 'BankBook'
ALTER TABLE [dbo].[BankBook]
ADD CONSTRAINT [FK_BankBookCredit]
    FOREIGN KEY ([CreditId])
    REFERENCES [dbo].[Credit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBookCredit'
CREATE INDEX [IX_FK_BankBookCredit]
ON [dbo].[BankBook]
    ([CreditId]);
GO

-- Creating foreign key on [CreditTypeId] in table 'Credit'
ALTER TABLE [dbo].[Credit]
ADD CONSTRAINT [FK_CreditCreditTypes]
    FOREIGN KEY ([CreditTypeId])
    REFERENCES [dbo].[CreditType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditCreditTypes'
CREATE INDEX [IX_FK_CreditCreditTypes]
ON [dbo].[Credit]
    ([CreditTypeId]);
GO

-- Creating foreign key on [DebtsId] in table 'Credit'
ALTER TABLE [dbo].[Credit]
ADD CONSTRAINT [FK_CreditDebts]
    FOREIGN KEY ([DebtsId])
    REFERENCES [dbo].[Debt]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditDebts'
CREATE INDEX [IX_FK_CreditDebts]
ON [dbo].[Credit]
    ([DebtsId]);
GO

-- Creating foreign key on [ManagerId] in table 'Credit'
ALTER TABLE [dbo].[Credit]
ADD CONSTRAINT [FK_ManagerCredit]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Manager]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerCredit'
CREATE INDEX [IX_FK_ManagerCredit]
ON [dbo].[Credit]
    ([ManagerId]);
GO

-- Creating foreign key on [CreditId] in table 'Payment'
ALTER TABLE [dbo].[Payment]
ADD CONSTRAINT [FK_PaymentsCredit]
    FOREIGN KEY ([CreditId])
    REFERENCES [dbo].[Credit]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentsCredit'
CREATE INDEX [IX_FK_PaymentsCredit]
ON [dbo].[Payment]
    ([CreditId]);
GO

-- Creating foreign key on [PersonId] in table 'Credit'
ALTER TABLE [dbo].[Credit]
ADD CONSTRAINT [FK_PersonCredit]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCredit'
CREATE INDEX [IX_FK_PersonCredit]
ON [dbo].[Credit]
    ([PersonId]);
GO

-- Creating foreign key on [ManagerId] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_ManagerMessage]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Manager]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerMessage'
CREATE INDEX [IX_FK_ManagerMessage]
ON [dbo].[Message]
    ([ManagerId]);
GO

-- Creating foreign key on [ManagerId] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_ManagerRequest]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Manager]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerRequest'
CREATE INDEX [IX_FK_ManagerRequest]
ON [dbo].[Request]
    ([ManagerId]);
GO

-- Creating foreign key on [PersonId] in table 'Message'
ALTER TABLE [dbo].[Message]
ADD CONSTRAINT [FK_PersonMessage]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMessage'
CREATE INDEX [IX_FK_PersonMessage]
ON [dbo].[Message]
    ([PersonId]);
GO

-- Creating foreign key on [PassportId] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [FK_PersonPassport]
    FOREIGN KEY ([PassportId])
    REFERENCES [dbo].[Passports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPassport'
CREATE INDEX [IX_FK_PersonPassport]
ON [dbo].[Person]
    ([PassportId]);
GO

-- Creating foreign key on [PersonId] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_PersonRequest]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonRequest'
CREATE INDEX [IX_FK_PersonRequest]
ON [dbo].[Request]
    ([PersonId]);
GO

-- Creating foreign key on [CreditTypeId] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_CreditTypesSetRequestSet]
    FOREIGN KEY ([CreditTypeId])
    REFERENCES [dbo].[CreditType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditTypesSetRequestSet'
CREATE INDEX [IX_FK_CreditTypesSetRequestSet]
ON [dbo].[Request]
    ([CreditTypeId]);
GO

-- Creating foreign key on [MessageId] in table 'Request'
ALTER TABLE [dbo].[Request]
ADD CONSTRAINT [FK_MessageRequestSet]
    FOREIGN KEY ([MessageId])
    REFERENCES [dbo].[Message]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MessageRequestSet'
CREATE INDEX [IX_FK_MessageRequestSet]
ON [dbo].[Request]
    ([MessageId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------