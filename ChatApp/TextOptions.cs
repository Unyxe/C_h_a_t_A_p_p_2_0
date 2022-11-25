using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class TextOptions : Form
    {
        public TextOptions()
        {
            InitializeComponent();
            if (!MainForm.is_admin)
            {
                bold_option.Enabled = false;
                cursive_chek.Enabled = false;
                color_red_btn.Enabled = false;
            }
            if (MainForm.bold_txt)
            {
                bold_option.Checked = true;
            }
            if (MainForm.cursive_txt)
            {
                cursive_chek.Checked = true;
            }
        }

        private void color_black_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "black";
        }

        private void color_red_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "red";
        }

        private void color_green_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "green";
        }

        private void color_blue_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "blue";
        }

        private void color_aqua_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "aqua";
        }

        private void color_yellow_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "yellow";
        }

        private void color_orange_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "orange";
        }

        private void color_purple_btn_Click(object sender, EventArgs e)
        {
            if (!MainForm.custom_color)
            {
                MainForm.custom_color = true;
            }
            MainForm.txt_color = "purple";
        }

        private void bold_option_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.bold_txt = bold_option.Checked;
        }

        private void cursive_chek_CheckedChanged(object sender, EventArgs e)
        {
            MainForm.cursive_txt = cursive_chek.Checked;
        }
    }
}
