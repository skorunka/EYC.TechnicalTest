// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests
{
	using System;

	using EYC.DomainModels;
	using EYC.Services.Tests.Repositories;

	using Xunit;

	public class ProductRepositoryUnitTests
	{
		[Fact]
		public void find_existing_Product_by_ProductId()
		{
			var productId = "Juice";

			var repository = new InMemoryProductRepository() as IRepository<Product>;

			Product product = repository.Find(productId);

			Assert.NotNull(product);
			Assert.Equal(productId, product.Id);
		}

		[Fact]
		public void throw_Exception_if_Product_notfound_by_ProductId()
		{
			var productId = "xxx";

			var repository = new InMemoryProductRepository() as IRepository<Product>;

			Assert.Throws<Exception>(() => repository.Find(productId));
		}

		[Fact]
		public void return_Juice_where_TypeIsFresh_QuantityIs50000_CountryIsSpain_UnitPriceIs2()
		{
		}
	}
}
