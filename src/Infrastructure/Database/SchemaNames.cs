namespace EKadry.Infrastructure.Database
{
    public static class SchemaNames
    {
        public const string Table = "KADRY";
        public const string Operators = "OPER";
        public const string Workers = "PRACOWNICY";
        public const string Contracts = "UMOWY";
        public const string Pkzp = "PKZP";

        public static string SchemaWithTable(string schema)
        {
            return $"{Table}.{schema}";
        }
    }
}