namespace EYC.UI.Console
{
	using System.Collections.Generic;

	using Dtos;

	public interface IConsoleApplication
	{
		ICollection<OutputItem> Run(string supplierName);
	}
}