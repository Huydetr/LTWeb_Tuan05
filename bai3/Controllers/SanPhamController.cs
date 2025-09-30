using bai3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bai3.Controllers
{
    public class SanPhamController : Controller
    {
        private SanPhamDAO dao = new SanPhamDAO();

        // 1 & 2. Trang hiển thị danh sách sản phẩm (có thể lọc)
        // URL: /SanPham/Index?MaLoai=X
        public ActionResult Index(int MaLoai = 0)
        {
            // Lấy danh sách sản phẩm (lọc theo MaLoai nếu có)
            var sanPhamList = dao.GetSanPham(MaLoai);

            // Lấy danh sách loại để hiển thị menu
            ViewBag.LoaiList = dao.GetLoaiSanPham();

            // Truyền danh sách sản phẩm sang View
            return View(sanPhamList);
        }

        // 4. Trang tìm kiếm theo tiêu đề gần đúng
        // URL: /SanPham/TimKiem?TuKhoa=Iphone
        public ActionResult TimKiem(string TuKhoa)
        {
            ViewBag.TuKhoa = TuKhoa;
            if (string.IsNullOrEmpty(TuKhoa))
            {
                return View(new List<SanPham>());
            }

            var sanPhamList = dao.GetSanPham(tuKhoa: TuKhoa);
            return View(sanPhamList);
        }
    }
}