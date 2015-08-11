// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests.ProductChargeCalculationService
{
	using System.Collections.Generic;

	using DomainModels;

	using EYC.Services.Rules;

	using Implementations;

	using Xunit;

	public class when_calculating_product_charge
	{
		[Theory]
		[InlineData(0), InlineData(666), InlineData(1000)]
		public void return_6_for_ProductQuantity_between_0_and_1000(int quantity)
		{
			const decimal expectedResult = 6.0m;
			Assert.Equal(expectedResult, CalculateProductCharge(quantity));
		}

		[Theory]
		[InlineData(1001), InlineData(1666), InlineData(5000)]
		public void return_4_for_ProductQuantity_between_1001_and_5000(int quantity)
		{
			const decimal expectedResult = 4.0m;
			Assert.Equal(expectedResult, CalculateProductCharge(quantity));
		}

		[Theory]
		[InlineData(5001), InlineData(6666)]
		public void return_3_for_ProductQuantity_greater_5001(int quantity)
		{
			const decimal expectedResult = 3.0m;
			Assert.Equal(expectedResult, CalculateProductCharge(quantity));
		}

		private static decimal CalculateProductCharge(int quantity)
		{
			var product = new Product { Quantity = quantity };
			var productChargeRules = new List<IChargeRule<Product>>
										 {
											 new ChargeRule<Product>(6, x => x.Quantity >= 0 && x.Quantity <= 1000),
											 new ChargeRule<Product>(4, x => x.Quantity >= 1001 && x.Quantity <= 5000),
											 new ChargeRule<Product>(3, x => x.Quantity >= 5001),
										 };
			var service = new ProductChargeCalculationService(productChargeRules) as IProductChargeCalculationService;

			return service.CalculateProductCharge(product);
		}
	}
}