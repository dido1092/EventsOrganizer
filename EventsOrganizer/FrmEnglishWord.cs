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

        private int getRndWordId = 0;
        public int getMin = 0;

        private DateTime dt;

        private bool isHintUsed = false;


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
            var getData = context.RepeatWords!.Select(r => new { r.Repeat, r.ShowOnBg, r.ShowOnEng }).FirstOrDefault();

            FrmRepeatWord frmRepeatWord = new FrmRepeatWord(labelWord);

            if (getData == null)
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
                var getWord = context.RepeatWords!.Select(w => new { w.Id, w.EnWord, w.BgWord, w.Minutes, w.Repeat }).OrderByDescending(w => w.Id).FirstOrDefault();


                var getFromEnBgWords = context.EnBgWords!.Select(w => new { w.EnWord, w.BgWord }).Where(w => w.BgWord == getWord!.BgWord).ToList();

                if (getFromEnBgWords != null)
                {
                    enWord = string.Empty;

                    int length = getFromEnBgWords.Count;

                    foreach (var w in getFromEnBgWords)
                    {
                        if (length == 1)
                        {
                            enWord += w.EnWord.Trim();
                            bgWord = w.BgWord.Trim();
                            break;
                        }
                        enWord += w.EnWord.Trim() + ", ";
                        bgWord = w.BgWord.Trim();

                        length--;
                    }

                    if (getData.ShowOnBg == true)
                    {
                        labelWord.Text = $"{bgWord}";
                    }
                    else
                    {
                        labelWord.Text = $"{enWord}";
                    }

                    labelInfo.Text = $"Repeating on every {getWord!.Minutes} min. \nLast Repeated in {dt}";
                }

                isHintUsed = false;

            }

            this.Show();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var getCheckBoxChecked = context.RepeatWords!.Select(c => new { c.EnWord, c.BgWord, c.ShowOnBg, c.ShowOnEng }).FirstOrDefault();

            if (getCheckBoxChecked != null)
            {
                string getWords = textBoxWord.Text.Trim().ToUpper();
                string[] arrWords = getWords.Split(',');

                DateTime dtNow = DateTime.Now;

                string wordLabel = labelWord.Text;

                var isBgWord = context.RepeatWords!.Select(i => i.ShowOnBg).FirstOrDefault();

                int IsNotCorrectWordCount = 0;

                if (isBgWord)
                {
                    var allSelectedWords = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.BgWord == wordLabel).ToList();

                    foreach (var w in allSelectedWords)
                    {
                        if (getWords == w.EnWord)
                        {

                            IsCorrect(w.EnWord, w.BgWord, getWords, dtNow);
                            break;
                        }
                        else
                        {
                            IsNotCorrectWordCount++;
                        }

                        if (IsNotCorrectWordCount == allSelectedWords.Count())
                        {
                            IsNotCorrect(w.EnWord, w.BgWord, getWords, dtNow);
                        }
                    }
                }
                else
                {
                    var allSelectedWords = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.EnWord == wordLabel);

                    foreach (var w in allSelectedWords)
                    {
                        if (getWords == w.BgWord)
                        {

                            IsCorrect(w.EnWord, w.BgWord, getWords, dtNow);
                            break;
                        }
                        else
                        {
                            IsNotCorrectWordCount++;
                        }

                        if (IsNotCorrectWordCount == allSelectedWords.Count())
                        {
                            IsNotCorrect(w.EnWord, w.BgWord, getWords, dtNow);
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        private void IsNotCorrect(string getEnWord, string getBgWord, string getWords, DateTime dtNow)
        {
            Result result = new Result()
            {
                EnWord = getEnWord,
                BgWord = getBgWord,
                WritingWord = getWords,
                IsCorrect = false,
                DateTime = dtNow
            };
            context.Add(result);

            MessageBox.Show("InCorrect!");

            //----------- Select InCorrect word --------------
            textBoxWord.Focus();
            textBoxWord.SelectAll();
            //------------------------------------------------
        }

        private void IsCorrect(string getEnWord, string getBgWord, string getWords, DateTime dtNow)
        {
            if (isHintUsed)
            {
                Result result = new Result()
                {
                    EnWord = getEnWord,
                    BgWord = getBgWord,
                    WritingWord = getWords,
                    IsCorrect = true,
                    Hint = true,
                    DateTime = dtNow
                };
                context.Add(result);
            }
            else
            {
                Result result = new Result()
                {
                    EnWord = getEnWord,
                    BgWord = getBgWord,
                    WritingWord = getWords,
                    IsCorrect = true,
                    Hint = false,
                    DateTime = dtNow
                };
                context.Add(result);
            }

            textBoxWord.Text = string.Empty;

            MessageBox.Show("Correct!");
            this.Close();
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
                var getWord = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.BgWord.Trim() == getWordFromLabel.Trim()).ToList();

                if (getWord != null)
                {
                    int length = getWord.Count;

                    foreach (var w in getWord)
                    {
                        if (length == 1)
                        {
                            enWord += w.EnWord.Trim();
                            break;
                        }
                        enWord += w.EnWord.Trim() + ", ";

                        length--;
                    }
                }
            }
            else//For En word reverse
            {
                string[] words = getWordFromLabel.Split(',');

                var getWord = context.EnBgWords!.Select(w => new { w.BgWord, w.EnWord }).Where(w => w.EnWord.Trim() == words[0].Trim()).FirstOrDefault();

                if (getWord != null)
                {
                    bgWord = getWord.BgWord.Trim();
                }
            }

            var getCheckBox = context.RepeatWords!.Select(c => new { c.Id, c.ShowOnBg, c.ShowOnEng }).FirstOrDefault();

            if (bgWord.Length > 0)
            {
                MessageBox.Show($"{bgWord}");
            }
            else if (enWord.Length > 0)
            {
                MessageBox.Show($"{enWord}");
            }

            isHintUsed = true;
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearchWord.Text.Trim();

            var selectWord = context.EnBgWords!.Select(w => new { w.Id, w.EnWord, w.BgWord }).Where(w => w.EnWord.ToUpper() == textBoxSearchWord.Text.ToUpper() || w.BgWord.ToUpper() == textBoxSearchWord.Text.ToUpper())
                .FirstOrDefault();

            if (selectWord != null)
            {
                labelWord.Text = selectWord!.EnWord + " - " + selectWord!.BgWord;
            }
            else
            {
                MessageBox.Show("Word not found!");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonTableWords_Click(object sender, EventArgs e)
        {
            FrmTableWords frmTableWords = new FrmTableWords();
            frmTableWords.Show();
        }
    }
}
