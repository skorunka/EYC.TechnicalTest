namespace EYC.Services.Implementations
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using EYC.DomainModels;

	public class ProductChargeCalculationService : IProductChargeCalculationService
	{
		private readonly IReadOnlyCollection<IChargeRule<Product>> _productChargeRules;

		public ProductChargeCalculationService(IReadOnlyCollection<IChargeRule<Product>> productChargeRules)
		{
			if (productChargeRules == null)
			{
				throw new ArgumentNullException(nameof(productChargeRules));
			}

			this._productChargeRules = productChargeRules;
		}

		public decimal CalculateProductCharge(Product product)
		{
			var charge = this._productChargeRules.Sum(x => x.GetCharge(product) ?? 0);

			return charge;
		}
	}
}