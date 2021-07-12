USE [#DBNAME]
GO

/****** Object:  ForeignKey [FK_COM_DiskResponse_DDA_Disks]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_COM_DiskResponse_DDA_Disks]') AND parent_object_id = OBJECT_ID(N'[dbo].[COM_DiskResponse]'))
ALTER TABLE [dbo].[COM_DiskResponse] DROP CONSTRAINT [FK_COM_DiskResponse_DDA_Disks]
GO
/****** Object:  ForeignKey [FK_DDA_AlarmChart_DDA_AlarmEvent]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_AlarmChart_DDA_AlarmEvent]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmChart]'))
ALTER TABLE [dbo].[DDA_AlarmChart] DROP CONSTRAINT [FK_DDA_AlarmChart_DDA_AlarmEvent]
GO
/****** Object:  ForeignKey [FK_DDA_AlarmEvent_DDA_ControlRule]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_AlarmEvent_DDA_ControlRule]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
ALTER TABLE [dbo].[DDA_AlarmEvent] DROP CONSTRAINT [FK_DDA_AlarmEvent_DDA_ControlRule]
GO
/****** Object:  ForeignKey [FK_DDA_ControlRuleDetail_DDA_ControlRule]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ControlRuleDetail_DDA_ControlRule]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRuleDetail]'))
ALTER TABLE [dbo].[DDA_ControlRuleDetail] DROP CONSTRAINT [FK_DDA_ControlRuleDetail_DDA_ControlRule]
GO
/****** Object:  ForeignKey [FK_DDA_Disk_DDA_Fab]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disk_DDA_Fab]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [FK_DDA_Disk_DDA_Fab]
GO
/****** Object:  ForeignKey [FK_DDA_Disk_DDA_Station]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disk_DDA_Station]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [FK_DDA_Disk_DDA_Station]
GO
/****** Object:  ForeignKey [FK_DDA_Disk_DDA_WordCell]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disk_DDA_WordCell]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [FK_DDA_Disk_DDA_WordCell]
GO
/****** Object:  ForeignKey [FK_DDA_Disks_DDA_Products]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disks_DDA_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [FK_DDA_Disks_DDA_Products]
GO
/****** Object:  ForeignKey [FK_DDA_Disks_DDA_TesterTypes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disks_DDA_TesterTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [FK_DDA_Disks_DDA_TesterTypes]
GO
/****** Object:  ForeignKey [FK_DDA_GradeMapping_DDA_Grades]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_GradeMapping_DDA_Grades]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_GradeMapping]'))
ALTER TABLE [dbo].[DDA_GradeMapping] DROP CONSTRAINT [FK_DDA_GradeMapping_DDA_Grades]
GO
/****** Object:  ForeignKey [FK_DDA_Processed_DDA_Recipes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Processed_DDA_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
ALTER TABLE [dbo].[DDA_Processed] DROP CONSTRAINT [FK_DDA_Processed_DDA_Recipes]
GO
/****** Object:  ForeignKey [FK_DDA_Processed_DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Processed_DDA_Surfaces]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
ALTER TABLE [dbo].[DDA_Processed] DROP CONSTRAINT [FK_DDA_Processed_DDA_Surfaces]
GO
/****** Object:  ForeignKey [FK_DDA_RecipeData_DDA_Recipes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_RecipeData_DDA_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_RecipeData]'))
ALTER TABLE [dbo].[DDA_RecipeData] DROP CONSTRAINT [FK_DDA_RecipeData_DDA_Recipes]
GO
/****** Object:  ForeignKey [FK_DDA_ResultData_DDA_Results]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultData_DDA_Results]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultData]'))
ALTER TABLE [dbo].[DDA_ResultData] DROP CONSTRAINT [FK_DDA_ResultData_DDA_Results]
GO
/****** Object:  ForeignKey [FK_DDA_ResultDetail_DDA_Results]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultDetail_DDA_Results]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]'))
ALTER TABLE [dbo].[DDA_ResultDetail] DROP CONSTRAINT [FK_DDA_ResultDetail_DDA_Results]
GO
/****** Object:  ForeignKey [FK_DDA_ResultDetail_DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultDetail_DDA_Surfaces]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]'))
ALTER TABLE [dbo].[DDA_ResultDetail] DROP CONSTRAINT [FK_DDA_ResultDetail_DDA_Surfaces]
GO
/****** Object:  ForeignKey [FK_DDA_ResultDetailData_DDA_ResultDetail]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultDetailData_DDA_ResultDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]'))
ALTER TABLE [dbo].[DDA_ResultDetailData] DROP CONSTRAINT [FK_DDA_ResultDetailData_DDA_ResultDetail]
GO
/****** Object:  ForeignKey [FK_DDA_ResultObjects_DDA_ResultObjectTypes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultObjects_DDA_ResultObjectTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultObjects]'))
ALTER TABLE [dbo].[DDA_ResultObjects] DROP CONSTRAINT [FK_DDA_ResultObjects_DDA_ResultObjectTypes]
GO
/****** Object:  ForeignKey [FK_DDA_Results_DDA_Signatures]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Results_DDA_Signatures]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Results]'))
ALTER TABLE [dbo].[DDA_Results] DROP CONSTRAINT [FK_DDA_Results_DDA_Signatures]
GO
/****** Object:  ForeignKey [FK_DDA_SurfaceData_DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_SurfaceData_DDA_Surfaces]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]'))
ALTER TABLE [dbo].[DDA_SurfaceData] DROP CONSTRAINT [FK_DDA_SurfaceData_DDA_Surfaces]
GO
/****** Object:  ForeignKey [FK_DDA_Surfaces_DDA_Disk]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Surfaces_DDA_Disk]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
ALTER TABLE [dbo].[DDA_Surfaces] DROP CONSTRAINT [FK_DDA_Surfaces_DDA_Disk]
GO
/****** Object:  ForeignKey [FK_DDA_ViolativeDisk_DDA_AlarmEvent]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ViolativeDisk_DDA_AlarmEvent]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]'))
ALTER TABLE [dbo].[DDA_ViolativeDisk] DROP CONSTRAINT [FK_DDA_ViolativeDisk_DDA_AlarmEvent]
GO
/****** Object:  ForeignKey [FK_DDA_ViolativeDisk_DDA_Disk]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ViolativeDisk_DDA_Disk]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]'))
ALTER TABLE [dbo].[DDA_ViolativeDisk] DROP CONSTRAINT [FK_DDA_ViolativeDisk_DDA_Disk]
GO
/****** Object:  Default [DF_DDA_AlarmChart_ChartSnapshotVersion]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmChart_ChartSnapshotVersion]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmChart]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmChart] DROP CONSTRAINT [DF_DDA_AlarmChart_ChartSnapshotVersion]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDataLevel1]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDataLevel1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] DROP CONSTRAINT [DF_DDA_AlarmEvent_GroupByDataLevel1]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDataLevel2]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDataLevel2]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] DROP CONSTRAINT [DF_DDA_AlarmEvent_GroupByDataLevel2]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDimensionID1]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDimensionID1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] DROP CONSTRAINT [DF_DDA_AlarmEvent_GroupByDimensionID1]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDimensionID2]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDimensionID2]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] DROP CONSTRAINT [DF_DDA_AlarmEvent_GroupByDimensionID2]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_Title]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_Title]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] DROP CONSTRAINT [DF_DDA_ControlRule_Title]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_SubCategory]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] DROP CONSTRAINT [DF_DDA_ControlRule_SubCategory]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_Category]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] DROP CONSTRAINT [DF_DDA_ControlRule_Category]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_Description]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_Description]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] DROP CONSTRAINT [DF_DDA_ControlRule_Description]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Top_Corr_cts]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Top_Corr_cts]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [DF_DDA_Disks_L2_Top_Corr_cts]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Bot_Corr_cts1]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Bot_Corr_cts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [DF_DDA_Disks_L2_Bot_Corr_cts1]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Top_NCorr_cts1]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Top_NCorr_cts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [DF_DDA_Disks_L2_Top_NCorr_cts1]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Bot_NCorr_cts11]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Bot_NCorr_cts11]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [DF_DDA_Disks_L2_Bot_NCorr_cts11]

End
GO
/****** Object:  Default [DF_DDA_Disks_Deleted]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [DF_DDA_Disks_Deleted]

End
GO
/****** Object:  Default [DF_DDA_Disks_HasMeaning]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_HasMeaning]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] DROP CONSTRAINT [DF_DDA_Disks_HasMeaning]

End
GO
/****** Object:  Default [DF_DDA_Processed_BreakWhenFound]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Processed_BreakWhenFound]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
Begin
ALTER TABLE [dbo].[DDA_Processed] DROP CONSTRAINT [DF_DDA_Processed_BreakWhenFound]

End
GO
/****** Object:  Default [DF_DDA_Processed_Finish]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Processed_Finish]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
Begin
ALTER TABLE [dbo].[DDA_Processed] DROP CONSTRAINT [DF_DDA_Processed_Finish]

End
GO
/****** Object:  Default [DF_DDA_Recipes_BreakWhenFound]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Recipes_BreakWhenFound]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Recipes]'))
Begin
ALTER TABLE [dbo].[DDA_Recipes] DROP CONSTRAINT [DF_DDA_Recipes_BreakWhenFound]

End
GO
/****** Object:  Default [DF__DDA_Resul__NoCom__6D9742D9]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Resul__NoCom__6D9742D9]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultData]'))
Begin
ALTER TABLE [dbo].[DDA_ResultData] DROP CONSTRAINT [DF__DDA_Resul__NoCom__6D9742D9]

End
GO
/****** Object:  Default [DF__DDA_Resul__NoCom__72C60C4A]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Resul__NoCom__72C60C4A]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]'))
Begin
ALTER TABLE [dbo].[DDA_ResultDetailData] DROP CONSTRAINT [DF__DDA_Resul__NoCom__72C60C4A]

End
GO
/****** Object:  Default [DF_DDA_Results_ProcessingDuration]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Results_ProcessingDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Results]'))
Begin
ALTER TABLE [dbo].[DDA_Results] DROP CONSTRAINT [DF_DDA_Results_ProcessingDuration]

End
GO
/****** Object:  Default [DF__DDA_Surfa__NoCom__70DDC3D8]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Surfa__NoCom__70DDC3D8]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]'))
Begin
ALTER TABLE [dbo].[DDA_SurfaceData] DROP CONSTRAINT [DF__DDA_Surfa__NoCom__70DDC3D8]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_HasSignature]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_HasSignature]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] DROP CONSTRAINT [DF_DDA_Surfaces_HasSignature]

End
GO
/****** Object:  Default [DF__DDA_Surfa__IsDef__619B8048]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Surfa__IsDef__619B8048]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] DROP CONSTRAINT [DF__DDA_Surfa__IsDef__619B8048]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_Processed]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_Processed]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] DROP CONSTRAINT [DF_DDA_Surfaces_Processed]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_Deleted]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] DROP CONSTRAINT [DF_DDA_Surfaces_Deleted]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_ProcessingDuration]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_ProcessingDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] DROP CONSTRAINT [DF_DDA_Surfaces_ProcessingDuration]

End
GO
/****** Object:  Default [DF_DDA_SysInfo_DBType]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_SysInfo_DBType]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_SysInfo]'))
Begin
ALTER TABLE [dbo].[DDA_SysInfo] DROP CONSTRAINT [DF_DDA_SysInfo_DBType]

End
GO
/****** Object:  Default [DF_DDA_ViolativeDisk_SignatureKey]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ViolativeDisk_SignatureKey]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]'))
Begin
ALTER TABLE [dbo].[DDA_ViolativeDisk] DROP CONSTRAINT [DF_DDA_ViolativeDisk_SignatureKey]

End
GO
/****** Object:  StoredProcedure [dbo].[UpdateProcessedByKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProcessedByKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateProcessedByKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Channels_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Channels_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Channels_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Channels_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Channels_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Channels_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_GetBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_GetBy_AlarmKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_GetBy_AlarmKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_DeleteBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_DeleteBy_AlarmKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmChart_DeleteBy_AlarmKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultData_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultData_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_DeleteBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_DeleteBy_ResultKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultData_DeleteBy_ResultKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultData_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultData_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_GetBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_GetBy_ResultKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultData_GetBy_ResultKey]
GO
/****** Object:  StoredProcedure [dbo].[_GetResultRawData]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultRawData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetResultRawData]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetailData_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetailData_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_GetResultThumbnail]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultThumbnail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetResultThumbnail]
GO
/****** Object:  StoredProcedure [dbo].[_GetResultThumbnailFlat]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultThumbnailFlat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetResultThumbnailFlat]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetailData_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_DeleteBy_ResultDetailKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_DeleteBy_ResultDetailKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetailData_DeleteBy_ResultDetailKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_GetBy_ResultDetailKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_GetBy_ResultDetailKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetailData_GetBy_ResultDetailKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Grades_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Grades_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Grades_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Grades_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Grades_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Grades_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SurfaceData_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceThumbnailFlat]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceThumbnailFlat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSourceThumbnailFlat]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SurfaceData_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SurfaceData_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_GetBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_GetBy_SurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SurfaceData_GetBy_SurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_DeleteBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_DeleteBy_SurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SurfaceData_DeleteBy_SurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceThumbnail]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceThumbnail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSourceThumbnail]
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceRawData]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceRawData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSourceRawData]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteBy_ResultKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_DeleteBy_ResultKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteBy_SurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_DeleteBy_SurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetBy_ResultKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_GetBy_ResultKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetBy_SurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_GetBy_SurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultDetail_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_ResultDetail_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_ResultDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_Update]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Results_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Results_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Results_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_GetBy_SignatureKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_GetBy_SignatureKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_GetBy_SignatureKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_DeleteBy_SignatureKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_DeleteBy_SignatureKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Results_DeleteBy_SignatureKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_HasSignature]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_HasSignature]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Surfaces_HasSignature]
GO
/****** Object:  StoredProcedure [dbo].[GET_RESULT_DETAIL_RAWDATA]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_RESULT_DETAIL_RAWDATA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_RESULT_DETAIL_RAWDATA]
GO
/****** Object:  StoredProcedure [dbo].[GET_RESULT_DETAIL]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_RESULT_DETAIL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_RESULT_DETAIL]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_DeleteNoSignature]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_DeleteNoSignature]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Surfaces_DeleteNoSignature]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_DeleteBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_DeleteBy_ControlRuleID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_DeleteBy_ControlRuleID]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_GetBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_GetBy_ControlRuleID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_GetBy_ControlRuleID]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_AlarmEvent_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRuleDetail_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRuleDetail_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_GetBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_GetBy_ControlRuleID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRuleDetail_GetBy_ControlRuleID]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_DeleteBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_DeleteBy_ControlRuleID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRuleDetail_DeleteBy_ControlRuleID]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRuleDetail_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetBy_AlarmKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_GetBy_AlarmKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteBy_DiskKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteBy_DiskKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteBy_AlarmKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteBy_AlarmKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetBy_DiskKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_GetBy_DiskKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ViolativeDisk_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_GradeMapping_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_GradeMapping_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_GradeMapping_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_GradeMapping_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_GradeMapping_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_GradeMapping_Insert]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_UpdateProcessingDuration]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_UpdateProcessingDuration]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Surfaces_UpdateProcessingDuration]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetBy_RecipeKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_GetBy_RecipeKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteBy_SurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_DeleteBy_SurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteBy_RecipeKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_DeleteBy_RecipeKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetBy_SurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Processed_GetBy_SurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_DeleteBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_DeleteBy_RecipeKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_RecipeData_DeleteBy_RecipeKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_RecipeData_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_RecipeData_Update]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Recipes_GetRawData]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Recipes_GetRawData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Recipes_GetRawData]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_GetBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_GetBy_RecipeKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_RecipeData_GetBy_RecipeKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_RecipeData_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_RecipeData_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disks_Update_CassID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks_Update_CassID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Disks_Update_CassID]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disk_GetKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disk_GetKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Disk_GetKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_Update]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disks_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Disks_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_Insert]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disks_Update_CassID_KKlot_KKSLot]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks_Update_CassID_KKlot_KKSLot]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Disks_Update_CassID_KKlot_KKSLot]
GO
/****** Object:  StoredProcedure [dbo].[GET_KOI_PARAM]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_KOI_PARAM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_KOI_PARAM]
GO
/****** Object:  StoredProcedure [dbo].[GET_EIS_PARAM]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_EIS_PARAM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_EIS_PARAM]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjects_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjects_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjects_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjects_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjects_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjects_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_KOI_Headers_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_KOI_Headers_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_KOI_Headers_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_PrivateKey_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_PrivateKey_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_PrivateKey_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_PrivateKey_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_PrivateKey_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_PrivateKey_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Stations_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Stations_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Station_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Station_GetByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Station_GetByName]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Stations_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Stations_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Stations_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Stations_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_GetDataSource]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetDataSource]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetDataSource]
GO
/****** Object:  StoredProcedure [dbo].[_GetSingleLayer]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSingleLayer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSingleLayer]
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceOfDisk]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceOfDisk]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSourceOfDisk]
GO
/****** Object:  StoredProcedure [dbo].[ExportView]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportView]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ExportView]
GO
/****** Object:  StoredProcedure [dbo].[ExportView_SurfaceOfSignature]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportView_SurfaceOfSignature]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ExportView_SurfaceOfSignature]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Signatures_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Signatures_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskSizes_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskSizes_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_WordCells_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_WordCells_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_WordCells_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_WordCells_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[DDA_WordCells_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_WordCells_GetByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_WordCells_GetByName]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_WordCells_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_WordCells_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_LastUpdateTable_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_LastUpdateTable_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_LastUpdateTable_Insert]
GO
/****** Object:  StoredProcedure [dbo].[LastUpdateTable_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastUpdateTable_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LastUpdateTable_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_LastUpdateTable_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_LastUpdateTable_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_LastUpdateTable_Update]
GO
/****** Object:  StoredProcedure [dbo].[LastUpdateTable_GetLastDateTime]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastUpdateTable_GetLastDateTime]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[LastUpdateTable_GetLastDateTime]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRule_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRule_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRule_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRule_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRule_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ControlRule_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskHeaders_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskHeaders_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskHeaders_Insert]
GO
/****** Object:  StoredProcedure [dbo].[DDA_DiskHeaders_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DiskHeaders_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_DiskHeaders_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_TesterTypes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_TesterTypes_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_TesterTypes_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_TesterTypes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_TesterTypes_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_TesterTypes_Insert]
GO
/****** Object:  StoredProcedure [dbo].[DDA_TesterType_GetByID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_TesterType_GetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_TesterType_GetByID]
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_sysdiagrams_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_sysdiagrams_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_sysdiagrams_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_sysdiagrams_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_sysdiagrams_Update]
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_sysdiagrams_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Fabs_Insert]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Fab_GetByID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Fab_GetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Fab_GetByID]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Fabs_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Fabs_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_FabKey_GetByID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_FabKey_GetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_FabKey_GetByID]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Fabs_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Fabs_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Fabs_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_GetKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_GetKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Surfaces_GetKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_Insert]
GO
/****** Object:  StoredProcedure [dbo].[spDebug_PerformanceByDay]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebug_PerformanceByDay]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDebug_PerformanceByDay]
GO
/****** Object:  StoredProcedure [dbo].[spDebug_PerformanceByHour]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebug_PerformanceByHour]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDebug_PerformanceByHour]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Processed_UpdateProcessedSurface]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Processed_UpdateProcessedSurface]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Processed_UpdateProcessedSurface]
GO
/****** Object:  StoredProcedure [dbo].[GET_NPROCESS_SURFACE]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_NPROCESS_SURFACE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_NPROCESS_SURFACE]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Recipes_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Recipes_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[GET_PROCESS_SURFACE]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_PROCESS_SURFACE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_PROCESS_SURFACE]
GO
/****** Object:  StoredProcedure [dbo].[GetRecipeByKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecipeByKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetRecipeByKey]
GO
/****** Object:  StoredProcedure [dbo].[GET_PREV_RECIPE]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_PREV_RECIPE]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_PREV_RECIPE]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Recipes_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[GetRecipeList]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecipeList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetRecipeList]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Recipes_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Recipes_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Recipes_Update]
GO
/****** Object:  StoredProcedure [dbo].[GetRecipeOrderByKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecipeOrderByKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetRecipeOrderByKey]
GO
/****** Object:  View [dbo].[SingleLayerResult]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SingleLayerResult]'))
DROP VIEW [dbo].[SingleLayerResult]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Products_UpdateFrom_WD_Products]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products_UpdateFrom_WD_Products]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Products_UpdateFrom_WD_Products]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Products_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products_GetByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Products_GetByName]
GO
/****** Object:  StoredProcedure [dbo].[DDA_GET_SURFACE_DATA]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_GET_SURFACE_DATA]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_GET_SURFACE_DATA]
GO
/****** Object:  View [dbo].[DDA_PRODUCT_DISKSIZE]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DDA_PRODUCT_DISKSIZE]'))
DROP VIEW [dbo].[DDA_PRODUCT_DISKSIZE]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Products_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Products_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjectTypes_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjectTypes_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjectTypes_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjectTypes_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjectTypes_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ResultObjectTypes_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[spDDA2EISCopyData]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDDA2EISCopyData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDDA2EISCopyData]
GO
/****** Object:  View [dbo].[ChartView]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ChartView]'))
DROP VIEW [dbo].[ChartView]
GO
/****** Object:  View [dbo].[SingleLayerViewQuery]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SingleLayerViewQuery]'))
DROP VIEW [dbo].[SingleLayerViewQuery]
GO
/****** Object:  View [dbo].[SourceViewQuery]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SourceViewQuery]'))
DROP VIEW [dbo].[SourceViewQuery]
GO
/****** Object:  View [dbo].[DiskViewQuery]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DiskViewQuery]'))
DROP VIEW [dbo].[DiskViewQuery]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_EIS_Resources_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_EIS_Resources_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_EIS_Resources_Insert]
GO
/****** Object:  View [dbo].[SingleLayerView]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SingleLayerView]'))
DROP VIEW [dbo].[SingleLayerView]
GO
/****** Object:  View [dbo].[DiskView]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DiskView]'))
DROP VIEW [dbo].[DiskView]
GO
/****** Object:  View [dbo].[SourceView]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SourceView]'))
DROP VIEW [dbo].[SourceView]
GO
/****** Object:  StoredProcedure [dbo].[DDA_DDA_EIS_Resources_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DDA_EIS_Resources_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_DDA_EIS_Resources_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SysInfo_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SysInfo_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SysInfo_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SysInfo_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SysInfo_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_SysInfo_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ClassLookups_Update]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ClassLookups_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ClassLookups_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ClassLookups_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ClassLookups_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_ClassLookups_GetAll]
GO
/****** Object:  Table [dbo].[DDA_GradeMapping]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_GradeMapping]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_GradeMapping]
GO
/****** Object:  Table [dbo].[DDA_ResultDetailData]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ResultDetailData]
GO
/****** Object:  Table [dbo].[DDA_ResultData]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultData]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ResultData]
GO
/****** Object:  Table [dbo].[DDA_AlarmChart]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_AlarmChart]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_AlarmChart]
GO
/****** Object:  Table [dbo].[COM_DiskResponse]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COM_DiskResponse]') AND type in (N'U'))
DROP TABLE [dbo].[COM_DiskResponse]
GO
/****** Object:  Table [dbo].[DDA_ViolativeDisk]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ViolativeDisk]
GO
/****** Object:  Table [dbo].[DDA_AlarmEvent]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_AlarmEvent]
GO
/****** Object:  Table [dbo].[DDA_ControlRuleDetail]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ControlRuleDetail]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ControlRuleDetail]
GO
/****** Object:  Table [dbo].[DDA_ResultDetail]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ResultDetail]
GO
/****** Object:  Table [dbo].[DDA_Results]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Results]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Results]
GO
/****** Object:  Table [dbo].[DDA_SurfaceData]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_SurfaceData]
GO
/****** Object:  Table [dbo].[DDA_RecipeData]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_RecipeData]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_RecipeData]
GO
/****** Object:  Table [dbo].[DDA_Processed]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Processed]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Processed]
GO
/****** Object:  Table [dbo].[DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Surfaces]
GO
/****** Object:  Table [dbo].[DDA_Disks]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Disks]
GO
/****** Object:  Table [dbo].[DDA_ResultObjects]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultObjects]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ResultObjects]
GO
/****** Object:  Table [dbo].[WD_Products]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WD_Products]') AND type in (N'U'))
DROP TABLE [dbo].[WD_Products]
GO
/****** Object:  Table [dbo].[DDA_Channels]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Channels]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Channels]
GO
/****** Object:  UserDefinedFunction [dbo].[fShiftBit]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fShiftBit]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fShiftBit]
GO
/****** Object:  StoredProcedure [dbo].[GET_EIS_KOI_PARAM]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_EIS_KOI_PARAM]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GET_EIS_KOI_PARAM]
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_DTS_Retrieve_EIS_KOI_Data]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_DTS_Retrieve_EIS_KOI_Data]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_EIS_KOI_Data]
GO
/****** Object:  Table [dbo].[DDA_Grades]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Grades]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Grades]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Grades_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Grades_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Grades_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_GetSurfaceByDisk]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSurfaceByDisk]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSurfaceByDisk]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_Update]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_Update]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_UpdateHasSignatureStatus]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_UpdateHasSignatureStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Surfaces_UpdateHasSignatureStatus]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Surfaces_Insert]
GO
/****** Object:  StoredProcedure [dbo].[_GetParetoChartData]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetParetoChartData]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetParetoChartData]
GO
/****** Object:  Table [dbo].[DDA_KOI_Headers]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_Headers]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_KOI_Headers]
GO
/****** Object:  Table [dbo].[DDA_PrivateKey]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_PrivateKey]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_PrivateKey]
GO
/****** Object:  StoredProcedure [dbo].[utl_KillUsers]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[utl_KillUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[utl_KillUsers]
GO
/****** Object:  Table [dbo].[DDA_Stations]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Stations]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Stations]
GO
/****** Object:  StoredProcedure [dbo].[_GetTotalRow]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetTotalRow]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetTotalRow]
GO
/****** Object:  StoredProcedure [dbo].[Paging_FromView]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paging_FromView]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[Paging_FromView]
GO
/****** Object:  StoredProcedure [dbo].[_GetSurfaceHasSignature]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSurfaceHasSignature]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetSurfaceHasSignature]
GO
/****** Object:  UserDefinedFunction [dbo].[f_Split]    Script Date: 06/14/2010 16:20:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[f_Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[f_Split]
GO
/****** Object:  Table [dbo].[DDA_Signatures]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Signatures]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Signatures]
GO
/****** Object:  Table [dbo].[DDA_DiskSizes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DiskSizes]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_DiskSizes]
GO
/****** Object:  Table [dbo].[DDA_WordCells]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_WordCells]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_WordCells]
GO
/****** Object:  Table [dbo].[DDA_LastUpdateTable]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_LastUpdateTable]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_LastUpdateTable]
GO
/****** Object:  Table [dbo].[DDA_ControlRule]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ControlRule]
GO
/****** Object:  Table [dbo].[DDA_DiskHeaders]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DiskHeaders]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_DiskHeaders]
GO
/****** Object:  Table [dbo].[DDA_TesterTypes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_TesterTypes]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_TesterTypes]
GO
/****** Object:  StoredProcedure [dbo].[spDebugGetResultByResource]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebugGetResultByResource]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDebugGetResultByResource]
GO
/****** Object:  StoredProcedure [dbo].[spDebugGetSourceByResource]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebugGetSourceByResource]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDebugGetSourceByResource]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskSizes_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskSizes_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[sp_Retrieve_EIS_KOI_Data]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Retrieve_EIS_KOI_Data]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_Retrieve_EIS_KOI_Data]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskSizes_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_DiskSizes_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteBy_WordCellKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteBy_WordCellKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_DeleteBy_WordCellKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_TestLocal]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_TestLocal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_KOI_TestLocal]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteBy_StationKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteBy_StationKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_DeleteBy_StationKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteBy_FabKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteBy_FabKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_DeleteBy_FabKey]
GO
/****** Object:  StoredProcedure [dbo].[_GetResultByResultDetailKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultByResultDetailKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetResultByResultDetailKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal]
GO
/****** Object:  StoredProcedure [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal]
GO
/****** Object:  Table [dbo].[DDA_Fabs]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Fabs]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Fabs]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetBy_WordCellKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetBy_WordCellKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_GetBy_WordCellKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetBy_StationKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetBy_StationKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_GetBy_StationKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetBy_FabKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetBy_FabKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_GetBy_FabKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[RemoveRapTierStoredProc]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RemoveRapTierStoredProc]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RemoveRapTierStoredProc]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Disks_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Signatures_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_DeleteBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_DeleteBy_DiskKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_DeleteBy_DiskKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Signatures_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Signatures_DeleteAll]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_GetBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_GetBy_DiskKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_GetBy_DiskKey]
GO
/****** Object:  Synonym [dbo].[DDADM_View]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.synonyms WHERE name = N'DDADM_View')
DROP SYNONYM [dbo].[DDADM_View]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Signatures_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_GetByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Surfaces_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[SignatureGetByName]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SignatureGetByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SignatureGetByName]
GO
/****** Object:  Table [dbo].[DDA_Recipes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Recipes]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Recipes]
GO
/****** Object:  StoredProcedure [dbo].[SignatureGetByKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SignatureGetByKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SignatureGetByKey]
GO
/****** Object:  UserDefinedFunction [dbo].[FormatDateTime]    Script Date: 06/14/2010 16:20:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormatDateTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[FormatDateTime]
GO
/****** Object:  StoredProcedure [dbo].[_GetResultBySurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultBySurfaceKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_GetResultBySurfaceKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_DDA_KOI_Headers_Insert]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DDA_KOI_Headers_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_DDA_KOI_Headers_Insert]
GO
/****** Object:  UserDefinedFunction [dbo].[fDate2String]    Script Date: 06/14/2010 16:20:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fDate2String]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fDate2String]
GO
/****** Object:  UserDefinedFunction [dbo].[fChangeOrder]    Script Date: 06/14/2010 16:20:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fChangeOrder]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[fChangeOrder]
GO
/****** Object:  StoredProcedure [dbo].[RecipeGetByID]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecipeGetByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RecipeGetByID]
GO
/****** Object:  StoredProcedure [dbo].[DDA_Cassettes_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Cassettes_GetByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_Cassettes_GetByName]
GO
/****** Object:  Table [dbo].[DDA_Products]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_Products]
GO
/****** Object:  Table [dbo].[DDA_ResultObjectTypes]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultObjectTypes]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ResultObjectTypes]
GO
/****** Object:  Table [dbo].[DDA_ApplicationData]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ApplicationData]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ApplicationData]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_GetByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Products_GetByPrimaryKey]
GO
/****** Object:  Table [dbo].[DDA_EIS_Resources]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_Resources]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_EIS_Resources]
GO
/****** Object:  Table [dbo].[DDA_SysInfo]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_SysInfo]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_SysInfo]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_GetAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Products_GetAll]
GO
/****** Object:  StoredProcedure [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_DTS_Retrieve_EIS_Data]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Products_DeleteByPrimaryKey]
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_DTS_Retrieve_KOI_Data]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data]
GO
/****** Object:  Table [dbo].[DDA_ClassLookups]    Script Date: 06/14/2010 16:20:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ClassLookups]') AND type in (N'U'))
DROP TABLE [dbo].[DDA_ClassLookups]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_DeleteAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[_DDA_Products_DeleteAll]
GO
/****** Object:  Role [DDADBUser]    Script Date: 06/14/2010 16:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'DDADBUser')
BEGIN
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'DDADBUser' AND type = 'R')
CREATE ROLE [DDADBUser]

END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Deletes all records from the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_Products_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Products]

' 
END
GO
/****** Object:  Table [dbo].[DDA_ClassLookups]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ClassLookups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ClassLookups](
	[ClassID] [int] NOT NULL,
	[ClassName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_ClassLookups] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ClassLookups', N'COLUMN',N'ClassID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ClassID - further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ClassLookups', @level2type=N'COLUMN',@level2name=N'ClassID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ClassLookups', N'COLUMN',N'ClassName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Classname - further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ClassLookups', @level2type=N'COLUMN',@level2name=N'ClassName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ClassLookups', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Channel information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ClassLookups'
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_DTS_Retrieve_KOI_Data]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data] 
	-- Add the parameters for the stored procedure here
	@testcell VARCHAR (5), 
	@lotnum VARCHAR (10),
	@lotslot VARCHAR (2)
AS
BEGIN
	DECLARE @debug BIT
	DECLARE @KKLot VARCHAR(10)
	DECLARE @KKSlot VARCHAR(2)
	DECLARE @CassID VARCHAR(20)
	DECLARE @NSql NVARCHAR(MAX)
	DECLARE @Sql VARCHAR(MAX)
	
	DECLARE  @tmp_table TABLE(Lot_Id VARCHAR(20), Lot_Slot VARCHAR(2), KKLot VARCHAR(10), KKSlot VARCHAR(2), Cass_ID VARCHAR(20))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	SET @KKLot = ''''
	SET @KKSlot = ''''
	SET @CassID = ''''

	IF LEN(@testcell) = 3
	SET @testcell = ''T'' + @testcell

	IF SUBSTRING(@testcell, 2, 1) = ''1''
	BEGIN
		SET @NSql = N''SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM KOI.dbo.tbl_KOI_Rawdata_PN1 KOI1 (NoLock), KOI.dbo.tbl_KOI_Rawdata2_PN1 KOI2(NoLock)''
		SET @NSql = @NSql + '' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = '''''' + @lotnum + '''''' AND Lot_Slot = '''''' + @lotslot + ''''''''
		EXEC master..sp_executesql @NSql, N''@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT'', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT
		
		INSERT INTO @tmp_table (Lot_Id, Lot_Slot, KKLot, KKSlot, Cass_ID) Values (@lotnum, @lotslot, CASE WHEN @KKLot = '''' THEN NULL ELSE @KKLot END, CASE WHEN @KKSlot = '''' THEN NULL ELSE @KKSlot END, CASE WHEN @CassID = '''' THEN NULL ELSE @CassID END)
		EXEC (@Sql) 
	END

	IF SUBSTRING(@testcell, 2, 1) = ''3''
	BEGIN
		SET @NSql = N''SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM KOI.dbo.tbl_KOI_Rawdata_PN2 KOI1 (NoLock), KOI.dbo.tbl_KOI_Rawdata2_PN2 KOI2(NoLock)''
		SET @NSql = @NSql + '' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = '''''' + @lotnum + '''''' AND Lot_Slot = '''''' + @lotslot + ''''''''
		EXEC master..sp_executesql @NSql, N''@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT'', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT

		INSERT INTO @tmp_table (Lot_Id, Lot_Slot, KKLot, KKSlot, Cass_ID) Values (@lotnum, @lotslot, CASE WHEN @KKLot = '''' THEN NULL ELSE @KKLot END, CASE WHEN @KKSlot = '''' THEN NULL ELSE @KKSlot END, CASE WHEN @CassID = '''' THEN NULL ELSE @CassID END)
		EXEC (@Sql) 
	END

	SELECT * FROM @tmp_table
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Deletes a record from the ''DDA_DiskTypes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Products_DeleteByPrimaryKey]
	@ProductKey int
AS
	DELETE FROM [dbo].[DDA_Products] WHERE
		ProductKey = @ProductKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_DTS_Retrieve_EIS_Data]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data] 
	-- Add the parameters for the stored procedure here
	@lotnum VARCHAR (10)
AS
BEGIN
	DECLARE @debug BIT
	
	DECLARE  @tmp_table TABLE(Lotnum VARCHAR(10), Rsc450 VARCHAR(10), Rsc453 VARCHAR(10), Rsc600 VARCHAR(10),
	Rsc725 VARCHAR(10), Rsc766 VARCHAR(10), Rsc769 VARCHAR(10), Rsc771 VARCHAR(10), Rsc764 VARCHAR(10), Rsc575 VARCHAR(10))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	INSERT INTO @tmp_table (Lotnum,Rsc450,Rsc453,Rsc600,Rsc725,Rsc766,Rsc769,Rsc771,Rsc764,Rsc575) 
	SELECT @lotnum, Rsc450, Rsc453, Rsc600, Rsc725, Rsc766 , Rsc769, Rsc771, Rsc764, Rsc575
	FROM EIS.dbo.tbl_Resources_Summary (nolock) WHERE Lotno803804805 = @lotnum
	
	-- Need to add in data also if cannot find any lot no
	if @@Rowcount = 0
	begin
		INSERT INTO @tmp_table (Lotnum) 
		VALUES (@lotnum)
	end

	SELECT * FROM @tmp_table
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Gets all records from the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_Products_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Products]

' 
END
GO
/****** Object:  Table [dbo].[DDA_SysInfo]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_SysInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_SysInfo](
	[SysInfoKey] [smallint] IDENTITY(1,1) NOT NULL,
	[MajorVersion] [int] NOT NULL,
	[MinorVersion] [int] NOT NULL,
	[Build] [int] NOT NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreateData] [datetime] NOT NULL,
	[DBType] [tinyint] NOT NULL,
 CONSTRAINT [PK_DDA_SysInfo] PRIMARY KEY CLUSTERED 
(
	[SysInfoKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON),
 CONSTRAINT [IX_DDA_SysInfo_Combine] UNIQUE NONCLUSTERED 
(
	[MajorVersion] ASC,
	[MinorVersion] ASC,
	[DBType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON),
 CONSTRAINT [IX_DDA_SysInfo_Version] UNIQUE NONCLUSTERED 
(
	[MajorVersion] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'SysInfoKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Information Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'SysInfoKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'MajorVersion'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Major version' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'MajorVersion'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'MinorVersion'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Minor version' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'MinorVersion'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'Build'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Building number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'Build'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Version  description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'Description'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'CreateData'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DDADB version time stamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'CreateData'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', N'COLUMN',N'DBType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DDADB type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo', @level2type=N'COLUMN',@level2name=N'DBType'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SysInfo', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DDA Database version information. The current version is 1.0.0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SysInfo'
GO
/****** Object:  Table [dbo].[DDA_EIS_Resources]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_Resources]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_EIS_Resources](
	[LotNum] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AutoNumber] [bigint] IDENTITY(1,1) NOT NULL,
	[Rsc725] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc769] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc771] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc764] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc575] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc450] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc453] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc600] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc766] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateTime725] [datetime] NULL,
	[DateTime769] [datetime] NULL,
	[DateTime771] [datetime] NULL,
	[DateTime764] [datetime] NULL,
	[DateTime575] [datetime] NULL,
	[DateTime450] [datetime] NULL,
	[DateTime453] [datetime] NULL,
	[DateTime600] [datetime] NULL,
	[DateTime766] [datetime] NULL,
 CONSTRAINT [PK_DDA_Resources] PRIMARY KEY CLUSTERED 
(
	[LotNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_Resources]') AND name = N'IX_DDA_Resources_AutoNumber')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_Resources_AutoNumber] ON [dbo].[DDA_EIS_Resources] 
(
	[AutoNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Gets a record from the ''DDA_DiskTypes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Products_GetByPrimaryKey]
	@ProductKey int
AS
	SELECT * FROM [dbo].[DDA_Products] WHERE
		ProductKey = @ProductKey

' 
END
GO
/****** Object:  Table [dbo].[DDA_ApplicationData]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ApplicationData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ApplicationData](
	[Key] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Value] [nvarchar](1024) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_ApplicationData] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[DDA_ResultObjectTypes]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultObjectTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ResultObjectTypes](
	[ObjectTypeKey] [int] NOT NULL,
	[ObjectTypeName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_ObjectTypes] PRIMARY KEY CLUSTERED 
(
	[ObjectTypeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultObjectTypes', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result object type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultObjectTypes'
GO
/****** Object:  Table [dbo].[DDA_Products]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Products](
	[ProductKey] [int] IDENTITY(1,1) NOT NULL,
	[ProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Prod_Class] [varchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_Products] PRIMARY KEY CLUSTERED 
(
	[ProductKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products]') AND name = N'IX_DDA_Products_ProductCode')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_Products_ProductCode] ON [dbo].[DDA_Products] 
(
	[ProductCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
/****** Object:  StoredProcedure [dbo].[DDA_Cassettes_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Cassettes_GetByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Updates a record in the ''DDA_DiskPhysical'' table.
CREATE PROCEDURE [dbo].[DDA_Cassettes_GetByName]
	@CassetteID nvarchar(50)
AS
	SELECT TOP 1 CassetteKey FROM DDA_Cassettes WHERE CassetteID = @CassetteID

' 
END
GO
/****** Object:  StoredProcedure [dbo].[RecipeGetByID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RecipeGetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[RecipeGetByID]
	@RecipeKey int
	
AS
BEGIN
	
	SET NOCOUNT ON;
	Select Top 1 RecipeKey from DDA_Recipes where
	RecipeKey =@RecipeKey	
	
    
END


' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fChangeOrder]    Script Date: 06/14/2010 16:20:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fChangeOrder]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,CANG>
-- =============================================
CREATE FUNCTION [dbo].[fChangeOrder]
(
	@ORDER VARCHAR(1024)
)
RETURNS VARCHAR(1024)
AS
BEGIN
	RETURN REPLACE (@ORDER, '','' , '' DESC,'') + '' DESC''
END
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fDate2String]    Script Date: 06/14/2010 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fDate2String]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,CANG>
-- =============================================
CREATE FUNCTION [dbo].[fDate2String] 
(
	@Datetime datetime
)
RETURNS VARCHAR(20)
AS
BEGIN
	RETURN CONVERT(VARCHAR,@Datetime,120)
END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_DDA_KOI_Headers_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DDA_KOI_Headers_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_DDA_KOI_Headers_Insert]
	@LotNum varchar(10),
	@slotNum smallint,	
	@KKLot varchar(10),
	@KKSlot varchar(2),	
	@Cass_ID VARCHAR(10)
AS
BEGIN
	insert into DDA_KOI_Headers(Lot_id,Lot_Slot,KKLot,KKSlot,Cass_ID)
	values(@LotNum,@slotNum,@KKLot,@KKSlot,@Cass_ID)
END




' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetResultBySurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultBySurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

	CREATE PROCEDURE [dbo].[_GetResultBySurfaceKey]
		-- Add the parameters for the stored procedure here
		@sqlWhere nvarchar(4000)
	AS
	BEGIN
		-- SET NOCOUNT ON added to prevent extra result sets from
		-- interfering with SELECT statements.
		SET NOCOUNT ON;

		-- Insert statements for procedure here
		Declare @SQL nvarchar(4000)

--		SET @SQL = ''SELECT DISTINCT ResultKey, ResultDetailKey, SignatureKey, SignatureName, 
--					NumberOfSignatureDefect, PercentOfSignatureDefect
--					FROM [SingleLayerView] 
--					WHERE '' + @sqlWhere
		
		SET @SQL = ''SELECT R.ResultKey, RD.ResultDetailKey, Si.SignatureKey, Si.SignatureName,
					RD.NumberOfDefect AS NumberOfSignatureDefect, RD.PercentOfDefect AS PercentOfSignatureDefect
					FROM DDA_Surfaces S, DDA_ResultDetail RD, DDA_Results R, DDA_Signatures Si
					WHERE S.SurfaceKey = RD.SurfaceKey AND RD.ResultKey = R.ResultKey AND Si.SignatureKey = R.SignatureKey AND R.IsMultiLayer = 0 AND '' + @sqlWhere

		EXEC (@SQL)
	END' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[FormatDateTime]    Script Date: 06/14/2010 16:20:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FormatDateTime]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,CANG>
-- =============================================

CREATE FUNCTION [dbo].[FormatDateTime] 
( 
    @dt DATETIME, 
    @format VARCHAR(16) 
) 

RETURNS VARCHAR(64) 
AS 
BEGIN 
    DECLARE @dtVC VARCHAR(64) 

    SELECT @dtVC = CASE @format 
 
    WHEN ''LONGDATE'' THEN 
 
        DATENAME(dw, @dt) 
        + '','' + SPACE(1) + DATENAME(m, @dt) 
        + SPACE(1) + CAST(DAY(@dt) AS VARCHAR(2)) 
        + '','' + SPACE(1) + CAST(YEAR(@dt) AS CHAR(4)) 
 
    WHEN ''LONGDATEANDTIME'' THEN 
 
        DATENAME(dw, @dt) 
        + '','' + SPACE(1) + DATENAME(m, @dt) 
        + SPACE(1) + CAST(DAY(@dt) AS VARCHAR(2)) 
        + '','' + SPACE(1) + CAST(YEAR(@dt) AS CHAR(4)) 
        + SPACE(1) + RIGHT(CONVERT(CHAR(20), 
        @dt - CONVERT(DATETIME, CONVERT(CHAR(8), 
        @dt, 112)), 22), 11) 
 
    WHEN ''SHORTDATE'' THEN 
 
        LEFT(CONVERT(CHAR(19), @dt, 0), 11) 
 
    WHEN ''SHORTDATEANDTIME'' THEN 
 
        REPLACE(REPLACE(CONVERT(CHAR(19), @dt, 0), 
            ''AM'', '' AM''), ''PM'', '' PM'') 
 
    WHEN ''UNIXTIMESTAMP'' THEN 
 
        CAST(DATEDIFF(SECOND, ''19700101'', @dt) 
        AS VARCHAR(64)) 
 
    WHEN ''YYYYMMDD'' THEN 
 
        CONVERT(CHAR(8), @dt, 112) 
 
    WHEN ''YYYY-MM-DD'' THEN 
 
        CONVERT(CHAR(10), @dt, 23) 
 
    WHEN ''YYMMDD'' THEN 
 
        CONVERT(VARCHAR(8), @dt, 12) 
 
    WHEN ''YY-MM-DD'' THEN 
 
        STUFF(STUFF(CONVERT(VARCHAR(8), @dt, 12), 
        5, 0, ''-''), 3, 0, ''-'') 
 
    WHEN ''MMDDYY'' THEN 
 
        REPLACE(CONVERT(CHAR(8), @dt, 10), ''-'', SPACE(0)) 
 
    WHEN ''MM-DD-YY'' THEN 
 
        CONVERT(CHAR(8), @dt, 10) 
 
    WHEN ''MM/DD/YY'' THEN 
 
        CONVERT(CHAR(8), @dt, 1) 
 
    WHEN ''MM/DD/YYYY'' THEN 
 
        CONVERT(CHAR(10), @dt, 101) 
 
    WHEN ''DDMMYY'' THEN 
 
        REPLACE(CONVERT(CHAR(8), @dt, 3), ''/'', SPACE(0)) 
 
    WHEN ''DD-MM-YY'' THEN 
 
        REPLACE(CONVERT(CHAR(8), @dt, 3), ''/'', ''-'') 
 
    WHEN ''DD/MM/YY'' THEN 
 
        CONVERT(CHAR(8), @dt, 3) 
 
    WHEN ''DD/MM/YYYY'' THEN 
 
        CONVERT(CHAR(10), @dt, 103) 
 
    WHEN ''HH:MM:SS 24'' THEN 
 
        CONVERT(CHAR(8), @dt, 8) 
 
    WHEN ''HH:MM 24'' THEN 
 
        LEFT(CONVERT(VARCHAR(8), @dt, 8), 5) 
 
    WHEN ''HH:MM:SS 12'' THEN 
 
        LTRIM(RIGHT(CONVERT(VARCHAR(20), @dt, 22), 11)) 
 
    WHEN ''HH:MM 12'' THEN 
 
        LTRIM(SUBSTRING(CONVERT( 
        VARCHAR(20), @dt, 22), 10, 5) 
        + RIGHT(CONVERT(VARCHAR(20), @dt, 22), 3)) 
		
	WHEN ''YYYY-MM'' THEN
		SUBSTRING(CONVERT(CHAR(10), @dt, 23),1,7)

	WHEN ''YYYY'' THEN
		SUBSTRING(CONVERT(CHAR(10), @dt, 23),1,4)

     ELSE 
 
        ''Invalid format specified'' 
 
    END 
    RETURN @dtVC 
END 
' 
END
GO
/****** Object:  StoredProcedure [dbo].[SignatureGetByKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SignatureGetByKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Gets a record from the ''DDA_Signatures'' table using the primary key value.
CREATE PROCEDURE [dbo].[SignatureGetByKey]
	@SignatureKey int
AS
	SELECT TOP 1 SignatureKey FROM [dbo].[DDA_Signatures] WHERE
		[SignatureKey] = @SignatureKey

 ' 
END
GO
/****** Object:  Table [dbo].[DDA_Recipes]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Recipes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Recipes](
	[RecipeKey] [int] IDENTITY(1,1) NOT NULL,
	[RecipeName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SignatureKey] [int] NULL,
	[PrevRecipeKey] [int] NULL,
	[Description] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Status] [tinyint] NULL,
	[TesterType] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BreakWhenFound] [bit] NULL,
 CONSTRAINT [PK_DDA_Recipes] PRIMARY KEY CLUSTERED 
(
	[RecipeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'RecipeKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RecipeKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'RecipeKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'RecipeName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recipe name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'RecipeName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'SignatureKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SSA signature key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'SignatureKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'PrevRecipeKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Preceding recipe key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'PrevRecipeKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recipename long description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'Description'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'Status'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 : normal, 1 : Running, 2: Edited...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'Status'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', N'COLUMN',N'TesterType'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TesterType is wildcard' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes', @level2type=N'COLUMN',@level2name=N'TesterType'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Recipes', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recipe information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Recipes'
GO
/****** Object:  StoredProcedure [dbo].[SignatureGetByName]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SignatureGetByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SignatureGetByName]
	-- Add the parameters for the stored procedure here
	@SignatureName nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select Top 1 SignatureKey from DDA_Signatures where SignatureName =@SignatureName
END







' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Surfaces'' table.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Surfaces]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Surfaces'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_GetByPrimaryKey]
	@SurfaceKey bigint
AS
	SELECT * FROM [dbo].[DDA_Surfaces] WHERE
		[SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Signatures'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Signatures_GetByPrimaryKey]
	@SignatureKey int
AS
	SELECT * FROM [dbo].[DDA_Signatures] WHERE
		[SignatureKey] = @SignatureKey
' 
END
GO
/****** Object:  Synonym [dbo].[DDADM_View]    Script Date: 06/14/2010 16:20:28 ******/
IF NOT EXISTS (SELECT * FROM sys.synonyms WHERE name = N'DDADM_View')
CREATE SYNONYM [dbo].[DDADM_View] FOR [DDADM].[dbo].[DM_View]
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_GetBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_GetBy_DiskKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_GetBy_DiskKey]
	@DiskKey bigint
AS
	SELECT * FROM [dbo].[DDA_Surfaces] WHERE [DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Signatures'' table.
CREATE PROCEDURE [dbo].[_DDA_Signatures_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Signatures]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Surfaces'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_DeleteByPrimaryKey]
	@SurfaceKey bigint
AS
	DELETE FROM [dbo].[DDA_Surfaces] WHERE
		[SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Signatures'' table.
CREATE PROCEDURE [dbo].[_DDA_Signatures_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Signatures]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_DeleteBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_DeleteBy_DiskKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Surfaces'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_DeleteBy_DiskKey]
	@DiskKey bigint
AS
	DELETE FROM [dbo].[DDA_Surfaces] WHERE [DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Signatures'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Signatures_DeleteByPrimaryKey]
	@SignatureKey int
AS
	DELETE FROM [dbo].[DDA_Signatures] WHERE
		[SignatureKey] = @SignatureKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Surfaces'' table.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Surfaces]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Disks'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Disks_GetByPrimaryKey]
	@DiskKey bigint
AS
	SELECT * FROM [dbo].[DDA_Disks] WHERE
		[DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[RemoveRapTierStoredProc]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RemoveRapTierStoredProc]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Cang
-- Create date: 2007-11-05
-- Description:	Remove generated stored proc by RapTier
-- =============================================
CREATE PROCEDURE [dbo].[RemoveRapTierStoredProc]
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE CURSP CURSOR
	FOR
	SELECT [name] FROM sysobjects WHERE [type]=''P'' and [name] like ''_DDA%''

	DECLARE @SPNAME VARCHAR(255)
	DECLARE @SQL VARCHAR(255)
	OPEN CURSP
	FETCH NEXT FROM CURSP INTO @SPNAME
	While (@@FETCH_STATUS <> -1)
	BEGIN
		SET @SQL = ''DROP PROCEDURE '' + @SPNAME
		EXEC(@SQL)
		PRINT @SPNAME + '' WAS REMOVED''
		FETCH NEXT FROM CURSP INTO @SPNAME
	END

	CLOSE CURSP
	DEALLOCATE CURSP
    
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Disks'' table.
CREATE PROCEDURE [dbo].[_DDA_Disks_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Disks]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetBy_FabKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetBy_FabKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Disks_GetBy_FabKey]
	@FabKey smallint
AS
	IF @FabKey IS NULL
		SELECT * FROM [dbo].[DDA_Disks] WHERE [FabKey] IS NULL
	ELSE
		SELECT * FROM [dbo].[DDA_Disks] WHERE [FabKey] = @FabKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetBy_StationKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetBy_StationKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Disks_GetBy_StationKey]
	@StationKey int
AS
	SELECT * FROM [dbo].[DDA_Disks] WHERE [StationKey] = @StationKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_GetBy_WordCellKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_GetBy_WordCellKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Disks_GetBy_WordCellKey]
	@WordCellKey int
AS
	SELECT * FROM [dbo].[DDA_Disks] WHERE [WordCellKey] = @WordCellKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Disks'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Disks_DeleteByPrimaryKey]
	@DiskKey bigint
AS
	DELETE FROM [dbo].[DDA_Disks] WHERE
		[DiskKey] = @DiskKey
' 
END
GO
/****** Object:  Table [dbo].[DDA_Fabs]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Fabs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Fabs](
	[FabKey] [smallint] IDENTITY(1,1) NOT NULL,
	[FabID] [nvarchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FabUUID] [nvarchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_IDA_Fab] PRIMARY KEY CLUSTERED 
(
	[FabKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Fabs]') AND name = N'IX_DDA_Fab_FabID')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_Fab_FabID] ON [dbo].[DDA_Fabs] 
(
	[FabID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Fabs', N'COLUMN',N'FabKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fab Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Fabs', @level2type=N'COLUMN',@level2name=N'FabKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Fabs', N'COLUMN',N'FabID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fab Indentification' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Fabs', @level2type=N'COLUMN',@level2name=N'FabID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Fabs', N'COLUMN',N'FabUUID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fab Unique Universal Indentification ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Fabs', @level2type=N'COLUMN',@level2name=N'FabUUID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Fabs', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fab Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Fabs', @level2type=N'COLUMN',@level2name=N'Description'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Fabs', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fab Identification Information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Fabs'
GO
/****** Object:  StoredProcedure [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_EIS_DTS_Retrieve_EIS_Data_TestCocal] 
	-- Add the parameters for the stored procedure here
	@lotnum VARCHAR (10)
AS
BEGIN
	DECLARE @debug BIT
	
	DECLARE  @tmp_table TABLE(Lotnum VARCHAR(10), Rsc450 VARCHAR(10), Rsc453 VARCHAR(10), Rsc600 VARCHAR(10),
	Rsc725 VARCHAR(10), Rsc766 VARCHAR(10), Rsc769 VARCHAR(10), Rsc771 VARCHAR(10), Rsc764 VARCHAR(10), Rsc575 VARCHAR(10))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	INSERT INTO @tmp_table (Lotnum,Rsc450,Rsc453,Rsc600,Rsc725,Rsc766,Rsc769,Rsc771,Rsc764,Rsc575) 
	values(@lotnum, ''Rsc450'', ''Rsc453'', ''Rsc600'', ''Rsc725'', ''Rsc766'' , ''Rsc769'', ''Rsc771'', ''Rsc764'', ''Rsc575'')
	
	
	-- Need to add in data also if cannot find any lot no
	if @@Rowcount = 0
	begin
		INSERT INTO @tmp_table (Lotnum) 
		VALUES (@lotnum)
	end

	SELECT * FROM @tmp_table
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data_TestLocal] 
	-- Add the parameters for the stored procedure here
	@testcell VARCHAR (5), 
	@lotnum VARCHAR (10),
	@lotslot VARCHAR (2)
AS
BEGIN
	DECLARE @debug BIT
	DECLARE @KKLot VARCHAR(10)
	DECLARE @KKSlot VARCHAR(2)
	DECLARE @CassID VARCHAR(20)
	DECLARE @NSql NVARCHAR(MAX)
	DECLARE @Sql VARCHAR(MAX)
	
	DECLARE  @tmp_table TABLE(Lot_Id VARCHAR(20), Lot_Slot VARCHAR(2), KKLot VARCHAR(10), KKSlot VARCHAR(2), Cass_ID VARCHAR(20))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	SET @KKLot = ''''
	SET @KKSlot = ''''
	SET @CassID = ''''
	
	INSERT INTO @tmp_table (Lot_Id, Lot_Slot, KKLot, KKSlot, Cass_ID) Values (@lotnum, @lotslot, ''x'',''s'',''cs'')
	
	SELECT * FROM @tmp_table
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetResultByResultDetailKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultByResultDetailKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



CREATE PROCEDURE [dbo].[_GetResultByResultDetailKey]
	-- Add the parameters for the stored procedure here
	@ResultDetailKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM [SingleLayerView] 
	WHERE [ResultDetailKey] = @ResultDetailKey
END







' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteBy_FabKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteBy_FabKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Disks'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Disks_DeleteBy_FabKey]
	@FabKey smallint
AS
	IF @FabKey IS NULL
		DELETE FROM [dbo].[DDA_Disks] WHERE [FabKey] IS NULL
	ELSE
		DELETE FROM [dbo].[DDA_Disks] WHERE [FabKey] = @FabKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteBy_StationKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteBy_StationKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Disks'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Disks_DeleteBy_StationKey]
	@StationKey int
AS
	DELETE FROM [dbo].[DDA_Disks] WHERE [StationKey] = @StationKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_TestLocal]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_TestLocal]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_KOI_TestLocal] 
	-- Add the parameters for the stored procedure here
	@testcell VARCHAR (5), 
	@lotnum VARCHAR (10),
	@lotslot VARCHAR (2)
AS
BEGIN

	DECLARE @debug BIT
	DECLARE @KKLot VARCHAR(10)
	DECLARE @KKSlot VARCHAR(2)
	DECLARE @CassID VARCHAR(20)
	DECLARE @NSql NVARCHAR(MAX)
	DECLARE @Sql VARCHAR(MAX)
	
	DECLARE  @tmp_table TABLE(Lotnum VARCHAR(10), Rsc450 VARCHAR(10), Rsc453 VARCHAR(10), Rsc600 VARCHAR(10),
	Rsc725 VARCHAR(10), Rsc766 VARCHAR(10), Rsc769 VARCHAR(10), Rsc771 VARCHAR(10), Rsc764 VARCHAR(10), Rsc575 VARCHAR(10),
	KKLot VARCHAR(10), KKSlot VARCHAR(2), Cass_ID VARCHAR(20))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	SET @KKLot = ''''
	SET @KKSlot = ''''
	SET @CassID = ''''

	INSERT INTO @tmp_table (Lotnum,Rsc450,Rsc453,Rsc600,Rsc725,Rsc766,Rsc769,Rsc771,Rsc764,Rsc575) 
	SELECT @lotnum, '''','''','''','''','''','''','''','''','''' 
	
	UPDATE @tmp_table SET Cass_ID = @CassID 



	SELECT * FROM @tmp_table

END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteBy_WordCellKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteBy_WordCellKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Disks'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Disks_DeleteBy_WordCellKey]
	@WordCellKey int
AS
	DELETE FROM [dbo].[DDA_Disks] WHERE [WordCellKey] = @WordCellKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Disks'' table.
CREATE PROCEDURE [dbo].[_DDA_Disks_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Disks]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Gets all records from the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_DiskSizes_GetAll]
AS
	SELECT * FROM [dbo].[DDA_DiskSizes]

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Gets a record from the ''DDA_DiskTypes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_DiskSizes_GetByPrimaryKey]
	@DiskSizeKey int
AS
	SELECT * FROM [dbo].[DDA_DiskSizes] WHERE
		DiskSizeKey = @DiskSizeKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Retrieve_EIS_KOI_Data]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Retrieve_EIS_KOI_Data]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		JR Lee
-- Create date: 29 August 2008
-- Description:	DDA Data Linkage with EIS and KOI
-- =============================================
CREATE PROCEDURE [dbo].[sp_Retrieve_EIS_KOI_Data] 
	-- Add the parameters for the stored procedure here
	@testcell VARCHAR (5), 
	@lotnum VARCHAR (10),
	@lotslot VARCHAR (2)
AS
BEGIN
	DECLARE @debug BIT
	DECLARE @KKLot VARCHAR(10)
	DECLARE @KKSlot VARCHAR(2)
	DECLARE @CassID VARCHAR(20)
	DECLARE @NSql NVARCHAR(MAX)
	DECLARE @Sql VARCHAR(MAX)
	
	DECLARE  @tmp_table TABLE(Lotnum VARCHAR(10), Rsc725 VARCHAR(10),  Rsc769 VARCHAR(10),  
	Rsc771 VARCHAR(10),  Rsc764 VARCHAR(10),  Rsc575 VARCHAR(10),
	KKLot VARCHAR(10), KKSlot VARCHAR(2), Cass_ID VARCHAR(20))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	SET @KKLot = ''''
	SET @KKSlot = ''''
	SET @CassID = ''''

	INSERT INTO @tmp_table (Lotnum,Rsc725,Rsc769,Rsc771,Rsc764,Rsc575) 
	SELECT @lotnum, CASE WHEN Rsc725 IS NULL THEN '''' ELSE Rsc725 END, CASE WHEN Rsc769 IS NULL THEN '''' ELSE Rsc769 END, CASE WHEN Rsc771 IS NULL THEN '''' ELSE Rsc771 END, CASE WHEN Rsc764 IS NULL THEN '''' ELSE Rsc764 END, CASE WHEN Rsc575 IS NULL THEN '''' ELSE Rsc575 END 
	FROM EIS.dbo.tbl_Resources_Summary (nolock) WHERE Lotno803804805 = @lotnum

	IF SUBSTRING(@testcell, 2, 1) = ''1''
	BEGIN
		SET @NSql = N''SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM KOI.dbo.tbl_KOI_Rawdata_PN1 KOI1 (NoLock), KOI.dbo.tbl_KOI_Rawdata2_PN1 KOI2(NoLock)''
		SET @NSql = @NSql + '' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = '''''' + @lotnum + '''''' AND Lot_Slot = '''''' + @lotslot + ''''''''
		EXEC master..sp_executesql @NSql, N''@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT'', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT
		
		UPDATE @tmp_table SET KKLot = @KKLot , KKSlot = @KKSlot ,  Cass_ID = @CassID 
		EXEC (@Sql) 
	END

	IF SUBSTRING(@testcell, 2, 1) = ''3''
	BEGIN
		SET @NSql = N''SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM KOI.dbo.tbl_KOI_Rawdata_PN2 KOI1 (NoLock), KOI.dbo.tbl_KOI_Rawdata2_PN2 KOI2(NoLock)''
		SET @NSql = @NSql + '' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = '''''' + @lotnum + '''''' AND Lot_Slot = '''''' + @lotslot + ''''''''
		EXEC master..sp_executesql @NSql, N''@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT'', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT

		UPDATE @tmp_table SET KKLot = @KKLot , KKSlot = @KKSlot ,  Cass_ID = @CassID 
		EXEC (@Sql) 
	END

	SELECT * FROM @tmp_table
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Deletes a record from the ''DDA_DiskTypes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_DiskSizes_DeleteByPrimaryKey]
	@DiskSizeKey int
AS
	DELETE FROM [dbo].[DDA_DiskSizes] WHERE
		DiskSizeKey = @DiskSizeKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Deletes all records from the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_DiskSizes_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_DiskSizes]

' 
END
GO
/****** Object:  StoredProcedure [dbo].[spDebugGetSourceByResource]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebugGetSourceByResource]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--spDebugGetSourceByResource ''2009-03-03 00:00:00'',''2009-03-03 04:00:00'',''PN2 MRS Map Files'',''MRS'',''GGW7109'',''Rsc725'',''MA15P2''

CREATE PROCEDURE [dbo].[spDebugGetSourceByResource]
@FromDate datetime,
@ToDate datetime,
@FabID varchar(100),
@TesterType varchar(50),
@ProductName varchar(50),
@ResourceType varchar(10),
@ResourceValue varchar(100)
AS


DECLARE @SQL NVARCHAR(4000)

SET  @SQL = ''SELECT   DDA_Disks.DiskKey,DDA_Surfaces.Surface,LotNo,SlotNum
FROM         DDA_Fabs INNER JOIN
                      DDA_Disks ON DDA_Fabs.FabKey = DDA_Disks.FabKey INNER JOIN
                      DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey INNER JOIN
                      DDA_TesterTypes ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID INNER JOIN
                      DDA_Products ON DDA_Disks.ProductKey = DDA_Products.ProductKey INNER JOIN
                      DDA_EIS_Resources ON DDA_Disks.LotNo = DDA_EIS_Resources.LotNum
WHERE DDA_Fabs.FabID = '''''' + @FabID + ''''''
AND TestDate >= '''''' + CAST(@FromDate AS VARCHAR) + '''''' AND TestDate < '''''' + CAST(@ToDate AS VARCHAR) + ''''''
AND DDA_TesterTypes.TesterType = ''''''+ @TesterType +''''''
AND DDA_Products.ProductCode = ''''''+ @ProductName+''''''
AND DDA_EIS_Resources.''+ @ResourceType + '' = '''''' + @ResourceValue + ''''''
ORDER BY DDA_Disks.DiskKey,DDA_Surfaces.Surface
''

--PRINT @SQL

EXEC (@SQL)' 
END
GO
/****** Object:  StoredProcedure [dbo].[spDebugGetResultByResource]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebugGetResultByResource]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'--spDebugGetResultByResource ''2009-03-03 00:00:00'',''2009-03-03 04:00:00'',''PN2 MRS Map Files'',''MRS'',''GGW7109'',''Rsc725'',''MA15P2'',''66''

create PROCEDURE [dbo].[spDebugGetResultByResource]
@FromDate datetime,
@ToDate datetime,
@FabID varchar(100),
@TesterType varchar(50),
@ProductName varchar(50),
@ResourceType varchar(10),
@ResourceValue varchar(100),
@Grade varchar(10)
AS


DECLARE @SQL NVARCHAR(4000)

SET  @SQL = ''SELECT		 DDA_Disks.DiskKey,DDA_Surfaces.Surface,LotNo,SlotNum
FROM         DDA_Fabs INNER JOIN
                      DDA_Disks ON DDA_Fabs.FabKey = DDA_Disks.FabKey INNER JOIN
                      DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey INNER JOIN
                      DDA_TesterTypes ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID INNER JOIN
                      DDA_Products ON DDA_Disks.ProductKey = DDA_Products.ProductKey INNER JOIN
                      DDA_ResultDetail ON DDA_Surfaces.SurfaceKey = DDA_ResultDetail.SurfaceKey INNER JOIN
                      DDA_Results ON DDA_ResultDetail.ResultKey = DDA_Results.ResultKey INNER JOIN
                      DDA_Signatures ON DDA_Results.SignatureKey = DDA_Signatures.SignatureKey INNER JOIN
                      DDA_GradeMapping ON DDA_Signatures.SignatureKey = DDA_GradeMapping.SignatureKey INNER JOIN
					  DDA_Grades ON DDA_Grades.GradeKey = DDA_GradeMapping.GradeKey LEFT OUTER JOIN
                      DDA_EIS_Resources ON DDA_Disks.LotNo = DDA_EIS_Resources.LotNum
WHERE DDA_Fabs.FabID = '''''' + @FabID + ''''''
AND TestDate >= '''''' + CAST(@FromDate AS VARCHAR) + '''''' AND TestDate < '''''' + CAST(@ToDate AS VARCHAR) + ''''''
AND DDA_TesterTypes.TesterType = ''''''+ @TesterType +''''''
AND DDA_Products.ProductCode = ''''''+ @ProductName+''''''
AND DDA_EIS_Resources.''+ @ResourceType + '' = '''''' + @ResourceValue + ''''''
AND DDA_Grades.Grade ='' + @Grade + ''
ORDER BY DDA_Disks.DiskKey,DDA_Surfaces.Surface''

--PRINT @SQL

EXEC (@SQL)' 
END
GO
/****** Object:  Table [dbo].[DDA_TesterTypes]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_TesterTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_TesterTypes](
	[TesterTypeID] [smallint] IDENTITY(1,1) NOT NULL,
	[TesterType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_Formats] PRIMARY KEY CLUSTERED 
(
	[TesterTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[DDA_DiskHeaders]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DiskHeaders]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_DiskHeaders](
	[LotNum] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SlotNum] [smallint] NOT NULL,
	[WordCellKey] [int] NOT NULL,
	[Rsc725] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc769] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc771] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc764] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc575] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KKLot] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KKSlot] [varchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc450] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc453] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc600] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Rsc766] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_DiskHeaders] PRIMARY KEY CLUSTERED 
(
	[LotNum] ASC,
	[SlotNum] ASC,
	[WordCellKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[DDA_ControlRule]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ControlRule](
	[ControlRuleID] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Title] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubCategory] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Category] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ControlRule] PRIMARY KEY CLUSTERED 
(
	[ControlRuleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRule', N'COLUMN',N'ControlRuleID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule UUID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRule', @level2type=N'COLUMN',@level2name=N'ControlRuleID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRule', N'COLUMN',N'Title'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule Title' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRule', @level2type=N'COLUMN',@level2name=N'Title'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRule', N'COLUMN',N'SubCategory'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule sub-category' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRule', @level2type=N'COLUMN',@level2name=N'SubCategory'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRule', N'COLUMN',N'Category'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule category' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRule', @level2type=N'COLUMN',@level2name=N'Category'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRule', N'COLUMN',N'Description'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRule', @level2type=N'COLUMN',@level2name=N'Description'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRule', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control rule Master table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRule'
GO
/****** Object:  Table [dbo].[DDA_LastUpdateTable]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_LastUpdateTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_LastUpdateTable](
	[TableName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastDateTime] [datetime] NULL,
 CONSTRAINT [PK_DDA_LastUpdateTable] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_LastUpdateTable', N'COLUMN',N'TableName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Table name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_LastUpdateTable', @level2type=N'COLUMN',@level2name=N'TableName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_LastUpdateTable', N'COLUMN',N'LastDateTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Last updating time to table name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_LastUpdateTable', @level2type=N'COLUMN',@level2name=N'LastDateTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_LastUpdateTable', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Real time metadata' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_LastUpdateTable'
GO
/****** Object:  Table [dbo].[DDA_WordCells]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_WordCells]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_WordCells](
	[WordCellKey] [int] IDENTITY(1,1) NOT NULL,
	[TestCell] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_WordCell] PRIMARY KEY CLUSTERED 
(
	[WordCellKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_WordCells]') AND name = N'IX_DDA_WordCells_TestCell')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_WordCells_TestCell] ON [dbo].[DDA_WordCells] 
(
	[TestCell] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_WordCells', N'COLUMN',N'WordCellKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'WordCellKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_WordCells', @level2type=N'COLUMN',@level2name=N'WordCellKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_WordCells', N'COLUMN',N'TestCell'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TestCell' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_WordCells', @level2type=N'COLUMN',@level2name=N'TestCell'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_WordCells', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Word Cell' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_WordCells'
GO
/****** Object:  Table [dbo].[DDA_DiskSizes]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DiskSizes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_DiskSizes](
	[DiskSizeKey] [int] IDENTITY(1,1) NOT NULL,
	[Prod_Class] [varchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InnerDiameter] [float] NULL,
	[OuterDiameter] [float] NULL,
 CONSTRAINT [PK_DDA_DiskType] PRIMARY KEY CLUSTERED 
(
	[DiskSizeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_DiskSizes', N'COLUMN',N'DiskSizeKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DiskTypeKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_DiskSizes', @level2type=N'COLUMN',@level2name=N'DiskSizeKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_DiskSizes', N'COLUMN',N'Prod_Class'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Product code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_DiskSizes', @level2type=N'COLUMN',@level2name=N'Prod_Class'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_DiskSizes', N'COLUMN',N'InnerDiameter'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'InnerDiameter (mm)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_DiskSizes', @level2type=N'COLUMN',@level2name=N'InnerDiameter'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_DiskSizes', N'COLUMN',N'OuterDiameter'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Out Diameter (mm)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_DiskSizes', @level2type=N'COLUMN',@level2name=N'OuterDiameter'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_DiskSizes', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_DiskSizes'
GO
/****** Object:  Table [dbo].[DDA_Signatures]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Signatures]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Signatures](
	[SignatureKey] [int] IDENTITY(1,1) NOT NULL,
	[SignatureID] [int] NOT NULL,
	[SignatureName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_DDA_Signature] PRIMARY KEY CLUSTERED 
(
	[SignatureKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Signatures]') AND name = N'IX_DDA_Signature_SignatureID')
CREATE NONCLUSTERED INDEX [IX_DDA_Signature_SignatureID] ON [dbo].[DDA_Signatures] 
(
	[SignatureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Signatures', N'COLUMN',N'SignatureKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Signature Key
System Signature
1 1 Unknown
2 2 Empty
3 3 No-Signature' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Signatures', @level2type=N'COLUMN',@level2name=N'SignatureKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Signatures', N'COLUMN',N'SignatureID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Long Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Signatures', @level2type=N'COLUMN',@level2name=N'SignatureID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Signatures', N'COLUMN',N'SignatureName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Spatial Signature Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Signatures', @level2type=N'COLUMN',@level2name=N'SignatureName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Signatures', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Spatial Signature Information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Signatures'
GO
/****** Object:  UserDefinedFunction [dbo].[f_Split]    Script Date: 06/14/2010 16:20:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[f_Split]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'

CREATE FUNCTION [dbo].[f_Split] 
(
 @Keyword VARCHAR(8000),
 @Delimiter VARCHAR(255)
)
RETURNS @SplitKeyword TABLE (Keyword VARCHAR(8000))
AS
BEGIN
 DECLARE @Word VARCHAR(255)
 DECLARE @TempKeyword TABLE (Keyword VARCHAR(8000))

 WHILE (CHARINDEX(@Delimiter, @Keyword, 1)>0)
 BEGIN
  SET @Word = SUBSTRING(@Keyword, 1 , CHARINDEX(@Delimiter, @Keyword, 1) - 1)
  SET @Keyword = SUBSTRING(@Keyword, CHARINDEX(@Delimiter, @Keyword, 1) + 1, LEN(@Keyword))
  INSERT INTO @TempKeyword VALUES(@Word)
 END
 
 INSERT INTO @TempKeyword VALUES(@Keyword)
 
 INSERT @SplitKeyword
 SELECT * FROM @TempKeyword
 RETURN
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSurfaceHasSignature]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSurfaceHasSignature]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[_GetSurfaceHasSignature]
	@WHERESQL NVARCHAR(4000),
	@StartRow INT = 0,
	@PAGESIZE INT = 20,
	@TOTALROW INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL NVARCHAR(4000)
	DECLARE @ORDERBY VARCHAR(100)

	SET @StartRow = @StartRow + 1

	SET @ORDERBY = ''SurfaceKey''
	SET @SQL = ''SELECT DISTINCT DiskKey, DiskID, TestGrade, SlotNum, LotNo, StationKey, InnerDiameter, LotIDCode, BinNo,
				OuterDiameter, TestCell, CassetteID, Tester, TestDate, Surface, Product, FabID, 
				SurfaceKey, NumberOfDefect, Loaded, L2_Top_Corr_cts, L2_Bot_Corr_cts, L2_Top_NCorr_cts, L2_Bot_NCorr_cts, TesterType
		,[Rsc725]
      ,[Rsc769]
      ,[Rsc771]
      ,[Rsc764]
      ,[Rsc575]
      ,[Rsc450]
      ,[Rsc453]
      ,[Rsc600]
      ,[Rsc766]
				FROM SingleLayerViewQuery WITH(NOLOCK) WHERE '' + @WHERESQL

	--GET TOTAL ROW NUMBER
	DECLARE @SQLQuery AS NVARCHAR(4000)
	SET @SQLQuery = N''SELECT @TOTALROW = COUNT(SurfaceKey) FROM (''  + @SQL + '') as a''
	EXECUTE sp_executesql @SQLQuery,N''@TOTALROW INT OUTPUT'', @TOTALROW OUTPUT
	--PRINT CAST(@TOTALROW AS VARCHAR)
	--PRINT @SQLQuery

	--Calculate row indices
	DECLARE @EndRow INT
	--Calculate end row
	SET @EndRow = @StartRow + @PageSize - 1;
	IF (@EndRow > @TOTALROW)
		SET @EndRow = @TOTALROW;

	DECLARE @Fields NVARCHAR(3000)
	DECLARE @Tables NVARCHAR(200)

	SET @Fields = ''DISTINCT SingleLayerView.DiskKey, SingleLayerView.DiskID, SingleLayerView.TestGrade, SingleLayerView.SlotNum, SingleLayerView.LotNo, SingleLayerView.StationKey, SingleLayerView.InnerDiameter, SingleLayerView.LotIDCode, SingleLayerView.BinNo,
				SingleLayerView.OuterDiameter, SingleLayerView.TestCell, SingleLayerView.CassetteID, SingleLayerView.Tester, SingleLayerView.TestDate, SingleLayerView.Surface, SingleLayerView.Product, SingleLayerView.FabID, 
				SingleLayerView.SurfaceKey, SingleLayerView.NumberOfDefect, SingleLayerView.Loaded, SingleLayerView.L2_Top_Corr_cts, SingleLayerView.L2_Bot_Corr_cts, SingleLayerView.L2_Top_NCorr_cts, SingleLayerView.L2_Bot_NCorr_cts, SingleLayerView.TesterType,
		SingleLayerView.[Rsc725]
		,SingleLayerView.[Rsc769]
      ,SingleLayerView.[Rsc771]
      ,SingleLayerView.[Rsc764]
      ,SingleLayerView.[Rsc575]
      ,SingleLayerView.[Rsc450]
      ,SingleLayerView.[Rsc453]
      ,SingleLayerView.[Rsc600]
      ,SingleLayerView.[Rsc766], SingleLayerView.KKLot, SingleLayerView.KKSlot  '';
	SET @Tables = ''SingleLayerView'';

--		SET @SQL = 
--		''WITH _Paging_ AS '' +
--		''(SELECT TOP '' + CAST(@EndRow AS NVARCHAR) + '' ROW_NUMBER() OVER (ORDER BY '' + @ORDERBY + '') AS RowNumber,SurfaceKey FROM ('' +
--			''SELECT '' + @Fields +
--			''FROM '' + @Tables + '' '' +
--			''WHERE '' + @WHERESQL + '') AS Temp ) '' +
--		''SELECT * INTO #TempResult FROM _Paging_ WHERE RowNumber >='' + CAST(@StartRow AS NVARCHAR) + '' ORDER BY RowNumber''
--
--	+ ''
--		SELECT DISTINCT [SingleLayerView].DiskKey, [SingleLayerView].DiskID, [SingleLayerView].TestGrade, [SingleLayerView].SlotNum, [SingleLayerView].LotNo, [SingleLayerView].StationKey, [SingleLayerView].InnerDiameter, 
--				[SingleLayerView].OuterDiameter, [SingleLayerView].TestCell, [SingleLayerView].CassetteID, [SingleLayerView].Tester, [SingleLayerView].TestDate, [SingleLayerView].Surface, [SingleLayerView].Product, [SingleLayerView].FabID, 
--				[SingleLayerView].SurfaceKey, [SingleLayerView].NumberOfDefect, [SingleLayerView].Loaded, [SingleLayerView].L2_Top_Corr_cts, [SingleLayerView].L2_Bot_Corr_cts, [SingleLayerView].L2_Top_NCorr_cts, [SingleLayerView].L2_Bot_NCorr_cts FROM [SingleLayerView] INNER JOIN #TempResult ON [SingleLayerView].SurfaceKey=#TempResult.SurfaceKey''

	--PRINT @SQL

	SET @SQL = ''SELECT DISTINCT SurfaceKey INTO #Temp FROM '' + ''SingleLayerViewQuery'' + '' WITH(NOLOCK) WHERE '' + @WHERESQL +
	'' SELECT ROW_NUMBER() OVER (ORDER BY '' + @ORDERBY + '') AS RowNumber, '' + @ORDERBY + '' INTO #Paging FROM #Temp
	 SELECT * INTO #TempResult FROM #Paging WHERE RowNumber >= '' + CAST(@StartRow AS NVARCHAR) + '' AND RowNumber <= '' + CAST(@EndRow AS NVARCHAR) 
	+ '' SELECT * FROM ( 
	SELECT '' + @Fields + '', RowNumber FROM '' + @Tables + '' WITH(NOLOCK) INNER JOIN #TempResult ON '' + @Tables + ''.'' + @ORDERBY + ''=#TempResult.'' + @ORDERBY + '' WHERE '' + @WHERESQL + '') as outputtable
	ORDER BY RowNumber''

	--PRINT (@SQL)
	EXEC (@SQL)
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[Paging_FromView]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Paging_FromView]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[Paging_FromView]
	@View NVARCHAR(255),
	@RECORDKEY VARCHAR(255),
	@FIELDS VARCHAR(1000),
	@WHERESQL NVARCHAR(4000),
	@StartRow INT = 0,
	@PAGESIZE INT = 20,
	@TOTALROW INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ViewQuery NVARCHAR(255)
	SET @ViewQuery  = @View + ''Query''

	DECLARE @SQL NVARCHAR(4000)

	SET @StartRow = @StartRow + 1

	--GET TOTAL ROW NUMBER
	DECLARE @SQLQuery AS NVARCHAR(4000)
	SET @SQLQuery = N''SELECT @TOTALROW = COUNT('' + @RECORDKEY + '') FROM '' + @ViewQuery + '' WITH(NOLOCK) WHERE '' + @WHERESQL
	--Print @SQLQuery
	EXECUTE sp_executesql @SQLQuery,N''@TOTALROW INT OUTPUT'', @TOTALROW OUTPUT

	--print @TOTALROW

	--Calculate row indices
	DECLARE @EndRow INT
	--Calculate end row
	SET @EndRow = @StartRow + @PageSize - 1;
	IF (@EndRow > @TOTALROW)
		SET @EndRow = @TOTALROW;

--	SET @SQL = ''SELECT '' + @RECORDKEY + '' INTO #Temp FROM '' + @View + '' WHERE '' + @WHERESQL +
--	'' SELECT ROW_NUMBER() OVER (ORDER BY '' + @RECORDKEY + '') AS RowNumber, '' + @RECORDKEY + '' INTO #Paging FROM #Temp
--	 SELECT * INTO #TempResult FROM #Paging WHERE RowNumber >= '' + CAST(@StartRow AS NVARCHAR) + '' AND RowNumber <= '' + CAST(@EndRow AS NVARCHAR) + ''
--	 SELECT '' + @FIELDS + '' FROM '' + @View + '' INNER JOIN #TempResult ON '' + @View + ''.'' + @RECORDKEY + ''=#TempResult.'' + @RECORDKEY + '' WHERE '' + @WHERESQL + '' ORDER BY #TempResult.RowNumber''

	SET @SQL = 
		''WITH _Paging_ AS '' +
		''(SELECT TOP '' + CAST(@EndRow AS NVARCHAR) +'' ROW_NUMBER() OVER (ORDER BY '' + @RECORDKEY + '') AS RowNumber,'' + @RECORDKEY + '' FROM ('' +
			''SELECT '' + @RECORDKEY + '' FROM '' + @ViewQuery + '' WITH(NOLOCK) '' +
			''WHERE '' + @WHERESQL + '') AS Temp ) '' +
		''SELECT * INTO #TempResult FROM _Paging_ WHERE RowNumber >='' + CAST(@StartRow AS NVARCHAR) 
	+ ''
		SELECT '' + @FIELDS + '' FROM '' + @View + '' WITH(NOLOCK) INNER JOIN #TempResult ON '' + @View + ''.'' + @RECORDKEY + ''=#TempResult.'' + @RECORDKEY + '' ORDER BY RowNumber''

	--PRINT @SQL
	EXEC (@SQL)
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetTotalRow]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetTotalRow]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[_GetTotalRow]
	@View NVARCHAR(255),
	@RECORDKEY VARCHAR(255),
	@FIELDS VARCHAR(1000),
	@WHERESQL NVARCHAR(4000)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @TOTALROW INT
	DECLARE @SQL NVARCHAR(4000)
	
	SET @TOTALROW = 0
	SET @SQL = ''SELECT '' + @FIELDS + '' FROM '' + @View + '' WHERE '' + @WHERESQL
	SET @SQL = N''SELECT @TOTALROW = COUNT('' + @RECORDKEY + '') FROM (''  + @SQL + '') as a''
	
	EXECUTE sp_executesql @SQL, N''@TOTALROW INT OUTPUT'', @TOTALROW OUTPUT			
	--PRINT @SQL
	PRINT @TOTALROW

	SELECT @TOTALROW
END
' 
END
GO
/****** Object:  Table [dbo].[DDA_Stations]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Stations]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Stations](
	[StationKey] [int] IDENTITY(1,1) NOT NULL,
	[Tester] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_Station] PRIMARY KEY CLUSTERED 
(
	[StationKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Stations]') AND name = N'IX_DDA_STATIONS_TESTER')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_STATIONS_TESTER] ON [dbo].[DDA_Stations] 
(
	[Tester] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Stations', N'COLUMN',N'StationKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'StationKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Stations', @level2type=N'COLUMN',@level2name=N'StationKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Stations', N'COLUMN',N'Tester'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tester ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Stations', @level2type=N'COLUMN',@level2name=N'Tester'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Stations', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Station information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Stations'
GO
/****** Object:  StoredProcedure [dbo].[utl_KillUsers]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[utl_KillUsers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[utl_KillUsers]
	@dbname varchar(50) 
	,@loginname varchar(50)
as
SET NOCOUNT ON

DECLARE @strSQL varchar(255)


CREATE table #tmpUsers(
spid int,
eid int,
status varchar(30),
loginname varchar(50),
hostname varchar(50),
blk int,
dbname varchar(50),
cmd varchar(30),
request_id int )

INSERT INTO #tmpUsers EXEC SP_WHO


DECLARE LoginCursor CURSOR
READ_ONLY
FOR SELECT spid, dbname FROM #tmpUsers WHERE dbname = @dbname --AND loginname = @loginname

DECLARE @spid varchar(10)
DECLARE @dbname2 varchar(40)
OPEN LoginCursor

FETCH NEXT FROM LoginCursor INTO @spid, @dbname2
WHILE (@@fetch_status <> -1)
BEGIN
IF (@@fetch_status <> -2)
BEGIN
PRINT ''Killing '' + @spid
SET @strSQL =''KILL '' + @spid
EXEC (@strSQL)
END
FETCH NEXT FROM LoginCursor INTO  @spid, @dbname2
END

CLOSE LoginCursor
DEALLOCATE LoginCursor

DROP table #tmpUsers' 
END
GO
/****** Object:  Table [dbo].[DDA_PrivateKey]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_PrivateKey]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_PrivateKey](
	[PKey] [smallint] IDENTITY(1,1) NOT NULL,
	[PrivateKey] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_PrivateKey] PRIMARY KEY CLUSTERED 
(
	[PKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_PrivateKey', N'COLUMN',N'PKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_PrivateKey', @level2type=N'COLUMN',@level2name=N'PKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_PrivateKey', N'COLUMN',N'PrivateKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Security private key for DDAWebservice accessing' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_PrivateKey', @level2type=N'COLUMN',@level2name=N'PrivateKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_PrivateKey', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Access DDAWebservice private key ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_PrivateKey'
GO
/****** Object:  Table [dbo].[DDA_KOI_Headers]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_Headers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_KOI_Headers](
	[Lot_Id] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Lot_Slot] [smallint] NOT NULL,
	[AutoNumber] [bigint] IDENTITY(1,1) NOT NULL,
	[KKLot] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[KKSlot] [varchar](2) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Cass_ID] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_KOI_Headers] PRIMARY KEY CLUSTERED 
(
	[Lot_Id] ASC,
	[Lot_Slot] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_Headers]') AND name = N'IX_DDA_KOI_Headers_AutoNumber')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_KOI_Headers_AutoNumber] ON [dbo].[DDA_KOI_Headers] 
(
	[AutoNumber] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_Headers]') AND name = N'IX_DDA_KOI_Headers_LOTID')
CREATE NONCLUSTERED INDEX [IX_DDA_KOI_Headers_LOTID] ON [dbo].[DDA_KOI_Headers] 
(
	[Lot_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_Headers]') AND name = N'IX_DDA_KOI_Headers_Slot')
CREATE NONCLUSTERED INDEX [IX_DDA_KOI_Headers_Slot] ON [dbo].[DDA_KOI_Headers] 
(
	[Lot_Slot] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
/****** Object:  StoredProcedure [dbo].[_GetParetoChartData]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetParetoChartData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetParetoChartData]
@WHERESQL NVARCHAR(4000)
AS
BEGIN
	DECLARE @SQL NVARCHAR(4000)
	DECLARE @TotalDisk real
	--SET @TotalDisk = (SELECT COUNT(DISTINCT(DiskKey)) FROM ChartView)
	SET @SQL = ''SELECT @TotalDisk = COUNT(DISTINCT(DiskKey)) FROM ChartView WHERE '' + @WHERESQL
	PRINT @SQL
	EXECUTE sp_executesql @SQL, N''@TotalDisk Real OUTPUT'', @TotalDisk OUTPUT
	
	IF @TotalDisk IS NULL OR @TotalDisk = 0 RETURN

	SET @SQL = ''SELECT Grade, COUNT(DISTINCT(DiskKey)) AS DiskCount, '' +
	''ROUND((COUNT(DISTINCT(DiskKey))/CAST('' + CAST(@TotalDisk as nvarchar) + '' AS Real)), 4) AS Yield '' +
	''FROM ChartView WITH(NOLOCK) WHERE HasSignature = 1 AND Grade IS NOT NULL AND '' + @WHERESQL + '' '' +
	''GROUP BY Grade '' +
	''UNION '' +
	''SELECT Grade, COUNT(DISTINCT(DiskKey)) AS DiskCount, '' +
	''ROUND((COUNT(DISTINCT(DiskKey))/CAST('' + CAST(@TotalDisk as nvarchar) + '' AS Real)), 4) AS Yield '' +
	''FROM (SELECT Grade, DiskKey FROM ChartView WITH(NOLOCK) '' +
	''WHERE HasSignature = 0 AND Grade IS NOT NULL AND '' + @WHERESQL + '' '' +
	''GROUP BY DiskKey, Grade '' +
	''HAVING COUNT(SurfaceKey) > 1) AS T '' +
	''GROUP BY Grade '' +
	''ORDER BY DiskCount DESC''
	
	EXEC (@SQL)
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_Surfaces'' table.
CREATE PROCEDURE [dbo].[DDA_Surfaces_Insert]
	@DiskKey bigint,
	@TestDate datetime,
	@Surface tinyint,
	@NumberOfDefect int,
	@Loaded bit,
	@HasSignature bit,
	@IsDefectList bit ,
	@InsertedDate datetime,
	@FileName varchar(50),
	@SurfaceKey bigint output

AS
	INSERT INTO [dbo].[DDA_Surfaces]
	(
		[DiskKey],
		[TestDate],
		[Surface],
		[NumberOfDefect],
		Loaded,
		HasSignature,
		IsDefectList,
		InsertedDate,	
		[FileName]
	)
	VALUES
	(
		@DiskKey,
		@TestDate,
		@Surface,
		@NumberOfDefect,
		@Loaded,
		@HasSignature,
		@IsDefectList,
		@InsertedDate,
		@FileName
	)

	SET @SurfaceKey = @@IDENTITY
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_UpdateHasSignatureStatus]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_UpdateHasSignatureStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DDA_Surfaces_UpdateHasSignatureStatus]
	@SurfaceKey bigint,
	@HasSignature bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE DDA_Surfaces SET HasSignature = @HasSignature WHERE SurfaceKey = @SurfaceKey
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Updates a record in the ''DDA_Surfaces'' table.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_Update]
	-- The rest of writeable parameters
	@DiskKey bigint,
	@TestDate datetime,
	@Surface tinyint,
	@NumberOfDefect int,
	@Loaded bit,
	@HasSignature bit,
	@IsDefectList bit,
	-- Primary key parameters
	@SurfaceKey bigint
AS
	UPDATE [dbo].[DDA_Surfaces] SET
		[DiskKey] = @DiskKey,
		[TestDate] = @TestDate,
		[Surface] = @Surface,
		[NumberOfDefect] = @NumberOfDefect,
		Loaded = @Loaded,
		HasSignature = @HasSignature,
		IsDefectList=@IsDefectList
	WHERE
		[SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSurfaceByDisk]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSurfaceByDisk]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[_GetSurfaceByDisk]
	@DiskKey bigint
AS
BEGIN
	SET NOCOUNT ON;

	SELECT S.* FROM DDA_Disks D, DDA_Surfaces S
	WHERE D.DiskKey = S.DiskKey AND D.DiskKey = @DiskKey
	ORDER BY S.Surface
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Grades_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Grades_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Deletes a record from the ''DDA_Processed'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Grades_DeleteByPrimaryKey]
	@GradeKey int
AS
	DELETE FROM [dbo].[DDA_Grades] WHERE
		GradeKey = @GradeKey

' 
END
GO
/****** Object:  Table [dbo].[DDA_Grades]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Grades]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Grades](
	[GradeKey] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [int] NULL,
	[GradeDescription] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_Grades] PRIMARY KEY CLUSTERED 
(
	[GradeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_KOI_DTS_Retrieve_EIS_KOI_Data]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_KOI_DTS_Retrieve_EIS_KOI_Data]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_EIS_KOI_Data] 
	-- Add the parameters for the stored procedure here
	@testcell VARCHAR (5), 
	@lotnum VARCHAR (10),
	@lotslot VARCHAR (2)
AS
BEGIN

	DECLARE @debug BIT
	DECLARE @KKLot VARCHAR(10)
	DECLARE @KKSlot VARCHAR(2)
	DECLARE @CassID VARCHAR(20)
	DECLARE @NSql NVARCHAR(MAX)
	DECLARE @Sql VARCHAR(MAX)
	
	DECLARE  @tmp_table TABLE(Lotnum VARCHAR(10), Rsc450 VARCHAR(10), Rsc453 VARCHAR(10), Rsc600 VARCHAR(10),
	Rsc725 VARCHAR(10), Rsc766 VARCHAR(10), Rsc769 VARCHAR(10), Rsc771 VARCHAR(10), Rsc764 VARCHAR(10), Rsc575 VARCHAR(10),
	KKLot VARCHAR(10), KKSlot VARCHAR(2), Cass_ID VARCHAR(20))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	SET @KKLot = ''''
	SET @KKSlot = ''''
	SET @CassID = ''''

	INSERT INTO @tmp_table (Lotnum,Rsc450,Rsc453,Rsc600,Rsc725,Rsc766,Rsc769,Rsc771,Rsc764,Rsc575) 
	SELECT @lotnum, CASE WHEN Rsc450 IS NULL THEN '''' ELSE Rsc450 END, CASE WHEN Rsc453 IS NULL THEN '''' ELSE Rsc453 END, CASE WHEN Rsc600 IS NULL THEN '''' ELSE Rsc600 END, CASE WHEN Rsc725 IS NULL THEN '''' ELSE Rsc725 END, 
	CASE WHEN Rsc766 IS NULL THEN '''' ELSE Rsc766 END, CASE WHEN Rsc769 IS NULL THEN '''' ELSE Rsc769 END, CASE WHEN Rsc771 IS NULL THEN '''' ELSE Rsc771 END, CASE WHEN Rsc764 IS NULL THEN '''' ELSE Rsc764 END, CASE WHEN Rsc575 IS NULL THEN '''' ELSE Rsc575 END 
	FROM EIS.dbo.tbl_Resources_Summary (nolock) WHERE Lotno803804805 = @lotnum

	IF SUBSTRING(@testcell, 2, 1) = ''1''
	BEGIN
		SET @NSql = N''SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM KOI.dbo.tbl_KOI_Rawdata_PN1 KOI1 (NoLock), KOI.dbo.tbl_KOI_Rawdata2_PN1 KOI2(NoLock)''
		SET @NSql = @NSql + '' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = '''''' + @lotnum + '''''' AND Lot_Slot = '''''' + @lotslot + ''''''''
		EXEC master..sp_executesql @NSql, N''@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT'', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT
		
		UPDATE @tmp_table SET KKLot = @KKLot , KKSlot = @KKSlot ,  Cass_ID = @CassID 
		EXEC (@Sql) 
	END

	IF SUBSTRING(@testcell, 2, 1) = ''3''
	BEGIN
		SET @NSql = N''SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM KOI.dbo.tbl_KOI_Rawdata_PN2 KOI1 (NoLock), KOI.dbo.tbl_KOI_Rawdata2_PN2 KOI2(NoLock)''
		SET @NSql = @NSql + '' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = '''''' + @lotnum + '''''' AND Lot_Slot = '''''' + @lotslot + ''''''''
		EXEC master..sp_executesql @NSql, N''@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT'', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT

		UPDATE @tmp_table SET KKLot = @KKLot , KKSlot = @KKSlot ,  Cass_ID = @CassID 
		EXEC (@Sql) 
	END

	SELECT * FROM @tmp_table

END




' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_EIS_KOI_PARAM]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_EIS_KOI_PARAM]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'





-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GET_EIS_KOI_PARAM] 
@NumTop numeric,
@AutoID numeric,
@TestDate datetime
AS
BEGIN
	
	
	Declare @SQL varchar(4000)
/*	set @SQL = ''SELECT top #1 dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.SlotNum, dbo.DDA_WordCells.TestCell,DDA_WordCells.WordCellKey
	FROM  dbo.DDA_Disks INNER JOIN
	dbo.DDA_WordCells ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey
	where dbo.DDA_Disks.DiskKey >= #2
	AND (dbo.DDA_Disks.LotNo not in (Select dbo.DDA_DiskHeaders.Lotnum from dbo.DDA_DiskHeaders)
	or dbo.DDA_Disks.SlotNum not in (Select dbo.DDA_DiskHeaders.SlotNum from dbo.DDA_DiskHeaders)
	or dbo.DDA_WordCells.WordCellKey not in (Select dbo.DDA_DiskHeaders.WordCellKey  from dbo.DDA_DiskHeaders))
	ORDER BY dbo.DDA_Disks.DiskKey''
	set @SQL = REPLACE(@SQL,''#1'',@NumTop)
	set @SQL = REPLACE(@SQL,''#2'',@AutoID)
	--print @SQL
	exec (@SQL)

*/
	set @SQL = ''SELECT top #1 dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.SlotNum, dbo.DDA_WordCells.TestCell,DDA_WordCells.WordCellKey
	FROM  dbo.DDA_Disks INNER JOIN dbo.DDA_WordCells ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey
	WHERE  dbo.DDA_Disks.DiskKey >= #2 
	AND dbo.DDA_Disks.TestDiskDate >= '''''' + CONVERT(NVARCHAR(10),@TestDate,101) + ''''''
	AND NOT EXISTS(SELECT * FROM dbo.DDA_DiskHeaders
				WHERE 
					dbo.DDA_Disks.LotNo = dbo.DDA_DiskHeaders.Lotnum
					AND dbo.DDA_Disks.SlotNum = dbo.DDA_DiskHeaders.SlotNum
					AND dbo.DDA_WordCells.WordCellKey = dbo.DDA_DiskHeaders.WordCellKey)
	ORDER BY dbo.DDA_Disks.DiskKey''
	set @SQL = REPLACE(@SQL,''#1'',@NumTop)
	set @SQL = REPLACE(@SQL,''#2'',@AutoID)
	
	print @SQL
	exec (@SQL)

END


/****** Object:  StoredProcedure [dbo].[_DDA_DiskHeaders_Insert]    Script Date: 02/11/2009 14:18:49 ******/
SET ANSI_NULLS ON
' 
END
GO
/****** Object:  UserDefinedFunction [dbo].[fShiftBit]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fShiftBit]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
BEGIN
execute dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,CANG>
-- =============================================
CREATE FUNCTION [dbo].[fShiftBit]
(
	@bita int,
	@shift int
)
RETURNS binary(50)
AS
BEGIN
	
	declare @i int
	set @i=0

	IF(@shift>=0)
	BEGIN
		while(@i<@shift)
		begin
			set @bita = @bita*2
			set @i=@i+1
		end
	END
	ELSE
	BEGIN
		set @shift = -@shift;
		while(@i<@shift)
		begin
			set @bita = @bita/2
			set @i=@i+1
		end		
	END

	return @bita
END
' 
END
GO
/****** Object:  Table [dbo].[DDA_Channels]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Channels]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Channels](
	[ChannelID] [int] NOT NULL,
	[ChannelName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_Channel] PRIMARY KEY CLUSTERED 
(
	[ChannelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Channels', N'COLUMN',N'ChannelID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ChannelKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Channels', @level2type=N'COLUMN',@level2name=N'ChannelID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Channels', N'COLUMN',N'ChannelName'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Channel Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Channels', @level2type=N'COLUMN',@level2name=N'ChannelName'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Channels', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Channel information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Channels'
GO
/****** Object:  Table [dbo].[WD_Products]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WD_Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WD_Products](
	[Prod_Code] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Prod_Class] [varchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_WD_Products] PRIMARY KEY CLUSTERED 
(
	[Prod_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[DDA_ResultObjects]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultObjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ResultObjects](
	[ObjectKey] [bigint] IDENTITY(1,1) NOT NULL,
	[ResultKey] [bigint] NULL,
	[ObjectTypeKey] [int] NULL,
	[RawData] [image] NULL,
	[NumberOfDefect] [int] NULL,
	[LocationX] [float] NULL,
	[LocationY] [float] NULL,
 CONSTRAINT [PK_DDA_ObjectResults] PRIMARY KEY CLUSTERED 
(
	[ObjectKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultObjects', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Object result' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultObjects'
GO
/****** Object:  Table [dbo].[DDA_Disks]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Disks](
	[DiskKey] [bigint] IDENTITY(1,1) NOT NULL,
	[DiskID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TestDiskDate] [datetime] NULL,
	[ProductKey] [int] NOT NULL,
	[TestGrade] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SlotNum] [smallint] NULL,
	[LotNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CassetteID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StationKey] [int] NOT NULL,
	[WordCellKey] [int] NOT NULL,
	[FabKey] [smallint] NOT NULL,
	[InnerDiameter] [float] NULL,
	[OuterDiameter] [float] NULL,
	[L2_Top_Corr_cts] [int] NULL,
	[L2_Bot_Corr_cts] [int] NULL,
	[L2_Top_NCorr_cts] [int] NULL,
	[L2_Bot_NCorr_cts] [int] NULL,
	[TesterTypeID] [smallint] NULL,
	[LotIDCode] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BinNo] [varchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NULL,
	[HasMeaning] [bit] NULL,
 CONSTRAINT [PK_IDA_Disk] PRIMARY KEY CLUSTERED 
(
	[DiskKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_BINNO')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_BINNO] ON [dbo].[DDA_Disks] 
(
	[BinNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_FabKey')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_FabKey] ON [dbo].[DDA_Disks] 
(
	[FabKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_GRADE')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_GRADE] ON [dbo].[DDA_Disks] 
(
	[TestGrade] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_LOTIDCODE')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_LOTIDCODE] ON [dbo].[DDA_Disks] 
(
	[LotIDCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_LOTNUM')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_LOTNUM] ON [dbo].[DDA_Disks] 
(
	[LotNo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_Product')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_Product] ON [dbo].[DDA_Disks] 
(
	[ProductKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_SLOTNUM')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_SLOTNUM] ON [dbo].[DDA_Disks] 
(
	[SlotNum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_StationKey')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_StationKey] ON [dbo].[DDA_Disks] 
(
	[StationKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_TestDiskDate')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_TestDiskDate] ON [dbo].[DDA_Disks] 
(
	[TestDiskDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_DISK_WorkCell')
CREATE NONCLUSTERED INDEX [IX_DDA_DISK_WorkCell] ON [dbo].[DDA_Disks] 
(
	[WordCellKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks]') AND name = N'IX_DDA_Disks_DDA_TesterTypes')
CREATE NONCLUSTERED INDEX [IX_DDA_Disks_DDA_TesterTypes] ON [dbo].[DDA_Disks] 
(
	[TesterTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'DiskKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'DiskKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'DiskID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk test ID for SSA analyzer ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'DiskID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'TestGrade'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TestGrade' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'TestGrade'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'SlotNum'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Slot number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'SlotNum'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'LotNo'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lot ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'LotNo'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'StationKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tester' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'StationKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'WordCellKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TestCell' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'WordCellKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'FabKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'FabKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'InnerDiameter'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Inner Diameter (mm)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'InnerDiameter'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'OuterDiameter'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Outer Diameter (mm)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'OuterDiameter'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'L2_Top_Corr_cts'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'L2_Top_Corr_cts' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'L2_Top_Corr_cts'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'L2_Bot_Corr_cts'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'L2_Bot_Corr_cts' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'L2_Bot_Corr_cts'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'L2_Top_NCorr_cts'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'L2_Bot_Corr_cts' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'L2_Top_NCorr_cts'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', N'COLUMN',N'L2_Bot_NCorr_cts'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'L2_Bot_Corr_cts' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks', @level2type=N'COLUMN',@level2name=N'L2_Bot_NCorr_cts'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Disks', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Disks'
GO
/****** Object:  Table [dbo].[DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Surfaces](
	[SurfaceKey] [bigint] IDENTITY(1,1) NOT NULL,
	[DiskKey] [bigint] NOT NULL,
	[TestDate] [datetime] NULL,
	[Surface] [tinyint] NOT NULL,
	[NumberOfDefect] [int] NULL,
	[Loaded] [bit] NULL,
	[HasSignature] [bit] NULL,
	[IsDefectList] [bit] NULL,
	[Processed] [bit] NULL,
	[Deleted] [bit] NULL,
	[ProcessingDuration] [int] NULL,
	[InsertedDate] [datetime] NULL,
	[FileName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_DiskImage] PRIMARY KEY CLUSTERED 
(
	[SurfaceKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]') AND name = N'IX_DDA_Surface_DiskKey')
CREATE NONCLUSTERED INDEX [IX_DDA_Surface_DiskKey] ON [dbo].[DDA_Surfaces] 
(
	[DiskKey] ASC
)
INCLUDE ( [NumberOfDefect]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]') AND name = N'IX_DDA_Surface_TestDate')
CREATE NONCLUSTERED INDEX [IX_DDA_Surface_TestDate] ON [dbo].[DDA_Surfaces] 
(
	[TestDate] ASC
)
INCLUDE ( [HasSignature],
[DiskKey]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'SurfaceKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DiskImageKey - further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'SurfaceKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'DiskKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'DiskKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'TestDate'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Data time stamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'TestDate'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'Surface'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = Top, 1 = Bottom' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'Surface'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'NumberOfDefect'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Surface defect number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'NumberOfDefect'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'Loaded'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'Loaded'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'HasSignature'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 = no, 1 = has' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'HasSignature'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', N'COLUMN',N'ProcessingDuration'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'mili seconds' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces', @level2type=N'COLUMN',@level2name=N'ProcessingDuration'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Surfaces', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Original Disk Map' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Surfaces'
GO
/****** Object:  Table [dbo].[DDA_Processed]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Processed]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Processed](
	[RecipeKey] [int] NOT NULL,
	[SurfaceKey] [bigint] NOT NULL,
	[BreakWhenFound] [bit] NULL,
	[Finish] [bit] NULL,
 CONSTRAINT [PK_DDA_Processed] PRIMARY KEY CLUSTERED 
(
	[RecipeKey] ASC,
	[SurfaceKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Processed]') AND name = N'IX_DDA_Processed')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_Processed] ON [dbo].[DDA_Processed] 
(
	[SurfaceKey] ASC,
	[RecipeKey] ASC,
	[BreakWhenFound] ASC,
	[Finish] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Processed', N'COLUMN',N'RecipeKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Processed recipe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Processed', @level2type=N'COLUMN',@level2name=N'RecipeKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Processed', N'COLUMN',N'SurfaceKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Processed surface' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Processed', @level2type=N'COLUMN',@level2name=N'SurfaceKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Processed', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Real time processing information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Processed'
GO
/****** Object:  Table [dbo].[DDA_RecipeData]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_RecipeData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_RecipeData](
	[RecipeKey] [int] NOT NULL,
	[RawData] [image] NULL
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_RecipeData]') AND name = N'IX_DDA_RecipeData_RecipeKey')
CREATE UNIQUE CLUSTERED INDEX [IX_DDA_RecipeData_RecipeKey] ON [dbo].[DDA_RecipeData] 
(
	[RecipeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_RecipeData', N'COLUMN',N'RecipeKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'RecipeKey' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_RecipeData', @level2type=N'COLUMN',@level2name=N'RecipeKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_RecipeData', N'COLUMN',N'RawData'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recipe content - metadata' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_RecipeData', @level2type=N'COLUMN',@level2name=N'RawData'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_RecipeData', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Recipe data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_RecipeData'
GO
/****** Object:  Table [dbo].[DDA_SurfaceData]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_SurfaceData](
	[SurfaceKey] [bigint] NOT NULL,
	[RawData] [image] NULL,
	[SourceThumbnail] [image] NULL,
	[SourceThumbnailFlat] [image] NULL,
	[NoCompress] [bit] NULL
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]') AND name = N'IX_DDA_SurfaceData')
CREATE UNIQUE CLUSTERED INDEX [IX_DDA_SurfaceData] ON [dbo].[DDA_SurfaceData] 
(
	[SurfaceKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SurfaceData', N'COLUMN',N'SurfaceKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SurfaceData', @level2type=N'COLUMN',@level2name=N'SurfaceKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SurfaceData', N'COLUMN',N'RawData'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Raw defectList in binary format' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SurfaceData', @level2type=N'COLUMN',@level2name=N'RawData'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SurfaceData', N'COLUMN',N'SourceThumbnail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Map Thumbnail 100x100 pixels - Disc view' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SurfaceData', @level2type=N'COLUMN',@level2name=N'SourceThumbnail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SurfaceData', N'COLUMN',N'SourceThumbnailFlat'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Map Thumbnail 100x100 pixels - Flat View' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SurfaceData', @level2type=N'COLUMN',@level2name=N'SourceThumbnailFlat'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_SurfaceData', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Surface data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_SurfaceData'
GO
/****** Object:  Table [dbo].[DDA_Results]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Results]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_Results](
	[ResultKey] [bigint] IDENTITY(1,1) NOT NULL,
	[SignatureKey] [int] NOT NULL,
	[IsMultiLayer] [bit] NULL,
	[AnalyzeTime] [datetime] NOT NULL,
	[NumberOfDefect] [int] NULL,
	[PercentOfDefect] [float] NULL,
	[RecipeKey] [int] NULL,
	[ProcessingDuration] [int] NULL,
 CONSTRAINT [PK_DDA_Process] PRIMARY KEY CLUSTERED 
(
	[ResultKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Results]') AND name = N'IX_DDA_Result_Signature')
CREATE NONCLUSTERED INDEX [IX_DDA_Result_Signature] ON [dbo].[DDA_Results] 
(
	[SignatureKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Results]') AND name = N'IX_DDA_Results')
CREATE NONCLUSTERED INDEX [IX_DDA_Results] ON [dbo].[DDA_Results] 
(
	[RecipeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'ResultKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Multi Layer Result Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'ResultKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'SignatureKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Signature Category Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'SignatureKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'IsMultiLayer'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Multilayer flag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'IsMultiLayer'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'AnalyzeTime'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DDA Multi Layer Result Time Stamp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'AnalyzeTime'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'NumberOfDefect'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result defect number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'NumberOfDefect'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'PercentOfDefect'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result defect percentage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'PercentOfDefect'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'RecipeKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Processing recipe key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'RecipeKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', N'COLUMN',N'ProcessingDuration'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ms' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results', @level2type=N'COLUMN',@level2name=N'ProcessingDuration'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_Results', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Master Results from Repeater, Slot Pattern, or Surfscan MultiLayer Analysis ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_Results'
GO
/****** Object:  Table [dbo].[DDA_ResultDetail]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ResultDetail](
	[ResultDetailKey] [bigint] IDENTITY(1,1) NOT NULL,
	[ResultKey] [bigint] NOT NULL,
	[SurfaceKey] [bigint] NOT NULL,
	[NumberOfDefect] [int] NULL,
	[PercentOfDefect] [float] NULL,
 CONSTRAINT [PK_DDA_DiskList] PRIMARY KEY CLUSTERED 
(
	[ResultDetailKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]') AND name = N'IX_DDA_DiskListItem')
CREATE UNIQUE NONCLUSTERED INDEX [IX_DDA_DiskListItem] ON [dbo].[DDA_ResultDetail] 
(
	[SurfaceKey] ASC,
	[ResultKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetail', N'COLUMN',N'ResultDetailKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'For further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetail', @level2type=N'COLUMN',@level2name=N'ResultDetailKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetail', N'COLUMN',N'ResultKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Multi Layer Result Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetail', @level2type=N'COLUMN',@level2name=N'ResultKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetail', N'COLUMN',N'SurfaceKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetail', @level2type=N'COLUMN',@level2name=N'SurfaceKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'MultilayerSignature Result data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetail'
GO
/****** Object:  Table [dbo].[DDA_ControlRuleDetail]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ControlRuleDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ControlRuleDetail](
	[ControlRuleID] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ControlRuleBody] [image] NULL,
	[ControlRuleVersion] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRuleDetail', N'COLUMN',N'ControlRuleID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ControlRule ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRuleDetail', @level2type=N'COLUMN',@level2name=N'ControlRuleID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRuleDetail', N'COLUMN',N'ControlRuleBody'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ControlRule body' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRuleDetail', @level2type=N'COLUMN',@level2name=N'ControlRuleBody'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRuleDetail', N'COLUMN',N'ControlRuleVersion'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule version' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRuleDetail', @level2type=N'COLUMN',@level2name=N'ControlRuleVersion'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ControlRuleDetail', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule information - detail table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ControlRuleDetail'
GO
/****** Object:  Table [dbo].[DDA_AlarmEvent]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_AlarmEvent](
	[AlarmKey] [bigint] IDENTITY(1,1) NOT NULL,
	[ControlRuleID] [char](40) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Severity] [tinyint] NOT NULL,
	[AlarmTimeStamp] [datetime] NOT NULL,
	[LastResultTimeStamp] [datetime] NOT NULL,
	[GroupByData1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GroupByData2] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GroupByDimension1] [tinyint] NOT NULL,
	[GroupByDimension2] [tinyint] NOT NULL,
 CONSTRAINT [PK_DDA_AlarmEvent] PRIMARY KEY CLUSTERED 
(
	[AlarmKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'AlarmKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alarm ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'AlarmKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'ControlRuleID'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control Rule UUID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'ControlRuleID'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'Severity'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alarm severity: 0-None; 1-Very Low; 2-Low; 3-Medium; 4-High; 5-Very High' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'Severity'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'AlarmTimeStamp'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alarm Time' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'AlarmTimeStamp'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'LastResultTimeStamp'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Time of last OOC Disk' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'LastResultTimeStamp'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'GroupByData1'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'GroupByData1'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'GroupByData2'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Further compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'GroupByData2'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'GroupByDimension1'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DeviceId: 0, SetupId: 1...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'GroupByDimension1'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', N'COLUMN',N'GroupByDimension2'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DeviceId: 0, SetupId: 1...' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent', @level2type=N'COLUMN',@level2name=N'GroupByDimension2'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmEvent', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Store process signatures (OOC, Trend...)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmEvent'
GO
/****** Object:  Table [dbo].[DDA_ViolativeDisk]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ViolativeDisk](
	[AlarmKey] [bigint] NOT NULL,
	[DiskKey] [bigint] NOT NULL,
	[CategoryIndex] [int] NOT NULL,
	[SignatureKey] [int] NOT NULL,
 CONSTRAINT [PK_DDA_ViolativeDisk] PRIMARY KEY CLUSTERED 
(
	[AlarmKey] ASC,
	[DiskKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ViolativeDisk', N'COLUMN',N'AlarmKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Alarm ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ViolativeDisk', @level2type=N'COLUMN',@level2name=N'AlarmKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ViolativeDisk', N'COLUMN',N'DiskKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk Key' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ViolativeDisk', @level2type=N'COLUMN',@level2name=N'DiskKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ViolativeDisk', N'COLUMN',N'CategoryIndex'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Disk index in OOC collection' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ViolativeDisk', @level2type=N'COLUMN',@level2name=N'CategoryIndex'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ViolativeDisk', N'COLUMN',N'SignatureKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Point to DDA_Signature.SCKey. Value 0 indicates that this rule is not classified by signature' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ViolativeDisk', @level2type=N'COLUMN',@level2name=N'SignatureKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ViolativeDisk', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains Disks which violate the OOC rule ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ViolativeDisk'
GO
/****** Object:  Table [dbo].[COM_DiskResponse]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[COM_DiskResponse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[COM_DiskResponse](
	[DiskKey] [bigint] NOT NULL
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[COM_DiskResponse]') AND name = N'IX_COM_DiskResponse')
CREATE UNIQUE CLUSTERED INDEX [IX_COM_DiskResponse] ON [dbo].[COM_DiskResponse] 
(
	[DiskKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[DDA_AlarmChart]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_AlarmChart]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_AlarmChart](
	[AlarmChartKey] [bigint] IDENTITY(1,1) NOT NULL,
	[AlarmKey] [bigint] NOT NULL,
	[ChartSnapshot] [image] NOT NULL,
	[ChartSnapshotVersion] [char](8) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_DDA_AlarmChart] PRIMARY KEY CLUSTERED 
(
	[AlarmChartKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmChart', N'COLUMN',N'AlarmChartKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Further master-detail compatible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmChart', @level2type=N'COLUMN',@level2name=N'AlarmChartKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmChart', N'COLUMN',N'AlarmKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmChart', @level2type=N'COLUMN',@level2name=N'AlarmKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmChart', N'COLUMN',N'ChartSnapshotVersion'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Chart snapshot version' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmChart', @level2type=N'COLUMN',@level2name=N'ChartSnapshotVersion'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_AlarmChart', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains the result chart information' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_AlarmChart'
GO
/****** Object:  Table [dbo].[DDA_ResultData]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ResultData](
	[ResultKey] [bigint] NOT NULL,
	[ResultThumbnail] [image] NULL,
	[ResultImage] [image] NULL,
	[ResultThumbnailFlat] [image] NULL,
	[ResultImageFlat] [image] NULL,
	[RawData] [image] NULL,
	[NoCompress] [bit] NULL
)
END
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultData', N'COLUMN',N'ResultThumbnail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result Signature Map 100x100 pixels' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultData', @level2type=N'COLUMN',@level2name=N'ResultThumbnail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultData', N'COLUMN',N'ResultImage'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result Signature Map 600x600 pixels' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultData', @level2type=N'COLUMN',@level2name=N'ResultImage'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultData', N'COLUMN',N'ResultThumbnailFlat'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result Signature Map 100x100 pixels' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultData', @level2type=N'COLUMN',@level2name=N'ResultThumbnailFlat'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultData', N'COLUMN',N'ResultImageFlat'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Result Signature Map 600x600 pixels' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultData', @level2type=N'COLUMN',@level2name=N'ResultImageFlat'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultData', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'SSA master result data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultData'
GO
/****** Object:  Table [dbo].[DDA_ResultDetailData]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_ResultDetailData](
	[ResultDetailKey] [bigint] NOT NULL,
	[RawData] [image] NULL,
	[SourceThumbnail] [image] NULL,
	[SourceThumbnailFlat] [image] NULL,
	[NoCompress] [bit] NULL
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]') AND name = N'IX_DDA_ResultDetailData')
CREATE UNIQUE CLUSTERED INDEX [IX_DDA_ResultDetailData] ON [dbo].[DDA_ResultDetailData] 
(
	[ResultDetailKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetailData', N'COLUMN',N'ResultDetailKey'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Array Key of Defect in DefectList in source surface' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetailData', @level2type=N'COLUMN',@level2name=N'ResultDetailKey'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetailData', N'COLUMN',N'RawData'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DefectList Result ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetailData', @level2type=N'COLUMN',@level2name=N'RawData'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetailData', N'COLUMN',N'SourceThumbnail'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-Test Disk Map 600x600 pixels' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetailData', @level2type=N'COLUMN',@level2name=N'SourceThumbnail'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetailData', N'COLUMN',N'SourceThumbnailFlat'))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'E-Test Disk Map 600x600 pixels' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetailData', @level2type=N'COLUMN',@level2name=N'SourceThumbnailFlat'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'DDA_ResultDetailData', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Detail result data' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DDA_ResultDetailData'
GO
/****** Object:  Table [dbo].[DDA_GradeMapping]    Script Date: 06/14/2010 16:20:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_GradeMapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DDA_GradeMapping](
	[GradeKey] [int] NOT NULL,
	[SignatureKey] [int] NOT NULL,
 CONSTRAINT [PK_DDA_GradeMapping] PRIMARY KEY CLUSTERED 
(
	[GradeKey] ASC,
	[SignatureKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_GradeMapping]') AND name = N'IX_DDA_GradeMapping_GradeKey')
CREATE NONCLUSTERED INDEX [IX_DDA_GradeMapping_GradeKey] ON [dbo].[DDA_GradeMapping] 
(
	[GradeKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[DDA_GradeMapping]') AND name = N'IX_DDA_GradeMapping_SignatureKey')
CREATE NONCLUSTERED INDEX [IX_DDA_GradeMapping_SignatureKey] ON [dbo].[DDA_GradeMapping] 
(
	[SignatureKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF)
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ClassLookups'' table.
CREATE PROCEDURE [dbo].[_DDA_ClassLookups_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ClassLookups]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_ClassLookups'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ClassLookups_GetByPrimaryKey]
	@ClassID int
AS
	SELECT * FROM [dbo].[DDA_ClassLookups] WHERE
		[ClassID] = @ClassID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ClassLookups'' table.
CREATE PROCEDURE [dbo].[_DDA_ClassLookups_Insert]
	@ClassID int,
	@ClassName nvarchar(50)
AS
	INSERT INTO [dbo].[DDA_ClassLookups]
	(
		[ClassID],
		[ClassName]
	)
	VALUES
	(
		@ClassID,
		@ClassName
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_ClassLookups'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ClassLookups_DeleteByPrimaryKey]
	@ClassID int
AS
	DELETE FROM [dbo].[DDA_ClassLookups] WHERE
		[ClassID] = @ClassID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ClassLookups'' table.
CREATE PROCEDURE [dbo].[_DDA_ClassLookups_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ClassLookups]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ClassLookups_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ClassLookups_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_ClassLookups'' table.
CREATE PROCEDURE [dbo].[_DDA_ClassLookups_Update]
	-- The rest of writeable parameters
	@ClassName nvarchar(50),
	-- Primary key parameters
	@ClassID int
AS
	UPDATE [dbo].[DDA_ClassLookups] SET
		[ClassName] = @ClassName
	WHERE
		[ClassID] = @ClassID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_SysInfo'' table.
CREATE PROCEDURE [dbo].[_DDA_SysInfo_Update]
	-- The rest of writeable parameters
	@MajorVersion int,
	@MinorVersion int,
	@Build int,
	@Description nvarchar(100),
	@CreateData datetime,
	@DBType tinyint,
	-- Primary key parameters
	@SysInfoKey smallint
AS
	UPDATE [dbo].[DDA_SysInfo] SET
		[MajorVersion] = @MajorVersion,
		[MinorVersion] = @MinorVersion,
		[Build] = @Build,
		[Description] = @Description,
		[CreateData] = @CreateData,
		[DBType] = @DBType
	WHERE
		[SysInfoKey] = @SysInfoKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_SysInfo'' table.
CREATE PROCEDURE [dbo].[_DDA_SysInfo_GetAll]
AS
	SELECT * FROM [dbo].[DDA_SysInfo]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_SysInfo'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_SysInfo_DeleteByPrimaryKey]
	@SysInfoKey smallint
AS
	DELETE FROM [dbo].[DDA_SysInfo] WHERE
		[SysInfoKey] = @SysInfoKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_SysInfo'' table.
CREATE PROCEDURE [dbo].[_DDA_SysInfo_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_SysInfo]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_SysInfo'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_SysInfo_GetByPrimaryKey]
	@SysInfoKey smallint
AS
	SELECT * FROM [dbo].[DDA_SysInfo] WHERE
		[SysInfoKey] = @SysInfoKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SysInfo_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SysInfo_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_SysInfo'' table.
CREATE PROCEDURE [dbo].[_DDA_SysInfo_Insert]
	@MajorVersion int,
	@MinorVersion int,
	@Build int,
	@Description nvarchar(100),
	@CreateData datetime,
	@DBType tinyint
AS
	INSERT INTO [dbo].[DDA_SysInfo]
	(
		[MajorVersion],
		[MinorVersion],
		[Build],
		[Description],
		[CreateData],
		[DBType]
	)
	VALUES
	(
		@MajorVersion,
		@MinorVersion,
		@Build,
		@Description,
		@CreateData,
		@DBType
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_DDA_EIS_Resources_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DDA_EIS_Resources_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_DDA_EIS_Resources_Insert]
	@LotNum varchar(10),	
	@Rsc725 varchar(10),
	@Rsc769 varchar(10),
	@Rsc771 varchar(10),
	@Rsc764 varchar(10),
	@Rsc575 varchar(10),	
	@Rsc450 VARCHAR(10),
	@Rsc453 VARCHAR(10),
	@Rsc600 VARCHAR(10),
	@Rsc766 VARCHAR(10)
AS
BEGIN
	insert into DDA_EIS_Resources(LotNum,Rsc725,Rsc769,Rsc771,Rsc764,Rsc575,Rsc450,Rsc453,Rsc600,Rsc766)
	values(@LotNum,@Rsc725,@Rsc769,@Rsc771,@Rsc764,@Rsc575,@Rsc450,@Rsc453,@Rsc600,@Rsc766)
END





' 
END
GO
/****** Object:  View [dbo].[SourceView]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SourceView]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[SourceView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, 
                      dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, 
                      dbo.DDA_Surfaces.HasSignature, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, 
                      dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterTypeID, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_EIS_Resources.Rsc725, 
                      dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, 
                      dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, 
                      dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, dbo.DDA_KOI_Headers.Cass_ID, dbo.DDA_Disks.HasMeaning
FROM         dbo.DDA_Surfaces INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_WordCells ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND 
                      dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'SourceView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[8] 2[50] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[5] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = -96
      End
      Begin Tables = 
         Begin Table = "DDA_Surfaces"
            Begin Extent = 
               Top = 10
               Left = 924
               Bottom = 251
               Right = 1086
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Disks"
            Begin Extent = 
               Top = 0
               Left = 566
               Bottom = 364
               Right = 718
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Stations"
            Begin Extent = 
               Top = 102
               Left = 63
               Bottom = 187
               Right = 215
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Products"
            Begin Extent = 
               Top = 0
               Left = 395
               Bottom = 100
               Right = 547
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_WordCells"
            Begin Extent = 
               Top = 4
               Left = 52
               Bottom = 91
               Right = 204
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Fabs"
            Begin Extent = 
               Top = 107
               Left = 760
               Bottom = 228
               Right = 912
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_TesterTypes"
            Begin Extent = 
               Top = 204
               Left = 56
               Bottom = 292
               Right = 208
            End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SourceView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'SourceView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_KOI_Headers"
            Begin Extent = 
               Top = 343
               Left = 772
               Bottom = 480
               Right = 943
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_EIS_Resources"
            Begin Extent = 
               Top = 331
               Left = 243
               Bottom = 548
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 29
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4830
         Alias = 2085
         Table = 3570
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SourceView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'SourceView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SourceView'
GO
/****** Object:  View [dbo].[DiskView]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DiskView]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[DiskView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Fabs.FabID, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, 
                      dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, 
                      dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_Disks.TestDiskDate AS TestDate, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, 
                      dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, dbo.DDA_KOI_Headers.Cass_ID, dbo.DDA_EIS_Resources.Rsc725, 
                      dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, 
                      dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, 
                      dbo.DDA_Disks.HasMeaning
FROM         dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND 
                      dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'DiskView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[62] 4[1] 2[28] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DDA_WordCells"
            Begin Extent = 
               Top = 66
               Left = 25
               Bottom = 151
               Right = 177
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Disks"
            Begin Extent = 
               Top = 3
               Left = 472
               Bottom = 336
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Fabs"
            Begin Extent = 
               Top = 2
               Left = 224
               Bottom = 117
               Right = 376
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Stations"
            Begin Extent = 
               Top = 288
               Left = 107
               Bottom = 373
               Right = 259
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Products"
            Begin Extent = 
               Top = 158
               Left = 17
               Bottom = 243
               Right = 169
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_TesterTypes"
            Begin Extent = 
               Top = 202
               Left = 210
               Bottom = 280
               Right = 380
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_EIS_Resources"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 222
               Right = 814
            En' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DiskView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'DiskView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'd
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_KOI_Headers"
            Begin Extent = 
               Top = 229
               Left = 662
               Bottom = 370
               Right = 814
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 4860
         Alias = 900
         Table = 5400
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DiskView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'DiskView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DiskView'
GO
/****** Object:  View [dbo].[SingleLayerView]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SingleLayerView]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[SingleLayerView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, 
                      dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, 
                      dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, dbo.DDA_Results.AnalyzeTime, 
                      dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, 
                      dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, 
                      dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, 
                      dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Signatures.SignatureID, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_Grades.GradeDescription, dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, 
                      dbo.DDA_KOI_Headers.Cass_ID, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, 
                      dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc600, 
                      dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_Disks.HasMeaning
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND 
                      dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'SingleLayerView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[26] 4[56] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -118
      End
      Begin Tables = 
         Begin Table = "DDA_Grades"
            Begin Extent = 
               Top = 133
               Left = 1242
               Bottom = 226
               Right = 1405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_GradeMapping"
            Begin Extent = 
               Top = 20
               Left = 1167
               Bottom = 98
               Right = 1319
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_WordCells"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 84
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Disks"
            Begin Extent = 
               Top = 33
               Left = 254
               Bottom = 404
               Right = 406
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Fabs"
            Begin Extent = 
               Top = 103
               Left = 23
               Bottom = 211
               Right = 175
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Surfaces"
            Begin Extent = 
               Top = 12
               Left = 425
               Bottom = 191
               Right = 587
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Stations"
            Begin Extent = 
               Top = 242
               Left = 13
               Bottom = 367
               Right = 165
            E' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SingleLayerView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'SingleLayerView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'nd
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_ResultDetail"
            Begin Extent = 
               Top = 4
               Left = 704
               Bottom = 133
               Right = 880
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Results"
            Begin Extent = 
               Top = 62
               Left = 962
               Bottom = 223
               Right = 1124
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Signatures"
            Begin Extent = 
               Top = 164
               Left = 738
               Bottom = 270
               Right = 918
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Products"
            Begin Extent = 
               Top = 284
               Left = 446
               Bottom = 395
               Right = 598
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_TesterTypes"
            Begin Extent = 
               Top = 198
               Left = 446
               Bottom = 278
               Right = 616
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_EIS_Resources"
            Begin Extent = 
               Top = 512
               Left = 823
               Bottom = 729
               Right = 975
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_KOI_Headers"
            Begin Extent = 
               Top = 314
               Left = 852
               Bottom = 463
               Right = 1101
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 45
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 6165
         Alias = 1995
         Table = 4530
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SingleLayerView'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'SingleLayerView', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SingleLayerView'
GO
/****** Object:  StoredProcedure [dbo].[_DDA_EIS_Resources_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_EIS_Resources_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[_DDA_EIS_Resources_Insert]
			@LotNum varchar(10)
           ,@Rsc725 varchar(10)
           ,@Rsc769 varchar(10)
           ,@Rsc771 varchar(10)
           ,@Rsc764 varchar(10)
           ,@Rsc575 varchar(10)
           ,@Rsc450 varchar(10)
           ,@Rsc453 varchar(10)
           ,@Rsc600 varchar(10)
           ,@Rsc766 varchar(10)
	,@DateTime725 datetime
      ,@DateTime769  datetime
      ,@DateTime771 datetime
      ,@DateTime764 datetime
      ,@DateTime575 datetime
      ,@DateTime450 datetime
      ,@DateTime453 datetime
      ,@DateTime600 datetime
      ,@DateTime766 datetime
AS


INSERT INTO [dbo].[DDA_EIS_Resources]
           ([LotNum]
           ,[Rsc725]
           ,[Rsc769]
           ,[Rsc771]
           ,[Rsc764]
           ,[Rsc575]
           ,[Rsc450]
           ,[Rsc453]
           ,[Rsc600]
           ,[Rsc766]
		,[DateTime725]
      ,[DateTime769]
      ,[DateTime771]
      ,[DateTime764]
      ,[DateTime575]
      ,[DateTime450]
      ,[DateTime453]
      ,[DateTime600]
      ,[DateTime766]
)
     VALUES
           (@LotNum
           ,@Rsc725
           ,@Rsc769
           ,@Rsc771
           ,@Rsc764
           ,@Rsc575
           ,@Rsc450
           ,@Rsc453
           ,@Rsc600
           ,@Rsc766
,@DateTime725 
      ,@DateTime769  
      ,@DateTime771 
      ,@DateTime764 
      ,@DateTime575 
      ,@DateTime450 
      ,@DateTime453 
      ,@DateTime600 
      ,@DateTime766 
)


' 
END
GO
/****** Object:  View [dbo].[DiskViewQuery]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DiskViewQuery]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[DiskViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Fabs.FabID, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, 
                      dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, 
                      dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_Disks.TestDiskDate AS TestDate, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, 
                      dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, 
                      dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, 
                      dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_Disks.HasMeaning
FROM         dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
'
GO
/****** Object:  View [dbo].[SourceViewQuery]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SourceViewQuery]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[SourceViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, 
                      dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, 
                      dbo.DDA_Surfaces.HasSignature, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, 
                      dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterTypeID, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_EIS_Resources.Rsc725, 
                      dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, 
                      dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, 
                      dbo.DDA_Disks.HasMeaning
FROM         dbo.DDA_Surfaces INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_WordCells ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
'
GO
/****** Object:  View [dbo].[SingleLayerViewQuery]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SingleLayerViewQuery]'))
EXEC dbo.sp_executesql @statement = N'
CREATE VIEW [dbo].[SingleLayerViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, 
                      dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, 
                      dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, dbo.DDA_Results.AnalyzeTime, 
                      dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, 
                      dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, 
                      dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, 
                      dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Signatures.SignatureID, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_Grades.GradeDescription, dbo.DDA_EIS_Resources.Rsc725, 
                      dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, 
                      dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, 
                      dbo.DDA_Disks.HasMeaning
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
'
GO
/****** Object:  View [dbo].[ChartView]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ChartView]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[ChartView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, 
                      dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Surfaces.NumberOfDefect, 
                      dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, 
                      dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, 
                      dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, 
                      dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, 
                      dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, 
                      dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_Disks.HasMeaning, 
                      dbo.DDA_Surfaces.HasSignature
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)'
GO
/****** Object:  StoredProcedure [dbo].[spDDA2EISCopyData]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDDA2EISCopyData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		CANG DO
-- Create date: 2010-01-26
-- Description:	Insert EIS Data into DDADB for each LOT
-- =============================================

CREATE PROCEDURE [dbo].[spDDA2EISCopyData] 
	-- Add the parameters for the stored procedure here
	@lotnum nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON

	IF ( EXISTS ( SELECT * FROM [DDA_EIS_Resources] WHERE LotNum = @lotnum) )
	BEGIN
		SELECT 2
		RETURN 2
	END
		
	DECLARE @Rsc450 VARCHAR(10)
	DECLARE @DateTime450 datetime
	DECLARE @Rsc453 VARCHAR(10)
	DECLARE @DateTime453 datetime
	DECLARE @Rsc600 VARCHAR(10)
	DECLARE @DateTime600 datetime
	DECLARE @Rsc725 VARCHAR(10)
	DECLARE @DateTime725 datetime
	DECLARE @Rsc766 VARCHAR(10)
	DECLARE @DateTime766 datetime
	DECLARE @Rsc769 VARCHAR(10)
	DECLARE @DateTime769 datetime
	DECLARE @Rsc771 VARCHAR(10)
	DECLARE @DateTime771 datetime
	DECLARE @Rsc764 VARCHAR(10)
	DECLARE @DateTime764 datetime
	DECLARE @Rsc575 VARCHAR(10)
	DECLARE @DateTime575 datetime

--	SELECT
--		@Rsc450 = Rsc450
--		, @DateTime450= TrDate450
--		, @Rsc453 = Rsc453
--		, @DateTime453=TrDate453
--		, @Rsc600 = Rsc600
--		, @DateTime600=TrDate600
--		, @Rsc725 = Rsc725
--		, @DateTime725=TrDate725
--		, @Rsc766 = Rsc766
--		, @DateTime766=TrDate766
--		, @Rsc769 = Rsc769
--		, @DateTime769=TrDate769
--		, @Rsc771 = Rsc771
--		, @DateTime771=TrDate771
--		, @Rsc764 = Rsc764
--		, @DateTime764=TrDate764
--		, @Rsc575 = Rsc575
--		, @DateTime575=TrDate575
--	FROM [WDKPG13].EIS.dbo.tbl_Resources_Summary as Summary WITH(NOLOCK) 
--	WHERE Lotno803804805 = @lotnum

	IF( @Rsc450 IS NULL 
		AND @Rsc453 IS NULL
		AND @Rsc600 IS NULL
		AND @Rsc725 IS NULL
		AND @Rsc766 IS NULL
		AND @Rsc769 IS NULL
		AND @Rsc771 IS NULL
		AND @Rsc764 IS NULL
		AND @Rsc575 IS NULL )
	BEGIN
		SELECT 0
	END
	ELSE
	BEGIN 
		INSERT INTO [DDA_EIS_Resources]
           ([LotNum]
           ,[Rsc725]
           ,[Rsc769]
           ,[Rsc771]
           ,[Rsc764]
           ,[Rsc575]
           ,[Rsc450]
           ,[Rsc453]
           ,[Rsc600]
           ,[Rsc766]
           ,[DateTime725]
           ,[DateTime769]
           ,[DateTime771]
           ,[DateTime764]
           ,[DateTime575]
           ,[DateTime450]
           ,[DateTime453]
           ,[DateTime600]
           ,[DateTime766])
     VALUES
           (@lotnum
           ,@Rsc725
           ,@Rsc769
           ,@Rsc771
           ,@Rsc764
           ,@Rsc575
           ,@Rsc450
           ,@Rsc453
           ,@Rsc600
           ,@Rsc766
           ,@DateTime725
           ,@DateTime769
           ,@DateTime771
           ,@DateTime764
           ,@DateTime575
           ,@DateTime450
           ,@DateTime453
           ,@DateTime600
           ,@DateTime766)

		SELECT 1
	END

END




' 
END
GO
/****** Object:  Trigger [trDeleteDisk]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trDeleteDisk]'))
EXEC dbo.sp_executesql @statement = N'create TRIGGER [dbo].[trDeleteDisk]
   ON  [dbo].[DDA_Disks]
   AFTER DELETE
AS 
BEGIN
	SET NOCOUNT ON;

	--delete from DDA_EIS_Resources
	DELETE FROM DDA_EIS_Resources 
	FROM DDA_EIS_Resources AS sd inner join deleted AS d 
	ON sd.LotNum = d.LotNo
	
	--delete from DDA_KOI_Headers
	DELETE FROM DDA_KOI_Headers 
	FROM DDA_KOI_Headers AS sd inner join deleted AS d 
	ON sd.Lot_Id = d.LotNo


END
'
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_ResultObjectTypes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ResultObjectTypes_GetByPrimaryKey]
	@ObjectTypeKey int
AS
	SELECT * FROM [dbo].[DDA_ResultObjectTypes] WHERE
		[ObjectTypeKey] = @ObjectTypeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ResultObjectTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjectTypes_Insert]
	@ObjectTypeKey int,
	@ObjectTypeName nvarchar(50)
AS
	INSERT INTO [dbo].[DDA_ResultObjectTypes]
	(
		[ObjectTypeKey],
		[ObjectTypeName]
	)
	VALUES
	(
		@ObjectTypeKey,
		@ObjectTypeName
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ResultObjectTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjectTypes_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ResultObjectTypes]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_ResultObjectTypes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ResultObjectTypes_DeleteByPrimaryKey]
	@ObjectTypeKey int
AS
	DELETE FROM [dbo].[DDA_ResultObjectTypes] WHERE
		[ObjectTypeKey] = @ObjectTypeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_ResultObjectTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjectTypes_Update]
	-- The rest of writeable parameters
	@ObjectTypeName nvarchar(50),
	-- Primary key parameters
	@ObjectTypeKey int
AS
	UPDATE [dbo].[DDA_ResultObjectTypes] SET
		[ObjectTypeName] = @ObjectTypeName
	WHERE
		[ObjectTypeKey] = @ObjectTypeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjectTypes_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjectTypes_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ResultObjectTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjectTypes_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ResultObjectTypes]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- Inserts a new record into the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_Products_Insert]
	@ProductCode nvarchar(50),
	@Prod_Class varchar(6)
AS
	INSERT INTO [dbo].[DDA_Products]
	(
		[ProductCode],
		Prod_Class
	
	)
	VALUES
	(
		@ProductCode,
		@Prod_Class
	)
	SELECT @@IDENTITY




' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Products_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Products_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- Updates a record in the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_Products_Update]
	-- The rest of writeable parameters
	@ProductCode nvarchar(50),
	@Prod_Class varchar(6),
	@ProductKey int
AS
	UPDATE [dbo].[DDA_Products] SET
		ProductCode = @ProductCode,
		Prod_Class = @Prod_Class
	WHERE
		ProductKey = @ProductKey




' 
END
GO
/****** Object:  View [dbo].[DDA_PRODUCT_DISKSIZE]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[DDA_PRODUCT_DISKSIZE]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[DDA_PRODUCT_DISKSIZE]
AS
SELECT     dbo.DDA_DiskSizes.Prod_Class, dbo.DDA_DiskSizes.DiskSizeKey, dbo.DDA_DiskSizes.InnerDiameter, dbo.DDA_DiskSizes.OuterDiameter, 
                      dbo.DDA_Products.ProductCode
FROM         dbo.DDA_DiskSizes INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_DiskSizes.Prod_Class = dbo.DDA_Products.Prod_Class
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'DDA_PRODUCT_DISKSIZE', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DDA_DiskSizes"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 190
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Products"
            Begin Extent = 
               Top = 6
               Left = 228
               Bottom = 106
               Right = 380
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DDA_PRODUCT_DISKSIZE'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'DDA_PRODUCT_DISKSIZE', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'DDA_PRODUCT_DISKSIZE'
GO
/****** Object:  StoredProcedure [dbo].[DDA_GET_SURFACE_DATA]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_GET_SURFACE_DATA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






CREATE PROCEDURE [dbo].[DDA_GET_SURFACE_DATA]
	@SurfaceKey bigint 
AS
BEGIN

	SELECT     DDA_Disks.DiskID, DDA_WordCells.TestCell, DDA_Stations.Tester, DDA_Disks.TestGrade, DDA_Disks.SlotNum, DDA_Disks.LotNo, 
                      DDA_Disks.InnerDiameter, DDA_Disks.OuterDiameter, DDA_Disks.L2_Top_Corr_cts, DDA_Disks.L2_Bot_Corr_cts, DDA_Disks.L2_Top_NCorr_cts, 
                      DDA_Disks.L2_Bot_NCorr_cts, DDA_SurfaceData.RawData, DDA_SurfaceData.SourceThumbnail, DDA_SurfaceData.SourceThumbnailFlat, 
                      DDA_Surfaces.TestDate, DDA_Surfaces.Surface, DDA_Surfaces.NumberOfDefect, DDA_Surfaces.IsDefectList, DDA_Fabs.FabID, DDA_Fabs.Description, 
                      DDA_SurfaceData.NoCompress, DDA_Products.ProductCode, DDA_Disks.CassetteID, DDA_TesterTypes.TesterType, DDA_Disks.LotIDCode, 
                      DDA_Disks.BinNo
	FROM         DDA_Disks INNER JOIN
                      DDA_Stations ON DDA_Disks.StationKey = DDA_Stations.StationKey INNER JOIN
                      DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey INNER JOIN
                      DDA_SurfaceData ON DDA_Surfaces.SurfaceKey = DDA_SurfaceData.SurfaceKey INNER JOIN
                      DDA_WordCells ON DDA_Disks.WordCellKey = DDA_WordCells.WordCellKey INNER JOIN
                      DDA_Fabs ON DDA_Disks.FabKey = DDA_Fabs.FabKey INNER JOIN
                      DDA_Products ON DDA_Disks.ProductKey = DDA_Products.ProductKey INNER JOIN
                      DDA_TesterTypes ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID

	WHERE DDA_Surfaces.SurfaceKey = @SurfaceKey

END





' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Products_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products_GetByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- Updates a record in the ''DDA_DiskPhysical'' table.
CREATE PROCEDURE [dbo].[DDA_Products_GetByName]
	@ProductCode nvarchar(50)
AS
	SELECT TOP 1 ProductKey FROM DDA_Products WHERE ProductCode = @ProductCode
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Products_UpdateFrom_WD_Products]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Products_UpdateFrom_WD_Products]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DDA_Products_UpdateFrom_WD_Products]
AS
BEGIN
	INSERT INTO DDA_Products(ProductCode,Prod_Class)
	SELECT Prod_Code,Prod_Class FROM WD_Products
	WHERE Prod_Code NOT IN(SELECT ProductCode FROM DDA_Products)

	UPDATE DDA_Products SET DDA_Products.Prod_Class=WD_Products.Prod_Class FROM WD_Products
	WHERE DDA_Products.ProductCode = WD_Products.Prod_Code AND DDA_Products.Prod_Class<>WD_Products.Prod_Class
	
END
' 
END
GO
/****** Object:  View [dbo].[SingleLayerResult]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[SingleLayerResult]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[SingleLayerResult]
AS
SELECT     TOP (1000) dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Disks.TestDiskDate, dbo.DDA_Grades.Grade, 
                      dbo.DDA_GradeMapping.GradeKey, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Surfaces.Surface, dbo.DDA_Surfaces.HasSignature
FROM         dbo.DDA_GradeMapping INNER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey INNER JOIN
                      dbo.DDA_Grades ON dbo.DDA_GradeMapping.GradeKey = dbo.DDA_Grades.GradeKey
WHERE     (dbo.DDA_Results.IsMultiLayer = 0) AND (NOT EXISTS
                          (SELECT     DiskKey
                            FROM          dbo.COM_DiskResponse
                            WHERE      (DiskKey = dbo.DDA_Disks.DiskKey))) AND (dbo.DDA_Surfaces.Processed = 1)
ORDER BY dbo.DDA_Disks.DiskKey
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'SingleLayerResult', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[59] 4[30] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "DDA_GradeMapping"
            Begin Extent = 
               Top = 28
               Left = 51
               Bottom = 130
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_WordCells"
            Begin Extent = 
               Top = 389
               Left = 916
               Bottom = 487
               Right = 1068
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Disks"
            Begin Extent = 
               Top = 1
               Left = 707
               Bottom = 381
               Right = 877
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Surfaces"
            Begin Extent = 
               Top = 18
               Left = 491
               Bottom = 280
               Right = 664
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Stations"
            Begin Extent = 
               Top = 259
               Left = 915
               Bottom = 347
               Right = 1067
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_ResultDetail"
            Begin Extent = 
               Top = 6
               Left = 273
               Bottom = 115
               Right = 435
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Results"
            Begin Extent = 
               Top = 186
               Left = 226
               Bottom = 328
               Right = 399
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SingleLayerResult'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane2' , N'SCHEMA',N'dbo', N'VIEW',N'SingleLayerResult', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "DDA_Products"
            Begin Extent = 
               Top = 137
               Left = 920
               Bottom = 237
               Right = 1072
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_TesterTypes"
            Begin Extent = 
               Top = 387
               Left = 452
               Bottom = 481
               Right = 626
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DDA_Grades"
            Begin Extent = 
               Top = 220
               Left = 0
               Bottom = 320
               Right = 163
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3915
         Alias = 1245
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SingleLayerResult'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'SingleLayerResult', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SingleLayerResult'
GO
/****** Object:  StoredProcedure [dbo].[GetRecipeOrderByKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecipeOrderByKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GetRecipeOrderByKey]	
@RecipeKey int , @output int output
AS
BEGIN
	WITH _temp AS
	(select ROW_NUMBER() OVER(ORDER BY recipekey) AS RowNumber,recipekey from dda_recipes)
	select @output=RowNumber from _temp where recipekey=@RecipeKey
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- Updates a record in the ''DDA_Recipes'' table.
CREATE PROCEDURE [dbo].[_DDA_Recipes_Update]
	-- The rest of writeable parameters
	@RecipeName nvarchar(50),
	@SignatureKey int,
	@PrevRecipeKey int,
	@Description nvarchar(255),
	@Status tinyint,
	@TesterType varchar(255),
	@BreakWhenFound bit,
	-- Primary key parameters
	@RecipeKey int
AS
	UPDATE [dbo].[DDA_Recipes] SET
		[PrevRecipeKey] = @PrevRecipeKey,
		[RecipeName] = @RecipeName,
		[SignatureKey] = @SignatureKey,
		[Description] = @Description,
		Status = @Status,
		TesterType = @TesterType,
		BreakWhenFound = @BreakWhenFound
	WHERE
		[RecipeKey] = @RecipeKey




' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Recipes'' table.
CREATE PROCEDURE [dbo].[_DDA_Recipes_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Recipes]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Recipes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Recipes_GetByPrimaryKey]
	@RecipeKey int
AS
	SELECT * FROM [dbo].[DDA_Recipes] WHERE
		[RecipeKey] = @RecipeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecipeList]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecipeList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GetRecipeList]	
AS
BEGIN
	SELECT  dbo.DDA_Recipes.*,dbo.DDA_Signatures.SignatureID, dbo.DDA_Signatures.SignatureName
	FROM    dbo.DDA_Signatures INNER JOIN
    dbo.DDA_Recipes ON dbo.DDA_Signatures.SignatureKey = dbo.DDA_Recipes.SignatureKey
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Recipes'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Recipes_DeleteByPrimaryKey]
	@RecipeKey int
AS
	DELETE FROM [dbo].[DDA_Recipes] WHERE
		[RecipeKey] = @RecipeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PREV_RECIPE]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_PREV_RECIPE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GET_PREV_RECIPE]
	@RECIPEKEY INT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT PrevRecipeKey FROM DDA_Recipes WHERE RecipeKey = @RECIPEKEY
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecipeByKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetRecipeByKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GetRecipeByKey]	
@RecipeKey int 
AS
BEGIN
	SELECT  DDA_Recipes.*, dbo.DDA_Signatures.SignatureName, DDA_Signatures.SignatureID, DDA_RecipeData.RawData
	FROM    DDA_Signatures INNER JOIN
    dbo.DDA_Recipes ON dbo.DDA_Signatures.SignatureKey = dbo.DDA_Recipes.SignatureKey INNER JOIN
	DDA_RecipeData ON DDA_Recipes.RecipeKey = DDA_RecipeData.RecipeKey
	WHERE DDA_Recipes.RecipeKey = @RecipeKey
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_PROCESS_SURFACE]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_PROCESS_SURFACE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GET_PROCESS_SURFACE]
	@RecipeKey INT,
	@PrevRecipeKey INT = -1,
	@Fabkey SMALLINT=0,
	@FromDate datetime = null,
	@TestGradeList varchar(1014) = null,
	@SurfaceKey BIGINT OUTPUT
AS
BEGIN
	SET @SurfaceKey = -1

	DECLARE @TesterType VARCHAR(255)
	SELECT @TesterType = TesterType FROM DDA_Recipes WHERE RecipeKey = @RecipeKey

	IF(@TesterType IS NOT NULL)
	BEGIN
		IF(@TesterType='''') SET @TesterType = NULL
	END

	DECLARE @SQL NVARCHAR(2048)

-- SELECT 
	SET @SQL = N''SELECT  TOP 1 @SurfaceKey=x.SurfaceKey FROM DDA_Surfaces x''

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + '' INNER JOIN DDA_Processed as y 
				ON x.SurfaceKey = y.SurfaceKey''

	IF(@Fabkey>0 OR @TesterType IS NOT NULL OR @TestGradeList IS NOT NULL )
	BEGIN
		
		SET @SQL = @SQL + '' INNER JOIN DDA_Disks ON x.DiskKey = DDA_Disks.DiskKey''
		IF( @TesterType IS NOT NULL)
		BEGIN
			SET @SQL = @SQL + '' INNER JOIN DDA_TesterTypes
				ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID''
		END
	END
		
-- WHERE
	SET @SQL = @SQL + ''
	WHERE''-- x.Processed=0''
	
	IF(@FromDate IS NOT NULL) SET @SQL = @SQL + '' x.TestDate >= '''''' + CAST(@FromDate AS VARCHAR) + '''''' AND''

	IF(@TestGradeList IS NOT NULL) SET @SQL = @SQL + '' ('' + @TestGradeList + '') AND''

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + '' y.RECIPEKEY = '' + CAST(@PrevRecipeKey AS NVARCHAR) + '' AND y.Finish=1 AND y.BreakWhenFound=0 AND''
	
	IF(@Fabkey>0) SET @SQL = @SQL + '' DDA_Disks.FabKey='' + CAST(@Fabkey AS NVARCHAR) + '' AND''
	
	IF(@TesterType IS NOT NULL) SET @SQL = @SQL + '' DDA_TesterTypes.TesterType LIKE '''''' + @TesterType + ''%'''' AND''
	
	--SET @SQL = @SQL + '' x.SurfaceKey NOT IN (SELECT SurfaceKey FROM DDA_Processed WHERE RecipeKey='' + CAST(@RecipeKey AS NVARCHAR) + '')''
	SET @SQL = @SQL + '' NOT EXISTS( SELECT p.SurfaceKey FROM DDA_Processed p WHERE RecipeKey='' + CAST(@RecipeKey AS NVARCHAR) + '' AND p.SurfaceKey=x.SurfaceKey)''

	EXECUTE sp_executesql @SQL,N''@SurfaceKey BIGINT OUTPUT'', @SurfaceKey OUTPUT
	--PRINT @SQL
END














' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Recipes'' table.
CREATE PROCEDURE [dbo].[_DDA_Recipes_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Recipes]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Recipes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Recipes_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Inserts a new record into the ''DDA_Recipes'' table.
CREATE PROCEDURE [dbo].[_DDA_Recipes_Insert]
	@RecipeName nvarchar(50),
	@SignatureKey int,
	@PrevRecipeKey int,
	@Description nvarchar(255),
	@Status tinyint,
	@TesterType varchar(255),
	@BreakWhenFound bit
AS
	INSERT INTO [dbo].[DDA_Recipes]
	(
		[PrevRecipeKey],
		[RecipeName],
		[SignatureKey],
		[Description],
		Status,
		TesterType,
		BreakWhenFound
	)
	VALUES
	(
		@PrevRecipeKey,
		@RecipeName,
		@SignatureKey,
		@Description,
		@Status,
		@TesterType,
		@BreakWhenFound
	)
	SELECT @@IDENTITY




' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_NPROCESS_SURFACE]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_NPROCESS_SURFACE]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GET_NPROCESS_SURFACE]
	@RecipeKey INT,
	@PrevRecipeKey INT = -1,
	@Fabkey SMALLINT=0,
	@FromDate datetime = null,
	@TestGradeList varchar(1014) = null,
	@N INT
AS
BEGIN
	DECLARE @TesterType VARCHAR(255)
	SELECT @TesterType = TesterType FROM DDA_Recipes WHERE RecipeKey = @RecipeKey

	IF(@TesterType IS NOT NULL)
	BEGIN
		IF(@TesterType='''') SET @TesterType = NULL
	END

	DECLARE @SQL NVARCHAR(4000)

-- SELECT 
	SET @SQL = ''SELECT  TOP '' + CAST(@N AS VARCHAR) + '' x.SurfaceKey FROM DDA_Surfaces x''

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + '' INNER JOIN DDA_Processed as y 
				ON x.SurfaceKey = y.SurfaceKey''

	IF(@Fabkey>0 OR @TesterType IS NOT NULL OR @TestGradeList IS NOT NULL )
	BEGIN
		
		SET @SQL = @SQL + '' INNER JOIN DDA_Disks ON x.DiskKey = DDA_Disks.DiskKey''
		IF( @TesterType IS NOT NULL)
		BEGIN
			SET @SQL = @SQL + '' INNER JOIN DDA_TesterTypes
				ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID''
		END
	END
		
-- WHERE
	SET @SQL = @SQL + ''
	WHERE''-- x.Processed=0''
	
	IF(@FromDate IS NOT NULL) SET @SQL = @SQL + '' x.TestDate >= '''''' + CAST(@FromDate AS VARCHAR) + '''''' AND''

	IF(@TestGradeList IS NOT NULL) SET @SQL = @SQL + '' ('' + @TestGradeList + '') AND''

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + '' y.RECIPEKEY = '' + CAST(@PrevRecipeKey AS NVARCHAR) + '' AND y.Finish=1 AND y.BreakWhenFound=0 AND''
	
	IF(@Fabkey>0) SET @SQL = @SQL + '' DDA_Disks.FabKey='' + CAST(@Fabkey AS NVARCHAR) + '' AND''
	
	IF(@TesterType IS NOT NULL) SET @SQL = @SQL + '' DDA_TesterTypes.TesterType LIKE '''''' + @TesterType + ''%'''' AND''
	
	--SET @SQL = @SQL + '' x.SurfaceKey NOT IN (SELECT SurfaceKey FROM DDA_Processed WHERE RecipeKey='' + CAST(@RecipeKey AS NVARCHAR) + '')''
	SET @SQL = @SQL + '' NOT EXISTS( SELECT p.SurfaceKey FROM DDA_Processed p WHERE RecipeKey='' + CAST(@RecipeKey AS NVARCHAR) + '' AND p.SurfaceKey=x.SurfaceKey)''

	EXECUTE sp_executesql @SQL
	--PRINT @SQL
END














' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Processed_UpdateProcessedSurface]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Processed_UpdateProcessedSurface]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DDA_Processed_UpdateProcessedSurface]
@SurfaceKey bigint
AS
BEGIN
	SET NOCOUNT ON;

--	declare @SurfaceKey bigint
--	set @SurfaceKey = 2

	--Get list of processed recipe
	DECLARE @TesterType nvarchar(50)
	SET @TesterType=''''
	SELECT @TesterType = DDA_TesterTypes.TesterType
		FROM DDA_Disks INNER JOIN
			DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey INNER JOIN
			DDA_TesterTypes ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID
		WHERE DDA_Surfaces.SurfaceKey = @SurfaceKey

	DECLARE @SUMR INT
	SELECT @SUMR = COUNT(RecipeKey) FROM DDA_Recipes WITH(NOLOCK) WHERE @TesterType LIKE TesterType + ''%'' 
--	PRINT @SUMR 

	DECLARE @SUMP INT
	SELECT @SUMP = COUNT(SurfaceKey)
	FROM DDA_Processed WITH(NOLOCK) INNER JOIN DDA_Recipes ON DDA_Processed.RecipeKey=DDA_Recipes.RecipeKey
	WHERE 
		@TesterType LIKE DDA_Recipes.TesterType + ''%'' 
		AND DDA_Processed.SurfaceKey = @SurfaceKey AND Finish=1
--	PRINT @SUMP 

	IF( @SUMR <= @SUMP AND @SUMP>0) 
	BEGIN
		UPDATE DDA_Surfaces SET Processed=1 WHERE SurfaceKey = @SurfaceKey
	END
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[spDebug_PerformanceByHour]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebug_PerformanceByHour]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spDebug_PerformanceByHour]
	@RunFromDate DateTime,
	@RunToDate DateTime,
	@TesterType nvarchar(50)
AS
BEGIN

	DECLARE @TesterTypeID smallint
	SELECT TOP 1 @TesterTypeID = TesterTypeID FROM DDA_TesterTypes WHERE TesterType=@TesterType

	CREATE TABLE #RawData
	(
		AtPoint datetime,
		LoadedSurfaces int,
		ProcessedSurfaces int,
		RemainSurfaces int
	)

	DECLARE @From datetime
	DECLARE @To datetime
	DECLARE @loaded int,@processed int,@remain int
	
	SET @From = @RunFromDate
	WHILE(@From<=@RunToDate)
	BEGIN
		SET @To = DATEADD(hh,1,@From)
		IF( @To > @RunToDate ) BREAK

		IF(@TesterTypeID IS NOT NULL)
		BEGIN

			SELECT   @loaded = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where DDA_Disks.TesterTypeID = @TesterTypeID AND InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) 

			SELECT   @processed = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where DDA_Disks.TesterTypeID = @TesterTypeID AND InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 1

			SELECT   @remain = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where DDA_Disks.TesterTypeID = @TesterTypeID AND InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 0
		END
		ELSE
		BEGIN

			SELECT   @loaded = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) 

			SELECT   @processed = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 1

			SELECT   @remain = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 0
		END

		INSERT INTO #RawData
		VALUES(@From,@loaded,@processed,@remain)

		SET @From = @To
	END

	SELECT * FROM #RawData

	DROP TABLE #RawData

END

--spDebug_PerformanceByHour ''2009-02-26 00:00:00'',''2009-03-04 00:00:00'',''MRS''' 
END
GO
/****** Object:  StoredProcedure [dbo].[spDebug_PerformanceByDay]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDebug_PerformanceByDay]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[spDebug_PerformanceByDay]
	@RunFromDate DateTime,
	@RunToDate DateTime,
	@TesterType nvarchar(50)
AS
BEGIN

	DECLARE @TesterTypeID smallint
	SELECT TOP 1 @TesterTypeID = TesterTypeID FROM DDA_TesterTypes WHERE TesterType=@TesterType

	CREATE TABLE #RawData
	(
		AtPoint datetime,
		LoadedSurfaces int,
		ProcessedSurfaces int,
		RemainSurfaces int
	)

	DECLARE @From datetime
	DECLARE @To datetime
	DECLARE @loaded int,@processed int,@remain int
	
	SET @From = @RunFromDate
	WHILE(@From<=@RunToDate)
	BEGIN
		SET @To = DATEADD(dd,1,@From)
		IF( @To > @RunToDate ) BREAK

		IF(@TesterTypeID IS NOT NULL)
		BEGIN

			SELECT   @loaded = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where DDA_Disks.TesterTypeID = @TesterTypeID AND InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) 

			SELECT   @processed = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where DDA_Disks.TesterTypeID = @TesterTypeID AND InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 1

			SELECT   @remain = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where DDA_Disks.TesterTypeID = @TesterTypeID AND InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 0
		END
		ELSE
		BEGIN

			SELECT   @loaded = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) 

			SELECT   @processed = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 1

			SELECT   @remain = count(surfacekey)  
			FROM         DDA_Disks INNER JOIN
								  DDA_Surfaces ON DDA_Disks.DiskKey = DDA_Surfaces.DiskKey
			where InsertedDate BETWEEN @From AND DATEADD(ms,-1,@To) AND Processed = 0
		END

		INSERT INTO #RawData
		VALUES(@From,@loaded,@processed,@remain)

		SET @From = @To
	END

	SELECT * FROM #RawData

	DROP TABLE #RawData

END

--spDebug_PerformanceByDay ''2009-02-26 00:00:00'',''2009-03-04 00:00:00'',''MRS''' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Surfaces_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Surfaces_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_Surfaces'' table.
CREATE PROCEDURE [dbo].[_DDA_Surfaces_Insert]
	@SurfaceKey bigint,
	@DiskKey bigint,
	@TestDate datetime,
	@Surface tinyint,
	@NumberOfDefect int,
	@Loaded bit,
	@HasSignature bit,
	@IsDefectList bit,
	@Processed bit,
	@Deleted bit,
	@ProcessingDuration int,
	@InsertedDate datetime,
	@filename	varchar(50)
AS
	INSERT INTO [dbo].[DDA_Surfaces]
	(
		[SurfaceKey],
		[DiskKey],
		[TestDate],
		[Surface],
		[NumberOfDefect],
		Loaded,
		HasSignature,
		IsDefectList,
		Processed,
		Deleted,
		ProcessingDuration,
		InsertedDate,
		[FileName]
	)
	VALUES
	(
		@SurfaceKey,
		@DiskKey,
		@TestDate,
		@Surface,
		@NumberOfDefect,
		@Loaded,
		@HasSignature,
		@IsDefectList,
		@Processed,
		@Deleted,
		@ProcessingDuration,
		@InsertedDate,
		@filename
	)

	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_GetKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_GetKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DDA_Surfaces_GetKey]
	@DiskKey	bigint,
	@Surface	bit,
	@SurfaceKey bigint output
AS
	SELECT TOP 1 @SurfaceKey = SurfaceKey FROM DDA_Surfaces WITH(NOLOCK)
	WHERE 
	DiskKey = @DiskKey
	AND Surface = @Surface
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Fabs'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Fabs_DeleteByPrimaryKey]
	@FabKey smallint
AS
	DELETE FROM [dbo].[DDA_Fabs] WHERE
		[FabKey] = @FabKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_Fabs'' table.
CREATE PROCEDURE [dbo].[_DDA_Fabs_Update]
	-- The rest of writeable parameters
	@FabID nvarchar(30),
	@FabUUID nvarchar(16),
	@Description nvarchar(100),
	-- Primary key parameters
	@FabKey smallint
AS
	UPDATE [dbo].[DDA_Fabs] SET
		[FabID] = @FabID,
		[FabUUID] = @FabUUID,
		[Description] = @Description
	WHERE
		[FabKey] = @FabKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Fabs'' table.
CREATE PROCEDURE [dbo].[_DDA_Fabs_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Fabs]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_FabKey_GetByID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_FabKey_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DDA_FabKey_GetByID]
	@ID nvarchar(30)
AS
	SELECT TOP 1 FabKey FROM DDA_Fabs WITH(NOLOCK) WHERE FabID = @ID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Fabs'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Fabs_GetByPrimaryKey]
	@FabKey smallint
AS
	SELECT * FROM [dbo].[DDA_Fabs] WHERE
		[FabKey] = @FabKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Fabs'' table.
CREATE PROCEDURE [dbo].[_DDA_Fabs_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Fabs]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Fab_GetByID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Fab_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[DDA_Fab_GetByID]
	@ID nvarchar(30)
AS
	SELECT TOP 1 * FROM DDA_Fabs WITH(NOLOCK) WHERE FabID = @ID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Fabs_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Fabs_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_Fabs'' table.
CREATE PROCEDURE [dbo].[_DDA_Fabs_Insert]
	@FabID nvarchar(30),
	@FabUUID nvarchar(16),
	@Description nvarchar(100)
AS
	INSERT INTO [dbo].[DDA_Fabs]
	(
		[FabID],
		[FabUUID],
		[Description]
	)
	VALUES
	(
		@FabID,
		@FabUUID,
		@Description
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''sysdiagrams'' table using the primary key value.
CREATE PROCEDURE [dbo].[_sysdiagrams_DeleteByPrimaryKey]
	@Diagram_id int
AS
	DELETE FROM [dbo].[sysdiagrams] WHERE
		[diagram_id] = @Diagram_id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''sysdiagrams'' table.
CREATE PROCEDURE [dbo].[_sysdiagrams_Update]
	-- The rest of writeable parameters
	@Name sysname,
	@Principal_id int,
	@Version int,
	@Definition varbinary(max),
	-- Primary key parameters
	@Diagram_id int
AS
	UPDATE [dbo].[sysdiagrams] SET
		[name] = @Name,
		[principal_id] = @Principal_id,
		[version] = @Version,
		[definition] = @Definition
	WHERE
		[diagram_id] = @Diagram_id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''sysdiagrams'' table.
CREATE PROCEDURE [dbo].[_sysdiagrams_Insert]
	@Name sysname,
	@Principal_id int,
	@Version int,
	@Definition varbinary(max)
AS
	INSERT INTO [dbo].[sysdiagrams]
	(
		[name],
		[principal_id],
		[version],
		[definition]
	)
	VALUES
	(
		@Name,
		@Principal_id,
		@Version,
		@Definition
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''sysdiagrams'' table using the primary key value.
CREATE PROCEDURE [dbo].[_sysdiagrams_GetByPrimaryKey]
	@Diagram_id int
AS
	SELECT * FROM [dbo].[sysdiagrams] WHERE
		[diagram_id] = @Diagram_id
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''sysdiagrams'' table.
CREATE PROCEDURE [dbo].[_sysdiagrams_GetAll]
AS
	SELECT * FROM [dbo].[sysdiagrams]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_sysdiagrams_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_sysdiagrams_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''sysdiagrams'' table.
CREATE PROCEDURE [dbo].[_sysdiagrams_DeleteAll]
AS
	DELETE FROM [dbo].[sysdiagrams]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_TesterType_GetByID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_TesterType_GetByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DDA_TesterType_GetByID]
	@ID nvarchar(50)
AS
	SELECT TOP 1 TesterTypeID FROM DDA_TesterTypes WITH(NOLOCK) WHERE TesterType = @ID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_TesterTypes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_TesterTypes_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Inserts a new record into the ''DDA_Fabs'' table.
CREATE PROCEDURE [dbo].[_DDA_TesterTypes_Insert]
	@TesterType nvarchar(50)	
AS
	INSERT INTO [dbo].[DDA_TesterTypes]
	(
		TesterType
	)
	VALUES
	(
		@TesterType
	)
	SELECT @@IDENTITY

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_TesterTypes_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_TesterTypes_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Gets all records from the ''DDA_Surfaces'' table.
CREATE PROCEDURE [dbo].[_DDA_TesterTypes_GetAll]
AS
	SELECT * FROM [dbo].[DDA_TesterTypes]

' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_DiskHeaders_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_DiskHeaders_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_DiskHeaders_Insert]
	@LotNum varchar(10),
	@slotNum smallint,
	@WordCellKey int,
	@Rsc725 varchar(10),
	@Rsc769 varchar(10),
	@Rsc771 varchar(10),
	@Rsc764 varchar(10),
	@Rsc575 varchar(10),
	@KKLot varchar(10),
	@KKSlot varchar(2),
	@Rsc450 VARCHAR(10),
	@Rsc453 VARCHAR(10),
	@Rsc600 VARCHAR(10),
	@Rsc766 VARCHAR(10)
AS
BEGIN
	insert into DDA_DiskHeaders(LotNum,slotNum,WordCellKey,Rsc725,Rsc769,Rsc771,Rsc764,Rsc575,KKLot,KKSlot,Rsc450,Rsc453,Rsc600,Rsc766)
	values(@LotNum,@slotNum,@WordCellKey,@Rsc725,@Rsc769,@Rsc771,@Rsc764,@Rsc575,@KKLot,@KKSlot,@Rsc450,@Rsc453,@Rsc600,@Rsc766)
END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskHeaders_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskHeaders_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[_DDA_DiskHeaders_Insert]
	@LotNum varchar(10),
	@slotNum smallint,
	@WordCellKey int,
	@Rsc725 varchar(10),
	@Rsc769 varchar(10),
	@Rsc771 varchar(10),
	@Rsc764 varchar(10),
	@Rsc575 varchar(10),
	@KKLot varchar(10),
	@KKSlot varchar(2),
	@Rsc450 VARCHAR(10),
	@Rsc453 VARCHAR(10),
	@Rsc600 VARCHAR(10),
	@Rsc766 VARCHAR(10)
AS
BEGIN
	insert into DDA_DiskHeaders(LotNum,slotNum,WordCellKey,Rsc725,Rsc769,Rsc771,Rsc764,Rsc575,KKLot,KKSlot,Rsc450,Rsc453,Rsc600,Rsc766)
	values(@LotNum,@slotNum,@WordCellKey,@Rsc725,@Rsc769,@Rsc771,@Rsc764,@Rsc575,@KKLot,@KKSlot,@Rsc450,@Rsc453,@Rsc600,@Rsc766)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ControlRule'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRule_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ControlRule]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_ControlRule'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ControlRule_GetByPrimaryKey]
	@ControlRuleID char(40)
AS
	SELECT * FROM [dbo].[DDA_ControlRule] WHERE
		[ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ControlRule'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRule_Insert]
	@ControlRuleID char(40),
	@Title nvarchar(50),
	@SubCategory nvarchar(50),
	@Category nvarchar(50),
	@Description nvarchar(200)
AS
	INSERT INTO [dbo].[DDA_ControlRule]
	(
		[ControlRuleID],
		[Title],
		[SubCategory],
		[Category],
		[Description]
	)
	VALUES
	(
		@ControlRuleID,
		@Title,
		@SubCategory,
		@Category,
		@Description
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_ControlRule'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ControlRule_DeleteByPrimaryKey]
	@ControlRuleID char(40)
AS
	DELETE FROM [dbo].[DDA_ControlRule] WHERE
		[ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_ControlRule'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRule_Update]
	-- The rest of writeable parameters
	@Title nvarchar(50),
	@SubCategory nvarchar(50),
	@Category nvarchar(50),
	@Description nvarchar(200),
	-- Primary key parameters
	@ControlRuleID char(40)
AS
	UPDATE [dbo].[DDA_ControlRule] SET
		[Title] = @Title,
		[SubCategory] = @SubCategory,
		[Category] = @Category,
		[Description] = @Description
	WHERE
		[ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRule_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRule_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ControlRule'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRule_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ControlRule]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LastUpdateTable_GetLastDateTime]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastUpdateTable_GetLastDateTime]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[LastUpdateTable_GetLastDateTime]
	@TableName varchar(255),
	@LastDateTime datetime output
AS
	SELECT @LastDateTime = LastDateTime
	FROM [DDA_LastUpdateTable]
	WHERE TableName = @TableName

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_LastUpdateTable_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_LastUpdateTable_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[_DDA_LastUpdateTable_Update]
	@TableName varchar(255),
	@LastDateTime DATETIME
AS
	UPDATE [dbo].[DDA_LastUpdateTable]
	SET LastDateTime = @LastDateTime
	WHERE TableName = @TableName
set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
' 
END
GO
/****** Object:  StoredProcedure [dbo].[LastUpdateTable_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LastUpdateTable_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[LastUpdateTable_Insert]
	@TableName varchar(255)
AS
	
	IF NOT EXISTS ( SELECT TableName FROM [DDA_LastUpdateTable] WHERE TableName=@TableName)
	BEGIN
		INSERT INTO [dbo].[DDA_LastUpdateTable]
		(
			[TableName],
			[LastDateTime]
		)
		VALUES
		(
			@TableName,
			GETDATE()
		)
	END
	ELSE
	BEGIN
		UPDATE [DDA_LastUpdateTable]
		SET [LastDateTime] = GETDATE()
		WHERE TableName=@TableName
	END






' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_LastUpdateTable_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_LastUpdateTable_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[_DDA_LastUpdateTable_Insert]
	@TableName varchar(255),
	@LastDateTime DATETIME
AS
	INSERT INTO [dbo].[DDA_LastUpdateTable]
	(
		[TableName],
		[LastDateTime]
	)
	VALUES
	(
		@TableName,
		@LastDateTime
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_WordCells'' table.
CREATE PROCEDURE [dbo].[_DDA_WordCells_Update]
	-- The rest of writeable parameters
	@TestCell nvarchar(50),
	-- Primary key parameters
	@WordCellKey int
AS
	UPDATE [dbo].[DDA_WordCells] SET
		[TestCell] = @TestCell
	WHERE
		[WordCellKey] = @WordCellKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_WordCells'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_WordCells_GetByPrimaryKey]
	@WordCellKey int
AS
	SELECT * FROM [dbo].[DDA_WordCells] WHERE
		[WordCellKey] = @WordCellKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_WordCells_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_WordCells_GetByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_DiskPhysical'' table.
CREATE PROCEDURE [dbo].[DDA_WordCells_GetByName]
	@TestCell nvarchar(50)
AS
	SELECT TOP 1 WordCellKey FROM DDA_WordCells WITH(NOLOCK) WHERE TestCell = @TestCell
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_WordCells'' table.
CREATE PROCEDURE [dbo].[_DDA_WordCells_GetAll]
AS
	SELECT * FROM [dbo].[DDA_WordCells]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_WordCells'' table.
CREATE PROCEDURE [dbo].[_DDA_WordCells_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_WordCells]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_WordCells'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_WordCells_DeleteByPrimaryKey]
	@WordCellKey int
AS
	DELETE FROM [dbo].[DDA_WordCells] WHERE
		[WordCellKey] = @WordCellKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_WordCells_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_WordCells_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_WordCells'' table.
CREATE PROCEDURE [dbo].[_DDA_WordCells_Insert]
	@TestCell nvarchar(50)
AS
	INSERT INTO [dbo].[DDA_WordCells]
	(
		[TestCell]
	)
	VALUES
	(
		@TestCell
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- Inserts a new record into the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_DiskSizes_Insert]
	@Prod_Class varchar(6),
	@InnerDiameter float,
	@OuterDiameter float
AS
	INSERT INTO [dbo].[DDA_DiskSizes]
	(
		[Prod_Class],
		[InnerDiameter],
		[OuterDiameter]
	)
	VALUES
	(
		@Prod_Class,
		@InnerDiameter,
		@OuterDiameter
	)
	SELECT @@IDENTITY




' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_DiskSizes_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_DiskSizes_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Updates a record in the ''DDA_DiskTypes'' table.
CREATE PROCEDURE [dbo].[_DDA_DiskSizes_Update]
	-- The rest of writeable parameters
	@Prod_Class varchar(6),
	@InnerDiameter float,
	@OuterDiameter float,
	-- Primary key parameters
	@DiskSizeKey int
AS
	UPDATE [dbo].[DDA_DiskSizes] SET
		[Prod_Class] = @Prod_Class,
		[InnerDiameter] = @InnerDiameter,
		[OuterDiameter] = @OuterDiameter
	WHERE
		DiskSizeKey = @DiskSizeKey





' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Updates a record in the ''DDA_Signatures'' table.
CREATE PROCEDURE [dbo].[_DDA_Signatures_Update]
	-- The rest of writeable parameters
	@SignatureID int,
	@SignatureName nvarchar(100),
	-- Primary key parameters
	@SignatureKey int
AS
	UPDATE [dbo].[DDA_Signatures] SET
		[SignatureName] = @SignatureName,
		[SignatureID] = @SignatureID
	WHERE
		[SignatureKey] = @SignatureKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Signatures_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Signatures_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Inserts a new record into the ''DDA_Signatures'' table.
CREATE PROCEDURE [dbo].[_DDA_Signatures_Insert]
	@SignatureID int,
	@SignatureName nvarchar(100)
	
AS
	INSERT INTO [dbo].[DDA_Signatures]
	(
		[SignatureName],
		SignatureID
	)
	VALUES
	(
		@SignatureName,
		@SignatureID
	)
	SELECT @@IDENTITY

' 
END
GO
/****** Object:  StoredProcedure [dbo].[ExportView_SurfaceOfSignature]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportView_SurfaceOfSignature]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

create PROCEDURE [dbo].[ExportView_SurfaceOfSignature]
	@View NVARCHAR(255),
	@FIELDS VARCHAR(1000),
	@WHERESQL NVARCHAR(4000),
	@Distinct bit = 0
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @SQL NVARCHAR(4000)
	DECLARE @F VARCHAR(255)
	DECLARE @ViewList VARCHAR(1024)
	DECLARE @ExList VARCHAR(1024)
	DECLARE @SDT VARCHAR(10)

	SET @ViewList = ''''
	SET @ExList = ''''
	SET @SDT = ''''

	IF @Distinct = 1 SET @SDT = '' DISTINCT ''

	DECLARE TableCursor CURSOR FOR 
	SELECT Keyword
	FROM dbo.[f_Split] (@FIELDS,'','')
	OPEN TableCursor
	FETCH NEXT FROM TableCursor INTO @F
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @F = LTRIM(RTRIM(@F))

		IF ( UPPER(@F) = ''KKLOT''
			OR UPPER(@F) = ''KKSLOT''
			OR UPPER(@F) = ''CASS_ID'' ) 
		BEGIN
			SET @ExList = @ExList + '',e.'' + @F
			SET @ViewList = @ViewList + '',e.'' + @F
		END
		ELSE 
		BEGIN
			IF( CHARINDEX ('' WHEN '',@F) >= 1 AND CHARINDEX ('' THEN '',@F) >= 1 )
			BEGIN
--				DECLARE @F VARCHAR(255)
--				SET @F = ''CASE Surface WHEN 0 THEN ''''Top'''' WHEN 1 Then ''''Bottom'''' END as Surface''
				SET @F = SUBSTRING(@F,1,4) + 
						+ '' v.'' + LTRIM(SUBSTRING(@F,CHARINDEX (''CASE'',@F) + 4,CHARINDEX(''WHEN'',@F) - CHARINDEX (''CASE'',@F) - 4))
				+ SUBSTRING(@F,CHARINDEX(''WHEN'',@F),LEN(@F) - CHARINDEX(''WHEN'',@F) + 1)
--				PRINT @F
				SET @ViewList = @ViewList + '','' + @F
			END
			ELSE
				SET @ViewList = @ViewList + '',v.'' + @F
		END

		FETCH NEXT FROM TableCursor INTO @F
	END
	CLOSE TableCursor
	DEALLOCATE TableCursor

	IF (@ViewList <> '''') SET @ViewList  = SUBSTRING(@ViewList , 2, LEN(@ViewList)-1)
	IF (@ExList <> '''') SET @ExList  = SUBSTRING(@ExList , 2, LEN(@ExList)-1)

	IF (@ExList = '''' AND LTRIM(RTRIM(@FIELDS)) <> ''*'')
	BEGIN
		SET @SQL = ''SELECT '' + @SDT + @ViewList + '' FROM '' + @View + '' as v WITH(NOLOCK)  WHERE '' + @WHERESQL +
		'' ORDER BY v.SurfaceKey''
		EXEC (@SQL)
	END
	ELSE
	BEGIN
		SET @SQL = ''SELECT * INTO #Temp FROM '' + @View + '' WITH(NOLOCK) WHERE '' + @WHERESQL

		IF(LTRIM(RTRIM(@FIELDS)) <> ''*'')
			SET @SQL = @SQL +''
				SELECT '' 
				+ @SDT
				+ @ViewList 
				+ '' FROM #Temp as v left join DDA_KOI_Headers as e WITH(NOLOCK) 
					on v.LotNo = e.Lot_ID
					and v.SlotNum = e.Lot_Slot ORDER BY v.SurfaceKey''
		ELSE 
			SET @SQL = @SQL + ''
				SELECT '' 
				+ @SDT 
				+ ''v.*,e.KKLot,e.KKSlot,e.Cass_ID FROM #Temp as v left join DDA_KOI_Headers  as e WITH(NOLOCK)
					on v.LotNo = e.Lot_ID
					and v.SlotNum = e.Lot_Slot ORDER BY v.SurfaceKey''

		EXEC (@SQL)
	END
	
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[ExportView]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportView]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[ExportView]
	@View NVARCHAR(255),
	@FIELDS VARCHAR(1000),
	@WHERESQL NVARCHAR(4000),
	@Distinct bit = 0
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @SQL NVARCHAR(4000)
	DECLARE @F VARCHAR(255)
	DECLARE @ViewList VARCHAR(1024)
	DECLARE @ExList VARCHAR(1024)
	DECLARE @SDT VARCHAR(10)

	SET @ViewList = ''''
	SET @ExList = ''''
	SET @SDT = ''''

	IF @Distinct = 1 SET @SDT = '' DISTINCT ''

	DECLARE TableCursor CURSOR FOR 
	SELECT Keyword
	FROM dbo.[f_Split] (@FIELDS,'','')
	OPEN TableCursor
	FETCH NEXT FROM TableCursor INTO @F
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @F = LTRIM(RTRIM(@F))

		IF ( UPPER(@F) = ''KKLOT''
			OR UPPER(@F) = ''KKSLOT''
			OR UPPER(@F) = ''CASS_ID'' ) 
		BEGIN
			SET @ExList = @ExList + '',e.'' + @F
			SET @ViewList = @ViewList + '',e.'' + @F
		END
		ELSE 
		BEGIN
			IF( CHARINDEX ('' WHEN '',@F) >= 1 AND CHARINDEX ('' THEN '',@F) >= 1 )
			BEGIN
--				DECLARE @F VARCHAR(255)
--				SET @F = ''CASE Surface WHEN 0 THEN ''''Top'''' WHEN 1 Then ''''Bottom'''' END as Surface''
				SET @F = SUBSTRING(@F,1,4) + 
						+ '' v.'' + LTRIM(SUBSTRING(@F,CHARINDEX (''CASE'',@F) + 4,CHARINDEX(''WHEN'',@F) - CHARINDEX (''CASE'',@F) - 4))
				+ SUBSTRING(@F,CHARINDEX(''WHEN'',@F),LEN(@F) - CHARINDEX(''WHEN'',@F) + 1)
--				PRINT @F
				SET @ViewList = @ViewList + '','' + @F
			END
			ELSE
				SET @ViewList = @ViewList + '',v.'' + @F
		END

		FETCH NEXT FROM TableCursor INTO @F
	END
	CLOSE TableCursor
	DEALLOCATE TableCursor

	IF (@ViewList <> '''') SET @ViewList  = SUBSTRING(@ViewList , 2, LEN(@ViewList)-1)
	IF (@ExList <> '''') SET @ExList  = SUBSTRING(@ExList , 2, LEN(@ExList)-1)

	IF (@ExList = '''' AND LTRIM(RTRIM(@FIELDS)) <> ''*'')
	BEGIN
		SET @SQL = ''SELECT '' + @SDT + @ViewList + '' FROM '' + @View + '' as v WITH(NOLOCK)  WHERE '' + @WHERESQL
		EXEC (@SQL)
	END
	ELSE
	BEGIN
		SET @SQL = ''SELECT * INTO #Temp FROM '' + @View + '' WITH(NOLOCK) WHERE '' + @WHERESQL

		IF(LTRIM(RTRIM(@FIELDS)) <> ''*'')
			SET @SQL = @SQL +''
				SELECT '' 
				+ @SDT
				+ @ViewList 
				+ '' FROM #Temp as v left join DDA_KOI_Headers as e WITH(NOLOCK) 
					on v.LotNo = e.Lot_ID
					and v.SlotNum = e.Lot_Slot''
		ELSE 
			SET @SQL = @SQL + ''
				SELECT '' 
				+ @SDT 
				+ ''v.*,e.KKLot,e.KKSlot,e.Cass_ID FROM #Temp as v left join DDA_KOI_Headers  as e WITH(NOLOCK)
					on v.LotNo = e.Lot_ID
					and v.SlotNum = e.Lot_Slot''

		EXEC (@SQL)
	END
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceOfDisk]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceOfDisk]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[_GetSourceOfDisk]
	@WHERESQL NVARCHAR(4000),
	@PAGEPOSITITION INT = 0,
	@PAGESIZE INT = 20,
	@TOTALROW INT = 0 OUTPUT
AS
BEGIN

exec Paging_FromView
	''DiskView'',
	''DiskKey'',
	''DiskView.*'',
	@WHERESQL,
	@PAGEPOSITITION,
	@PAGESIZE,
	@TOTALROW output

--
--	SET NOCOUNT ON;
--
--	DECLARE @SQL NVARCHAR(4000)
--	DECLARE @ORDERBY VARCHAR(100)
--
--	SET @ORDERBY = ''DiskKey''
--	SET @SQL = ''SELECT * FROM [DiskView] WHERE '' + @WHERESQL
--
--	--GET TOTAL ROW NUMBER
--	DECLARE @SQLQuery AS NVARCHAR(4000)
--	SET @SQLQuery = N''SELECT @TOTALROW = COUNT(DiskKey) FROM (''  + @SQL + '') as a''
--	EXECUTE sp_executesql @SQLQuery,N''@TOTALROW INT OUTPUT'', @TOTALROW OUTPUT
--	--PRINT CAST(@TOTALROW AS VARCHAR)
--
--	--Calculate row indices
--	DECLARE @StartRow INT;
--	DECLARE @EndRow INT;
--	DECLARE @PageCount INT;-- khong su dung
--	EXEC [Paging_GetRowIndices] @PAGEPOSITITION, @PAGESIZE, @TOTALROW, @PAGECOUNT OUTPUT, @StartRow OUTPUT, @EndRow OUTPUT;
--
--	DECLARE @Fields NVARCHAR(3000)
--	DECLARE @Tables NVARCHAR(200)
--
--	SET @Fields = ''* '';
--	SET @Tables = ''[DiskView]'';
--
--		SET @SQL = 
--		''WITH _Paging_ AS '' +
--		''(SELECT TOP '' + CAST(@EndRow AS NVARCHAR) + '' ROW_NUMBER() OVER (ORDER BY '' + @ORDERBY + '') AS RowNumber,DiskKey FROM ('' +
--			''SELECT '' + @Fields +
--			''FROM '' + @Tables + '' '' +
--			''WHERE '' + @WHERESQL + '') AS Temp ) '' +
--		''SELECT * INTO #TempResult FROM _Paging_ WHERE RowNumber >='' + CAST(@StartRow AS NVARCHAR) + '' ORDER BY RowNumber''
--
--	+ ''
--		SELECT [DiskView].* FROM [DiskView] INNER JOIN #TempResult ON [DiskView].DiskKey=#TempResult.DiskKey
--		''
--
--	EXEC (@SQL)
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSingleLayer]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSingleLayer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[_GetSingleLayer]
	@WHERESQL NVARCHAR(4000),
	@PAGEPOSITITION INT = 0,
	@PAGESIZE INT = 20,
	@TOTALROW INT = 0 OUTPUT
AS
BEGIN

exec Paging_FromView
	''SingleLayerView'',
	''ResultKey'',
	''SingleLayerView.*'',
	@WHERESQL,
	@PAGEPOSITITION,
	@PAGESIZE,
	@TOTALROW output

--	SET NOCOUNT ON;
--
--	DECLARE @SQL NVARCHAR(4000)
--	DECLARE @ORDERBY VARCHAR(100)
--
--	SET @ORDERBY = ''ResultKey''
--	SET @SQL = ''SELECT * FROM [SingleLayerView] WHERE '' + @WHERESQL
--
--	--GET TOTAL ROW NUMBER
--	DECLARE @SQLQuery AS NVARCHAR(4000)
--	SET @SQLQuery = N''SELECT @TOTALROW = COUNT(ResultKey) FROM (''  + @SQL + '') as a''
--	EXECUTE sp_executesql @SQLQuery,N''@TOTALROW INT OUTPUT'', @TOTALROW OUTPUT
--	--PRINT CAST(@TOTALROW AS VARCHAR)
--
--	--Calculate row indices
--	DECLARE @StartRow INT;
--	DECLARE @EndRow INT;
--	DECLARE @PageCount INT;-- khong su dung
--	EXEC [Paging_GetRowIndices] @PAGEPOSITITION, @PAGESIZE, @TOTALROW, @PAGECOUNT OUTPUT, @StartRow OUTPUT, @EndRow OUTPUT;
--
--	DECLARE @Fields NVARCHAR(3000)
--	DECLARE @Tables NVARCHAR(200)
--
--	SET @Fields = ''* '';
--	SET @Tables = ''[SingleLayerView]'';
--
--	SET @SQL = 
--		''WITH _Paging_ AS '' +
--		''(SELECT TOP '' + CAST(@EndRow AS NVARCHAR) + '' ROW_NUMBER() OVER (ORDER BY '' + @ORDERBY + '') AS RowNumber, ResultKey FROM ('' +
--			''SELECT '' + @Fields +
--			''FROM '' + @Tables + '' '' +
--			''WHERE '' + @WHERESQL + '') AS Temp ) '' +
--		''SELECT * INTO #TempResult FROM _Paging_ WHERE RowNumber >='' + CAST(@StartRow AS NVARCHAR) + '' ORDER BY RowNumber''
--
--	+ ''
--		SELECT [SingleLayerView].* FROM [SingleLayerView] INNER JOIN #TempResult ON [SingleLayerView].ResultKey=#TempResult.ResultKey
--		''
--	--print @SQL
--	EXEC (@SQL)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetDataSource]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetDataSource]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[_GetDataSource]
	@WHERESQL NVARCHAR(4000),
	@PAGEPOSITITION INT = 0,
	@PAGESIZE INT = 20,
	@TOTALROW INT = 0 OUTPUT
AS
BEGIN

exec Paging_FromView
	''SourceView'',
	''SurfaceKey'',
	''SourceView.*'',
	@WHERESQL,
	@PAGEPOSITITION,
	@PAGESIZE,
	@TOTALROW output

--	SET NOCOUNT ON;
--
--	DECLARE @SQL NVARCHAR(4000)
--	DECLARE @ORDERBY VARCHAR(1000) -- LAY THEO KEY CAN LIET KE : vd view by Disk thi phai lay theo key cua Disk
--
--	SET @ORDERBY = ''SurfaceKey''
--	SET @SQL = ''SELECT * FROM [SourceView] WHERE '' + @WHERESQL
--
--	--GET TOTAL ROW NUMBER
--	DECLARE @SQLQuery AS NVARCHAR(4000)
--	SET @SQLQuery = N''SELECT @TOTALROW = COUNT(SurfaceKey) FROM (''  + @SQL + '') as a''
--	EXECUTE sp_executesql @SQLQuery,N''@TOTALROW INT OUTPUT'', @TOTALROW OUTPUT
--
--	--PRINT CAST(@TOTALROW AS VARCHAR)
--	--Calculate row indices
--	DECLARE @StartRow INT;
--	DECLARE @EndRow INT;
--	DECLARE @PageCount INT;-- khong su dung
--	EXEC [Paging_GetRowIndices] @PAGEPOSITITION, @PAGESIZE, @TOTALROW, @PAGECOUNT OUTPUT, @StartRow OUTPUT, @EndRow OUTPUT;
--
--	DECLARE @Fields NVARCHAR(3000)
--	DECLARE @Tables NVARCHAR(200)
--
--	SET @Fields = ''* '';
--	SET @Tables = ''[SourceView]'';
--
--		SET @SQL = 
--		''WITH _Paging_ AS '' +
--		''(SELECT TOP '' + CAST(@EndRow AS NVARCHAR) + '' ROW_NUMBER() OVER (ORDER BY '' + @ORDERBY + '') AS RowNumber,SurfaceKey FROM ('' +
--			''SELECT '' + @Fields +
--			''FROM '' + @Tables + '' '' +
--			''WHERE '' + @WHERESQL + '') AS Temp ) '' +
--		''SELECT * INTO #TempResult FROM _Paging_ WHERE RowNumber >='' + CAST(@StartRow AS NVARCHAR) + '' ORDER BY RowNumber''
--
--	+ ''
--		SELECT SourceView.* FROM SourceView INNER JOIN #TempResult ON SourceView.SurfaceKey=#TempResult.SurfaceKey
--		''
--
--	EXEC (@SQL)
	
END












' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Stations'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Stations_GetByPrimaryKey]
	@StationKey int
AS
	SELECT * FROM [dbo].[DDA_Stations] WHERE
		[StationKey] = @StationKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_Stations'' table.
CREATE PROCEDURE [dbo].[_DDA_Stations_Insert]
	@Tester nvarchar(50)
AS
	INSERT INTO [dbo].[DDA_Stations]
	(
		[Tester]
	)
	VALUES
	(
		@Tester
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Stations'' table.
CREATE PROCEDURE [dbo].[_DDA_Stations_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Stations]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_Stations'' table.
CREATE PROCEDURE [dbo].[_DDA_Stations_Update]
	-- The rest of writeable parameters
	@Tester nvarchar(50),
	-- Primary key parameters
	@StationKey int
AS
	UPDATE [dbo].[DDA_Stations] SET
		[Tester] = @Tester
	WHERE
		[StationKey] = @StationKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Station_GetByName]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Station_GetByName]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_DiskPhysical'' table.
CREATE PROCEDURE [dbo].[DDA_Station_GetByName]
	@Tester nvarchar(50)
AS
	SELECT TOP 1 StationKey FROM DDA_Stations WITH(NOLOCK) WHERE Tester = @Tester
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Stations'' table.
CREATE PROCEDURE [dbo].[_DDA_Stations_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Stations]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Stations_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Stations_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Stations'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Stations_DeleteByPrimaryKey]
	@StationKey int
AS
	DELETE FROM [dbo].[DDA_Stations] WHERE
		[StationKey] = @StationKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_PrivateKey'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_PrivateKey_DeleteByPrimaryKey]
	@PKey smallint
AS
	DELETE FROM [dbo].[DDA_PrivateKey] WHERE
		[PKey] = @PKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_PrivateKey'' table.
CREATE PROCEDURE [dbo].[_DDA_PrivateKey_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_PrivateKey]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_PrivateKey'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_PrivateKey_GetByPrimaryKey]
	@PKey smallint
AS
	SELECT * FROM [dbo].[DDA_PrivateKey] WHERE
		[PKey] = @PKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_PrivateKey'' table.
CREATE PROCEDURE [dbo].[_DDA_PrivateKey_GetAll]
AS
	SELECT * FROM [dbo].[DDA_PrivateKey]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_PrivateKey'' table.
CREATE PROCEDURE [dbo].[_DDA_PrivateKey_Insert]
	@PrivateKey char(40)
AS
	INSERT INTO [dbo].[DDA_PrivateKey]
	(
		[PrivateKey]
	)
	VALUES
	(
		@PrivateKey
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_PrivateKey_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_PrivateKey_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_PrivateKey'' table.
CREATE PROCEDURE [dbo].[_DDA_PrivateKey_Update]
	-- The rest of writeable parameters
	@PrivateKey char(40),
	-- Primary key parameters
	@PKey smallint
AS
	UPDATE [dbo].[DDA_PrivateKey] SET
		[PrivateKey] = @PrivateKey
	WHERE
		[PKey] = @PKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_KOI_Headers_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_KOI_Headers_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[_DDA_KOI_Headers_Insert]
			@Lot_Id varchar(20)
           ,@Lot_Slot smallint
           ,@AutoNumber bigint
           ,@KKLot varchar(10)
           ,@KKSlot varchar(2)
           ,@Cass_ID varchar(20)
AS


INSERT INTO [DDA_KOI_Headers]
           ([Lot_Id]
           ,[Lot_Slot]
           ,[AutoNumber]
           ,[KKLot]
           ,[KKSlot]
           ,[Cass_ID])
     VALUES
           (@Lot_Id
           ,@Lot_Slot
           ,@AutoNumber
           ,@KKLot
           ,@KKSlot
           ,@Cass_ID)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_ResultObjects'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjects_Update]
	-- The rest of writeable parameters
	@ResultKey bigint,
	@ObjectTypeKey int,
	@RawData image,
	@NumberOfDefect int,
	@LocationX float,
	@LocationY float,
	-- Primary key parameters
	@ObjectKey bigint
AS
	UPDATE [dbo].[DDA_ResultObjects] SET
		[ResultKey] = @ResultKey,
		[ObjectTypeKey] = @ObjectTypeKey,
		[RawData] = @RawData,
		[NumberOfDefect] = @NumberOfDefect,
		[LocationX] = @LocationX,
		[LocationY] = @LocationY
	WHERE
		[ObjectKey] = @ObjectKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_ResultObjects'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ResultObjects_GetByPrimaryKey]
	@ObjectKey bigint
AS
	SELECT * FROM [dbo].[DDA_ResultObjects] WHERE
		[ObjectKey] = @ObjectKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ResultObjects'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjects_Insert]
	@ResultKey bigint,
	@ObjectTypeKey int,
	@RawData image,
	@NumberOfDefect int,
	@LocationX float,
	@LocationY float
AS
	INSERT INTO [dbo].[DDA_ResultObjects]
	(
		[ResultKey],
		[ObjectTypeKey],
		[RawData],
		[NumberOfDefect],
		[LocationX],
		[LocationY]
	)
	VALUES
	(
		@ResultKey,
		@ObjectTypeKey,
		@RawData,
		@NumberOfDefect,
		@LocationX,
		@LocationY
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ResultObjects'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjects_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ResultObjects]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_ResultObjects'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ResultObjects_DeleteByPrimaryKey]
	@ObjectKey bigint
AS
	DELETE FROM [dbo].[DDA_ResultObjects] WHERE
		[ObjectKey] = @ObjectKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultObjects_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultObjects_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ResultObjects'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultObjects_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ResultObjects]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_EIS_PARAM]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_EIS_PARAM]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GET_EIS_PARAM] 
@NumTop int,
@AutoID bigint,
@TestDate datetime
AS
BEGIN

	SELECT LotNo,MAX(DiskKey) as DiskKey INTO #Disk FROM  dbo.DDA_Disks WITH (NOLOCK)
	WHERE DDA_Disks.TestDiskDate >= @TestDate 
		AND dbo.DDA_Disks.DiskKey >= @AutoID
	GROUP BY LotNo

	SELECT top (@NumTop) LotNo,DiskKey
	FROM  #Disk 
	WHERE NOT EXISTS(SELECT Lotnum FROM dbo.DDA_EIS_Resources
				WHERE 
				#Disk.LotNo = dbo.DDA_EIS_Resources.Lotnum)
	ORDER BY #Disk.DiskKey
	
	DROP TABLE #Disk

/*	
	SELECT top (@NumTop) dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.SlotNum
	FROM  dbo.DDA_Disks WITH(NOLOCK)
	WHERE dbo.DDA_Disks.TestDiskDate >= @TestDate 
	AND  dbo.DDA_Disks.DiskKey >= @AutoID 
	AND NOT EXISTS(SELECT Lotnum FROM dbo.DDA_EIS_Resources
				WHERE 
				dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.Lotnum)
	ORDER BY dbo.DDA_Disks.DiskKey	
*/	

END


/****** Object:  StoredProcedure [dbo].[_DDA_DiskHeaders_Insert]    Script Date: 02/11/2009 14:18:49 ******/
SET ANSI_NULLS ON

' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_KOI_PARAM]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_KOI_PARAM]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GET_KOI_PARAM] 
@NumTop int,
@AutoID bigint,
@TestDate datetime
AS
BEGIN
	
	SELECT DiskKey,LotNo,SlotNum,WordCellKey INTO #Disk FROM  dbo.DDA_Disks WITH(NOLOCK)
	WHERE DDA_Disks.TestDiskDate >= @TestDate 
		AND dbo.DDA_Disks.DiskKey >= @AutoID

	SELECT top (@NumTop) DiskKey, LotNo, SlotNum, dbo.DDA_WordCells.TestCell,DDA_WordCells.WordCellKey
	FROM  #Disk INNER JOIN dbo.DDA_WordCells WITH(NOLOCK) ON #Disk.WordCellKey = dbo.DDA_WordCells.WordCellKey
	WHERE NOT EXISTS(SELECT * FROM dbo.DDA_KOI_Headers
				WHERE 
					#Disk.LotNo = dbo.DDA_KOI_Headers.Lot_id
					AND #Disk.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot)
	ORDER BY #Disk.DiskKey

	DROP TABLE #Disk
/*	
	SELECT top (@NumTop) dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.SlotNum, dbo.DDA_WordCells.TestCell,DDA_WordCells.WordCellKey
	FROM  dbo.DDA_Disks WITH(NOLOCK) INNER JOIN dbo.DDA_WordCells WITH(NOLOCK) ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey
	WHERE dbo.DDA_Disks.TestDiskDate >= @TestDate
	AND dbo.DDA_Disks.DiskKey >= @AutoID
	AND NOT EXISTS(SELECT * FROM dbo.DDA_KOI_Headers
				WHERE 
					dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_id
					AND dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot)
	ORDER BY dbo.DDA_Disks.DiskKey
*/

END


/****** Object:  StoredProcedure [dbo].[_DDA_DiskHeaders_Insert]    Script Date: 02/11/2009 14:18:49 ******/
SET ANSI_NULLS ON



' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disks_Update_CassID_KKlot_KKSLot]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks_Update_CassID_KKlot_KKSLot]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_Disks_Update_CassID_KKlot_KKSLot] 
	-- Add the parameters for the stored procedure here
	@LotNo nvarchar(50),
	@SlotNum smallint,
	@WordCellKey int,
	@Cass_ID nvarchar(50),
	@KKLot nvarchar(50),
	@KKSlot nvarchar(2)

AS
BEGIN
	update DDA_Disks
	set CassetteID = @Cass_ID, KKLot = @KKLot,KKSlot = @KKSlot
	
	where LotNo = @LotNo
	and SlotNum = @SlotNum
	and WordCellKey = @WordCellKey
END













' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






-- Inserts a new record into the ''DDA_Disks'' table.
CREATE PROCEDURE [dbo].[_DDA_Disks_Insert]
	@DiskID nvarchar(50),
	@TestGrade varchar(4),
	@SlotNum smallint,
	@LotNo nvarchar(50),
	@CassetteID nvarchar(50),
	@StationKey int,
	@WordCellKey int,
	@FabKey smallint,
	@InnerDiameter	float,
	@OuterDiameter	float,
@L2_Top_Corr_cts int,
@L2_Bot_Corr_cts int,
@L2_Top_NCorr_cts int,
@L2_Bot_NCorr_cts int,
	@ProductKey int,
	@TestDiskDate DATETIME,
	@TesterTypeID smallint,
	@LotIDCode	varchar(10),
	@BinNo	varchar(4)
	
AS
	INSERT INTO [dbo].[DDA_Disks]
	(
		[DiskID],
		[TestGrade],
		[SlotNum],
		[LotNo],
		CassetteID,
		[StationKey],
		[WordCellKey],
		[FabKey],
		InnerDiameter,
		OuterDiameter,
L2_Top_Corr_cts ,
L2_Bot_Corr_cts ,
L2_Top_NCorr_cts ,
L2_Bot_NCorr_cts ,
	ProductKey,
	TestDiskDate,
	TesterTypeID,
	LotIDCode,
	BinNo
		
	)
	VALUES
	(
		@DiskID,
		@TestGrade,
		@SlotNum,
		@LotNo,
		@CassetteID,
		@StationKey,
		@WordCellKey,
		@FabKey,
		@InnerDiameter,
		@OuterDiameter,
@L2_Top_Corr_cts ,
@L2_Bot_Corr_cts ,
@L2_Top_NCorr_cts ,
@L2_Bot_NCorr_cts ,
@ProductKey,
@TestDiskDate,
@TesterTypeID,
@LotIDCode,
@BinNo
	)
	SELECT @@IDENTITY











' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disks_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Inserts a new record into the ''DDA_Disks'' table.
CREATE PROCEDURE [dbo].[DDA_Disks_Insert]
	@DiskID nvarchar(50),
	@TestGrade varchar(4),
	@SlotNum smallint,
	@LotNo nvarchar(50),
	@CassetteID nvarchar(50),
	@StationKey int,
	@WordCellKey int,
	@FabKey smallint,
	@InnerDiameter	float,
	@OuterDiameter	float,
	@L2_Top_Corr_cts int,
	@L2_Bot_Corr_cts int,
	@L2_Top_NCorr_cts int,
	@L2_Bot_NCorr_cts int,
	@ProductKey int,
	@TestDiskDate datetime,
	@TesterTypeID smallint,
	@LotIDCode varchar(10),
	@BinNo varchar(4),
	@DiskKey bigint output
AS
	INSERT INTO [dbo].[DDA_Disks]
	(
		[DiskID],
		[TestGrade],
		[SlotNum],
		[LotNo],
		CassetteID,
		[StationKey],
		[WordCellKey],
		[FabKey],
		InnerDiameter,
		OuterDiameter,
		L2_Top_Corr_cts ,
		L2_Bot_Corr_cts ,
		L2_Top_NCorr_cts ,
		L2_Bot_NCorr_cts ,
		ProductKey,
		TestDiskDate,
		TesterTypeID,
		LotIDCode,
		BinNo
	)
	VALUES
	(
		@DiskID,
		@TestGrade,
		@SlotNum,
		@LotNo,
		@CassetteID,
		@StationKey,
		@WordCellKey,
		@FabKey,
		@InnerDiameter,
		@OuterDiameter,
		@L2_Top_Corr_cts ,
		@L2_Bot_Corr_cts ,
		@L2_Top_NCorr_cts ,
		@L2_Bot_NCorr_cts ,
		@ProductKey,
		@TestDiskDate,
		@TesterTypeID,
		@LotIDCode,
		@BinNo
	)

	SET @DiskKey = @@IDENTITY
	SELECT @@IDENTITY















' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Disks_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Disks_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Updates a record in the ''DDA_Disks'' table.
CREATE PROCEDURE [dbo].[_DDA_Disks_Update]
	-- The rest of writeable parameters
	@DiskID nvarchar(50),
	@TestGrade varchar(4),
	@SlotNum smallint,
	@LotNo nvarchar(50),
	@CassetteID nvarchar(50),
	@StationKey int,
	@WordCellKey int,
	@FabKey smallint,
	@InnerDiameter float,
	@OuterDiameter float,
@L2_Top_Corr_cts int,
@L2_Bot_Corr_cts int,
@L2_Top_NCorr_cts int,
@L2_Bot_NCorr_cts int,
	@ProductKey int,
	@TestDiskDate DATETIME,
	@TesterTypeID smallint,
	@LotIDCode	varchar(10),
	@BinNo	varchar(4),
	-- Primary key parameters
	@DiskKey bigint
AS
	UPDATE [dbo].[DDA_Disks] SET
		[DiskID] = @DiskID,
		[TestGrade] = @TestGrade,
		[SlotNum] = @SlotNum,
		[LotNo] = @LotNo,
		CassetteID = @CassetteID,
		[StationKey] = @StationKey,
		[WordCellKey] = @WordCellKey,
		[FabKey] = @FabKey,
		InnerDiameter = @InnerDiameter,
		OuterDiameter = @OuterDiameter,

L2_Top_Corr_cts = @L2_Top_Corr_cts,
L2_Bot_Corr_cts = @L2_Bot_Corr_cts,
L2_Top_NCorr_cts = @L2_Top_NCorr_cts,
L2_Bot_NCorr_cts = @L2_Bot_NCorr_cts,
ProductKey= @ProductKey,
TestDiskDate = @TestDiskDate,
TesterTypeID = @TesterTypeID,
LotIDCode = @LotIDCode,
BinNo = @BinNo

	WHERE
		[DiskKey] = @DiskKey











' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disk_GetKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disk_GetKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DDA_Disk_GetKey]
	@FabKey	smallint,
	@DiskID	nvarchar(50),
	@DiskKey bigint output

AS
	SELECT TOP 1 @DiskKey = DiskKey FROM DDA_Disks WITH(NOLOCK)
	WHERE 
	FabKey	= @FabKey
	AND DiskID	= @DiskID
' 
END
GO
/****** Object:  Trigger [trInsertDisk]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[trInsertDisk]'))
EXEC dbo.sp_executesql @statement = N'
CREATE TRIGGER [dbo].[trInsertDisk] ON [dbo].[DDA_Disks]
   AFTER INSERT
	NOT FOR REPLICATION 
AS 
BEGIN
	SET NOCOUNT ON;

	IF (SELECT COUNT(DiskKey) FROM INSERTED)  > 1 RETURN 

    -- Insert statements for trigger here
	DECLARE @TesterTypeID smallint
	DECLARE @LotNo nvarchar(50)	
	DECLARE @SlotNum smallint	
	DECLARE @TestDiskDate datetime
	DECLARE @DiskCount smallint

	SELECT @TesterTypeID = TesterTypeID , @LotNo = LotNo, @SlotNum = SlotNum
	FROM INSERTED

	SELECT @TestDiskDate = MAX(TestDiskDate),@DiskCount = COUNT(DiskKey) FROM DDA_Disks
	WHERE @TesterTypeID = TesterTypeID AND @LotNo = LotNo AND @SlotNum = SlotNum

	IF ( @DiskCount <=1 ) RETURN

	UPDATE DDA_Disks 
	SET HasMeaning = 0
	WHERE @TesterTypeID = TesterTypeID AND @LotNo = LotNo AND @SlotNum = SlotNum

	UPDATE DDA_Disks 
	SET HasMeaning = 1
	WHERE @TesterTypeID = TesterTypeID AND @LotNo = LotNo AND @SlotNum = SlotNum AND @TestDiskDate = TestDiskDate
		
END
'
GO
/****** Object:  StoredProcedure [dbo].[DDA_Disks_Update_CassID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Disks_Update_CassID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DDA_Disks_Update_CassID] 
	-- Add the parameters for the stored procedure here
	@LotNo nvarchar(50),
	@SlotNum smallint,
	@WordCellKey int,
	@Cass_ID nvarchar(50)

AS
BEGIN
	update DDA_Disks
	set CassetteID = @Cass_ID
	where LotNo = @LotNo
	and SlotNum = @SlotNum
	and WordCellKey = @WordCellKey
END












' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_RecipeData'' table.
CREATE PROCEDURE [dbo].[_DDA_RecipeData_GetAll]
AS
	SELECT * FROM [dbo].[DDA_RecipeData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_RecipeData'' table.
CREATE PROCEDURE [dbo].[_DDA_RecipeData_Insert]
	@RecipeKey int,
	@RawData image
AS
	INSERT INTO [dbo].[DDA_RecipeData]
	(
		[RecipeKey],
		[RawData]
	)
	VALUES
	(
		@RecipeKey,
		@RawData
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_GetBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_GetBy_RecipeKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_RecipeData_GetBy_RecipeKey]
	@RecipeKey int
AS
	SELECT * FROM [dbo].[DDA_RecipeData] WHERE [RecipeKey] = @RecipeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Recipes_GetRawData]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Recipes_GetRawData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DDA_Recipes_GetRawData]
	-- Add the parameters for the stored procedure here
	@RecipeKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    -- Insert statements for procedure here
	SELECT RawData FROM DDA_RecipeData WHERE RecipeKey = @RecipeKey
END

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Inserts a new record into the ''DDA_RecipeData'' table.
CREATE PROCEDURE [dbo].[_DDA_RecipeData_Update]
	@RecipeKey int,
	@RawData image
AS
	UPDATE DDA_RecipeData 
	SET [RawData]= @RawData WHERE [RecipeKey]=@RecipeKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_RecipeData'' table.
CREATE PROCEDURE [dbo].[_DDA_RecipeData_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_RecipeData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_RecipeData_DeleteBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_RecipeData_DeleteBy_RecipeKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_RecipeData'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_RecipeData_DeleteBy_RecipeKey]
	@RecipeKey int
AS
	DELETE FROM [dbo].[DDA_RecipeData] WHERE [RecipeKey] = @RecipeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetBy_SurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Processed_GetBy_SurfaceKey]
	@SurfaceKey bigint
AS
	SELECT * FROM [dbo].[DDA_Processed] WHERE [SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteBy_RecipeKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Processed'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Processed_DeleteBy_RecipeKey]
	@RecipeKey int
AS
	DELETE FROM [dbo].[DDA_Processed] WHERE [RecipeKey] = @RecipeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Processed'' table.
CREATE PROCEDURE [dbo].[_DDA_Processed_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Processed]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Processed'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Processed_GetByPrimaryKey]
	@RecipeKey int,
	@SurfaceKey bigint
AS
	SELECT * FROM [dbo].[DDA_Processed] WHERE
		[RecipeKey] = @RecipeKey AND
		[SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- Inserts a new record into the ''DDA_Processed'' table.
CREATE PROCEDURE [dbo].[_DDA_Processed_Insert]
	@RecipeKey int,
	@SurfaceKey bigint,
	@BreakWhenFound bit,
	@Finish bit
AS
	INSERT INTO [dbo].[DDA_Processed]
	(
		[RecipeKey],
		[SurfaceKey],
		BreakWhenFound,
		Finish
	)
	VALUES
	(
		@RecipeKey,
		@SurfaceKey,
		@BreakWhenFound,
		@Finish
	)




' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Processed'' table.
CREATE PROCEDURE [dbo].[_DDA_Processed_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Processed]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteBy_SurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Processed'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Processed_DeleteBy_SurfaceKey]
	@SurfaceKey bigint
AS
	DELETE FROM [dbo].[DDA_Processed] WHERE [SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_GetBy_RecipeKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_GetBy_RecipeKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Processed_GetBy_RecipeKey]
	@RecipeKey int
AS
	SELECT * FROM [dbo].[DDA_Processed] WHERE [RecipeKey] = @RecipeKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Processed'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Processed_DeleteByPrimaryKey]
	@RecipeKey int,
	@SurfaceKey bigint
AS
	DELETE FROM [dbo].[DDA_Processed] WHERE
		[RecipeKey] = @RecipeKey AND
		[SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Processed_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Processed_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- Inserts a new record into the ''DDA_Processed'' table.
CREATE PROCEDURE [dbo].[_DDA_Processed_Update]
	@RecipeKey int,
	@SurfaceKey bigint,
	@BreakWhenFound bit,
	@Finish bit
AS
	UPDATE [dbo].[DDA_Processed]
	SET 
		BreakWhenFound = @BreakWhenFound,
		Finish = @Finish
	WHERE
		RecipeKey = @RecipeKey
		AND SurfaceKey= @SurfaceKey



' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_UpdateProcessingDuration]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_UpdateProcessingDuration]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DDA_Surfaces_UpdateProcessingDuration]
	@SurfaceKey bigint,
	@ProcessingDuration int
AS
BEGIN

	UPDATE DDA_Surfaces SET ProcessingDuration = 
		CASE 
			WHEN ProcessingDuration IS NULL THEN @ProcessingDuration
			ELSE ProcessingDuration + @ProcessingDuration
		END
	WHERE SurfaceKey = @SurfaceKey

	

	IF (EXISTS(SELECT SurfaceKey FROM DDA_Surfaces WHERE SurfaceKey = @SurfaceKey AND Processed=1 ) )
	BEGIN
		DECLARE @RN INT
		SELECT @RN = COUNT(RecipeKey) FROM DDA_Processed WHERE SurfaceKey = @SurfaceKey
		IF(@RN>0) UPDATE DDA_Surfaces SET ProcessingDuration = ProcessingDuration/@RN WHERE SurfaceKey = @SurfaceKey
	END

	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_GradeMapping_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_GradeMapping_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Inserts a new record into the ''DDA_Processed'' table.
CREATE PROCEDURE [dbo].[_DDA_GradeMapping_Insert]
	@GradeKey int,
	@SignatureKey int
AS

	IF(NOT EXISTS(SELECT  SignatureKey FROM DDA_GradeMapping WHERE GradeKey = @GradeKey AND SignatureKey=@SignatureKey ))
	BEGIN
		INSERT INTO [dbo].[DDA_GradeMapping]
		(
			GradeKey,
			SignatureKey
		)
		VALUES
		(
			@GradeKey,
			@SignatureKey
		)
	END




' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_GradeMapping_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_GradeMapping_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Processed'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_GradeMapping_DeleteByPrimaryKey]
	@GradeKey int,
	@SignatureKey int
AS
	DELETE FROM [dbo].[DDA_GradeMapping] WHERE
		GradeKey = @GradeKey AND
		SignatureKey = @SignatureKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ViolativeDisk'' table.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_Insert]
	@AlarmKey bigint,
	@DiskKey bigint,
	@CategoryIndex int,
	@SignatureKey int
AS
	INSERT INTO [dbo].[DDA_ViolativeDisk]
	(
		[AlarmKey],
		[DiskKey],
		[CategoryIndex],
		[SignatureKey]
	)
	VALUES
	(
		@AlarmKey,
		@DiskKey,
		@CategoryIndex,
		@SignatureKey
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ViolativeDisk'' table.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ViolativeDisk]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ViolativeDisk'' table.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ViolativeDisk]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetBy_DiskKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_GetBy_DiskKey]
	@DiskKey bigint
AS
	SELECT * FROM [dbo].[DDA_ViolativeDisk] WHERE [DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_ViolativeDisk'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteByPrimaryKey]
	@AlarmKey bigint,
	@DiskKey bigint
AS
	DELETE FROM [dbo].[DDA_ViolativeDisk] WHERE
		[AlarmKey] = @AlarmKey AND
		[DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_ViolativeDisk'' table.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_Update]
	-- The rest of writeable parameters
	@CategoryIndex int,
	@SignatureKey int,
	-- Primary key parameters
	@AlarmKey bigint,
	@DiskKey bigint
AS
	UPDATE [dbo].[DDA_ViolativeDisk] SET
		[CategoryIndex] = @CategoryIndex,
		[SignatureKey] = @SignatureKey
	WHERE
		[AlarmKey] = @AlarmKey AND
		[DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteBy_AlarmKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ViolativeDisk'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteBy_AlarmKey]
	@AlarmKey bigint
AS
	DELETE FROM [dbo].[DDA_ViolativeDisk] WHERE [AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_DeleteBy_DiskKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_DeleteBy_DiskKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ViolativeDisk'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_DeleteBy_DiskKey]
	@DiskKey bigint
AS
	DELETE FROM [dbo].[DDA_ViolativeDisk] WHERE [DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_ViolativeDisk'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_GetByPrimaryKey]
	@AlarmKey bigint,
	@DiskKey bigint
AS
	SELECT * FROM [dbo].[DDA_ViolativeDisk] WHERE
		[AlarmKey] = @AlarmKey AND
		[DiskKey] = @DiskKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ViolativeDisk_GetBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ViolativeDisk_GetBy_AlarmKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ViolativeDisk_GetBy_AlarmKey]
	@AlarmKey bigint
AS
	SELECT * FROM [dbo].[DDA_ViolativeDisk] WHERE [AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ControlRuleDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRuleDetail_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ControlRuleDetail]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_DeleteBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_DeleteBy_ControlRuleID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ControlRuleDetail'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ControlRuleDetail_DeleteBy_ControlRuleID]
	@ControlRuleID char(40)
AS
	DELETE FROM [dbo].[DDA_ControlRuleDetail] WHERE [ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_GetBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_GetBy_ControlRuleID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ControlRuleDetail_GetBy_ControlRuleID]
	@ControlRuleID char(40)
AS
	SELECT * FROM [dbo].[DDA_ControlRuleDetail] WHERE [ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ControlRuleDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRuleDetail_Insert]
	@ControlRuleID char(40),
	@ControlRuleBody image,
	@ControlRuleVersion char(8)
AS
	INSERT INTO [dbo].[DDA_ControlRuleDetail]
	(
		[ControlRuleID],
		[ControlRuleBody],
		[ControlRuleVersion]
	)
	VALUES
	(
		@ControlRuleID,
		@ControlRuleBody,
		@ControlRuleVersion
	)
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ControlRuleDetail_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ControlRuleDetail_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ControlRuleDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ControlRuleDetail_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ControlRuleDetail]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_AlarmEvent'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_Insert]
	@ControlRuleID char(40),
	@Severity tinyint,
	@AlarmTimeStamp datetime,
	@LastResultTimeStamp datetime,
	@GroupByData1 nvarchar(50),
	@GroupByData2 nvarchar(50),
	@GroupByDimension1 tinyint,
	@GroupByDimension2 tinyint
AS
	INSERT INTO [dbo].[DDA_AlarmEvent]
	(
		[ControlRuleID],
		[Severity],
		[AlarmTimeStamp],
		[LastResultTimeStamp],
		[GroupByData1],
		[GroupByData2],
		[GroupByDimension1],
		[GroupByDimension2]
	)
	VALUES
	(
		@ControlRuleID,
		@Severity,
		@AlarmTimeStamp,
		@LastResultTimeStamp,
		@GroupByData1,
		@GroupByData2,
		@GroupByDimension1,
		@GroupByDimension2
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_AlarmEvent'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_GetAll]
AS
	SELECT * FROM [dbo].[DDA_AlarmEvent]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_AlarmEvent'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_GetByPrimaryKey]
	@AlarmKey bigint
AS
	SELECT * FROM [dbo].[DDA_AlarmEvent] WHERE
		[AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_AlarmEvent'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_DeleteByPrimaryKey]
	@AlarmKey bigint
AS
	DELETE FROM [dbo].[DDA_AlarmEvent] WHERE
		[AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_GetBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_GetBy_ControlRuleID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_GetBy_ControlRuleID]
	@ControlRuleID char(40)
AS
	SELECT * FROM [dbo].[DDA_AlarmEvent] WHERE [ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_AlarmEvent'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_Update]
	-- The rest of writeable parameters
	@ControlRuleID char(40),
	@Severity tinyint,
	@AlarmTimeStamp datetime,
	@LastResultTimeStamp datetime,
	@GroupByData1 nvarchar(50),
	@GroupByData2 nvarchar(50),
	@GroupByDimension1 tinyint,
	@GroupByDimension2 tinyint,
	-- Primary key parameters
	@AlarmKey bigint
AS
	UPDATE [dbo].[DDA_AlarmEvent] SET
		[ControlRuleID] = @ControlRuleID,
		[Severity] = @Severity,
		[AlarmTimeStamp] = @AlarmTimeStamp,
		[LastResultTimeStamp] = @LastResultTimeStamp,
		[GroupByData1] = @GroupByData1,
		[GroupByData2] = @GroupByData2,
		[GroupByDimension1] = @GroupByDimension1,
		[GroupByDimension2] = @GroupByDimension2
	WHERE
		[AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_AlarmEvent'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_AlarmEvent]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmEvent_DeleteBy_ControlRuleID]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmEvent_DeleteBy_ControlRuleID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_AlarmEvent'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_AlarmEvent_DeleteBy_ControlRuleID]
	@ControlRuleID char(40)
AS
	DELETE FROM [dbo].[DDA_AlarmEvent] WHERE [ControlRuleID] = @ControlRuleID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_DeleteNoSignature]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_DeleteNoSignature]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[DDA_Surfaces_DeleteNoSignature]
@SurfaceKey bigint,
@ProcessingDuration int
AS
BEGIN
	-- Check HasSignature 
	IF( EXISTS(SELECT dbo.DDA_Results.ResultKey
	FROM dbo.DDA_Results INNER JOIN
						  dbo.DDA_ResultDetail ON dbo.DDA_Results.ResultKey = dbo.DDA_ResultDetail.ResultKey
	WHERE dbo.DDA_ResultDetail.SurfaceKey = @SurfaceKey 
		 AND dbo.DDA_Results.SignatureKey <> 2 AND dbo.DDA_Results.SignatureKey <> 3)) --''No-Signature'', ''Empty''
	BEGIN
		-- Copy ProcessingDuration from 2,3 to this ?
		--...

		-- Auto Remove ''No-Signature'', ''Empty''
		DELETE FROM dbo.DDA_Results
			FROM dbo.DDA_Results as result 
			INNER JOIN dbo.DDA_ResultDetail ON result.ResultKey = dbo.DDA_ResultDetail.ResultKey
			WHERE dbo.DDA_ResultDetail.SurfaceKey = @SurfaceKey 
			 AND (result.SignatureKey = 2 OR result.SignatureKey = 3)
	END
	ELSE
	BEGIN
		-- Update ProcessingDuration for DDA_Results
		DECLARE @MyProcessingDuration int
		DECLARE @ResultKey bigint

		SELECT TOP 1 @MyProcessingDuration = ProcessingDuration , @ResultKey = DDA_Results.ResultKey
		FROM DDA_Results INNER JOIN DDA_ResultDetail ON DDA_Results.ResultKey = DDA_ResultDetail.ResultKey
		WHERE SurfaceKey = @SurfaceKey AND (SignatureKey = 2 OR SignatureKey = 3)

		IF(@ResultKey IS NOT NULL AND (@MyProcessingDuration IS NULL OR @MyProcessingDuration < @ProcessingDuration) )
		BEGIN
			UPDATE DDA_Results SET ProcessingDuration= @ProcessingDuration WHERE ResultKey = @ResultKey
		END
	END

END




' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_RESULT_DETAIL]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_RESULT_DETAIL]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[GET_RESULT_DETAIL]
	@RECIPEKEY INT,
	@SurfaceKey  BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		 DDA_ResultDetailData.*
	FROM         DDA_ResultDetailData 
		INNER JOIN DDA_ResultDetail ON DDA_ResultDetailData.ResultDetailKey = DDA_ResultDetail.ResultDetailKey
		INNER JOIN DDA_Results ON DDA_ResultDetail.ResultKey = DDA_Results.ResultKey
		WHERE     (DDA_Results.RecipeKey = @RECIPEKEY) AND (DDA_ResultDetail.SurfaceKey = @SurfaceKey)

END



' 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_RESULT_DETAIL_RAWDATA]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_RESULT_DETAIL_RAWDATA]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[GET_RESULT_DETAIL_RAWDATA]
	@RECIPEKEY INT,
	@SurfaceKey  BIGINT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		 DDA_ResultDetailData.RAWDATA, DDA_ResultDetailData.NoCompress
	FROM         DDA_ResultDetailData 
		INNER JOIN DDA_ResultDetail ON DDA_ResultDetailData.ResultDetailKey = DDA_ResultDetail.ResultDetailKey
		INNER JOIN DDA_Results ON DDA_ResultDetail.ResultKey = DDA_Results.ResultKey
		WHERE     (DDA_Results.RecipeKey = @RECIPEKEY) AND (DDA_ResultDetail.SurfaceKey = @SurfaceKey)

END





' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Surfaces_HasSignature]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces_HasSignature]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[DDA_Surfaces_HasSignature]
@SurfaceKey bigint
AS
BEGIN
	--- Check HasSignature include No-Signature and Empty Signature
	IF( EXISTS (SELECT dbo.DDA_Results.ResultKey
		FROM dbo.DDA_Results INNER JOIN
		dbo.DDA_ResultDetail ON dbo.DDA_Results.ResultKey = dbo.DDA_ResultDetail.ResultKey
		WHERE dbo.DDA_ResultDetail.SurfaceKey = @SurfaceKey ))	SELECT 1
	ELSE SELECT 0
END





' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_DeleteBy_SignatureKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_DeleteBy_SignatureKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_Results'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_Results_DeleteBy_SignatureKey]
	@SignatureKey int
AS
	DELETE FROM [dbo].[DDA_Results] WHERE [SignatureKey] = @SignatureKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Results'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Results_DeleteByPrimaryKey]
	@ResultKey bigint
AS
	DELETE FROM [dbo].[DDA_Results] WHERE
		[ResultKey] = @ResultKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Results'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Results_GetByPrimaryKey]
	@ResultKey bigint
AS
	SELECT * FROM [dbo].[DDA_Results] WHERE
		[ResultKey] = @ResultKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_GetBy_SignatureKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_GetBy_SignatureKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_Results_GetBy_SignatureKey]
	@SignatureKey int
AS
	SELECT * FROM [dbo].[DDA_Results] WHERE [SignatureKey] = @SignatureKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Results'' table.
CREATE PROCEDURE [dbo].[_DDA_Results_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Results]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Inserts a new record into the ''DDA_Results'' table.
CREATE PROCEDURE [dbo].[_DDA_Results_Insert]
	@ResultKey bigint,
	@SignatureKey int,
	@IsMultiLayer bit,
	@AnalyzeTime datetime,
	@NumberOfDefect int,
	@PercentOfDefect float,
	@RecipeKey int,
	@ProcessingDuration int
AS
	INSERT INTO [dbo].[DDA_Results]
	(
		[ResultKey],
		[SignatureKey],
		[IsMultiLayer],
		[AnalyzeTime],
		[NumberOfDefect],
		[PercentOfDefect],
		RecipeKey,
		ProcessingDuration
	)
	VALUES
	(
		@ResultKey,
		@SignatureKey,
		@IsMultiLayer,
		@AnalyzeTime,
		@NumberOfDefect,
		@PercentOfDefect,
		@RecipeKey,
		@ProcessingDuration
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Results'' table.
CREATE PROCEDURE [dbo].[_DDA_Results_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Results]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_Results_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Results_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Inserts a new record into the ''DDA_Results'' table.
CREATE PROCEDURE [dbo].[DDA_Results_Insert]
	@SignatureKey int,
	@IsMultiLayer bit,
	@AnalyzeTime datetime,
	@NumberOfDefect int,
	@PercentOfDefect float,
	@RecipeKey int,
	@ProcessingDuration int,
	@ResultKey bigint output
AS
	INSERT INTO [dbo].[DDA_Results]
	(
		[SignatureKey],
		[IsMultiLayer],
		[AnalyzeTime],
		[NumberOfDefect],
		[PercentOfDefect],
		RecipeKey,
		ProcessingDuration 
	)
	VALUES
	(
		@SignatureKey,
		@IsMultiLayer,
		@AnalyzeTime,
		@NumberOfDefect,
		@PercentOfDefect,
		@RecipeKey,
		@ProcessingDuration
	)
	SELECT @ResultKey= @@IDENTITY


' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Results_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Results_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Updates a record in the ''DDA_Results'' table.
CREATE PROCEDURE [dbo].[_DDA_Results_Update]
	-- The rest of writeable parameters
	@SignatureKey int,
	@IsMultiLayer bit,
	@AnalyzeTime datetime,
	@NumberOfDefect int,
	@PercentOfDefect float,
	@RecipeKey int,
	-- Primary key parameters
	@ResultKey bigint
AS
	UPDATE [dbo].[DDA_Results] SET
		[SignatureKey] = @SignatureKey,
		[IsMultiLayer] = @IsMultiLayer,
		[AnalyzeTime] = @AnalyzeTime,
		[NumberOfDefect] = @NumberOfDefect,
		[PercentOfDefect] = @PercentOfDefect,
		RecipeKey = @RecipeKey
	WHERE
		[ResultKey] = @ResultKey

' 
END
GO
/****** Object:  StoredProcedure [dbo].[DDA_ResultDetail_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Inserts a new record into the ''DDA_ResultDetail'' table.
CREATE PROCEDURE [dbo].[DDA_ResultDetail_Insert]
	@ResultKey bigint,
	@SurfaceKey bigint,
	@NumberOfDefect int,
	@PercentOfDefect float,
	@ResultDetailKey bigint output
AS
	INSERT INTO [dbo].[DDA_ResultDetail]
	(
		[ResultKey],
		[SurfaceKey],
		[NumberOfDefect],
		[PercentOfDefect]
	)
	VALUES
	(
		@ResultKey,
		@SurfaceKey,
		@NumberOfDefect,
		@PercentOfDefect
	)
	SELECT @ResultDetailKey = @@IDENTITY

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_ResultDetail'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_GetByPrimaryKey]
	@ResultDetailKey bigint
AS
	SELECT * FROM [dbo].[DDA_ResultDetail] WHERE
		[ResultDetailKey] = @ResultDetailKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_ResultDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_Insert]
	@ResultKey bigint,
	@SurfaceKey bigint,
	@NumberOfDefect int,
	@PercentOfDefect float
AS
	INSERT INTO [dbo].[DDA_ResultDetail]
	(
		[ResultKey],
		[SurfaceKey],
		[NumberOfDefect],
		[PercentOfDefect]
	)
	VALUES
	(
		@ResultKey,
		@SurfaceKey,
		@NumberOfDefect,
		@PercentOfDefect
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_ResultDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_Update]
	-- The rest of writeable parameters
	@ResultKey bigint,
	@SurfaceKey bigint,
	@NumberOfDefect int,
	@PercentOfDefect float,
	-- Primary key parameters
	@ResultDetailKey bigint
AS
	UPDATE [dbo].[DDA_ResultDetail] SET
		[ResultKey] = @ResultKey,
		[SurfaceKey] = @SurfaceKey,
		[NumberOfDefect] = @NumberOfDefect,
		[PercentOfDefect] = @PercentOfDefect
	WHERE
		[ResultDetailKey] = @ResultDetailKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetBy_SurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_GetBy_SurfaceKey]
	@SurfaceKey bigint
AS
	SELECT * FROM [dbo].[DDA_ResultDetail] WHERE [SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetBy_ResultKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_GetBy_ResultKey]
	@ResultKey bigint
AS
	SELECT * FROM [dbo].[DDA_ResultDetail] WHERE [ResultKey] = @ResultKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteBy_SurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ResultDetail'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_DeleteBy_SurfaceKey]
	@SurfaceKey bigint
AS
	DELETE FROM [dbo].[DDA_ResultDetail] WHERE [SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_ResultDetail'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_DeleteByPrimaryKey]
	@ResultDetailKey bigint
AS
	DELETE FROM [dbo].[DDA_ResultDetail] WHERE
		[ResultDetailKey] = @ResultDetailKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteBy_ResultKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ResultDetail'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_DeleteBy_ResultKey]
	@ResultKey bigint
AS
	DELETE FROM [dbo].[DDA_ResultDetail] WHERE [ResultKey] = @ResultKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ResultDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ResultDetail]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetail_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetail_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ResultDetail'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetail_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ResultDetail]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceRawData]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceRawData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetSourceRawData]
	-- Add the parameters for the stored procedure here
	@SurfaceKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [RawData] FROM [dbo].[DDA_SurfaceData] WHERE [SurfaceKey] = @SurfaceKey
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceThumbnail]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceThumbnail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetSourceThumbnail]
	-- Add the parameters for the stored procedure here
	@SurfaceKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [SourceThumbnail] FROM [dbo].[DDA_SurfaceData] WHERE [SurfaceKey] = @SurfaceKey
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_DeleteBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_DeleteBy_SurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_SurfaceData'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_SurfaceData_DeleteBy_SurfaceKey]
	@SurfaceKey bigint
AS
	DELETE FROM [dbo].[DDA_SurfaceData] WHERE [SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_GetBy_SurfaceKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_GetBy_SurfaceKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_SurfaceData_GetBy_SurfaceKey]
	@SurfaceKey bigint
AS
	SELECT * FROM [dbo].[DDA_SurfaceData] WHERE [SurfaceKey] = @SurfaceKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_SurfaceData'' table.
CREATE PROCEDURE [dbo].[_DDA_SurfaceData_GetAll]
AS
	SELECT * FROM [dbo].[DDA_SurfaceData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Inserts a new record into the ''DDA_SurfaceData'' table.
CREATE PROCEDURE [dbo].[_DDA_SurfaceData_Insert]
	@SurfaceKey bigint,
	@RawData image,
	@SourceThumbnail image,
	@SourceThumbnailFlat image,
	@NoCompress bit
AS
	INSERT INTO [dbo].[DDA_SurfaceData]
	(
		[SurfaceKey],
		[RawData],
		[SourceThumbnail],
		[SourceThumbnailFlat],
NoCompress
	)
	VALUES
	(
		@SurfaceKey,
		@RawData,
		@SourceThumbnail,
		@SourceThumbnailFlat,
@NoCompress
	)

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetSourceThumbnailFlat]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetSourceThumbnailFlat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetSourceThumbnailFlat]
	-- Add the parameters for the stored procedure here
	@SurfaceKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [SourceThumbnailFlat] FROM [dbo].[DDA_SurfaceData] WHERE [SurfaceKey] = @SurfaceKey
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_SurfaceData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_SurfaceData_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_SurfaceData'' table.
CREATE PROCEDURE [dbo].[_DDA_SurfaceData_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_SurfaceData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Grades_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Grades_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- Inserts a new record into the ''DDA_Stations'' table.
CREATE PROCEDURE [dbo].[_DDA_Grades_Update]
	@Grade int,
	@GradeDescription nvarchar(255),
	@GradeKey int
AS
	UPDATE [dbo].[DDA_Grades]
	SET
	
		Grade = @Grade,
		GradeDescription = @GradeDescription
	
	WHERE
		GradeKey = @GradeKey


' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Grades_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Grades_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- Inserts a new record into the ''DDA_Stations'' table.
CREATE PROCEDURE [dbo].[_DDA_Grades_Insert]
	@Grade int,
	@GradeDescription nvarchar(255)
AS
	INSERT INTO [dbo].[DDA_Grades]
	(
		Grade,
		GradeDescription
	)
	VALUES
	(
		@Grade,
		@GradeDescription
	)
	SELECT @@IDENTITY



' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_GetBy_ResultDetailKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_GetBy_ResultDetailKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultDetailData_GetBy_ResultDetailKey]
	@ResultDetailKey bigint
AS
	SELECT * FROM [dbo].[DDA_ResultDetailData] WHERE [ResultDetailKey] = @ResultDetailKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_DeleteBy_ResultDetailKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_DeleteBy_ResultDetailKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ResultDetailData'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultDetailData_DeleteBy_ResultDetailKey]
	@ResultDetailKey bigint
AS
	DELETE FROM [dbo].[DDA_ResultDetailData] WHERE [ResultDetailKey] = @ResultDetailKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ResultDetailData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetailData_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ResultDetailData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetResultThumbnailFlat]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultThumbnailFlat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetResultThumbnailFlat]
	-- Add the parameters for the stored procedure here
	@ResultDetailKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [SourceThumbnailFlat] FROM [dbo].[DDA_ResultDetailData] WHERE [ResultDetailKey] = @ResultDetailKey
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetResultThumbnail]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultThumbnail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetResultThumbnail]
	-- Add the parameters for the stored procedure here
	@ResultDetailKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [SourceThumbnail] FROM [dbo].[DDA_ResultDetailData] WHERE [ResultDetailKey] = @ResultDetailKey
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ResultDetailData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetailData_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ResultDetailData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultDetailData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultDetailData_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- Inserts a new record into the ''DDA_ResultDetailData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultDetailData_Insert]
	@ResultDetailKey bigint,
	@RawData image,
	@SourceThumbnail image,
	@SourceThumbnailFlat image,
	@NoCompress bit = 0
AS
	INSERT INTO [dbo].[DDA_ResultDetailData]
	(
		[ResultDetailKey],
		[RawData],
		[SourceThumbnail],
		[SourceThumbnailFlat],
		NoCompress
	)
	VALUES
	(
		@ResultDetailKey,
		@RawData,
		@SourceThumbnail,
		@SourceThumbnailFlat,
		@NoCompress
	)



' 
END
GO
/****** Object:  StoredProcedure [dbo].[_GetResultRawData]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_GetResultRawData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[_GetResultRawData]
	-- Add the parameters for the stored procedure here
	@ResultDetailKey bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [RawData] FROM [dbo].[DDA_ResultDetailData] WHERE [ResultDetailKey] = @ResultDetailKey
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_GetBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_GetBy_ResultKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultData_GetBy_ResultKey]
	@ResultKey bigint
AS
	SELECT * FROM [dbo].[DDA_ResultData] WHERE [ResultKey] = @ResultKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- Updates a record in the ''DDA_ResultData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultData_Update]
	-- The rest of writeable parameters
	@ResultThumbnail image,
	@ResultImage image,
	@ResultThumbnailFlat image,
	@ResultImageFlat image,
	@RawData image,
	@NoCompress bit,
	-- Primary key parameters
	@ResultKey bigint
AS
	UPDATE [dbo].[DDA_ResultData] SET
		[ResultThumbnail] = @ResultThumbnail,
		[ResultImage] = @ResultImage,
		[ResultThumbnailFlat] = @ResultThumbnailFlat,
		[ResultImageFlat] = @ResultImageFlat,
		[RawData] = @RawData,
		NoCompress = @NoCompress
	WHERE
		ResultKey = @ResultKey


' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_ResultData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultData_GetAll]
AS
	SELECT * FROM [dbo].[DDA_ResultData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_DeleteBy_ResultKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_DeleteBy_ResultKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_ResultData'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_ResultData_DeleteBy_ResultKey]
	@ResultKey bigint
AS
	DELETE FROM [dbo].[DDA_ResultData] WHERE [ResultKey] = @ResultKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- Inserts a new record into the ''DDA_ResultData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultData_Insert]
	@ResultKey bigint,
	@ResultThumbnail image,
	@ResultImage image,
	@ResultThumbnailFlat image,
	@ResultImageFlat image,
	@RawData image,
	@NoCompress bit
AS
	INSERT INTO [dbo].[DDA_ResultData]
	(
		[ResultKey],
		[ResultThumbnail],
		[ResultImage],
		[ResultThumbnailFlat],
		[ResultImageFlat],
		[RawData],
		NoCompress
	)
	VALUES
	(
		@ResultKey,
		@ResultThumbnail,
		@ResultImage,
		@ResultThumbnailFlat,
		@ResultImageFlat,
		@RawData,
		@NoCompress
	)
	SELECT @@IDENTITY

' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_ResultData_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_ResultData_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_ResultData'' table.
CREATE PROCEDURE [dbo].[_DDA_ResultData_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_ResultData]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_DeleteBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_DeleteBy_AlarmKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Delete records from the ''DDA_AlarmChart'' table using a foreign key.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_DeleteBy_AlarmKey]
	@AlarmKey bigint
AS
	DELETE FROM [dbo].[DDA_AlarmChart] WHERE [AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_AlarmChart'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_AlarmChart]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_AlarmChart'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_Insert]
	@AlarmKey bigint,
	@ChartSnapshot image,
	@ChartSnapshotVersion char(8)
AS
	INSERT INTO [dbo].[DDA_AlarmChart]
	(
		[AlarmKey],
		[ChartSnapshot],
		[ChartSnapshotVersion]
	)
	VALUES
	(
		@AlarmKey,
		@ChartSnapshot,
		@ChartSnapshotVersion
	)
	SELECT @@IDENTITY
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_AlarmChart'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_GetByPrimaryKey]
	@AlarmChartKey bigint
AS
	SELECT * FROM [dbo].[DDA_AlarmChart] WHERE
		[AlarmChartKey] = @AlarmChartKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_AlarmChart'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_GetAll]
AS
	SELECT * FROM [dbo].[DDA_AlarmChart]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_AlarmChart'' table.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_Update]
	-- The rest of writeable parameters
	@AlarmKey bigint,
	@ChartSnapshot image,
	@ChartSnapshotVersion char(8),
	-- Primary key parameters
	@AlarmChartKey bigint
AS
	UPDATE [dbo].[DDA_AlarmChart] SET
		[AlarmKey] = @AlarmKey,
		[ChartSnapshot] = @ChartSnapshot,
		[ChartSnapshotVersion] = @ChartSnapshotVersion
	WHERE
		[AlarmChartKey] = @AlarmChartKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_AlarmChart'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_DeleteByPrimaryKey]
	@AlarmChartKey bigint
AS
	DELETE FROM [dbo].[DDA_AlarmChart] WHERE
		[AlarmChartKey] = @AlarmChartKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_AlarmChart_GetBy_AlarmKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_AlarmChart_GetBy_AlarmKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records for the specified foreign key.
CREATE PROCEDURE [dbo].[_DDA_AlarmChart_GetBy_AlarmKey]
	@AlarmKey bigint
AS
	SELECT * FROM [dbo].[DDA_AlarmChart] WHERE [AlarmKey] = @AlarmKey
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_GetAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_GetAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets all records from the ''DDA_Channels'' table.
CREATE PROCEDURE [dbo].[_DDA_Channels_GetAll]
AS
	SELECT * FROM [dbo].[DDA_Channels]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_GetByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_GetByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Gets a record from the ''DDA_Channels'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Channels_GetByPrimaryKey]
	@ChannelID int
AS
	SELECT * FROM [dbo].[DDA_Channels] WHERE
		[ChannelID] = @ChannelID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_DeleteAll]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_DeleteAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes all records from the ''DDA_Channels'' table.
CREATE PROCEDURE [dbo].[_DDA_Channels_DeleteAll]
AS
	DELETE FROM [dbo].[DDA_Channels]
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Updates a record in the ''DDA_Channels'' table.
CREATE PROCEDURE [dbo].[_DDA_Channels_Update]
	-- The rest of writeable parameters
	@ChannelName nvarchar(50),
	-- Primary key parameters
	@ChannelID int
AS
	UPDATE [dbo].[DDA_Channels] SET
		[ChannelName] = @ChannelName
	WHERE
		[ChannelID] = @ChannelID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_DeleteByPrimaryKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_DeleteByPrimaryKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Deletes a record from the ''DDA_Channels'' table using the primary key value.
CREATE PROCEDURE [dbo].[_DDA_Channels_DeleteByPrimaryKey]
	@ChannelID int
AS
	DELETE FROM [dbo].[DDA_Channels] WHERE
		[ChannelID] = @ChannelID
' 
END
GO
/****** Object:  StoredProcedure [dbo].[_DDA_Channels_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[_DDA_Channels_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- Inserts a new record into the ''DDA_Channels'' table.
CREATE PROCEDURE [dbo].[_DDA_Channels_Insert]
	@ChannelID int,
	@ChannelName nvarchar(50)
AS
	INSERT INTO [dbo].[DDA_Channels]
	(
		[ChannelID],
		[ChannelName]
	)
	VALUES
	(
		@ChannelID,
		@ChannelName
	)
' 
END
GO
/****** Object:  Trigger [WD_Products_After_Insert]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[WD_Products_After_Insert]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Cang
-- Create date: 2008-10-29
-- Description:	Create Trigger for insert,update to update Product from WD to DDADB
-- =============================================
CREATE TRIGGER [dbo].[WD_Products_After_Insert]
   ON  [dbo].[WD_Products] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	-- Insert new product
	INSERT INTO DDA_Products(ProductCode,Prod_Class)
	SELECT Prod_Code,Prod_Class FROM inserted
	WHERE Prod_Code NOT IN(SELECT ProductCode FROM DDA_Products)

	-- Update product class of product code
	UPDATE DDA_Products SET DDA_Products.Prod_Class=inserted.Prod_Class FROM inserted
	WHERE DDA_Products.ProductCode = inserted.Prod_Code AND DDA_Products.Prod_Class<>inserted.Prod_Class
END
'
GO
/****** Object:  Trigger [DDA_Processed_Insert_Update]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[DDA_Processed_Insert_Update]'))
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Cang
-- Create date: 2008-12-26
-- Description:	Create Trigger for insert/update processed
-- =============================================
CREATE TRIGGER [dbo].[DDA_Processed_Insert_Update]
   ON  [dbo].[DDA_Processed] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @SurfaceKey BIGINT
	DECLARE @BreakWhenFound bit

	SELECT TOP 1 @SurfaceKey = SurfaceKey,@BreakWhenFound = BreakWhenFound FROM inserted WHERE Finish=1

	IF(@SurfaceKey IS NOT NULL) 
	BEGIN
		IF (@BreakWhenFound=1) UPDATE DDA_Surfaces SET Processed=1 WHERE SurfaceKey = @SurfaceKey
		ELSE EXEC DDA_Processed_UpdateProcessedSurface @SurfaceKey 
	END
END


'
GO
/****** Object:  StoredProcedure [dbo].[UpdateProcessedByKey]    Script Date: 06/14/2010 16:20:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateProcessedByKey]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateProcessedByKey]
	@SurfaceKey bigint,
	@RecipeKey int,
	@status bit
AS	
BEGIN

	--Get bit position from recipekey
	DECLARE @bit int
	set @bit = -1;
	EXEC GetRecipeOrderByKey @RecipeKey, @bit output
	IF(@bit=-1) RETURN @bit

	--find ProcessedBitArray position
	declare @i int
	set @i = 1
	while(@bit / (@i*32) >0 )
	BEGIN
		set @i=@i+1
	END

	--create mask to apply
	declare @bitorder int
	declare @mask int
	set @bitorder = (@bit % (@i*32)) - 1 
	set @mask = 1
	set @mask = dbo.fShiftBit(@mask,@bitorder);
	set @i = @i - 1

	DECLARE @SQL NVARCHAR(1024)
	SET @SQL = ''ProcessedBitArray'' + cast(@i as varchar)
	
	IF(@status > 0)
	BEGIN
		SET @SQL = ''UPDATE DDA_SURFACES SET '' + @SQL + '' = '' + @SQL + ''|'' + cast(@mask as varchar) + '' WHERE SurfaceKey = '' + cast(@SurfaceKey as varchar)
	END
	ELSE
	BEGIN
		SET @mask = ~@mask
		SET @SQL = ''UPDATE DDA_SURFACES SET '' + @SQL + '' = '' + @SQL + ''&'' + cast(@mask as varchar) + '' WHERE SurfaceKey = '' + cast(@SurfaceKey as varchar)
	END
	
	PRINT @SQL

	EXECUTE sp_executesql @SQL
END

--select * from dda_surfaces
--UpdateProcessedByKey 105,10,0' 
END
GO
/****** Object:  Default [DF_DDA_AlarmChart_ChartSnapshotVersion]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmChart_ChartSnapshotVersion]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmChart]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmChart] ADD  CONSTRAINT [DF_DDA_AlarmChart_ChartSnapshotVersion]  DEFAULT ('01.00.00') FOR [ChartSnapshotVersion]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDataLevel1]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDataLevel1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] ADD  CONSTRAINT [DF_DDA_AlarmEvent_GroupByDataLevel1]  DEFAULT (N'None') FOR [GroupByData1]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDataLevel2]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDataLevel2]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] ADD  CONSTRAINT [DF_DDA_AlarmEvent_GroupByDataLevel2]  DEFAULT (N'None') FOR [GroupByData2]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDimensionID1]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDimensionID1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] ADD  CONSTRAINT [DF_DDA_AlarmEvent_GroupByDimensionID1]  DEFAULT ((0)) FOR [GroupByDimension1]

End
GO
/****** Object:  Default [DF_DDA_AlarmEvent_GroupByDimensionID2]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_AlarmEvent_GroupByDimensionID2]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
Begin
ALTER TABLE [dbo].[DDA_AlarmEvent] ADD  CONSTRAINT [DF_DDA_AlarmEvent_GroupByDimensionID2]  DEFAULT ((0)) FOR [GroupByDimension2]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_Title]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_Title]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] ADD  CONSTRAINT [DF_DDA_ControlRule_Title]  DEFAULT (N'Unknown') FOR [Title]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_SubCategory]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_SubCategory]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] ADD  CONSTRAINT [DF_DDA_ControlRule_SubCategory]  DEFAULT (N'Unknown') FOR [SubCategory]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_Category]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] ADD  CONSTRAINT [DF_DDA_ControlRule_Category]  DEFAULT (N'Unknown') FOR [Category]

End
GO
/****** Object:  Default [DF_DDA_ControlRule_Description]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ControlRule_Description]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRule]'))
Begin
ALTER TABLE [dbo].[DDA_ControlRule] ADD  CONSTRAINT [DF_DDA_ControlRule_Description]  DEFAULT (N'Unknown') FOR [Description]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Top_Corr_cts]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Top_Corr_cts]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] ADD  CONSTRAINT [DF_DDA_Disks_L2_Top_Corr_cts]  DEFAULT ((0)) FOR [L2_Top_Corr_cts]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Bot_Corr_cts1]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Bot_Corr_cts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] ADD  CONSTRAINT [DF_DDA_Disks_L2_Bot_Corr_cts1]  DEFAULT ((0)) FOR [L2_Bot_Corr_cts]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Top_NCorr_cts1]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Top_NCorr_cts1]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] ADD  CONSTRAINT [DF_DDA_Disks_L2_Top_NCorr_cts1]  DEFAULT ((0)) FOR [L2_Top_NCorr_cts]

End
GO
/****** Object:  Default [DF_DDA_Disks_L2_Bot_NCorr_cts11]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_L2_Bot_NCorr_cts11]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] ADD  CONSTRAINT [DF_DDA_Disks_L2_Bot_NCorr_cts11]  DEFAULT ((0)) FOR [L2_Bot_NCorr_cts]

End
GO
/****** Object:  Default [DF_DDA_Disks_Deleted]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] ADD  CONSTRAINT [DF_DDA_Disks_Deleted]  DEFAULT ((0)) FOR [Deleted]

End
GO
/****** Object:  Default [DF_DDA_Disks_HasMeaning]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Disks_HasMeaning]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
Begin
ALTER TABLE [dbo].[DDA_Disks] ADD  CONSTRAINT [DF_DDA_Disks_HasMeaning]  DEFAULT ((1)) FOR [HasMeaning]

End
GO
/****** Object:  Default [DF_DDA_Processed_BreakWhenFound]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Processed_BreakWhenFound]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
Begin
ALTER TABLE [dbo].[DDA_Processed] ADD  CONSTRAINT [DF_DDA_Processed_BreakWhenFound]  DEFAULT ((0)) FOR [BreakWhenFound]

End
GO
/****** Object:  Default [DF_DDA_Processed_Finish]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Processed_Finish]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
Begin
ALTER TABLE [dbo].[DDA_Processed] ADD  CONSTRAINT [DF_DDA_Processed_Finish]  DEFAULT ((0)) FOR [Finish]

End
GO
/****** Object:  Default [DF_DDA_Recipes_BreakWhenFound]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Recipes_BreakWhenFound]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Recipes]'))
Begin
ALTER TABLE [dbo].[DDA_Recipes] ADD  CONSTRAINT [DF_DDA_Recipes_BreakWhenFound]  DEFAULT ((0)) FOR [BreakWhenFound]

End
GO
/****** Object:  Default [DF__DDA_Resul__NoCom__6D9742D9]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Resul__NoCom__6D9742D9]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultData]'))
Begin
ALTER TABLE [dbo].[DDA_ResultData] ADD  CONSTRAINT [DF__DDA_Resul__NoCom__6D9742D9]  DEFAULT ((0)) FOR [NoCompress]

End
GO
/****** Object:  Default [DF__DDA_Resul__NoCom__72C60C4A]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Resul__NoCom__72C60C4A]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]'))
Begin
ALTER TABLE [dbo].[DDA_ResultDetailData] ADD  CONSTRAINT [DF__DDA_Resul__NoCom__72C60C4A]  DEFAULT ((0)) FOR [NoCompress]

End
GO
/****** Object:  Default [DF_DDA_Results_ProcessingDuration]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Results_ProcessingDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Results]'))
Begin
ALTER TABLE [dbo].[DDA_Results] ADD  CONSTRAINT [DF_DDA_Results_ProcessingDuration]  DEFAULT ((0)) FOR [ProcessingDuration]

End
GO
/****** Object:  Default [DF__DDA_Surfa__NoCom__70DDC3D8]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Surfa__NoCom__70DDC3D8]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]'))
Begin
ALTER TABLE [dbo].[DDA_SurfaceData] ADD  CONSTRAINT [DF__DDA_Surfa__NoCom__70DDC3D8]  DEFAULT ((0)) FOR [NoCompress]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_HasSignature]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_HasSignature]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] ADD  CONSTRAINT [DF_DDA_Surfaces_HasSignature]  DEFAULT ((0)) FOR [HasSignature]

End
GO
/****** Object:  Default [DF__DDA_Surfa__IsDef__619B8048]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF__DDA_Surfa__IsDef__619B8048]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] ADD  CONSTRAINT [DF__DDA_Surfa__IsDef__619B8048]  DEFAULT ((0)) FOR [IsDefectList]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_Processed]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_Processed]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] ADD  CONSTRAINT [DF_DDA_Surfaces_Processed]  DEFAULT ((0)) FOR [Processed]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_Deleted]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_Deleted]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] ADD  CONSTRAINT [DF_DDA_Surfaces_Deleted]  DEFAULT ((0)) FOR [Deleted]

End
GO
/****** Object:  Default [DF_DDA_Surfaces_ProcessingDuration]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_Surfaces_ProcessingDuration]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
Begin
ALTER TABLE [dbo].[DDA_Surfaces] ADD  CONSTRAINT [DF_DDA_Surfaces_ProcessingDuration]  DEFAULT ((0)) FOR [ProcessingDuration]

End
GO
/****** Object:  Default [DF_DDA_SysInfo_DBType]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_SysInfo_DBType]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_SysInfo]'))
Begin
ALTER TABLE [dbo].[DDA_SysInfo] ADD  CONSTRAINT [DF_DDA_SysInfo_DBType]  DEFAULT ((0)) FOR [DBType]

End
GO
/****** Object:  Default [DF_DDA_ViolativeDisk_SignatureKey]    Script Date: 06/14/2010 16:20:25 ******/
IF Not EXISTS (SELECT * FROM sys.default_constraints WHERE object_id = OBJECT_ID(N'[dbo].[DF_DDA_ViolativeDisk_SignatureKey]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]'))
Begin
ALTER TABLE [dbo].[DDA_ViolativeDisk] ADD  CONSTRAINT [DF_DDA_ViolativeDisk_SignatureKey]  DEFAULT ((0)) FOR [SignatureKey]

End
GO
/****** Object:  ForeignKey [FK_COM_DiskResponse_DDA_Disks]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_COM_DiskResponse_DDA_Disks]') AND parent_object_id = OBJECT_ID(N'[dbo].[COM_DiskResponse]'))
ALTER TABLE [dbo].[COM_DiskResponse]  WITH CHECK ADD  CONSTRAINT [FK_COM_DiskResponse_DDA_Disks] FOREIGN KEY([DiskKey])
REFERENCES [dbo].[DDA_Disks] ([DiskKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[COM_DiskResponse] CHECK CONSTRAINT [FK_COM_DiskResponse_DDA_Disks]
GO
/****** Object:  ForeignKey [FK_DDA_AlarmChart_DDA_AlarmEvent]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_AlarmChart_DDA_AlarmEvent]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmChart]'))
ALTER TABLE [dbo].[DDA_AlarmChart]  WITH CHECK ADD  CONSTRAINT [FK_DDA_AlarmChart_DDA_AlarmEvent] FOREIGN KEY([AlarmKey])
REFERENCES [dbo].[DDA_AlarmEvent] ([AlarmKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_AlarmChart] CHECK CONSTRAINT [FK_DDA_AlarmChart_DDA_AlarmEvent]
GO
/****** Object:  ForeignKey [FK_DDA_AlarmEvent_DDA_ControlRule]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_AlarmEvent_DDA_ControlRule]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_AlarmEvent]'))
ALTER TABLE [dbo].[DDA_AlarmEvent]  WITH CHECK ADD  CONSTRAINT [FK_DDA_AlarmEvent_DDA_ControlRule] FOREIGN KEY([ControlRuleID])
REFERENCES [dbo].[DDA_ControlRule] ([ControlRuleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_AlarmEvent] CHECK CONSTRAINT [FK_DDA_AlarmEvent_DDA_ControlRule]
GO
/****** Object:  ForeignKey [FK_DDA_ControlRuleDetail_DDA_ControlRule]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ControlRuleDetail_DDA_ControlRule]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ControlRuleDetail]'))
ALTER TABLE [dbo].[DDA_ControlRuleDetail]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ControlRuleDetail_DDA_ControlRule] FOREIGN KEY([ControlRuleID])
REFERENCES [dbo].[DDA_ControlRule] ([ControlRuleID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ControlRuleDetail] CHECK CONSTRAINT [FK_DDA_ControlRuleDetail_DDA_ControlRule]
GO
/****** Object:  ForeignKey [FK_DDA_Disk_DDA_Fab]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disk_DDA_Fab]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Disk_DDA_Fab] FOREIGN KEY([FabKey])
REFERENCES [dbo].[DDA_Fabs] ([FabKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Disks] CHECK CONSTRAINT [FK_DDA_Disk_DDA_Fab]
GO
/****** Object:  ForeignKey [FK_DDA_Disk_DDA_Station]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disk_DDA_Station]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Disk_DDA_Station] FOREIGN KEY([StationKey])
REFERENCES [dbo].[DDA_Stations] ([StationKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Disks] CHECK CONSTRAINT [FK_DDA_Disk_DDA_Station]
GO
/****** Object:  ForeignKey [FK_DDA_Disk_DDA_WordCell]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disk_DDA_WordCell]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Disk_DDA_WordCell] FOREIGN KEY([WordCellKey])
REFERENCES [dbo].[DDA_WordCells] ([WordCellKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Disks] CHECK CONSTRAINT [FK_DDA_Disk_DDA_WordCell]
GO
/****** Object:  ForeignKey [FK_DDA_Disks_DDA_Products]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disks_DDA_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Disks_DDA_Products] FOREIGN KEY([ProductKey])
REFERENCES [dbo].[DDA_Products] ([ProductKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Disks] CHECK CONSTRAINT [FK_DDA_Disks_DDA_Products]
GO
/****** Object:  ForeignKey [FK_DDA_Disks_DDA_TesterTypes]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Disks_DDA_TesterTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Disks]'))
ALTER TABLE [dbo].[DDA_Disks]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Disks_DDA_TesterTypes] FOREIGN KEY([TesterTypeID])
REFERENCES [dbo].[DDA_TesterTypes] ([TesterTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Disks] CHECK CONSTRAINT [FK_DDA_Disks_DDA_TesterTypes]
GO
/****** Object:  ForeignKey [FK_DDA_GradeMapping_DDA_Grades]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_GradeMapping_DDA_Grades]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_GradeMapping]'))
ALTER TABLE [dbo].[DDA_GradeMapping]  WITH CHECK ADD  CONSTRAINT [FK_DDA_GradeMapping_DDA_Grades] FOREIGN KEY([GradeKey])
REFERENCES [dbo].[DDA_Grades] ([GradeKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_GradeMapping] CHECK CONSTRAINT [FK_DDA_GradeMapping_DDA_Grades]
GO
/****** Object:  ForeignKey [FK_DDA_Processed_DDA_Recipes]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Processed_DDA_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
ALTER TABLE [dbo].[DDA_Processed]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Processed_DDA_Recipes] FOREIGN KEY([RecipeKey])
REFERENCES [dbo].[DDA_Recipes] ([RecipeKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Processed] CHECK CONSTRAINT [FK_DDA_Processed_DDA_Recipes]
GO
/****** Object:  ForeignKey [FK_DDA_Processed_DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Processed_DDA_Surfaces]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Processed]'))
ALTER TABLE [dbo].[DDA_Processed]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Processed_DDA_Surfaces] FOREIGN KEY([SurfaceKey])
REFERENCES [dbo].[DDA_Surfaces] ([SurfaceKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Processed] CHECK CONSTRAINT [FK_DDA_Processed_DDA_Surfaces]
GO
/****** Object:  ForeignKey [FK_DDA_RecipeData_DDA_Recipes]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_RecipeData_DDA_Recipes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_RecipeData]'))
ALTER TABLE [dbo].[DDA_RecipeData]  WITH CHECK ADD  CONSTRAINT [FK_DDA_RecipeData_DDA_Recipes] FOREIGN KEY([RecipeKey])
REFERENCES [dbo].[DDA_Recipes] ([RecipeKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_RecipeData] CHECK CONSTRAINT [FK_DDA_RecipeData_DDA_Recipes]
GO
/****** Object:  ForeignKey [FK_DDA_ResultData_DDA_Results]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultData_DDA_Results]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultData]'))
ALTER TABLE [dbo].[DDA_ResultData]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ResultData_DDA_Results] FOREIGN KEY([ResultKey])
REFERENCES [dbo].[DDA_Results] ([ResultKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ResultData] CHECK CONSTRAINT [FK_DDA_ResultData_DDA_Results]
GO
/****** Object:  ForeignKey [FK_DDA_ResultDetail_DDA_Results]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultDetail_DDA_Results]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]'))
ALTER TABLE [dbo].[DDA_ResultDetail]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ResultDetail_DDA_Results] FOREIGN KEY([ResultKey])
REFERENCES [dbo].[DDA_Results] ([ResultKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ResultDetail] CHECK CONSTRAINT [FK_DDA_ResultDetail_DDA_Results]
GO
/****** Object:  ForeignKey [FK_DDA_ResultDetail_DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultDetail_DDA_Surfaces]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetail]'))
ALTER TABLE [dbo].[DDA_ResultDetail]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ResultDetail_DDA_Surfaces] FOREIGN KEY([SurfaceKey])
REFERENCES [dbo].[DDA_Surfaces] ([SurfaceKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ResultDetail] CHECK CONSTRAINT [FK_DDA_ResultDetail_DDA_Surfaces]
GO
/****** Object:  ForeignKey [FK_DDA_ResultDetailData_DDA_ResultDetail]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultDetailData_DDA_ResultDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultDetailData]'))
ALTER TABLE [dbo].[DDA_ResultDetailData]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ResultDetailData_DDA_ResultDetail] FOREIGN KEY([ResultDetailKey])
REFERENCES [dbo].[DDA_ResultDetail] ([ResultDetailKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ResultDetailData] CHECK CONSTRAINT [FK_DDA_ResultDetailData_DDA_ResultDetail]
GO
/****** Object:  ForeignKey [FK_DDA_ResultObjects_DDA_ResultObjectTypes]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ResultObjects_DDA_ResultObjectTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ResultObjects]'))
ALTER TABLE [dbo].[DDA_ResultObjects]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ResultObjects_DDA_ResultObjectTypes] FOREIGN KEY([ObjectTypeKey])
REFERENCES [dbo].[DDA_ResultObjectTypes] ([ObjectTypeKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ResultObjects] CHECK CONSTRAINT [FK_DDA_ResultObjects_DDA_ResultObjectTypes]
GO
/****** Object:  ForeignKey [FK_DDA_Results_DDA_Signatures]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Results_DDA_Signatures]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Results]'))
ALTER TABLE [dbo].[DDA_Results]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Results_DDA_Signatures] FOREIGN KEY([SignatureKey])
REFERENCES [dbo].[DDA_Signatures] ([SignatureKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Results] CHECK CONSTRAINT [FK_DDA_Results_DDA_Signatures]
GO
/****** Object:  ForeignKey [FK_DDA_SurfaceData_DDA_Surfaces]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_SurfaceData_DDA_Surfaces]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_SurfaceData]'))
ALTER TABLE [dbo].[DDA_SurfaceData]  WITH CHECK ADD  CONSTRAINT [FK_DDA_SurfaceData_DDA_Surfaces] FOREIGN KEY([SurfaceKey])
REFERENCES [dbo].[DDA_Surfaces] ([SurfaceKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_SurfaceData] CHECK CONSTRAINT [FK_DDA_SurfaceData_DDA_Surfaces]
GO
/****** Object:  ForeignKey [FK_DDA_Surfaces_DDA_Disk]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_Surfaces_DDA_Disk]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_Surfaces]'))
ALTER TABLE [dbo].[DDA_Surfaces]  WITH CHECK ADD  CONSTRAINT [FK_DDA_Surfaces_DDA_Disk] FOREIGN KEY([DiskKey])
REFERENCES [dbo].[DDA_Disks] ([DiskKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_Surfaces] CHECK CONSTRAINT [FK_DDA_Surfaces_DDA_Disk]
GO
/****** Object:  ForeignKey [FK_DDA_ViolativeDisk_DDA_AlarmEvent]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ViolativeDisk_DDA_AlarmEvent]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]'))
ALTER TABLE [dbo].[DDA_ViolativeDisk]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ViolativeDisk_DDA_AlarmEvent] FOREIGN KEY([AlarmKey])
REFERENCES [dbo].[DDA_AlarmEvent] ([AlarmKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ViolativeDisk] CHECK CONSTRAINT [FK_DDA_ViolativeDisk_DDA_AlarmEvent]
GO
/****** Object:  ForeignKey [FK_DDA_ViolativeDisk_DDA_Disk]    Script Date: 06/14/2010 16:20:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DDA_ViolativeDisk_DDA_Disk]') AND parent_object_id = OBJECT_ID(N'[dbo].[DDA_ViolativeDisk]'))
ALTER TABLE [dbo].[DDA_ViolativeDisk]  WITH CHECK ADD  CONSTRAINT [FK_DDA_ViolativeDisk_DDA_Disk] FOREIGN KEY([DiskKey])
REFERENCES [dbo].[DDA_Disks] ([DiskKey])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DDA_ViolativeDisk] CHECK CONSTRAINT [FK_DDA_ViolativeDisk_DDA_Disk]
GO


ALTER TABLE dbo.DDA_Recipes ADD
	CreateDateTime datetime NULL,
	LastModifyTime datetime NULL
GO
ALTER TABLE dbo.DDA_Recipes ADD CONSTRAINT
	DF_DDA_Recipes_CreateDateTime DEFAULT GETDATE() FOR CreateDateTime
GO
ALTER TABLE dbo.DDA_Recipes ADD CONSTRAINT
	DF_DDA_Recipes_LastModifyTime DEFAULT GETDATE() FOR LastModifyTime
GO



set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROCEDURE [dbo].[GET_NPROCESS_SURFACE]
	@RecipeKey INT,
	@PrevRecipeKey INT = -1,
	@Fabkey SMALLINT=0,
	@FromDate datetime = null,
	@TestGradeList varchar(1014) = null,
	@N INT
AS
BEGIN
	DECLARE @TesterType VARCHAR(255)
	SELECT @TesterType = TesterType FROM DDA_Recipes WHERE RecipeKey = @RecipeKey

	IF (@FromDate = '1900-01-01' )
		SELECT @FromDate = CreateDateTime FROM DDA_Recipes WHERE RecipeKey = @RecipeKey

	IF(@TesterType IS NOT NULL)
	BEGIN
		IF(@TesterType='') SET @TesterType = NULL
	END

	DECLARE @SQL NVARCHAR(4000)

-- SELECT 
	SET @SQL = 'SELECT  TOP ' + CAST(@N AS VARCHAR) + ' x.SurfaceKey FROM DDA_Surfaces x'

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + ' INNER JOIN DDA_Processed as y 
				ON x.SurfaceKey = y.SurfaceKey'

	IF(@Fabkey>0 OR @TesterType IS NOT NULL OR @TestGradeList IS NOT NULL )
	BEGIN
		
		SET @SQL = @SQL + ' INNER JOIN DDA_Disks ON x.DiskKey = DDA_Disks.DiskKey'
		IF( @TesterType IS NOT NULL)
		BEGIN
			SET @SQL = @SQL + ' INNER JOIN DDA_TesterTypes
				ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID'
		END
	END
		
-- WHERE
	SET @SQL = @SQL + '
	WHERE'-- x.Processed=0'
	
	IF(@FromDate IS NOT NULL) SET @SQL = @SQL + ' x.InsertedDate >= ''' + CAST(@FromDate AS VARCHAR) + ''' AND'

	IF(@TestGradeList IS NOT NULL) SET @SQL = @SQL + ' (' + @TestGradeList + ') AND'

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + ' y.RECIPEKEY = ' + CAST(@PrevRecipeKey AS NVARCHAR) + ' AND y.Finish=1 AND y.BreakWhenFound=0 AND'
	
	IF(@Fabkey>0) SET @SQL = @SQL + ' DDA_Disks.FabKey=' + CAST(@Fabkey AS NVARCHAR) + ' AND'
	
	IF(@TesterType IS NOT NULL) SET @SQL = @SQL + ' DDA_TesterTypes.TesterType LIKE ''' + @TesterType + '%'' AND'
	
	--SET @SQL = @SQL + ' x.SurfaceKey NOT IN (SELECT SurfaceKey FROM DDA_Processed WHERE RecipeKey=' + CAST(@RecipeKey AS NVARCHAR) + ')'
	SET @SQL = @SQL + ' NOT EXISTS( SELECT p.SurfaceKey FROM DDA_Processed p WHERE RecipeKey=' + CAST(@RecipeKey AS NVARCHAR) + ' AND p.SurfaceKey=x.SurfaceKey)'

	EXECUTE sp_executesql @SQL
	--PRINT @SQL
END

GO

CREATE NONCLUSTERED INDEX [IX_DDA_Surface_InsertedDate] ON [dbo].[DDA_Surfaces] 
(
	[InsertedDate] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO


-- Inserts a new record into the 'DDA_Recipes' table.
ALTER PROCEDURE [dbo].[_DDA_Recipes_Insert]
	@RecipeName nvarchar(50),
	@SignatureKey int,
	@PrevRecipeKey int,
	@Description nvarchar(255),
	@Status tinyint,
	@TesterType varchar(255),
	@BreakWhenFound bit
AS
	INSERT INTO [dbo].[DDA_Recipes]
	(
		[PrevRecipeKey],
		[RecipeName],
		[SignatureKey],
		[Description],
		Status,
		TesterType,
		BreakWhenFound,
CreateDateTime,
LastModifyTime

	)
	VALUES
	(
		@PrevRecipeKey,
		@RecipeName,
		@SignatureKey,
		@Description,
		@Status,
		@TesterType,
		@BreakWhenFound,
GETDATE(),
GETDATE()
	)
	SELECT @@IDENTITY
GO



-- Updates a record in the 'DDA_Recipes' table.
ALTER PROCEDURE [dbo].[_DDA_Recipes_Update]
	-- The rest of writeable parameters
	@RecipeName nvarchar(50),
	@SignatureKey int,
	@PrevRecipeKey int,
	@Description nvarchar(255),
	@Status tinyint,
	@TesterType varchar(255),
	@BreakWhenFound bit,
	-- Primary key parameters
	@RecipeKey int
AS
	UPDATE [dbo].[DDA_Recipes] SET
		[PrevRecipeKey] = @PrevRecipeKey,
		[RecipeName] = @RecipeName,
		[SignatureKey] = @SignatureKey,
		[Description] = @Description,
		Status = @Status,
		TesterType = @TesterType,
		BreakWhenFound = @BreakWhenFound,
		LastModifyTime = GETDATE()
		
	WHERE
		[RecipeKey] = @RecipeKey
GO

UPDATE [DDA_Recipes]
   SET 
      [CreateDateTime] = '2010-06-14',
      [LastModifyTime] = '2010-06-14'
 

GO

ALTER PROCEDURE [dbo].[ExportView_SurfaceOfSignature]
	@View NVARCHAR(255),
	@FIELDS VARCHAR(1000),
	@WHERESQL NVARCHAR(4000),
	@Distinct bit = 0
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @SQL NVARCHAR(4000)
	DECLARE @F VARCHAR(255)
	DECLARE @ViewList VARCHAR(1024)
	DECLARE @ExList VARCHAR(1024)
	DECLARE @SDT VARCHAR(10)

	SET @ViewList = ''
	SET @ExList = ''
	SET @SDT = ''

	IF @Distinct = 1 SET @SDT = ' DISTINCT '

	DECLARE TableCursor CURSOR FOR 
	SELECT Keyword
	FROM dbo.[f_Split] (@FIELDS,',')
	OPEN TableCursor
	FETCH NEXT FROM TableCursor INTO @F
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @F = LTRIM(RTRIM(@F))

		IF ( UPPER(@F) = 'KKLOT'
			OR UPPER(@F) = 'KKSLOT'
			OR UPPER(@F) = 'CASS_ID' ) 
		BEGIN
			SET @ExList = @ExList + ',e.' + @F
			SET @ViewList = @ViewList + ',e.' + @F
		END
		ELSE 
		BEGIN
			IF( CHARINDEX (' WHEN ',@F) >= 1 AND CHARINDEX (' THEN ',@F) >= 1 )
			BEGIN
--				DECLARE @F VARCHAR(255)
--				SET @F = 'CASE Surface WHEN 0 THEN ''Top'' WHEN 1 Then ''Bottom'' END as Surface'
				SET @F = SUBSTRING(@F,1,4) + 
						+ ' v.' + LTRIM(SUBSTRING(@F,CHARINDEX ('CASE',@F) + 4,CHARINDEX('WHEN',@F) - CHARINDEX ('CASE',@F) - 4))
				+ SUBSTRING(@F,CHARINDEX('WHEN',@F),LEN(@F) - CHARINDEX('WHEN',@F) + 1)
--				PRINT @F
				SET @ViewList = @ViewList + ',' + @F
			END
			ELSE
				SET @ViewList = @ViewList + ',v.' + @F
		END

		FETCH NEXT FROM TableCursor INTO @F
	END
	CLOSE TableCursor
	DEALLOCATE TableCursor

	IF (@ViewList <> '') SET @ViewList  = SUBSTRING(@ViewList , 2, LEN(@ViewList)-1)
	IF (@ExList <> '') SET @ExList  = SUBSTRING(@ExList , 2, LEN(@ExList)-1)

	IF (@ExList = '' AND LTRIM(RTRIM(@FIELDS)) <> '*')
	BEGIN
		SET @SQL = 'SELECT ' + @SDT + @ViewList + ' FROM ' + @View + ' as v WITH(NOLOCK)  WHERE ' + @WHERESQL +
		' ORDER BY v.SurfaceKey, v.Grade, v.SignatureName'
		EXEC (@SQL)
	END
	ELSE
	BEGIN
		SET @SQL = 'SELECT * INTO #Temp FROM ' + @View + ' WITH(NOLOCK) WHERE ' + @WHERESQL

		IF(LTRIM(RTRIM(@FIELDS)) <> '*')
			SET @SQL = @SQL +'
				SELECT ' 
				+ @SDT
				+ @ViewList 
				+ ' FROM #Temp as v left join DDA_KOI_Headers as e WITH(NOLOCK) 
					on v.LotNo = e.Lot_ID
					and v.SlotNum = e.Lot_Slot ORDER BY v.SurfaceKey, v.Grade, v.SignatureName'
		ELSE 
			SET @SQL = @SQL + '
				SELECT ' 
				+ @SDT 
				+ 'v.*,e.KKLot,e.KKSlot,e.Cass_ID FROM #Temp as v left join DDA_KOI_Headers  as e WITH(NOLOCK)
					on v.LotNo = e.Lot_ID
					and v.SlotNum = e.Lot_Slot ORDER BY v.SurfaceKey, v.Grade, v.SignatureName'

		EXEC (@SQL)
	END
	
END
GO

GO
ALTER TABLE dbo.DDA_EIS_Resources ADD
	Rsc01 varchar(10) NULL,
	Rsc02 varchar(10) NULL,
	Rsc03 varchar(10) NULL,
	Rsc04 varchar(10) NULL,
	Rsc05 varchar(10) NULL,
	Rsc06 varchar(10) NULL,
	Rsc07 varchar(10) NULL,
	Rsc08 varchar(10) NULL,
	Rsc09 varchar(10) NULL,
	Rsc10 varchar(10) NULL,
	Rsc11 varchar(10) NULL,
	DateTime01 datetime NULL,
	DateTime02 datetime NULL,
	DateTime03 datetime NULL,
	DateTime04 datetime NULL,
	DateTime05 datetime NULL,
	DateTime06 datetime NULL,
	DateTime07 datetime NULL,
	DateTime08 datetime NULL,
	DateTime09 datetime NULL,
	DateTime10 datetime NULL,
	DateTime11 datetime NULL
GO

ALTER PROCEDURE [dbo].[_DDA_EIS_Resources_Insert]
			@LotNum varchar(10)
           ,@Rsc725 varchar(10)
           ,@Rsc769 varchar(10)
           ,@Rsc771 varchar(10)
           ,@Rsc764 varchar(10)
           ,@Rsc575 varchar(10)
           ,@Rsc450 varchar(10)
           ,@Rsc453 varchar(10)
           ,@Rsc600 varchar(10)
           ,@Rsc766 varchar(10)
	,@DateTime725 datetime
      ,@DateTime769  datetime
      ,@DateTime771 datetime
      ,@DateTime764 datetime
      ,@DateTime575 datetime
      ,@DateTime450 datetime
      ,@DateTime453 datetime
      ,@DateTime600 datetime
      ,@DateTime766 datetime,
	@Rsc01 varchar(10) = NULL,
	@Rsc02 varchar(10) = NULL,
	@Rsc03 varchar(10) = NULL,
	@Rsc04 varchar(10) = NULL,
	@Rsc05 varchar(10) = NULL,
	@Rsc06 varchar(10) = NULL,
	@Rsc07 varchar(10) = NULL,
	@Rsc08 varchar(10) = NULL,
	@Rsc09 varchar(10) = NULL,
	@Rsc10 varchar(10) = NULL,
	@Rsc11 varchar(10) = NULL,
	@DateTime01 datetime = NULL,
	@DateTime02 datetime = NULL,
	@DateTime03 datetime = NULL,
	@DateTime04 datetime = NULL,
	@DateTime05 datetime = NULL,
	@DateTime06 datetime = NULL,
	@DateTime07 datetime = NULL,
	@DateTime08 datetime = NULL,
	@DateTime09 datetime = NULL,
	@DateTime10 datetime = NULL,
	@DateTime11 datetime = NULL
AS


INSERT INTO [dbo].[DDA_EIS_Resources]
           ([LotNum]
           ,[Rsc725]
           ,[Rsc769]
           ,[Rsc771]
           ,[Rsc764]
           ,[Rsc575]
           ,[Rsc450]
           ,[Rsc453]
           ,[Rsc600]
           ,[Rsc766]
		,[DateTime725]
      ,[DateTime769]
      ,[DateTime771]
      ,[DateTime764]
      ,[DateTime575]
      ,[DateTime450]
      ,[DateTime453]
      ,[DateTime600]
      ,[DateTime766],
		Rsc01 ,
		Rsc02 ,
		Rsc03 ,
		Rsc04 ,
		Rsc05 ,
		Rsc06 ,
		Rsc07 ,
		Rsc08 ,
		Rsc09 ,
		Rsc10 ,
		Rsc11 ,
		DateTime01 ,
		DateTime02 ,
		DateTime03 ,
		DateTime04 ,
		DateTime05 ,
		DateTime06 ,
		DateTime07 ,
		DateTime08 ,
		DateTime09 ,
		DateTime10 ,
		DateTime11 
	)
     VALUES
           (@LotNum
           ,@Rsc725
           ,@Rsc769
           ,@Rsc771
           ,@Rsc764
           ,@Rsc575
           ,@Rsc450
           ,@Rsc453
           ,@Rsc600
           ,@Rsc766
		,@DateTime725 
      ,@DateTime769  
      ,@DateTime771 
      ,@DateTime764 
      ,@DateTime575 
      ,@DateTime450 
      ,@DateTime453 
      ,@DateTime600 
      ,@DateTime766 ,
		@Rsc01 ,
		@Rsc02 ,
		@Rsc03 ,
		@Rsc04 ,
		@Rsc05 ,
		@Rsc06 ,
		@Rsc07 ,
		@Rsc08 ,
		@Rsc09 ,
		@Rsc10 ,
		@Rsc11 ,
		@DateTime01 ,
		@DateTime02 ,
		@DateTime03 ,
		@DateTime04 ,
		@DateTime05 ,
		@DateTime06 ,
		@DateTime07 ,
		@DateTime08 ,
		@DateTime09 ,
		@DateTime10 ,
		@DateTime11 
)
GO


ALTER VIEW [dbo].[ChartView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.InnerDiameter, 
                      dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, 
                      dbo.DDA_Fabs.FabID, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, 
                      dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, 
                      dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, 
                      dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_EIS_Resources.Rsc725, 
                      dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, 
                      dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, 
                      dbo.DDA_Disks.HasMeaning, dbo.DDA_Surfaces.HasSignature, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
GO


ALTER VIEW [dbo].[DiskView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.StationKey, 
                      dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, 
                      dbo.DDA_Stations.Tester, dbo.DDA_Fabs.FabID, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Disks.L2_Top_Corr_cts, 
                      dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, 
                      dbo.DDA_Products.ProductCode AS Product, dbo.DDA_Disks.TestDiskDate AS TestDate, dbo.DDA_TesterTypes.TesterType, dbo.DDA_TesterTypes.TesterTypeID, 
                      dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, dbo.DDA_KOI_Headers.Cass_ID, 
                      dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, 
                      dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, 
                      dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_Disks.HasMeaning, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[DiskViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.StationKey, 
                      dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, 
                      dbo.DDA_Stations.Tester, dbo.DDA_Fabs.FabID, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Disks.L2_Top_Corr_cts, 
                      dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, 
                      dbo.DDA_Products.ProductCode AS Product, dbo.DDA_Disks.TestDiskDate AS TestDate, dbo.DDA_TesterTypes.TesterType, dbo.DDA_TesterTypes.TesterTypeID, 
                      dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, 
                      dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, 
                      dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_Disks.HasMeaning, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, 
                      dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[SingleLayerView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.StationKey, 
                      dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, 
                      dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, 
                      dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, 
                      dbo.DDA_Results.AnalyzeTime, dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, 
                      dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, 
                      dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, 
                      dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, 
                      dbo.DDA_Signatures.SignatureID, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_Grades.GradeDescription, 
                      dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, dbo.DDA_KOI_Headers.Cass_ID, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, 
                      dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, 
                      dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_Disks.HasMeaning, 
                      dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[SingleLayerViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.StationKey, 
                      dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, 
                      dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, 
                      dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, 
                      dbo.DDA_Results.AnalyzeTime, dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, 
                      dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, 
                      dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, 
                      dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, 
                      dbo.DDA_Signatures.SignatureID, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_Grades.GradeDescription, 
                      dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, 
                      dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, 
                      dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_Disks.HasMeaning, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[SourceView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.StationKey, 
                      dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, 
                      dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, 
                      dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, dbo.DDA_Surfaces.HasSignature, dbo.DDA_Disks.L2_Top_Corr_cts, 
                      dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, 
                      dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, 
                      dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, 
                      dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, dbo.DDA_KOI_Headers.Cass_ID, dbo.DDA_Disks.HasMeaning, 
                      dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_Surfaces INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_WordCells ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[SourceViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, dbo.DDA_Disks.StationKey, 
                      dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, dbo.DDA_WordCells.TestCell, 
                      dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, 
                      dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, dbo.DDA_Surfaces.HasSignature, dbo.DDA_Disks.L2_Top_Corr_cts, 
                      dbo.DDA_Disks.L2_Bot_Corr_cts, dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, 
                      dbo.DDA_Products.ProductCode AS Product, dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, 
                      dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_EIS_Resources.Rsc600, 
                      dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_Disks.HasMeaning, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806
FROM         dbo.DDA_Surfaces INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_Surfaces.DiskKey = dbo.DDA_Disks.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_WordCells ON dbo.DDA_Disks.WordCellKey = dbo.DDA_WordCells.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
GO

SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[_GetSurfaceHasSignature]
	@WHERESQL NVARCHAR(4000),
	@StartRow INT = 0,
	@PAGESIZE INT = 20,
	@TOTALROW INT = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @SQL NVARCHAR(4000)
	DECLARE @ORDERBY VARCHAR(100)

	SET @StartRow = @StartRow + 1

	SET @ORDERBY = 'SurfaceKey'
	SET @SQL = 'SELECT DISTINCT DiskKey, DiskID, TestGrade, SlotNum, LotNo, StationKey, InnerDiameter, LotIDCode, BinNo,
				OuterDiameter, TestCell, CassetteID, Tester, TestDate, Surface, Product, FabID, 
				SurfaceKey, NumberOfDefect, Loaded, L2_Top_Corr_cts, L2_Bot_Corr_cts, L2_Top_NCorr_cts, L2_Bot_NCorr_cts, TesterType
		,[Rsc725]
      ,[Rsc769]
      ,[Rsc771]
      ,[Rsc764]
      ,[Rsc575]
      ,[Rsc450]
      ,[Rsc453]
      ,[Rsc600]
      ,[Rsc766]
	  ,[Rsc0806]
	  ,[Rsc3806]
				FROM SingleLayerViewQuery WITH(NOLOCK) WHERE ' + @WHERESQL

	--GET TOTAL ROW NUMBER
	DECLARE @SQLQuery AS NVARCHAR(4000)
	SET @SQLQuery = N'SELECT @TOTALROW = COUNT(SurfaceKey) FROM ('  + @SQL + ') as a'
	EXECUTE sp_executesql @SQLQuery,N'@TOTALROW INT OUTPUT', @TOTALROW OUTPUT
	--PRINT CAST(@TOTALROW AS VARCHAR)
	--PRINT @SQLQuery

	--Calculate row indices
	DECLARE @EndRow INT
	--Calculate end row
	SET @EndRow = @StartRow + @PageSize - 1;
	IF (@EndRow > @TOTALROW)
		SET @EndRow = @TOTALROW;

	DECLARE @Fields NVARCHAR(3000)
	DECLARE @Tables NVARCHAR(200)

	SET @Fields = 'DISTINCT SingleLayerView.DiskKey, SingleLayerView.DiskID, SingleLayerView.TestGrade, SingleLayerView.SlotNum, SingleLayerView.LotNo, SingleLayerView.StationKey, SingleLayerView.InnerDiameter, SingleLayerView.LotIDCode, SingleLayerView.BinNo,
				SingleLayerView.OuterDiameter, SingleLayerView.TestCell, SingleLayerView.CassetteID, SingleLayerView.Tester, SingleLayerView.TestDate, SingleLayerView.Surface, SingleLayerView.Product, SingleLayerView.FabID, 
				SingleLayerView.SurfaceKey, SingleLayerView.NumberOfDefect, SingleLayerView.Loaded, SingleLayerView.L2_Top_Corr_cts, SingleLayerView.L2_Bot_Corr_cts, SingleLayerView.L2_Top_NCorr_cts, SingleLayerView.L2_Bot_NCorr_cts, SingleLayerView.TesterType,
		SingleLayerView.[Rsc725]
		,SingleLayerView.[Rsc769]
      ,SingleLayerView.[Rsc771]
      ,SingleLayerView.[Rsc764]
      ,SingleLayerView.[Rsc575]
      ,SingleLayerView.[Rsc450]
      ,SingleLayerView.[Rsc453]
      ,SingleLayerView.[Rsc600]
      ,SingleLayerView.[Rsc766]
	  ,SingleLayerView.[Rsc0806]
	  ,SingleLayerView.[Rsc3806]
	  ,SingleLayerView.KKLot, SingleLayerView.KKSlot  ';
	SET @Tables = 'SingleLayerView';

--		SET @SQL = 
--		'WITH _Paging_ AS ' +
--		'(SELECT TOP ' + CAST(@EndRow AS NVARCHAR) + ' ROW_NUMBER() OVER (ORDER BY ' + @ORDERBY + ') AS RowNumber,SurfaceKey FROM (' +
--			'SELECT ' + @Fields +
--			'FROM ' + @Tables + ' ' +
--			'WHERE ' + @WHERESQL + ') AS Temp ) ' +
--		'SELECT * INTO #TempResult FROM _Paging_ WHERE RowNumber >=' + CAST(@StartRow AS NVARCHAR) + ' ORDER BY RowNumber'
--
--	+ '
--		SELECT DISTINCT [SingleLayerView].DiskKey, [SingleLayerView].DiskID, [SingleLayerView].TestGrade, [SingleLayerView].SlotNum, [SingleLayerView].LotNo, [SingleLayerView].StationKey, [SingleLayerView].InnerDiameter, 
--				[SingleLayerView].OuterDiameter, [SingleLayerView].TestCell, [SingleLayerView].CassetteID, [SingleLayerView].Tester, [SingleLayerView].TestDate, [SingleLayerView].Surface, [SingleLayerView].Product, [SingleLayerView].FabID, 
--				[SingleLayerView].SurfaceKey, [SingleLayerView].NumberOfDefect, [SingleLayerView].Loaded, [SingleLayerView].L2_Top_Corr_cts, [SingleLayerView].L2_Bot_Corr_cts, [SingleLayerView].L2_Top_NCorr_cts, [SingleLayerView].L2_Bot_NCorr_cts FROM [SingleLayerView] INNER JOIN #TempResult ON [SingleLayerView].SurfaceKey=#TempResult.SurfaceKey'

	--PRINT @SQL

	SET @SQL = 'SELECT DISTINCT SurfaceKey INTO #Temp FROM ' + 'SingleLayerViewQuery' + ' WITH(NOLOCK) WHERE ' + @WHERESQL +
	' SELECT ROW_NUMBER() OVER (ORDER BY ' + @ORDERBY + ') AS RowNumber, ' + @ORDERBY + ' INTO #Paging FROM #Temp
	 SELECT * INTO #TempResult FROM #Paging WHERE RowNumber >= ' + CAST(@StartRow AS NVARCHAR) + ' AND RowNumber <= ' + CAST(@EndRow AS NVARCHAR) 
	+ ' SELECT * FROM ( 
	SELECT ' + @Fields + ', RowNumber FROM ' + @Tables + ' WITH(NOLOCK) INNER JOIN #TempResult ON ' + @Tables + '.' + @ORDERBY + '=#TempResult.' + @ORDERBY + ' WHERE ' + @WHERESQL + ') as outputtable
	ORDER BY RowNumber'

	--PRINT (@SQL)
	EXEC (@SQL)
END
GO

-- =============================================
-- Author:		CANG DO
-- Create date: 2010-01-26
-- Description:	Insert EIS Data into DDADB for each LOT
-- =============================================
-- Update data for MCT : 806 Resource

ALTER PROCEDURE [dbo].[spDDA2EISCopyData] 
	-- Add the parameters for the stored procedure here
	@lotnum nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON

	IF ( EXISTS ( SELECT * FROM [DDA_EIS_Resources] WHERE LotNum = @lotnum) )
	BEGIN
		SELECT 2
		RETURN 2
	END
		
	DECLARE @Rsc450 VARCHAR(10)
	DECLARE @DateTime450 datetime
	DECLARE @Rsc453 VARCHAR(10)
	DECLARE @DateTime453 datetime
	DECLARE @Rsc600 VARCHAR(10)
	DECLARE @DateTime600 datetime
	DECLARE @Rsc725 VARCHAR(10)
	DECLARE @DateTime725 datetime
	DECLARE @Rsc766 VARCHAR(10)
	DECLARE @DateTime766 datetime
	DECLARE @Rsc769 VARCHAR(10)
	DECLARE @DateTime769 datetime
	DECLARE @Rsc771 VARCHAR(10)
	DECLARE @DateTime771 datetime
	DECLARE @Rsc764 VARCHAR(10)
	DECLARE @DateTime764 datetime
	DECLARE @Rsc575 VARCHAR(10)
	DECLARE @DateTime575 datetime
	DECLARE @dlotnum nvarchar(50)

	SET @dlotnum = @lotnum

	-- Check Type Of Operation 
	--Any lot number which start from the character ‘A’ is the 806 lot number.	
	IF ( SUBSTRING( LTRIM(@lotnum), 1,1 ) = 'A' )
	BEGIN

		-- get the last testcell from LotNo
		declare @testcell VARCHAR (5)
		SELECT @testcell = DDA_WordCells.TestCell
		FROM  DDA_Disks WITH(NOLOCK) INNER JOIN
						  DDA_WordCells WITH(NOLOCK) ON DDA_Disks.WordCellKey = DDA_WordCells.WordCellKey
		where DDA_Disks.LotNo = @lotnum

		DECLARE @MotherLotId VARCHAR(10)
		DECLARE @NSql NVARCHAR(MAX)
		DECLARE @Sql VARCHAR(MAX)
	
		SET @MotherLotId = ''

		IF LEN(@testcell) = 3
		SET @testcell = 'T' + @testcell

		IF SUBSTRING(@testcell, 2, 1) = '1'
		BEGIN
			SET @NSql = N'SELECT @MotherLotId = Lot_Id FROM [WDKPG13].KOI.dbo.tbl_KOI_Rawdata_PN1 as KOI1(NoLock), [WDKPG13].KOI.dbo.tbl_KOI_Rawdata2_PN1 as KOI2(NoLock)'
			SET @NSql = @NSql + ' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND KK_Lot = ''' + @lotnum + ''''
			EXEC master..sp_executesql @NSql, N'@MotherLotId varchar(10) OUTPUT', @MotherLotId OUTPUT
		END

		IF SUBSTRING(@testcell, 2, 1) = '3'
		BEGIN
			SET @NSql = N'SELECT  @MotherLotId = Lot_Id FROM [WDKPG13].KOI.dbo.tbl_KOI_Rawdata_PN2 as KOI1 (NoLock), [WDKPG13].KOI.dbo.tbl_KOI_Rawdata2_PN2 as KOI2(NoLock)'
			SET @NSql = @NSql + ' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND KK_Lot = ''' + @lotnum + ''''
			EXEC master..sp_executesql @NSql, N'@MotherLotId varchar(10) OUTPUT', @MotherLotId OUTPUT
		END

		set @lotnum = @MotherLotId
	END



--	SELECT
--		@Rsc450 = Rsc450
--		, @DateTime450= TrDate450
--		, @Rsc453 = Rsc453
--		, @DateTime453=TrDate453
--		, @Rsc600 = Rsc600
--		, @DateTime600=TrDate600
--		, @Rsc725 = Rsc725
--		, @DateTime725=TrDate725
--		, @Rsc766 = Rsc766
--		, @DateTime766=TrDate766
--		, @Rsc769 = Rsc769
--		, @DateTime769=TrDate769
--		, @Rsc771 = Rsc771
--		, @DateTime771=TrDate771
--		, @Rsc764 = Rsc764
--		, @DateTime764=TrDate764
--		, @Rsc575 = Rsc575
--		, @DateTime575=TrDate575
--	FROM [WDKPG13].EIS.dbo.tbl_Resources_Summary as Summary WITH(NOLOCK) 
--	WHERE Lotno803804805 = @lotnum


	IF( @Rsc450 IS NULL 
		AND @Rsc453 IS NULL
		AND @Rsc600 IS NULL
		AND @Rsc725 IS NULL
		AND @Rsc766 IS NULL
		AND @Rsc769 IS NULL
		AND @Rsc771 IS NULL
		AND @Rsc764 IS NULL
		AND @Rsc575 IS NULL )
	BEGIN
		SELECT 0
	END
	ELSE
	BEGIN 
		INSERT INTO [DDA_EIS_Resources]
           ([LotNum]
           ,[Rsc725]
           ,[Rsc769]
           ,[Rsc771]
           ,[Rsc764]
           ,[Rsc575]
           ,[Rsc450]
           ,[Rsc453]
           ,[Rsc600]
           ,[Rsc766]
           ,[DateTime725]
           ,[DateTime769]
           ,[DateTime771]
           ,[DateTime764]
           ,[DateTime575]
           ,[DateTime450]
           ,[DateTime453]
           ,[DateTime600]
           ,[DateTime766])
     VALUES
           (@dlotnum
           ,@Rsc725
           ,@Rsc769
           ,@Rsc771
           ,@Rsc764
           ,@Rsc575
           ,@Rsc450
           ,@Rsc453
           ,@Rsc600
           ,@Rsc766
           ,@DateTime725
           ,@DateTime769
           ,@DateTime771
           ,@DateTime764
           ,@DateTime575
           ,@DateTime450
           ,@DateTime453
           ,@DateTime600
           ,@DateTime766)

		SELECT 1
	END

END
GO


ALTER PROCEDURE [dbo].[DDA_KOI_DTS_Retrieve_KOI_Data] 
	-- Add the parameters for the stored procedure here
	@testcell VARCHAR (5), 
	@lotnum VARCHAR (10),
	@lotslot VARCHAR (2)
AS
BEGIN
	DECLARE @debug BIT
	DECLARE @KKLot VARCHAR(10)
	DECLARE @KKSlot VARCHAR(2)
	DECLARE @CassID VARCHAR(20)
	DECLARE @NSql NVARCHAR(MAX)
	DECLARE @Sql VARCHAR(MAX)
	
	DECLARE  @tmp_table TABLE(Lot_Id VARCHAR(20), Lot_Slot VARCHAR(2), KKLot VARCHAR(10), KKSlot VARCHAR(2), Cass_ID VARCHAR(20))

	-- Set to 1 to debugging information --
	SET @debug = 1
	IF @debug = 0
		SET NOCOUNT ON
	ELSE
		SET NOCOUNT OFF

	SET @KKLot = ''
	SET @KKSlot = ''
	SET @CassID = ''

	IF LEN(@testcell) = 3
	SET @testcell = 'T' + @testcell

	IF SUBSTRING(@testcell, 2, 1) = '1'
	BEGIN
		SET @NSql = N'SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM [WDKPG13].KOI.dbo.tbl_KOI_Rawdata_PN1 KOI1 (NoLock), [WDKPG13].KOI.dbo.tbl_KOI_Rawdata2_PN1 KOI2(NoLock)'
		SET @NSql = @NSql + ' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = ''' + @lotnum + ''' AND Lot_Slot = ''' + @lotslot + ''''
		EXEC master..sp_executesql @NSql, N'@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT
		
		INSERT INTO @tmp_table (Lot_Id, Lot_Slot, KKLot, KKSlot, Cass_ID) Values (@lotnum, @lotslot, CASE WHEN @KKLot = '' THEN NULL ELSE @KKLot END, CASE WHEN @KKSlot = '' THEN NULL ELSE @KKSlot END, CASE WHEN @CassID = '' THEN NULL ELSE @CassID END)
		EXEC (@Sql) 
	END

	IF SUBSTRING(@testcell, 2, 1) = '3'
	BEGIN
		SET @NSql = N'SELECT @KKLot = KK_Lot, @KKSlot = Cass_Slot, @CassID = KOI1.Cass_ID FROM [WDKPG13].KOI.dbo.tbl_KOI_Rawdata_PN2 KOI1 (NoLock), [WDKPG13].KOI.dbo.tbl_KOI_Rawdata2_PN2 KOI2(NoLock)'
		SET @NSql = @NSql + ' WHERE KOI1.Cass_ID = KOI2.Cass_ID AND Lot_Id = ''' + @lotnum + ''' AND Lot_Slot = ''' + @lotslot + ''''
		EXEC master..sp_executesql @NSql, N'@KKLot varchar(10) OUTPUT, @KKSlot varchar(2) OUTPUT, @CassID varchar(20) OUTPUT', @KKLot OUTPUT, @KKSlot OUTPUT, @CassID OUTPUT

		INSERT INTO @tmp_table (Lot_Id, Lot_Slot, KKLot, KKSlot, Cass_ID) Values (@lotnum, @lotslot, CASE WHEN @KKLot = '' THEN NULL ELSE @KKLot END, CASE WHEN @KKSlot = '' THEN NULL ELSE @KKSlot END, CASE WHEN @CassID = '' THEN NULL ELSE @CassID END)
		EXEC (@Sql) 
	END

	SELECT * FROM @tmp_table
END


-- update 2010-08-16

GO
CREATE PROCEDURE [dbo].[_GetParetoChartDataIndividualResource_TestCell]
@WHERESQL NVARCHAR(4000),
@GROUPBY NVARCHAR(50)
AS
BEGIN
	DECLARE @SQL NVARCHAR(4000)
	DECLARE @TotalDisk real

	SET @SQL = 'SELECT @TotalDisk = COUNT(DISTINCT(DiskKey)) FROM ChartView WITH(NOLOCK) WHERE ' + @WHERESQL
	EXECUTE sp_executesql @SQL, N'@TotalDisk Real OUTPUT', @TotalDisk OUTPUT
	
	IF @TotalDisk IS NULL OR @TotalDisk = 0 RETURN

	SET @SQL = 'SELECT Grade, ISNULL(' + @GROUPBY + ', ''Unknown'') AS ' + @GROUPBY + ', COUNT(DISTINCT(DiskKey)) AS DiskCount, ' +
	'ROUND((COUNT(DISTINCT(DiskKey))/CAST(' + CAST(@TotalDisk as nvarchar) + ' AS Real)), 4) AS Yield ' +
	'FROM ChartView WITH(NOLOCK) WHERE HasSignature = 1 AND Grade IS NOT NULL AND ' + @WHERESQL + ' ' +
	'GROUP BY Grade, ISNULL(' + @GROUPBY + ', ''Unknown'')' +
	' UNION ' +
	'SELECT Grade, ISNULL(' + @GROUPBY + ', ''Unknown'') AS ' + @GROUPBY + ', COUNT(DISTINCT(DiskKey)) AS DiskCount, ' +
	'ROUND((COUNT(DISTINCT(DiskKey))/CAST(' + CAST(@TotalDisk as nvarchar) + ' AS Real)), 4) AS Yield ' +
	'FROM (SELECT Grade, ISNULL(' + @GROUPBY +', ''Unknown'') AS ' + @GROUPBY +', DiskKey FROM ChartView WITH(NOLOCK) ' +
	'WHERE HasSignature = 0 AND Grade IS NOT NULL AND ' + @WHERESQL + ' ' +
	'GROUP BY DiskKey, Grade, ISNULL(' + @GROUPBY + ', ''Unknown'')' +
	' HAVING COUNT(SurfaceKey) > 1) AS T ' +
	'GROUP BY Grade, ' + @GROUPBY 
	
	--PRINT(@SQL)

	EXEC (@SQL)
END
GO


ALTER VIEW [dbo].[SingleLayerView]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, 
                      dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, 
                      dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, dbo.DDA_Results.AnalyzeTime, 
                      dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, 
                      dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, 
                      dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, 
                      dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Signatures.SignatureID, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_Grades.GradeDescription, dbo.DDA_KOI_Headers.KKLot, dbo.DDA_KOI_Headers.KKSlot, 
                      dbo.DDA_KOI_Headers.Cass_ID, dbo.DDA_EIS_Resources.Rsc725, dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, 
                      dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc600, 
                      dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, dbo.DDA_Disks.HasMeaning, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, 
                      dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806, dbo.DDA_EIS_Resources.DateTime725, dbo.DDA_EIS_Resources.DateTime769, 
                      dbo.DDA_EIS_Resources.DateTime771, dbo.DDA_EIS_Resources.DateTime764, dbo.DDA_EIS_Resources.DateTime575, 
                      dbo.DDA_EIS_Resources.DateTime450, dbo.DDA_EIS_Resources.DateTime453, dbo.DDA_EIS_Resources.DateTime600, 
                      dbo.DDA_EIS_Resources.DateTime766, dbo.DDA_EIS_Resources.DateTime01 AS DateTime0806, 
                      dbo.DDA_EIS_Resources.DateTime02 AS DateTime3806
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum LEFT OUTER JOIN
                      dbo.DDA_KOI_Headers ON dbo.DDA_Disks.SlotNum = dbo.DDA_KOI_Headers.Lot_Slot AND 
                      dbo.DDA_Disks.LotNo = dbo.DDA_KOI_Headers.Lot_Id
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
GO



ALTER VIEW [dbo].[SingleLayerViewQuery]
AS
SELECT     dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Surfaces.TestDate, dbo.DDA_Surfaces.Surface, dbo.DDA_Fabs.FabID, 
                      dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Fabs.FabUUID, dbo.DDA_Fabs.Description, dbo.DDA_Surfaces.NumberOfDefect, dbo.DDA_Surfaces.Loaded, 
                      dbo.DDA_Signatures.SignatureName, dbo.DDA_Results.SignatureKey, dbo.DDA_Results.AnalyzeTime, 
                      dbo.DDA_ResultDetail.NumberOfDefect AS NumberOfSignatureDefect, dbo.DDA_ResultDetail.PercentOfDefect AS PercentOfSignatureDefect, 
                      dbo.DDA_ResultDetail.ResultKey, dbo.DDA_ResultDetail.ResultDetailKey, dbo.DDA_Disks.L2_Top_Corr_cts, dbo.DDA_Disks.L2_Bot_Corr_cts, 
                      dbo.DDA_Disks.L2_Top_NCorr_cts, dbo.DDA_Disks.L2_Bot_NCorr_cts, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode AS Product, 
                      dbo.DDA_TesterTypes.TesterTypeID, dbo.DDA_TesterTypes.TesterType, dbo.DDA_Signatures.SignatureID, dbo.DDA_Disks.LotIDCode, 
                      dbo.DDA_Disks.BinNo, dbo.DDA_Grades.Grade, dbo.DDA_Grades.GradeDescription, dbo.DDA_EIS_Resources.Rsc725, 
                      dbo.DDA_EIS_Resources.Rsc769, dbo.DDA_EIS_Resources.Rsc771, dbo.DDA_EIS_Resources.Rsc764, dbo.DDA_EIS_Resources.Rsc575, 
                      dbo.DDA_EIS_Resources.Rsc450, dbo.DDA_EIS_Resources.Rsc600, dbo.DDA_EIS_Resources.Rsc766, dbo.DDA_EIS_Resources.Rsc453, 
                      dbo.DDA_Disks.HasMeaning, dbo.DDA_EIS_Resources.Rsc01 AS Rsc0806, dbo.DDA_EIS_Resources.Rsc02 AS Rsc3806, 
                      dbo.DDA_EIS_Resources.DateTime725, dbo.DDA_EIS_Resources.DateTime769, dbo.DDA_EIS_Resources.DateTime771, 
                      dbo.DDA_EIS_Resources.DateTime764, dbo.DDA_EIS_Resources.DateTime575, dbo.DDA_EIS_Resources.DateTime450, 
                      dbo.DDA_EIS_Resources.DateTime453, dbo.DDA_EIS_Resources.DateTime600, dbo.DDA_EIS_Resources.DateTime766, 
                      dbo.DDA_EIS_Resources.DateTime01 AS DateTime0806, dbo.DDA_EIS_Resources.DateTime02 AS DateTime3806
FROM         dbo.DDA_Grades INNER JOIN
                      dbo.DDA_GradeMapping ON dbo.DDA_Grades.GradeKey = dbo.DDA_GradeMapping.GradeKey RIGHT OUTER JOIN
                      dbo.DDA_WordCells INNER JOIN
                      dbo.DDA_Disks ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Fabs ON dbo.DDA_Disks.FabKey = dbo.DDA_Fabs.FabKey INNER JOIN
                      dbo.DDA_Surfaces ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Signatures ON dbo.DDA_Results.SignatureKey = dbo.DDA_Signatures.SignatureKey INNER JOIN
                      dbo.DDA_Products ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey LEFT OUTER JOIN
                      dbo.DDA_EIS_Resources ON dbo.DDA_Disks.LotNo = dbo.DDA_EIS_Resources.LotNum
WHERE     (dbo.DDA_Results.IsMultiLayer = 0)
GO


ALTER PROCEDURE [dbo].[_GetParetoChartDataIndividualResource_TestCell]
@WHERESQL NVARCHAR(4000),
@GROUPBY NVARCHAR(50)
AS
BEGIN
	CREATE TABLE #TEMP(	
		DiskKey bigint,
		SurfaceKey bigint,
		Grade int,
		HasSignature bit,
		TestCell nvarchar(50),
		Rsc725 varchar(10),
		Rsc769 varchar(10),
		Rsc771 varchar(10),
		Rsc764 varchar(10), 
		Rsc575 varchar(10),
		Rsc450 varchar(10),
		Rsc600 varchar(10),
		Rsc766 varchar(10),
		Rsc453 varchar(10),
		Rsc0806 varchar(10),
		Rsc3806 varchar(10))

	CREATE TABLE #GROUPBY(
		Grade int,
		GroupBy nvarchar(50),
		DiskCount int,
		Yield real)

	CREATE TABLE #VALUE(
		GroupBy nvarchar(50),
		DiskCount int)

	DECLARE @SQL NVARCHAR(4000)
	DECLARE @TotalDisk real

	SET @SQL = 'INSERT INTO #TEMP 
	SELECT DiskKey,SurfaceKey,Grade,HasSignature,TestCell,Rsc725,Rsc769,Rsc771,Rsc764,Rsc575,Rsc450,Rsc600,Rsc766,Rsc453,Rsc0806,Rsc3806 
	FROM ChartView WITH(NOLOCK) WHERE ' + @WHERESQL
	EXEC(@SQL)

	SET @TotalDisk = (SELECT COUNT(DISTINCT DiskKey) FROM #TEMP)
	IF @TotalDisk IS NULL OR @TotalDisk = 0 RETURN

	--All
	SET @SQL = 'SELECT Grade, COUNT(DISTINCT(DiskKey)) AS DiskCount, ' +
	'ROUND((COUNT(DISTINCT(DiskKey))/CAST(' + CAST(@TotalDisk as nvarchar) + ' AS Real)), 4) AS Yield ' +
	'FROM #TEMP WITH(NOLOCK) WHERE HasSignature = 1 AND Grade IS NOT NULL ' +
	'GROUP BY Grade ' +
	'UNION ' +
	'SELECT Grade, COUNT(DISTINCT(DiskKey)) AS DiskCount, ' +
	'ROUND((COUNT(DISTINCT(DiskKey))/CAST(' + CAST(@TotalDisk as nvarchar) + ' AS Real)), 4) AS Yield ' +
	'FROM (SELECT Grade, DiskKey FROM #TEMP WITH(NOLOCK) ' +
	'WHERE HasSignature = 0 AND Grade IS NOT NULL ' +
	'GROUP BY DiskKey, Grade ' +
	'HAVING COUNT(SurfaceKey) > 1) AS T ' +
	'GROUP BY Grade
	 ORDER BY DiskCount DESC'
	EXEC (@SQL)
	
	--Group By
	SET @SQL = 'INSERT INTO #GROUPBY
	SELECT Grade, ISNULL(' + @GROUPBY + ', ''Unknown'') AS ' + @GROUPBY + ', COUNT(DISTINCT(DiskKey)) AS DiskCount, ' +
	'CAST(0 AS Real) AS Yield ' +
	'FROM #TEMP WITH(NOLOCK) WHERE HasSignature = 1 AND Grade IS NOT NULL ' +
	'GROUP BY Grade, ISNULL(' + @GROUPBY + ', ''Unknown'') ' +
	'UNION ' +
	'SELECT Grade, ISNULL(' + @GROUPBY + ', ''Unknown'') AS ' + @GROUPBY + ', COUNT(DISTINCT(DiskKey)) AS DiskCount, ' +
	'CAST(0 AS Real) AS Yield ' +
	'FROM (SELECT Grade, ISNULL(' + @GROUPBY +', ''Unknown'') AS ' + @GROUPBY +', DiskKey FROM #TEMP WITH(NOLOCK) ' +
	'WHERE HasSignature = 0 AND Grade IS NOT NULL ' + 
	'GROUP BY DiskKey, Grade, ISNULL(' + @GROUPBY + ', ''Unknown'') ' +
	'HAVING COUNT(SurfaceKey) > 1) AS T ' +
	'GROUP BY Grade, ' + @GROUPBY 
	
	EXEC (@SQL)
	
	SET @SQL = 'INSERT INTO #VALUE 
	SELECT ISNULL(' + @GROUPBY + ', ''Unknown''), COUNT(DISTINCT(DiskKey)) FROM #TEMP WITH(NOLOCK)
	GROUP BY ISNULL(' + @GROUPBY + ', ''Unknown'')'
	EXEC (@SQL)

	--Update Yield
	UPDATE #GROUPBY
	SET #GROUPBY.Yield = ROUND(#GROUPBY.DiskCount / CAST(#VALUE.DiskCount AS Real), 4)
	FROM #VALUE
	WHERE #GROUPBY.GroupBy = #VALUE.GroupBy

	SELECT * FROM #GROUPBY WITH(NOLOCK)
	
	DROP TABLE #TEMP
	DROP TABLE #GROUPBY
	DROP TABLE #VALUE
END
GO

ALTER VIEW [dbo].[SingleLayerResult]
AS
SELECT  dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
                      dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
                      dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode, 
                      dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Disks.TestDiskDate, dbo.DDA_Grades.Grade, 
                      dbo.DDA_GradeMapping.GradeKey, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Surfaces.Surface, dbo.DDA_Surfaces.HasSignature
FROM         dbo.DDA_GradeMapping  WITH(NOLOCK) INNER JOIN
                      dbo.DDA_WordCells  WITH(NOLOCK) INNER JOIN
                      dbo.DDA_Disks WITH(NOLOCK) ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
                      dbo.DDA_Surfaces  WITH(NOLOCK) ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
                      dbo.DDA_Stations  WITH(NOLOCK) ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
                      dbo.DDA_ResultDetail  WITH(NOLOCK) ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
                      dbo.DDA_Results  WITH(NOLOCK) ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
                      dbo.DDA_Products  WITH(NOLOCK) ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
                      dbo.DDA_TesterTypes  WITH(NOLOCK) ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
                      dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey INNER JOIN
                      dbo.DDA_Grades  WITH(NOLOCK) ON dbo.DDA_GradeMapping.GradeKey = dbo.DDA_Grades.GradeKey
WHERE     (dbo.DDA_Results.IsMultiLayer = 0) 
			AND (NOT EXISTS
                          (SELECT     DiskKey
                            FROM          dbo.COM_DiskResponse
                            WHERE      DiskKey = dbo.DDA_Disks.DiskKey)) 
			AND (dbo.DDA_Surfaces.Processed = 1)
--ORDER BY dbo.DDA_Disks.DiskKey
GO


CREATE PROCEDURE [dbo].[spCOM_Disk]
	@Top int = 1000,
	@DiskKey bigint = 0,
	@TestCell nvarchar(50) = null
AS
BEGIN

	IF @TestCell IS NULL 
	BEGIN
		SELECT  TOP (@Top) dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
				   dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
						  dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode, 
						  dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Disks.TestDiskDate, dbo.DDA_Grades.Grade, 
						  dbo.DDA_GradeMapping.GradeKey, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Surfaces.Surface, dbo.DDA_Surfaces.HasSignature
		FROM       dbo.DDA_GradeMapping  WITH(NOLOCK) INNER JOIN
							  dbo.DDA_WordCells  WITH(NOLOCK) INNER JOIN
							  dbo.DDA_Disks WITH(NOLOCK) ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
							  dbo.DDA_Surfaces  WITH(NOLOCK) ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
							  dbo.DDA_Stations  WITH(NOLOCK) ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
							  dbo.DDA_ResultDetail  WITH(NOLOCK) ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
							  dbo.DDA_Results  WITH(NOLOCK) ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
							  dbo.DDA_Products  WITH(NOLOCK) ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
							  dbo.DDA_TesterTypes  WITH(NOLOCK) ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
							  dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey INNER JOIN
							  dbo.DDA_Grades  WITH(NOLOCK) ON dbo.DDA_GradeMapping.GradeKey = dbo.DDA_Grades.GradeKey
		WHERE    dbo.DDA_Disks.DiskKey > @DiskKey
					AND (dbo.DDA_Results.IsMultiLayer = 0) 
					AND (NOT EXISTS (SELECT DiskKey FROM dbo.COM_DiskResponse
									WHERE      (DiskKey = dbo.DDA_Disks.DiskKey))) 
					AND (dbo.DDA_Surfaces.Processed = 1)
		ORDER BY  dbo.DDA_Disks.DiskKey	
	END
	ELSE
	BEGIN
		SELECT  TOP (@Top) dbo.DDA_Disks.DiskKey, dbo.DDA_Disks.DiskID, dbo.DDA_Disks.TestGrade, dbo.DDA_Disks.SlotNum, dbo.DDA_Disks.LotNo, 
				   dbo.DDA_Disks.StationKey, dbo.DDA_Disks.WordCellKey, dbo.DDA_Disks.FabKey, dbo.DDA_Disks.InnerDiameter, dbo.DDA_Disks.OuterDiameter, 
						  dbo.DDA_WordCells.TestCell, dbo.DDA_Stations.Tester, dbo.DDA_Disks.CassetteID, dbo.DDA_Products.ProductCode, 
						  dbo.DDA_TesterTypes.TesterType, dbo.DDA_Disks.LotIDCode, dbo.DDA_Disks.BinNo, dbo.DDA_Disks.TestDiskDate, dbo.DDA_Grades.Grade, 
						  dbo.DDA_GradeMapping.GradeKey, dbo.DDA_Surfaces.SurfaceKey, dbo.DDA_Surfaces.Surface, dbo.DDA_Surfaces.HasSignature
		FROM       dbo.DDA_GradeMapping  WITH(NOLOCK) INNER JOIN
							  dbo.DDA_WordCells  WITH(NOLOCK) INNER JOIN
							  dbo.DDA_Disks WITH(NOLOCK) ON dbo.DDA_WordCells.WordCellKey = dbo.DDA_Disks.WordCellKey INNER JOIN
							  dbo.DDA_Surfaces  WITH(NOLOCK) ON dbo.DDA_Disks.DiskKey = dbo.DDA_Surfaces.DiskKey INNER JOIN
							  dbo.DDA_Stations  WITH(NOLOCK) ON dbo.DDA_Disks.StationKey = dbo.DDA_Stations.StationKey INNER JOIN
							  dbo.DDA_ResultDetail  WITH(NOLOCK) ON dbo.DDA_Surfaces.SurfaceKey = dbo.DDA_ResultDetail.SurfaceKey INNER JOIN
							  dbo.DDA_Results  WITH(NOLOCK) ON dbo.DDA_ResultDetail.ResultKey = dbo.DDA_Results.ResultKey INNER JOIN
							  dbo.DDA_Products  WITH(NOLOCK) ON dbo.DDA_Disks.ProductKey = dbo.DDA_Products.ProductKey INNER JOIN
							  dbo.DDA_TesterTypes  WITH(NOLOCK) ON dbo.DDA_Disks.TesterTypeID = dbo.DDA_TesterTypes.TesterTypeID ON 
							  dbo.DDA_GradeMapping.SignatureKey = dbo.DDA_Results.SignatureKey INNER JOIN
							  dbo.DDA_Grades  WITH(NOLOCK) ON dbo.DDA_GradeMapping.GradeKey = dbo.DDA_Grades.GradeKey
		WHERE    dbo.DDA_Disks.DiskKey > @DiskKey
					AND dbo.DDA_WordCells.TestCell = @TestCell
					AND (dbo.DDA_Results.IsMultiLayer = 0) 
					AND (NOT EXISTS (SELECT DiskKey FROM dbo.COM_DiskResponse
									WHERE      (DiskKey = dbo.DDA_Disks.DiskKey))) 
					AND (dbo.DDA_Surfaces.Processed = 1)
		ORDER BY  dbo.DDA_Disks.DiskKey	
	END
END
GO



/*
Update 2011-01-25
*/

CREATE TABLE [dbo].[DDA_ProcessedOperation](
	[RecipeKey] [int] NOT NULL,
	[SurfaceKey] [bigint] NOT NULL,
	[BreakWhenFound] [bit] NULL,
	[Finish] [bit] NULL,
 CONSTRAINT [PK_DDA_ProcessedOperation] PRIMARY KEY CLUSTERED 
(
	[RecipeKey] ASC,
	[SurfaceKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[DDA_SurfacesOperation](
	[SurfaceKey] [bigint] NOT NULL,
	[DiskKey] [bigint] NOT NULL,
	[TestDate] [datetime] NULL,
	[Surface] [tinyint] NOT NULL,
	[NumberOfDefect] [int] NULL,
	[Loaded] [bit] NULL,
	[HasSignature] [bit] NULL,
	[IsDefectList] [bit] NULL,
	[Processed] [bit] NULL,
	[Deleted] [bit] NULL,
	[ProcessingDuration] [int] NULL,
	[InsertedDate] [datetime] NULL,
	[FileName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_DDA_SurfacesOperation] PRIMARY KEY CLUSTERED 
(
	[SurfaceKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_DDA_ProcessedOperation] ON [dbo].[DDA_ProcessedOperation] 
(
	[RecipeKey] ASC,
	[SurfaceKey] ASC,
	[BreakWhenFound] ASC,
	[Finish] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

/****** Object:  Index [IX_DDA_SurfaceOperation_DiskKey]    Script Date: 01/24/2011 09:40:15 ******/
CREATE NONCLUSTERED INDEX [IX_DDA_SurfaceOperation_DiskKey] ON [dbo].[DDA_SurfacesOperation] 
(
	[DiskKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

GO
/****** Object:  Index [IX_DDA_SurfaceOperation_InsertedDate]    Script Date: 01/24/2011 09:40:41 ******/
CREATE NONCLUSTERED INDEX [IX_DDA_SurfaceOperation_InsertedDate] ON [dbo].[DDA_SurfacesOperation] 
(
	[InsertedDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = OFF) ON [PRIMARY]
GO

ALTER TABLE dbo.DDA_ProcessedOperation ADD CONSTRAINT
	FK_DDA_ProcessedOperation_DDA_SurfacesOperation FOREIGN KEY
	(
	SurfaceKey
	) REFERENCES dbo.DDA_SurfacesOperation
	(
	SurfaceKey
	) ON UPDATE  NO ACTION 
	 ON DELETE  CASCADE 
	
GO

CREATE PROCEDURE [dbo].[DDA_Processed_CheckFinished]
@SurfaceKey bigint,
@DiskKey bigint,
@result bit output
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @TesterType nvarchar(50)
	DECLARE @TesterTypeID smallint
	DECLARE @SUMP INT
	DECLARE @SUMR INT

	SELECT @TesterTypeID = TesterTypeID FROM DDA_Disks WITH(NOLOCK) WHERE DiskKey = @DiskKey
	SET @TesterType=''
	SELECT @TesterType = TesterType FROM DDA_TesterTypes WITH(NOLOCK) WHERE TesterTypeID = @TesterTypeID
	
	SELECT @SUMR = COUNT(RecipeKey) FROM DDA_Recipes WITH(NOLOCK) WHERE @TesterType LIKE TesterType + '%' 

	SELECT @SUMP = COUNT(SurfaceKey)
	FROM DDA_Processed WITH(NOLOCK) INNER JOIN DDA_Recipes ON DDA_Processed.RecipeKey=DDA_Recipes.RecipeKey
	WHERE 
		DDA_Processed.SurfaceKey = @SurfaceKey AND Finish=1
		AND @TesterType LIKE DDA_Recipes.TesterType + '%' 

	IF( @SUMR <= @SUMP AND @SUMP>0) 
		set @result = 1
	ELSE
		set @result = 0
	
END
GO


-- =============================================
-- Author:		Cang
-- Create date: 2008-12-26
-- Description:	Create Trigger for insert/update processed
-- =============================================
-- Update on 2010-01-21 for auto insert nosignature
ALTER TRIGGER [dbo].[DDA_Processed_Insert_Update]
   ON  [dbo].[DDA_Processed] 
   AFTER INSERT,UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @SurfaceKey BIGINT
	DECLARE @DiskKey BIGINT
	DECLARE @BreakWhenFound bit
	DECLARE @RecipeKey int
	DECLARE @Finised bit

	SELECT TOP 1 @SurfaceKey = SurfaceKey,@RecipeKey=RecipeKey,@BreakWhenFound = BreakWhenFound FROM inserted WHERE Finish=1

	-- Skip
	IF @SurfaceKey IS NULL RETURN

	-- Check Finish
	SET @Finised = 0
	IF (@BreakWhenFound=1) SET @Finised = 1
	ELSE
	BEGIN
		SELECT @DiskKey = DiskKey FROM DDA_Surfaces WITH(NOLOCK) WHERE SurfaceKey = @SurfaceKey
		EXEC [DDA_Processed_CheckFinished] @SurfaceKey,@DiskKey, @Finised out;
	END

	-- Last Processed
	IF ( @Finised = 1 )
	BEGIN
		-- Update Status
		UPDATE DDA_Surfaces SET Processed=1 WHERE SurfaceKey = @SurfaceKey

		-- CHECK TO INSERT NO-SIGNATURE 
		IF NOT EXISTS(SELECT * FROM DDA_ResultDetail WITH(NOLOCK) WHERE SurfaceKey = @SurfaceKey)
		BEGIN
			DECLARE @SignatureKey int
			DECLARE @DefCount int

			SET @SignatureKey = 3 -- NoSignature
			SELECT @DefCount = NumberOfDefect FROM DDA_Surfaces WITH(NOLOCK) WHERE SurfaceKey = @SurfaceKey
			IF @DefCount <=0 SET @SignatureKey = 2 -- Empty

			-- Insert DDA_Results
			INSERT INTO DDA_Results(SignatureKey,IsMultiLayer,AnalyzeTime,NumberOfDefect,PercentOfDefect)
			VALUES(@SignatureKey,0,GETDATE(),0,0)

			-- Insert DDA_ResultDetail
			INSERT INTO DDA_ResultDetail(ResultKey,SurfaceKey,NumberOfDefect,PercentOfDefect)
			VALUES(@@IDENTITY,@SurfaceKey,0,0)
		END--IF NOT EXISTS
	END--IF ( @Finised = 1 )

	-- Insert into Operation
	DELETE FROM DDA_ProcessedOperation WHERE SurfaceKey = @SurfaceKey AND RecipeKey=@RecipeKey
	INSERT INTO DDA_ProcessedOperation SELECT * FROM inserted

END
GO

CREATE TRIGGER [dbo].[trDDA_Surfaces_Insert]
  ON  [dbo].[DDA_Surfaces] 
   AFTER INSERT
AS 
BEGIN
	INSERT INTO DDA_SurfacesOperation SELECT * FROM inserted
END
GO

CREATE TRIGGER [dbo].[trDDA_Surfaces_Update]
  ON  [dbo].[DDA_Surfaces] 
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @SurfaceKey BIGINT
	DECLARE @Processed bit

	SELECT TOP 1 @SurfaceKey = SurfaceKey,@Processed = Processed FROM inserted
--DELETE FROM DDA_SurfacesOperation WHERE SurfaceKey = @SurfaceKey
--INSERT INTO DDA_SurfacesOperation SELECT * FROM inserted
	UPDATE DDA_SurfacesOperation SET Processed = @Processed WHERE SurfaceKey = @SurfaceKey
END
GO


ALTER PROCEDURE [dbo].[GET_NPROCESS_SURFACE]
	@RecipeKey INT,
	@PrevRecipeKey INT = -1,
	@Fabkey SMALLINT=0,
	@FromDate datetime = null,
	@TestGradeList varchar(1014) = null,
	@N INT
AS
BEGIN
	DECLARE @TesterType VARCHAR(255)
	SELECT @TesterType = TesterType FROM DDA_Recipes  WITH(NOLOCK) WHERE RecipeKey = @RecipeKey

	IF (@FromDate = '1900-01-01' )
		SELECT @FromDate = CreateDateTime FROM DDA_Recipes WITH(NOLOCK) WHERE RecipeKey = @RecipeKey

	IF(@TesterType IS NOT NULL)
	BEGIN
		IF(@TesterType='') SET @TesterType = NULL
	END

	DECLARE @SQL NVARCHAR(4000)



-- Check On Operation Tables	
	-- SELECT 
	SET @SQL = 'SELECT  TOP ' + CAST(@N AS VARCHAR) + ' x.SurfaceKey FROM DDA_SurfacesOperation x WITH(NOLOCK) '

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + ' INNER JOIN DDA_ProcessedOperation as y  WITH(NOLOCK) 
				ON x.SurfaceKey = y.SurfaceKey'

	IF(@Fabkey>0 OR @TesterType IS NOT NULL OR @TestGradeList IS NOT NULL )
	BEGIN
		
		SET @SQL = @SQL + ' INNER JOIN DDA_Disks WITH(NOLOCK) ON x.DiskKey = DDA_Disks.DiskKey'
		IF( @TesterType IS NOT NULL)
		BEGIN
			SET @SQL = @SQL + ' INNER JOIN DDA_TesterTypes WITH(NOLOCK) 
				ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID'
		END
	END
		
	-- WHERE
	SET @SQL = @SQL + '
	WHERE'-- x.Processed=0'
	
	IF(@FromDate IS NOT NULL) SET @SQL = @SQL + ' x.InsertedDate >= ''' + CAST(@FromDate AS VARCHAR) + ''' AND'

	IF(@TestGradeList IS NOT NULL) SET @SQL = @SQL + ' (' + @TestGradeList + ') AND'

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + ' y.RECIPEKEY = ' + CAST(@PrevRecipeKey AS NVARCHAR) + ' AND y.Finish=1 AND y.BreakWhenFound=0 AND'
	
	IF(@Fabkey>0) SET @SQL = @SQL + ' DDA_Disks.FabKey=' + CAST(@Fabkey AS NVARCHAR) + ' AND'
	
	IF(@TesterType IS NOT NULL) SET @SQL = @SQL + ' DDA_TesterTypes.TesterType LIKE ''' + @TesterType + '%'' AND'
	
	SET @SQL = @SQL + ' NOT EXISTS( SELECT p.SurfaceKey FROM DDA_ProcessedOperation p WITH(NOLOCK) WHERE RecipeKey=' + CAST(@RecipeKey AS NVARCHAR) + ' AND p.SurfaceKey=x.SurfaceKey)'

	EXECUTE sp_executesql @SQL

	IF @@ROWCOUNT > 0 
		RETURN @@ROWCOUNT



-- Check On all Tables

	-- SELECT 
	SET @SQL = 'SELECT  TOP ' + CAST(@N AS VARCHAR) + ' x.SurfaceKey FROM DDA_Surfaces x WITH(NOLOCK)'

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + ' INNER JOIN DDA_Processed as y WITH(NOLOCK) 
				ON x.SurfaceKey = y.SurfaceKey'

	IF(@Fabkey>0 OR @TesterType IS NOT NULL OR @TestGradeList IS NOT NULL )
	BEGIN
		
		SET @SQL = @SQL + ' INNER JOIN DDA_Disks WITH(NOLOCK) ON x.DiskKey = DDA_Disks.DiskKey'
		IF( @TesterType IS NOT NULL)
		BEGIN
			SET @SQL = @SQL + ' INNER JOIN DDA_TesterTypes WITH(NOLOCK)
				ON DDA_Disks.TesterTypeID = DDA_TesterTypes.TesterTypeID'
		END
	END
		
	-- WHERE
	SET @SQL = @SQL + '
	WHERE'-- x.Processed=0'
	
	IF(@FromDate IS NOT NULL) SET @SQL = @SQL + ' x.InsertedDate >= ''' + CAST(@FromDate AS VARCHAR) + ''' AND'

	IF(@TestGradeList IS NOT NULL) SET @SQL = @SQL + ' (' + @TestGradeList + ') AND'

	IF(@PrevRecipeKey > -1) SET @SQL = @SQL + ' y.RECIPEKEY = ' + CAST(@PrevRecipeKey AS NVARCHAR) + ' AND y.Finish=1 AND y.BreakWhenFound=0 AND'
	
	IF(@Fabkey>0) SET @SQL = @SQL + ' DDA_Disks.FabKey=' + CAST(@Fabkey AS NVARCHAR) + ' AND'
	
	IF(@TesterType IS NOT NULL) SET @SQL = @SQL + ' DDA_TesterTypes.TesterType LIKE ''' + @TesterType + '%'' AND'
	
	--SET @SQL = @SQL + ' x.SurfaceKey NOT IN (SELECT SurfaceKey FROM DDA_Processed WHERE RecipeKey=' + CAST(@RecipeKey AS NVARCHAR) + ')'
	SET @SQL = @SQL + ' NOT EXISTS( SELECT p.SurfaceKey FROM DDA_Processed p WITH(NOLOCK) WHERE RecipeKey=' + CAST(@RecipeKey AS NVARCHAR) + ' AND p.SurfaceKey=x.SurfaceKey)'

	EXECUTE sp_executesql @SQL



	--PRINT @SQL
END
GO


ALTER PROCEDURE [dbo].[DDA_Surfaces_UpdateHasSignatureStatus]
	@SurfaceKey bigint,
	@HasSignature bit
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @HasSignature0 bit
	SELECT @HasSignature0  = HasSignature FROM DDA_Surfaces WITH(NOLOCK) WHERE SurfaceKey = @SurfaceKey
	IF @HasSignature = @HasSignature0 RETURN

	UPDATE DDA_Surfaces SET HasSignature = @HasSignature WHERE SurfaceKey = @SurfaceKey
END
GO

CREATE PROCEDURE spDeleteOperation
@hours int = 24,
@records int = 0
AS
BEGIN
	DECLARE @BeforeDate DateTime 

	SET @BeforeDate = DATEADD( hh , -@hours , GETDATE() )

	IF @records = 0 
		DELETE FROM DDA_SurfacesOperation WHERE InsertedDate < @BeforeDate
	ELSE
	BEGIN
		DELETE DDA_SurfacesOperation
			FROM (SELECT TOP (@records) * FROM DDA_SurfacesOperation WHERE InsertedDate < @BeforeDate)
			DDA_SurfacesOperation
	END

	SELECT @@ROWCOUNT
END
GO
