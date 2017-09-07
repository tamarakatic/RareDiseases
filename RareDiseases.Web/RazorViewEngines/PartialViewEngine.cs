using System.Web.Mvc;

namespace RareDiseases.Web.RazorViewEngines
{
	public class PartialViewEngine : RazorViewEngine
	{
		public PartialViewEngine()
		{
			string[] locations =
			{
				"~/Views/Partials/{1}/{0}.cshtml",
				"~/Views/Partials/{1}/_{0}.cshtml"
			};

			PartialViewLocationFormats = locations;
		}
	}
}