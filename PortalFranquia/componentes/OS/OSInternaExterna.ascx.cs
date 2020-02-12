using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalFranquia.componentes.OS
{
    public partial class OSInternaExterna : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool getOSInterna()
        {
            return rbOSInterna.Checked;
        }
    }
}