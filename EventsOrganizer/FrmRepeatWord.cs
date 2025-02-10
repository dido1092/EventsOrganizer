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
    public partial class FrmRepeatWord : Form
    {
        private int minutes = 0;
        public FrmRepeatWord()
        {
            InitializeComponent();
        }

        private void buttonAddMin_Click(object sender, EventArgs e)
        {
            bool isInt = int.TryParse(comboBoxMin.Text, out minutes);

            if (isInt)
            {
                SetMinutes();

                MessageBox.Show("Done!");

                this.Close();
            }
            else
            {
                MessageBox.Show("Enter Integer!");
            }
        }
        public void SetMinutes()
        {
            FrmEnglishWord frmEnglishWord = new FrmEnglishWord();
            frmEnglishWord.getMin = this.minutes;

            if (minutes > 0)
            {
                frmEnglishWord.timerMinutes.Enabled = true;

                frmEnglishWord.timerMinutes.Interval = minutes * 60000;
            }
        }
    }
}
