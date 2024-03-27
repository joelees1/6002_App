using Supabase;

namespace JL_CW_App
{
    public static class Constants
    {
        public static string RestEndpointBase = "https://newsdata.io/api/1";

        public static class Endpoints
        {
            public static string News = "/news";
        }
        
          public const SQLite.SQLiteOpenFlags Flags =
                // open the database in read/write mode
                SQLite.SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                SQLite.SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLite.SQLiteOpenFlags.SharedCache;
        
        public const string DatabaseFilename = "DemoDatabase.db3";

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}