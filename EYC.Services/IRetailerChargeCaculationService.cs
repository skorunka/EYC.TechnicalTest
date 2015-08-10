namespace EYC.Services
{
	public interface IRetailerChargeCaculationService
	{
		decimal CalculateRetailerCharge(string supplierName, string productName);
	}
}