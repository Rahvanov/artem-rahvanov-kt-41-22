namespace Rahvanov.Models
{
        public class Position
        {
            public int PositionId { get; set; }  // Первичный ключ
            public string Name { get; set; }  // Название должности
            public List<Teachers> Teachers { get; set; }  // Связь с преподавателями
        }
    }
