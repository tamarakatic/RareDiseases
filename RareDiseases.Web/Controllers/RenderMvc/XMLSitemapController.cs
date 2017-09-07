using System.Web.Mvc;
using Umbraco.Web.Mvc;
using RareDiseases.Models.DocumentTypes.Compositions;

namespace RareDiseases.Web.Controllers.RenderMvc
{
	public class XMLSitemapController : RenderMvcController
	{
		public ActionResult XMLSitemap(PageModel model)
		{
			return CurrentTemplate(model);
		}
	}
}
