namespace Rahvanov.Filters.TeacherFilters
{
    public class DepartmentFullFilter
    {
        public DateTime? FoundedAfter { get; set; }
        public DateTime? FoundedBefore { get; set; }
        public int? MinTeachersCount { get; set; }
        public int? MaxTeachersCount { get; set; }
    }
}
