namespace TPCOUR5.Models
{
	public class  Product
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal price { get; set; }
		public int Stock {  get; set; }
		public int SalePrice { get; set; }

		public Guid CategoryId { get; set; }

		public Category Category { get; set; }
		 public Guid MarqueId { get; set; }
		public Marque Marque { get; set; }

	}
}
