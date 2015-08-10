namespace EYC.Services.Implementations
{
	using System;

	public class RetailerChargeCaculationService : IRetailerChargeCaculationService
	{
		public decimal CalculateRetailerCharge(string supplierId, string productName)
		{
			if (string.IsNullOrWhiteSpace(supplierId))
			{
				throw new ArgumentException("SupplierId can not be null, empty or whitespace.", nameof(supplierId));
			}

			if (string.IsNullOrWhiteSpace(productName))
			{
				throw new ArgumentException("ProductName can not be null, empty or whitespace.", nameof(productName));
			}

			var totalCharge = 5m;
			var unitQuantity = 50000;
			var unitPrice = 2m;

			var total = unitQuantity * unitPrice;

			return total * (totalCharge / 100);
		}
	}
}
