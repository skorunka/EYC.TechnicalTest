// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests
{
	using System;

	using EYC.Services.Implementations;

	using Xunit;

	public class RetailerChargeCaculationServiceUnitTests
	{
		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_SupplierId_is_NullOrEmptyOrWhitespace(string supplierId)
		{
			var productName = "Juice";

			var service = new RetailerChargeCaculationService() as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, productName));
		}

		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_ProductName_is_NullOrEmptyOrWhitespace(string productName)
		{
			var supplierId = "SupplierTwo";

			var service = new RetailerChargeCaculationService() as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, productName));
		}

		[Fact]
		public void return_5000_for_SupplierTwo_and_Juice()
		{
			var expectedResult = 5000m;
			var supplierId = "SupplierTwo";
			var productName = "Juice";

			var service = new RetailerChargeCaculationService() as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, productName);

			Assert.Equal(expectedResult, result);
		}
	}
}
