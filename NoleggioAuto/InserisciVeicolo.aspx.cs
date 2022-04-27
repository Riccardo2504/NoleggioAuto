﻿using NoleggioAuto.Business.Managers;
using NoleggioAuto.Business.Models;
using NoleggioAuto.Web.Controls;
using NoleggioAuto.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioAuto.Web
{
    public partial class InserisciVeicolo : System.Web.UI.Page
    {
        private static string Messaggio { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var veicoloManager = new VeicoloManager(Settings.Default.ARCAConnectionString);
                var listaMarche = veicoloManager.PopolaMarche();
                ddlMarca.DataSource = listaMarche;
                ddlMarca.DataTextField = nameof(MarcaModel.Descrizione);
                ddlMarca.DataValueField = nameof(MarcaModel.Id);
                ddlMarca.DataBind();
                ddlMarca.SelectedIndex = -1;
            }
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {
            var personaManager = new VeicoloManager(Settings.Default.ARCAConnectionString);

            if (!IsFormValido())
            {
                //Visualizza un messaggio di errore
                infoControl.SetMessage(InfoControl.TipoInfo.Warning, Messaggio);
                return;
            }

            var veicoloModel = new VeicoloModel();
            veicoloModel.IdMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            veicoloModel.Cognome = txtModello.Text;
            veicoloModel.IdAlimentazione = Convert.ToInt32(ddlAlimentazione.SelectedValue);
            var parseOk = DateTime.TryParse(txtDataImmatricolazione.Text, out DateTime dt);
            if (parseOk)
            {
                veicoloModel.DataImmatricolazione = dt;
            }
            veicoloModel.Email = txtTarga.Text;
            veicoloModel.Telefono = txtNote.Text;
            var inserito = veicoloManager.InsertVeicolo(veicoloModel);

            if (inserito)
            {
                Messaggio = "Tutti i campi sono stati inseriti correttamente";
                infoControl.SetMessage(InfoControl.TipoInfo.Success, Messaggio);
            }
        }

        protected bool IsFormValido()
        {
            // Marca
            if (string.IsNullOrWhiteSpace(txtIdMarca.Text))
            {
                Messaggio = "Il campo marca non può essere vuoto";
                return false;
            }

            // Modello
            if (string.IsNullOrWhiteSpace(txtModello.Text))
            {
                Messaggio = "Il campo modello non può essere vuoto";
                return false;
            }

            // Data Immatricloazione
            if (string.IsNullOrWhiteSpace(txtDataImmatricolazione.Text))
            {
                Messaggio = "Il campo data di immatricolazione non può essere vuoto";
                if (!DateTime.TryParse(txtDataImmatricolazione.Text, out DateTime dt))
                    Messaggio = $"Il formato della data non è corretto {dt}";
                return false;
            }

            // Alimentazione
            if (string.IsNullOrWhiteSpace(txtIdAlimentazione.Text))
            {
                Messaggio = "Il campo alimentazione non può essere vuoto";
                return false;
            }

            //Targa
            if (string.IsNullOrWhiteSpace(txtTarga.Text))
            {
                Messaggio = "Il campo targa email non può essere vuoto";
                return false;
            }
        }
    }
}