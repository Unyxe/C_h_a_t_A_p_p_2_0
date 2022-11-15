namespace ChatApp
{
    partial class Form2
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
            this.Adm_title = new System.Windows.Forms.Label();
            this.rmt_cls_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usercount_reset = new System.Windows.Forms.Button();
            this.session_id_box = new System.Windows.Forms.TextBox();
            this.amount_usercount = new System.Windows.Forms.TextBox();
            this.bckup_logfile_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.rickroll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Adm_title
            // 
            this.Adm_title.AutoSize = true;
            this.Adm_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Adm_title.Location = new System.Drawing.Point(12, 9);
            this.Adm_title.Name = "Adm_title";
            this.Adm_title.Size = new System.Drawing.Size(166, 31);
            this.Adm_title.TabIndex = 0;
            this.Adm_title.Text = "Admin Panel";
            // 
            // rmt_cls_btn
            // 
            this.rmt_cls_btn.Location = new System.Drawing.Point(91, 53);
            this.rmt_cls_btn.Name = "rmt_cls_btn";
            this.rmt_cls_btn.Size = new System.Drawing.Size(62, 23);
            this.rmt_cls_btn.TabIndex = 1;
            this.rmt_cls_btn.Text = "Enable";
            this.rmt_cls_btn.UseVisualStyleBackColor = true;
            this.rmt_cls_btn.Click += new System.EventHandler(this.rmt_cls_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remote close";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reset user count (need other admins to restart the app)";
            // 
            // usercount_reset
            // 
            this.usercount_reset.Location = new System.Drawing.Point(306, 146);
            this.usercount_reset.Name = "usercount_reset";
            this.usercount_reset.Size = new System.Drawing.Size(62, 23);
            this.usercount_reset.TabIndex = 4;
            this.usercount_reset.Text = "Reset";
            this.usercount_reset.UseVisualStyleBackColor = true;
            this.usercount_reset.Click += new System.EventHandler(this.usercount_reset_Click);
            // 
            // session_id_box
            // 
            this.session_id_box.Location = new System.Drawing.Point(285, 90);
            this.session_id_box.Name = "session_id_box";
            this.session_id_box.Size = new System.Drawing.Size(83, 20);
            this.session_id_box.TabIndex = 5;
            // 
            // amount_usercount
            // 
            this.amount_usercount.Location = new System.Drawing.Point(350, 116);
            this.amount_usercount.Name = "amount_usercount";
            this.amount_usercount.Size = new System.Drawing.Size(18, 20);
            this.amount_usercount.TabIndex = 6;
            // 
            // bckup_logfile_btn
            // 
            this.bckup_logfile_btn.Location = new System.Drawing.Point(93, 182);
            this.bckup_logfile_btn.Name = "bckup_logfile_btn";
            this.bckup_logfile_btn.Size = new System.Drawing.Size(75, 23);
            this.bckup_logfile_btn.TabIndex = 7;
            this.bckup_logfile_btn.Text = "Backup";
            this.bckup_logfile_btn.UseVisualStyleBackColor = true;
            this.bckup_logfile_btn.Click += new System.EventHandler(this.bckup_logfile_btn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Backup logfile";
            // 
            // rickroll
            // 
            this.rickroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rickroll.Location = new System.Drawing.Point(18, 211);
            this.rickroll.Name = "rickroll";
            this.rickroll.Size = new System.Drawing.Size(350, 104);
            this.rickroll.TabIndex = 9;
            this.rickroll.Text = "RickROll";
            this.rickroll.UseVisualStyleBackColor = true;
            this.rickroll.Click += new System.EventHandler(this.rickroll_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 327);
            this.Controls.Add(this.rickroll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bckup_logfile_btn);
            this.Controls.Add(this.amount_usercount);
            this.Controls.Add(this.session_id_box);
            this.Controls.Add(this.usercount_reset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rmt_cls_btn);
            this.Controls.Add(this.Adm_title);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Adm_title;
        private System.Windows.Forms.Button rmt_cls_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button usercount_reset;
        private System.Windows.Forms.TextBox session_id_box;
        private System.Windows.Forms.TextBox amount_usercount;
        private System.Windows.Forms.Button bckup_logfile_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button rickroll;
    }
}