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
    public partial class DettaglioVeicolo : System.Web.UI.Page
    {
        public static int IdLocal {get; set;}
        public static List<int> listID = new List<int>();
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



            if (!IsPostBack)
            {
                listID = (List<int>)Session["IdList"];
                IdLocal = (int)Session["Id"];
                PopolaCampi();
                
            }
        }
        protected void PopolaCampi()
        {
            string dettaglio = "";
           
            var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
            VeicoloModel veicolo = veicoloManager.CercaVeicoloById(Convert.ToInt32(IdLocal));

            ddlMarca.Text = veicolo.IdMarca.ToString();
            txtDettaglioModello.Text = veicolo.Modello;
            ddlAlimentazione.Text = veicolo.IdAlimentazione.ToString();
            if (veicolo.DataImmatricolazione.HasValue)
            {
                var dt = (DateTime)veicolo.DataImmatricolazione;
                dettaglio = dt.ToShortDateString();
            }
            txtDettaglioDataImmatricolazione.Text = dettaglio;
            txtDettaglioTarga.Text = veicolo.Targa;
            txtDettaglioNote.Text = veicolo.Note;
            if (veicolo.DataInserimento.HasValue)
            {
                var dt = (DateTime)veicolo.DataInserimento;
                dettaglio = dt.ToShortDateString();
            }
            txtDettaglioInserimento.Text = dettaglio;
            if (veicolo.DataModifica.HasValue)
            {
                var dt = (DateTime)veicolo.DataModifica;
                dettaglio = dt.ToShortDateString();
            }
            txtDettaglioDataModifica.Text = dettaglio;
            ViewState["id"] = IdLocal;
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {
            var veicoloManager = new VeicoloManager(Settings.Default.Stage2022ConnectionString);
            var veicoloModel = veicoloManager.CercaVeicoloById(Convert.ToInt32(ViewState["id"]));

            veicoloModel.IdMarca = Convert.ToInt32(ddlMarca.SelectedValue);
            veicoloModel.Modello = txtDettaglioModello.Text;
            veicoloModel.IdAlimentazione = Convert.ToInt32(ddlMarca.SelectedValue);
            var parseOk = DateTime.TryParse(txtDettaglioDataImmatricolazione.Text, out DateTime dt);
            if (parseOk)
            {
                veicoloModel.DataImmatricolazione = dt;
            }
            veicoloModel.Targa = txtDettaglioTarga.Text;
            veicoloModel.Note = txtDettaglioNote.Text;

            veicoloManager.UpdateVeicolo(veicoloModel);
        }

        protected void btnAvantiVeicolo_Click(object sender, EventArgs e)
        {
            IdLocal = listID[listID.IndexOf(IdLocal) + 1];
            PopolaCampi();
            if (listID.IndexOf(IdLocal)==(listID.Count()) - 1)
            {
                btnAvantiVeicolo.Visible = false;
            }
            else
            {
                btnAvantiVeicolo.Visible = true;
            }
            if (listID.IndexOf(IdLocal) == 0)
            {
                btnIndietroVeicolo.Visible = false;
            }
            else
            {
                btnIndietroVeicolo.Visible = true;
            }
        }

        protected void btnIndietroVeicolo_Click(object sender, EventArgs e)
        {
            IdLocal = listID[listID.IndexOf(IdLocal) - 1];
            PopolaCampi();
            if (listID.IndexOf(IdLocal) == 0)
            {
                btnIndietroVeicolo.Visible = false;
            }
            else
            {
                btnIndietroVeicolo.Visible = true;
            }
            if (listID.IndexOf(IdLocal) == listID.Count() - 1)
            {
                btnAvantiVeicolo.Visible = false;
            }
            else
            {
                btnAvantiVeicolo.Visible = true;
            }
        }
    }
}