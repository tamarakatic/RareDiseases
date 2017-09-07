using Umbraco.Core.Models;
using RareDiseases.Models.Extensions;

namespace RareDiseases.Models.DocumentTypes.Nodes
{
	public class SettingsModel : CachedContentModel
	{
		public SettingsModel(IPublishedContent content) : base(content)
		{
		}

		public string SiteName => this.GetPropertyValue<string>();
		public string Robots => this.GetPropertyValue<string>();
	}
}
