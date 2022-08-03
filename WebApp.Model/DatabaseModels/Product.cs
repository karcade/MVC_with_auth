namespace WebApp.Model.DatabaseModels
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Products")]
    public class Product
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
