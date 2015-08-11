namespace EYC.UI.Console
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Calculations.Repositories;
	using Calculations.Services;
	using DomainModels;
	using Dtos;

	public sealed class ConsoleApplication : IConsoleApplication
	{
		private readonly IRetailerChargeCaculationService _retailerChargeCaculationService;

		private readonly IProductRepository _productRepository;

		public ConsoleApplication(IRetailerChargeCaculationService retailerChargeCaculationService, IProductRepository productRepository)
		{
			if (retailerChargeCaculationService == null)
			{
				throw new ArgumentNullException(nameof(retailerChargeCaculationService));
			}

			if (productRepository == null)
			{
				throw new ArgumentNullException(nameof(productRepository));
			}

			this._retailerChargeCaculationService = retailerChargeCaculationService;
			this._productRepository = productRepository;
		}

		public ICollection<OutputItem> Run(string supplierName)
		{
			var products = this._productRepository.GetAllForSupplier(supplierName);

			var outputItems =
				products.Select(
					product =>
					MapProductToOutputItem(
						product,
						this._retailerChargeCaculationService.CalculateRetailerCharge(supplierName, product))).ToList();

			return outputItems;
		}

		private static OutputItem MapProductToOutputItem(Product product, decimal retailerCharge)
		{
			return new OutputItem
			{
				ProductName = product.Name,
				Total = product.Quantity * product.UnitPrice,
				RetailerCharge = retailerCharge
			};
		}
	}
}