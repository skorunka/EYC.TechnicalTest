namespace EYC.DomainModels
{
	public class Product
	{
		public string SupplierName { get; set; }

		public string Name { get; set; }

		public ProductType Type { get; set; }

		public int Quantity { get; set; }

		public string Country { get; set; }

		public decimal UnitPrice { get; set; }
	}
}
