namespace EYC.Services.Implementations
{
	using System;

	public class RetailerChargeCaculationService : IRetailerChargeCaculationService
	{
		private readonly IProductRepository _productRepository;

		private readonly IProductChargeCalculationService _productChargeCalculationService;

		public RetailerChargeCaculationService(IProductRepository productRepository, IProductChargeCalculationService productChargeCalculationService)
		{
			if (productRepository == null)
			{
				throw new ArgumentNullException(nameof(productRepository));
			}

			if (productChargeCalculationService == null)
			{
				throw new ArgumentNullException(nameof(productChargeCalculationService));
			}

			this._productRepository = productRepository;
			this._productChargeCalculationService = productChargeCalculationService;
		}

		public decimal CalculateRetailerCharge(string supplierName, string productName)
		{
			if (string.IsNullOrWhiteSpace(supplierName))
			{
				throw new ArgumentException("Supplier name can not be null, empty or whitespace.", nameof(supplierName));
			}

			if (string.IsNullOrWhiteSpace(productName))
			{
				throw new ArgumentException("Product name can not be null, empty or whitespace.", nameof(productName));
			}

			//// [FS]: We want this product at this time, we dont care about concurent Product changes(Quantity, UnitPrice etc.).
			var product = this._productRepository.Find(supplierName, productName);
			var productCharge = this._productChargeCalculationService.CalculateProductCharge(product);
			var retailerCharge = product.Quantity * product.UnitPrice * (productCharge / 100);

			return retailerCharge;
		}
	}
}
