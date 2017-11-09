using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WedFim.Areas.Admin.Models;
using WedFim.Common;
using Model.EF;
namespace WedFim.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var Dao = new UserDAO();
                var result = Dao.Login(model.UserName, Encryptor.MD5Hash( model.Password));
                if (result)
                {
                    var user = Dao.getid(model.UserName);

                    var userSession = new UserLogin();
                    userSession.Username = user.NameUser;
                    userSession.Password = user.PassUser;

                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    Session["name"] = user.NameUser;
                    Session["image"] = user.ImageUser;
                    Session["id"] = user.IDUserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "dang nhap khong dung");
                }
            }
            return View("Index");
        }
        public ActionResult user()
        {

            ViewBag.image = Session["image"].ToString();
            ViewBag.username = Session["name"].ToString();
            ViewBag.IdUser = Session["id"].ToString();
            return PartialView();

        }
        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            return RedirectToAction("Login");
        }
    }

}