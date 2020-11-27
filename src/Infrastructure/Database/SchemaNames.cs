namespace EKadry.Infrastructure.Database
{
    public static class SchemaNames
    {
        public const string Table = "KADRY";
        public const string Operators = "OPER";

        public static string SchemaWithTable(string schema)
        {
            return $"{Table}.{schema}";
        }
    }
}