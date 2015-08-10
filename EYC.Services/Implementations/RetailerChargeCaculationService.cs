namespace EYC.Services.Implementations
{
	public class RetailerChargeCaculationService : IRetailerChargeCaculationService
	{
		public decimal CalculateRetailerCharge(string supplierId, string productName)
		{
			return 5000m;
		}
	}
}
