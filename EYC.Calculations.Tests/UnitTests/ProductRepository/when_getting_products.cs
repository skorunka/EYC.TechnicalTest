// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Repositories.UnitTests.ProductRepository
{
	using System.Linq;

	using Repositories;

	using Xunit;

	public class when_getting_products
	{
		[Fact]
		public void return_all_Products_for_Supplier_by_SupplierName()
		{
			const string supplierName = "Supplier 2";

			var repository = new InMemoryProductRepository() as IProductRepository;

			var products = repository.GetAllForSupplier(supplierName);

			Assert.NotNull(products);
			Assert.Equal(products.Count, 2);
			Assert.True(products.All(x => x.SupplierName == supplierName));
		}
	}
}
