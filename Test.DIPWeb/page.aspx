<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="page.aspx.cs" Inherits="Test.DIPWeb.page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
       
        <table style="width: 100%; text-align: center; background-color: navy;">
            <tr style="color: #fff;">
                <td>编号</td>
                <td>用户名</td>
                <td>密码</td>
                <td>昵称</td>
                <td>年龄</td>
                <td>性别</td>
                <td>生日</td>
                <td>民族</td>
                <td>操作</td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr style="background-color: #fff;">
                        <td><%#Eval("Ids") %></td>
                        <td><%#Eval("UserName") %></td>
                        <td><%#Eval("PassWord") %></td>
                        <td><%#Eval("NickName") %></td>
                        <td><%#Eval("Age") %></td>
                        <td><%#Eval("SexStr") %></td>
                        <td><%#Eval("Birthday","{0:yyyy年MM月dd日}") %></td>
                        <td><%#Eval("NationName") %></td>
                        <td>
                            <a href="edit.aspx?id=<%#Eval("Ids") %>">编辑</a>
                            <a href="remove.aspx?id=<%#Eval("Ids") %>">删除</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <a href="add.aspx">添加</a>   <%= str %>
    </form>
</body>
</html>
