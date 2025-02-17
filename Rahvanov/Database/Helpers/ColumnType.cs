namespace Rahvanov.Database.Helpers
{
    public static class ColumnType
    {
        public const string Date = "date";            // Дата без времени
        public const string Guid = "uuid";            // Уникальный идентификатор
        public const string String = "varchar";       // Строки (текст)
        public const string Text = "text";            // Большой текст
        public const string Bool = "bool";            // Логический тип
        public const string Int = "int";              // Целые числа
        public const string Long = "bigint";          // Большие числа
        public const string Decimal = "money";        // Денежный тип
        public const string Double = "numeric(10,2)"; // Десятичные числа
    }

}
