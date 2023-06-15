# Taskhamut

This solution implements a fairly simple single page task list.  This will be a learning/practice project for me, but might provide a useful example resource to other learners.

Status: preliminary, nothing working yet


# Uses:

  * Visual Studio 2022 CE 17.6.2 (or newer)
  * .Net 7
  * C# 10
    * Nullable Reference Types enabled
  * SQLite 3.X
  * Entity Framework Core 7
    * Code-first db scaffolding
  * Windows App SDK 1.3
    * Template Studio
      * Dependency injection
      * MVVM
        * Windows Community Toolkit 7.0
          * RelayCommand functionality to forward events from View to ViewModel (per MVVM desire to minimize code in view's codebehind files and resulting coupling).
  
# Not using/implementing
  * localization/internationalization
  * testing/TDD

# UI Summary
  * Tabbed navigator
    * viewing/editing tasks
    * creating/selecting user
    * managing task categories
    * user options
    * about info

# Back end summary
  Back end is a SQLite database, although I would like to make this switchable to any common database - except for the added overhead and complexity.  SQL Server [Express|Desktop], MySQL/MariaDB, PostgreSQL, MongoDB, Cassandra, etc.  Allowing somewhat arbitrary ODBC or JDBC database connections would be an interesting feat.

# Possible future additions
  * Segregating tasks into projects
  * Due dates
  * Prioritizations
  * Recurring tasks
  For now, spplying  KISS (Keeping It Simple, Stupid).  There are enough cheap or free, full-featured task/todo managers out there!
