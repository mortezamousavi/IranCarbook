using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using PagedList;
using PagedList.Mvc;

namespace Irancarbook.Controllers
{
    public class HomeController : Controller
    {
        DataLayer.DataContext db = new DataContext();
        public ActionResult Index()
        {
            var myimage = db.Gallery.ToList();
            ViewData["Mygallery"] = myimage;
            var res = db.Maghaleh.OrderByDescending(f => f.Id).Take(5).ToList();
            ViewData["Content"] = res;
            return View();
        }
        public ActionResult MaghalehList()
        {
            var res = db.MaghalehGroup.ToList();
            ViewData["DataList"] = res;
            return PartialView("DoctorList");
        }
        public ActionResult Mynews()
        {
            var mynews = db.news.Take(10).ToList();
            ViewData["Mynews"] = mynews;
            return PartialView("newsPartial");
        }
        public ActionResult MyCarInfo()
        {
            var reer = db.CarInfo.ToList();
            ViewData["mycar"] = reer;
            return PartialView("CarInformation");
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult newscontent(string Id)
        {
            Int32 myid = Convert.ToInt32(Id);
            var res = db.news.FirstOrDefault(d => d.newsId == myid);
            ViewBag.myTitle = res.Name;
            ViewBag.Image = res.Image;
            ViewBag.content = res.News;
            if (res.News.Length > 151)
            {
                ViewBag.Mydesc = res.News.Substring(0, 150);
            }
            else if (res.News.Length < 151)
            {
                ViewBag.Mydesc = res.News;
            }

            return View();
        }
        public ActionResult Company(string Id)
        {
            Int32 myid = Convert.ToInt32(Id);
            var res = db.CarInfo.FirstOrDefault(d => d.Id == myid);
            ViewBag.myTitle = res.Name;
            ViewBag.Image = res.Image;
            ViewBag.content = res.Comment;
            ViewBag.mykeyword = res.keyword;
            if (res.Comment.Length > 151)
            {
                ViewBag.Mydesc = res.Comment.Substring(0, 150);
            }
            else if (res.Comment.Length < 151)
            {
                ViewBag.Mydesc = res.Comment;
            }
            
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult SaveUser(dbUser muser)
        {
            muser.RoleId = 2;
            db.dbUser.Add(muser);
            db.SaveChanges();
            var myimage = db.Gallery.ToList();
            ViewData["Mygallery"] = myimage;
            var res = db.Maghaleh.OrderByDescending(f => f.Id).Take(5).ToList();
            ViewData["Content"] = res;

            return View("index");
        }
        public virtual ActionResult checkpassuser(string name)
        {

            var er = db.dbUser.Any(d => d.mail == name);
            if (er == true)
            {
                var res = db.dbUser.FirstOrDefault(r => r.mail == name);
                return Json(new { i = res.mail });
            }

            return View();
        }
        public virtual ActionResult checkuserpass(string name, string pass)
        {

            var er = db.dbUser.Any(d => d.mail == name && d.pass == pass);
            if (er == true)
            {
                var res = db.dbUser.FirstOrDefault(r => r.mail == name && r.pass == pass);
                return Json(new { i = res.mail });
            }

            return View();
        }
        public ActionResult MaghalehContent(string Id)
        {
            Int32 myid = Convert.ToInt32(Id);
            var res = db.Maghaleh.FirstOrDefault(d => d.Id == myid);
            ViewBag.myTitle = res.Name;
            ViewBag.Image = res.ImageName;
            ViewBag.content = res.Content;
            ViewBag.mykeyword = res.KeyWords;
            if (res.Content.Length > 151)
            {
                ViewBag.Mydesc = res.Content.Substring(0, 150);
            }
            else if (res.Content.Length < 151)
            {
                ViewBag.Mydesc = res.Content;
            }
            ViewBag.files = res.FileName;
            return View();
        }
        public ActionResult Maghalat(int? paged)
        {
            ViewData["myMaghaleh"] = db.Maghaleh.OrderByDescending(r => r.Id).ToList().ToPagedList(paged ?? 1, 6);
            return View();
        }
        public ActionResult news(int? paged)
        {
            ViewData["mynews"] = db.news.OrderByDescending(r => r.newsId).ToList().ToPagedList(paged ?? 1, 6);
            return View();
        }
        public ActionResult Tarikhche(int? paged)
        {
            ViewData["mynews"] = db.CarInfo.OrderByDescending(r => r.Id).ToList().ToPagedList(paged ?? 1, 6);
            return View();
        }
        public ActionResult MyTopMaghaleh()
        {
            var res = db.Maghaleh.OrderByDescending(r => r.Position).Take(6).ToList();
            ViewData["LastMatlab"] = res;
            return PartialView("LastMatlab");

        }
        public ActionResult Login(string txtname,string txtpass)
        {
            var res = db.dbUser.FirstOrDefault(e => e.mail == txtname && e.pass == txtpass);
            if(res != null)
            {
                if (res.RoleId == 1)
                {
                  System.Web.Security.FormsAuthentication.SetAuthCookie(txtname, true);
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtname, true);
                return Redirect("/Admin/Default/Index");
                }
              
            }
           
            return View("index");
        }
        public ActionResult LoginUser(string txtname,string txtpass)
        {
            var repass = db.dbUser.Any(d => d.mail == txtname);
            if(repass == true)
            {
                var rename = db.dbUser.Any(a => a.pass == txtpass && a.mail == txtname);
                if (rename == true)
                {
                    var relogin = db.dbUser.FirstOrDefault(a => a.pass == txtpass && a.mail == txtname);
                    System.Web.Security.FormsAuthentication.SetAuthCookie(txtname, true);
                    System.Web.Security.FormsAuthentication.RedirectFromLoginPage(txtname, true);
                    return Redirect("/home/index");

                }
            }
            return View("index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}