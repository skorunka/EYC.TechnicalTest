namespace EYC.UI.Web
{
	using System.Collections.Generic;
	using System.Reflection;
	using System.Web.Mvc;

	using Autofac;
	using Autofac.Integration.Mvc;

	using Calculations.Repositories;
	using Calculations.Rules;
	using Calculations.Services;
	using DomainModels;

	public static class ContainerConfig
	{
		public static void RegisterContainer()
		{
			var builder = new ContainerBuilder();

			// Register your MVC controllers.
			builder.RegisterControllers(typeof(MvcApplication).Assembly);

			// OPTIONAL: Register model binders that require DI.
			builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
			builder.RegisterModelBinderProvider();

			// OPTIONAL: Register web abstractions like HttpContextBase.
			builder.RegisterModule<AutofacWebTypesModule>();

			// OPTIONAL: Enable property injection in view pages.
			builder.RegisterSource(new ViewRegistrationSource());

			// OPTIONAL: Enable property injection into action filters.
			builder.RegisterFilterProvider();

			builder.RegisterType<InMemoryProductRepository>().As<IProductRepository>();
			builder.RegisterType<RetailerChargeCaculationService>().As<IRetailerChargeCaculationService>();
			builder.RegisterType<ProductChargeCalculationService>().As<IProductChargeCalculationService>();
			builder.RegisterInstance(Rules.ProductChargeRules).As<IReadOnlyCollection<IChargeRule<Product>>>().SingleInstance();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
		}
	}
}