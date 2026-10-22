using AUTHORIZATION;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAUNCHER_FANBOT
{
    public partial class Menu : Form
    {
        #region VARIABLES
        private readonly EngineWork EngineWork = new EngineWork();

        private const string text_bot_1 = "BOT";
        private const string text_bot_2 = "BOT";
        private const string login = "LOGIN";
        private const string password = "PASSWORD";
        public string sect = "SETTING FAN-BOT";
        private const string sett = "SETTING_BOTS";
        private const string logs = "Logs";
        private readonly TextBox[] textBoxes_l;
        private readonly TextBox[] textBoxes_p;
        private readonly ComboBox[] comboBoxes;
        private readonly Button[] button_start;
        private readonly CheckBox[] checkBox_bots;
        private readonly CheckBox[] checkBox_save_data;
        private readonly CheckBox[] checkBox_load_data;
        private readonly RichTextBox[] richTextBoxes;
        private readonly TextBox[] textBox_cmds;
        private readonly Process[] processes_bots = new Process[5];
        private readonly bool[] bots_status = new bool[5];

        private static readonly string[] colors = new string[5];
        public string[] files_names = new string[4] { "wb.exe", "setting_launcher_fanbot.ini", "setting_bots.ini", "accounts.ini" };
        private readonly string auto_command = "auto_command.txt";

        /// <summary>
        /// Gets the current time.
        /// </summary>
        /// <returns>Current time (HH:mm:ss).</returns>
        private string TimeText() => $"{DateTime.Now:HH:mm:ss}";

        private bool check = false;
        private static byte servers;

        #endregion VARIABLES

#if DEBUG
        /// <summary>
        /// Collects all controls of the form and writes them to '__LANG.ini'.
        /// </summary>
        /// <param name="control_cont">Form.</param>
        /// <param name="name">Section name.</param>
        public void GET_CONTROLS_LANG(Control control_cont, string name)
        {
            try
            {
                File.Delete("__LANG.ini");
                EngineWork.GetAllControls(control_cont, new IniFile("__LANG.ini"), name, true);
            }
            catch (Exception er) { EngineWork.MSB_Error("GET_CONTROLS_LANG" + er); }
        }
#endif

        //Initialization
        public Menu()
        {
            InitializeComponent();
            Size = new Size(484, 410);

            textBoxes_l = new TextBox[] { textBox_l_1, textBox_l_2, textBox_l_3, textBox_l_4, textBox_l_5 };
            textBoxes_p = new TextBox[] { textBox_p_1, textBox_p_2, textBox_p_3, textBox_p_4, textBox_p_5 };
            comboBoxes = new ComboBox[] { comboBox1, comboBox2, comboBox3, comboBox4, comboBox5, comboBox_bots_server };
            button_start = new Button[] { button_start_1, button_start_2, button_start_3, button_start_4, button_start_5 };
            checkBox_bots = new CheckBox[] { checkBox_bot1s, checkBox_bot2s, checkBox_bot3s, checkBox_bot4s, checkBox_bot5s };
            checkBox_save_data = new CheckBox[] { checkBox_save_data_1, checkBox_save_data_2, checkBox_save_data_3, checkBox_save_data_4, checkBox_save_data_5 };
            checkBox_load_data = new CheckBox[] { checkBox_load_data_1, checkBox_load_data_2, checkBox_load_data_3, checkBox_load_data_4, checkBox_load_data_5 };
            richTextBoxes = new RichTextBox[] { richTextBox1, richTextBox2, richTextBox3, richTextBox4, richTextBox5 };
            textBox_cmds = new TextBox[] { textBox_cmd1, textBox_cmd2, textBox_cmd3, textBox_cmd4, textBox_cmd5, textBox_cmd_all };

#if DEBUG
            GET_CONTROLS_LANG(this, this.Name);
#endif

            comboBox_languages.SelectedIndex = 0;
            comboBox_text_colors.SelectedIndex = 0;
            GetFilesLanguage();
            LoadSettings();

            try
            {
                //Load the settings for wb.exe
                IniFile SettingsBots = new IniFile(files_names[2]);
                if (File.Exists(files_names[2]))
                {
                    //Friends
                    ignor_friends.Checked = SettingsBots.ReadString("wb_accept_friend_requests", sett) == "0";
                    ignor_friends_invite.Checked = SettingsBots.ReadString("wb_postpone_friend_requests", sett) == "1";

                    //Clan
                    ignor_clan.Checked = SettingsBots.ReadString("wb_accept_clan_invites", sett) == "0";
                    ignor_clan_invite.Checked = SettingsBots.ReadString("wb_postpone_clan_invites", sett) == "1";

                    //Room
                    no_exit_room.Checked = SettingsBots.ReadString("wb_leave_on_start", sett) == "0";
                    start_room_k.Checked = SettingsBots.ReadString("wb_auto_start", sett) != "0";

                    //Language
                    string g_language = SettingsBots.ReadString("g_language", sett);
                    rb_eu.Checked = g_language == "english";

                    //Auto_Command_Settings
                    if (SettingsBots.ReadString("AUTO_COMMAND", sett) != "")
                    {
                        textBox_nick.Text = SettingsBots.ReadString("AUTO_COMMAND", sett).Replace("follow", "").Replace(" ", "");
                        checkBox_autocmd.Checked = true;
                    }
                }
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[Menu -> Loading bot settings]"); }
        }

        /// <summary>
        /// On form close: saves the settings, then terminates the process and its threads.
        /// </summary>
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings(null, null);
            SettingsSave_settings_bots();
            Environment.Exit(0);
        }
        /// <summary>
        /// Switches the menu page
        /// (0 - menu,
        ///  1 - bot settings).
        /// </summary>
        /// <param name="id">Page ID.</param>
        private void ChangePage(byte id)
        {
            tabControl_main.Visible = false;
            panel_page_settings_bots.Visible = false;

            tabControl_main.Location = new Point(-2, 0);
            panel_page_settings_bots.Location = new Point(978, 0);

            if (id == 0)
            {
                tabControl_main.Visible = true;
                tabControl_main.Location = new Point(-2, 0);
                settings_back.Visible = false;
                settings_back.Location = new Point(488, 351);
            }
            else if (id == 1)
            {
                panel_page_settings_bots.Visible = true;
                panel_page_settings_bots.Location = new Point(-2, 0);
                tabControl_main.Location = new Point(978, 0);
                settings_back.Visible = true;
                settings_back.Location = new Point(10, 340);
            }
        }

        #region tabControl_main

        #region FORM_CONTROLS

        /// <summary>
        /// Resets the settings (deletes the files) and restarts the application.
        /// </summary>
        private void button_delete_setting_Click(object sender, EventArgs e)
        {
            File.Delete(files_names[1]);
            File.Delete(files_names[2]);
            Process.Start($"{Application.ProductName}.exe");
            Environment.Exit(0);
        }
        private void button_restart_start_Click(object sender, EventArgs e)
        {
            if (timer_restart.Enabled == true) return;

            timer_restart.Stop();
            if (comboBox_bots_server.SelectedIndex == -1)
            { EngineWork.MSB_Error("You must select a server first.."); return; }

            if (!checkBox_bots[0].Checked && !checkBox_bots[1].Checked && !checkBox_bots[2].Checked &&
                !checkBox_bots[3].Checked && !checkBox_bots[4].Checked && !checkBox_bots_all.Checked)
            { EngineWork.MSB_Error("You have not selected a bot.."); return; }

            if (radioButton_through_time.Checked) timer_restart.Interval = (int)(numericUpDown_sec.Value * 1000);
            else if (radioButton_off_proc.Checked) timer_restart.Interval = 5000;

            timer_restart.Start();
            panel_status_restart.BackColor = Color.Green;
            richlog_info_bots.Text += $"{TimeText()} [RESTART]: ON\n";

            comboBox_bots_server.Enabled = false;
        }
        private void button_restart_stop_Click(object sender, EventArgs e)
        {
            if (timer_restart.Enabled == false) return;

            timer_restart.Stop();
            richlog_info_bots.Text += $"{TimeText()} [RESTART]: OFF\n";
            panel_status_restart.BackColor = Color.Red;

            comboBox_bots_server.Enabled = true;
        }
        /// <summary>
        /// Starts all available bots.
        /// </summary>
        private void button_start_all_bots_Click(object sender, EventArgs e)
        {
            if (comboBox_bots_server.SelectedIndex == -1)
            { EngineWork.MSB_Error("You must select a server first.."); return; }

            if (!checkBox_bots[0].Checked && !checkBox_bots[1].Checked && !checkBox_bots[2].Checked &&
                !checkBox_bots[3].Checked && !checkBox_bots[4].Checked && !checkBox_bots_all.Checked)
            { EngineWork.MSB_Error("You have not selected a bot.."); return; }

            if (File.Exists(files_names[3]))
            {
                int n_bots = 0;
                IniFile accounts = new IniFile(files_names[3]);

                try
                {
                    servers = serverBox(comboBox_bots_server);
                    for (int i = 0; i < 5; i++)
                    {
                        if (checkBox_bots_all.Checked || checkBox_bots[i].Checked)
                        {
                            string tmp = $"{text_bot_2}{i + 1}-{servers}";
                            if (accounts.KeyExists(login, tmp) && accounts.KeyExists(password, tmp))
                            {
                                richlog_info_bots.Text += $"{TimeText()} [{text_bot_1}-{i + 1}]: START..\n";
                                textBoxes_l[i].Text = accounts.ReadString(login, tmp);
                                textBoxes_p[i].Text = accounts.ReadString(password, tmp);
                                comboBoxes[i].SelectedIndex = servers;
                                button_start_Click(button_start[i], e);
                                n_bots++;
                            }
                        }
                    }
                    label_int_bot.Text = n_bots.ToString();
                }
                catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[button_start_all_bots_Click]"); }
            }
        }
        /// <summary>
        /// Starts the bot that belongs to the clicked button.
        /// </summary>
        private void button_start_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    if (button == button_start[i])
                    {
                        richTextBoxes[i].Clear();

                        ComboBox tmp_comboBox = comboBoxes[i];
                        string tmp_login = textBoxes_l[i].Text;
                        string tmp_password = textBoxes_p[i].Text;
                        string tmp_bot = $"{text_bot_2}{i + 1}";
                        CheckBox tmp_checkBox = checkBox_save_data[i];
                        new Thread(delegate ()
                        {
                            Start_Aut(tmp_comboBox, tmp_login, tmp_password, button, tmp_bot, tmp_checkBox);
                        }).Start();
                    }
                }
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[button_start_Click]"); }
        }
        /// <summary>
        /// Deletes the data of a specific server and bot.
        /// </summary>
        private void button_del_server_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int tmp = 0;

            if (button == button_del_server_1) tmp = 0;
            else if (button == button_del_server_2) tmp = 1;
            else if (button == button_del_server_3) tmp = 2;
            else if (button == button_del_server_4) tmp = 3;
            else if (button == button_del_server_5) tmp = 4;

            DeleteDataServer($"{text_bot_2}{tmp}", comboBoxes[tmp]);
        }
        /// <summary>
        /// Deletes all data of a specific bot.
        /// </summary>
        private void button_del_bot_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int tmp = 0;

            if (File.Exists("MailRuAuthLog.log")) File.Delete("MailRuAuthLog.log");
            if (File.Exists("mailru-two-factor")) File.Delete("mailru-two-factor");

            if (button == button_del_bot_1) tmp = 1;
            else if (button == button_del_bot_2) tmp = 2;
            else if (button == button_del_bot_3) tmp = 3;
            else if (button == button_del_bot_4) tmp = 4;
            else if (button == button_del_bot_5) tmp = 5;

            DeleteAllData($"{text_bot_2}{tmp}");
        }
        /// <summary>
        /// Switches to the bot settings page.
        /// </summary>
        private void button_settings_bots_Click(object sender, EventArgs e) => ChangePage(1);
        /// <summary>
        /// Returns to page 0 (menu) and saves the bot settings.
        /// </summary>
        private void settings_back_Click(object sender, EventArgs e)
        {
            ChangePage(0);
            SettingsSave_settings_bots();
        }
        /// <summary>
        /// Background color of the log RichTextBoxes.
        /// </summary>
        private void button_color_console_Click(object sender, EventArgs e)
        {
            bool save_color = sender != null && e != null;
            if (save_color && colorDialog_main.ShowDialog() != DialogResult.OK) return;

            Color color = save_color ? colorDialog_main.Color : ColorTranslator.FromHtml(colors[0]);

            List<Control> controls = new List<Control>();
            EngineWork.GetAllControls_ForSettings(controls, this, richlog_info_bots.GetType());
            foreach (RichTextBox tmp_richTextBox in controls) tmp_richTextBox.BackColor = color;

            if (save_color) colors[0] = ColorTranslator.ToHtml(color);
        }
        /// <summary>
        /// Text color of the log RichTextBoxes.
        /// </summary>
        private void button_setting_font_Click(object sender, EventArgs e)
        {
            bool save_color = sender != null && e != null;
            if (save_color && colorDialog_main.ShowDialog() != DialogResult.OK) return;

            Color color = save_color ? colorDialog_main.Color : ColorTranslator.FromHtml(colors[1]);

            List<Control> controls = new List<Control>();
            EngineWork.GetAllControls_ForSettings(controls, this, richlog_info_bots.GetType());
            foreach (RichTextBox tmp_richTextBox in controls) tmp_richTextBox.ForeColor = color;

            if (save_color) colors[1] = ColorTranslator.ToHtml(color);
        }
        /// <summary>
        /// Form background color.
        /// </summary>
        private void button_color_fon_Click(object sender, EventArgs e)
        {
            bool save_color = sender != null && e != null;
            if (save_color && colorDialog_main.ShowDialog() != DialogResult.OK) return;

            Color color = save_color ? colorDialog_main.Color : ColorTranslator.FromHtml(colors[2]);
            BackColor = color;

            List<Control> controls = new List<Control>();
            EngineWork.GetAllControls_ForSettings(controls, this, page_bot_global_settings.GetType());
            foreach (TabPage tmp_tabpage in controls) tmp_tabpage.BackColor = color;

            if (save_color) colors[2] = ColorTranslator.ToHtml(color);
        }
        /// <summary>
        /// Background color of all buttons.
        /// </summary>
        private void button_colors_fon_Click(object sender, EventArgs e)
        {
            bool save_color = sender != null && e != null;
            if (save_color && colorDialog_main.ShowDialog() != DialogResult.OK) return;

            Color color = save_color ? colorDialog_main.Color : ColorTranslator.FromHtml(colors[3]);

            List<Control> controls = new List<Control>();
            EngineWork.GetAllControls_ForSettings(controls, this, button_colors_fon.GetType());
            foreach (Button tmp_button in controls) tmp_button.BackColor = color;

            if (save_color) colors[3] = ColorTranslator.ToHtml(color);
        }
        /// <summary>
        /// Text color of all buttons.
        /// </summary>
        private void button_colors_text_Click(object sender, EventArgs e)
        {
            bool save_color = sender != null && e != null;
            if (save_color && colorDialog_main.ShowDialog() != DialogResult.OK) return;

            Color color = save_color ? colorDialog_main.Color : ColorTranslator.FromHtml(colors[4]);

            List<Control> controls = new List<Control>();
            EngineWork.GetAllControls_ForSettings(controls, this, button_colors_fon.GetType());
            foreach (Button tmp_button in controls) tmp_button.ForeColor = color;

            if (save_color) colors[4] = ColorTranslator.ToHtml(color);
        }
        /// <summary>
        /// Clears the logs (*.log files).
        /// </summary>
        private void button_clear_logs_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(logs))
                {
                    string[] files = Directory.GetFiles(logs, "*.log");
                    int error = 0;
                    foreach (string file in files)
                    {
                        try { File.Delete(Path.GetFullPath(file)); }
                        catch { error++; }
                    }
                    EngineWork.MSB_Information($"Total files: {files.Length}\n\nDeleted: {files.Length - error}\nErrors: {error}", "Deleting logs..");
                }
                else EngineWork.MSB_Information($"No logs found!", "Deleting logs..");
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[button_clear_logs]"); }
        }


        /// <summary>
        /// Timer that restarts the bots.
        /// </summary>
        private void timer_restart_Tick(object sender, EventArgs e)
        {
            byte server = serverBox(comboBox_bots_server);
            if (server == 8) return;

            IniFile accounts = new IniFile(files_names[3]);
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (checkBox_bots[i - 1].Checked && !bots_status[i - 1])
                    {
                        if (radioButton_through_time.Checked || (radioButton_off_proc.Checked && processes_bots[i - 1] != null && processes_bots[i - 1].HasExited))
                        {
                            string tmp = $"{text_bot_2}{i}-{server}";
                            if (accounts.KeyExists(login, tmp) && accounts.KeyExists(password, tmp))
                            {
                                richlog_info_bots.Text += $"{TimeText()} [{text_bot_1}-{i}]: START..\n";

                                ComboBox tmp_comboBox = comboBox_bots_server;
                                Button button = button_start[i - 1];
                                string tmp_bot = $"{text_bot_2}{i}";
                                CheckBox tmp_checkBox_save_data = checkBox_save_data[i - 1];
                                bots_status[i - 1] = true;
                                new Thread(delegate ()
                                {
                                    Start_Aut(tmp_comboBox, accounts.ReadString(login, tmp), accounts.ReadString(password, tmp),
                                              button, tmp_bot, tmp_checkBox_save_data);
                                }).Start();
                            }
                        }
                    }
                }
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[timer_start_bots_Tick]"); }
        }
        /// <summary>
        /// Timer that checks the saved bot data (login\password).
        /// </summary>
        private void timer_check_data_Tick(object sender, EventArgs e)
        {
            if (File.Exists(files_names[3]))
            {
                IniFile accounts = new IniFile(files_names[3]);
                byte server = serverBox(comboBox_bots_server);
                if (server == 8)
                {
                    for (int i = 0; i < checkBox_bots.Length; i++)
                    {
                        checkBox_bots[i].Enabled = false;
                        checkBox_bots[i].Checked = false;
                    }
                    checkBox_bots_all.Enabled = false;
                    checkBox_bots_all.Checked = false;
                    return;
                }

                try
                {
                    for (int i = 0; i < checkBox_bots.Length; i++)
                    {
                        string tmp = $"{text_bot_2}{i + 1}-{server}";
                        if (accounts.KeyExists(login, tmp) && accounts.KeyExists(password, tmp))
                        {
                            checkBox_bots[i].Enabled = true;
                            checkBox_bots_all.Enabled = true;
                        }
                        else checkBox_bots[i].Enabled = false;
                    }
                }
                catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[timer_check_data_Tick]"); timer_check_data.Stop(); }
            }
        }


        /// <summary>
        /// Server selection; loads the saved data, if any.
        /// </summary>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;

            for (int i = 0; i < 5; i++) if (comboBox == comboBoxes[i]) 
                    LoadAccount(comboBox, $"{text_bot_2}{i + 1}", checkBox_load_data[i], textBoxes_l[i], textBoxes_p[i]);
        }
        private void comboBox_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = true;
        /// <summary>
        /// Selects a translation file and loads it.
        /// </summary>
        private void comboBox_languages_SelectedIndexChanged(object sender, EventArgs e) => EngineWork.Translation(this, !comboBox_languages.Text.Contains("default"), comboBox_languages.Text, Name);
        /// <summary>
        /// Standard start mode: groupBox_bot_N.Enabled = standart_start.Checked.
        /// </summary>
        private void standart_start_CheckedChanged(object sender, EventArgs e)
        {
            bool tmp = standart_start.Checked;
            groupBox_pin.Enabled = radioButton_pinvoke.Checked;
            groupBox_bot_1.Enabled = tmp;
            groupBox_bot_2.Enabled = tmp;
            groupBox_bot_3.Enabled = tmp;
            groupBox_bot_4.Enabled = tmp;
            groupBox_bot_5.Enabled = tmp;
        }

        /// <summary>
        /// Sets UseSystemPasswordChar for the <c>login</c> fields.
        /// </summary>
        private void checkBox_crt_login_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) textBoxes_l[i].UseSystemPasswordChar = checkBox_crt_login.Checked;
        }
        /// <summary>
        /// Sets UseSystemPasswordChar for the <c>password</c> fields.
        /// </summary>
        private void checkBox_crt_pass_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) textBoxes_p[i].UseSystemPasswordChar = checkBox_crt_pass.Checked;
        }

        /// <summary>
        /// In the <c>Direct</c> start mode the cmd text color selection is disabled;
        /// in the <c>Console</c> start mode it is enabled.
        /// </summary>
        private void comboBox_text_colors_Enabled_CheckedChanged(object sender, EventArgs e) => comboBox_text_colors.Enabled = radioButton_start_classic_plus.Checked;
        /// <summary>
        /// Selects all available bots.
        /// </summary>
        private void checkBox_bots_all_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkBox_bots.Length; i++) if (checkBox_bots[i].Enabled == true) checkBox_bots[i].Checked = true;
        }

        private void label_creaters_Click(object sender, EventArgs e)
        {
            EngineWork.MSB_Information(
            $"\n[0xLaileb]\n" +
            $"\nDmitry Bard [Zrefer]\n" +
            $"\nDmitry Klimenkov [DeKoSiK]\n", label_creaters.Text);
        }
        private void label_link_github_Click(object sender, EventArgs e) => Process.Start("https://github.com/0xLaileb/Fan-Bots");
        /// <summary>
        /// Clears the text of the corresponding RichTextBox.
        /// </summary>
        private void pictureBox_clear_log_Click(object sender, EventArgs e)
        {
            PictureBox picturebox = sender as PictureBox;

            if (picturebox == pictureBox_clear_log_1) richTextBoxes[0].Clear();
            else if (picturebox == pictureBox_clear_log_2) richTextBoxes[1].Clear();
            else if (picturebox == pictureBox_clear_log_3) richTextBoxes[2].Clear();
            else if (picturebox == pictureBox_clear_log_4) richTextBoxes[3].Clear();
            else if (picturebox == pictureBox_clear_log_5) richTextBoxes[4].Clear();
            else if (picturebox == pictureBox_clear_log_all) richlog_info_bots.Clear();
        }

        /// <summary>
        /// When the user leaves the <c>GLOBAL SETTINGS</c> tab, saves the settings.
        /// </summary>
        private void tabControl_main_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            if (tabControl_main.SelectedTab == tabControl_main.TabPages[6]) SaveSettings(null, null);
        }
        /// <summary>
        /// When the user opens the BOT-S tab, starts the data check.
        /// </summary>
        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_main.SelectedTab == tabControl_main.TabPages[5] && timer_check_data.Enabled == false) timer_check_data.Start();
        }
        /// <summary>
        /// Changes the form opacity.
        /// </summary>
        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label_n.Text = $"{hScrollBar_transparency.Value}%";
            Opacity = hScrollBar_transparency.Value * 0.01;
        }

        /// <summary>
        /// Sends a command to a specific bot (process).
        /// </summary>
        private void textBox_cmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox txb = (TextBox)sender;
                if (string.IsNullOrEmpty(txb.Text)) return;

                if (txb == textBox_cmd1) WriteCmd(richTextBoxes[0], textBox_cmds[0], processes_bots[0], true);
                else if (txb == textBox_cmd2) WriteCmd(richTextBoxes[1], textBox_cmds[1], processes_bots[1], true);
                else if (txb == textBox_cmd3) WriteCmd(richTextBoxes[2], textBox_cmds[2], processes_bots[2], true);
                else if (txb == textBox_cmd4) WriteCmd(richTextBoxes[3], textBox_cmds[3], processes_bots[3], true);
                else if (txb == textBox_cmd5) WriteCmd(richTextBoxes[4], textBox_cmds[4], processes_bots[4], true);
                else if (txb == textBox_cmd_all) WriteCmd_All("all");
            }
        }

        #endregion FORM_CONTROLS

        #region OTHER

        /// <summary>
        /// Gets the server ID.
        /// </summary>
        /// <returns>Server ID.</returns>
        private byte serverBox(ComboBox c) => c.SelectedIndex != -1 ? (byte)c.SelectedIndex : (byte)8;

        /// <summary>
        /// Saves the account data.
        /// </summary>
        /// <param name="lg">Login.</param>
        /// <param name="ps">Password.</param>
        /// <param name="comboBox">comboBox that provides the selected server ID.</param>
        /// <param name="bot">Bot.</param>
        /// <param name="checkBox">Whether the data should be saved / loaded.</param>
        private void SaveAccount(string lg, string ps, ComboBox comboBox, string bot, CheckBox checkBox)
        {
            if (!checkBox.Checked) return;

            byte server = 0;
            comboBox.Invoke((MethodInvoker)delegate { server = serverBox(comboBox); });
            IniFile account = new IniFile(files_names[3]);
            account.Write(login, lg, $"{bot}-{server}");
            account.Write(password, ps, $"{bot}-{server}");
        }
        /// <summary>
        /// Loads the account data.
        /// </summary>
        /// <param name="comboBox">comboBox that provides the selected server ID.</param>
        /// <param name="bot">Bot.</param>
        /// <param name="checkBox">Whether the data should be saved / loaded.</param>
        /// <param name="txtl">TextBox that receives the saved login.</param>
        /// <param name="txtp">TextBox that receives the saved password.</param>
        private void LoadAccount(ComboBox comboBox, string bot, CheckBox checkBox, TextBox txtl, TextBox txtp)
        {
            if (!checkBox.Checked) return;

            byte server = serverBox(comboBox);
            IniFile account = new IniFile(files_names[3]);
            txtl.Text = account.ReadString(login, $"{bot}-{server}");
            txtp.Text = account.ReadString(password, $"{bot}-{server}");
        }

        /// <summary>
        /// Deletes the account data of a specific server and bot, and also deletes <c>mailru-two-factor</c>.
        /// </summary>
        /// <param name="bot">Bot.</param>
        /// <param name="comboBox">comboBox that provides the selected server ID.</param>
        private void DeleteDataServer(string bot, ComboBox comboBox)
        {
            try
            {
                new IniFile(files_names[3]).DeleteSection($"{bot}-{serverBox(comboBox)}");
                if (File.Exists("mailru-two-factor")) File.Delete("mailru-two-factor");

                EngineWork.MSB_Information("Data deleted!", "Deleting data..");
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[DeleteDataServer]"); }
        }
        /// <summary>
        /// Deletes all account data of a specific bot.
        /// </summary>
        /// <param name="bot">Bot.</param>
        private void DeleteAllData(string bot)
        {
            try
            {
                IniFile iniFile = new IniFile(files_names[3]);
                for (int i = 0; i < comboBox1.Items.Count; i++)
                {
                    iniFile.DeleteSection($"{bot}-{i}");
                }

                EngineWork.MSB_Information("Data deleted!", "Deleting data..");
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[DeleteAllData]"); }
        }

        /// <summary>
        /// Returns if the bot process is already running; otherwise starts a new one.
        /// </summary>
        /// <param name="argm">Start arguments.</param>
        /// <param name="bot">Bot.</param>
        /// <param name="id_bot">Bot ID.</param>
        private void CheckMyProc(string argm, string bot, int id_bot)
        {
            if (processes_bots[id_bot] != null && !processes_bots[id_bot].HasExited) return;

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = bot,
                Arguments = argm,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                StandardOutputEncoding = Encoding.UTF8
            };
            processes_bots[id_bot] = new Process { StartInfo = startInfo };

            Process proc = processes_bots[id_bot];
            proc.OutputDataReceived += ConsoleOutputHandler;
            proc.Start();
            proc.BeginOutputReadLine();
        }
        /// <summary>
        /// Receives the process output and writes it to the corresponding RichTextBox.
        /// </summary>
        private void ConsoleOutputHandler(object sendingProcess, DataReceivedEventArgs Data)
        {
            IniFile FollowBoss = new IniFile(files_names[2]);
            Process proc = (Process)sendingProcess;

            try
            {
                int BotId = -1;

                for (int x = 0; x < processes_bots.Length; x++)
                {
                    if (processes_bots[x] != null &&
                       !processes_bots[x].HasExited &&
                        processes_bots[x].Id == proc.Id)
                    {
                        BotId = x; break;
                    }
                }
                if (BotId == -1) return;

                RichTextBox rich = richTextBoxes[BotId];

                rich?.Invoke((MethodInvoker)delegate
                {
                    try
                    {
                        if (checkBox_save_logs.Checked) SaveLogs($"ID{processes_bots[BotId].Id}_bot_{BotId + 1}", Data.Data);

                        rich.AppendText($"{Data.Data}\n"
                            .Replace("CMD#", ">")
                            .Replace("[0m", string.Empty)
                            .Replace("[1;31m", string.Empty)
                            .Replace("[1;32m", string.Empty)
                            .Replace("[1m", string.Empty)
                            .Replace("[32;1m", string.Empty));
                        rich.SelectionStart = rich.TextLength;
                        rich.ScrollToCaret();

                        if (!check && Data.Data.Contains("<_________________________________________________________>") && File.Exists(auto_command))
                        {
                            new Thread(delegate ()
                            {
                                string[] AutoCommands = File.ReadAllLines(auto_command);
                                foreach (string Command in AutoCommands)
                                {
                                    Thread.Sleep(5000);
                                    if (!string.IsNullOrEmpty(Command) && !Command.Contains(Encoding.UTF8.GetString(new byte[] { 0x20, 0x73, 0x61, 0x79 })))
                                    {
                                        WriteCmd(rich, null, processes_bots[BotId], true, Command);
                                    }
                                }
                                check = true;
                            }).Start();

                        }
                    }
                    catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[[rich?.Invoke]"); }
                });
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[ConsoleOutputHandler]"); }
        }

        /// <summary>
        /// Sends a command to a specific process.
        /// </summary>
        /// <param name="richTextBox">richTextBox that receives the execution result.</param>
        /// <param name="textBox">textBox that holds the command text.</param>
        /// <param name="proc">Process that receives the command.</param>
        /// <param name="delete_cmd">Whether to clear the command textBox.</param>
        /// <param name="text">Command text.</param>
        private void WriteCmd(RichTextBox richTextBox, TextBox textBox, Process proc, bool delete_cmd, string text = "")
        {
            try
            {
                if (proc == null || proc.HasExited) return;
                if (textBox != null)
                {
                    proc.StandardInput.WriteLine(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(textBox.Text.Replace(Environment.NewLine, null))));
                    if (delete_cmd) textBox.Clear();
                }
                else proc.StandardInput.WriteLine(Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(text.Replace(Environment.NewLine, null))));
            }
            catch (Exception er) { richTextBox.Text += $"[WriteCmd]: {er}\n"; }
        }
        /// <summary>
        /// Sends one command to all available bots.
        /// </summary>
        /// <param name="bot">Bot.</param>
        private void WriteCmd_All(string bot)
        {
            if (bot != "all") SendCmd(Convert.ToInt32(bot));
            else for (int i = 1; i <= 5; i++) SendCmd(i);

            void SendCmd(int BotNum)
            {
                try
                {
                    richlog_info_bots.Invoke((MethodInvoker)delegate
                    {
                        if (processes_bots[BotNum - 1] != null && !processes_bots[BotNum - 1].HasExited)
                        {
                            richlog_info_bots.Text += $"{TimeText()} [{text_bot_1}-{BotNum}]: Sending command '{textBox_cmd_all.Text}'\n";
                            WriteCmd(richTextBoxes[BotNum - 1], textBox_cmd_all, processes_bots[BotNum - 1], false);
                        }
                    });
                }
                catch (Exception er) { richlog_info_bots.Text += $"{TimeText()} [{text_bot_1}-{BotNum}]: Error: {er}\n"; }
            }
            textBox_cmd_all.Clear();
        }

        /// <summary>
        /// Saves the logs of a specific bot.
        /// </summary>
        /// <param name="bot">Bot.</param>
        /// <param name="text">Log.</param>
        private void SaveLogs(string bot, string text)
        {
            string tmp_logs = "Logs";
            string tmp_file = $"{tmp_logs}\\{bot}.log";

            try
            {
                if (!Directory.Exists(tmp_logs)) Directory.CreateDirectory(tmp_logs);
                File.AppendAllText(tmp_file, $"[{TimeText()}]: {text}\n");
            }
            catch { }
        }

        /// <summary>
        /// Creates and starts the bot process.
        /// </summary>
        /// <param name="id_bot">Bot ID.</param>
        /// <param name="token">Account token.</param>
        /// <param name="id">Account ID.</param>
        /// <param name="server">Server.</param>
        private void OpenCMD(int id_bot, string token, string id, string server)
        {
            try
            {
                string tmp_file_server_cfg = $@"cfg\server\{server}.cfg";

                if (radioButton_levak_keys.Checked)
                    File.WriteAllText(tmp_file_server_cfg, EngineWork.GET($@"https://raw.githubusercontent.com/Levak/warfacebot/master/cfg/server/{server}.cfg"));
            }
            catch (Exception er) { EngineWork.MSB_Error($"Your internet connection may be down, or the key retrieval mode is unavailable!\n\n{er}", "[GetKey]"); return;  }

            try
            {
                string bots = files_names[0];
                string start = string.Empty;

                if (radioButton_start_classic_plus.Checked)
                {
                    string color = string.Empty;
                    comboBox_text_colors.Invoke((MethodInvoker)delegate { color = comboBox_text_colors.SelectedIndex.ToString(); });
                    if (color == "0") color = EngineWork.random.Next(0, comboBox_text_colors.Items.Count).ToString();

                    bots = "cmd";
                    start = $"/c chcp 65001 & color {color} & {files_names[0]} -t {token} -i {id} -f ./cfg/server/{server}.cfg & pause";
                }
                else if (radioButton_start_classic.Checked) start = $"-t {token} -i {id} -f ./cfg/server/{server}.cfg";

                if (standart_start.Checked)
                {
                    CheckMyProc(start, bots, id_bot);
                }
                else if (simple_start.Checked)
                {
                    if (processes_bots[id_bot] != null && !processes_bots[id_bot].HasExited) richlog_info_bots.Text += $"{TimeText()} [{text_bot_1}-{id_bot + 1}]: RESTART..\n";
                    ProcessStartInfo psi = new ProcessStartInfo(bots, start);
                    processes_bots[id_bot] = new Process { StartInfo = psi };
                    processes_bots[id_bot].Start();
                }
                else if (radioButton_pinvoke.Checked)
                {
                    if (pinvoke_no_svor.Checked) pInvokeProcessStart.StartProcessNoActivate($"{bots} {start}", 4);
                    else if (pinvoke_svor.Checked) pInvokeProcessStart.StartProcessNoActivate($"{bots} {start}", 7);
                    else if (fon_start.Checked) pInvokeProcessStart.StartProcessNoActivate($"{bots} {start}", 0);
                }
                bots_status[id_bot] = false;
            }
            catch (Exception er) { EngineWork.MSB_Error($"Failed to start CMD!\n{er}", "[OpenCMD]"); bots_status[id_bot] = false; }
        }
        /// <summary>
        /// Account authorization.
        /// </summary>
        /// <param name="comboBox">Server.</param>
        /// <param name="login">Login.</param>
        /// <param name="password">Password.</param>
        /// <param name="button">Bot button.</param>
        /// <param name="bot">Bot.</param>
        /// <param name="checkBox">Whether to save the account data after a successful authorization.</param>
        private void Start_Aut(ComboBox comboBox, string login, string password, Button button, string bot, CheckBox checkBox)
        {
            int tmp = 0; comboBox.Invoke((MethodInvoker)delegate { tmp = comboBox.SelectedIndex; });
            if (tmp == -1)
            { EngineWork.MSB_Error("You must select a server first.."); return; }

            if (login == "" && password == "")
            { EngineWork.MSB_Error("The login and password fields must not be empty."); return; }

            int id_bot = Convert.ToInt32(bot.Replace("BOT", string.Empty)) - 1;
            try
            {
                byte sb = 0;
                comboBox.Invoke((MethodInvoker)delegate
                {
                    comboBox.Enabled = false;
                    sb = (byte)(serverBox(comboBox) + 1);
                });

                button.Invoke((MethodInvoker)delegate { button.Text = "LOG IN"; });
                string[] check = { };
                if (sb == 4 || sb == 5 || sb == 6 || sb == 7)
                {
                    byte server = 0;
                    if (sb == 4) server = 0;
                    else if (sb == 5) server = 1;
                    else if (sb == 6) server = 2;
                    else if (sb == 7) server = 3;

                    check = new MailRu().AuthMailRu(login, password, button, server);
                }
                else if (sb == 1 || sb == 2) check = new MyCom().AuthMyCom(login, password, sb);
                else if (sb == 3) check = new GoPlay().AuthGoPlay(login, password);

                if (check[0] == "true" && check[0] != null)
                {
                    if (checkBox.Checked) SaveAccount(login, password, comboBox, bot, checkBox);

                    string serverBox_cfg(ComboBox c)
                    {
                        int SelectedIndex = 0;
                        comboBox.Invoke((MethodInvoker)delegate { SelectedIndex = c.SelectedIndex; });
                        if (SelectedIndex == -1) return "none";
                        if (SelectedIndex == 0) return "eu";
                        if (SelectedIndex == 1) return "na";
                        if (SelectedIndex == 2) return "vn";
                        if (SelectedIndex == 3) return "ru-alpha";
                        if (SelectedIndex == 4) return "ru-bravo";
                        if (SelectedIndex == 5) return "ru-charlie";
                        if (SelectedIndex == 6) return "ru-pts";
                        return "none";
                    }

                    OpenCMD(id_bot, check[2], check[1], serverBox_cfg(comboBox));
                }
                else EngineWork.MSB_Error(check[1], "[Authorization]"); 

                comboBox.Invoke((MethodInvoker)delegate { comboBox.Enabled = true; });
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[Start_Aut]"); bots_status[id_bot] = false; }
        }

        /// <summary>
        /// Gets the translation files.
        /// </summary>
        private void GetFilesLanguage()
        {
            foreach (string file in Directory.GetFiles("language")) comboBox_languages.Items.Add(file);
        }
        /// <summary>
        /// Saves the launcher settings.
        /// </summary>
        private void SaveSettings(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(files_names[1])) File.Delete(files_names[1]);
                IniFile settings_menu = new IniFile(files_names[1]);

                //Keys
                settings_menu.Write(radioButton_levak_keys.Name, radioButton_levak_keys.Checked.ToString(), sect);
                settings_menu.Write(radioButton_my_keys.Name, radioButton_my_keys.Checked.ToString(), sect);

                //Start mode
                settings_menu.Write(radioButton_start_classic.Name, radioButton_start_classic.Checked.ToString(), sect);
                settings_menu.Write(radioButton_start_classic_plus.Name, radioButton_start_classic_plus.Checked.ToString(), sect);

                //Hide login \ password
                settings_menu.Write(checkBox_crt_pass.Name, checkBox_crt_pass.Checked.ToString(), sect);
                settings_menu.Write(checkBox_crt_login.Name, checkBox_crt_login.Checked.ToString(), sect);

                //Load data, Save data
                for (int i = 0; i < 5; i++)
                {
                    settings_menu.Write(checkBox_load_data[i].Name, checkBox_load_data[i].Checked.ToString(), sect);
                    settings_menu.Write(checkBox_save_data[i].Name, checkBox_save_data[i].Checked.ToString(), sect);
                }

                //Restart
                settings_menu.Write(radioButton_through_time.Name, radioButton_through_time.Checked.ToString(), sect);
                settings_menu.Write(radioButton_off_proc.Name, radioButton_off_proc.Checked.ToString(), sect);

                //Window start mode
                settings_menu.Write(standart_start.Name, standart_start.Checked.ToString(), sect);
                settings_menu.Write(simple_start.Name, simple_start.Checked.ToString(), sect);
                settings_menu.Write(radioButton_pinvoke.Name, radioButton_pinvoke.Checked.ToString(), sect);

                //PinVoke
                settings_menu.Write(pinvoke_svor.Name, pinvoke_svor.Checked.ToString(), sect);
                settings_menu.Write(pinvoke_no_svor.Name, pinvoke_no_svor.Checked.ToString(), sect);
                settings_menu.Write(fon_start.Name, fon_start.Checked.ToString(), sect);

                //Language
                if (comboBox_languages.SelectedIndex != -1) settings_menu.Write(comboBox_languages.Name, comboBox_languages.Text, sect);

                //Console text color
                if (comboBox_text_colors.SelectedIndex != -1) settings_menu.Write(comboBox_text_colors.Name, comboBox_text_colors.SelectedIndex.ToString(), sect);

                //Logs
                settings_menu.Write(checkBox_save_logs.Name, checkBox_save_logs.Checked.ToString(), sect);

                //Opacity
                if (hScrollBar_transparency.Value > 10) settings_menu.Write(hScrollBar_transparency.Name, hScrollBar_transparency.Value.ToString(), sect);

                //Colors
                for (int i = 0; i < colors.Length; i++) if (!string.IsNullOrWhiteSpace(colors[i])) settings_menu.Write($"colors_{i}", colors[i], sect);
            }
            catch (Exception er) { EngineWork.MSB_Error($"Failed to save the settings!\n{er}", "[SaveSettings]"); }
        }
        /// <summary>
        /// Loads the launcher settings.
        /// </summary>
        private void LoadSettings()
        {
            try
            {
                if (File.Exists(files_names[1]))
                {
                    IniFile settings_menu = new IniFile(files_names[1]);
                    //Keys
                    radioButton_levak_keys.Checked = settings_menu.ReadBool(radioButton_levak_keys.Name, sect);
                    radioButton_my_keys.Checked = settings_menu.ReadBool(radioButton_my_keys.Name, sect);

                    //Start mode
                    radioButton_start_classic.Checked = settings_menu.ReadBool(radioButton_start_classic.Name, sect);
                    radioButton_start_classic_plus.Checked = settings_menu.ReadBool(radioButton_start_classic_plus.Name, sect);

                    //Hide login/password
                    checkBox_crt_pass.Checked = settings_menu.ReadBool(checkBox_crt_pass.Name, sect);
                    checkBox_crt_login.Checked = settings_menu.ReadBool(checkBox_crt_login.Name, sect);

                    checkBox_crt_login_Click(null, null);
                    checkBox_crt_pass_Click(null, null);

                    //Load data, Save data
                    for (int i = 0; i < 5; i++)
                    {
                        checkBox_load_data[i].Checked = settings_menu.ReadBool(checkBox_load_data[i].Name, sect);
                        checkBox_save_data[i].Checked = settings_menu.ReadBool(checkBox_save_data[i].Name, sect);
                    }

                    //Restart
                    radioButton_through_time.Checked = settings_menu.ReadBool(radioButton_through_time.Name, sect);
                    radioButton_off_proc.Checked = settings_menu.ReadBool(radioButton_off_proc.Name, sect);

                    //Window start mode
                    standart_start.Checked = settings_menu.ReadBool(standart_start.Name, sect);
                    simple_start.Checked = settings_menu.ReadBool(simple_start.Name, sect);
                    radioButton_pinvoke.Checked = settings_menu.ReadBool(radioButton_pinvoke.Name, sect);

                    //Pinvoke mode
                    pinvoke_svor.Checked = settings_menu.ReadBool(pinvoke_svor.Name, sect);
                    pinvoke_no_svor.Checked = settings_menu.ReadBool(pinvoke_no_svor.Name, sect);
                    fon_start.Checked = settings_menu.ReadBool(fon_start.Name, sect);

                    //Language
                    string LANGUAGE = settings_menu.ReadString(comboBox_languages.Name, sect);
                    if (LANGUAGE != "default (english)")
                    {
                        comboBox_languages.Text = LANGUAGE;
                        EngineWork.Translation(this, true, LANGUAGE, Name);
                    }
                    LoadPrms();

                    //Console text color
                    string tmp_comboBox_text_colors = settings_menu.ReadString(comboBox_text_colors.Name, sect);
                    comboBox_text_colors.SelectedIndex = Convert.ToInt32(!string.IsNullOrWhiteSpace(tmp_comboBox_text_colors) ? tmp_comboBox_text_colors : "0");

                    //Logs
                    checkBox_save_logs.Checked = settings_menu.ReadBool(checkBox_save_logs.Name, sect);

                    //Opacity
                    string VISIBILITY = settings_menu.ReadString(hScrollBar_transparency.Name, sect);
                    if (VISIBILITY != "" && Convert.ToInt32(VISIBILITY) >= 10) hScrollBar_transparency.Value = Convert.ToInt32(VISIBILITY);

                    //Colors
                    for (int i = 0; i < colors.Length; i++)
                    {
                        string tmp = settings_menu.ReadString($"colors_{i}", sect);
                        if (!string.IsNullOrWhiteSpace(tmp))
                        {
                            colors[i] = tmp;
                            switch (i)
                            {
                                case 0: button_color_console_Click(null, null); break;
                                case 1: button_setting_font_Click(null, null); break;
                                case 2: button_color_fon_Click(null, null); break;
                                case 3: button_colors_fon_Click(null, null); break;
                                case 4: button_colors_text_Click(null, null); break;
                            }
                        }
                    }
                }
                else SaveSettings(null, null);

                label_ver.Text = $"v{Application.ProductVersion}";
            }
            catch (Exception er) { EngineWork.MSB_Error($"Failed to load the launcher settings!\n{er}", "[LoadSettings]"); SaveSettings(null, null); }

            try
            {
                IniFile wb_settings = new IniFile(files_names[2]);
                if (!File.Exists(files_names[2]))
                {
                    //Default settings
                    wb_settings.Write("wb_accept_friend_requests", "1", sett);
                    wb_settings.Write("wb_postpone_friend_requests", "0", sett);
                    wb_settings.Write("wb_accept_clan_invites", "1", sett);
                    wb_settings.Write("wb_postpone_clan_invites", "0", sett);
                    wb_settings.Write("wb_leave_on_start", "1", sett);
                    wb_settings.Write("wb_auto_start", "1", sett);
                    wb_settings.Write("g_language", "english", sett);
                }
            }
            catch (Exception er) { EngineWork.MSB_Error($"Failed to load the bot settings!\n{er}", "[LoadSettings]"); }

            if (!File.Exists(auto_command)) File.Create(auto_command);
        }
        /// <summary>
        /// Loads the parameters (.Text) of the controls.
        /// </summary>
        public void LoadPrms()
        {
            try
            {
                EngineWork.TextBoxWatermarkExtensionMethod.SetWatermark(textBox_auto_command, EngineWork.prms[0]);
                EngineWork.TextBoxWatermarkExtensionMethod.SetWatermark(textBox_nick, EngineWork.prms[1]);
                foreach (TextBox textbox in textBoxes_l) EngineWork.TextBoxWatermarkExtensionMethod.SetWatermark(textbox, EngineWork.prms[2]);
                foreach (TextBox textbox in textBoxes_p) EngineWork.TextBoxWatermarkExtensionMethod.SetWatermark(textbox, EngineWork.prms[3]);
                foreach (TextBox textbox in textBox_cmds) EngineWork.TextBoxWatermarkExtensionMethod.SetWatermark(textbox, EngineWork.prms[4]);
                foreach (ComboBox combobox in comboBoxes) for (int a = 0, b = 5; a < combobox.Items.Count; a++, b++) combobox.Items[a] = EngineWork.prms[b];
                for (int a = 0, b = 12; a < comboBox_text_colors.Items.Count; a++, b++) comboBox_text_colors.Items[a] = EngineWork.prms[b];
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[LoadPrms]"); }
        }

        #endregion OTHER

        #endregion tabControl_main

        #region panel_page_settings_bots

        private int line = 0;
        /// <summary>
        /// Deletes the automatic commands.
        /// </summary>
        private void pictureBox_clear_command_Click(object sender, EventArgs e)
        {
            File.WriteAllText(auto_command, string.Empty);
            EngineWork.MSB_Information("Automatic commands deleted!", "Automatic commands");
        }
        /// <summary>
        /// Adds a command to the automatic commands.
        /// </summary>
        private void pictureBox_add_command_Click(object sender, EventArgs e)
        {
            line++;
            if (textBox_auto_command.Text != null)
            {
                File.AppendAllText(auto_command, $"{textBox_auto_command.Text}\n");
                EngineWork.MSB_Information($"{textBox_auto_command.Text}\nID: {line}", "Automatic commands");
            }
        }
        /// <summary>
        /// Saves the bot settings.
        /// </summary>
        private void SettingsSave_settings_bots()
        {
            try
            {
                IniFile setting_bots = new IniFile(files_names[2]);

                setting_bots.Write("wb_accept_friend_requests", ignor_friends.Checked ? "0" : "1", sett);
                setting_bots.Write("wb_postpone_friend_requests", ignor_friends_invite.Checked ? "1" : "0", sett);
                setting_bots.Write("wb_accept_clan_invites", ignor_clan.Checked ? "0" : "1", sett);
                setting_bots.Write("wb_postpone_clan_invites", ignor_clan_invite.Checked ? "1" : "0", sett);
                setting_bots.Write("wb_leave_on_start", no_exit_room.Checked ? "0" : "1", sett);
                setting_bots.Write("wb_auto_start", start_room_k.Checked ? "1" : "0", sett);

                if (!rb_my.Checked) setting_bots.Write("g_language", "english", sett);

                if (checkBox_autocmd.Checked)
                {
                    if (textBox_nick.Text != "" || textBox_nick.Text != " ") setting_bots.Write("AUTO_COMMAND", $"follow {textBox_nick.Text}", sett);
                    else if (setting_bots.KeyExists("AUTO_COMMAND", sett)) setting_bots.DeleteKey("AUTO_COMMAND", sett);
                }
                else setting_bots.DeleteKey("AUTO_COMMAND", sett);
            }
            catch (Exception er) { EngineWork.MSB_Error(er.ToString(), "[SettingsSave_settings_bots]"); }
        }

        #endregion panel_page_settings_bots
    }
}
