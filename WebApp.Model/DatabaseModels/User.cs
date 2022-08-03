namespace WebApp.Model.DatabaseModels
{
	[System.ComponentModel.DataAnnotations.Schema.Table("Users")]
	public class User
    {
		[System.ComponentModel.DataAnnotations.Key]
		public int Id { get; set; }
		public string Username { get; set; }
		public byte[] PasswordHash { get; set; }
		public byte[] PasswordSalt { get; set; }
		public string RefreshToken { get; set; }
		public DateTime TokenCreated { get; set; }
		public DateTime TokenExpires { get; set; }
		public List<Product>? Posts { get; set; }
	}
}
