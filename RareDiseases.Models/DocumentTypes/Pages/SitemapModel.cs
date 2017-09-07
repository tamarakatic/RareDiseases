using System.Globalization;
using System.Linq;
using Umbraco.Core.Models;
using RareDiseases.Common;
using RareDiseases.Models.Extensions;
using RareDiseases.Models.DocumentTypes.Compositions;

namespace RareDiseases.Models.DocumentTypes.Pages
{
	public class SitemapModel : PageModel
	{
		public SitemapModel()
		{
		}

		public SitemapModel(IPublishedContent content) : base(content)
		{
		}

		public SitemapModel(IPublishedContent content, CultureInfo culture) : base(content, culture)
		{
		}

		public int DepthLevel => this.GetCachedValue(() => (Content.HasValue() ? Content.GetPropertyValue<int>() : AppSettings.SitemapDepthLevelDefaultValue) + Constants.HomePageLevel);

		public bool ShouldIncludeChildrenInSitemap(PageModel page)
		{
			return (page.Content.Level < DepthLevel) && page.SitemapItems.Any();
		}
	}
}
