using EventsOrganizer.Data;
using EventsOrganizer.Data.Models;
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
    public partial class FrmInsert : Form
    {
        EventsOrganizerContext context = new EventsOrganizerContext();

        private string path = string.Empty;
        public FrmInsert()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxBgWord.Text = string.Empty;
            textBoxEnWord.Text = string.Empty;
        }

        private void buttonInserManualWords_Click(object sender, EventArgs e)
        {
            string enW = textBoxEnWord.Text.ToUpper();
            string bgW = textBoxBgWord.Text.ToUpper();

            if (enW.Length > 0 && bgW.Length > 0)
            {
                EnBgWord enBgWord = new EnBgWord()
                {
                    EnWord = enW,
                    BgWord = bgW,
                    DateTime = DateTime.Now,
                };
                context.Add(enBgWord);

                context.SaveChanges();

                MessageBox.Show("Done!");
            }
        }

        private void toolStripButtonInsertFromFile_Click(object sender, EventArgs e)
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
            string enWord = string.Empty;
            string bgWord = string.Empty;

            //HashSet<string> hsQA = new HashSet<string>();

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
                    enWord = arrWords[0].Trim().ToUpper();

                    bgWord = arrWords[1].Trim().ToUpper();

                    if (enWord != string.Empty && bgWord != string.Empty)
                    {
                        //hsQA.Add($"{enWord} {bgWord}");

                        //if (hsQA.Contains($"{enWord} {bgWord}"))
                        //{
                            EnBgWord enBgWord = new EnBgWord()
                            {
                                EnWord = enWord,
                                BgWord = bgWord,
                                DateTime = dateTimeNow
                            };
                            context.EnBgWords!.Add(enBgWord);
                            context.SaveChanges();
                        //}
                        bgWord = string.Empty;
                        enWord = string.Empty;
                    }
                }
            }
            MessageBox.Show("Import Done!");
        }
    }
}
