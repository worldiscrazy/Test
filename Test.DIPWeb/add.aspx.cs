using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Test.BDFactory;
using Test.IBLL;
using Test.Model;

namespace Test.DIPWeb
{
    public partial class add : System.Web.UI.Page
    {


        IUserBLL userBLL = new Factory<Users>().CreateBLL<IUserBLL>("UserBLL");
        INationBLL nationBLL = new Factory<Nation>().CreateBLL<INationBLL>("NationBLL");

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Click += Button1_Click;

            if (!IsPostBack)
            {
                select_nation.DataSource = nationBLL.Get().ToList();
                select_nation.DataValueField = "NationCode";
                select_nation.DataTextField = "NationName";
                select_nation.DataBind();
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.UserName = txt_username.Text;
            u.PassWord = txt_password.Text;
            u.NickName = txt_nickname.Text;
            u.Sex = Convert.ToBoolean(RadioButtonList1.SelectedItem.Value);
            u.Birthday = Convert.ToDateTime(txt_birthday.Text);
            u.NationCode = select_nation.SelectedItem.Value;

            userBLL.Add(u);
            Response.Redirect("page.aspx");
        }

    }
}