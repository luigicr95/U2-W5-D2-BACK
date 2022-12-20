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
    public partial class EffettuaPagamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dipendente.ListaDipendenti.Clear();
                string idDipendente = Request.QueryString["IdDipendente"];
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT * FROM Dipendenti WHERE IdDipendente = {idDipendente}";
                    command.Connection = connection;

                    SqlDataReader readerDipendenti = command.ExecuteReader();

                    if (readerDipendenti.HasRows)
                    {
                        while (readerDipendenti.Read())
                        {
                            Dipendente dipendente = new Dipendente();
                            dipendente.IdDipendente = Convert.ToInt32(readerDipendenti["IdDipendente"]);
                            dipendente.Nome = readerDipendenti["Nome"].ToString();
                            dipendente.Cognome = readerDipendenti["Cognome"].ToString();
                            dipendente.Stipendio = Convert.ToDecimal(readerDipendenti["Stipendio"]);
                            Dipendente.ListaDipendenti.Add(dipendente);
                        }
                    }

                    GridDettagli.DataSource = Dipendente.ListaDipendenti;
                    GridDettagli.DataBind();

                    connection.Close();
                }
                catch (Exception ex)
                {

                }

                if (RadioButtonAcconto.Checked)
                {
                    TextPagamento.Visible = true;
                }
            }
        }

        protected void ButtonEffettua_Click(object sender, EventArgs e)
        {
            if (RadioButtonStipendio.Checked)
            {

                string idDipendente = Request.QueryString["IdDipendente"];
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT * FROM Dipendenti WHERE IdDipendente = {idDipendente}";
                    command.Connection = connection;

                    SqlDataReader readerDipendenti = command.ExecuteReader();

                    decimal stipendio = 0;

                    if (readerDipendenti.HasRows)
                    {
                        while (readerDipendenti.Read())
                        {

                            stipendio = Convert.ToDecimal(readerDipendenti["Stipendio"]);

                        }
                    }

                    SqlCommand commandPagamento = new SqlCommand();
                    commandPagamento.Parameters.AddWithValue("@TipoPagamento", "Stipendio");
                    commandPagamento.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToShortDateString());
                    commandPagamento.Parameters.AddWithValue("@TotalePagamento", stipendio);
                    commandPagamento.Parameters.AddWithValue("@IdDipendente", idDipendente);
                    commandPagamento.CommandText = "INSERT INTO Pagamenti VALUES (@TipoPagamento, @DataPagamento, @TotalePagamento, @IdDipendente)";
                    commandPagamento.Connection= connection;
                    int righeinteressate = commandPagamento.ExecuteNonQuery();

                    if (righeinteressate > 0)
                    {
                        PagamentoEffettuato.Text = "Pagamento effettuato";
                    }
                    else
                    {
                        PagamentoEffettuato.Text = "Pagamento non riuscito";
                    }


                    connection.Close();
                }
                catch (Exception ex)
                {
                    PagamentoEffettuato.Text = ex.Message;
                }
            }
            else if (RadioButtonAcconto.Checked)
            {


                string idDipendente = Request.QueryString["IdDipendente"];
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"SELECT * FROM Dipendenti WHERE IdDipendente = {idDipendente}";
                    command.Connection = connection;

                    SqlDataReader readerDipendenti = command.ExecuteReader();

                    decimal stipendio = 0;

                    if (readerDipendenti.HasRows)
                    {
                        while (readerDipendenti.Read())
                        {

                            stipendio = Convert.ToDecimal(readerDipendenti["Stipendio"]);

                        }
                    }

                    SqlCommand commandPagamento = new SqlCommand();
                    commandPagamento.Parameters.AddWithValue("@TipoPagamento", "Acconto");
                    commandPagamento.Parameters.AddWithValue("@DataPagamento", DateTime.Now.ToShortDateString());
                    commandPagamento.Parameters.AddWithValue("@TotalePagamento", TextPagamento.Text);
                    commandPagamento.Parameters.AddWithValue("@IdDipendente", idDipendente);
                    commandPagamento.CommandText = "INSERT INTO Pagamenti VALUES (@TipoPagamento, @DataPagamento, @TotalePagamento, @IdDipendente)";
                    commandPagamento.Connection= connection;
                    int righeinteressate = commandPagamento.ExecuteNonQuery();

                    if (righeinteressate > 0)
                    {
                        PagamentoEffettuato.Text = "Pagamento effettuato";
                    }
                    else
                    {
                        PagamentoEffettuato.Text = "Pagamento non riuscito";
                    }


                    connection.Close();
                }
                catch (Exception ex)
                {
                    PagamentoEffettuato.Text = ex.Message;
                }
            }
        }

        protected void RadioButtonAcconto_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButtonAcconto.Checked)
            {
                TextPagamento.Visible = true;
            }
        }
    }
}