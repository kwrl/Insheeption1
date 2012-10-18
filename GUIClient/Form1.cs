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

        public Form1()
        {
            InitializeComponent();
           // getinfobruker();

        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            kart = new Kart();
            oversikt = new Oversikt();

            kart.fillDataGridViewMapSearch(dgvSauer, "");
            oversikt.fillDataGridSearchSheep(dgwSearchSheep);
            oversikt.getStartInfo(textBoxGammelPassord, textBoxEpost);

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

            oversikt.alterUser(textBoxGammelPassord, textBoxEpost, textBoxNyPassord, textBoxAdresse, textBoxTelefon, textBoxID);
       
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

            
            //kart.btnShowSheepPosition(dgvSauer, label1);

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

            kart.fillDataGridViewMapSearch(dgvSauer, searchWord);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


    }
}


//            cmd.CommandText = "INSERT INTO Sauer(sauID, flokkID, navn, fodselsdato, notat) VALUES ('"+ textBoxNySauID.Text +"', '"+ textBoxNyFlokkID.Text +"', '"+ textBoxNyNavn.Text +"', '"+ textBoxNyFdato.Text +"', '"+ textBoxNyNotat.Text +"')";

