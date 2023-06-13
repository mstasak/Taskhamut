using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Taskhamut.Core.Models;
public class MyDbContext : DbContext
{
    private const string sqlLiteDbPath = @"F:\Data\Taskhamut.db";
    //private const string sqlServerConnectString = "Data Source=.;Initial Catalog=Taskhamut;Integrated Security=true;MultipleActiveResultSets=true;";

    public MyDbContext()
    {
    }

    public DbSet<TaskEntity> Tasks
    {
        get; set;
    }
    public DbSet<CategoryEntity> Categories
    {
        get; set;
    }
    public DbSet<UserEntity> Users
    {
        get; set;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //switch (dbProvider)
        //{
            //case ProviderType.UnspecifiedProvider:
            //    throw new InvalidOperationException($"Data Provider not specified");
            //case ProviderType.SQLiteProvider:
                optionsBuilder.UseSqlite($"Filename={sqlLiteDbPath}"); //.UseSqlite($"Filename={sqlLiteDbPath}");
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
    }
}
