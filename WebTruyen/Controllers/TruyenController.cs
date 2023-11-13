using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
    
    public class TruyenController : Controller
    {
        dataDataContext data = new dataDataContext();
        // GET: Truyen


        public ActionResult Index(int id)
        {
            /*var truyen = from s in data.Truyens
                         where s.MaTruyen == id
                         select s;
            return View(truyen);*/
            Chuong model = data.Chuongs.FirstOrDefault(c => c.MaTruyen == id);
            return View(model);
        }
        public ActionResult Chuong(int id)
        {

            var item = from c in data.Chuongs where c.MaTruyen == id select c;

            /*       var item = from c in data.Chuongs select c;*/
            return PartialView(item);
        }





    }
}
