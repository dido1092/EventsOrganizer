using EventsOrganizer.Data.Common;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventsOrganizer
{
    public partial class FrmResults : Form
    {
        public FrmResults()
        {
            InitializeComponent();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        public void Refresh()
        {
            SqlConnection cnn = new SqlConnection(DbConfig.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            try
            {
                TableResult(DbConfig.ConnectionString);

                CountRows(DbConfig.ConnectionString);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void TableResult(string connectionString)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Results", connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Results");
            dataGridViewResult.DataSource = ds.Tables["Results"]?.DefaultView;
        }
        private void CountRows(string connectionString)
        {
            // Create the connection.
            SqlConnection conn = new SqlConnection(DbConfig.ConnectionString);

            // Build the query to count, including CustomerID criteria if specified.
            string selectText = "SELECT COUNT(*) FROM Results";

            // Create the command to count the records.
            SqlCommand cmd = new SqlCommand(selectText, conn);

            // Execute the command, storing the results.
            conn.Open();
            int recordCount = (int)cmd.ExecuteScalar();
            conn.Close();
            //labelEventNums.Text = $"Събития бр: {recordCount}";
            labelRows.Text = $"Rows: {recordCount}";
        }
    }
}
