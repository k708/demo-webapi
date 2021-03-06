using demo_webapi.Models.Enum;

namespace demo_webapi.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        public string Name { get; set; } = "フルーツ";
        public Season BestSeason { get; set; } = Season.Everyday;
        public int Price { get; set; } = 100;
        public int Stock { get; set; } = 0;
    }
}