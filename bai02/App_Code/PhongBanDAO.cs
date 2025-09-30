using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

    public class PhongBanDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QLDuLieuPhongBanDB"].ConnectionString;

        // 1. Lấy tất cả phòng ban (cho trang HienThiPhongBan)
        public DataTable GetAllPhongBan()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT MaPhong, TenPhong FROM PhongBan ORDER BY MaPhong";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        // 2. Lấy chi tiết phòng ban và số lượng nhân viên (cho trang ChiTietPhongBan)
        public DataTable GetChiTietPhongBan(int maPhong)
        {
            string sql = @"
            SELECT 
                PB.MaPhong, 
                PB.TenPhong, 
                COUNT(NV.MaNV) AS SoNV
            FROM PhongBan PB
            LEFT JOIN NhanVien NV ON PB.MaPhong = NV.MaPhong
            WHERE PB.MaPhong = @MaPB
            GROUP BY PB.MaPhong, PB.TenPhong";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPB", maPhong);
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
