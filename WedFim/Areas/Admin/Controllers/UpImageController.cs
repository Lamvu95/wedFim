using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WedFim.Areas.Admin.Controllers
{
    public class UpImageController : Controller
    {
        // GET: Admin/UpImage
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProcesUpload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/Content/image_webfim"), filePath));
            }
            return Json("thanh cong");
        }

    }
}