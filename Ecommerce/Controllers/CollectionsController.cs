using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class CollectionsController : Controller
    {
        DoAnEntities database = new DoAnEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Menu(string Searching)
        {
            if(Searching != null)
            {
                Session["search"]=Searching;
            }
            return View(database.Products.Where(x=>x.NamePro.Contains(Searching)||Searching==null).ToList());
            
        }
    }
}