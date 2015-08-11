namespace EYC.Services
{
	using DomainModels;

	public interface IProductChargeCalculationService
	{
		decimal CalculateProductCharge(Product product);
	}
}