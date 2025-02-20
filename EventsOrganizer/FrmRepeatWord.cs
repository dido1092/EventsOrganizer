using EventsOrganizer.Data;
using EventsOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
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
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE [RepeatWords]");
            context.SaveChanges(true);

            string[] arrWords = label.Text.Split("-");

            //string pattern = @"([А-Яа-я]+)";

            //string bgWord = string.Empty;
            //string enWord = string.Empty;

            //if (!Regex.IsMatch(arrWords, pattern))
            //{
            //    var getWord = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.BgWord == arrWords.Trim()).FirstOrDefault();

            //    if (getWord != null)
            //    {
            //        bgWord = getWord.BgWord;
            //    }
            //}
            //else
            //{
            //    var getWord = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.EnWord == arrWords.Trim()).FirstOrDefault();

            //    if (getWord != null)
            //    {
            //        enWord = getWord.EnWord;
            //    }
            //}

            DateTime dateTimeNow = DateTime.Now;

            if (arrWords.Length > 1)
            {
                if (checkBoxRepeat.Checked)
                {
                    if (checkBoxShowOnBg.Checked)
                    {
                        RepeatWord repeatWords = new RepeatWord()
                        {
                            EnWord = arrWords[0].Trim().ToUpper(),
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
                    context.SaveChanges();
                }
            }
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

            //if (getCheckBoxBg?.ShowOnBg != null)
            //{
            //    if (getCheckBoxBg!.ShowOnBg == true)
            //    {
            //        checkBoxShowOnBg.Checked = true;
            //    }
            //}
        }

        private void checkBoxShowOnEn_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxShowOnBg.Checked = false;

            //var getCheckBoxBg = context.RepeatWords!.Select(c => new { c.Id, c.ShowOnEng }).FirstOrDefault();


            //if (getCheckBoxBg?.ShowOnEng != null)
            //{
            //    if (getCheckBoxBg!.ShowOnEng == true)
            //    {
            //        checkBoxShowOnBg.Checked = true;
            //    }
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

