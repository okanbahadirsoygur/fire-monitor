using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FireMonitor.Models;
using FireMonitor.DbContextContext;

namespace FireMonitor.Controllers;

public class HomeController : Controller
{
 
    public IActionResult Index()
    {

        return Redirect("/login");

        
    }//func
 
 
}//class

