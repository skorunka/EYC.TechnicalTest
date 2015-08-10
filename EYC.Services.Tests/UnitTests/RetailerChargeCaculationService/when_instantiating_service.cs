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

	public class when_instantiating_service
	{
		[Fact]
		public void throw_ArgumentNullException_if_ProductRepository_is_null()
		{
			Assert.Throws<ArgumentNullException>(() => new RetailerChargeCaculationService(null, new ProductChargeCalculationService(new List<IChargeRule<Product>>())));
		}

		[Fact]
		public void throw_ArgumentNullException_if_ProductChargeCalculationService_is_null()
		{
			Assert.Throws<ArgumentNullException>(() => new RetailerChargeCaculationService(new TestProductRepository(), null));
		}
	}
}