using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ComponentController : ControllerBase
{
    private readonly ComponentModule _componentModule;

    public ComponentController(ComponentModule componentModule)
    {
        _componentModule = componentModule;
    }

    [HttpGet]
    public IActionResult GetComponents()
    {
        var components = _componentModule.Get();
        return Ok(components);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetComponentById(int id)
    {
        var component = _componentModule.GetById(id);
        if (component == null)
        {
            return NotFound(); // Return 404 Not Found if component is not found
        }
        return Ok(component); // Return 200 OK with the found componentDTO
    }

    [HttpPost]
    public IActionResult CreateComponent(ComponentDTO componentDTO)
    {
        return _componentModule.Create(componentDTO) ? Ok() : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateComponent(int id, ComponentDTO componentDTO)
    {
        return _componentModule.Update(id, componentDTO) ? Ok() : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteComponent(int id)
    {
        return _componentModule.Delete(id) ? Ok() : BadRequest();
    }
}
