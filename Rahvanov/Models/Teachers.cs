using Rahvanov.Models;

namespace Rahvanov.Models
{
    public class Teachers
    {
        public int TeacherId { get; set; }  // Первичный ключ
        public string FullName { get; set; }  // ФИО преподавателя

        // Внешние ключи
        public int AcademicDegreeId { get; set; }
        public AcademicDegree AcademicDegree { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Workload> Workloads { get; set; }  // Связь с нагрузками
    }
}
