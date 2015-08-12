namespace EYC.UI.Web.Models.Home
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations;

	public class RetailerChargesResultViewModel
	{
		public string SupplierName { get; set; }

		public ICollection<RetailerCharge> Charges { get; set; }

		public class RetailerCharge
		{
			public string ProductName { get; set; }

			[DataType(DataType.Currency)]
			public decimal Total { get; set; }

			[DataType(DataType.Currency)]
			public decimal Charge { get; set; }
		}
	}
}