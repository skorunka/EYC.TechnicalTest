// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Services.UnitTests.RetailerChargeCaculationService
{
	using System;
	using System.Collections.Generic;

	using DomainModels;
	using Implementations;
	using Tests.Repositories;

	using Xunit;

	public class when_calculating_retailer_charge
	{
		private static readonly IReadOnlyCollection<IChargeRule<Product>> ProductChargeRules = new List<IChargeRule<Product>>
										 {
											 new ChargeRule<Product>(6, x => x.Quantity >= 0 && x.Quantity <= 1000),
											 new ChargeRule<Product>(4, x => x.Quantity >= 1001 && x.Quantity <= 5000),
											 new ChargeRule<Product>(3, x => x.Quantity >= 5001),
											 new ChargeRule<Product>(1, x => x.Country != "UK"),
											 new ChargeRule<Product>(1, x => x.Type == ProductType.Fresh)
										 };

		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_SupplierId_is_NullOrEmptyOrWhitespace(string supplierId)
		{
			const string productName = "Juice";

			var repository = new TestProductRepository();
			var productChargeCalculationService = new ProductChargeCalculationService(ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(repository, productChargeCalculationService) as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, productName));
		}

		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_ProductName_is_NullOrEmptyOrWhitespace(string productName)
		{
			const string supplierId = "SupplierTwo";

			var repository = new TestProductRepository();
			var productChargeCalculationService = new ProductChargeCalculationService(ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(repository, productChargeCalculationService) as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, productName));
		}

		[Fact]
		public void return_5000_for_Supplier2_and_Juice()
		{
			var expectedResult = 5000m;
			var supplierId = "Supplier 2";
			var productName = "Juice";

			var repository = new TestProductRepository();
			var productChargeCalculationService = new ProductChargeCalculationService(ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(repository, productChargeCalculationService) as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, productName);

			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void return_120_for_Supplier2_and_SoftDrink()
		{
			var expectedResult = 120m;
			var supplierId = "Supplier 2";
			var productName = "Soft Drink";

			var repository = new TestProductRepository();
			var productChargeCalculationService = new ProductChargeCalculationService(ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(repository, productChargeCalculationService) as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, productName);

			Assert.Equal(expectedResult, result);
		}
	}
}
