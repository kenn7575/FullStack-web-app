namespace DA
{
    public abstract class DatabaseAccess
    {
        public DatabaseAccess(){
            ConnectionString = "Server=10.130.54.79;" +
            "Database=Buisness;" +
               "Uid=sa;" +
               "Password=1234";
        }
        public static string? ConnectionString { get; private set; }
    }
}