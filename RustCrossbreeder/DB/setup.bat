@call :setup 2>&1 >> setup_log.txt
@PAUSE
@exit /b

:setup

sqllocaldb create RustCrossbreeder 11.0
sqllocaldb start RustCrossbreeder

sqlcmd -S (localdb)\TitanEDMLocal -i "%~dp0\RustCrossbreeder_SetupTables.sql"
sqlcmd -S (localdb)\TitanEDMLocal -i "%~dp0\RustCrossbreeder_SetupProcedures.sql"
sqlcmd -S (localdb)\TitanEDMLocal -i "%~dp0\RustCrossbreeder_SetupData.sql"
