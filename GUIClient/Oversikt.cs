using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ITprosjekt
{
    class Oversikt
    {
        public String loggedInEmail;
        String gammeltpassordLocal;
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
        private String myconnectionstring = "Server=129.241.151.172;Database=IT1901;User=root;Password=herp";

        public void getinfosau(TextBox textBoxSauID, TextBox textBoxFlokkID, TextBox textBoxNavn, TextBox textBoxFdato, TextBox textBoxNotat, String strSelectedId)
        {
            String dbconnect = myconnectionstring;
            MySqlConnection dbconn = new MySqlConnection(dbconnect);

            String strSearchWord = strSelectedId;

            if (strSearchWord == "") { }
            else
            {
                try
                {
                    MySqlCommand cmdSauID = dbconn.CreateCommand();
                    MySqlDataReader ReaderSauID;
                    cmdSauID.CommandText = "select sauID from Sauer where navn = '" + strSearchWord + "' OR sauID ='" + strSearchWord + "'";
                    dbconn.Open();
                    ReaderSauID = cmdSauID.ExecuteReader();
                    ReaderSauID.Read();
                    textBoxSauID.Text = ReaderSauID.GetValue(0).ToString();
                    dbconn.Close();

                    MySqlCommand cmdFlokkID = dbconn.CreateCommand();
                    MySqlDataReader ReaderSauFlokk;
                    cmdFlokkID.CommandText = "select flokkID from Sauer where navn = '" + strSearchWord + "' OR sauID ='" + strSearchWord + "'";
                    dbconn.Open();
                    ReaderSauFlokk = cmdFlokkID.ExecuteReader();
                    ReaderSauFlokk.Read();
                    textBoxFlokkID.Text = ReaderSauFlokk.GetValue(0).ToString();
                    dbconn.Close();


                    MySqlCommand cmdNavn = dbconn.CreateCommand();
                    MySqlDataReader ReaderNavn;
                    cmdNavn.CommandText = "select navn from Sauer where navn = '" + strSearchWord + "' OR sauID ='" + strSearchWord + "'";
                    dbconn.Open();
                    ReaderNavn = cmdNavn.ExecuteReader();
                    ReaderNavn.Read();
                    textBoxNavn.Text = ReaderNavn.GetValue(0).ToString();
                    dbconn.Close();


                    MySqlCommand cmdFdato = dbconn.CreateCommand();
                    MySqlDataReader ReaderFdato;
                    cmdFdato.CommandText = "select fodselsdato from Sauer where navn = '" + strSearchWord + "' OR sauID ='" + strSearchWord + "'";
                    dbconn.Open();
                    ReaderFdato = cmdFdato.ExecuteReader();
                    ReaderFdato.Read();
                    textBoxFdato.Text = ReaderFdato.GetValue(0).ToString();
                    dbconn.Close();

                    MySqlCommand cmdNotat = dbconn.CreateCommand();
                    MySqlDataReader ReaderNotat;
                    cmdNotat.CommandText = "select notat from Sauer where navn = '" + strSearchWord + "' OR sauID ='" + strSearchWord + "'";
                    dbconn.Open();
                    ReaderNotat = cmdNotat.ExecuteReader();
                    ReaderNotat.Read();
                    textBoxNotat.Text = ReaderNotat.GetValue(0).ToString();
                    dbconn.Close();
                } catch(Exception e){
                    
                }
            }
        }

        public void fillDataGridSearchSheep(DataGridView dgwSearchSheep, String strFlokkID)
        {


            dbcMySql = new MySqlConnection(myconnectionstring);
            dbcMySql.Open();

            string strQuery = "";

            strQuery = "SELECT * FROM Sauer WHERE flokkID='" + strFlokkID + "'";

            sqlAdapter = new MySqlDataAdapter(strQuery, dbcMySql);
            sqlCommandBuilder = new MySqlCommandBuilder(sqlAdapter);

            sqlAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();

            dataTable = new DataTable();
            sqlAdapter.Fill(dataTable);

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            dgwSearchSheep.DataSource = bindingSource;

            dbcMySql.Close();

            dgwSearchSheep.Columns["flokkID"].Visible = false;

        }

        public void alterSheep(TextBox textBoxFlokkID, TextBox textBoxNavn, TextBox textBoxNotat, TextBox textBoxSauID)
        {
            String dbconnect = myconnectionstring;
            MySqlConnection dbconn = new MySqlConnection(dbconnect);

            MySqlCommand cmd = dbconn.CreateCommand();
            cmd.CommandText = "UPDATE Sauer SET flokkID='" + textBoxFlokkID.Text + "', navn= '" + textBoxNavn.Text + "', notat= '" + textBoxNotat.Text + "'  WHERE sauID= '" + textBoxSauID.Text + "'";
            dbconn.Open();
            cmd.ExecuteNonQuery();
            dbconn.Close();

            MessageBox.Show("Sau Endret");
        }

        public void alterUser(TextBox textBoxGammelPassord, TextBox textBoxEpost, TextBox textBoxNyPassord, TextBox textBoxAdresse, TextBox textBoxTelefon, TextBox textBoxID, String bondeID)
        {
            String dbconnect = myconnectionstring;
            MySqlConnection dbconn = new MySqlConnection(dbconnect);

       

            if (textBoxGammelPassord.Text == gammeltpassordLocal)
            {
                MySqlCommand cmd = dbconn.CreateCommand();
                cmd.CommandText = "UPDATE login SET epost='" + textBoxEpost.Text + "', passord= '" + textBoxNyPassord.Text + "'WHERE bondeID= '" + bondeID + "'";
                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();

                MySqlCommand cmd2 = dbconn.CreateCommand();
                cmd2.CommandText = "UPDATE Kontakt SET adresse= '" + textBoxAdresse.Text + "', telefonnr= '" + textBoxTelefon.Text + "' WHERE bondeID= '" + bondeID + "'";
                dbconn.Open();
                cmd2.ExecuteNonQuery();
                dbconn.Close();

                MessageBox.Show(textBoxTelefon.Text);
                getinfobruker(textBoxGammelPassord,  textBoxEpost,  textBoxNyPassord,  textBoxAdresse,  textBoxTelefon ,textBoxID, bondeID);
            }
            else
            {
                MessageBox.Show("Feil passord");
            }

        }

        public void getStartInfo(TextBox textBoxGammelPassord, TextBox textBoxEpost, String bondeID)
        {
            String dbconnect = myconnectionstring;
            MySqlConnection dbconn = new MySqlConnection(dbconnect);

            MySqlCommand cmdepost = dbconn.CreateCommand();
            MySqlDataReader Readerepost;
            cmdepost.CommandText = "select epost from login where bondeID = '" + bondeID + "'"; // må endres så: bondeID = current user id
            dbconn.Open();
            Readerepost = cmdepost.ExecuteReader();
            Readerepost.Read();
            textBoxEpost.Text = Readerepost.GetValue(0).ToString();
            dbconn.Close();

            MySqlCommand cmdpw = dbconn.CreateCommand();
            MySqlDataReader Readerpw;
            cmdpw.CommandText = "select passord from login where bondeID = '" + bondeID + "'";
            dbconn.Open();
            Readerpw = cmdpw.ExecuteReader();
            Readerpw.Read();
           // textBoxGammelPassord.Text = Readerpw.GetValue(0).ToString(); //ta bort for å skjule passord
            gammeltpassordLocal = Readerpw.GetValue(0).ToString();
            dbconn.Close();

        }

        private void getinfobruker(TextBox textBoxGammelPassord, TextBox textBoxEpost, TextBox textBoxNyPassord, TextBox textBoxAdresse, TextBox textBoxTelefon, TextBox textBoxID, String bondeID)
        {
            String dbconnect = myconnectionstring;
            MySqlConnection dbconn = new MySqlConnection(dbconnect);

            MySqlCommand cmdepost = dbconn.CreateCommand();
            MySqlDataReader Readerepost;
            cmdepost.CommandText = "select epost from login where bondeID = '" + bondeID + "'"; // må endres så: bondeID = current user id
            dbconn.Open();
            Readerepost = cmdepost.ExecuteReader();
            Readerepost.Read();
            textBoxEpost.Text = Readerepost.GetValue(0).ToString();
            dbconn.Close();

            MySqlCommand cmdpw = dbconn.CreateCommand();
            MySqlDataReader Readerpw;
            cmdpw.CommandText = "select passord from login where bondeID = '" + bondeID + "'";
            dbconn.Open();
            Readerpw = cmdpw.ExecuteReader();
            Readerpw.Read();
            textBoxGammelPassord.Text = Readerpw.GetValue(0).ToString(); //ta bort for å skjule passord
            gammeltpassordLocal = Readerpw.GetValue(0).ToString();
            dbconn.Close();

            MySqlCommand cmdtlf = dbconn.CreateCommand();
            MySqlDataReader Readertlf;
            cmdtlf.CommandText = "select telefonnr from Kontakt where bondeID = '" + bondeID + "'";
            dbconn.Open();
            Readertlf = cmdtlf.ExecuteReader();
            Readertlf.Read();
            textBoxTelefon.Text = Readertlf.GetValue(0).ToString();
            dbconn.Close();

            MySqlCommand cmdadresse = dbconn.CreateCommand();
            MySqlDataReader Readeradresse;
            cmdadresse.CommandText = "select adresse from Kontakt where bondeID = '" + bondeID + "'";
            dbconn.Open();
            Readeradresse = cmdadresse.ExecuteReader();
            Readeradresse.Read();
            textBoxAdresse.Text = Readeradresse.GetValue(0).ToString();
            dbconn.Close();

            MySqlCommand cmdID = dbconn.CreateCommand();
            MySqlDataReader ReaderID;
            cmdID.CommandText = "select bondeID from login where bondeID = '" + bondeID + "'";
            dbconn.Open();
            ReaderID = cmdID.ExecuteReader();
            ReaderID.Read();
            textBoxID.Text = ReaderID.GetValue(0).ToString();
            dbconn.Close();
        }

        internal void addSheep(TextBox textBoxNyFlokkID, TextBox textBoxNyNavn, TextBox textBoxNyFdato, TextBox textBoxNyNotat)
        {
            String dbconnect = myconnectionstring;
            MySqlConnection dbconn = new MySqlConnection(dbconnect);

            MySqlCommand cmd = dbconn.CreateCommand();
            cmd.CommandText = "INSERT INTO Sauer(flokkID, navn, fodselsdato, notat) VALUES ('" + textBoxNyFlokkID.Text + "', '" + textBoxNyNavn.Text + "', '" + textBoxNyFdato.Text + "', '" + textBoxNyNotat.Text + "')";
            dbconn.Open();
            cmd.ExecuteNonQuery();
            dbconn.Close();

            MessageBox.Show("Sau lagt til");
        }

        internal void fillDataGridSearchSheep(ListBox dgwSearchSheep)
        {
            throw new System.NotImplementedException();
        }
    }
}
