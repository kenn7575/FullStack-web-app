namespace DA
{
    public class DatabaseAccess
    {
        public DatabaseAccess(){
            Database = "MyDatabase";
        }
        public static string Database { get; private set; }
    }
}