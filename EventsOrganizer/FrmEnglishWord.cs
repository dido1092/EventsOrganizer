using EventsOrganizer.Data;
using EventsOrganizer.Data.Models;
using System.Data;
using System.Speech.Synthesis;

namespace EventsOrganizer
{
    public partial class FrmEnglishWord : Form
    {
        EventsOrganizerContext context = new EventsOrganizerContext();

        private string path = string.Empty;
        private string enWord = string.Empty;
        private string bgWord = string.Empty;

        public int getMin = 0;

        public FrmEnglishWord()
        {
            InitializeComponent();
        }

        private void toolStripButtonInsert_Click(object sender, EventArgs e)
        {
            OpenFile();
            InsertEnBgWords();
        }
        private void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
        }
        private void InsertEnBgWords()
        {
            int countLines = 0;
            string enWord = string.Empty;
            string bgWord = string.Empty;

            HashSet<EnBgWord> hsQA = new HashSet<EnBgWord>();

            DateTime dateTimeNow = DateTime.Now;

            string[] lines = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                string getLine = lines[i];

                string[] arrWords = getLine.Split('-');

                if (getLine == "")
                {
                    continue;
                }

                if (getLine != "")
                {
                    enWord = arrWords[0].ToUpper();

                    bgWord = arrWords[1].ToUpper();

                    if (enWord != string.Empty && bgWord != string.Empty)
                    {
                        EnBgWord enBgWord = new EnBgWord()
                        {
                            EnWord = enWord,
                            BgWord = bgWord,
                            DateTime = dateTimeNow
                        };
                        context.EnBgWords!.Add(enBgWord);
                        context.SaveChanges();

                        bgWord = string.Empty;
                        enWord = string.Empty;
                    }
                }
            }
            MessageBox.Show("Import Done!");
        }

        private void FrmEnglishWord_Load(object sender, EventArgs e)
        {
            Execute();
        }
        private void Execute()
        {
            if (timerMinutes.Enabled == false)
            {
                Random rndWord = new Random();
                int getRndWordId = rndWord.Next(2, 10001);//Words Id's range

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
                var getWords = context.Results!.Select(w => new { w.Id, w.EnWord, w.BgWord }).OrderByDescending(w => w.Id).FirstOrDefault();

                if (getWords != null)
                {
                    enWord = getWords!.EnWord;
                    bgWord = getWords!.BgWord;

                    labelWord.Text = $"{enWord} - {bgWord}";
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string[] getWords = textBoxWord.Text.Split('-');

            string getEnWord = getWords[0].Trim().ToUpper();
            string getBgWord = getWords[1].Trim().ToUpper();

            if (getWords.Length > 0)
            {
                if (timerMinutes.Enabled == false)
                {
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
                else
                {
                    if (getEnWord.Trim().ToUpper() == enWord.Trim().ToUpper() && getBgWord.Trim().ToUpper() == bgWord.Trim().ToUpper())//Check if writing word is correct and equal to enWord
                    {
                        MessageBox.Show("Correct");

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("InCorrect");
                    }
                }
            }
        }

        private void toolStripButtonResult_Click(object sender, EventArgs e)
        {
            FrmResults frmResult = new FrmResults();
            frmResult.Show();
        }

        public void timerMinutes_Tick(object sender, EventArgs e)
        {
            this.Show();
        }

        private void toolStripButtonRepeat_Click(object sender, EventArgs e)
        {
            FrmRepeatWord frmRepeatWord = new FrmRepeatWord();
            frmRepeatWord.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Execute();
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
    }
}
