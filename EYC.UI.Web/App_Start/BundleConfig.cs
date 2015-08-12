namespace EYC.UI.Web
{
	using System.Web.Optimization;

	public static class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/site").Include(
						Links.Bundles.Scripts.Assets._extensions_js,
						Links.Bundles.Scripts.Assets.site_js));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  Links.Bundles.Scripts.Assets.bootstrap_js,
					  Links.Bundles.Scripts.Assets.respond_js));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  Links.Bundles.Content.Assets.bootstrap_css,
					  Links.Bundles.Content.Assets.Site_css));
		}
	}
}
