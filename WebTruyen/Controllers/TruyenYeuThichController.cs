using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruyen.Models;

namespace WebTruyen.Controllers
{
   public class TruyenYeuThichController : Controller
    {
        dataDataContext data = new dataDataContext();
        // GET: TruyenYeuThich
        public ActionResult FavoriteBooks()
        {
            /*string loggedInUsername = NguoiDung.Linq.MaNguoiDung; // Lấy thông tin đăng nhập hiện tại

           
                var currentUser = data.NguoiDungs.SingleOrDefault(u => u.TaiKhoan == loggedInUsername);*/
            /* NguoiDung loggedInUser = Session["TaiKhoan"] as NguoiDung;*/



            /* if (Session["TaiKhoan"] != null)
             {
                 var favoriteBooks = data.TruyenYeuThiches.Where(a => a.MaNguoiDung == ND.MaNguoiDung).Select(b => b.MaTruyen).ToList();
                  // Làm việc với danh sách truyện yêu thích tại đây và truyền chúng đến view
                  return View(favoriteBooks);
              }*/

            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;

            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);
            if (currentUser != null)
            {
                
                var favoriteBooks = data.TruyenYeuThiches.Where(a => a.MaNguoiDung == currentUser.MaNguoiDung ).ToList();
                // Làm việc với danh sách truyện yêu thích tại đây và truyền chúng đến view
                return View(favoriteBooks);
            }
            return View();
           
           
        }
      
        public ActionResult AddTruyenYeuThich(int MaTruyen)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }

            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;
            
            var currentUser = data.NguoiDungs.SingleOrDefault(u => u.MaNguoiDung == ND.MaNguoiDung);

          
            if (currentUser != null)
            {
                var truyenYeuThich= new TruyenYeuThich
                {
                    MaNguoiDung = currentUser.MaNguoiDung,
                    MaTruyen = MaTruyen
                };
                data.TruyenYeuThiches.InsertOnSubmit(truyenYeuThich);
                data.SubmitChanges();
            }
            return RedirectToAction("Index", "TrangChu");
        }
        
       
        public ActionResult RemoveFromFavorites(int bookid)
        {
            NguoiDung ND = Session["TaiKhoan"] as NguoiDung;

            

                var favoriteBook = data.TruyenYeuThiches.FirstOrDefault(a => a.MaNguoiDung == ND.MaNguoiDung);
                if (favoriteBook != null)
                {
                    data.TruyenYeuThiches.DeleteOnSubmit(favoriteBook);
                    data.SubmitChanges();
                }
                else
            {
                return RedirectToAction("Index", "TrangChu");
            }

            // Redirect hoặc trả về view tùy thuộc vào logic ứng dụng của bạn
            return RedirectToAction("FavoriteBooks", "TruyenYeuThich");
        }
    }
}