using System.Globalization;
using Umbraco.Core.Models;
using RareDiseases.Models.DocumentTypes.Compositions;

namespace RareDiseases.Models.DocumentTypes.Pages
{
	public class HomeModel : PageModel
	{
		public HomeModel()
		{
		}

		public HomeModel(IPublishedContent content) : base(content)
		{
		}

		public HomeModel(IPublishedContent content, CultureInfo culture) : base(content, culture)
		{
		}
	}
}
