namespace EventsOrganizer
{
    partial class FrmResults
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
            dataGridViewResult = new DataGridView();
            resultBindingSource = new BindingSource(components);
            buttonRefresh = new Button();
            labelRows = new Label();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            enWordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bgWordDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isCorrectDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            Hint = new DataGridViewCheckBoxColumn();
            dateTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewResult
            // 
            dataGridViewResult.AllowUserToAddRows = false;
            dataGridViewResult.AllowUserToDeleteRows = false;
            dataGridViewResult.AutoGenerateColumns = false;
            dataGridViewResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewResult.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, enWordDataGridViewTextBoxColumn, bgWordDataGridViewTextBoxColumn, isCorrectDataGridViewCheckBoxColumn, Hint, dateTimeDataGridViewTextBoxColumn });
            dataGridViewResult.DataSource = resultBindingSource;
            dataGridViewResult.Location = new Point(35, 62);
            dataGridViewResult.Name = "dataGridViewResult";
            dataGridViewResult.ReadOnly = true;
            dataGridViewResult.Size = new Size(664, 332);
            dataGridViewResult.TabIndex = 0;
            // 
            // resultBindingSource
            // 
            resultBindingSource.DataSource = typeof(Data.Models.Result);
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(719, 62);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(96, 31);
            buttonRefresh.TabIndex = 1;
            buttonRefresh.Text = "REFRESH";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // labelRows
            // 
            labelRows.AutoSize = true;
            labelRows.Location = new Point(37, 414);
            labelRows.Name = "labelRows";
            labelRows.Size = new Size(38, 15);
            labelRows.TabIndex = 2;
            labelRows.Text = "Rows:";
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // enWordDataGridViewTextBoxColumn
            // 
            enWordDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            enWordDataGridViewTextBoxColumn.DataPropertyName = "EnWord";
            enWordDataGridViewTextBoxColumn.HeaderText = "EnWord";
            enWordDataGridViewTextBoxColumn.Name = "enWordDataGridViewTextBoxColumn";
            enWordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bgWordDataGridViewTextBoxColumn
            // 
            bgWordDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            bgWordDataGridViewTextBoxColumn.DataPropertyName = "BgWord";
            bgWordDataGridViewTextBoxColumn.HeaderText = "BgWord";
            bgWordDataGridViewTextBoxColumn.Name = "bgWordDataGridViewTextBoxColumn";
            bgWordDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isCorrectDataGridViewCheckBoxColumn
            // 
            isCorrectDataGridViewCheckBoxColumn.DataPropertyName = "IsCorrect";
            isCorrectDataGridViewCheckBoxColumn.HeaderText = "IsCorrect";
            isCorrectDataGridViewCheckBoxColumn.Name = "isCorrectDataGridViewCheckBoxColumn";
            isCorrectDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // Hint
            // 
            Hint.DataPropertyName = "Hint";
            Hint.HeaderText = "Hint";
            Hint.Name = "Hint";
            Hint.ReadOnly = true;
            // 
            // dateTimeDataGridViewTextBoxColumn
            // 
            dateTimeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dateTimeDataGridViewTextBoxColumn.DataPropertyName = "DateTime";
            dateTimeDataGridViewTextBoxColumn.HeaderText = "DateTime";
            dateTimeDataGridViewTextBoxColumn.Name = "dateTimeDataGridViewTextBoxColumn";
            dateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmResults
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(857, 450);
            Controls.Add(labelRows);
            Controls.Add(buttonRefresh);
            Controls.Add(dataGridViewResult);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmResults";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmResults";
            ((System.ComponentModel.ISupportInitialize)dataGridViewResult).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewResult;
        private Button buttonRefresh;
        private BindingSource resultBindingSource;
        private Label labelRows;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn enWordDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bgWordDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isCorrectDataGridViewCheckBoxColumn;
        private DataGridViewCheckBoxColumn Hint;
        private DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
    }
}