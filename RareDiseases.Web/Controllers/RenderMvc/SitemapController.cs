using System.Web.Mvc;
using Umbraco.Web.Mvc;
using RareDiseases.Models.DocumentTypes.Pages;

namespace RareDiseases.Web.Controllers.RenderMvc
{
	public class SitemapController : RenderMvcController
	{
		public ActionResult Index(SitemapModel model)
		{
			return CurrentTemplate(model);
		}
	}
}
