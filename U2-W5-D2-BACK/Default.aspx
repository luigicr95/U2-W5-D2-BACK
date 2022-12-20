<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="U2_W5_D2_BACK.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <asp:GridView ID="GridDipendenti" CssClass="table table-bordered  table-striped table-light" runat="server" ItemType="U2_W5_D2_BACK.Dipendente" AutoGenerateColumns="false">
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
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="ButtonDettaglio" runat="server" Text="Dettagli Pagamenti" CommandArgument="<%#Item.IdDipendente %>" OnClick="ButtonDettaglio_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="ButtonModifica" runat="server" Text="Modifica" CommandArgument="<%#Item.IdDipendente %>" OnClick="ButtonModifica_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
