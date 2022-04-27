
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipale.aspx.cs" Inherits="NoleggioAuto.Web.PaginaPrincipale" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" ID="Button1" Text="Visualizza tutti i veicoli nella lista" OnClick="btnPaginaLista_Click" />
    <asp:Button runat="server" ID="Button2" Text="Inserisci un veicolo nel DB" OnClick="btnInserisciVeicolo_Click" />
    <asp:Button runat="server" ID="Button3" Text="Cerca veicoli specifici" OnClick="btnRicercaVeicolo_Click" />
</asp:Content>
