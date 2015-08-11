// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Repositories.UnitTests.ProductRepository
{
	using System;

	using Repositories;

	using Xunit;

	public class when_finding_product
	{
		[Fact]
		public void return_existing_Product_by_SupplierName_and_ProductName()
		{
			const string supplierName = "Supplier 2";
			const string productName = "Juice";

			var repository = new InMemoryProductRepository() as IProductRepository;

			var product = repository.Find(supplierName, productName);

			Assert.NotNull(product);
			Assert.Equal(supplierName, product.SupplierName);
			Assert.Equal(productName, product.Name);
		}

		[Theory]
		[InlineData("a", "Juice")]
		[InlineData("Supplier 2", "b")]
		[InlineData("a", "b")]
		public void throw_Exception_if_Product_notfound_by_SupplierName_or_ProductName(string supplierName, string productName)
		{
			var repository = new InMemoryProductRepository() as IProductRepository;

			Assert.Throws<Exception>(() => repository.Find(supplierName, productName));
		}
	}
}
