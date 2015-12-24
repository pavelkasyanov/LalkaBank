USE [BankBase]
GO

INSERT INTO [dbo].[BankAaccount]
           ([Id]
           ,[Amount])
     VALUES
           ('{2FFF176A-9EFB-4600-B103-7ABFD4AADFB1}', 5000000000)
GO

INSERT INTO [dbo].[CreditSubType]
           ([Id]
           ,[Name]
           ,[Abbreviation])
     VALUES
           ('{BDE03809-8DFC-4915-AFE5-890877168116}', 'Ann', 'Ann')
GO

INSERT INTO [dbo].[CreditSubType]
           ([Id]
           ,[Name]
           ,[Abbreviation])
     VALUES
           ('{047210E4-4B75-41F1-B51E-A51746B27EDB}', 'Grad', 'Grad')
GO