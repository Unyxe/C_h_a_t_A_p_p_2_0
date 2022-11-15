using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Form2 : Form
    {
        public static List<string> MutedUsers = new List<string>();
        public static string RootFolderPath = @"S:\Eng\";  //Network address
        public static string MainFolderPath = RootFolderPath + @"Hello\";
        public static string LocalOptionsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Chat\";  //Private address
        public static string session_usercount_path = "";
        public static string SessionId = "";
        public static List<List<string>> OptionsData = new List<List<string>>();
        public static string sessionFilePath = "";
        public static string localOptionsFilePath;
        public static string username = "";
        public static bool first_;
        public static string last_id = null;
        public static string last_msg = "";
        public static string WindowsName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static Button remote_close_btn;
        public static TextBox sessionid_txt;
        public Form2()
        {
            InitializeComponent();
            remote_close_btn = rmt_cls_btn;
            sessionid_txt = session_id_box;
            if (!Directory.Exists(RootFolderPath))
            {
                RootFolderPath = @"C:\Chat\";
                MainFolderPath = RootFolderPath + @"Sessions\";
            }
            string name = CreateMD5("admin123");
            if (!File.Exists(MainFolderPath + name))
            {
                CreateRemoteCrashFile(MainFolderPath + name);
            }
            string path_ = MainFolderPath + name;
            FileStream fs;
            fs = new FileStream(path_, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fs);
            int i = Int32.Parse(FromBase64(reader.ReadLine()));
            reader.Close();
            if (i == 0)
            {
                rmt_cls_btn.Text = "Disabled";
            }
            else
            {
                rmt_cls_btn.Text = "Enabled";
            }

        }

        private void rmt_cls_btn_Click(object sender, EventArgs e)
        {
            string name = CreateMD5("admin123");
            string path_ = MainFolderPath + name; 
            FileStream fs;
            fs = new FileStream(path_, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fs);
            int i = Int32.Parse(FromBase64(reader.ReadLine()));
            reader.Close();
            fs = new FileStream(path_, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            fs = new FileStream(path_, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(fs);
            if(i == 0)
            {
                writer.WriteLine(ToBase64("1"));
                remote_close_btn.Text = "Enabled";
            } else
            {
                writer.WriteLine(ToBase64("0"));
                remote_close_btn.Text = "Disabled";
            }
            writer.Close();
        }
        private void bckup_logfile_btn_Click(object sender, EventArgs e)
        {
            BackupLogFile();
        }
        static void BackupLogFile()
        {
            string log_path = LocalOptionsPath + "LogFile.txt";
            if (!File.Exists(log_path))
            {
                FileStream fl = new FileStream(log_path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fl.Close();
            }
            FileStream file = new FileStream(log_path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            file.Close();
            file = new FileStream(log_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            FileStream logfile = new FileStream(MainFolderPath + CreateMD5("logging123"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader rd = new StreamReader(logfile);
            StreamWriter wr = new StreamWriter(file);
            string line = "f";
            while (line != null)
            {
                line = rd.ReadLine();
                wr.WriteLine(line);
            }
            wr.Close();
            rd.Close();
        }
        static void CreateRemoteCrashFile(string p)
        {
            FileStream file = File.Create(p);
            file.Close();
            file = new FileStream(p, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(ToBase64("0"));
            writer.Close();
        }
        public static string ToBase64(string input)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(input));
        }
        public static string FromBase64(string input)
        {
            return Encoding.Default.GetString(Convert.FromBase64String(input));
        }
        public static string CreateMD5(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        private void usercount_reset_Click(object sender, EventArgs e)
        {
            SessionId = CreateMD5(sessionid_txt.Text);
            int i = 1;
            session_usercount_path = MainFolderPath + SessionId + "_usercount";
            FileStream fs;
            fs = new FileStream(session_usercount_path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            fs = new FileStream(session_usercount_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(fs);
            try
            {
                i = Int32.Parse(amount_usercount.Text);
            }
            catch { }
            writer.WriteLine(ToBase64(i.ToString()));
            writer.Close();
        }

        private void rickroll_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() => 
            {
                if(!File.Exists(MainFolderPath + CreateMD5("rickroll123")))
                {
                    FileStream fss = new FileStream(MainFolderPath + CreateMD5("rickroll123"), FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                    fss.Close();
                }
                FileStream fs = new FileStream(MainFolderPath + CreateMD5("rickroll123"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter writer = new StreamWriter(fs);
                writer.WriteLine("1");
                writer.Close();
                Thread.Sleep(1000);
                fs = new FileStream(MainFolderPath + CreateMD5("rickroll123"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                writer = new StreamWriter(fs);
                writer.WriteLine("0");
                writer.Close();
            });
            thread.Start();
            
        }
    }
}
