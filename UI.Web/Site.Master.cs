﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void lbCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["UsuarioActual"] = null;
            Page.Response.Redirect("~/Login.aspx");
        }
    }
}