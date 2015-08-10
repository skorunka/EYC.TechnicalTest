namespace EYC.Services
{
	using System;

	using EYC.DomainModels;

	public interface IProductRepository
	{
		/// <exception cref="Exception">If no product found.</exception>
		Product Find(string supplierName, string productName);
	}
}