using AspNetCoreGeneratedDocument;
using EasyRepair.Data;
using EasyRepair.Migrations;
using EasyRepair.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
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
    public async Task<IActionResult> ItemsDev(string inputVal, int itType)
    {
        try
        {
            var type = ItemType.Device;

            if(itType == 0)
            {
                type = ItemType.Device;
            }
            else
            {
                type = ItemType.SparePart;
            }

            var query = _context.Items.Where(it => it.Tipo == type).AsQueryable();

            if (!string.IsNullOrWhiteSpace(inputVal))
            {
                if(itType == 0)
                {
                    query = query.Where(it => it.Name.Contains(inputVal));
                    Console.WriteLine(query);
                }
                else if(itType == 1)
                {
                    query = query.Where(it => it.Name.Contains(inputVal));
                    Console.WriteLine(query);
                }
            }

            return Json(await query.ToListAsync());
        }
        catch(Exception er)
        {
            Console.WriteLine(er);
        }
        return View();
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