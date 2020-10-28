using demo_webapi.Models.Enum;

namespace demo_webapi.Models.Dtos.Fruit
{
    public class AddFruitDto
    {
        public string Name { get; set; } = "フルーツ";
        public Season BestSeason { get; set; } = Season.Everyday;
        public int Price { get; set; } = 100;
        public int Stock { get; set; } = 0;
    }
}