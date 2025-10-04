using EventsOrganizer.Data;
using EventsOrganizer.Data.Common;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace EventsOrganizer
{
    public partial class FrmResults : Form
    {
        EventsOrganizerContext context = new EventsOrganizerContext();
        public FrmResults()
        {
            InitializeComponent();
            FillDates();
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

                CountRows();
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
        private void CountRows()
        {
            int rows = dataGridViewResult.Rows.Count;

            labelRows.Text = $"Rows: {rows}";
        }
        private void FrmResults_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonSelectDate_Click(object sender, EventArgs e)
        {
            string finalDate = string.Empty;

            string getDate = comboBoxDate.Text;
            getDate = getDate.Replace("г", "");

            string[] arrDate = getDate.Split('.');

            for (int i = arrDate.Length - 2; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (arrDate[i].Length == 1)
                    {
                        finalDate += '0';
                    }
                    finalDate += arrDate[i] += '-';
                    finalDate = finalDate.Replace(" ", "");
                }
                else
                {
                    finalDate += arrDate[i];
                }
            }
           

            SqlConnection cnn = new SqlConnection(DbConfig.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            SelectedDate(finalDate, DbConfig.ConnectionString);
            CountRows();
        }
        private void SelectedDate(string date, string connectionString)
        {
            SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM Results WHERE DateTime Like '{date}%'", connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Results");
            dataGridViewResult.DataSource = ds.Tables["Results"]?.DefaultView;
        }
        private DateTime FillDates()
        {
            var dates = context.Results!.Select(r => r.DateTime.Date).Distinct().ToList();

            foreach (var date in dates)
            {
                comboBoxDate.Items.Add(date);
            }
            return dates.FirstOrDefault();
        }
    }
}
