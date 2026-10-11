using EasyRepair.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

//namespace EasyRepair.Controllers.Api;

//[ApiController]
//[Route("api/[controller]")]
public class ItemController : Controller //Base
{
    private protected EasyRepairContext _context;

    public ItemController(EasyRepairContext context)
    {
        _context = context;
    }

    public IActionResult Device()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> UtentiProva()
    {
        var cartItems = await _context.Items.Select(it => new
            {
                it.Name,
                it.Price
            }).ToListAsync();

        return Json(cartItems);
    }

    /*
    // futura parte per react
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[]
        {
            new { id = 1, brand = "Samsung", model = "Galaxy S24" },
            new { id = 2, brand = "Apple", model = "iPhone 15" }
        });
    }
    */
}