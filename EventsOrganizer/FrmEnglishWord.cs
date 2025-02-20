using EventsOrganizer.Data;
using EventsOrganizer.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;

namespace EventsOrganizer
{
    public partial class FrmEnglishWord : Form
    {
        EventsOrganizerContext context = new EventsOrganizerContext();

        private string path = string.Empty;
        private string enWord = string.Empty;
        private string bgWord = string.Empty;

        public int getMin = 0;
        private DateTime dt;

        private int getRndWordId = 0;

        public FrmEnglishWord(DateTime dateTime)
        {
            this.dt = dateTime;
            InitializeComponent();
        }

        private void toolStripButtonInsert_Click(object sender, EventArgs e)
        {
            FrmInsert frmInsert = new FrmInsert();
            frmInsert.Show();
        }
        private void FrmEnglishWord_Load(object sender, EventArgs e)
        {
            Execute();
        }
        public void Execute()
        {
            var repeat = context.RepeatWords!.Select(r => r.Repeat).FirstOrDefault();

            FrmRepeatWord frmRepeatWord = new FrmRepeatWord(labelWord);

            bool isCheckBoxBgChecked = frmRepeatWord.GetCheckBoxChecked();

            if (repeat == false)
            {
                Random rndWord = new Random();
                getRndWordId = rndWord.Next(2, 10000);//Words Id's range in DB

                var getWords = context.EnBgWords!.Select(w => new { w.Id, w.EnWord, w.BgWord }).Where(w => w.Id == getRndWordId).FirstOrDefault();

                if (getWords != null)
                {
                    enWord = getWords!.EnWord;
                    bgWord = getWords!.BgWord;

                    labelWord.Text = $"{enWord} - {bgWord}";
                }
            }
            else
            {
                var getWords = context.RepeatWords!.Select(w => new { w.Id, w.EnWord, w.BgWord, w.Minutes, w.Repeat }).OrderByDescending(w => w.Id).FirstOrDefault();

                if (getWords != null)
                {
                    enWord = getWords.EnWord.Trim();
                    bgWord = getWords.BgWord.Trim();

                    if (isCheckBoxBgChecked)
                    {
                        labelWord.Text = $"{bgWord}";
                    }
                    else
                    {
                        labelWord.Text = $"{enWord}";
                    }
                }
                labelInfo.Text = $"Repeating on every {getWords!.Minutes} min. \nLast Repeated in {dt}";
            }

            //this.Show();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var getCheckBoxChecked = context.RepeatWords!.Select(c => new { c.ShowOnBg, c.ShowOnEng }).FirstOrDefault();

            string getEnWord = string.Empty;
            string getBgWord = string.Empty;

            if (getCheckBoxChecked != null)
            {
                if (getCheckBoxChecked.ShowOnEng == true)
                {
                    getEnWord = labelWord.Text.Trim().ToUpper();
                    getBgWord = textBoxWord.Text.Trim().ToUpper();
                }
                else if (getCheckBoxChecked.ShowOnBg == true)
                {
                    getBgWord = labelWord.Text.Trim().ToUpper();
                    getEnWord = textBoxWord.Text.Trim().ToUpper();
                }
                string getWords = textBoxWord.Text;

                DateTime dtNow = DateTime.Now;

                if (getEnWord == enWord.Trim().ToUpper() && getBgWord == bgWord.Trim().ToUpper())//Check if writing word is correct and equal to enWord
                {
                    Result result = new Result()
                    {
                        EnWord = getEnWord,
                        BgWord = getBgWord,
                        IsCorrect = true,
                        DateTime = dtNow
                    };
                    context.Add(result);

                    textBoxWord.Text = string.Empty;

                    MessageBox.Show("Correct!");

                    this.Close();
                }
                else
                {
                    Result result = new Result()
                    {
                        EnWord = getEnWord,
                        BgWord = getBgWord,
                        IsCorrect = false,
                        DateTime = dtNow
                    };
                    context.Add(result);

                    MessageBox.Show("InCorrect!");
                }
                context.SaveChanges();
            }
        }

        private void toolStripButtonResult_Click(object sender, EventArgs e)
        {
            FrmResults frmResult = new FrmResults();
            frmResult.Show();
        }

        public void timerMinutes_Tick(object sender, EventArgs e)
        {
            Execute();
        }

        private void toolStripButtonRepeat_Click(object sender, EventArgs e)
        {
            FrmRepeatWord frmRepeatWord = new FrmRepeatWord(labelWord);
            frmRepeatWord.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            ReadText(enWord);
        }
        private void ReadText(string word)
        {
            SpeechSynthesizer speech = new SpeechSynthesizer();
            speech.SpeakAsync(word);
        }

        private void buttonAnotherWord_Click(object sender, EventArgs e)
        {
            Execute();
        }

        public void labelWord_Click(object sender, EventArgs e)
        {

        }

        private void buttonHint_Click(object sender, EventArgs e)
        {
            FrmRepeatWord frmRepeatWord = new FrmRepeatWord(labelWord);

            bool isCheckBoxBgChecked = frmRepeatWord.GetCheckBoxChecked();

            string getWordFromLabel = labelWord.Text.Trim();

            string pattern = @"([А-Яа-я]+)";


            string bgWord = string.Empty;
            string enWord = string.Empty;

            if (Regex.IsMatch(getWordFromLabel, pattern))
            {
                var getWord = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.BgWord == getWordFromLabel.Trim()).FirstOrDefault();

                if (getWord != null)
                {
                    enWord = getWord.EnWord.Trim();
                }
            }
            else
            {
                var getWord = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.EnWord == getWordFromLabel.Trim()).FirstOrDefault();

                if (getWord != null)
                {
                    bgWord = getWord.BgWord.Trim();
                }
            }



            //var getWords = context.EnBgWords!.Select(w => new { w.Id, w.EnWord, w.BgWord }).Where(w => w.Id == getRndWordId).FirstOrDefault();

            var getCheckBox = context.RepeatWords!.Select(c => new { c.Id, c.ShowOnBg, c.ShowOnEng }).FirstOrDefault();

            if (bgWord.Length > 0)
            {
                MessageBox.Show($"{bgWord}");
            }
            else if (enWord.Length > 0)
            {
                MessageBox.Show($"{enWord}");
            }
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
