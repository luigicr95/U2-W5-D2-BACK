using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace U2_W5_D2_BACK
{
    public partial class DettagliPagamenti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Pagamento.ListaPagamenti.Clear();
            string idDipendente = Request.QueryString["IdDipendente"];

            try
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = $"SELECT * FROM Pagamenti WHERE IdDipendente = {idDipendente}";
                command.Connection = connection;

                SqlDataReader readerDipendenti = command.ExecuteReader();

                if (readerDipendenti.HasRows)
                {
                    while (readerDipendenti.Read())
                    {
                        Pagamento pagamento = new Pagamento();
                        pagamento.IdPagamento = Convert.ToInt32(readerDipendenti["IdPagamento"]);
                        pagamento.TipoPagamento = readerDipendenti["TipoPagamento"].ToString();
                        pagamento.DataPagamento = Convert.ToDateTime(readerDipendenti["DataPagamento"]);
                        pagamento.IdDipendente = Convert.ToInt32(readerDipendenti["IdDipendente"]);
                        pagamento.TotalePagamento = Convert.ToDecimal(readerDipendenti["TotalePagamento"]);
                        Pagamento.ListaPagamenti.Add(pagamento);
                    }
                }

                GridPagamenti.DataSource = Pagamento.ListaPagamenti;
                GridPagamenti.DataBind();

                connection.Close();
            } catch (Exception ex)
            {

            }
        }

        protected void ButtonNuovoPagamento_Click(object sender, EventArgs e)
        {
            string idDipendente = Request.QueryString["IdDipendente"];
            Response.Redirect($"EffettuaPagamento.aspx?IdDipendente={idDipendente}");
        }
    }
}