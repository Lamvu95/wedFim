using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace WedFim.Areas.Admin.Controllers
{
    public class HomeController :BaseController
    {

        WebFilmEntities db = new WebFilmEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Admin(string user)
        {
            var lisuser = db.Table_Username.Where(x => x.NameUser == user).ToList();
            return View(lisuser);
        }
        public PartialViewResult phim_partial()
        {
            var listFim = db.Table_Fim.Where(x => x.NamSanXuat == 2017).ToList();
            return PartialView(listFim);
        }
    }

}