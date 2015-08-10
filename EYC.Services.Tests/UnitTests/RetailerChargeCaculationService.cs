// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests
{
	using EYC.Services.Implementations;

	using Xunit;

	public class RetailerChargeCaculationServiceUnitTests
	{
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
