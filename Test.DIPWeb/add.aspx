<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Test.DIPWeb.add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>添加用户</h1>
            <h4>没写限制，不要为空，生日格式不要错</h4>
            用户名：<asp:TextBox ID="txt_username" runat="server"></asp:TextBox><br />
            <br />
            密码：<asp:TextBox ID="txt_password" runat="server"></asp:TextBox><br />
            <br />
            昵称：<asp:TextBox ID="txt_nickname" runat="server"></asp:TextBox><br />
            <br />
            性别：<asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="True" Selected="True">男</asp:ListItem>
                <asp:ListItem Value="False">女</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            生日：<asp:TextBox ID="txt_birthday" runat="server"></asp:TextBox>请按照格式：yyyy-MM-dd，不然要报错哒
            <br />
            <br />
            民族：<asp:DropDownList ID="select_nation" runat="server"></asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="立即保存" />
        </div>
    </form>
</body>
</html>
