CREATE DATABASE [#DBNAME]  ON 
(NAME = N'DDADB_Data', FILENAME = N'#NAME\#DBNAME_Data.MDF' , SIZE = 50, MAXSIZE = UNLIMITED,  FILEGROWTH = 100MB ) 
LOG ON 
(NAME = N'DDADB_Log', FILENAME = N'#NAME\#DBNAME_Log.LDF' , SIZE = 5,  MAXSIZE = 10GB, FILEGROWTH = 10MB)

GO
ALTER DATABASE [#DBNAME] SET RECOVERY SIMPLE