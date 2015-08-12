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

				var supplierName = Console.ReadLine();

				Console.WriteLine("\nItem | Total( units * unit price ) | Retailer charge");
				Console.WriteLine(new string('-', 52));

				var outputItems = consoleApplication.Run(supplierName);

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
			builder.RegisterInstance(Rules.ProductChargeRules).As<IReadOnlyCollection<IChargeRule<Product>>>().SingleInstance();

			return builder.Build();
		}
	}
}
