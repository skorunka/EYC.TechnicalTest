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
													new Product { SupplierName = "Supplier 2", Name = "Juice" },
													new Product { SupplierName = "Supplier 2", Name = "Soft Drink" }
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