using System;

namespace GroupWebApplication.Models
{
    public class DatabaseConnection
    {
        public readonly string ConnectionString = "Server=tcp:csd412project.database.windows.net,1433;" +
                                                  "Initial Catalog=NasaProject;Persist Security Info=False;" +
                                                  "User ID=bleierzapf;Password=csd412Password;MultipleActiveResultSets=False;" +
                                                  "Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}