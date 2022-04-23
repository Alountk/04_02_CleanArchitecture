using System;

namespace Blog.MigratorDB
{
    [Serializable]
    public class ConnectionStringCollection
    {
        public string ConnectionStringSQLServer { get; set; }
        public string ConnectionStringMySQLServer { get; set; }
        public string ConnectionStringPostgreSQLServer { get; set; }
    }
}