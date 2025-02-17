namespace Rahvanov.Models
{
        public class AcademicDegree
        {
            public int AcademicDegreeId { get; set; }  // Первичный ключ
            public string Name { get; set; }  // Название степени
            public List<Teachers> Teachers { get; set; }  // Связь с преподавателями
        }
    }

