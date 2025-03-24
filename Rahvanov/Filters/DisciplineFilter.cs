namespace Rahvanov.Filters
{
    public class DisciplineFilter
    {
        public string TeacherName { get; set; } // часть ФИО преподавателя
        public int? MinHours { get; set; }
        public int? MaxHours { get; set; }
    }
}
