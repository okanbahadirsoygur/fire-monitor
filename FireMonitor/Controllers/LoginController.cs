using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireMonitor.DbContextContext;
using FireMonitor.Models;
using Microsoft.AspNetCore.Mvc;

/**
 * Fire Monitor - Login Controller
 * 
 * @author: Okan Bahadır Soygür
 * @date: 10.11.2022
 * 
 */
 

namespace FireMonitor.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet("/login")]
        public IActionResult Index([FromQuery(Name = "response")] String? response)
        {
            String? isLogin = HttpContext.Session.GetString("login") ?? null;

            if (isLogin != null && isLogin.Equals("1"))
            {
                return Redirect("/monitoring");
            }
            else
            {

                if (response != null)
                {
                    if (!response.Equals("success"))
                    {
                        ViewBag.response = response;
                    }

                }//response


                return View();

            }//isLogin
        }//func

        [Route("/login")]
        [HttpPost]
        public IActionResult IndexPost([FromForm(Name = "host")] String host, [FromForm(Name = "path")] String path,[FromForm(Name = "user")] String user, [FromForm(Name = "password")] String password)
        {
            try
            {
                string connectionString = $"database={host}:{path};user={user};password={password}";

                FirebirdDbContext db = new FirebirdDbContext(connectionString);

                MON_DATABASE temp = db.MON_DATABASE.First();

                HttpContext.Session.SetString("login", "1");

                HttpContext.Session.SetString("h", host);

                HttpContext.Session.SetString("c", connectionString); 

                

                return Redirect("/login?response=success");


            }catch(Exception e)
            {
                Console.WriteLine(e);
                return Redirect("/login?response=CONNECTION_ERROR");

            }//try

        
        }//func


    }//class
}//namespace

