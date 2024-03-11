using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Form
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text == "Jeet" && TextBox2.Text == "1234")
            {
                //Button1.PostBackUrl = "~/Contact.aspx";
                Session["UserName"] = TextBox1.Text;
                Response.Redirect("~/Contact.aspx");
            }
            else
            {
                //Button1.PostBackUrl = "~/Default.aspx";
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}