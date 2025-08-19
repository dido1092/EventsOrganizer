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
    public partial class FrmTableWords : Form
    {
        public FrmTableWords()
        {
            InitializeComponent();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            SqlConnection cnn = new SqlConnection(DbConfig.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            TableBgEnWords(DbConfig.ConnectionString);

            CountRows();
        }

        private void TableBgEnWords(string connectionString)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM EnBgWords", connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "EnBgWords");
            dataGridViewWords.DataSource = ds.Tables["EnBgWords"]?.DefaultView;
        }
        private void CountRows()
        {
            int recordCount = dataGridViewWords.RowCount;

            labelRows.Text = $"Rows: {recordCount - 1}"; // -1 for empty row.
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = DbConfig.ConnectionString;

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            int rowindex = dataGridViewWords.CurrentRow.Index;
            int colindex = dataGridViewWords.CurrentCell.ColumnIndex;

            string? columnName = dataGridViewWords.Columns[colindex].HeaderText;

            string? getValue = dataGridViewWords.CurrentCell.Value.ToString();
            string? id = dataGridViewWords.Rows[rowindex].Cells[0].Value.ToString();

            try
            {
                using (cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    string sqlCommand = $"Update EnBgWords set {columnName}=@{columnName} Where Id={id}";
                    cmd = new SqlCommand(sqlCommand, cnn);
                    cmd.Parameters.AddWithValue($"@{columnName}", getValue);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cnn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxEnWord_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxBgWord.Checked = false;
        }

        private void checkBoxBgWord_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxEnWord.Checked = false;
        }

        private async void buttonSearch_Click(object sender, EventArgs e)
        {
            string word = textBoxSearch.Text.ToUpper();

            await Execute(word);
        }
        private async Task Execute(string word)
        {
            if (checkBoxEnWord.Checked)
            {
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM EnBgWords WHERE EnWord = '{word}'", DbConfig.ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "EnBgWords");
                dataGridViewWords.DataSource = ds.Tables["EnBgWords"]?.DefaultView;

                string query = $"SELECT * FROM EnBgWords WHERE EnWord = '{word}'";

                CountRows();
            }
            else if (checkBoxBgWord.Checked)
            {
                SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM EnBgWords WHERE BgWord = N'{word}'", DbConfig.ConnectionString);
                DataSet ds = new DataSet();
                da.Fill(ds, "EnBgWords");
                dataGridViewWords.DataSource = ds.Tables["EnBgWords"]?.DefaultView;

                string query = $"SELECT * FROM EnBgWords WHERE BgWord = N'{word}'";

                CountRows();
            }
            else
            {
                MessageBox.Show("Choice a checkbox!");
            }
        }
    }
}
