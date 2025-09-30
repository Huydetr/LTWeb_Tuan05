using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class ChiTietPhongBan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lấy MaPB từ Query String
                if (Request.QueryString["MaPB"] != null)
                {
                    if (int.TryParse(Request.QueryString["MaPB"], out int maPB))
                    {
                        LoadChiTiet(maPB);
                    }
                    else
                    {
                        Response.Write("Mã phòng ban không hợp lệ.");
                    }
                }
                else
                {
                    Response.Write("Vui lòng chọn một phòng ban để xem chi tiết.");
                }
            }
        }

        private void LoadChiTiet(int maPB)
        {
            PhongBanDAO dao = new PhongBanDAO();
            DataTable dt = dao.GetChiTietPhongBan(maPB);

            if (dt.Rows.Count > 0)
            {
                // Hiển thị dữ liệu từ DataTable
                DataRow row = dt.Rows[0];
                lblMaPB.Text = row["MaPhong"].ToString();
                lblTenPB.Text = row["TenPhong"].ToString();
                lblSoNV.Text = row["SoNV"].ToString();
            }
            else
            {
                Response.Write("Không tìm thấy thông tin chi tiết của phòng ban này.");
            }
        }
    }
