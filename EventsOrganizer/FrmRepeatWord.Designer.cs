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
            SuspendLayout();
            // 
            // comboBoxMin
            // 
            comboBoxMin.FormattingEnabled = true;
            comboBoxMin.Items.AddRange(new object[] { "15", "30", "60", "90", "120", "150", "180", "240" });
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
            buttonAddMin.Location = new Point(128, 43);
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
            checkBoxRepeat.Location = new Point(45, 92);
            checkBoxRepeat.Name = "checkBoxRepeat";
            checkBoxRepeat.Size = new Size(62, 19);
            checkBoxRepeat.TabIndex = 3;
            checkBoxRepeat.Text = "Repeat";
            checkBoxRepeat.UseVisualStyleBackColor = true;
            checkBoxRepeat.CheckedChanged += checkBoxRepeat_CheckedChanged;
            // 
            // FrmRepeatWord
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 150);
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
    }
}