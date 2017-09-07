using Umbraco.Core.Models;

namespace RareDiseases.Models.MediaTypes
{
	public class CachedMediaModel : CachedContentModel
	{
		public CachedMediaModel(IPublishedContent content) : base(content)
		{
		}
	}
}
