using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bai3.Models
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string DuongDan { get; set; }
        public int Gia { get; set; }
        public string MoTa { get; set; }
        public int MaLoai { get; set; }
        // Có thể thêm thuộc tính TenLoai nếu cần hiển thị
    }
}