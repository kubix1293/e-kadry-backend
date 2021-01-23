namespace EKadry.Infrastructure.Database
{
    public static class SchemaNames
    {
        public const string Table = "KADRY";
        public const string Operators = "OPER";
        public const string Workers = "PRACOWNICY";
        public const string JobPostions = "STANOW";
        public const string Contracts = "UMOWY";
        public const string Pkzp = "PKZP";
        public const string PkzpPositions = "PKZP_POZ";
        public const string PkzpSchedule = "PKZP_HARM";
        public const string Period = "OKRESY";

        public static string SchemaWithTable(string schema)
        {
            return $"{Table}.{schema}";
        }
    }
}