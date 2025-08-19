namespace EventsOrganizer
{
    partial class FrmTableWords
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
            dataGridViewWords = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enWordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bgWordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enBgWordBindingSource = new BindingSource(components);
            buttonRefresh = new Button();
            labelRows = new Label();
            buttonUpdate = new Button();
            textBoxSearch = new TextBox();
            buttonSearch = new Button();
            checkBoxEnWord = new CheckBox();
            checkBoxBgWord = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enBgWordBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewWords
            // 
            dataGridViewWords.AutoGenerateColumns = false;
            dataGridViewWords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWords.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, enWordDataGridViewTextBoxColumn, bgWordDataGridViewTextBoxColumn });
            dataGridViewWords.DataSource = enBgWordBindingSource;
            dataGridViewWords.Location = new Point(33, 136);
            dataGridViewWords.Name = "dataGridViewWords";
            dataGridViewWords.Size = new Size(610, 481);
            dataGridViewWords.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // enWordDataGridViewTextBoxColumn
            // 
            enWordDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            enWordDataGridViewTextBoxColumn.DataPropertyName = "EnWord";
            enWordDataGridViewTextBoxColumn.HeaderText = "EnWord";
            enWordDataGridViewTextBoxColumn.Name = "enWordDataGridViewTextBoxColumn";
            // 
            // bgWordDataGridViewTextBoxColumn
            // 
            bgWordDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bgWordDataGridViewTextBoxColumn.DataPropertyName = "BgWord";
            bgWordDataGridViewTextBoxColumn.HeaderText = "BgWord";
            bgWordDataGridViewTextBoxColumn.Name = "bgWordDataGridViewTextBoxColumn";
            // 
            // enBgWordBindingSource
            // 
            enBgWordBindingSource.DataSource = typeof(Data.Models.EnBgWord);
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(668, 136);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(92, 29);
            buttonRefresh.TabIndex = 1;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // labelRows
            // 
            labelRows.AutoSize = true;
            labelRows.Location = new Point(33, 620);
            labelRows.Name = "labelRows";
            labelRows.Size = new Size(35, 15);
            labelRows.TabIndex = 2;
            labelRows.Text = "Rows";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(668, 212);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(92, 29);
            buttonUpdate.TabIndex = 3;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Location = new Point(33, 73);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(284, 23);
            textBoxSearch.TabIndex = 4;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(340, 73);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(116, 23);
            buttonSearch.TabIndex = 5;
            buttonSearch.Text = "Search";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // checkBoxEnWord
            // 
            checkBoxEnWord.AutoSize = true;
            checkBoxEnWord.Location = new Point(33, 35);
            checkBoxEnWord.Name = "checkBoxEnWord";
            checkBoxEnWord.Size = new Size(69, 19);
            checkBoxEnWord.TabIndex = 6;
            checkBoxEnWord.Text = "En word";
            checkBoxEnWord.UseVisualStyleBackColor = true;
            checkBoxEnWord.CheckedChanged += checkBoxEnWord_CheckedChanged;
            // 
            // checkBoxBgWord
            // 
            checkBoxBgWord.AutoSize = true;
            checkBoxBgWord.Location = new Point(143, 35);
            checkBoxBgWord.Name = "checkBoxBgWord";
            checkBoxBgWord.Size = new Size(70, 19);
            checkBoxBgWord.TabIndex = 7;
            checkBoxBgWord.Text = "Bg word";
            checkBoxBgWord.UseVisualStyleBackColor = true;
            checkBoxBgWord.CheckedChanged += checkBoxBgWord_CheckedChanged;
            // 
            // FrmTableWords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(860, 660);
            Controls.Add(checkBoxBgWord);
            Controls.Add(checkBoxEnWord);
            Controls.Add(buttonSearch);
            Controls.Add(textBoxSearch);
            Controls.Add(buttonUpdate);
            Controls.Add(labelRows);
            Controls.Add(buttonRefresh);
            Controls.Add(dataGridViewWords);
            Name = "FrmTableWords";
            Text = "FrmTableWords";
            ((System.ComponentModel.ISupportInitialize)dataGridViewWords).EndInit();
            ((System.ComponentModel.ISupportInitialize)enBgWordBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewWords;
        private BindingSource enBgWordBindingSource;
        private Button buttonRefresh;
        private Label labelRows;
        private Button buttonUpdate;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enWordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bgWordDataGridViewTextBoxColumn;
        private TextBox textBoxSearch;
        private Button buttonSearch;
        private CheckBox checkBoxEnWord;
        private CheckBox checkBoxBgWord;
    }
}