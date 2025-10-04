using EventsOrganizer.Data;
using EventsOrganizer.Data.Common;
using EventsOrganizer.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Data;

namespace EventsOrganizer
{
    public partial class Form1 : Form
    {
        public static EventsOrganizerContext context = new EventsOrganizerContext();
        private string? columnName = string.Empty;

        private int id = 0;
        private int colindex = 0;

        private bool buttonOnOffWasClicked = false;
        private string getEventName;
        private string[] arrDir;
        private string path;
        private string getEventNameNow = string.Empty;
        private string lastRemindDateTime = string.Empty;
        private string? buttonOnOffState = string.Empty;
        private DateTime lastDateTimeRepeatWord;
        //Form1 form;
        //int interval = 0;
        //FrmRemindInterval frmRemindInterval;// = new FrmRemindInterval(interval);

        public Form1()
        {
            Thread thrDateTimeNow = new Thread(SetStartup);
            thrDateTimeNow.IsBackground = true;
            thrDateTimeNow.Start();

            Thread thr = new Thread(new ThreadStart(ButtonOnOffState));
            thr.IsBackground = true;
            thr.Start();

            //form = new Form1();
            //frmRemindInterval = new FrmRemindInterval();
            InitializeComponent();
        }
        private void SetStartup()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)!;

            rk.SetValue("EventsOrganizer", Application.ExecutablePath);

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIconGeneral.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
        }
        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            string getName = textBoxEventName.Text;

            if (getName.Length > 0)
            {
                var checkForEqualName = context.Events!.Select(n => new { n.Id, n.enable, n.eventName }).Where(n => n.eventName == getName).FirstOrDefault();

                if (checkForEqualName == null)
                {
                    Event @event = new Event()
                    {
                        eventName = getName,
                        enable = false,
                        dateTimeNow = DateTime.Now,
                        RemainingDays = 0,
                        State = ""
                    };
                    context.Events!.Add(@event);

                    context.SaveChanges();

                    MessageBox.Show("Done!");
                }
            }
            Refresh();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            List<int> getDateTime = context.Events!.Select(e => e.Id).ToList();

            if (getDateTime.Count > 0)
            {
                UpdatinEachMinDateTimeNowInTable(getDateTime);
            }

            Refresh();
        }
        public void Refresh()
        {
            SqlConnection cnn = new SqlConnection(DbConfig.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            try
            {
                TableEvents(DbConfig.ConnectionString);

                CountRows(DbConfig.ConnectionString);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void TableEvents(string connectionString)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Events Order By RemainingDays", connectionString);
            DataSet ds = new DataSet();
            da.Fill(ds, "Events");
            dataGridViewEvents.DataSource = ds.Tables["Events"]?.DefaultView;
        }
        private void CountRows(string connectionString)
        {
            // Create the connection.
            SqlConnection conn = new SqlConnection(DbConfig.ConnectionString);

            // Build the query to count, including CustomerID criteria if specified.
            string selectText = "SELECT COUNT(*) FROM Events";

            // Create the command to count the records.
            SqlCommand cmd = new SqlCommand(selectText, conn);

            // Execute the command, storing the results.
            conn.Open();
            int recordCount = (int)cmd.ExecuteScalar();
            conn.Close();
            //labelEventNums.Text = $"Събития бр: {recordCount}";
            labelEventNums.Text = $"Events: {recordCount}";
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void Delete()
        {
            DataGridViewCell cell = dataGridViewEvents.SelectedCells[0] as DataGridViewCell;

            string value = cell.Value.ToString()!;
            int getEventId = int.Parse(value!);

            var eventId = context.Events!.Where(v => v.Id == getEventId).FirstOrDefault();

            try
            {
                if (eventId != null)
                {
                    context.Events!.Remove(eventId);
                    context.SaveChanges();
                }
                MessageBox.Show($"The Event '{getEventId}' has been deleted! ");

                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Event Can'not deleted! ");
            }
        }

        private void buttonUpdateEvent_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void Update()
        {
            string connectionString = null;
            connectionString = DbConfig.ConnectionString;

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            int rowindex = dataGridViewEvents.CurrentRow.Index;
            colindex = dataGridViewEvents.CurrentCell.ColumnIndex;

            columnName = dataGridViewEvents.Columns[colindex].HeaderText;

            string? getValue = dataGridViewEvents.CurrentCell.Value.ToString();
            string? getId = dataGridViewEvents.Rows[rowindex].Cells[0].Value.ToString();

            bool checkId = int.TryParse(getId!, out id);

            if (checkId)
            {
                var getValues = context.Events!.Select(v => new { v.Id, v.eventName, v.enable, v.dateTimeNow, v.remindDateTime }).Where(v => v.Id == id).AsNoTracking().FirstOrDefault();

                using (cnn = new SqlConnection(connectionString))
                {
                    string getColumnValue = dataGridViewEvents.SelectedCells[0].Value.ToString()!;

                    lastRemindDateTime = getColumnValue;

                    if (columnName == "enable")
                    {
                        bool isEnableChecked = Convert.ToBoolean(dataGridViewEvents.SelectedCells[0].EditedFormattedValue);

                        if (getValues != null)
                        {
                            if (isEnableChecked)
                            {
                                SetEnbleToTrue(cnn, cmd, columnName, getValues.eventName, checkId);
                            }
                            else
                            {
                                SetEnbleToFalse(cnn, cmd, columnName, getValues.eventName, checkId);
                            }
                        }
                    }
                    if (columnName == "RemindDateTime" && dataGridViewEvents.SelectedCells[0].Value != null)
                    {
                        string dateTimeNow = DateTime.Now.ToString();

                        TimeSpan span = Convert.ToDateTime(getColumnValue).Subtract(Convert.ToDateTime(dateTimeNow));

                        var remainingDays = span.Days;

                        var totalMiliseconds = span.TotalMilliseconds;

                        if (totalMiliseconds > 0)
                        {
                            var res = System.Convert.ToDateTime(getColumnValue);

                            cnn.Open();
                            string sqlCommand = $"Update Events set {columnName}=@{columnName},State=@State, RemainingDays=@RemainingDays Where Id={id}";
                            cmd = new SqlCommand(sqlCommand, cnn);
                            cmd.Parameters.AddWithValue($"@{columnName}", res);
                            cmd.Parameters.AddWithValue($"@RemainingDays", $"{remainingDays}");

                            if (getValues!.enable == true)
                            {
                                cmd.Parameters.AddWithValue($"@State", "Waiting...");
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue($"@State", "");
                            }

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                            {
                                MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            cnn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Оставащата дата трябва да е по-голяма от текущата!");
                        }
                    }
                    if (columnName == "eventName" && dataGridViewEvents.SelectedCells[0].Value != null)
                    {
                        cnn.Open();
                        string sqlCommand = $"Update Events set {columnName}=@{columnName} Where Id={id}";
                        cmd = new SqlCommand(sqlCommand, cnn);
                        cmd.Parameters.AddWithValue($"@{columnName}", $"{getColumnValue}");

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        cnn.Close();
                    }
                    Refresh();
                }
            }
        }

        public void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DON'T DELETE THIS METHOD!!!
        }

        private SqlCommand SetState(SqlConnection cnn, SqlCommand cmd, int id)
        {
            string lastRemindDateTime = string.Empty;

            var getlastRemindDateTime = context.Events!.Select(r => new { r.Id, r.remindDateTime }).Where(r => r.Id == id).FirstOrDefault();

            if (getlastRemindDateTime != null)
            {
                lastRemindDateTime = getlastRemindDateTime!.remindDateTime.ToString();


                string dateTimeNow = DateTime.Now.ToString();

                TimeSpan span = Convert.ToDateTime(lastRemindDateTime).Subtract(Convert.ToDateTime(dateTimeNow));

                var remainingDays = span.Days;

                var totalMiliseconds = span.TotalMilliseconds;

                cmd.Connection = cnn;
                string sqlCommand = $"Update Events set State=@State Where Id={id}";
                cmd = new SqlCommand(sqlCommand, cnn);

                if (totalMiliseconds > 0)
                {
                    cmd.Parameters.AddWithValue($"@State", "Waiting...");
                }
                else
                {
                    cmd.Parameters.AddWithValue($"@State", "Passed!");
                }
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            return cmd;
        }

        private SqlCommand SetEnbleToTrue(SqlConnection cnn, SqlCommand cmd, string columnName, string eventName, bool checkId)
        {
            if (checkId)
            {
                cmd.Connection = cnn;
                cnn.Open();
                string sqlCommand = $"Update Events set {columnName}=@{columnName} Where Id={id}";
                cmd = new SqlCommand(sqlCommand, cnn);
                cmd.Parameters.AddWithValue($"@{columnName}", true);

                SetState(cnn, cmd, id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                cnn.Close();
            }

            return cmd;
        }
        private SqlCommand SetEnbleToFalse(SqlConnection cnn, SqlCommand cmd, string columnName, string eventName, bool checkId)
        {
            if (checkId)
            {
                cmd.Connection = cnn;
                cnn.Open();

                string sqlCommand = $"Update Events set {columnName}=@{columnName}, remindDateTime=@remindDateTime, RemainingDays=@RemainingDays, State=@State Where Id={id}";

                cmd = new SqlCommand(sqlCommand, cnn);

                cmd.Parameters.AddWithValue($"@{columnName}", false);
                cmd.Parameters.AddWithValue($"@remindDateTime", "");
                cmd.Parameters.AddWithValue($"@RemainingDays", "");
                cmd.Parameters.AddWithValue($"@State", "");

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 1)
                {
                    MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cnn.Close();
            }

            return cmd;
        }
        private void ButtonOnOffState()
        {
            var getButtonOnOffState = context.ButtonOnOffs!.Select(s => new { s.Id, s.State }).FirstOrDefault();

            buttonOnOffState = getButtonOnOffState!.State;

            if (buttonOnOffState == "ON")
            {
                buttonOnOff.BackColor = Color.Green;
            }
            else if (buttonOnOffState == "OFF")
            {
                buttonOnOff.BackColor = Color.Red;
            }

            while (!this.IsHandleCreated)
                System.Threading.Thread.Sleep(100);

            Invoke(new Action(() =>
            {
                buttonOnOff.Text = getButtonOnOffState!.State;
            }));
        }
        private void buttonOnOff_Click(object sender, EventArgs e)
        {
            ButtonOnOffClick(buttonOnOffState!);
        }

        private void ButtonOnOffClick(string state)
        {
            List<int> getDateTime = context.Events!.Select(e => e.Id).ToList();

            if (getDateTime.Count > 0)
            {
                UpdatinEachMinDateTimeNowInTable(getDateTime);
            }

            if (buttonOnOff.Text == "OFF")
            {
                Invoke(new Action(() =>
                {
                    buttonOnOff.Text = "ON";
                }));

                buttonOnOff.BackColor = Color.Green;

                timer1.Enabled = true;
                //timerBrazenly.Enabled = true;
                timerUpdateDateTimeNow.Enabled = true;

                UpdateButtonToOn();
            }
            else
            {
                if (buttonOnOff.Text == "ON")
                {
                    Invoke(new Action(() =>
                    {
                        buttonOnOff.Text = "OFF";
                    }));
                }

                buttonOnOff.BackColor = Color.Red;

                timer1.Enabled = false;
                //timerBrazenly.Enabled = false;
                timerUpdateDateTimeNow.Enabled = false;

                UpdateButtonToOff();
            }
            state = buttonOnOff.Text;
        }

        private void CheckForEqualTime()
        {
            //string currentDir = this.GetType().Assembly.Location;
            //string[] arrDir = currentDir.Split("\\");
            //string path = string.Empty;

            var getAllEnablesTrue = context.Events!.Select(e => new { e.Id, e.eventName, e.enable, e.dateTimeNow, e.remindDateTime }).Where(e => e.enable == true).ToList();

            //for (int i = 0; i < arrDir.Length - 1; i++)
            //{
            //    path += arrDir[i] + "\\";
            //}
            //path += "Sounds\\FunnySound.wav";

            string currentDateTime = DateTime.Now.ToString();

            foreach (var e in getAllEnablesTrue)
            {
                string remindDateTime = e.remindDateTime.ToString();
                string eventName = e.eventName.ToString();

                if (currentDateTime == remindDateTime)
                {
                    PlaySound();

                    MessageBox.Show($"{e.eventName}!!!");

                    PrintInfo(currentDateTime, eventName);

                    return;
                }
            }
        }

        private void PrintInfo(string currentDateTime, string eventName)
        {
            labelInfo.Text = $"{eventName} - {currentDateTime}";
            labelInfo.ForeColor = Color.Red;
        }

        private void PlaySound()
        {
            string path = string.Empty;

            string currentDir = this.GetType().Assembly.Location;
            string[] arrDir = currentDir.Split("\\");

            for (int i = 0; i < arrDir.Length - 1; i++)
            {
                path += arrDir[i] + "\\";
            }
            path += "Sounds\\FunnySound.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);
            player.Play();
        }

        private void UpdatinEachMinDateTimeNowInTable(List<int> getDateTime)
        {
            foreach (var e in getDateTime)
            {
                string connectionString = null;
                connectionString = DbConfig.ConnectionString; //ConnectionString();
                SqlConnection cnn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                cmd.Connection = cnn;
                cnn.Open();
                string sqlCommand = $"Update Events set dateTimeNow = @dateTimeNow Where Id={e}";
                cmd = new SqlCommand(sqlCommand, cnn);
                cmd.Parameters.AddWithValue($"@dateTimeNow", DateTime.Now);
                int rowsAffected = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            Refresh();
        }
        private void UpdateRemainingDays()
        {
            var getRemindDateTime = context.Events!.Select(r => new { r.Id, r.enable, r.remindDateTime, r.RemainingDays }).Where(r => r.enable == true).ToList();

            foreach (var r in getRemindDateTime)
            {
                DateTime dateTimeNow = DateTime.Now;

                TimeSpan span = Convert.ToDateTime(r.remindDateTime).Subtract(Convert.ToDateTime(dateTimeNow));

                var remainingDays = span.Days;

                string connectionString = null;
                connectionString = DbConfig.ConnectionString;
                SqlConnection cnn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;

                cmd.Connection = cnn;
                cnn.Open();
                string sqlCommand = $"Update Events set RemainingDays=@RemainingDays Where Id={r.Id}";
                cmd = new SqlCommand(sqlCommand, cnn);
                cmd.Parameters.AddWithValue($"@RemainingDays", remainingDays);
                int rowsAffected = cmd.ExecuteNonQuery();
                cnn.Close();
            }

            Refresh();
        }
        private void UpdateButtonToOff()
        {
            string connectionString = null!;
            connectionString = DbConfig.ConnectionString;

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            columnName = "State";

            cmd.Connection = cnn;
            cnn.Open();
            string sqlCommand = $"Update [ButtonOnOffs] set {columnName}=@{columnName} Where Id={1}";
            cmd = new SqlCommand(sqlCommand, cnn);
            cmd.Parameters.AddWithValue($"@{columnName}", "OFF");
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cnn.Close();
        }

        private void UpdateButtonToOn()
        {
            string connectionString = null;
            connectionString = DbConfig.ConnectionString;

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            columnName = "State";

            cmd.Connection = cnn;
            cnn.Open();
            string sqlCommand = $"Update [ButtonOnOffs] set {columnName}=@{columnName} Where Id={1}";
            cmd = new SqlCommand(sqlCommand, cnn);
            cmd.Parameters.AddWithValue($"@{columnName}", "ON");
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cnn.Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifyIconGeneral.ContextMenuStrip = contextMenuStrip1;

            this.Show();

            MaxmizedFromTray();
        }
        private void MinimzedTray()
        {
            notifyIconGeneral.Visible = true;
            notifyIconGeneral.Icon = SystemIcons.Application;

            notifyIconGeneral.BalloonTipText = "Minimized";
            //notifyIcon1.BalloonTipTitle = "Your Application is Running in BackGround";
            notifyIconGeneral.ShowBalloonTip(500);
        }

        private void MaxmizedFromTray()
        {
            notifyIconGeneral.Visible = true;
            notifyIconGeneral.BalloonTipText = "Maximized";
            //notifyIcon1.BalloonTipTitle = "Application is Running in Foreground";
            notifyIconGeneral.ShowBalloonTip(500);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            FrmEnglishWord frmEnglishWord = new FrmEnglishWord(lastDateTimeRepeatWord);
            frmEnglishWord.ShowDialog();

            if (FormWindowState.Minimized == this.WindowState)
            {
                MinimzedTray();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {

                MaxmizedFromTray();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void buttonPromptEvent_Click(object sender, EventArgs e)
        {
            CheckForEqualTime();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pardeepTimer();
        }
        private void pardeepTimer()
        {
            //labelTime.Text = $"Време: {DateTime.Now.ToString()}";
            labelTime.Text = $"Time: {DateTime.Now.ToString()}";

            if (buttonOnOff.Text == "ON")
            {
                string currentDateTime = DateTime.Now.ToString();

                var getAllEnablesTrue = context.Events!.Select(e => new { e.Id, e.eventName, e.enable, e.dateTimeNow, e.remindDateTime }).Where(e => e.enable == true).ToList();

                foreach (var e in getAllEnablesTrue)
                {
                    int getId = e.Id;

                    string remindDateTime = e.remindDateTime.ToString();

                    string eventName = e.eventName.ToString();

                    TimeSpan span = Convert.ToDateTime(remindDateTime).Subtract(Convert.ToDateTime(currentDateTime));

                    var totalMiliseconds = span.TotalMilliseconds;

                    if (totalMiliseconds > 0)
                    {
                        //labelInfo.Text = $"ИНФО:";
                        labelInfo.Text = $"INFO:";
                        labelInfo.ForeColor = Color.Black;
                    }
                    if (remindDateTime == currentDateTime)
                    {
                        SetEventStateToPassed(getId);

                        CheckForEqualTime();

                        List<int> getEnable = context.Events!.Select(e => e.Id).ToList();

                        if (getEnable.Count > 0)
                        {
                            UpdatinEachMinDateTimeNowInTable(getEnable);
                        }

                        this.Show();

                        Refresh();

                        return;
                    }
                    else if (totalMiliseconds < 0)
                    {
                        SetEventStateToPassed(getId);

                        PrintInfo(currentDateTime, eventName);

                        return;

                    }
                }
            }
        }

        //private void BrazenlyTimer()
        //{
        //    if (checkBoxBrazenly.Checked && comboBoxMinutes.Text != "")
        //    {
        //        timerBrazenly.Enabled = true;

        //        int interval = 0;

        //        bool checkMin = int.TryParse(comboBoxMinutes.Text, out interval);

        //        if (checkMin)
        //        {
        //            timerBrazenly.Interval = interval * 60000;

        //            PlaySound();
        //        }

        //        List<int> getEnable = context.Events!.Select(e => e.Id).ToList();

        //        if (getEnable.Count > 0)
        //        {
        //            UpdatinEachMinDateTimeNowInTable(getEnable);
        //        }

        //        Refresh();

        //        this.Show();

        //        return;
        //    }
        //    else
        //    {
        //        timerBrazenly.Enabled = false;
        //    }

        //}

        private void SetEventStateToPassed(int id)
        {
            string connectionString = null!;
            connectionString = DbConfig.ConnectionString;

            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;

            cmd.Connection = cnn;
            cnn.Open();
            string sqlCommand = $"Update Events set State=@State Where Id={id}";
            cmd = new SqlCommand(sqlCommand, cnn);
            cmd.Parameters.AddWithValue($"@State", "Passed!");
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 1)
            {
                //MessageBox.Show("Information Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            cnn.Close();
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxSound_Click(object sender, EventArgs e)
        {
            PlaySound();
        }

        //private void PassedTime()
        //{
        //    string currentDateTime = DateTime.Now.ToString();

        //    var getAllEnablesTrue = context.Events!.Select(e => new { e.Id, e.eventName, e.enable, e.dateTimeNow, e.remindDateTime }).Where(e => e.enable == true).ToList();

        //    foreach (var e in getAllEnablesTrue)
        //    {
        //        int getId = e.Id;

        //        string remindDateTime = e.remindDateTime.ToString();

        //        string eventName = e.eventName.ToString();

        //        TimeSpan span = Convert.ToDateTime(remindDateTime).Subtract(Convert.ToDateTime(currentDateTime));

        //        var totalMiliseconds = span.TotalMilliseconds;

        //        if (totalMiliseconds < 0)
        //        {
        //            PlaySound();
        //            return;
        //        }
        //    }
        //}

        public void labelEventNums_Click(object sender, EventArgs e)
        {

        }

        private void timerBrazenly_Tick(object sender, EventArgs e)
        {
            //BrazenlyTimer();
        }

        private void buttonAddBrazenlyTimer_Click(object sender, EventArgs e)
        {
            //BrazenlyTimer();
            FrmRepeater frmRepeater = new FrmRepeater();
            frmRepeater.TopMost = true;
            frmRepeater.Show();
        }

        private void timerUpdateDateTimeNow_Tick(object sender, EventArgs e)
        {
            List<int> getEnable = context.Events!.Select(e => e.Id).ToList();

            if (getEnable.Count > 0)
            {
                UpdatinEachMinDateTimeNowInTable(getEnable);

                UpdateRemainingDays();
            }
        }

        private void buttonRepeat_Click(object sender, EventArgs e)
        {
            FrmRepeater frmRepeater = new FrmRepeater();
            frmRepeater.TopMost = true;
            frmRepeater.Show();
        }

        private void buttonLearnEnglish_Click(object sender, EventArgs e)
        {
            FrmEnglishWord frmEnglishWord = new FrmEnglishWord(lastDateTimeRepeatWord);
            frmEnglishWord.Show();
        }

        private void timerRepeatWord_Tick(object sender, EventArgs e)
        {
            var getInterval = context.RepeatWords!.Select(i => i.Minutes).FirstOrDefault();

            DateTime now = DateTime.Now;

            timerRepeatWord.Interval = 1000;

            if (getInterval != 0)
            {
                FrmEnglishWord frmEnglishWord = new FrmEnglishWord(lastDateTimeRepeatWord);
                //frmEnglishWord.timerMinutes.Enabled = true;

                timerRepeatWord.Interval = getInterval * 60000;

                frmEnglishWord.Execute();
                frmEnglishWord.Show();

                GetLastDateTimeRepeating();
            }
        }
        public DateTime GetLastDateTimeRepeating()
        {
            return lastDateTimeRepeatWord = DateTime.Now;
        }

        private void textBoxEventName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
