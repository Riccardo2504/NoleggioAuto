﻿using NoleggioAuto.Business.Managers;
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
    public partial class RicercaVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
                var listaMarche = veicoloManager.PopolaMarche();
                ddlMarca.DataSource = listaMarche;
                ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
                ddlMarca.DataValueField = nameof(MarcaModel.Id);
                ddlMarca.DataBind();
                ddlMarca.SelectedIndex = -1;
            }

            if (!IsPostBack)
            {
                var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
                var listaAlimentazioni = veicoloManager.PopolaAlimentazione();
                ddlAlimentazione.DataSource = listaAlimentazioni;
                ddlAlimentazione.DataTextField = nameof(AlimentazioneModel.Descrizione);
                ddlAlimentazione.DataValueField = nameof(AlimentazioneModel.Id);
                ddlAlimentazione.DataBind();
                ddlAlimentazione.SelectedIndex = -1;
            }

        }
        
        protected void btnCerca_Click(object sender, EventArgs e)
        {
            
            var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
            var veicoloModel = new VeicoloManager.RicercaVeicolo()
            {
                IdMarca = Convert.ToInt32(ddlAlimentazione.SelectedValue),
                Modello = txtRicercaModello.Text,
                IdAlimentazione = Convert.ToInt32(ddlAlimentazione.SelectedValue),
                DataImmatricolazione = DateTime.Parse(txtRicercaDataImmatricolazione.Text),
                Targa = txtRicercaTarga.Text
            };

            List<int> listId = new List<int>();

            var veicoloList = veicoloManager.RicercaVeicolo1(veicoloModel);
            foreach (var item in veicoloList)
            {
                listId.Add(item.Id);
            }
            Session["IdList"] = listId;
            gvRicercaVeicolo.DataSource = veicoloList;
            gvRicercaVeicolo.DataBind();
            
        }
        
        protected void gvRicercaVeicolo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Dettagli") 
            {
                
                int index = Convert.ToInt32(e.CommandArgument);
                var Id = Convert.ToInt32(gvRicercaVeicolo.DataKeys[index].Value.ToString());
                Session["Id"] = Id;
                Response.Redirect("DettaglioVeicolo.aspx");
            }
            if (e.CommandName == "Elimina")
            {
                var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
                int index = Convert.ToInt32(e.CommandArgument);
                var Id = Convert.ToInt32(gvRicercaVeicolo.DataKeys[index].Value.ToString());
                veicoloManager.EliminaVeicolo(Id);
                //riprendi la lista e ricarica la pagina
                var veicoloModel = new VeicoloManager.RicercaVeicolo()
                {
                    IdMarca = Convert.ToInt32(ddlMarca.SelectedValue),
                    Modello = txtRicercaModello.Text,
                    IdAlimentazione = Convert.ToInt32(ddlAlimentazione.SelectedValue),
                    DataImmatricolazione = DateTime.Parse(txtRicercaDataImmatricolazione.Text),
                    Targa = txtRicercaTarga.Text,
                };

                var veicoloList = veicoloManager.RicercaVeicolo1(veicoloModel);

                gvRicercaVeicolo.DataSource = veicoloList;
                gvRicercaVeicolo.DataBind();
            }
        }
    }
}