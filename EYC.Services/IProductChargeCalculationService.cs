namespace EYC.Services
{
	using EYC.DomainModels;

	public interface IProductChargeCalculationService
	{
		decimal CalculateProductCharge(Product product);
	}
}