using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace ITprosjekt
{

    class Kart
    {
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
        private String myconnectionstring = "Server=80.202.107.226;Database=IT1901;User=root;Password=herp";

        public void fillDataGridViewMapSearch(DataGridView dgvSauer, String strSearchName, String strFlokkID)
        {
        
            dbcMySql = new MySqlConnection(myconnectionstring);
            dbcMySql.Open();

            string strQuery = "";

            strQuery = "SELECT * FROM Sauer WHERE flokkID='"+strFlokkID+"' AND (navn LIKE '%" + strSearchName + "%' OR sauID LIKE '%" + strSearchName + "%')";

            sqlAdapter = new MySqlDataAdapter(strQuery, dbcMySql);
            sqlCommandBuilder = new MySqlCommandBuilder(sqlAdapter);

            sqlAdapter.UpdateCommand = sqlCommandBuilder.GetUpdateCommand();

            dataTable = new DataTable();
            sqlAdapter.Fill(dataTable); 

            bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;

            dgvSauer.DataSource = bindingSource;

            dbcMySql.Close();

            dgvSauer.Columns["flokkID"].Visible = false;
        }
        


        public void btnShowSheepPosition(DataGridView dgvSauer, Label label1)
        {
            /*
            String strSelectedId = dgvSauer.Rows[gridEvent.RowIndex].Cells[0].Value.ToString();

            label1.Text = Convert.ToString(strSelectedId);

            try
            {
                dbcMySql = new MySqlConnection(myconnectionstring);
                dbcMySql.Open();

                string stm = @"SELECT breddegrad From Posisjon WHERE sauID ='" + strSelectedId + "'";

                MySqlCommand cmd = new MySqlCommand(stm, dbcMySql);
                rdr = cmd.ExecuteReader();

                String er = "";

                while (rdr.Read())
                {

                    er = Convert.ToString(rdr.GetString(0).PadRight(0) +
                        rdr.GetString(0));
                }

                label1.Text = er.Substring(0, 2);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (dbcMySql != null)
                {
                    dbcMySql.Close();
                }

            }*/
        }


    }
}
