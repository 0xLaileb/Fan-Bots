using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace LAUNCHER_FANBOT
{
    public class EngineWork
    {
        /// <summary>
        /// Global Random instance.
        /// </summary>
        public readonly Random random = new Random(Environment.TickCount);

        /// <summary>
        /// Flag that tells whether the first call has already happened.
        /// </summary>
        private bool one_start = false;

        /// <summary>
        /// List of parameters loaded from / saved to the translation file.
        /// </summary>
        public string[] prms = new string[]
        {
            "Enter an automatic command",
            "Enter a nickname",
            "Enter login",
            "Enter password",
            "Enter a command",

            "MY.COM - EUROPE",
            "MY.COM - AMERICA",
            "GOPLAY - VIETNAM",
            "RU - ALPHA",
            "RU - BRAVO",
            "RU - CHARLIE",
            "RU - PTS",

            "Random",
            "Blue",
            "Green",
            "Aqua",
            "Red",
            "Purple",
            "Yellow",
            "White",
            "Gray",
            "Light Blue"
        };

        /// <summary>
        /// Calls MessageBox.Show(...) with preset parameters for an information message.
        /// </summary>
        public void MSB_Information(string text, string caption) => MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

        /// <summary>
        /// Calls MessageBox.Show(...) with preset parameters for an error message.
        /// </summary>
        public void MSB_Error(string er, string caption = "Error..") => MessageBox.Show(er, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);

        /// <summary>
        /// Assigns <c>value</c> to <c>set</c> (by reference) after checking IsNullOrWhiteSpace(value). 
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="set">Reference to the variable that receives the new value.</param>
        public void SetValue(string value, ref string set) { if (!string.IsNullOrWhiteSpace(value)) set = value; }


        /// <summary>
        /// Gets the source code of a page.
        /// </summary>
        /// <param name="url">Site URL.</param>
        /// <returns>Page source code (HTML) as a string.</returns>
        public static string GET(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string res = reader.ReadToEnd();
            reader.Close();

            return res;
        }

        /// <summary>
        /// Walks all controls of the form and writes or reads their values (.Text = value).
        /// </summary>
        /// <param name="control">Form.</param>
        /// <param name="name">Section name.</param>
        /// <param name="write">Write (true) or read (false).</param>
        public void GetAllControls(Control control, IniFile iniFile, string name, bool write)
        {
            if (!string.IsNullOrWhiteSpace(control.Text))
            {
                if (write) iniFile.Write(control.Name, control.Text, name);
                else
                {
                    string tmp = iniFile.ReadString(control.Name, name);
                    if (!string.IsNullOrWhiteSpace(tmp)) control.Text = tmp;
                }
            }
            foreach (Control tmp_control in control.Controls) GetAllControls(tmp_control, iniFile, name, write);
        }


        /// <summary>
        /// Loads the prms[] array from iniFile, or in DEBUG mode copies the parameters to the clipboard.
        /// </summary>
        /// <param name="menu">Reference to Menu.</param>
        /// <param name="name">Section name.</param>
        private void GetAllPrms(Menu menu, IniFile iniFile, string name)
        {
#if DEBUG
            string tmp = string.Empty;
            for (int i = 0; i < prms.Length; i++) tmp += $"{$">prms_{i}"} = {prms[i]}\n";
            Clipboard.SetText(tmp); 
#else
            for (int i = 0; i < prms.Length; i++) SetValue(iniFile.ReadString($">prms_{i}", name), ref prms[i]);
#endif
        }

        /// <summary>
        /// Collects all controls of the given type into <c>get_controls_list</c>.
        /// </summary>
        /// <param name="get_controls_list">List that receives the controls.</param>
        /// <param name="control">Form.</param>
        /// <param name="type">Control type (control.GetType()).</param>
        public void GetAllControls_ForSettings(List<Control> get_controls_list, Control control, Type type)
        {
            if (control.GetType() == type) get_controls_list.Add(control);
            foreach (Control ctrlChild in control.Controls) GetAllControls_ForSettings(get_controls_list, ctrlChild, type);
        }

        /// <summary>
        ///  Applies a translation to the controls (.Text = string) or restarts the application.
        /// </summary>
        /// <param name="control_cont">Form.</param>
        /// <param name="translation">Apply the translation file (true) or restart the application with the default language (false).</param>
        /// <param name="file">File name.</param>
        /// <param name="name">Section name.</param>
        public void Translation(Control control_cont, bool translation, string file, string name)
        {
            Menu menu = (Menu)control_cont;
            if (translation == true)
            {
                GetAllControls(control_cont, new IniFile(file), name, false);
                GetAllPrms(menu, new IniFile(file), name);
                menu.LoadPrms();
            }
            else if (one_start == true)
            {
                new IniFile(menu.files_names[3]).Write(menu.comboBox_languages.Name, "default (english)", menu.sect);
                Process.Start(Application.ProductName + ".exe");
                Environment.Exit(0);
            }
            else one_start = true;
        }

        public static class TextBoxWatermarkExtensionMethod
        {
            private const uint ECM_FIRST = 0x1500;
            private const uint EM_SETCUEBANNER = ECM_FIRST + 1;

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, uint wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);
            public static void SetWatermark(TextBox textBox, string watermarkText) => SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermarkText);
        }
    }
}
