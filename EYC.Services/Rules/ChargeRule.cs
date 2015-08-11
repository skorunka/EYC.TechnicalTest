namespace EYC.Services.Rules
{
	using System;

	public class ChargeRule<T> : IChargeRule<T>
	{
		private readonly decimal _charge;

		private readonly Func<T, bool> _ruleDefinitionFunc;

		public ChargeRule(decimal charge, Func<T, bool> ruleDefinitionFunc)
		{
			if (ruleDefinitionFunc == null)
			{
				throw new ArgumentNullException(nameof(ruleDefinitionFunc));
			}

			this._charge = charge;
			this._ruleDefinitionFunc = ruleDefinitionFunc;
		}

		public decimal? GetCharge(T entity)
		{
			return this._ruleDefinitionFunc(entity) ? (decimal?)this._charge : null;
		}
	}
}