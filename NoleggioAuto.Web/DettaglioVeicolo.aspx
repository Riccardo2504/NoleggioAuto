<%@ Page Title="DettaglioVeicolo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioVeicolo.aspx.cs" Inherits="NoleggioAuto.Web.DettaglioVeicolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="panel-body">

        <asp:Button runat="server" ID="btnIndietroVeicolo" Text="Veicolo Precedente" CssClass="btn btn-default" OnClick="btnIndietroVeicolo_Click " Visible="false" />
        <asp:Button runat="server" ID="btnAvantiVeicolo" Text="Veicolo Successivo" CssClass="btn btn-default" OnClick="btnAvantiVeicolo_Click" Visible="false" />
        
    </div>

   <div>
        <formview class ="col-md-4">
            <label for="txtMarca">Marca</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control select2"></asp:DropDownList>
        </formview>
            </div>
        <br />

    <div class="panel-body">
        <label for="txtDettagliModello">Modello</label>
        <asp:TextBox runat="server" ID="txtDettaglioModello" CssClass="form-control" Text="" ReadOnly="false">

        </asp:TextBox>
    </div>
    <div class="panel-body">
        <label for="txtDettaglioDataImmatricolazione">Data Di Immatricolazione (dd/mm/yyyy) </label>
        <asp:TextBox runat="server" ID="txtDettaglioDataImmatricolazione" CssClass="form-control" Text="" ReadOnly="false">

        </asp:TextBox>

    </div>
   <div>
        <formview class ="col-md-4">
            <label for="txtAlimentazione">Alimentazione</label>
            <asp:DropDownList ID="ddlAlimentazione" runat="server" CssClass="form-control select2"></asp:DropDownList>
        </formview>
            </div>
        <br />


    <div class="panel-body">
        <label for="txtDettaglioTarga">Targa </label>
        <asp:TextBox runat="server" ID="txtDettaglioTarga" CssClass="form-control" Text="" ReadOnly="false">

        </asp:TextBox>
    </div>
    <div class="panel-body">
        <label for="txtDettaglioNote">Note </label>
        <asp:TextBox runat="server" ID="txtDettaglioNote" CssClass="form-control" Text="" ReadOnly="false">

        </asp:TextBox>
    </div>

    <div class="panel-body">
        <label for="txtDettaglioInserimento">Data Inserimento </label>
        <asp:TextBox runat="server" ID="txtDettaglioInserimento" CssClass="form-control" Text="" ReadOnly="true">

        </asp:TextBox>
    </div>
    <div class="panel-body">
        <label for="txtDettaglioDataModifica">Ultima Modifica</label>
        <asp:TextBox runat="server" ID="txtDettaglioDataModifica" CssClass="form-control" Text="" ReadOnly="true">
        </asp:TextBox>
   
    </div>
    <div class="panel-body"> 
        
        <asp:Button runat="server" ID="Button1" Text="Modifica" CssClass="btn btn-default" OnClick="btnModifica_Click" />
        
    </div>

</asp:Content>
