using Umbraco.Core.Models;
using RareDiseases.Models.Extensions;
using RareDiseases.Models.Helpers;

namespace RareDiseases.Models.MediaTypes
{
	public class FileModel : CachedMediaModel
	{
		public FileModel(IPublishedContent content) : base(content)
		{
		}

		public string Url => Content.Url;
		public string Type => UmbracoExtension;
		public string FormattedSize => this.GetCachedValue(() => Utility.GetFormattedSize(UmbracoBytes));

		private string UmbracoExtension => this.GetPropertyValue<string>();
		private string UmbracoBytes => this.GetPropertyValue<string>();
	}
}
