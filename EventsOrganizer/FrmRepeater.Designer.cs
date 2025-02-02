namespace EventsOrganizer
{
    partial class FrmRepeater
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
            comboBoxYears = new ComboBox();
            buttonAdd = new Button();
            comboBoxMonths = new ComboBox();
            comboBoxDays = new ComboBox();
            comboBoxHours = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBoxMinutes = new ComboBox();
            label5 = new Label();
            comboBoxIds = new ComboBox();
            label6 = new Label();
            buttonClear = new Button();
            SuspendLayout();
            // 
            // comboBoxYears
            // 
            comboBoxYears.FormattingEnabled = true;
            comboBoxYears.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            comboBoxYears.Location = new Point(112, 56);
            comboBoxYears.Name = "comboBoxYears";
            comboBoxYears.Size = new Size(64, 23);
            comboBoxYears.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(112, 110);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(388, 39);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "A D D";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // comboBoxMonths
            // 
            comboBoxMonths.FormattingEnabled = true;
            comboBoxMonths.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            comboBoxMonths.Location = new Point(197, 56);
            comboBoxMonths.Name = "comboBoxMonths";
            comboBoxMonths.Size = new Size(64, 23);
            comboBoxMonths.TabIndex = 2;
            // 
            // comboBoxDays
            // 
            comboBoxDays.FormattingEnabled = true;
            comboBoxDays.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" });
            comboBoxDays.Location = new Point(277, 56);
            comboBoxDays.Name = "comboBoxDays";
            comboBoxDays.Size = new Size(64, 23);
            comboBoxDays.TabIndex = 3;
            // 
            // comboBoxHours
            // 
            comboBoxHours.FormattingEnabled = true;
            comboBoxHours.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24" });
            comboBoxHours.Location = new Point(356, 56);
            comboBoxHours.Name = "comboBoxHours";
            comboBoxHours.Size = new Size(64, 23);
            comboBoxHours.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 38);
            label1.Name = "label1";
            label1.Size = new Size(29, 15);
            label1.TabIndex = 5;
            label1.Text = "Year";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 38);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 6;
            label2.Text = "Month";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(277, 38);
            label3.Name = "label3";
            label3.Size = new Size(27, 15);
            label3.TabIndex = 7;
            label3.Text = "Day";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(356, 38);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 8;
            label4.Text = "Hour";
            // 
            // comboBoxMinutes
            // 
            comboBoxMinutes.FormattingEnabled = true;
            comboBoxMinutes.Items.AddRange(new object[] { "1", "2", "3", "5", "10", "20", "30", "40", "50", "55" });
            comboBoxMinutes.Location = new Point(436, 56);
            comboBoxMinutes.Name = "comboBoxMinutes";
            comboBoxMinutes.Size = new Size(64, 23);
            comboBoxMinutes.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(436, 38);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 10;
            label5.Text = "Minute";
            // 
            // comboBoxIds
            // 
            comboBoxIds.FormattingEnabled = true;
            comboBoxIds.Location = new Point(23, 56);
            comboBoxIds.Name = "comboBoxIds";
            comboBoxIds.Size = new Size(67, 23);
            comboBoxIds.TabIndex = 11;
            comboBoxIds.SelectedIndexChanged += comboBoxIds_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 38);
            label6.Name = "label6";
            label6.Size = new Size(17, 15);
            label6.TabIndex = 12;
            label6.Text = "Id";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(385, 195);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(115, 28);
            buttonClear.TabIndex = 13;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // FrmRepeater
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 274);
            Controls.Add(buttonClear);
            Controls.Add(label6);
            Controls.Add(comboBoxIds);
            Controls.Add(label5);
            Controls.Add(comboBoxMinutes);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxHours);
            Controls.Add(comboBoxDays);
            Controls.Add(comboBoxMonths);
            Controls.Add(buttonAdd);
            Controls.Add(comboBoxYears);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmRepeater";
            Text = "Repeater";
            Load += FrmRepeater_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxYears;
        private Button buttonAdd;
        private ComboBox comboBoxMonths;
        private ComboBox comboBoxDays;
        private ComboBox comboBoxHours;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxMinutes;
        private Label label5;
        private ComboBox comboBoxIds;
        private Label label6;
        private Button buttonClear;
    }
}