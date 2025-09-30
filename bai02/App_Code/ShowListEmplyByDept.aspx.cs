using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



    public partial class ShowListEmplyByDept : System.Web.UI.Page
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
                        LoadNhanVien(maPB);
                    }
                    else
                    {
                        Response.Write("Mã phòng ban không hợp lệ.");
                    }
                }
                else
                {
                    Response.Write("Vui lòng chọn một phòng ban để xem nhân viên.");
                }
            }
        }

        private void LoadNhanVien(int maPB)
        {
            NhanVienDAO nvDao = new NhanVienDAO();
            DataTable dt = nvDao.GetNhanVienByPhongBan(maPB);

            // Lấy tên phòng ban để hiển thị tiêu đề
            if (dt.Rows.Count > 0)
            {
                lblTenPhong.Text = dt.Rows[0]["TenPhong"].ToString();
            }
            else
            {
                // Nếu không có nhân viên, vẫn cố gắng lấy tên phòng ban
                PhongBanDAO pbDao = new PhongBanDAO();
                DataTable pbDt = pbDao.GetChiTietPhongBan(maPB);
                if (pbDt.Rows.Count > 0)
                {
                    lblTenPhong.Text = pbDt.Rows[0]["TenPhong"].ToString();
                }
            }

            // Đổ dữ liệu nhân viên vào GridView
            gvNhanVien.DataSource = dt;
            gvNhanVien.DataBind();

            if (dt.Rows.Count == 0)
            {
                // Thông báo nếu không có nhân viên
                Response.Write("<p>Phòng ban này hiện chưa có nhân viên nào.</p>");
            }
        }
    }
