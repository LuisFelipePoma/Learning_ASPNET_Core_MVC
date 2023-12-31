using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Dtos;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("items")]
	public class ItemsController : ControllerBase
	{
		private readonly IItemsRepository repository;
		public ItemsController(IItemsRepository repository)
		{
			this.repository = repository;
		}

		// GET /items
		[HttpGet]
		public IEnumerable<ItemDto> GetItems()
		{
			var items = repository.GetItems().Select(item => item.AsDto());
			return items;
		}

		// GET /items/{id}
		[HttpGet("{id}")]
		public ActionResult<ItemDto> GetItem(Guid id)
		{
			var item = repository.GetItem(id).AsDto();
			if (item is null)
			{
				return NotFound();
			}
			return Ok(item);
		}


		// POST /items
		[HttpPost]
		public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
		{
			Item item = new()
			{
				Id = Guid.NewGuid(),
				Name = itemDto.Name,
				Price = itemDto.Price,
				CreatedDate = DateTimeOffset.UtcNow
			};
			repository.CreateItem(item);
			// This "return" return a 201 status code with the item in the body.
			return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
		}

		// PUT /items/{id}
		[HttpPut("{id}")]
		public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
		{
			var existingItem = repository.GetItem(id);
			if (existingItem is null)
			{
				return NotFound();
			}
			Item updatedItem = existingItem with
			{
				Name = itemDto.Name,
				Price = itemDto.Price
			};
			repository.UpdateItem(updatedItem);
			return NoContent();
		}

		// DELETE /items/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteItem(Guid id)
		{
			var existingItem = repository.GetItem(id);
			if (existingItem is null)
			{
				return NotFound();
			}
			repository.DeleteItem(id);
			return NoContent();
		}
	}
}