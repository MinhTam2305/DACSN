using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruyen.Models;
namespace WebTruyen.Models
{
    public class LichSu
    {
        dataDataContext data = new dataDataContext();
        public int iMaTruyen { get; set; }
        public string sTenTruyen { get; set; }
        public string sHinh { get; set; }
       
        public int iSoLuong { get; set; }

        public LichSu(int ms)
        {
            iMaTruyen = ms;
            Truyen truyen = data.Truyens.Single(n => n.MaTruyen == iMaTruyen);
            sTenTruyen = truyen.TenTruyen;
            sHinh = truyen.Hinh;
           
            iSoLuong = 1;

        }

    }
}