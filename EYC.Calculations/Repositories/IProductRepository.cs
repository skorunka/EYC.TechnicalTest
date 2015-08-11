namespace EYC.Calculations.Repositories
{
	using System.Collections.Generic;

	using EYC.DomainModels;

	public interface IProductRepository
	{
		/// <exception cref="System.Exception">If no product found.</exception>
		Product Find(string supplierName, string productName);

		ICollection<Product> GetAllForSupplier(string supplierName);
	}
}