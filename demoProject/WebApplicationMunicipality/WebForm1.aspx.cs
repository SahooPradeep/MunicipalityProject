using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationMunicipality
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.ServiceClient serviceClient = new ServiceReference1.ServiceClient();

            try
            {
                serviceClient.getTaxdetails(TextBox1.Text, TextBox2.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}