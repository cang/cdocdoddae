USE [#DBNAME]
GO

-- Insert Unknown Signatures
SET IDENTITY_INSERT DDA_Signatures ON
GO

DELETE FROM [dbo].[DDA_Signatures]
WHERE SignatureKey IN (1,2,3)
GO

INSERT INTO [dbo].[DDA_Signatures]
           (SignatureKey
			,[SignatureName]
           ,[SignatureID])
     VALUES
           (1,'Unknown',9997)
GO

INSERT INTO [dbo].[DDA_Signatures]
           (SignatureKey
			,[SignatureName]
           ,[SignatureID])
     VALUES
           (2,'Empty',9998)
GO

INSERT INTO [dbo].[DDA_Signatures]
           (SignatureKey
			,[SignatureName]
           ,[SignatureID])
     VALUES
           (3,'No-Signature',9999)
GO

SET IDENTITY_INSERT DDA_Signatures OFF
GO
-- END Insert Unknown Signatures



INSERT INTO [dbo].[DDA_ApplicationData]
           ([Key]
           ,[Value])
     VALUES
           ('DBTYPE','#DBTYPE')
GO
           
INSERT INTO DDA_ApplicationData([key],[value]) VALUES('AllowMultiApplicationServer','false')
GO

-- Insert default DiskType
--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('TEST',25,95)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('TEST','TEST')
--GO

--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('SURF',25,95)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('SURF','SURF')
--GO

--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('MEDIA',25,95)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('MEDIA','MEDIA')
--GO

--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('KOMAG',25,70)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('KOMAG','KOMAG')
--GO

--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('CORSA*',25,70)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('CORSA*','CORSA*')
--GO

--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('HCANE',25,70)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('HCANE','HCANE')
--GO

--INSERT INTO [DDADB].[dbo].[DDA_DiskSizes]([Prod_Class],[InnerDiameter],[OuterDiameter]) VALUES ('MOOSE',25,95)
--GO
--INSERT INTO [DDADB].[dbo].[DDA_Products]([ProductCode],[Prod_Class]) VALUES ('MOOSE','MOOSE')
--GO


