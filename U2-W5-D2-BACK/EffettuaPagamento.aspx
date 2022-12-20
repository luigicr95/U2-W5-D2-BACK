<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="EffettuaPagamento.aspx.cs" Inherits="U2_W5_D2_BACK.EffettuaPagamento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-3">
        <asp:GridView ID="GridDettagli" CssClass="table table-bordered  table-striped table-light" runat="server" ItemType="U2_W5_D2_BACK.Dipendente" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <p class="ps-2"><%# Item.Nome %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Cognome">
                    <ItemTemplate>
                        <p><%# Item.Cognome %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Stipendio">
                    <ItemTemplate>
                        <p><%# Item.Stipendio.ToString("c2") %></p>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:RadioButton ID="RadioButtonStipendio" Text="Stipendio" runat="server" GroupName="Pagamenti" />
        <asp:RadioButton ID="RadioButtonAcconto" Text="Acconto" runat="server" GroupName="Pagamenti" OnCheckedChanged="RadioButtonAcconto_CheckedChanged" AutoPostBack="true" />
        <br />
        <asp:TextBox ID="TextPagamento" CssClass="form-control mt-1" placeholder="Importo" runat="server" Visible="false"></asp:TextBox>
        <asp:Button ID="ButtonEffettua" CssClass="btn btn-warning border-0 rounded-2 mt-3" runat="server" Text="Effettua Pagamento" OnClick="ButtonEffettua_Click" />
        <asp:Label ID="PagamentoEffettuato" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
