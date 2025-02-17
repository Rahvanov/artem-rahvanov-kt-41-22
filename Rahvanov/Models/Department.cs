namespace Rahvanov.Models
{
        public class Department
        {
            public int DepartmentId { get; set; }  // Первичный ключ
            public string Name { get; set; }  // Название кафедры
            public DateTime FoundationYear { get; set; }  // Год основания

            // Заведующий кафедрой (связь один-к-одному с преподавателем)
            public int HeadTeacherId { get; set; }
            public Teachers HeadTeacher { get; set; }

            public List<Teachers> Teachers { get; set; }  // Преподаватели на кафедре
        }
    }
