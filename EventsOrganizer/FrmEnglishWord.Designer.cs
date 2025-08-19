namespace EventsOrganizer
{
    partial class FrmEnglishWord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnglishWord));
            labelWord = new Label();
            textBoxWord = new TextBox();
            buttonOK = new Button();
            toolStrip1 = new ToolStrip();
            toolStripButtonInsert = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonTableWords = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonResult = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButtonRepeat = new ToolStripButton();
            timerMinutes = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            buttonAnotherWord = new Button();
            labelInfo = new Label();
            buttonHint = new Button();
            textBoxSearchWord = new TextBox();
            buttonSearch = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelWord
            // 
            labelWord.AutoSize = true;
            labelWord.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelWord.Location = new Point(38, 127);
            labelWord.Name = "labelWord";
            labelWord.Size = new Size(79, 30);
            labelWord.TabIndex = 0;
            labelWord.Text = "WORD";
            labelWord.Click += labelWord_Click;
            // 
            // textBoxWord
            // 
            textBoxWord.Location = new Point(38, 194);
            textBoxWord.Name = "textBoxWord";
            textBoxWord.Size = new Size(289, 23);
            textBoxWord.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(333, 194);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(89, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonInsert, toolStripSeparator1, toolStripButtonTableWords, toolStripSeparator2, toolStripButtonResult, toolStripSeparator3, toolStripButtonRepeat });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(629, 25);
            toolStrip1.TabIndex = 3;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonInsert
            // 
            toolStripButtonInsert.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonInsert.Image = (Image)resources.GetObject("toolStripButtonInsert.Image");
            toolStripButtonInsert.ImageTransparentColor = Color.Magenta;
            toolStripButtonInsert.Name = "toolStripButtonInsert";
            toolStripButtonInsert.Size = new Size(23, 22);
            toolStripButtonInsert.Text = "Insert";
            toolStripButtonInsert.Click += toolStripButtonInsert_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripButtonTableWords
            // 
            toolStripButtonTableWords.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonTableWords.Image = (Image)resources.GetObject("toolStripButtonTableWords.Image");
            toolStripButtonTableWords.ImageTransparentColor = Color.Magenta;
            toolStripButtonTableWords.Name = "toolStripButtonTableWords";
            toolStripButtonTableWords.Size = new Size(23, 22);
            toolStripButtonTableWords.Text = "Words";
            toolStripButtonTableWords.Click += toolStripButtonTableWords_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripButtonResult
            // 
            toolStripButtonResult.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonResult.Image = (Image)resources.GetObject("toolStripButtonResult.Image");
            toolStripButtonResult.ImageTransparentColor = Color.Magenta;
            toolStripButtonResult.Name = "toolStripButtonResult";
            toolStripButtonResult.Size = new Size(23, 22);
            toolStripButtonResult.Text = "Result";
            toolStripButtonResult.Click += toolStripButtonResult_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripButtonRepeat
            // 
            toolStripButtonRepeat.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonRepeat.Image = (Image)resources.GetObject("toolStripButtonRepeat.Image");
            toolStripButtonRepeat.ImageTransparentColor = Color.Magenta;
            toolStripButtonRepeat.Name = "toolStripButtonRepeat";
            toolStripButtonRepeat.Size = new Size(23, 22);
            toolStripButtonRepeat.Text = "Repeat";
            toolStripButtonRepeat.Click += toolStripButtonRepeat_Click;
            // 
            // timerMinutes
            // 
            timerMinutes.Interval = 60000;
            timerMinutes.Tick += timerMinutes_Tick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(461, 194);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 23);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // buttonAnotherWord
            // 
            buttonAnotherWord.Location = new Point(38, 239);
            buttonAnotherWord.Name = "buttonAnotherWord";
            buttonAnotherWord.Size = new Size(96, 23);
            buttonAnotherWord.TabIndex = 6;
            buttonAnotherWord.Text = "Another word";
            buttonAnotherWord.UseVisualStyleBackColor = true;
            buttonAnotherWord.Click += buttonAnotherWord_Click;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelInfo.ForeColor = SystemColors.ActiveCaptionText;
            labelInfo.Location = new Point(38, 298);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(30, 15);
            labelInfo.TabIndex = 7;
            labelInfo.Text = "Info";
            labelInfo.Click += labelInfo_Click;
            // 
            // buttonHint
            // 
            buttonHint.Location = new Point(257, 239);
            buttonHint.Name = "buttonHint";
            buttonHint.Size = new Size(70, 23);
            buttonHint.TabIndex = 8;
            buttonHint.Text = "Hint";
            buttonHint.UseVisualStyleBackColor = true;
            buttonHint.Click += buttonHint_Click;
            // 
            // textBoxSearchWord
            // 
            textBoxSearchWord.Location = new Point(38, 41);
            textBoxSearchWord.Name = "textBoxSearchWord";
            textBoxSearchWord.Size = new Size(289, 23);
            textBoxSearchWord.TabIndex = 9;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(333, 41);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(89, 23);
            buttonSearch.TabIndex = 10;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // FrmEnglishWord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 344);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearchWord);
            Controls.Add(buttonHint);
            Controls.Add(labelInfo);
            Controls.Add(buttonAnotherWord);
            Controls.Add(pictureBox1);
            Controls.Add(toolStrip1);
            Controls.Add(buttonOK);
            Controls.Add(textBoxWord);
            Controls.Add(labelWord);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmEnglishWord";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Learn English Word";
            Load += FrmEnglishWord_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label labelWord;
        private TextBox textBoxWord;
        private Button buttonOK;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonInsert;
        private ToolStripButton toolStripButtonResult;
        private ToolStripButton toolStripButtonRepeat;
        public System.Windows.Forms.Timer timerMinutes;
        private PictureBox pictureBox1;
        private Button buttonAnotherWord;
        private Label labelInfo;
        private Button buttonHint;
        private TextBox textBoxSearchWord;
        private Button buttonSearch;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButtonTableWords;
    }
}