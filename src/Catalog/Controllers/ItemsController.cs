using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("items")]
	public class ItemsController : ControllerBase
	{
		private readonly InMemItemsRepository repository;
		public ItemsController()
		{
			repository = new InMemItemsRepository();
		}

		// GET /items
		[HttpGet]
		public IEnumerable<Item> GetItems()
		{
			var items = repository.GetItems();
			return items;
		}

		// GET /items/{id}
		[HttpGet("{id}")]
		public ActionResult<Item> GetItem(Guid id)
		{
			var item = repository.GetItem(id);
			if (item is null)
			{
				return NotFound();
			}
			return Ok(item);
		}
	}
}