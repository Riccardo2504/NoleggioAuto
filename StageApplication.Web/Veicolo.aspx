<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Veicolo.aspx.cs" Inherits="NoleggioAuto.Web.Veicolo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView runat="server" ID="gvVeicolo" CssClass="table table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="False" meta:resourcekey="gvDocumentiResource1" OnRowCommand="gvVeicolo_RowCommand">
        <Columns>
            <%--<asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>--%>

            <asp:BoundField DataField="Id" HeaderText="Id" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText="Modello" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="IdAlimentazione" HeaderText="Alimentazione" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DataImmatricolazione" HeaderText="Data Immatricolazione" DataFormatString="{0:dd/MM/yyyy}" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Targa" HeaderText="Targa" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Note" HeaderText="Note" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:buttonfield buttontype="Button" 
            commandname="Dettagli"
            headertext="Dettagli" 
            text="Dettagli"/>
        </Columns>
    </asp:GridView>

</asp:Content>
