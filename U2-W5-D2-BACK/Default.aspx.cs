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
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection connection = new SqlConnection();
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["ConnessioneDB_Ediltutto"].ToString();
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandText = "SELECT * FROM Dipendenti";
                command.Connection= connection;

                SqlDataReader readerDipendenti = command.ExecuteReader();

                if (readerDipendenti.HasRows)
                {
                    while(readerDipendenti.Read())
                    {
                        Dipendente dipendente= new Dipendente();
                        dipendente.IdDipendente = Convert.ToInt32(readerDipendenti["IdDipendente"]);
                        dipendente.Nome = readerDipendenti["Nome"].ToString();
                        dipendente.Cognome = readerDipendenti["Cognome"].ToString();
                        dipendente.Stipendio = Convert.ToDecimal(readerDipendenti["Stipendio"]);
                        Dipendente.ListaDipendenti.Add(dipendente);
                    }
                }

                GridDipendenti.DataSource = Dipendente.ListaDipendenti;
                GridDipendenti.DataBind();

                connection.Close();
            }
        }

        protected void ButtonDettaglio_Click(object sender, EventArgs e)
        {
            Button Dettaglio = (Button)sender;
            int IdDipendente = Convert.ToInt32(Dettaglio.CommandArgument);
            Response.Redirect($"DettagliPagamenti.aspx?IdDipendente={IdDipendente}");
        }

        protected void ButtonModifica_Click(object sender, EventArgs e)
        {
            Button Modifica = (Button)sender;
            int IdDipendente = Convert.ToInt32(Modifica.CommandArgument);
            Response.Redirect($"AggiungiDipendente.aspx?IdDipendente={IdDipendente}");
        }
    }
}