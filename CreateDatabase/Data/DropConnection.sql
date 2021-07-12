USE master
GO
DECLARE
@p_SPID int,
@p_SQL nvarchar(2000)
DECLARE #cur_Processes CURSOR FOR
SELECT
p.SPID
FROM 
master.dbo.sysprocesses AS p
JOIN master.dbo.sysdatabases AS d ON( d.dbid = p.dbid )
WHERE
d.Name = '#DBNAME'
OPEN #cur_Processes
FETCH NEXT FROM #cur_Processes INTO @p_SPID
WHILE @@FETCH_STATUS = 0 
     BEGIN
    SET @p_SQL = 'KILL ' + CONVERT( nvarchar(30), @p_SPID )
    PRINT @p_SQL
    EXECUTE( @p_SQL )
    FETCH NEXT FROM #cur_Processes INTO @p_SPID
END

CLOSE #cur_Processes
DEALLOCATE #cur_Processes