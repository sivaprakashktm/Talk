using Microsoft.Data.SqlClient;
using TalkService.Model;

namespace TalkService.Context
{
    public class DbContext
    {
        private readonly string? connectionString;
        public DbContext(TalkConfiguration talkConfiguration) 
        {
            this.connectionString = talkConfiguration.TalkappConnectionString;
        }

        public SqlConnection? GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
