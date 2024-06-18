using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class APIBaseController : ControllerBase {
    protected readonly Database _db;
    protected readonly IMapper _map; 

    public APIBaseController(Database db, IMapper map) {
        _db = db;
        _map = map;
    }
}