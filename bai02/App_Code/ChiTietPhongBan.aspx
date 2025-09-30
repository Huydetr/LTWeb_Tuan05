<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiTietPhongBan.aspx.cs" Inherits="ChiTietPhongBan" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Chi Tiết Phòng Ban</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>CHI TIẾT PHÒNG BAN</h2>
        <p>
            <b>Mã PB:</b> <asp:Label ID="lblMaPB" runat="server"></asp:Label><br />
            <b>Tên PB:</b> <asp:Label ID="lblTenPB" runat="server"></asp:Label><br />
            <b>Số NV:</b> <asp:Label ID="lblSoNV" runat="server"></asp:Label>
        </p>
        <p><a href="HienThiPhongBan.aspx">Quay lại Danh sách Phòng ban</a></p>
    </form>
</body>
</html>