// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Services.UnitTests.RetailerChargeCaculationService
{
	using System;
	using System.Collections.Generic;
	using System.Security.Cryptography.X509Certificates;

	using DomainModels;
	using Rules;
	using Services;

	using Xunit;

	public class when_calculating_retailer_charge
	{
		[Theory]
		[InlineData(null), InlineData(""), InlineData("  "), InlineData("\n \t")]
		public void throw_ArgumentException_when_SupplierId_is_NullOrEmptyOrWhitespace(string supplierId)
		{
			var product = new Product { Name = "Juice" };

			var productChargeCalculationService = new ProductChargeCalculationService(Rules.ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(productChargeCalculationService) as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, product));
		}

		[Fact]
		public void throw_ArgumentNullException_when_Product_is_Null()
		{
			const string supplierId = "SupplierTwo";

			var productChargeCalculationService = new ProductChargeCalculationService(Rules.ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(productChargeCalculationService) as IRetailerChargeCaculationService;

			Assert.Throws<ArgumentException>(() => service.CalculateRetailerCharge(supplierId, null));
		}

		[Fact]
		public void return_5000_for_Supplier2_and_Juice()
		{
			var expectedResult = 5000m;
			var supplierId = "Supplier 2";
			var product = new Product
			{
				Name = "Juice",
				SupplierName = "Supplier 2",
				Type = ProductType.Fresh,
				Quantity = 50000,
				Country = "Spain",
				UnitPrice = 2.00m
			};

			var productChargeCalculationService = new ProductChargeCalculationService(Rules.ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(productChargeCalculationService) as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, product);

			Assert.Equal(expectedResult, result);
		}

		[Fact]
		public void return_120_for_Supplier2_and_SoftDrink()
		{
			var expectedResult = 120m;
			var supplierId = "Supplier 2";
			var product = new Product
			{
				Name = "Soft Drink",
				SupplierName = "Supplier 2",
				Type = ProductType.Processed,
				Quantity = 3000,
				Country = "UK",
				UnitPrice = 1.00m
			};

			var productChargeCalculationService = new ProductChargeCalculationService(Rules.ProductChargeRules) as IProductChargeCalculationService;
			var service = new RetailerChargeCaculationService(productChargeCalculationService) as IRetailerChargeCaculationService;
			var result = service.CalculateRetailerCharge(supplierId, product);

			Assert.Equal(expectedResult, result);
		}
	}
}
