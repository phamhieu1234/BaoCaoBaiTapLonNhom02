using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BaoCaoBaiTapLonNhom02.Models;

namespace BaoCaoBaiTapLonNhom02.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        return View();
    }
   

    public IActionResult Privacy()
    {
        ViewBag.thongbao = "Bạn đã đăng ký thành công";
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
