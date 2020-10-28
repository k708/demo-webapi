namespace demo_webapi.Models.Dtos.Fruit
{
    public class GetFruitDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "フルーツ";
        public int Price { get; set; } = 100;
    }
}