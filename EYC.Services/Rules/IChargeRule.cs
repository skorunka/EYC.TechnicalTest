namespace EYC.Services.Rules
{
	public interface IChargeRule<in T>
	{
		decimal? GetCharge(T entity);
	}
}