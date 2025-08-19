using EventsOrganizer.Data;
using EventsOrganizer.Data.Common;
using EventsOrganizer.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EventsOrganizer
{
    public partial class FrmRepeatWord : Form
    {
        EventsOrganizerContext context = new EventsOrganizerContext();

        Label label;

        private int minutes = 0;

        public FrmRepeatWord(Label label)
        {
            this.label = label;

            InitializeComponent();
        }

        private void buttonAddMin_Click(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(comboBoxMin.Text, out minutes);

            if (isInt)
            {
                SetMinutes();

                MessageBox.Show("Done!");

                if (minutes != 0)
                {
                    FrmRepeater frmRepeater = new FrmRepeater();
                    frmRepeater.Close();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Enter Integer!");
            }
        }
        public void SetMinutes()
        {
            string[] arrWords = label.Text.Split("-");

            DateTime dateTimeNow = DateTime.Now;

            if (arrWords.Length > 1)
            {
                context.Database.ExecuteSqlRaw("TRUNCATE TABLE [RepeatWords]");
                context.SaveChanges(true);

                if (checkBoxRepeat.Checked)
                {
                    if (checkBoxShowOnBg.Checked)
                    {
                        var getBgWord = context.EnBgWords!.Select(w => new { w.EnWord, w.BgWord }).Where(w => w.BgWord == arrWords[1].ToUpper().Trim()).FirstOrDefault();
                        var getAllEnWords = context.EnBgWords!.Select(w => new { w.EnWord, w.BgWord }).Where(w => w.EnWord == getBgWord!.EnWord).ToList();

                        string enWords = string.Empty;

                        int length = 0;

                        foreach (var enW in getAllEnWords)
                        {
                            if (length == 1)
                            {
                                enWords += enW.EnWord;
                                break;
                            }
                            enWords += enW.EnWord + ", ";
                            length--;
                        }
                        RepeatWord repeatWords = new RepeatWord()
                        {
                            EnWord = enWords.ToUpper(),
                            BgWord = arrWords[1].Trim().ToUpper(),
                            Minutes = minutes,
                            Repeat = true,
                            ShowOnEng = false,
                            ShowOnBg = true,
                            DateTime = dateTimeNow
                        };

                        context.Add(repeatWords);
                    }
                    else if (checkBoxShowOnEn.Checked)
                    {
                        RepeatWord repeatWords = new RepeatWord()
                        {
                            EnWord = arrWords[0].Trim().ToUpper(),
                            BgWord = arrWords[1].Trim().ToUpper(),
                            Minutes = minutes,
                            Repeat = true,
                            ShowOnEng = true,
                            ShowOnBg = false,
                            DateTime = dateTimeNow
                        };

                        context.Add(repeatWords);
                    }
                }
            }
            else if (arrWords.Length == 1)
            {
                if (checkBoxRepeat.Checked)
                {
                    SqlConnection cnn = new SqlConnection(DbConfig.ConnectionString);
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;

                    using (cnn = new SqlConnection(DbConfig.ConnectionString))
                    {
                        cnn.Open();
                        string sqlCommand = $"Update RepeatWords set Minutes = {minutes} Where Id = 1";
                        cmd = new SqlCommand(sqlCommand, cnn);
                        cmd.Parameters.AddWithValue($"@Minutes", minutes);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        cnn.Close();
                    }
                    if (checkBoxShowOnBg.Checked)
                    {
                        using (cnn = new SqlConnection(DbConfig.ConnectionString))
                        {
                            cnn.Open();
                            string sqlCommand = $"Update RepeatWords set ShowOnBg = 'true' Where Id = 1";
                            cmd = new SqlCommand(sqlCommand, cnn);
                            cmd.Parameters.AddWithValue($"@ShowOnBg", true);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            string sqlCommand2 = $"Update RepeatWords set ShowOnEng = 'false' Where Id = 1";
                            cmd = new SqlCommand(sqlCommand2, cnn);
                            cmd.Parameters.AddWithValue($"@ShowOnEng", false);
                            rowsAffected = cmd.ExecuteNonQuery();

                            cnn.Close();
                        }
                    }
                    if (checkBoxShowOnEn.Checked)
                    {
                        using (cnn = new SqlConnection(DbConfig.ConnectionString))
                        {
                            cnn.Open();
                            string sqlCommand = $"Update RepeatWords set ShowOnBg = 'false' Where Id = 1";
                            cmd = new SqlCommand(sqlCommand, cnn);
                            cmd.Parameters.AddWithValue($"@ShowOnBg", false);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            string sqlCommand2 = $"Update RepeatWords set ShowOnEng = 'true' Where Id = 1";
                            cmd = new SqlCommand(sqlCommand2, cnn);
                            cmd.Parameters.AddWithValue($"@ShowOnEng", true);
                            rowsAffected = cmd.ExecuteNonQuery();

                            cnn.Close();
                        }
                    }
                }
                else
                {
                    context.Database.ExecuteSqlRaw("TRUNCATE TABLE [RepeatWords]");
                    context.SaveChanges(true);
                }
            }
            context.SaveChanges();
        }


        private void checkBoxRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxRepeat.Checked)
            {
                comboBoxMin.Text = $"{0.ToString()}";
            }
        }

        private void FrmRepeatWord_Load(object sender, EventArgs e)
        {
            bool rStatus = RepeatStatus();

            if (rStatus)
            {
                checkBoxRepeat.Checked = true;
            }
            else
            {
                checkBoxRepeat.Checked = false;
            }

            var getCheckBox = context.RepeatWords!.Select(c => new { c.Id, c.ShowOnEng, c.ShowOnBg }).FirstOrDefault();

            if (getCheckBox?.ShowOnEng == true)
            {
                checkBoxShowOnEn.Checked = true;
            }
            else if (getCheckBox?.ShowOnBg == true)
            {
                checkBoxShowOnBg.Checked = true;
            }

            var repeatMin = context.RepeatWords!.Select(r => r.Minutes).FirstOrDefault();

            comboBoxMin.Text = $"{repeatMin.ToString()}";

            this.TopMost = true;
        }
        private bool RepeatStatus()
        {
            var repeatStatus = context.RepeatWords!.Select(r => r.Repeat).FirstOrDefault();

            return repeatStatus;
        }

        private void checkBoxShowOnBg_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxShowOnEn.Checked = false;

            //var getCheckBoxBg = context.RepeatWords!.Select(c => new { c.Id, c.ShowOnBg }).FirstOrDefault();

            //if (getCheckBoxBg?.ShowOnBg == true)
            //{
            //    checkBoxShowOnBg.Checked = true;
            //}
        }

        private void checkBoxShowOnEn_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxShowOnBg.Checked = false;

            //var getCheckBoxEn = context.RepeatWords!.Select(c => new { c.Id, c.ShowOnEng }).FirstOrDefault();

            //if (getCheckBoxEn?.ShowOnEng == true)
            //{
            //    checkBoxShowOnEn.Checked = true;
            //}
        }

        public bool GetCheckBoxChecked()
        {
            bool checkBoxBg = false;

            if (checkBoxShowOnBg.Checked)
            {
                checkBoxBg = true;
            }
            else if (checkBoxShowOnEn.Checked)
            {
                checkBoxBg = false;
            }

            return checkBoxBg;
        }
    }
}

