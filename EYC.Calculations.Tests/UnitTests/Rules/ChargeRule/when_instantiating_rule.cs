// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
namespace EYC.Calculations.Rules.UnitTests.ChargeRule
{
	using System;

	using DomainModels;

	using Xunit;

	public class when_instantiating_rule
	{
		[Fact]
		public void throw_ArgumentNullException_if_RuleDefinitionFunc_is_null()
		{
			Assert.Throws<ArgumentNullException>(() => new ChargeRule<Product>(10, null) as IChargeRule<Product>);
		}
	}
}