namespace EventsOrganizer
{
    partial class FrmInsert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsert));
            textBoxEnWord = new TextBox();
            label1 = new Label();
            buttonInserManualWords = new Button();
            textBoxBgWord = new TextBox();
            label2 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButtonInsertFromFile = new ToolStripButton();
            buttonClear = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxEnWord
            // 
            textBoxEnWord.Location = new Point(33, 69);
            textBoxEnWord.Name = "textBoxEnWord";
            textBoxEnWord.Size = new Size(179, 23);
            textBoxEnWord.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 51);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 1;
            label1.Text = "Enter English Word";
            // 
            // buttonInserManualWords
            // 
            buttonInserManualWords.Location = new Point(231, 130);
            buttonInserManualWords.Name = "buttonInserManualWords";
            buttonInserManualWords.Size = new Size(90, 23);
            buttonInserManualWords.TabIndex = 2;
            buttonInserManualWords.Text = "Insert";
            buttonInserManualWords.UseVisualStyleBackColor = true;
            buttonInserManualWords.Click += buttonInserManualWords_Click;
            // 
            // textBoxBgWord
            // 
            textBoxBgWord.Location = new Point(33, 130);
            textBoxBgWord.Name = "textBoxBgWord";
            textBoxBgWord.Size = new Size(179, 23);
            textBoxBgWord.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 112);
            label2.Name = "label2";
            label2.Size = new Size(119, 15);
            label2.TabIndex = 4;
            label2.Text = "Enter Bulgarian Word";
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonInsertFromFile });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(516, 25);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonInsertFromFile
            // 
            toolStripButtonInsertFromFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButtonInsertFromFile.Image = (Image)resources.GetObject("toolStripButtonInsertFromFile.Image");
            toolStripButtonInsertFromFile.ImageTransparentColor = Color.Magenta;
            toolStripButtonInsertFromFile.Name = "toolStripButtonInsertFromFile";
            toolStripButtonInsertFromFile.Size = new Size(23, 22);
            toolStripButtonInsertFromFile.Text = "InsertFromFile";
            toolStripButtonInsertFromFile.Click += toolStripButtonInsertFromFile_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(400, 28);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(80, 24);
            buttonClear.TabIndex = 6;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // FrmInsert
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(516, 211);
            Controls.Add(buttonClear);
            Controls.Add(toolStrip1);
            Controls.Add(label2);
            Controls.Add(textBoxBgWord);
            Controls.Add(buttonInserManualWords);
            Controls.Add(label1);
            Controls.Add(textBoxEnWord);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmInsert";
            Text = "FrmInsert";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEnWord;
        private Label label1;
        private Button buttonInserManualWords;
        private TextBox textBoxBgWord;
        private Label label2;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonInsertFromFile;
        private Button buttonClear;
    }
}