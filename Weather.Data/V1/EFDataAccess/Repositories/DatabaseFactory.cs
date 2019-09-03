using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace Weather.Data.V1
{
    public static class ConnectionTools
    {
        public static void ChangeDatabaseConnection(
                this DbContext source,
                string connectionString)
            /* this would be used if the
            *  connectionString name varied from 
            *  the base EF class name */
        {
            try
            {
                // now flip the properties that were changed
                source.Database.GetDbConnection().ConnectionString
                    = connectionString;
            }
            catch (Exception )
            {
                // set log item if required
            }
        }
    }

    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly DbContext _dataContext;
        public string Prefix;

        public DatabaseFactory( string prefix = "", string connectionstring = "")
        {
            Prefix = prefix;
            _dataContext = new DataContext(prefix);
            if (!string.IsNullOrEmpty(connectionstring))
            {
                _dataContext.ChangeDatabaseConnection(connectionstring);
            }

            // Get randomize Id
            var random = new Random(DateTime.Now.Millisecond);
            Id = random.Next(1000000).ToString();
        }

        public string Id { get; set; }

        public DbContext GetDbContext()
        {
            return _dataContext;
        }

        public string GetPrefix()
        {
            return Prefix;
        }
    }
}