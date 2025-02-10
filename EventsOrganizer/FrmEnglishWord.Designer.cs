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
            toolStripButtonResult = new ToolStripButton();
            toolStripButtonRepeat = new ToolStripButton();
            timerMinutes = new System.Windows.Forms.Timer(components);
            pictureBox1 = new PictureBox();
            buttonAnotherWord = new Button();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelWord
            // 
            labelWord.AutoSize = true;
            labelWord.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelWord.Location = new Point(31, 41);
            labelWord.Name = "labelWord";
            labelWord.Size = new Size(79, 30);
            labelWord.TabIndex = 0;
            labelWord.Text = "WORD";
            // 
            // textBoxWord
            // 
            textBoxWord.Location = new Point(31, 108);
            textBoxWord.Name = "textBoxWord";
            textBoxWord.Size = new Size(317, 23);
            textBoxWord.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(354, 108);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonInsert, toolStripButtonResult, toolStripButtonRepeat });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(535, 25);
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
            pictureBox1.Location = new Point(445, 108);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 23);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // buttonAnotherWord
            // 
            buttonAnotherWord.Location = new Point(31, 153);
            buttonAnotherWord.Name = "buttonAnotherWord";
            buttonAnotherWord.Size = new Size(96, 23);
            buttonAnotherWord.TabIndex = 6;
            buttonAnotherWord.Text = "Another word";
            buttonAnotherWord.UseVisualStyleBackColor = true;
            buttonAnotherWord.Click += buttonAnotherWord_Click;
            // 
            // FrmEnglishWord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 255);
            Controls.Add(buttonAnotherWord);
            Controls.Add(pictureBox1);
            Controls.Add(toolStrip1);
            Controls.Add(buttonOK);
            Controls.Add(textBoxWord);
            Controls.Add(labelWord);
            FormBorderStyle = FormBorderStyle.FixedSingle;
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

        private Label labelWord;
        private TextBox textBoxWord;
        private Button buttonOK;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonInsert;
        private ToolStripButton toolStripButtonResult;
        private ToolStripButton toolStripButtonRepeat;
        public System.Windows.Forms.Timer timerMinutes;
        private PictureBox pictureBox1;
        private Button buttonAnotherWord;
    }
}