using Catalog.Entities;

namespace Catalog.Repositories
{
	public interface IItemsRepository
	{
		Item GetItem(Guid id);
		IEnumerable<Item> GetItems();
	}
}