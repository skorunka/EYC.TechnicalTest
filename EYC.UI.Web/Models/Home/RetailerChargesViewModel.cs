namespace EYC.UI.Web.Models.Home
{
	using System.ComponentModel.DataAnnotations;

	public class RetailerChargesViewModel
	{
		public const string FormName = "RetailerChargesForm";

		[Required]
		[Display(Name = "Supplier name")]
		public string SupplierName { get; set; }
	}
}