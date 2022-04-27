using NoleggioAuto.Business.Managers;
using NoleggioAuto.Business.Models;
using NoleggioAuto.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioAuto.Web
{
    public partial class Veicolo : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
            List<VeicoloModelView> veicoloList = veicoloManager.GetVeicoloList(veicolo);
            gvVeicolo.DataSource = veicoloList;
            gvVeicolo.DataBind();
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
          
        }
        
        protected void gvVeicolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Dettagli")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var Id = Convert.ToInt32(gvVeicolo.Rows[index].Cells[0].Text);
                Session["Id"] = Id;
                Response.Redirect("DettaglioVeicolo.aspx");
            }
            if (e.CommandName == "Elimina")
            {
                var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
                int index = Convert.ToInt32(e.CommandArgument);
                var Id = Convert.ToInt32(gvVeicolo.Rows[index].Cells[0].Text);
                veicoloManager.EliminaVeicolo(Id);
                
            }
        }
    }
}