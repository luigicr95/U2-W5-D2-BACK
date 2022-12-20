<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="AggiungiDipendente.aspx.cs" Inherits="U2_W5_D2_BACK.AggiungiDipendente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <asp:TextBox ID="TextNome" CssClass="form-control mt-1" placeholder="Nome" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextCognome" CssClass="form-control mt-1" placeholder="Cognome" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextIndirizzo" CssClass="form-control mt-1" placeholder="Indirizzo" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextCodiceFiscale" CssClass="form-control mt-1" placeholder="Codice Fiscale" runat="server"></asp:TextBox>
        <asp:CheckBox ID="CheckConiugato" CssClass="mt-2" AutoPostBack="true" Text="Coniugato" runat="server" />
        <asp:TextBox ID="TextNumeroFigli" CssClass="form-control mt-1" placeholder="Figli a carico" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextMansione" CssClass="form-control mt-1" placeholder="Mansione" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextStipendio" CssClass="form-control mt-1" placeholder="Stipendio" runat="server"></asp:TextBox>

        <asp:Button ID="ButtonAggiungi" CssClass="btn btn-warning border-0 rounded-2 mt-3" runat="server" Text="Aggiungi dipendente" OnClick="ButtonAggiungi_Click" />

        <asp:Label ID="LabelInserimento" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
