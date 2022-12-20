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
    public partial class AggiungiDipendente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.QueryString["IdDipendente"] != null)
                    {
                        string idDipendente = Request.QueryString["IdDipendente"];

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

                                TextNome.Text = readerDipendenti["Nome"].ToString();
                                TextCognome.Text = readerDipendenti["Cognome"].ToString();
                                TextStipendio.Text = readerDipendenti["Stipendio"].ToString();
                                TextNumeroFigli.Text = readerDipendenti["NumeroFigli"].ToString();
                                TextMansione.Text = readerDipendenti["Mansione"].ToString();
                                TextIndirizzo.Text = readerDipendenti["Indirizzo"].ToString();
                                TextCodiceFiscale.Text = readerDipendenti["CodiceFiscale"].ToString();
                                CheckConiugato.Checked = Convert.ToBoolean(readerDipendenti["Coniugato"]);

                            }
                        }


                        connection.Close();

                        ButtonAggiungi.Text = "Modifica";
                    }
                }catch (Exception ex)
                {

                }
               

            
            }
        }

        protected void ButtonAggiungi_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["IdDipendente"] != null)
            {
                try
                {
                    string idDipendente = Request.QueryString["IdDipendente"];
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Parameters.AddWithValue("@Nome", TextNome.Text);
                    command.Parameters.AddWithValue("@Cognome", TextCognome.Text);
                    command.Parameters.AddWithValue("@Indirizzo", TextIndirizzo.Text);
                    command.Parameters.AddWithValue("@CodiceFiscale", TextCodiceFiscale.Text);
                    command.Parameters.AddWithValue("@Coniugato", CheckConiugato.Checked);
                    command.Parameters.AddWithValue("@NumeroFigli", TextNumeroFigli.Text);
                    command.Parameters.AddWithValue("@Mansione", TextMansione.Text);
                    command.Parameters.AddWithValue("@Stipendio", TextStipendio.Text);
                    command.CommandText = $"UPDATE  Dipendenti SET Nome = @Nome , Cognome = @Cognome, Indirizzo = @Indirizzo, CodiceFiscale = @CodiceFiscale, Coniugato = @Coniugato, NumeroFigli = @NumeroFigli, Mansione = @Mansione, Stipendio = @Stipendio" +
                        $" WHERE IdDipendente = {idDipendente}";
                    command.Connection = connection;

                    int righeInteressate = command.ExecuteNonQuery();

                    if (righeInteressate > 0)
                    {
                        LabelInserimento.Text = "Inserimento effettuato";
                    }
                    else
                    {
                        LabelInserimento.Text = "C'è stato un errore";
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    LabelInserimento.Text = ex.Message;
                }
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Parameters.AddWithValue("@Nome", TextNome.Text);
                    command.Parameters.AddWithValue("@Cognome", TextCognome.Text);
                    command.Parameters.AddWithValue("@Indirizzo", TextIndirizzo.Text);
                    command.Parameters.AddWithValue("@CodiceFiscale", TextCodiceFiscale.Text);
                    command.Parameters.AddWithValue("@Coniugato", CheckConiugato.Checked);
                    command.Parameters.AddWithValue("@NumeroFigli", TextNumeroFigli.Text);
                    command.Parameters.AddWithValue("@Mansione", TextMansione.Text);
                    command.Parameters.AddWithValue("@Stipendio", TextStipendio.Text);
                    command.CommandText = "INSERT INTO Dipendenti VALUES (@Nome, @Cognome, @Indirizzo, @CodiceFiscale, @Coniugato, @NumeroFigli, @Mansione, @Stipendio)";
                    command.Connection = connection;

                    int righeInteressate = command.ExecuteNonQuery();

                    if (righeInteressate > 0)
                    {
                        LabelInserimento.Text = "Inserimento effettuato";
                    }
                    else
                    {
                        LabelInserimento.Text = "C'è stato un errore";
                    }

                    connection.Close();

                }
                catch (Exception ex)
                {
                    LabelInserimento.Text = ex.Message;
                }
            }

            
        }
    }
}