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
    public partial class page : System.Web.UI.Page
    {

        IUserBLL userBll = new Factory<Users>().CreateBLL<IUserBLL>("UserBLL");

        private int id=0;
        public string str;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                //string ids = Request["id"].ToString();// Convert.ToInt32(Request["id"].ToString());

                //string flag = int.TryParse(ids, out id).ToString();

                //str = flag.ToString();

                Repeater1.DataSource = userBll.Get().ToList();
                Repeater1.DataBind();
            }

        }
    }
}