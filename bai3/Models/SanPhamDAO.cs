using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace bai3.Models
{
    public class SanPhamDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QLDTDDDB"].ConnectionString;

        // Lấy tất cả loại sản phẩm
        public List<Loai> GetLoaiSanPham()
        {
            List<Loai> list = new List<Loai>();
            string sql = "SELECT MaLoai, TenLoai FROM Loai ORDER BY MaLoai";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Loai
                        {
                            MaLoai = (int)reader["MaLoai"],
                            TenLoai = reader["TenLoai"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // Lấy sản phẩm theo Mã loại (MaLoai = 0 nếu muốn lấy tất cả)
        public List<SanPham> GetSanPham(int maLoai = 0, string tuKhoa = null)
        {
            List<SanPham> list = new List<SanPham>();
            string sql = "SELECT MaSP, TenSP, DuongDan, Gia, MoTa, MaLoai FROM SanPham WHERE 1=1";

            if (maLoai > 0)
            {
                sql += " AND MaLoai = @MaLoai";
            }
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                // Tìm kiếm theo tiêu đề gần đúng
                sql += " AND TenSP LIKE @TuKhoa";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (maLoai > 0) cmd.Parameters.AddWithValue("@MaLoai", maLoai);
                    if (!string.IsNullOrEmpty(tuKhoa)) cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new SanPham
                            {
                                MaSP = (int)reader["MaSP"],
                                TenSP = reader["TenSP"].ToString(),
                                DuongDan = reader["DuongDan"].ToString(),
                                Gia = (int)reader["Gia"],
                                MoTa = reader["MoTa"].ToString(),
                                MaLoai = (int)reader["MaLoai"]
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}