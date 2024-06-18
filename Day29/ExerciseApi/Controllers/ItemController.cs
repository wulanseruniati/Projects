using Microsoft.AspNetCore.Mvc;

public class ItemController : APIBaseController {
    private readonly ItemModule _itemModule;
    public ItemController(ItemModule ItemModule)
    {
        _itemModule=ItemModule;
    }
    [HttpGet]
    public IActionResult GetItem()
    {
        return Ok(_itemModule.Get());
    }
    
    [HttpGet("{id}")]
    public IActionResult GetItemById(Guid id)
    {
        return Ok(_itemModule.GetById(id));    // Return the found component
    }

    [HttpPost]
    public IActionResult CreateItem(ItemDTO itemDTO)
    {
        return _itemModule.Create(itemDTO) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateItem(Guid id, ItemDTO componentDTO)
    {
        return _itemModule.Update(id,componentDTO) ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(Guid id)
    {
        return _itemModule.Delete(id) ? Ok() : BadRequest();
    }
}