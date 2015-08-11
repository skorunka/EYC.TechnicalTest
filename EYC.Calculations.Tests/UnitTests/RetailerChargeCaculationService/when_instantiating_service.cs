// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Services.UnitTests.RetailerChargeCaculationService
{
	using System;

	using Services;

	using Xunit;

	public class when_instantiating_service
	{
		[Fact]
		public void throw_ArgumentNullException_if_ProductChargeCalculationService_is_null()
		{
			Assert.Throws<ArgumentNullException>(() => new RetailerChargeCaculationService(null));
		}
	}
}