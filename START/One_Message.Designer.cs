namespace START
{
    partial class One_Message
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(One_Message));
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_info = new System.Windows.Forms.RichTextBox();
            this.timer_check = new System.Windows.Forms.Timer(this.components);
            this.richTextBox_use_conditions = new System.Windows.Forms.RichTextBox();
            this.button_exit2 = new System.Windows.Forms.Button();
            this.button_next2 = new System.Windows.Forms.Button();
            this.label_sec = new System.Windows.Forms.Label();
            this.label_info_button = new System.Windows.Forms.Label();
            this.label_info_sec = new System.Windows.Forms.LinkLabel();
            this.radioButton_use_yes = new System.Windows.Forms.RadioButton();
            this.radioButton_use_no = new System.Windows.Forms.RadioButton();
            this.panel_page_dp = new System.Windows.Forms.Panel();
            this.panel_1 = new System.Windows.Forms.Panel();
            this.button_exit1 = new System.Windows.Forms.Button();
            this.button_next1 = new System.Windows.Forms.Button();
            this.label_select_lang = new System.Windows.Forms.Label();
            this.radioButton_russian = new System.Windows.Forms.RadioButton();
            this.panel_lang = new System.Windows.Forms.Panel();
            this.pictureBox_eu = new System.Windows.Forms.PictureBox();
            this.pictureBox_ru = new System.Windows.Forms.PictureBox();
            this.radioButton_english = new System.Windows.Forms.RadioButton();
            this.pictureBox_logo = new System.Windows.Forms.PictureBox();
            this.label_info = new System.Windows.Forms.Label();
            this.panel_page_0 = new System.Windows.Forms.Panel();
            this.label_license = new System.Windows.Forms.Label();
            this.label_info_funcode = new System.Windows.Forms.Label();
            this.panel_page_1 = new System.Windows.Forms.Panel();
            this.panel_page_2 = new System.Windows.Forms.Panel();
            this.panel_page_dp.SuspendLayout();
            this.panel_1.SuspendLayout();
            this.panel_lang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).BeginInit();
            this.panel_page_0.SuspendLayout();
            this.panel_page_1.SuspendLayout();
            this.panel_page_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(38, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пожалуйста, прочитайте следующую важную информацию:";
            // 
            // richTextBox_info
            // 
            this.richTextBox_info.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox_info.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_info.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_info.Location = new System.Drawing.Point(10, 10);
            this.richTextBox_info.MaxLength = 10000;
            this.richTextBox_info.Name = "richTextBox_info";
            this.richTextBox_info.Size = new System.Drawing.Size(443, 278);
            this.richTextBox_info.TabIndex = 1;
            this.richTextBox_info.Text = resources.GetString("richTextBox_info.Text");
            // 
            // timer_check
            // 
            this.timer_check.Interval = 1000;
            this.timer_check.Tick += new System.EventHandler(this.timer_check_Tick);
            // 
            // richTextBox_use_conditions
            // 
            this.richTextBox_use_conditions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox_use_conditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox_use_conditions.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_use_conditions.Location = new System.Drawing.Point(10, 35);
            this.richTextBox_use_conditions.MaxLength = 10000;
            this.richTextBox_use_conditions.Name = "richTextBox_use_conditions";
            this.richTextBox_use_conditions.Size = new System.Drawing.Size(443, 198);
            this.richTextBox_use_conditions.TabIndex = 4;
            this.richTextBox_use_conditions.Text = resources.GetString("richTextBox_use_conditions.Text");
            // 
            // button_exit2
            // 
            this.button_exit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit2.Location = new System.Drawing.Point(318, 9);
            this.button_exit2.Name = "button_exit2";
            this.button_exit2.Size = new System.Drawing.Size(68, 23);
            this.button_exit2.TabIndex = 2;
            this.button_exit2.Text = "< Назад";
            this.button_exit2.UseVisualStyleBackColor = true;
            this.button_exit2.Click += new System.EventHandler(this.button_exit2_Click);
            // 
            // button_next2
            // 
            this.button_next2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next2.Location = new System.Drawing.Point(392, 9);
            this.button_next2.Name = "button_next2";
            this.button_next2.Size = new System.Drawing.Size(68, 23);
            this.button_next2.TabIndex = 3;
            this.button_next2.Text = "Далее >";
            this.button_next2.UseVisualStyleBackColor = true;
            this.button_next2.Click += new System.EventHandler(this.button_next2_Click);
            // 
            // label_sec
            // 
            this.label_sec.AutoSize = true;
            this.label_sec.Location = new System.Drawing.Point(276, 14);
            this.label_sec.Name = "label_sec";
            this.label_sec.Size = new System.Drawing.Size(24, 13);
            this.label_sec.TabIndex = 6;
            this.label_sec.Text = "сек";
            // 
            // label_info_button
            // 
            this.label_info_button.AutoSize = true;
            this.label_info_button.Location = new System.Drawing.Point(24, 14);
            this.label_info_button.Name = "label_info_button";
            this.label_info_button.Size = new System.Drawing.Size(234, 13);
            this.label_info_button.TabIndex = 5;
            this.label_info_button.Text = "Кнопка  \'Далее >\'  -  будет доступна через:";
            // 
            // label_info_sec
            // 
            this.label_info_sec.AutoSize = true;
            this.label_info_sec.Location = new System.Drawing.Point(259, 14);
            this.label_info_sec.Name = "label_info_sec";
            this.label_info_sec.Size = new System.Drawing.Size(19, 13);
            this.label_info_sec.TabIndex = 4;
            this.label_info_sec.TabStop = true;
            this.label_info_sec.Text = "30";
            // 
            // radioButton_use_yes
            // 
            this.radioButton_use_yes.AutoSize = true;
            this.radioButton_use_yes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_use_yes.Location = new System.Drawing.Point(72, 241);
            this.radioButton_use_yes.Name = "radioButton_use_yes";
            this.radioButton_use_yes.Size = new System.Drawing.Size(309, 17);
            this.radioButton_use_yes.TabIndex = 6;
            this.radioButton_use_yes.Text = "Я согласен с условиями использования и лицензией.";
            this.radioButton_use_yes.UseVisualStyleBackColor = true;
            // 
            // radioButton_use_no
            // 
            this.radioButton_use_no.AutoSize = true;
            this.radioButton_use_no.Checked = true;
            this.radioButton_use_no.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_use_no.Location = new System.Drawing.Point(72, 264);
            this.radioButton_use_no.Name = "radioButton_use_no";
            this.radioButton_use_no.Size = new System.Drawing.Size(325, 17);
            this.radioButton_use_no.TabIndex = 7;
            this.radioButton_use_no.TabStop = true;
            this.radioButton_use_no.Text = "Я не согласен с условиями использования и лицензией.";
            this.radioButton_use_no.UseVisualStyleBackColor = true;
            // 
            // panel_page_dp
            // 
            this.panel_page_dp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_page_dp.Controls.Add(this.label_sec);
            this.panel_page_dp.Controls.Add(this.button_exit2);
            this.panel_page_dp.Controls.Add(this.label_info_button);
            this.panel_page_dp.Controls.Add(this.label_info_sec);
            this.panel_page_dp.Controls.Add(this.button_next2);
            this.panel_page_dp.Location = new System.Drawing.Point(492, 295);
            this.panel_page_dp.Name = "panel_page_dp";
            this.panel_page_dp.Size = new System.Drawing.Size(487, 48);
            this.panel_page_dp.TabIndex = 10;
            // 
            // panel_1
            // 
            this.panel_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_1.Controls.Add(this.button_exit1);
            this.panel_1.Controls.Add(this.button_next1);
            this.panel_1.Location = new System.Drawing.Point(-9, 290);
            this.panel_1.Name = "panel_1";
            this.panel_1.Size = new System.Drawing.Size(487, 48);
            this.panel_1.TabIndex = 11;
            // 
            // button_exit1
            // 
            this.button_exit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit1.Location = new System.Drawing.Point(85, 11);
            this.button_exit1.Name = "button_exit1";
            this.button_exit1.Size = new System.Drawing.Size(155, 23);
            this.button_exit1.TabIndex = 2;
            this.button_exit1.Text = "Отмена";
            this.button_exit1.UseVisualStyleBackColor = true;
            this.button_exit1.Click += new System.EventHandler(this.Exit);
            // 
            // button_next1
            // 
            this.button_next1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next1.Location = new System.Drawing.Point(245, 11);
            this.button_next1.Name = "button_next1";
            this.button_next1.Size = new System.Drawing.Size(155, 23);
            this.button_next1.TabIndex = 3;
            this.button_next1.Text = "Далее >";
            this.button_next1.UseVisualStyleBackColor = true;
            this.button_next1.Click += new System.EventHandler(this.button_next1_Click);
            // 
            // label_select_lang
            // 
            this.label_select_lang.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_select_lang.Location = new System.Drawing.Point(3, 4);
            this.label_select_lang.Name = "label_select_lang";
            this.label_select_lang.Size = new System.Drawing.Size(169, 20);
            this.label_select_lang.TabIndex = 12;
            this.label_select_lang.Text = "Язык:";
            this.label_select_lang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButton_russian
            // 
            this.radioButton_russian.AutoSize = true;
            this.radioButton_russian.Checked = true;
            this.radioButton_russian.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_russian.Location = new System.Drawing.Point(15, 40);
            this.radioButton_russian.Name = "radioButton_russian";
            this.radioButton_russian.Size = new System.Drawing.Size(14, 13);
            this.radioButton_russian.TabIndex = 13;
            this.radioButton_russian.TabStop = true;
            this.radioButton_russian.UseVisualStyleBackColor = true;
            this.radioButton_russian.CheckedChanged += new System.EventHandler(this.radioButton_russian_CheckedChanged);
            // 
            // panel_lang
            // 
            this.panel_lang.Controls.Add(this.pictureBox_eu);
            this.panel_lang.Controls.Add(this.pictureBox_ru);
            this.panel_lang.Controls.Add(this.label_select_lang);
            this.panel_lang.Controls.Add(this.radioButton_english);
            this.panel_lang.Controls.Add(this.radioButton_russian);
            this.panel_lang.Location = new System.Drawing.Point(140, 45);
            this.panel_lang.Name = "panel_lang";
            this.panel_lang.Size = new System.Drawing.Size(175, 66);
            this.panel_lang.TabIndex = 15;
            // 
            // pictureBox_eu
            // 
            this.pictureBox_eu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_eu.BackgroundImage")));
            this.pictureBox_eu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_eu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_eu.Location = new System.Drawing.Point(114, 35);
            this.pictureBox_eu.Name = "pictureBox_eu";
            this.pictureBox_eu.Size = new System.Drawing.Size(41, 22);
            this.pictureBox_eu.TabIndex = 17;
            this.pictureBox_eu.TabStop = false;
            // 
            // pictureBox_ru
            // 
            this.pictureBox_ru.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_ru.BackgroundImage")));
            this.pictureBox_ru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_ru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_ru.Location = new System.Drawing.Point(37, 35);
            this.pictureBox_ru.Name = "pictureBox_ru";
            this.pictureBox_ru.Size = new System.Drawing.Size(41, 22);
            this.pictureBox_ru.TabIndex = 16;
            this.pictureBox_ru.TabStop = false;
            // 
            // radioButton_english
            // 
            this.radioButton_english.AutoSize = true;
            this.radioButton_english.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_english.Location = new System.Drawing.Point(92, 39);
            this.radioButton_english.Name = "radioButton_english";
            this.radioButton_english.Size = new System.Drawing.Size(14, 13);
            this.radioButton_english.TabIndex = 14;
            this.radioButton_english.UseVisualStyleBackColor = true;
            this.radioButton_english.CheckedChanged += new System.EventHandler(this.radioButton_english_CheckedChanged);
            // 
            // pictureBox_logo
            // 
            this.pictureBox_logo.BackgroundImage = global::START.Properties.Resources.fanbots_logo;
            this.pictureBox_logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_logo.Location = new System.Drawing.Point(17, 167);
            this.pictureBox_logo.Name = "pictureBox_logo";
            this.pictureBox_logo.Size = new System.Drawing.Size(108, 102);
            this.pictureBox_logo.TabIndex = 16;
            this.pictureBox_logo.TabStop = false;
            // 
            // label_info
            // 
            this.label_info.Location = new System.Drawing.Point(130, 172);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(319, 70);
            this.label_info.TabIndex = 41;
            this.label_info.Text = resources.GetString("label_info.Text");
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_page_0
            // 
            this.panel_page_0.Controls.Add(this.label_license);
            this.panel_page_0.Controls.Add(this.label_info_funcode);
            this.panel_page_0.Controls.Add(this.panel_lang);
            this.panel_page_0.Controls.Add(this.label_info);
            this.panel_page_0.Controls.Add(this.panel_1);
            this.panel_page_0.Controls.Add(this.pictureBox_logo);
            this.panel_page_0.Location = new System.Drawing.Point(2, 2);
            this.panel_page_0.Name = "panel_page_0";
            this.panel_page_0.Size = new System.Drawing.Size(468, 340);
            this.panel_page_0.TabIndex = 42;
            // 
            // label_license
            // 
            this.label_license.Location = new System.Drawing.Point(117, 7);
            this.label_license.Name = "label_license";
            this.label_license.Size = new System.Drawing.Size(227, 13);
            this.label_license.TabIndex = 43;
            this.label_license.Text = "GNU Affero General Public License v3.0";
            this.label_license.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_info_funcode
            // 
            this.label_info_funcode.Location = new System.Drawing.Point(129, 254);
            this.label_info_funcode.Name = "label_info_funcode";
            this.label_info_funcode.Size = new System.Drawing.Size(319, 15);
            this.label_info_funcode.TabIndex = 42;
            this.label_info_funcode.Text = "Принадлежит организации: «Fun-Code»";
            this.label_info_funcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_page_1
            // 
            this.panel_page_1.Controls.Add(this.richTextBox_info);
            this.panel_page_1.Location = new System.Drawing.Point(501, 2);
            this.panel_page_1.Name = "panel_page_1";
            this.panel_page_1.Size = new System.Drawing.Size(468, 291);
            this.panel_page_1.TabIndex = 43;
            // 
            // panel_page_2
            // 
            this.panel_page_2.Controls.Add(this.richTextBox_use_conditions);
            this.panel_page_2.Controls.Add(this.label2);
            this.panel_page_2.Controls.Add(this.radioButton_use_yes);
            this.panel_page_2.Controls.Add(this.radioButton_use_no);
            this.panel_page_2.Location = new System.Drawing.Point(501, 349);
            this.panel_page_2.Name = "panel_page_2";
            this.panel_page_2.Size = new System.Drawing.Size(468, 291);
            this.panel_page_2.TabIndex = 44;
            // 
            // One_Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(462, 337);
            this.Controls.Add(this.panel_page_2);
            this.Controls.Add(this.panel_page_dp);
            this.Controls.Add(this.panel_page_1);
            this.Controls.Add(this.panel_page_0);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "One_Message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fan-Bot\'s";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Exit);
            this.panel_page_dp.ResumeLayout(false);
            this.panel_page_dp.PerformLayout();
            this.panel_1.ResumeLayout(false);
            this.panel_lang.ResumeLayout(false);
            this.panel_lang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_eu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_logo)).EndInit();
            this.panel_page_0.ResumeLayout(false);
            this.panel_page_1.ResumeLayout(false);
            this.panel_page_2.ResumeLayout(false);
            this.panel_page_2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox_info;
        private System.Windows.Forms.Timer timer_check;
        private System.Windows.Forms.RichTextBox richTextBox_use_conditions;
        private System.Windows.Forms.Button button_exit2;
        private System.Windows.Forms.Button button_next2;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.Label label_info_button;
        private System.Windows.Forms.LinkLabel label_info_sec;
        private System.Windows.Forms.RadioButton radioButton_use_yes;
        private System.Windows.Forms.RadioButton radioButton_use_no;
        private System.Windows.Forms.Panel panel_page_dp;
        private System.Windows.Forms.Panel panel_1;
        private System.Windows.Forms.Button button_exit1;
        private System.Windows.Forms.Button button_next1;
        private System.Windows.Forms.Label label_select_lang;
        private System.Windows.Forms.RadioButton radioButton_russian;
        private System.Windows.Forms.Panel panel_lang;
        private System.Windows.Forms.PictureBox pictureBox_eu;
        private System.Windows.Forms.PictureBox pictureBox_ru;
        private System.Windows.Forms.PictureBox pictureBox_logo;
        private System.Windows.Forms.RadioButton radioButton_english;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Panel panel_page_0;
        private System.Windows.Forms.Panel panel_page_1;
        private System.Windows.Forms.Panel panel_page_2;
        private System.Windows.Forms.Label label_info_funcode;
        private System.Windows.Forms.Label label_license;
    }
}