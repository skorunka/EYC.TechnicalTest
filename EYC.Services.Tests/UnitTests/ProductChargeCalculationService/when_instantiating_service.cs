// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests.ProductChargeCalculationService
{
	using System;

	using Implementations;

	using Xunit;

	public class when_instantiating_service
	{
		[Fact]
		public void throw_ArgumentNullException_if_ProductChargeRules_is_null()
		{
			Assert.Throws<ArgumentNullException>(() => new ProductChargeCalculationService(null));
		}
	}
}