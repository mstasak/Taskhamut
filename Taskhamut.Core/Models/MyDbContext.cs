using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Taskhamut.Core.Models;
public class MyDbContext : DbContext {
    private const string sqlLiteDbPath = @"F:\Data\Taskhamut.db";
    //private const string sqlServerConnectString = "Data Source=.;Initial Catalog=Taskhamut;Integrated Security=true;MultipleActiveResultSets=true;";

    public MyDbContext() {
    }

    public DbSet<TaskEntity> Tasks {
        get; set;
    }
    public DbSet<CategoryEntity> Categories {
        get; set;
    }
    public DbSet<UserEntity> Users {
        get; set;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        //switch (dbProvider)
        //{
        //case ProviderType.UnspecifiedProvider:
        //    throw new InvalidOperationException($"Data Provider not specified");
        //case ProviderType.SQLiteProvider:
        //    optionsBuilder.UseSqlite($"Filename={sqlLiteDbPath}");
        //    break;
        //case ProviderType.SqlServerProvider:
        //    optionsBuilder.UseSqlServer(sqlServerConnectString);
        //    break;
        //case ProviderType.MySQLProvider:
        //    break;
        //case ProviderType.PostgreSQLProvider:
        //    break;
        //case ProviderType.MariaDBProvider:
        //    break;
        //case ProviderType.MongoDBProvider:
        //    break;
        //default:
        //    throw new NotSupportedException($"Unsupported Data Provider: {dbProvider}");
        //}
        optionsBuilder.UseSqlite($"Filename={sqlLiteDbPath}");
    }
}

/*
* 
* Initial model creation from cmd prompt or nuget console: 
* 
* https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
* In Dev PowerShell panel:
* 
* F:
* cd F:\dev\WinAppSDK\Taskhamut\Taskhamut.Core
* 
* dotnet tool install --global dotnet-ef     (will print error if already installed)
* 
* dotnet tool update --global dotnet-ef     (if installed; reports error if not installed)
* 
* dotnet ef migrations add InitialCreate
*   - you may need to save all and build and then retry
*   - you may need to add package reference to Microsoft.EntityFrameworkCore.Designer
*   - you may need to manually specify the primary key column for entities which do not follow
*   naming conventions (for example, "TaskEntity" has PK TaskId)
* 
* dotnet ef database update
*   If successful, you can inspect results as follows:
*   f:
*   cd \data
*   sqlite3 taskhamut.db
*   .schema
*   .quit
*
*
* Rolling back a migration
*   dotnet ef migrations remove
*
* Starting over (brute force reset)
* To remove the database from command prompt, simple 'del f:\data\taskhamut.db' .
*   alternatively, 'dotnet ef database drop' may work the same
* Remove all migrations from the Taskhamut.Core\Migrations folder, and you can start over.
*
*/

//?TODO: Convert to singleton
//      (maybe not needed, as this is really a single-user single-thread app - just use db
//      context in a transient manner)
/* from https://csharpindepth.com/articles/singleton
public sealed class Singleton
{
    private static readonly Lazy<Singleton> lazy =
        new Lazy<Singleton>(() => new Singleton());

    public static Singleton Instance { get { return lazy.Value; } }

    private Singleton()
    {
    }
} 
 */
