using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using DAL;
using BOL;

namespace MyApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

        public IActionResult Login()
    {
        return View();
    }
      [HttpPost]
    public IActionResult Login(string username,string password)
    {
          Login log = DBManager.validate(username,password);
          if(log!=null){
            Console.WriteLine(username,password);
            return RedirectToAction("Welcome");
          }
          else{
                Console.WriteLine(username+" "+password);

          }
            
            return View();
    }

    
    
    public IActionResult Index()
    {
        return View();
    }

  
   public IActionResult Register()
    {
        return View();
    }

     [HttpPost]
    public IActionResult Register(String username, String password, String email)
    {
 
        DBManager.InsertData(username,password,email);

        return View();
    }
         public IActionResult Welcome()
    {
        return View();
    }
      
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
