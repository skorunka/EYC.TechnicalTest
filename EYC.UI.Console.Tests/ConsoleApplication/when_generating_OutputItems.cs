// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.UI.UnitTests.ConsoleApplication
{
	using System.Collections.Generic;

	using Calculations.Repositories;
	using Calculations.Rules;
	using Calculations.Services;
	using Console;
	using Console.Dtos;
	using DomainModels;

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

			var productChargeRules = new List<IChargeRule<Product>>
										 {
											 new ChargeRule<Product>(6, x => x.Quantity >= 0 && x.Quantity <= 1000),
											 new ChargeRule<Product>(4, x => x.Quantity >= 1001 && x.Quantity <= 5000),
											 new ChargeRule<Product>(3, x => x.Quantity >= 5001),
											 new ChargeRule<Product>(1, x => x.Country != "UK"),
											 new ChargeRule<Product>(1, x => x.Type == ProductType.Fresh)
										 };

			var productChargeCalculationService = new ProductChargeCalculationService(productChargeRules) as IProductChargeCalculationService;
			var retailerChargeCaculationService = new RetailerChargeCaculationService(productChargeCalculationService) as IRetailerChargeCaculationService;
			var productRepository = new InMemoryProductRepository() as IProductRepository;
			var application = new ConsoleApplication(retailerChargeCaculationService, productRepository) as IConsoleApplication;
			var outputItems = application.Run(supplierName);

			Assert.Equal(expectedResult, outputItems);
		}
	}
}