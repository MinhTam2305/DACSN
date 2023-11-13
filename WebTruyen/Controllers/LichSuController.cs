using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;


namespace WebTruyen.Controllers
{
    public class LichSuController : Controller
    {
        // GET: LichSu
        public List<LichSu> LayTruyenLS()
        {
            List<LichSu> lstLichSu = Session["LichSu"] as List<LichSu>;
            if (lstLichSu== null)
            {
                lstLichSu = new List<LichSu>();
                Session["LichSu"] = lstLichSu;
            }
            return lstLichSu;
        }
        public ActionResult ThemTruyen(int truyen, string url)
        {
            List<LichSu> lstLichSu = LayTruyenLS();
            LichSu truyenls = lstLichSu.Find(n => n.iMaTruyen == truyen);
            if (truyenls == null)
            {
                truyenls = new LichSu(truyen);
                lstLichSu.Add(truyenls);
            }
            else
            {
                truyenls.iSoLuong++;

            }
            return Redirect(url);
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<LichSu> lstLichSu = Session["LichSu"] as List<LichSu>;
            if (lstLichSu != null)
            {
                iTongSoLuong = lstLichSu.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        public ActionResult LichSu()
        {
            List<LichSu> lstLichSu = LayTruyenLS();
            if (lstLichSu.Count == 0)
            {
                return RedirectToAction("Index", "TrangChu");
            }
        
            return View(lstLichSu);
        }
    }
}