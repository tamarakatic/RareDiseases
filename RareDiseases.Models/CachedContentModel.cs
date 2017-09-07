using System.Collections.Generic;
using Umbraco.Core.Models;
using RareDiseases.Models.Extensions;

namespace RareDiseases.Models
{
	public abstract class CachedContentModel : IUmbracoCachedModel
	{
		protected CachedContentModel(IPublishedContent content)
		{
			Content = content;
		}

		public IPublishedContent Content { get; }
		IDictionary<string, object> IUmbracoCachedModel.CachedProperties { get; } = new Dictionary<string, object>();
		public string Name => Content.Name;
	}
}
