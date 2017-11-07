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

        public ActionResult Index(string searchTerm, int? page)
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
            return View(phantrang.ToPagedList(page ?? 1, 4));
        }
    }
}