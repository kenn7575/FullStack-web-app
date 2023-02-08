namespace DA
{
    public class DatabaseAccess
    {
        public DatabaseAccess(){
            ConnectionString = "Server=localhost;" +
            "Database=Buisness;" +
               "UID=sa;" +
               "Password=1234";
        }
        public static string? ConnectionString { get; private set; }
    }
}