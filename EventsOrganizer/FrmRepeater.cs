using EventsOrganizer.Data;
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
    public partial class FrmRepeater : Form
    {
        EventsOrganizerContext context = new EventsOrganizerContext();

        private int id = 0;
        private int years = 0;
        private int months = 0;
        private int days = 0;
        private int hours = 0;
        private int minutes = 0;

        public FrmRepeater()
        {
            InitializeComponent();
        }
        private void FrmRepeater_Load(object sender, EventArgs e)
        {
            Thread loadIds = new Thread(GetIds);
            loadIds.IsBackground = true;
            loadIds.Start();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            bool checkId = int.TryParse(comboBoxIds.Text, out id);

            bool checkYears = int.TryParse(comboBoxYears.Text, out years);

            bool checkMonths = int.TryParse(comboBoxMonths.Text, out months);

            bool checkDays = int.TryParse(comboBoxDays.Text, out days);

            bool checkHours = int.TryParse(comboBoxHours.Text, out hours);

            bool checkMin = int.TryParse(comboBoxMinutes.Text, out minutes);

            if (checkId)
            {
                DateTime newDateTime = DateTime.Now;

                if (checkYears)
                {
                    newDateTime = newDateTime.AddYears(years);
                }
                if (checkMonths)
                {
                    newDateTime = newDateTime.AddMonths(months);
                }
                if (checkDays)
                {
                    newDateTime = newDateTime.AddDays(days);
                }
                if (checkHours)
                {
                    newDateTime = newDateTime.AddHours(hours);
                }
                if (checkMin)
                {
                    newDateTime = newDateTime.AddMinutes(minutes);
                }

                SetEnbleToTrue(id, newDateTime);
            }


        }
        private void SetEnbleToTrue(int id, DateTime remindDateTime)
        {
            string connectionString = null!;
            connectionString = DbConfig.ConnectionString;

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            cmd.Connection = cnn;
            cnn.Open();
            string sqlCommand = $"Update Events set remindDateTime=@remindDateTime Where Id={id}";
            cmd = new SqlCommand(sqlCommand, cnn);
            cmd.Parameters.AddWithValue($"@remindDateTime", remindDateTime);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            cnn.Close();
        }

        private void comboBoxIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetIds();
        }

        private void GetIds()
        {
            var getIds = context.Events!.Select(e => e.Id).ToList();

            if (getIds.Count > 0)
            {
                foreach (var id in getIds)
                {
                    comboBoxIds.Items.Add(id);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxYears.Text = string.Empty;
            comboBoxMonths.Text = string.Empty;
            comboBoxDays.Text = string.Empty;
            comboBoxHours.Text = string.Empty;
            comboBoxMinutes.Text = string.Empty;

        }
    }
}
