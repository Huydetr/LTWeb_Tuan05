using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


    public partial class HienThiPhongBan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPhongBanData();
            }
        }

        private void LoadPhongBanData()
        {
            try
            {
                PhongBanDAO dao = new PhongBanDAO();
                DataTable dt = dao.GetAllPhongBan();

                // Đổ dữ liệu từ DataTable vào GridView
                gvPhongBan.DataSource = dt;
                gvPhongBan.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: lỗi kết nối CSDL)
                Response.Write("Lỗi khi tải danh sách phòng ban: " + ex.Message);
            }
        }
    }
