namespace EYC.Calculations.Services
{
	using DomainModels;

	public interface IRetailerChargeCaculationService
	{
		decimal CalculateRetailerCharge(string supplierName, Product product);
	}
}