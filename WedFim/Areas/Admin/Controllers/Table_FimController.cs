﻿using System;
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

namespace WedFim.Areas.Admin.Controllers
{
    public class Table_FimController : BaseController
    {
        private WebFilmEntities db = new WebFilmEntities();

        // GET: Admin/Table_Fim
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

        // GET: Admin/Table_Fim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            if (table_Fim == null)
            {
                return HttpNotFound();
            }
            return View(table_Fim);
        }

        // GET: Admin/Table_Fim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Table_Fim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFim,NameFim,IDTheLoai,TenDienVien,AnhDienVien,ThongTinBoFim,DaoDien,NamSanXuat,NoiSanXuat,Rating,IDUserName,AnhPhim,Slide,url")] Table_Fim table_Fim)
        {
            if (ModelState.IsValid)
            {
                db.Table_Fim.Add(table_Fim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Fim);
        }

        // GET: Admin/Table_Fim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            if (table_Fim == null)
            {
                return HttpNotFound();
            }
            
            return View(table_Fim);
        }

        // POST: Admin/Table_Fim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFim,NameFim,IDTheLoai,TenDienVien,AnhDienVien,ThongTinBoFim,DaoDien,NamSanXuat,NoiSanXuat,Rating,IDUserName,AnhPhim,Slide,url")] Table_Fim table_Fim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Fim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Fim);
        }

        // GET: Admin/Table_Fim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {  
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            if (table_Fim == null)
            {
              
                return HttpNotFound();
            }
           
            return View(table_Fim);
        }

        // POST: Admin/Table_Fim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Fim table_Fim = db.Table_Fim.Find(id);
            db.Table_Fim.Remove(table_Fim);
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

            var NameImage = System.IO.Path.GetRandomFileName() +file.FileName;
            file.SaveAs(Server.MapPath("~/Content/image_webfim/" + NameImage));
              
                return NameImage;
            

        }
        
    }
}
