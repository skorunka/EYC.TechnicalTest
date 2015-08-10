// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests
{
	using System;

	using EYC.Services.Implementations;
	using EYC.Services.Tests.Repositories;

	using Xunit;

	public class RetailerChargeCaculationServiceUnitTests
	{
		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_SupplierId_is_NullOrEmptyOrWhitespace(string supplierId)
		{
			var productName = "Juice";

			var repository = new TestProductRepository();
			var service = new RetailerChargeCaculationService(repository) as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, productName));
		}

		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_ProductName_is_NullOrEmptyOrWhitespace(string productName)
		{
			var supplierId = "SupplierTwo";

			var repository = new TestProductRepository();
			var service = new RetailerChargeCaculationService(repository) as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, productName));
		}

		[Fact]
		public void return_5000_for_Supplier2_and_Juice()
		{
			var expectedResult = 5000m;
			var supplierId = "Supplier 2";
			var productName = "Juice";

			var repository = new TestProductRepository();
			var service = new RetailerChargeCaculationService(repository) as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, productName);

			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void return_120_for_Supplier2_and_SoftDrink()
		{
			var expectedResult = 1200m;
			var supplierId = "Supplier 2";
			var productName = "Soft Drink";

			var repository = new TestProductRepository();
			var service = new RetailerChargeCaculationService(repository) as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, productName);

			Assert.Equal(expectedResult, result);
		}
	}
}
