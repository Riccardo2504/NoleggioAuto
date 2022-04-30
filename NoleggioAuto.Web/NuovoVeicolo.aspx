<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/NuovoVeicolo.aspx.cs" Inherits="NoleggioAuto.Web.NuovoVeicolo" %>
<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
<script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <br />
    <uc1:Info runat="server" ID="infoControl" />
    <br />

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Inserisci Veicolo</h3>
        </div>

        <br />

        <div>
        <formview class ="col-md-4">
            <label for="txtMarca">Marca</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control select2"></asp:DropDownList>
        </formview>
        </div>

        <br />

        <div class="panel-body">

            <div class="form-group">
                <label for="txtNome">Modello</label>
                <asp:TextBox runat="server" ID="txtModello" CssClass ="form-control">
                </asp:TextBox>
            </div>

            <br />

            <div class="form-group">
                 <label for="txtDataImmatricolazione">Data di immatricolazione (dd/mm/yyyy)</label>               
               <asp:Calendar ID = "txtDataImmatricolazione" runat = "server" SelectionMode="DayWeekMonth"></asp:Calendar>
            <div>

            <br />

        <formview class ="col-md-4">
            <label for="txtAlimentazione">Alimentazione</label>
            <asp:DropDownList ID="ddlAlimentazione" runat="server" CssClass="form-control select2"></asp:DropDownList>
        </formview>
            </div>

            </div>

            <div class="form-group">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtTarga" CssClass ="form-control">
                </asp:TextBox>
            </div>

            </div>

            <div class="form-group">
                <label for="txtNote">Note</label>
                <asp:TextBox runat="server" ID="txtNote" CssClass ="form-control">
                </asp:TextBox>
            </div>

            <asp:Button runat="server" ID="btnInserisci" Text="Inserisci" CssClass="btn btn-default" OnClick="btnInserisci_Click" />
        </div>
    
    <script>
        $('.select2').select2();
    </script>
</asp:Content>
