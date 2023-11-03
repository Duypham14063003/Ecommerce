using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class AdminController : Controller
    {
        private DoAnEntities1 database = new DoAnEntities1();
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(AdminUser ad)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(ad.NameUser))
                    ModelState.AddModelError(string.Empty, "Tên đăng nhập này không được để trống");
                if (string.IsNullOrEmpty(ad.PasswordUser))
                    ModelState.AddModelError(string.Empty, "Mật khẩu không được để trống");
                if (ModelState.IsValid)
                {
                    var admin = database.AdminUsers.FirstOrDefault(s => s.NameUser == ad.NameUser && s.PasswordUser == ad.PasswordUser);
                    if (admin != null)
                    {
                        Session["ADMIN"] = admin.NameUser;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng! Vui lòng kiểm tra lại";
                }

            }
            return View();
        }
    }
}