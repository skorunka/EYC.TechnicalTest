namespace EYC.Services
{
	public interface IRetailerChargeCaculationService
	{
		decimal CalculateRetailerCharge(string supplierId, string productName);
	}
}