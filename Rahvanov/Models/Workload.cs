namespace Rahvanov.Models
{
        public class Workload
        {
            public int WorkloadId { get; set; }  // Первичный ключ
            public int DisciplineId { get; set; }
            public Discipline Discipline { get; set; }

            public int TeacherId { get; set; }
            public Teachers Teacher { get; set; }

            public int Hours { get; set; }  // Количество часов нагрузки
        }
    }
