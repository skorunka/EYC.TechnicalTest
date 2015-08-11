namespace EYC.Calculations.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	using DomainModels;

	public class InMemoryProductRepository : IProductRepository
	{
		private static readonly ICollection<Product> Products = new ReadOnlyCollection<Product>(new[]
												{
													new Product { SupplierName = "Supplier 1", Name = "Egg", Type = ProductType.Fresh, Quantity = 2000, Country = "Ireland", UnitPrice = 1.25m },
													new Product { SupplierName = "Supplier 1", Name = "Chicken", Type = ProductType.Fresh, Quantity = 7000, Country = "Spain", UnitPrice = 2.20m },
													new Product { SupplierName = "Supplier 1", Name = "Milk", Type = ProductType.Processed, Quantity = 9000, Country = "UK", UnitPrice = 0.79m },

													new Product { SupplierName = "Supplier 2", Name = "Soft Drink", Type = ProductType.Processed, Quantity = 3000, Country = "UK", UnitPrice = 1.00m },
													new Product { SupplierName = "Supplier 2", Name = "Juice", Type = ProductType.Fresh, Quantity = 50000, Country = "Spain", UnitPrice = 2.00m }
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

		public ICollection<Product> GetAllForSupplier(string supplierName)
		{
			var products = Products.Where(x => x.SupplierName == supplierName).ToList();
			return products;
		}
	}
}