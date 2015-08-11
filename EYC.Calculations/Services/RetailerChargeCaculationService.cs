namespace EYC.Calculations.Services
{
	using System;

	using DomainModels;

	public class RetailerChargeCaculationService : IRetailerChargeCaculationService
	{
		private readonly IProductChargeCalculationService _productChargeCalculationService;

		public RetailerChargeCaculationService(IProductChargeCalculationService productChargeCalculationService)
		{
			if (productChargeCalculationService == null)
			{
				throw new ArgumentNullException(nameof(productChargeCalculationService));
			}

			this._productChargeCalculationService = productChargeCalculationService;
		}

		public decimal CalculateRetailerCharge(string supplierName, Product product)
		{
			if (string.IsNullOrWhiteSpace(supplierName))
			{
				throw new ArgumentException("Supplier name can not be null, empty or whitespace.", nameof(supplierName));
			}

			if (product == null)
			{
				throw new ArgumentException("Product can not be null.", nameof(product));
			}

			var productCharge = this._productChargeCalculationService.CalculateProductCharge(product);
			var retailerCharge = product.Quantity * product.UnitPrice * (productCharge / 100);

			return retailerCharge;
		}
	}
}
