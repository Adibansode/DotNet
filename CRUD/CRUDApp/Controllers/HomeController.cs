using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDApp.Models;
using DAL;
using BOL;
using BLL;
namespace CRUDApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        catalog mgr=new catalog();
        List<products> products=mgr.GetAllProducts();
        ViewData["allProducts"]=products;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult update()
    {
        return View();
    }

[HttpPost]
public IActionResult update(int pid,string pname)
    {
        Console.WriteLine(pid +" "+ pname);
        DBManager.updatebyid(pid,pname);
                Console.WriteLine(pid +" "+ pname);
        
        return View();
    }

     public IActionResult insert()
    {
        return View();
    }

[HttpPost]
     public IActionResult insert(int pid,string pname,int pprice,int qty)
    {
        DBManager.insert(pid,pname,pprice,qty);
        return View();
    }


   public IActionResult delete()
    {
        return View();
    }

[HttpPost]
     public IActionResult delete(int pid)
    {
        DBManager.Deletebyid(pid);
        return View();
    }






    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
 
}
