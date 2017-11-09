using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using PagedList;


namespace WedFim.Areas.Admin
{
    public class TimKiemController : Controller
    {
        WebFilmEntities db = new WebFilmEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult partial_phim(string searchTerm, int? page)
        {


            var Phim = from b in db.Table_Fim select b;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                Phim = db.Table_Fim.OrderByDescending(b => b.IDFim).Where(b => b.NameFim.Contains(searchTerm));
                ViewBag.SearchTerm = searchTerm;
            }
            else
            {
                Phim = db.Table_Fim.OrderByDescending(b => b.IDFim);
            }
            var phantrang = Phim;
            int pagenuber = (page ?? 1);
            return PartialView(phantrang.ToPagedList(page ?? 1, 4));
        }
        public PartialViewResult partial_user(string searchTerm, int? page)
        {


            var Phim = from b in db.Table_Username select b;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                Phim = db.Table_Username.OrderByDescending(b => b.IDUserName).Where(b => b.NameUser.Contains(searchTerm));
                ViewBag.SearchTerm = searchTerm;
            }
            else
            {
                Phim = db.Table_Username.OrderByDescending(b => b.IDUserName);
            }
            var phantrang = Phim;
            int pagenuber = (page ?? 1);
            return PartialView(phantrang.ToPagedList(page ?? 1, 4));
        }
    }
}