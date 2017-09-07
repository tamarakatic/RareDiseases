using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;
using RareDiseases.Common;
using RareDiseases.Models.DocumentTypes.Nodes;
using RareDiseases.Models.DocumentTypes.Pages;
using RareDiseases.Models.Extensions;
using RareDiseases.Models.Helpers;

namespace RareDiseases.Models.DocumentTypes.Compositions
{
	public class PageModel : RenderModel, IUmbracoCachedModel
	{
		public PageModel() : this(new UmbracoHelper(UmbracoContext.Current).TypedContent(UmbracoContext.Current.PageId))
		{
		}

		public PageModel(IPublishedContent content) : base(content)
		{
		}

		public PageModel(IPublishedContent content, CultureInfo culture) : base(content, culture)
		{
		}

		#region [Content]

		public string Title => this.GetPropertyWithDefaultValue(Name);

		#endregion

		#region [SEO]

		public string SeoTitle => this.GetPropertyWithDefaultValue(Title);
		public string SeoDescription => this.GetPropertyValue<string>();
		public string SeoKeywords => this.GetPropertyValue<string>();
		public string SeoAuthor => this.GetPropertyValue<string>();

		#endregion

		#region [Page Settings]

		public bool HideFromSiteNavigation => UmbracoNaviHide;
		public bool HideFromSiteSearch => this.GetPropertyValue<bool>();
		public bool HideFromGoogleSearch => this.GetPropertyValue<bool>();
		public bool HideFromSitemap => this.GetPropertyValue<bool>();
		public string ExternalRedirect => this.GetPropertyValue<string>();

		#endregion

		#region [Additional]

		public IEnumerable<PageModel> NavigationItems => this.GetCachedValue(() => Content.GetNavigationItems());
		public IEnumerable<PageModel> SideBarNavigationItems => this.GetCachedValue(() => Content.GetSideBarNavigationItems(Constants.HomePageLevel + 1));
		public IEnumerable<PageModel> SitemapItems => this.GetCachedValue(() => Content.GetSitemapItems());
		public IEnumerable<PageModel> SitemapXMLItems => this.GetCachedValue(() => Content.GetSitemapXMLItems());
		public HomeModel Home => this.GetCachedValue(() => GetHomeModel());
		public SettingsModel Settings => this.GetCachedValue(() => GetSettingsModel());

		public bool IsActivePage => this.GetCachedValue(() => GetIsActivePage());
		public bool HasNavigationItems => this.GetCachedValue(() => NavigationItems.Any());
		public string FullUrl => this.GetCachedValue(() => Content.UrlAbsolute());
		public string Url => Content.Url;

		#endregion

		IDictionary<string, object> IUmbracoCachedModel.CachedProperties { get; } = new Dictionary<string, object>();

		protected readonly UmbracoHelper UmbracoHelper = new UmbracoHelper(UmbracoContext.Current);
		protected string Name => Content.Name;

		private bool UmbracoNaviHide => this.GetPropertyValue<bool>();

		private HomeModel GetHomeModel()
		{
			return Content.AncestorOrSelf(Constants.HomePageLevel).AsType<HomeModel>();
		}

		private SettingsModel GetSettingsModel()
		{
			return UmbracoHelper.TypedContentSingleAtXPath("//Settings").AsType<SettingsModel>();
		}

		private bool GetIsActivePage()
		{
			string currentPath = UmbracoContext.Current.PublishedContentRequest.PublishedContent.Path;

			return Utility.ContainsId(currentPath, Content.Id);
		}
	}
}
