namespace EYC.Calculations.Rules
{
	using System.Collections.Generic;

	using DomainModels;

	public static class Rules
	{
		public static IReadOnlyCollection<IChargeRule<Product>> ProductChargeRules { get; } =
			new List<IChargeRule<Product>>
				{
					new ChargeRule<Product>(6, x => x.Quantity >= 0 && x.Quantity <= 1000),
					new ChargeRule<Product>(4, x => x.Quantity >= 1001 && x.Quantity <= 5000),
					new ChargeRule<Product>(3, x => x.Quantity >= 5001),
					new ChargeRule<Product>(1, x => x.Country != "UK"),
					new ChargeRule<Product>(1, x => x.Type == ProductType.Fresh)
				};
	}
}