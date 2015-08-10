namespace EYC.Services.Implementations
{
	using System;

	using EYC.DomainModels;

	public class RetailerChargeCaculationService : IRetailerChargeCaculationService
	{
		private readonly IProductRepository _productRepository;

		public RetailerChargeCaculationService(IProductRepository productRepository)
		{
			if (productRepository == null)
			{
				throw new ArgumentNullException(nameof(productRepository));
			}

			this._productRepository = productRepository;
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

			var product = this._productRepository.Find(supplierName, productName);

			var totalCharge = 5m;

			var total = product.Quantity * product.UnitPrice;

			return total * (totalCharge / 100);
		}
	}
}
