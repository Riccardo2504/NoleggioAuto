using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioAuto.Web
{
    public partial class PaginaPrincipale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPaginaLista_Click(object sender, EventArgs e)
        {
            Response.Redirect("Veicolo.aspx");
        }

        protected void btnInserisciVeicolo_Click(object sender, EventArgs e)
        {
            Response.Redirect("InserisciVeicolo.aspx");
        }

        protected void btnRicercaVeicolo_Click(object sender, EventArgs e)
        {
            Response.Redirect("RicercaVeicolo.aspx");
        }
    }
}