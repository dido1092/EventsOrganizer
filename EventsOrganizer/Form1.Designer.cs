namespace EventsOrganizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBoxEventName = new TextBox();
            buttonAddEvent = new Button();
            dataGridViewEvents = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eventName = new DataGridViewTextBoxColumn();
            enable = new DataGridViewCheckBoxColumn();
            dateTimeNow = new DataGridViewTextBoxColumn();
            RemindDateTime = new DataGridViewTextBoxColumn();
            RemainingDays = new DataGridViewTextBoxColumn();
            State = new DataGridViewTextBoxColumn();
            eventBindingSource = new BindingSource(components);
            labelEventNums = new Label();
            buttonRefresh = new Button();
            buttonDeleteEvent = new Button();
            buttonUpdateEvent = new Button();
            buttonOnOff = new Button();
            notifyIconGeneral = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            showToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            labelTime = new Label();
            labelInfo = new Label();
            pictureBoxSound = new PictureBox();
            timerUpdateDateTimeNow = new System.Windows.Forms.Timer(components);
            buttonRepeat = new Button();
            buttonLearnEnglish = new Button();
            timerRepeatWord = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)eventBindingSource).BeginInit();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSound).BeginInit();
            SuspendLayout();
            // 
            // textBoxEventName
            // 
            textBoxEventName.Location = new Point(45, 40);
            textBoxEventName.Name = "textBoxEventName";
            textBoxEventName.Size = new Size(213, 23);
            textBoxEventName.TabIndex = 0;
            // 
            // buttonAddEvent
            // 
            buttonAddEvent.Location = new Point(264, 36);
            buttonAddEvent.Name = "buttonAddEvent";
            buttonAddEvent.Size = new Size(115, 34);
            buttonAddEvent.TabIndex = 1;
            buttonAddEvent.Text = "Add Event";
            buttonAddEvent.UseVisualStyleBackColor = true;
            buttonAddEvent.Click += buttonAddEvent_Click;
            // 
            // dataGridViewEvents
            // 
            dataGridViewEvents.AllowUserToAddRows = false;
            dataGridViewEvents.AutoGenerateColumns = false;
            dataGridViewEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEvents.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, eventName, enable, dateTimeNow, RemindDateTime, RemainingDays, State });
            dataGridViewEvents.DataSource = eventBindingSource;
            dataGridViewEvents.Location = new Point(45, 117);
            dataGridViewEvents.Name = "dataGridViewEvents";
            dataGridViewEvents.Size = new Size(883, 450);
            dataGridViewEvents.TabIndex = 2;
            dataGridViewEvents.CellContentClick += dataGridViewEvents_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // eventName
            // 
            eventName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            eventName.DataPropertyName = "eventName";
            eventName.HeaderText = "eventName";
            eventName.Name = "eventName";
            // 
            // enable
            // 
            enable.DataPropertyName = "enable";
            enable.HeaderText = "enable";
            enable.Name = "enable";
            // 
            // dateTimeNow
            // 
            dateTimeNow.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dateTimeNow.DataPropertyName = "dateTimeNow";
            dateTimeNow.HeaderText = "dateTimeNow";
            dateTimeNow.Name = "dateTimeNow";
            // 
            // RemindDateTime
            // 
            RemindDateTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RemindDateTime.DataPropertyName = "RemindDateTime";
            RemindDateTime.HeaderText = "RemindDateTime";
            RemindDateTime.Name = "RemindDateTime";
            // 
            // RemainingDays
            // 
            RemainingDays.DataPropertyName = "RemainingDays";
            RemainingDays.HeaderText = "RemainingDays";
            RemainingDays.Name = "RemainingDays";
            // 
            // State
            // 
            State.DataPropertyName = "State";
            State.HeaderText = "State";
            State.Name = "State";
            // 
            // eventBindingSource
            // 
            eventBindingSource.DataSource = typeof(Data.Models.Event);
            // 
            // labelEventNums
            // 
            labelEventNums.AutoSize = true;
            labelEventNums.Location = new Point(45, 570);
            labelEventNums.Name = "labelEventNums";
            labelEventNums.Size = new Size(44, 15);
            labelEventNums.TabIndex = 3;
            labelEventNums.Text = "Events:";
            labelEventNums.Click += labelEventNums_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(941, 114);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(118, 32);
            buttonRefresh.TabIndex = 4;
            buttonRefresh.Text = "REFRESH";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonDeleteEvent
            // 
            buttonDeleteEvent.Location = new Point(941, 276);
            buttonDeleteEvent.Name = "buttonDeleteEvent";
            buttonDeleteEvent.Size = new Size(118, 32);
            buttonDeleteEvent.TabIndex = 4;
            buttonDeleteEvent.Text = "CLEAR";
            buttonDeleteEvent.UseVisualStyleBackColor = true;
            buttonDeleteEvent.Click += buttonDeleteEvent_Click;
            // 
            // buttonUpdateEvent
            // 
            buttonUpdateEvent.Location = new Point(941, 201);
            buttonUpdateEvent.Name = "buttonUpdateEvent";
            buttonUpdateEvent.Size = new Size(118, 32);
            buttonUpdateEvent.TabIndex = 4;
            buttonUpdateEvent.Text = "UPDATE";
            buttonUpdateEvent.UseVisualStyleBackColor = true;
            buttonUpdateEvent.Click += buttonUpdateEvent_Click;
            // 
            // buttonOnOff
            // 
            buttonOnOff.Location = new Point(941, 30);
            buttonOnOff.Name = "buttonOnOff";
            buttonOnOff.Size = new Size(118, 33);
            buttonOnOff.TabIndex = 5;
            buttonOnOff.Text = "OFF";
            buttonOnOff.UseVisualStyleBackColor = true;
            buttonOnOff.Click += buttonOnOff_Click;
            // 
            // notifyIconGeneral
            // 
            notifyIconGeneral.BalloonTipTitle = "Event Organizer";
            notifyIconGeneral.ContextMenuStrip = contextMenuStrip1;
            notifyIconGeneral.Icon = (Icon)resources.GetObject("notifyIconGeneral.Icon");
            notifyIconGeneral.Text = "Event Organizer";
            notifyIconGeneral.Visible = true;
            notifyIconGeneral.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { showToolStripMenuItem, exitToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 48);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // showToolStripMenuItem
            // 
            showToolStripMenuItem.Name = "showToolStripMenuItem";
            showToolStripMenuItem.Size = new Size(103, 22);
            showToolStripMenuItem.Text = "Show";
            showToolStripMenuItem.Click += showToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(103, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(45, 604);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(36, 15);
            labelTime.TabIndex = 7;
            labelTime.Text = "Time:";
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelInfo.Location = new Point(385, 40);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(67, 25);
            labelInfo.TabIndex = 8;
            labelInfo.Text = "INFO: ";
            labelInfo.Click += labelInfo_Click;
            // 
            // pictureBoxSound
            // 
            pictureBoxSound.Image = (Image)resources.GetObject("pictureBoxSound.Image");
            pictureBoxSound.Location = new Point(941, 540);
            pictureBoxSound.Name = "pictureBoxSound";
            pictureBoxSound.Size = new Size(27, 27);
            pictureBoxSound.TabIndex = 9;
            pictureBoxSound.TabStop = false;
            pictureBoxSound.Tag = "";
            pictureBoxSound.Click += pictureBoxSound_Click;
            // 
            // timerUpdateDateTimeNow
            // 
            timerUpdateDateTimeNow.Enabled = true;
            timerUpdateDateTimeNow.Interval = 60000;
            timerUpdateDateTimeNow.Tick += timerUpdateDateTimeNow_Tick;
            // 
            // buttonRepeat
            // 
            buttonRepeat.Location = new Point(941, 368);
            buttonRepeat.Name = "buttonRepeat";
            buttonRepeat.Size = new Size(90, 30);
            buttonRepeat.TabIndex = 10;
            buttonRepeat.Text = "Repeat";
            buttonRepeat.UseVisualStyleBackColor = true;
            buttonRepeat.Click += buttonRepeat_Click;
            // 
            // buttonLearnEnglish
            // 
            buttonLearnEnglish.Location = new Point(941, 437);
            buttonLearnEnglish.Name = "buttonLearnEnglish";
            buttonLearnEnglish.Size = new Size(90, 30);
            buttonLearnEnglish.TabIndex = 11;
            buttonLearnEnglish.Text = "Learn English";
            buttonLearnEnglish.UseVisualStyleBackColor = true;
            buttonLearnEnglish.Click += buttonLearnEnglish_Click;
            // 
            // timerRepeatWord
            // 
            timerRepeatWord.Enabled = true;
            timerRepeatWord.Interval = 1000;
            timerRepeatWord.Tick += timerRepeatWord_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 640);
            Controls.Add(buttonLearnEnglish);
            Controls.Add(buttonRepeat);
            Controls.Add(pictureBoxSound);
            Controls.Add(labelInfo);
            Controls.Add(labelTime);
            Controls.Add(buttonOnOff);
            Controls.Add(buttonUpdateEvent);
            Controls.Add(buttonDeleteEvent);
            Controls.Add(buttonRefresh);
            Controls.Add(labelEventNums);
            Controls.Add(dataGridViewEvents);
            Controls.Add(buttonAddEvent);
            Controls.Add(textBoxEventName);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Organizer";
            FormClosing += Form1_FormClosing;
            Load += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridViewEvents).EndInit();
            ((System.ComponentModel.ISupportInitialize)eventBindingSource).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxSound).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEventName;
        private Button buttonAddEvent;
        private DataGridViewTextBoxColumn eventNameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn enableDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn dateTimeDataGridViewTextBoxColumn;
        private BindingSource eventBindingSource;
        private Button buttonRefresh;
        private Button buttonDeleteEvent;
        private Button buttonUpdateEvent;
        private Button buttonOnOff;
        private NotifyIcon notifyIconGeneral;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private Label labelTime;
        private Label labelInfo;
        private PictureBox pictureBoxSound;
        public Label labelEventNums;
        public DataGridView dataGridViewEvents;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn eventName;
        private DataGridViewCheckBoxColumn enable;
        private DataGridViewTextBoxColumn dateTimeNow;
        private DataGridViewTextBoxColumn RemindDateTime;
        private DataGridViewTextBoxColumn RemainingDays;
        private DataGridViewTextBoxColumn State;
        private System.Windows.Forms.Timer timerUpdateDateTimeNow;
        private Button buttonRepeat;
        private Button buttonLearnEnglish;
        private System.Windows.Forms.Timer timerRepeatWord;
    }
}
