namespace Rahvanov.Models
{
        public class Discipline
        {
            public int DisciplineId { get; set; }  // Первичный ключ
            public string Name { get; set; }  // Название дисциплины
            public List<Workload> Workloads { get; set; }  // Связь с нагрузками
        }
    }
