# Taskhamut

This single-project solution implements a fairly simple single page task list.  This will be a learning/practice project for me, but might provide a useful example resource to other learners.

Status: preliminary, nothing working yet


Uses: Visual Studio 2022 CE 17.6.2, .Net 7, Entity Framework Core 7, C# 10 with Nullable Reference Types enabled, SQLite 3.X, Windows App SDK, Template Studio

Also using: dependency injection, MVVM, code first db scaffolding

Not using/implementing: localization/internationalization

Undetermined usage: WinAppSDK Community Toolkit


UI Summary: Tabbed navigator offers areas for viewing/editing tasks, creating/selecting user, managing task categories, user options, and about info.

Back end summary: Back end is a SQLite database, although I would like to make this switchable to any common database - except for the added overhead and complexity.  SQL Server [Express|Desktop], MySQL/MariaDB, PostgreSQL, MongoDB, Cassandra, etc.  Allowing somewhat arbitrary ODBC or JDBC database connections would be an interesting feat.


Possible future additions include segregating tasks into projects, due dates, prioritizations, recurring tasks.

For now, Keeping It Simple, Stupid.
