namespace EYC.Calculations.Rules
{
	public interface IChargeRule<in T>
	{
		decimal? GetCharge(T entity);
	}
}