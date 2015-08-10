namespace EYC.Services.Tests.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	using DomainModels;

	public class TestProductRepository : IProductRepository
	{
		private static readonly ICollection<Product> Products = new ReadOnlyCollection<Product>(new[]
												{
													new Product { SupplierName = "Supplier 2", Name = "Juice", Quantity = 50000, UnitPrice = 2.00m },
													new Product { SupplierName = "Supplier 2", Name = "Soft Drink", Quantity = 3000, UnitPrice = 1.00m }
												});

		public Product Find(string supplierName, string productName)
		{
			var product = Products.FirstOrDefault(x => x.SupplierName == supplierName && x.Name == productName);

			if (product == null)
			{
				throw new Exception($"Product \"{productName}\" for Supplier \"{supplierName}\" not found.");
			}

			return product;
		}
	}
}