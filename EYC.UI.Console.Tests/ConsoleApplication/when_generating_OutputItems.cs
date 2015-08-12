// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.UI.UnitTests.ConsoleApplication
{
	using System.Collections.Generic;
	using System.Linq;

	using Calculations.Repositories;
	using Calculations.Rules;
	using Calculations.Services;
	using Console;
	using Console.Dtos;

	using Xunit;

	public class when_generating_OutputItems
	{
		[Fact]
		public void return_specific_OutputItems_for_Supplier2()
		{
			const string supplierName = "Supplier 2";

			var expectedResult = new List<OutputItem>
									 {
										 new OutputItem { ProductName = "Soft Drink", Total = 3000.00m, RetailerCharge = 120.00m },
										 new OutputItem { ProductName = "Juice", Total = 100000.00m, RetailerCharge = 5000.00m },
									 };

			var productChargeRules = Rules.ProductChargeRules;
			var productChargeCalculationService = new ProductChargeCalculationService(productChargeRules) as IProductChargeCalculationService;
			var retailerChargeCaculationService = new RetailerChargeCaculationService(productChargeCalculationService) as IRetailerChargeCaculationService;
			var productRepository = new InMemoryProductRepository() as IProductRepository;
			var application = new ConsoleApplication(retailerChargeCaculationService, productRepository) as IConsoleApplication;

			var outputItems = application.Run(supplierName).ToList();

			//// TODO: I can't figure out why this Assertion does not work?! xUnit BUG?
			//// Assert.Equal(expectedResult, outputItems);

			//// fix for "Assert.Equal(expectedResult, outputItems)"
			for (var i = 0; i < expectedResult.Count; i++)
			{
				Assert.True(expectedResult[i].RetailerCharge == outputItems[i].RetailerCharge);
				Assert.True(expectedResult[i].Total == outputItems[i].Total);
				Assert.True(expectedResult[i].ProductName == outputItems[i].ProductName);
			}
		}
	}
}