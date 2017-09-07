using System.Collections.Generic;

namespace RareDiseases.Models.Additional.Pagination
{
	public class ReadOnlyPagedCollection<T>
	{
		public ReadOnlyPagedCollection(IReadOnlyList<T> items, PaginationModel pagination)
		{
			Items = items;
			Pagination = pagination;
		}

		public IReadOnlyList<T> Items { get; }
		public PaginationModel Pagination { get; }
	}
}
