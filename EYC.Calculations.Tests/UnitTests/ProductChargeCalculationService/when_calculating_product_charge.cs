// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Services.UnitTests.ProductChargeCalculationService
{
	using DomainModels;
	using Rules;
	using Services;

	using Xunit;

	public class when_calculating_product_charge
	{
		[Theory]
		[InlineData(0), InlineData(666), InlineData(1000)]
		public void return_6_for_ProductQuantity_between_0_and_1000(int quantity)
		{
			const decimal expectedResult = 6.0m;
			Assert.Equal(expectedResult, CalculateProductChargeForQuantity(quantity));
		}

		[Theory]
		[InlineData(1001), InlineData(1666), InlineData(5000)]
		public void return_4_for_ProductQuantity_between_1001_and_5000(int quantity)
		{
			const decimal expectedResult = 4.0m;
			Assert.Equal(expectedResult, CalculateProductChargeForQuantity(quantity));
		}

		[Theory]
		[InlineData(5001), InlineData(6666)]
		public void return_3_for_ProductQuantity_over_5000(int quantity)
		{
			const decimal expectedResult = 3.0m;
			Assert.Equal(expectedResult, CalculateProductChargeForQuantity(quantity));
		}

		[Fact]
		public void return_1_for_ProductCountry_non_UK()
		{
			const decimal expectedResult = 1.0m;

			var product = new Product { Country = "DE", Type = ProductType.Processed, Quantity = -1 };
			var productChargeRules = Rules.ProductChargeRules;
			var service = new ProductChargeCalculationService(productChargeRules) as IProductChargeCalculationService;

			var result = service.CalculateProductCharge(product);

			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void return_1_for_ProductType_Fresh()
		{
			const decimal expectedResult = 1.0m;

			var product = new Product { Country = "UK", Type = ProductType.Fresh, Quantity = -1 };
			var productChargeRules = Rules.ProductChargeRules;
			var service = new ProductChargeCalculationService(productChargeRules) as IProductChargeCalculationService;

			var result = service.CalculateProductCharge(product);

			Assert.Equal(expectedResult, result);
		}

		private static decimal CalculateProductChargeForQuantity(int quantity)
		{
			var product = new Product { Quantity = quantity, Type = ProductType.Processed, Country = "UK" };
			var productChargeRules = Rules.ProductChargeRules;
			var service = new ProductChargeCalculationService(productChargeRules) as IProductChargeCalculationService;

			return service.CalculateProductCharge(product);
		}
	}
}