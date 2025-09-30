using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

    public class NhanVienDAO
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["QLDuLieuPhongBanDB"].ConnectionString;

        // Lấy danh sách nhân viên theo MaPhong (cho trang ShowListEmplyByDept)
        public DataTable GetNhanVienByPhongBan(int maPhong)
        {
            string sql = @"
            SELECT NV.MaNV, NV.HoTen, NV.GioiTinh, NV.ThanhPho, PB.TenPhong
            FROM NhanVien NV
            INNER JOIN PhongBan PB ON NV.MaPhong = PB.MaPhong
            WHERE NV.MaPhong = @MaPB
            ORDER BY NV.MaNV";

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
