use master 
go
exec sp_defaultdb "sa","master"
go
exec sp_detach_db [#DBNAME],'true'
go
