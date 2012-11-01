using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ITprosjekt;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Kart kart;
        Oversikt oversikt;
        private string strSelectedIdToMap;
        DataGridViewCellEventArgs gridEvent;
        private MySqlConnection dbcMySql;
        private MySqlCommand cmdMySql;
        private MySqlDataAdapter adpMySql;
        private MySqlDataReader rdr;
        private DataSet dtsFromMySql;
        private MySqlCommandBuilder cmbMySql;
        private MySqlDataAdapter sqlAdapter;
        private MySqlCommandBuilder sqlCommandBuilder;
        private DataTable dataTable;
        private BindingSource bindingSource;
        private string bondeID;
        private String strFlokkID;
        String myconnectionstring = "Server=129.241.151.172;Database=IT1901;User=root;Password=herp";


        public Form1(string bondeID)
        {

            this.bondeID = bondeID;
            InitializeComponent();
            
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

            //Kjører metoden som presenterer ruten til de fire første sauene i databasen.
            //Dette antallet brukes for å ikke skape et for kaotisk kart.
            presentFourSheeps();
            
            //Henter brukernavn til den innloggede brukeren
            String strBrukerLoggedIn = getBrukerNavn();

            //Setter tittel
            this.Text = "SheepTracker - " + strBrukerLoggedIn + " innlogget";

            //Lager form-objekter for å praktisere mønsteret mediator og model-view-controller, da 
            //logikk-, gui- og kontroller-funksjoner separeres fra hverandre.
            kart = new Kart();
            oversikt = new Oversikt();
            
            //Henter flokkid
            strFlokkID = getFlokkID();

            //Gjennomfører logikk i henhold til å fylle grids med sauer
            kart.fillDataGridViewMapSearch(dgvSauer, "", strFlokkID);
            oversikt.fillDataGridSearchSheep(dgwSearchSheep, strFlokkID);
            oversikt.getStartInfo(textBoxGammelPassord, textBoxEpost, bondeID);

            //Starter klokken som brukes til å kontrollere om simulatoren skal hente ny informasjon
            //Denne klokken er synlig i høyre hjørne i applikasjonen.
            timer1.Start();

            timer1.Tick += new EventHandler(delegate(object s, EventArgs a)
            {
                String strNow = DateTime.Now.ToString("hh:mm:ss tt");

                label3.Text = strNow;

                if (label3.Text == "09.00.00") {
                    //Validering mot databasen, sjekke seneste input og sette inn nytt om disse er for gamle.
                    //updateDatabase();
                }

            });

            
            
        }

        private string getBrukerNavn()
        {
            
            //Kobles til databasen, spør etter riktig bruker og returnerer navnet
            dbcMySql = new MySqlConnection(myconnectionstring);
            dbcMySql.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM Bonde WHERE bondeID = '" + this.bondeID + "'"); ;
            cmd.Connection = dbcMySql;
            MySqlDataReader reader = cmd.ExecuteReader();
            String bondeNavn = "";

            while (reader.Read())
            {
                bondeNavn = reader.GetString(2);
            }

            return bondeNavn;
        }

        private string getFlokkID()
        {


            //Kobles til databasen, spør etter riktig bruker og returnerer bondeid
            dbcMySql = new MySqlConnection(myconnectionstring);
            dbcMySql.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format("SELECT * FROM Saueflokk WHERE bondeID = '" + this.bondeID+ "'"); ;
            cmd.Connection = dbcMySql;
            MySqlDataReader reader = cmd.ExecuteReader();
            String bondeID = "";

            while (reader.Read())
            {
                bondeID = reader.GetString(0);
            }

            return bondeID;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelNyPassord_Click(object sender, EventArgs e)
        {

        }

        private void textEpost_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonLagreEndringer_Click(object sender, EventArgs e)
        {

            
            oversikt.alterUser(textBoxGammelPassord, textBoxEpost, textBoxNyPassord, textBoxAdresse, textBoxTelefon, textBoxID, bondeID);
       
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void buttonSoksau_Click(object sender, EventArgs e)
        {
            String strSelectedCell = textSokSauInstillinger.Text;
            oversikt.getinfosau(textBoxSauID, textBoxFlokkID, textBoxNavn, textBoxFdato, textBoxNotat, strSelectedCell);

        }



       
        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLeggTilNySau_Click(object sender, EventArgs e)
        {
            oversikt.addSheep(textBoxNyFlokkID, textBoxNyNavn, textBoxNyFdato, textBoxNyNotat);
        }

        private void tabOversikt_Click(object sender, EventArgs e)
        {

        }

        private void btnShowSheepPos_Click(object sender, EventArgs e)
        {

            presentFourSheeps();

            
            //kart.btnShowSheepPosition(dgvSauer, label1);

        }

        private void presentFourSheeps()
        {
            String[] IDs = new String[10];

            for (int i = 1; i < 5; i++)
            {
                dbcMySql = new MySqlConnection(myconnectionstring);
                dbcMySql.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = string.Format("SELECT * FROM Sauer WHERE flokkID = '" + "1" + "' LIMIT " + i);
                cmd.Connection = dbcMySql;
                MySqlDataReader reader = cmd.ExecuteReader();
                String next = "";

                while (reader.Read())
                {
                    next = reader.GetString(0);
                }

                IDs[i] = next;


            }

            dbcMySql.Close();
            //MessageBox.Show(IDs[2]);
            //String strSelectedIdToMap = dgvSauer.Rows[e.RowIndex].Cells[0].Value.ToString();
            webBrowser1.Navigate("http://folk.ntnu.no/kenneaas/sau/flerID/index.php?id1=" + IDs[1] + "&id2=" + IDs[2] + "&id3=" + IDs[3] + "&id4=" + IDs[4] + ""); 
     
        }

        private void btnAlterSheep_Click(object sender, EventArgs e)
        {
            oversikt.alterSheep(textBoxFlokkID, textBoxNavn, textBoxNotat, textBoxSauID);
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            this.Hide();
            f.Show();
        }

        private void dgvSauer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
           String strSelectedIdToMap = dgvSauer.Rows[e.RowIndex].Cells[0].Value.ToString();
           webBrowser1.Navigate("http://folk.ntnu.no/kenneaas/sau/sauID/index.php?sauID=" + strSelectedIdToMap); 
     
        }

        private void dgwSearchSheep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String strSelectedId = dgwSearchSheep.Rows[e.RowIndex].Cells[0].Value.ToString();

            oversikt.getinfosau(textBoxSauID, textBoxFlokkID, textBoxNavn, textBoxFdato, textBoxNotat, strSelectedId);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSauID.Text = "";
            textBoxFlokkID.Text = "";
            textBoxNavn.Text = "";
            textBoxFdato.Text = "";
            textBoxNotat.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textSokSauKart_TextChanged(object sender, EventArgs e)
        {
            String searchWord = textSokSauKart.Text;

            kart.fillDataGridViewMapSearch(dgvSauer, searchWord, strFlokkID);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void tabKart_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            webBrowser1.Navigate("http://folk.ntnu.no/kenneaas/sau/flokkID/index.php?flokkID=1"); 
      
        }


    }
}


//            cmd.CommandText = "INSERT INTO Sauer(sauID, flokkID, navn, fodselsdato, notat) VALUES ('"+ textBoxNySauID.Text +"', '"+ textBoxNyFlokkID.Text +"', '"+ textBoxNyNavn.Text +"', '"+ textBoxNyFdato.Text +"', '"+ textBoxNyNotat.Text +"')";

