// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.UI.UnitTests.ConsoleApplication
{
	using System;

	using Calculations.Repositories;
	using Calculations.Services;
	using Console;

	using Moq;

	using Xunit;

	public class when_instantiating_application
	{
		[Fact]
		public void throw_ArgumentNullException_if_RetailerChargeCaculationService_is_null()
		{
			Assert.Throws<ArgumentNullException>(() => new ConsoleApplication(null, new InMemoryProductRepository()));
		}

		[Fact]
		public void throw_ArgumentNullException_if_ProductRepository_is_null()
		{
			var retailerChargeCaculationServiceMock = new Mock<IRetailerChargeCaculationService>();

			Assert.Throws<ArgumentNullException>(() => new ConsoleApplication(retailerChargeCaculationServiceMock.Object, null));
		}
	}
}