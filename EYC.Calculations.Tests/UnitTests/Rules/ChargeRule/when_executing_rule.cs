// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Rules.UnitTests.ChargeRule
{
	using System;

	using DomainModels;
	using Rules;

	using Xunit;

	public class when_executing_rule
	{
		[Fact]
		public void return_defined_Charge_when_Product_match_rule_definition()
		{
			const decimal expectedResult = 10;

			var ruleDefinition = new Func<Product, bool>(p => p != null);
			var rule = new ChargeRule<Product>(10, ruleDefinition) as IChargeRule<Product>;

			var product = new Product();
			var productCharge = rule.GetCharge(product);

			Assert.Equal(expectedResult, productCharge);
		}

		[Fact]
		public void return_null_when_Product_does_not_match_rule_definition()
		{
			decimal? expectedResult = null;

			var ruleDefinition = new Func<Product, bool>(p => p == null);
			var rule = new ChargeRule<Product>(10, ruleDefinition) as IChargeRule<Product>;

			var product = new Product();
			var productCharge = rule.GetCharge(product);

			Assert.Equal(expectedResult, productCharge);
		}
	}
}
