<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaPrincipale.aspx.cs" Inherits="NoleggioAuto.Web.PaginaPrincipale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" ID="btnPaginaLista" Text="Visualizza tutti i veicoli nella lista" OnClick="btnPaginaLista_Click" />
    <asp:Button runat="server" ID="btnInserisciVeicolo" Text="Inserisci un veicolo nel DB" OnClick="btnInserisciVeicolo_Click" />
    <asp:Button runat="server" ID="btnRicercaVeicolo" Text="Cerca dati specifici" OnClick="btnRicercaVeicolo_Click" />
</asp:Content>
