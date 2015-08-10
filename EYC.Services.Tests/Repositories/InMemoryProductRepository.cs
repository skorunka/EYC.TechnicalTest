namespace EYC.Services.Tests.Repositories
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	using EYC.DomainModels;

	public class InMemoryProductRepository : IRepository<Product>
	{
		private static readonly ICollection<Product> Products = new ReadOnlyCollection<Product>(new[]
												{
													new Product { Id = "Juice" },
													new Product { Id = "Soft Drink" }
												});

		public Product Find(string productId)
		{
			var product = Products.FirstOrDefault(x => x.Id == productId);

			if (product == null)
			{
				throw new Exception($"Product \"{productId}\" not found.");
			}

			return product;
		}
	}
}