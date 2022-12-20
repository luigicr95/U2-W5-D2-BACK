<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="DettagliPagamenti.aspx.cs" Inherits="U2_W5_D2_BACK.DettagliPagamenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <asp:Button ID="ButtonNuovoPagamento" runat="server" Text="Nuovo Pagamento" OnClick="ButtonNuovoPagamento_Click" />
        <asp:GridView ID="GridPagamenti" CssClass="table table-bordered  table-striped table-light" runat="server" ItemType="U2_W5_D2_BACK.Pagamento" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Importo">
                    <ItemTemplate>
                        <p class="ps-2"><%# Item.TotalePagamento.ToString("c2") %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo">
                    <ItemTemplate>
                        <p><%# Item.TipoPagamento %></p>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data Pagamento">
                    <ItemTemplate>
                        <p><%# Item.DataPagamento.ToString("d") %></p>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
