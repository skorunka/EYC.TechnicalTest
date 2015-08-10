namespace EYC.Services
{
	public interface IChargeRule<in T>
	{
		decimal? GetCharge(T entity);
	}
}