using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using PagedList;
using WedFim.Common;
using System.IO;

namespace WedFim.Areas.Admin.Controllers
{
    public class Table_UsernameController : BaseController
    {
        private WebFilmEntities db = new WebFilmEntities();

        // GET: Admin/Table_Username
        public ActionResult Index(string searchTerm, int? page)
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
            return View(phantrang.ToPagedList(page ?? 1, 4));
        
        }
        // GET: Admin/Table_Username/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Username table_Username = db.Table_Username.Find(id);
            if (table_Username == null)
            {
                return HttpNotFound();
            }
            return View(table_Username);
        }

        // GET: Admin/Table_Username/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Table_Username/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDUserName,NameUser,PassUser,ConfirmPassUser,NgaySinh,GioiTinh,SDT,Chucvu,ImageUser")] Table_Username table_Username)
        {
            if (ModelState.IsValid)
            {
                db.Table_Username.Add(table_Username);
                var a = Encryptor.MD5Hash(table_Username.PassUser);
                table_Username.PassUser = a;
                table_Username.ConfirmPassUser = a;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Username);
        }

        // GET: Admin/Table_Username/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Username table_Username = db.Table_Username.Find(id);
            if (table_Username == null)
            {
                return HttpNotFound();
            }
            return View(table_Username);
        }

        // POST: Admin/Table_Username/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDUserName,NameUser,PassUser,ConfirmPassUser,NgaySinh,GioiTinh,SDT,Chucvu,ImageUser")] Table_Username table_Username)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Username).State = EntityState.Modified;
                //var a = Encryptor.MD5Hash(table_Username.PassUser);
                //table_Username.PassUser = a;
                //table_Username.ConfirmPassUser = a;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Username);
        }

        // GET: Admin/Table_Username/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Username table_Username = db.Table_Username.Find(id);
            if (table_Username == null)
            {
                return HttpNotFound();
            }
            return View(table_Username);
        }

        // POST: Admin/Table_Username/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Username table_Username = db.Table_Username.Find(id);
            db.Table_Username.Remove(table_Username);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public string ProcesUpload(HttpPostedFileBase file)
        {

            // var NameImage = Guid.NewGuid() + file.FileName;
            // var NameImage = System.IO.Path.GetExtension(file.FileName);

            var NameImage = System.IO.Path.GetRandomFileName() + file.FileName;
            file.SaveAs(Server.MapPath("~/Content/image_webfim/" + NameImage));

            return NameImage;


        }
        [HttpPost]
        public ActionResult Proceskeo(IEnumerable<HttpPostedFileBase> files)
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
