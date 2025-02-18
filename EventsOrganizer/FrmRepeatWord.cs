using EventsOrganizer.Data;
using EventsOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
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

            string[] arrWords = label.Text.Split('-');

            DateTime dateTimeNow = DateTime.Now;

            if (arrWords.Length > 1)
            {
                if (checkBoxRepeat.Checked)
                {
                    RepeatWord repeatWords = new RepeatWord()
                    {
                        EnWord = arrWords[0].Trim().ToUpper(),
                        BgWord = arrWords[1].Trim().ToUpper(),
                        Minutes = minutes,
                        Repeat = true,
                        DateTime = dateTimeNow
                    };

                    context.Add(repeatWords);
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
    }
}

