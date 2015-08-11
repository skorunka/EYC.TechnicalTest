namespace EYC.Calculations.Services
{
	using DomainModels;

	public interface IProductChargeCalculationService
	{
		decimal CalculateProductCharge(Product product);
	}
}