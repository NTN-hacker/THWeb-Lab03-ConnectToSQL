using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult listBook()
        {
            //entity framework code first
            DataBook data = new DataBook();
            var list = data.SACHes.ToList();
            return View(list);
        }

        //buy
        [Authorize]
        public ActionResult Buy(int id)
        {
            DataBook data = new DataBook();
            SACH book = data.SACHes.SingleOrDefault(p => p.MaSach == id);
            if (book == null)
            {
                return HttpNotFound();
            }    
            return View(book);
        }
        [Authorize]
        public ActionResult createBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include = "TenSach,GiaBan,GiaBia,AnhBia")] SACH book)
        {
            DataBook data = new DataBook();
            var list = data.SACHes.ToList();
            data.SACHes.Add(book);
            data.SaveChanges();
            return RedirectToAction("listBook", list);
        }
        //chỉnh sửa
        [Authorize]
        public ActionResult editBook(int id)
        {
            DataBook data = new DataBook();
            var book = data.SACHes.ToList();
            SACH b = new SACH();
            foreach (SACH i in book)
            {
                if (i.MaSach == id)
                {
                    b = i;
                    break;
                }
                
            }
            if (b == null)
                return HttpNotFound();
            return View(b);
        }

        //post: Book/EditBook/Id
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string TenSach, decimal GiaBan, int GiaBia, string AnhBia)
        {
            DataBook data = new DataBook();
            var list = data.SACHes.ToList();
            SACH book = list.FirstOrDefault(p => p.MaSach == id);
            if (book != null)
            {
                book.TenSach = TenSach;
                book.GiaBan = GiaBan;
                book.GiaBia = GiaBia;
                book.AnhBia = AnhBia;
                data.SACHes.AddOrUpdate (book);
                data.SaveChanges();
            }    
           
            return RedirectToAction("listBook", list);
        }
        //xóa
        public ActionResult deleteBook(int id)
        {
            DataBook data = new DataBook();
            var list = data.SACHes.ToList();
            SACH b = new SACH();
            foreach (SACH i in list)
            {
                if (i.MaSach == id)
                {
                    b = i;
                    break;
                }    
            }
            if (b == null)
                return HttpNotFound();
            return View(b);
        }
        [HttpPost, ActionName("deleteBook")]
        [ValidateAntiForgeryToken]
        public ActionResult deleteBookConfirm(int id)
        {
           
            DataBook data = new DataBook();
            var list = data.SACHes.ToList();
            SACH book = list.FirstOrDefault(p => p.MaSach == id);
            if (book != null)
            {
                data.SACHes.Remove(book);
                data.SaveChanges();
            }

            return RedirectToAction("listBook", list);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}