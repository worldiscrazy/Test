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
    public partial class remove : System.Web.UI.Page
    {

        private IUserBLL userBLL = new Factory<Users>().CreateBLL<IUserBLL>("UserBLL");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string id = Request["id"].ToString();
                userBLL.Remove(Convert.ToInt32(id));
                Response.Redirect("page.aspx");
            }
        }
    }
}