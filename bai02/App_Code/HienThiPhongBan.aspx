<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HienThiPhongBan.aspx.cs" Inherits="HienThiPhongBan" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Danh sách Phòng ban</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>HienThiPhongBan</h2>
        <asp:GridView ID="gvPhongBan" runat="server" AutoGenerateColumns="False" DataKeyNames="MaPhong" 
            CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:BoundField DataField="MaPhong" HeaderText="Mã Phòng" />
                <asp:BoundField DataField="TenPhong" HeaderText="Tên Phòng" />
                <asp:TemplateField HeaderText="Chức năng">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlChiTiet" runat="server" Text="Xem chi tiết" 
                            NavigateUrl='<%# "ChiTietPhongBan.aspx?MaPB=" + Eval("MaPhong") %>' />
                        |
                        <asp:HyperLink ID="hlNhanVien" runat="server" Text="Xem nhân viên" 
                            NavigateUrl='<%# "ShowListEmplyByDept.aspx?MaPB=" + Eval("MaPhong") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>