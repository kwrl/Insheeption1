using System;
using System.Data;
using GUIClient;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        Form3 form;
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
        

        public Form3()
        {
            InitializeComponent();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            form = new Form3();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strEmail = txbEmail.Text.ToString().Trim();
            String strPassword = txbPassword.Text.ToString().Trim();


            //md5-kryptering
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(strPassword);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            String password = s.ToString();

            GUIClient.ServiceReference1.SheepServiceClient client = new GUIClient.ServiceReference1.SheepServiceClient();

            bool login= client.NormalLogin(strEmail, strPassword);
            lblForgotPassword.Text = Convert.ToString(login);

            // lblForgotPassword.Text = password;
            /*
            dbcMySql = new MySqlConnection(myconnectionstring);
            dbcMySql.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format("SELECT bondeID FROM login WHERE epost = '" + strEmail + "' AND passord='" + strPassword + "'"); ;
            cmd.Connection = dbcMySql;
            MySqlDataReader reader = cmd.ExecuteReader();
            String res = "";

            while (reader.Read())
            {
                res = reader.GetString(0);
            }
            */

            //dbcMySql.Close();

            if (login == true)
            {
                
                // lblForgotPassword.Text = res;
                /*
                if (cbxRememberMe.Checked == true)
                {
                    dbcMySql = new MySqlConnection(myconnectionstring);
                    dbcMySql.Open();
                    MySqlCommand cmd2 = new MySqlCommand();
                    cmd2.CommandText = string.Format("UPDATE login SET huskmeg ='1' WHERE epost = '" + strEmail + "' AND passord='" + strPassword + "'"); ;
                    cmd2.Connection = dbcMySql;
                    cmd2.ExecuteReader();
                    dbcMySql.Close();
                }
                */
                /*
                Form1 f = new Form1();
                this.Hide();
                f.Show();
                */
                //lblForgotPassword.Text = Convert.ToString(login);
            }
            else
            {
                //lblForgotPassword.Text = "Herp derp";
                lblLoginAgain.Visible = true;
            }
        }

        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            if (txbEmail.Text == "" || !txbEmail.Text.Contains("@") || !txbEmail.Text.Contains("."))
            {
                MessageBox.Show("Tast inn en gyldig epostaddresse");
            }
            else
            {
                MessageBox.Show("En epost med nytt passord er sendt til din epostadresse(dummy)");
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
