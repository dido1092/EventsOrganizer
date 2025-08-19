namespace EventsOrganizer
{
    partial class FrmRepeatWord
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
            comboBoxMin = new ComboBox();
            label1 = new Label();
            buttonAddMin = new Button();
            checkBoxRepeat = new CheckBox();
            checkBoxShowOnBg = new CheckBox();
            checkBoxShowOnEn = new CheckBox();
            SuspendLayout();
            // 
            // comboBoxMin
            // 
            comboBoxMin.FormattingEnabled = true;
            comboBoxMin.Items.AddRange(new object[] { "15", "30", "45", "60", "90", "120", "150", "180", "240" });
            comboBoxMin.Location = new Point(45, 44);
            comboBoxMin.Name = "comboBoxMin";
            comboBoxMin.Size = new Size(77, 23);
            comboBoxMin.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 26);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Min.";
            // 
            // buttonAddMin
            // 
            buttonAddMin.Location = new Point(215, 43);
            buttonAddMin.Name = "buttonAddMin";
            buttonAddMin.Size = new Size(75, 23);
            buttonAddMin.TabIndex = 2;
            buttonAddMin.Text = "Add";
            buttonAddMin.UseVisualStyleBackColor = true;
            buttonAddMin.Click += buttonAddMin_Click;
            // 
            // checkBoxRepeat
            // 
            checkBoxRepeat.AutoSize = true;
            checkBoxRepeat.Location = new Point(128, 48);
            checkBoxRepeat.Name = "checkBoxRepeat";
            checkBoxRepeat.Size = new Size(62, 19);
            checkBoxRepeat.TabIndex = 3;
            checkBoxRepeat.Text = "Repeat";
            checkBoxRepeat.UseVisualStyleBackColor = true;
            checkBoxRepeat.CheckedChanged += checkBoxRepeat_CheckedChanged;
            // 
            // checkBoxShowOnBg
            // 
            checkBoxShowOnBg.AutoSize = true;
            checkBoxShowOnBg.Location = new Point(45, 94);
            checkBoxShowOnBg.Name = "checkBoxShowOnBg";
            checkBoxShowOnBg.Size = new Size(91, 19);
            checkBoxShowOnBg.TabIndex = 4;
            checkBoxShowOnBg.Text = "Show On Bg";
            checkBoxShowOnBg.UseVisualStyleBackColor = true;
            checkBoxShowOnBg.CheckedChanged += checkBoxShowOnBg_CheckedChanged;
            // 
            // checkBoxShowOnEn
            // 
            checkBoxShowOnEn.AutoSize = true;
            checkBoxShowOnEn.Location = new Point(45, 128);
            checkBoxShowOnEn.Name = "checkBoxShowOnEn";
            checkBoxShowOnEn.Size = new Size(90, 19);
            checkBoxShowOnEn.TabIndex = 5;
            checkBoxShowOnEn.Text = "Show On En";
            checkBoxShowOnEn.UseVisualStyleBackColor = true;
            checkBoxShowOnEn.CheckedChanged += checkBoxShowOnEn_CheckedChanged;
            // 
            // FrmRepeatWord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(348, 183);
            Controls.Add(checkBoxShowOnEn);
            Controls.Add(checkBoxShowOnBg);
            Controls.Add(checkBoxRepeat);
            Controls.Add(buttonAddMin);
            Controls.Add(label1);
            Controls.Add(comboBoxMin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmRepeatWord";
            Text = "FrmRepeatWord";
            Load += FrmRepeatWord_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxMin;
        private Label label1;
        private Button buttonAddMin;
        private CheckBox checkBoxRepeat;
        private CheckBox checkBoxShowOnBg;
        private CheckBox checkBoxShowOnEn;
    }
}