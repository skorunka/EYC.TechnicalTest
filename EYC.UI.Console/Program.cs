namespace EYC.UI.Console
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;
	using System.Globalization;

	using Autofac;

	using Calculations.Repositories;
	using Calculations.Rules;
	using Calculations.Services;
	using DomainModels;

	[ExcludeFromCodeCoverage]
	public static class Program
	{
		public static void Main(string[] args)
		{
			CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
			CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.DefaultThreadCurrentCulture;

			Console.Write("Supplier Name: ");

			using (var container = BuildContainer())
			{
				var consoleApplication = container.Resolve<IConsoleApplication>();

				Console.WriteLine("\nItem | Total( units * unit price ) | Retailer charge");
				Console.WriteLine(new string('-', 52));

				var outputItems = consoleApplication.Run(Console.ReadLine());

				foreach (var outputItem in outputItems)
				{
					Console.WriteLine($"{outputItem.ProductName} | {outputItem.Total:C} | {outputItem.RetailerCharge:C}");
				}
			}

			Console.Write("\nPress enter to exit.");
			Console.ReadLine();
		}

		private static IContainer BuildContainer()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<ConsoleApplication>().As<IConsoleApplication>();
			builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>();
			builder.RegisterType<RetailerChargeCaculationService>().As<IRetailerChargeCaculationService>();
			builder.RegisterType<ProductChargeCalculationService>().As<IProductChargeCalculationService>();
			builder.RegisterInstance(GetProductChargeRules()).As<IReadOnlyCollection<IChargeRule<Product>>>();

			return builder.Build();
		}

		private static IList<IChargeRule<Product>> GetProductChargeRules()
		{
			return new List<IChargeRule<Product>>
					   {
						   new ChargeRule<Product>(6, x => x.Quantity >= 0 && x.Quantity <= 1000),
						   new ChargeRule<Product>(4, x => x.Quantity >= 1001 && x.Quantity <= 5000),
						   new ChargeRule<Product>(3, x => x.Quantity >= 5001),
						   new ChargeRule<Product>(1, x => x.Country != "UK"),
						   new ChargeRule<Product>(1, x => x.Type == ProductType.Fresh)
					   };
		}
	}
}
