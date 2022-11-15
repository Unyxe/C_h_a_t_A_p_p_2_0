using System;
using System.IO;

namespace ChatApp
{
    partial class Form1
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
            try
            {
                base.Dispose(disposing);
            }
            catch
            {
                /*
                FileStream fs = new FileStream(MainFolderPath+SessionId+"f", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamReader reader = new StreamReader(fs);
                int i = Int32.Parse(reader.ReadLine());
                fs = new FileStream(MainFolderPath + SessionId + "f", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine(i+1+"");
                writer.Close();
                */
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.msg_textbox = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.notifications_lbl = new System.Windows.Forms.Label();
            this.sessionid_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connect_btn = new System.Windows.Forms.Button();
            this.message_txt = new System.Windows.Forms.TextBox();
            this.char_count_lbl = new System.Windows.Forms.Label();
            this.global_chat_btn = new System.Windows.Forms.Button();
            this.user_count_label = new System.Windows.Forms.Label();
            this.admin_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "_______________";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // msg_textbox
            // 
            this.msg_textbox.Enabled = false;
            this.msg_textbox.Location = new System.Drawing.Point(472, 215);
            this.msg_textbox.Multiline = true;
            this.msg_textbox.Name = "msg_textbox";
            this.msg_textbox.Size = new System.Drawing.Size(316, 58);
            this.msg_textbox.TabIndex = 1;
            this.msg_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msg_textbox_keypress);
            // 
            // send_btn
            // 
            this.send_btn.Enabled = false;
            this.send_btn.Location = new System.Drawing.Point(713, 279);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 2;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // notifications_lbl
            // 
            this.notifications_lbl.AutoSize = true;
            this.notifications_lbl.ForeColor = System.Drawing.Color.Black;
            this.notifications_lbl.Location = new System.Drawing.Point(469, 330);
            this.notifications_lbl.Name = "notifications_lbl";
            this.notifications_lbl.Size = new System.Drawing.Size(91, 13);
            this.notifications_lbl.TabIndex = 3;
            this.notifications_lbl.Text = "______________";
            // 
            // sessionid_textbox
            // 
            this.sessionid_textbox.Location = new System.Drawing.Point(688, 85);
            this.sessionid_textbox.Name = "sessionid_textbox";
            this.sessionid_textbox.Size = new System.Drawing.Size(100, 20);
            this.sessionid_textbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(627, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "SessionID";
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(688, 59);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(100, 20);
            this.username_textbox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(627, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username";
            // 
            // connect_btn
            // 
            this.connect_btn.Location = new System.Drawing.Point(713, 111);
            this.connect_btn.Name = "connect_btn";
            this.connect_btn.Size = new System.Drawing.Size(75, 23);
            this.connect_btn.TabIndex = 8;
            this.connect_btn.Text = "Connect";
            this.connect_btn.UseVisualStyleBackColor = true;
            this.connect_btn.Click += new System.EventHandler(this.connect_btn_Click);
            // 
            // message_txt
            // 
            this.message_txt.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.message_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.message_txt.Location = new System.Drawing.Point(20, 59);
            this.message_txt.Multiline = true;
            this.message_txt.Name = "message_txt";
            this.message_txt.ReadOnly = true;
            this.message_txt.Size = new System.Drawing.Size(421, 379);
            this.message_txt.TabIndex = 9;
            // 
            // char_count_lbl
            // 
            this.char_count_lbl.AutoSize = true;
            this.char_count_lbl.Location = new System.Drawing.Point(660, 284);
            this.char_count_lbl.Name = "char_count_lbl";
            this.char_count_lbl.Size = new System.Drawing.Size(36, 13);
            this.char_count_lbl.TabIndex = 10;
            this.char_count_lbl.Text = "0/100";
            // 
            // global_chat_btn
            // 
            this.global_chat_btn.Location = new System.Drawing.Point(584, 111);
            this.global_chat_btn.Name = "global_chat_btn";
            this.global_chat_btn.Size = new System.Drawing.Size(123, 23);
            this.global_chat_btn.TabIndex = 11;
            this.global_chat_btn.Text = "Global Chat Connect";
            this.global_chat_btn.UseVisualStyleBackColor = true;
            this.global_chat_btn.Click += new System.EventHandler(this.global_chat_btn_Click);
            // 
            // user_count_label
            // 
            this.user_count_label.AutoSize = true;
            this.user_count_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_count_label.Location = new System.Drawing.Point(20, 26);
            this.user_count_label.Name = "user_count_label";
            this.user_count_label.Size = new System.Drawing.Size(112, 20);
            this.user_count_label.TabIndex = 12;
            this.user_count_label.Text = "Active users: 0";
            // 
            // admin_btn
            // 
            this.admin_btn.Enabled = false;
            this.admin_btn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.admin_btn.Location = new System.Drawing.Point(713, 414);
            this.admin_btn.Name = "admin_btn";
            this.admin_btn.Size = new System.Drawing.Size(75, 23);
            this.admin_btn.TabIndex = 13;
            this.admin_btn.Text = "_";
            this.admin_btn.UseVisualStyleBackColor = true;
            this.admin_btn.Click += new System.EventHandler(this.admin_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.admin_btn);
            this.Controls.Add(this.user_count_label);
            this.Controls.Add(this.global_chat_btn);
            this.Controls.Add(this.char_count_lbl);
            this.Controls.Add(this.message_txt);
            this.Controls.Add(this.connect_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sessionid_textbox);
            this.Controls.Add(this.notifications_lbl);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.msg_textbox);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ChatLUTC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox msg_textbox;
        public System.Windows.Forms.Label notifications_lbl;
        private System.Windows.Forms.TextBox sessionid_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button connect_btn;
        private System.Windows.Forms.TextBox message_txt;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Label char_count_lbl;
        public System.Windows.Forms.Button global_chat_btn;
        private System.Windows.Forms.Label user_count_label;
        private System.Windows.Forms.Button admin_btn;
    }
}

