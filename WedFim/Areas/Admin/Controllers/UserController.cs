using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WedFim.Areas.Admin.Controllers
{
   
        // GET: Admin/Users
        public class UserController : BaseController
        {
            WebFilmEntities db = new WebFilmEntities();
            // GET: Admin/User
            public ActionResult Index()
            {

                ViewBag.Chucvu = new SelectList(db.Table_Username, "IDUserName", "Chucvu");
                ViewBag.GioiTinh = new SelectList(db.Table_Username, "IDUserName", "GioiTinh");
                return View();
            }
            public ActionResult Create(Table_Username user)
            {
                if (ModelState.IsValid)
                {
                    var dao = new UserDAO();
                    long id = dao.Insert(user);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "User");
                    }
                    else
                    {
                        ModelState.AddModelError("", "chuc mung them thanh cong");
                    }
                }
                return View("Index");
            }
        }
    
}