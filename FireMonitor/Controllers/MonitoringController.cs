using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireMonitor.DbContextContext;
using FireMonitor.Models;
using Microsoft.AspNetCore.Mvc;

/**
 * Fire Monitor - Monitoring Controller
 * 
 * @author: Okan Bahadır Soygür
 * @date: 10.11.2022
 * 
 */

namespace FireMonitor.Controllers
{
    public class MonitoringController : Controller
    {

        [HttpGet]
        [Route("/monitoring")]
        public IActionResult Index()
        {
            String? isLogin = HttpContext.Session.GetString("login") ?? null;

            if(isLogin != null && isLogin.Equals("1"))
            {

                String connectionString = HttpContext.Session.GetString("c");

                try
                {

                    FirebirdDbContext db = new FirebirdDbContext(connectionString);

                    ViewBag.MON_ATTACHMENTS = db.MON_ATTACHMENTS.AsNoTracking()
                    .Join(db.MON_MEMORY_USAGE, a => a.MON_STAT_ID, m => m.MON_STAT_ID, (a, m) => new { a, m })
                    .Where(join=> !join.a.MON_USER.Contains("Cache Writer") && !join.a.MON_USER.Contains("Garbage Collector"))
                    .ToList();
                     

                    ViewBag.DATABASE = db.MON_DATABASE.AsNoTracking().FirstOrDefault().MON_DATABASE_NAME;

                    ViewBag.HOST = HttpContext.Session.GetString("h");

                    ViewBag.MEMORY_USED = (db.MON_MEMORY_USAGE.AsNoTracking().Sum(m => m.MON_MEMORY_USED) / 1024 / 1024) + " MB";

                    return View();


                }catch(Exception e)
                {
                    HttpContext.Session.Remove("login");
                    HttpContext.Session.Remove("h");
                    HttpContext.Session.Remove("c");

                    Console.WriteLine(e);
                    return Redirect("/login");
                }//try

            }else
            {
                return Redirect("/login");
            }

      

        }//func


        [Route("/monitoring")]
        [HttpPost]
        public IActionResult IndexPost([FromForm(Name = "MON_ATTACHMENT_ID")] int? MON_ATTACHMENT_ID)
        {
            String connectionString = HttpContext.Session.GetString("c");

            try
            {
                FirebirdDbContext db = new FirebirdDbContext(connectionString);

                MON_ATTACHMENTS temp =  db.MON_ATTACHMENTS.Where(a => a.MON_ATTACHMENT_ID == MON_ATTACHMENT_ID).SingleOrDefault();

                db.MON_ATTACHMENTS.Remove(temp);

                db.SaveChanges();

                return Redirect("/monitoring");


            }catch(Exception e)
            {
                HttpContext.Session.Remove("login");
                HttpContext.Session.Remove("h");
                HttpContext.Session.Remove("c");

                Console.WriteLine(e);

                return Redirect("/login");
            }//try

        }//func

        [Route("logout")]
        [HttpPost]
        public IActionResult logout()
        {
            HttpContext.Session.Remove("login");
            HttpContext.Session.Remove("c");
            HttpContext.Session.Remove("h");

            return Redirect("/login");
        }//func


    }//class
}//namespace

