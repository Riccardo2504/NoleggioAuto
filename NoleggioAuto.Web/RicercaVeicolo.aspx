<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaVeicolo.aspx.cs" Inherits="NoleggioAuto.Web.RicercaVeicolo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
   
    <br />

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Ricerca Veicolo</h3>
        </div>
        <div>
        <formview class ="col-md-4">
            <label for="txtRicercaMarca">Marca</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control select2"></asp:DropDownList>
        </formview>
            </div>
        <br />

            <div class="form-group">
                <label for="txtRicercaModello">Modello</label>
                <asp:TextBox runat="server" ID="txtRicercaModello" CssClass ="form-control">
                </asp:TextBox>
            </div>
           
           <div>
        <formview class ="col-md-4">
            <label for="txtRicercaAlimentazione">Alimentazione</label>
            <asp:DropDownList ID="ddlAlimentazione" runat="server" CssClass="form-control select2"></asp:DropDownList>
        </formview>
            </div>
        <br />
            <div class="form-group">
                <label for="txtRicercaDataImmatricolazioneDa">Data di immatricolazione Da</label>
                <asp:TextBox runat="server" ID="txtRicercaDataImmatricolazioneDa" class="form-control date datepicker">
                </asp:TextBox>
            </div>

        <div class="form-group">
                <label for="txtRicercaDataImmatricolazioneA">Data di immatricolazione A</label>
                <asp:TextBox runat="server" ID="txtRicercaDataImmatricolazioneA" class="form-control date datepicker">
                </asp:TextBox>
            </div>

            <div class="form-group ">
                <label for="txtTarga">Targa</label>
                <asp:TextBox runat="server" ID="txtRicercaTarga" CssClass="form-control">
                </asp:TextBox>
            </div>

            <asp:Button runat="server" ID="btnInserisci" Text="Cerca" CssClass="btn btn-default" OnClick="btnCerca_Click" />
            <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-default" OnClick="btnClear_Click" />
        </div>

        <asp:GridView runat="server" AutoGenerateSelectButton="true" ID="gvRicercaVeicolo" CssClass="table table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="False" meta:resourcekey="gvDocumentiResource1"  DataKeyNames="Id" OnRowCommand="gvRicercaVeicolo_RowCommand">
        <Columns>
            <%--<asp:BoundField DataField="Id" HeaderText="Id" Visible="False" meta:resourcekey="BoundFieldResource1">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>--%>
            <asp:BoundField DataField="Id" HeaderText="Id" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Descrizione" HeaderText="Marca" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText="Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DescrizioneAlimentazione" HeaderText="Alimentazione" >
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="DataImmatricolazione" HeaderText="DataImmatricolazione" DataFormatString="{0:dd/MM/yyyy}" >
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
             <asp:buttonfield buttontype="Button" 
            commandname="Elimina"
            headertext="Elimina" 
            text="Elimina"/>
        </Columns>
    </asp:GridView>

</asp:Content>
