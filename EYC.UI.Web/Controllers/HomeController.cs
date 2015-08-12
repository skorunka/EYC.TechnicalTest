namespace EYC.UI.Web.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Mvc;

	using Calculations.Services;

	using Calculations.Repositories;

	using Models.Home;

	public partial class HomeController : BaseController
	{
		private readonly IProductRepository _productRepository;

		private readonly IRetailerChargeCaculationService _retailerChargeCaculationService;

		public HomeController(IProductRepository productRepository, IRetailerChargeCaculationService retailerChargeCaculationService)
		{
			if (productRepository == null)
			{
				throw new ArgumentNullException(nameof(productRepository));
			}

			if (retailerChargeCaculationService == null)
			{
				throw new ArgumentNullException(nameof(retailerChargeCaculationService));
			}

			this._productRepository = productRepository;
			this._retailerChargeCaculationService = retailerChargeCaculationService;
		}

		public virtual ActionResult Index()
		{
			var model = BuildIndexViewModel();

			return this.View(this.Views.Index, model);
		}

		[HttpPost]
		public virtual ActionResult GetSubTextPositions([Bind(Prefix = RetailerChargesViewModel.FormName)]RetailerChargesViewModel inputForm)
		{
			if (!this.ModelState.IsValid)
			{
				return this.View(this.Views.Index, BuildIndexViewModel());
			}

			var retailerCharges = this.GetRetailerCharges(inputForm.SupplierName);

			var model = BuildIndexViewModel(inputForm.SupplierName, retailerCharges);

			return this.View(this.Views.Index, model);
		}

		private IList<RetailerChargesResultViewModel.RetailerCharge> GetRetailerCharges(string supplierName)
		{
			var products = this._productRepository.GetAllForSupplier(supplierName);

			var retailerCharges =
				products.Select(
					product =>
					new RetailerChargesResultViewModel.RetailerCharge
					{
						ProductName = product.Name,
						Total = product.Quantity * product.UnitPrice,
						Charge = this._retailerChargeCaculationService.CalculateRetailerCharge(supplierName, product)
					}).ToList();

			return retailerCharges;
		}

		private static IndexViewModel BuildIndexViewModel()
		{
			return new IndexViewModel
			{
				RetailerChargesForm = new RetailerChargesViewModel(),
				RetailerCharges = null
			};
		}

		private static IndexViewModel BuildIndexViewModel(string supplierName, ICollection<RetailerChargesResultViewModel.RetailerCharge> retailerCharges)
		{
			return new IndexViewModel
			{
				RetailerChargesForm = new RetailerChargesViewModel(),
				RetailerCharges = new RetailerChargesResultViewModel
				{
					SupplierName = supplierName,
					Charges = retailerCharges
				}
			};
		}
	}
}