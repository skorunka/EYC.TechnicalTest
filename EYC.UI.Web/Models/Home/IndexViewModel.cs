namespace EYC.UI.Web.Models.Home
{
	using System.ComponentModel.DataAnnotations;

	public class IndexViewModel
	{
		[UIHint("RetailerChargesForm")]
		public RetailerChargesViewModel RetailerChargesForm { get; set; }

		[UIHint("RetailerCharges")]
		public RetailerChargesResultViewModel RetailerCharges { get; set; }
	}
}