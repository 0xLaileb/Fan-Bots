using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace START
{
    public partial class One_Message : Form
    {
        #region Variables
        private string no_ok = "You did not accept the terms, so you cannot use Fan-Bot's\n(you can restart Fan-Bot's and change your decision)";
        private byte g_id = 0;
        private int timer_sec = 30;
        private readonly Random random = new Random();

        private readonly List<Color> colors = new List<Color>() { Color.Green, Color.Red, Color.Purple, Color.Coral };
        #endregion

        //Initialization
        public One_Message()
        {
            InitializeComponent();
            Size = new Size(478, 376);
            richTextBox_info.ReadOnly = true;
            richTextBox_use_conditions.ReadOnly = true;
        }

        /// <summary>
        /// Terminates this process and its threads.
        /// </summary>
        private void Exit(object sender, EventArgs e) => Environment.Exit(0);

        /// <summary>
        /// Switches the menu page
        /// (0 - information page,
        ///  1 - terms of use,
        ///  2 - important information and agreement).
        /// </summary>
        /// <param name="id">Page ID.</param>
        private void ChangePage(byte id)
        {
            g_id = id;
            timer_check.Stop();
            foreach (Panel panel in Controls) panel.Visible = false;

            Point point = new Point(0, 0);
            if (id == 0)
            {
                panel_page_0.Location = point;
                panel_page_0.Visible = true;
                return;
            }
            else if (id == 1)
            {
                panel_page_1.Location = point;
                panel_page_1.Visible = true;
            }
            else if (id == 2)
            {
                panel_page_2.Location = point;
                panel_page_2.Visible = true;
            }
            else if (id == 3)
            {
                if (radioButton_use_yes.Checked)
                {
                    if (File.Exists(Program.one_message)) File.Delete(Program.one_message);
                    Start();
                }
                else Program.MSB_Error(no_ok);

                Close();
            }

            button_next2.Enabled = false;
            panel_page_dp.Location = new Point(-7, 295);
            panel_page_dp.Visible = true;
            label_info_sec.LinkColor = Color.Black;
            label_info_sec.Text = "0";
            timer_sec = 30;
        }

        /// <summary>
        /// 30 seconds of torment for users who do not like to read.
        /// </summary>
        private void timer_check_Tick(object sender, EventArgs e)
        {
            timer_sec--;

            label_info_sec.LinkColor = colors[random.Next(0, colors.Count)];
            if (timer_sec == 0)
            {
                button_next2.Enabled = true;
                label_info_sec.LinkColor = Color.Black;
                label_info_sec.Text = "0";
                System.Media.SystemSounds.Hand.Play();
                timer_sec = 30;
                button_next2.Enabled = true;
                timer_check.Stop();
            }
            else
            {
                label_info_sec.Text = timer_sec.ToString();
                button_next2.Enabled = false;
            }
        }

        /// <summary>
        /// Switches FORWARD to page 1 (terms of use).
        /// </summary>
        private void button_next1_Click(object sender, EventArgs e)
        {
            ChangePage(1);
            timer_check.Start();
        }

        /// <summary>
        /// Switches FORWARD to page 2 (important information and agreement), or exits and starts the launcher.
        /// </summary>
        private void button_next2_Click(object sender, EventArgs e)
        {
            ChangePage(g_id == 1 ? (byte)2 : (byte)3);
            timer_check.Start();
        }

        /// <summary>
        /// Switches BACK to page 0 (information page) or to page 1 (terms of use).
        /// </summary>
        private void button_exit2_Click(object sender, EventArgs e)
        {
            ChangePage(g_id == 1 ? (byte)0 : (byte)1);
            timer_check.Stop();
            button_next2.Enabled = true;
        }

        /// <summary>
        /// Kills running copies so they can be restarted, then starts files[0] (launcher.exe).
        /// </summary>
        public void Start()
        {
            try
            {
                for (int i = 0; i < Program.files.Length; i++)
                    foreach (Process tmp_process in Process.GetProcessesByName(Program.files[i].Replace(".exe", string.Empty))) tmp_process.Kill();

                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = Program.dir,
                    FileName = $@"{Application.StartupPath}\{Program.dir}{Program.files[0]}"
                };
                Process.Start(processStartInfo);
            }
            catch (Exception er) { Program.MSB_Error(er.ToString()); Console.ReadKey(); }
        }
    }
}
