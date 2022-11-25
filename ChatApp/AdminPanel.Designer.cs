namespace ChatApp
{
    partial class AdminPanel
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
            this.rickroll = new System.Windows.Forms.Button();
            this.color_settings_btn = new System.Windows.Forms.Button();
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
            // rickroll
            // 
            this.rickroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rickroll.Location = new System.Drawing.Point(9, 120);
            this.rickroll.Name = "rickroll";
            this.rickroll.Size = new System.Drawing.Size(350, 104);
            this.rickroll.TabIndex = 9;
            this.rickroll.Text = "RickROll";
            this.rickroll.UseVisualStyleBackColor = true;
            this.rickroll.Click += new System.EventHandler(this.rickroll_Click);
            // 
            // color_settings_btn
            // 
            this.color_settings_btn.Location = new System.Drawing.Point(12, 91);
            this.color_settings_btn.Name = "color_settings_btn";
            this.color_settings_btn.Size = new System.Drawing.Size(347, 23);
            this.color_settings_btn.TabIndex = 10;
            this.color_settings_btn.Text = "Text Settings";
            this.color_settings_btn.UseVisualStyleBackColor = true;
            this.color_settings_btn.Click += new System.EventHandler(this.color_settings_btn_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 232);
            this.Controls.Add(this.color_settings_btn);
            this.Controls.Add(this.rickroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rmt_cls_btn);
            this.Controls.Add(this.Adm_title);
            this.Name = "AdminPanel";
            this.Text = "Admin Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Adm_title;
        private System.Windows.Forms.Button rmt_cls_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button rickroll;
        private System.Windows.Forms.Button color_settings_btn;
    }
}