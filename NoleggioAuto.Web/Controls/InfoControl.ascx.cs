using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NoleggioAuto.Web.Controls
{
    public partial class InfoControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMessage(TipoInfo tipoInfo, string testo)
        {
            this.panelInfo.Visible = true;
            string cssClass;
            switch (tipoInfo)
            {
                case TipoInfo.Danger:
                    cssClass = "btn-danger";
                    break;
                case TipoInfo.Info:
                    cssClass = "btn-info";
                    break;
                case TipoInfo.Success:
                    cssClass = "btn-success";
                    break;
                case TipoInfo.Warning:
                    cssClass = "btn-warning";
                    break;
                default:
                    cssClass = "btn-primary";
                    break;
            }
            this.DescrizioneMessaggio.Text = testo;
            panelInfo.Attributes["class"] = "form-control " + cssClass;
        }
        public enum TipoInfo
        {
            Info, Danger, Success, Warning
        }
    }
}