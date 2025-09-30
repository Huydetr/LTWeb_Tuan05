<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowListEmplyByDept.aspx.cs" Inherits="ShowListEmplyByDept" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Danh sách Nhân viên</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>DANH SÁCH NHÂN VIÊN THEO PHÒNG BAN</h2>
        <h3>PHÒNG: <asp:Label ID="lblTenPhong" runat="server" Font-Bold="True"></asp:Label></h3>
        
        <asp:GridView ID="gvNhanVien" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="MaNV" HeaderText="Mã NV" />
                <asp:BoundField DataField="HoTen" HeaderText="Họ Tên" />
                <asp:BoundField DataField="GioiTinh" HeaderText="Giới Tính" />
                <asp:BoundField DataField="ThanhPho" HeaderText="Thành Phố" />
            </Columns>
        </asp:GridView>

        <p><a href="HienThiPhongBan.aspx">Back to Deparments List.</a></p>
    </form>
</body>
</html>