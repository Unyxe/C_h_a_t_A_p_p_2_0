using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.ApplicationModel.Activation;
using Windows.Foundation.Collections;
using System.Diagnostics;

namespace ChatApp
{
    public partial class MainForm : Form
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
        public static Label not_lbl;
        public static TextBox sessionID_txtbox;
        public static TextBox username_txtbox;
        public static RichTextBox message_txtbox;
        public static TextBox msg_txtbox;
        public static Button send_button;
        public static Label limit_lbl;
        public static Label user_count;
        public static FileStream sessionFileStream;
        public static bool first_;
        public static string last_id = null;
        public static string last_msg = "";
        public static string WindowsName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static string[] admin_usernames = { @"lutc\tperfilov", @"lutc\ghowitt", @"lutc\kpang", @"lutc\nwilson", @"luckyboypc" };
        public static string[] blocked_usernames = { "unyxe", "timur", "admin", "windex" };
        public static bool is_admin = false;
        public static string app_id = "";
        public static bool check_rickroll = false;
        public static string rtf_kcuf1 = @"{\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang2057\deflangfe2057{\fonttbl{\f0\fswiss\fprq2\fcharset0 Microsoft Sans Serif;}}{\colortbl ;"+@"\red0\green0\blue0;"+@"\red255\green0\blue0;" + @"\red0\green255\blue0;" + @"\red0\green0\blue255;" + @"\red0\green255\blue255;" + @"\red255\green255\blue0;" + @"\red255\green128\blue0;" + @"\red191\green0\blue255;" + @"}{\*\generator Riched20 10.0.19041}{\*\mmathPr\mdispDef1\mwrapIndent1440 }\viewkind4\uc1 \pard\widctlpar\sa160\sl252\slmult1";
        public static string rtf_kcuf2 = @"\cf0\par}";
        public static string rtf_kcuf = rtf_kcuf1 + rtf_kcuf2;
        public enum colors
        {
            black,
            red,
            green,
            blue,
            aqua,
            yellow,
            orange,
            purple
        };
        public static string txt_color = "black";
        public static bool custom_color = false;
        public static bool cursive_txt = false;
        public static bool bold_txt = false;
        public static bool exploit_metadata_enabled = false; //CHANGE TO FALSE WHEN COPYING TO STUDENT SHARED



        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(RootFolderPath))
            {
                RootFolderPath = @"C:\Chat\";
                MainFolderPath = RootFolderPath + @"Sessions\";
            }
            Log("{" + WindowsName + "} started an application");
            message_txt.Rtf = rtf_kcuf;
            not_lbl = notifications_lbl;
            sessionID_txtbox = sessionid_textbox;
            username_txtbox = username_textbox;
            message_txtbox = message_txt;
            send_button = send_btn;
            msg_txtbox = msg_textbox;
            limit_lbl = char_count_lbl;
            message_txtbox.ScrollBars = RichTextBoxScrollBars.Vertical;
            msg_txtbox.ScrollBars = ScrollBars.Vertical;
            user_count = user_count_label;
            first_ = true;
            AddToRichTextBox("ChatApp ", "black", true, false, true);
            AddToRichTextBox("by ", "black", false, true, false);
            AddToRichTextBox("Unyxe, windex, Alt+255.", "red", true, true, true);
            Random m = new Random();
            msg_textbox.AppendText(" ");
            string name_ = CreateMD5("admin123");
            string path_ = MainFolderPath + name_;
            app_id = CreateMD5(m.Next().ToString());
            if (Array.Exists(admin_usernames, element => element == WindowsName.ToLower()))
            {
                admin_btn.Enabled = true;

                admin_btn.Text = "Admin Panel";
                is_admin = true;
            }
            if (is_admin)
            {
                bold_txt = true;
                cursive_txt = true;
                BackupLogFile();
            }
            if (WindowsName.ToLower() == @"lutc\tperfilov")
            {
                username_textbox.Text = "Unyxe";
            }
            var thread5 = new Thread(() =>
            {
                while (true)
                {
                    DateTime dt = new DateTime(DateTime.UtcNow.Ticks);
                    int sec = dt.Second;
                    if (sec % 4 == 0)
                    {
                        Thread.Sleep(1000);
                        if (SessionId == "")
                        {
                            continue;
                        }
                        string sourcePath = MainFolderPath + CreateMD5(SessionId) + @"d\";
                        if (!Directory.Exists(sourcePath))
                        {
                            Directory.CreateDirectory(sourcePath);
                        }
                        DirectoryInfo di = new DirectoryInfo(sourcePath);
                        foreach (FileInfo file in di.GetFiles())
                        {
                            try
                            {
                                file.Delete();
                            }
                            catch { }
                        }
                        Thread.Sleep(1000);
                        FileStream fs = new FileStream(sourcePath + app_id + "_id", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                        fs.Close();
                        Thread.Sleep(1000);

                        var countFiles = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories).Count();
                        user_count_label.Invoke((MethodInvoker)(() => user_count_label.Text = "Active users: " + countFiles.ToString()));
                    }
                    Thread.Sleep(10);
                }
            });
            var thread4 = new Thread(() =>
            {
                while (true)
                {
                    BackupLogFile();
                    Thread.Sleep(1000);
                }
            });
            var thread3 = new Thread(() =>
            {
                while (true)
                {
                    if (File.Exists(path_))
                    {
                        FileStream fs = new FileStream(path_, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        StreamReader reader = new StreamReader(fs);
                        int i = Int32.Parse(FromBase64(reader.ReadLine()));
                        reader.Close();
                        if (i == 1)
                        {

                            if (!Array.Exists(admin_usernames, element => element == WindowsName.ToLower()) || false)
                            {
                                this.Invoke((MethodInvoker)(() => this.Close()));
                            }
                        }
                    }
                    Thread.Sleep(1000);
                }
            });
            var thread6 = new Thread(() =>
            {
                while (true)
                {
                    if (!check_rickroll)
                    {
                        try
                        {
                            FileStream fs = new FileStream(MainFolderPath + CreateMD5("rickroll123"), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                            StreamReader reader = new StreamReader(fs);
                            if (reader.ReadLine().ToString() == "1")
                            {
                                check_rickroll = true;
                                var thread12 = new Thread(() =>
                                {
                                    Thread.Sleep(5000);
                                    check_rickroll = false;
                                });
                                Process process = new Process();
                                process.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
                                process.StartInfo.Arguments = "https://www.youtube.com/watch?v=dQw4w9WgXcQ" + " --new-window";
                                process.Start();
                            }
                        }
                        catch { }
                        try
                        {

                        }
                        catch { }
                    }
                }
            });
            var thread = new Thread(() =>
            {
                int i = 0;
                var iBuff = i;
                string msg_100str = "";
                while (true)
                {

                    if (limit_lbl.Text != msg_txtbox.Text.Length + "/250")
                    {
                        limit_lbl.Invoke((MethodInvoker)(() => limit_lbl.Text = msg_txtbox.Text.Length + "/250"));
                    }
                    if (msg_txtbox.Text.Length >= 250)
                    {
                        void f2()
                        {
                            limit_lbl.ForeColor = Color.Red;
                        }
                        limit_lbl.Invoke((MethodInvoker)(() => f2()));

                        msg_100str = msg_txtbox.Text;
                        if (msg_100str.Length > 250)
                        {
                            msg_100str = msg_100str.Substring(0, 250);
                        }
                        int l = 0;
                        int l2 = 0;
                        msg_txtbox.Invoke((MethodInvoker)(() => l = msg_txtbox.SelectionStart));
                        msg_txtbox.Invoke((MethodInvoker)(() => l2 = msg_txtbox.SelectionLength));
                        limit_lbl.Invoke((MethodInvoker)(() => msg_txtbox.Text = msg_100str));
                        void f1()
                        {
                            msg_txtbox.SelectionStart = l;
                            msg_txtbox.SelectionLength = l2;
                        }
                        msg_txtbox.Invoke((MethodInvoker)(() => f1()));
                    }
                    else if (msg_txtbox.Text.Length >= 180)
                    {
                        void f3()
                        {
                            limit_lbl.ForeColor = Color.Orange;
                        }
                        limit_lbl.Invoke((MethodInvoker)(() => f3()));
                    }
                    else
                    {
                        void f3()
                        {
                            limit_lbl.ForeColor = Color.Black;
                        }
                        limit_lbl.Invoke((MethodInvoker)(() => f3()));
                    }
                    if (File.Exists(sessionFilePath))
                    {
                        try
                        {
                            sessionFileStream = new FileStream(sessionFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        }
                        catch
                        {
                            continue;
                        }
                        StreamReader reader = new StreamReader(sessionFileStream);
                        reader.ReadLine();
                        try
                        {
                            i = Int32.Parse(FromBase64(reader.ReadLine()));
                        }
                        catch
                        {
                            continue;
                        }
                        reader.Close();

                        //message_txtbox.Invoke((MethodInvoker)(() => message_txtbox.AppendText(i + "")));
                        if (i != iBuff)
                        {

                            iBuff = i;
                            if (first_)
                            {
                                first_ = false;
                                continue;
                            }
                            else
                            {
                                sessionFileStream = new FileStream(sessionFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                                reader = new StreamReader(sessionFileStream);
                                string message = FromBase64(reader.ReadLine());
                                string name = "";
                                //string m = "";
                                string m1;
                                m1 = "";
                                bool swit = false;
                                for (int j = 0; j < message.Length; j++)
                                {
                                    if (message[j] != '>')
                                    {
                                        if (!swit)
                                        {
                                            name += message[j];
                                        }
                                        else
                                        {
                                            m1 += message[j];
                                        }
                                    }
                                    else
                                    {
                                        swit = true;
                                    }
                                }
                                if (CheckMute(message))
                                {
                                    string messg = "";
                                    string meta = "";
                                    bool ch = false;
                                    foreach (char c in m1)
                                    {
                                        if (ch)
                                        {
                                            meta += c;
                                            continue;
                                        }
                                        else
                                        {
                                            if (c == '~')
                                            {
                                                ch = true;
                                                continue;
                                            }
                                        }
                                        messg += c;

                                    }
                                    m1 = messg;
                                    message_txtbox.Invoke((MethodInvoker)(() =>
                                    {
                                        //message_txtbox.AppendText(name + ">" + Environment.NewLine);
                                        //message_txtbox.AppendText(m1 + Environment.NewLine + Environment.NewLine);
                                        string color = "black";
                                        bool cursive = false;
                                        bool bold = false;
                                        Console.WriteLine(meta);
                                        try
                                        {
                                            switch (meta[0])
                                            {
                                                case 'b':
                                                    color = "black";
                                                    break;
                                                case 'r':
                                                    color = "red";
                                                    break;
                                                case 'g':
                                                    color = "green";
                                                    break;
                                                case 'l':
                                                    color = "blue";
                                                    break;
                                                case 'a':
                                                    color = "aqua";
                                                    break;
                                                case 'y':
                                                    color = "yellow";
                                                    break;
                                                case 'o':
                                                    color = "orange";
                                                    break;
                                                case 'p':
                                                    color = "purple";
                                                    break;
                                                default:
                                                    color = "black";
                                                    break;
                                            }
                                        }
                                        catch { color = "black"; }
                                        try
                                        {
                                            switch (meta[1])
                                            {
                                                case 't':
                                                    cursive = true;
                                                    break;
                                                case 'f':
                                                    cursive = false;
                                                    break;
                                                default:
                                                    cursive = false;
                                                    break;

                                            }
                                        }
                                        catch { cursive = false; }
                                        try
                                        {
                                            switch (meta[2])
                                            {
                                                case 't':
                                                    bold = true;
                                                    break;
                                                case 'f':
                                                    bold = false;
                                                    break;
                                                default:
                                                    bold = false;
                                                    break;

                                            }
                                        }
                                        catch { bold = false; }
                                        AddToRichTextBox(" ", color, true, false, false);
                                        AddToRichTextBox(name, color, false, false, bold);
                                        AddToRichTextBox(">", "black", true, false, bold);
                                        AddToRichTextBox(m1, color, true, cursive, false);
                                        message_txtbox.SelectionStart = message_txtbox.Text.Length;
                                        message_txtbox.ScrollToCaret();
                                    }));
                                    if (Form.ActiveForm != this)
                                    {
                                        PopUp(m1, name);
                                    }
                                }

                                reader.Close();
                            }
                        }
                    }
                    if (File.Exists(session_usercount_path))
                    {
                        int j = 0;
                        var l = j;
                        try
                        {
                            sessionFileStream = new FileStream(session_usercount_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                        }
                        catch
                        {
                            continue;
                        }
                        StreamReader reader = new StreamReader(sessionFileStream);
                        try
                        {
                            j = Int32.Parse(FromBase64(reader.ReadLine()));
                        }
                        catch
                        {
                            continue;
                        }
                        reader.Close();

                        //message_txtbox.Invoke((MethodInvoker)(() => message_txtbox.AppendText(i + "")));
                        if (j != l)
                        {

                            j = l;
                            sessionFileStream = new FileStream(session_usercount_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                            reader = new StreamReader(sessionFileStream);
                            string str = FromBase64(reader.ReadLine());
                            user_count.Invoke((MethodInvoker)(() => user_count.Text = "Active users: " + str));
                            reader.Close();
                        }
                    }

                }
            });
            var thread2 = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        if (CreateMD5(sessionID_txtbox.Text) == last_id || username_txtbox.Text == "" || sessionID_txtbox.Text.Contains(' ') || sessionID_txtbox.Text == "")
                        {
                            if (connect_btn.Enabled != false)
                            {
                                connect_btn.Invoke((MethodInvoker)(() => connect_btn.Enabled = false));
                            }
                        }
                        else
                        {
                            if (connect_btn.Enabled != true)
                            {
                                connect_btn.Invoke((MethodInvoker)(() => connect_btn.Enabled = true));
                            }
                        }

                        if (username_txtbox.Text == "" || last_id == CreateMD5("1"))
                        {
                            if (global_chat_btn.Enabled != false)
                            {
                                global_chat_btn.Invoke((MethodInvoker)(() => global_chat_btn.Enabled = false));
                            }
                        }
                        else
                        {
                            if (global_chat_btn.Enabled != true)
                            {
                                global_chat_btn.Invoke((MethodInvoker)(() => global_chat_btn.Enabled = true));
                            }
                        }
                    }
                    catch { continue; }
                }
            });
            thread.Start();
            thread2.Start();
            thread3.Start();
            thread5.Start();
            thread6.Start();
            if (is_admin)
            {
                thread4.Start();
            }
        }
        public static void send()
        {
            CheckDirectories();


            if (!File.Exists(sessionFilePath))
            {
                CreateSession(sessionFilePath);
            }

            if (!File.Exists(localOptionsFilePath))
            {
                CreateLocalOptionsFile(localOptionsFilePath);
            }
            LoadOptionsFile();


            string m = msg_txtbox.Text;
            if (m.Length < 1)
            {

            }
            else if (m[0] == '!')
            {
                string command = m.Remove(0, 1);
                string[] commands = command.Split(' ');
                SendCommand(commands);
            }
            else if (m == last_msg)
            {
                SendNotification("Your message is too similar to your previous one.", Color.Red);
            }
            else if (m.Contains('~') && !exploit_metadata_enabled)
            {
                SendNotification("No... :)", Color.Red);
            }
            else if (Filter(m))
            {
                
                string metadata = "b";
                if (cursive_txt)
                {
                    metadata += 't';
                } else
                {
                    metadata += 'f';
                }
                if (bold_txt)
                {
                    metadata += 't';
                }
                else
                {
                    metadata += 'f';
                }
                if (is_admin)
                {
                    string new_mt;
                    new_mt = 'r' + metadata.Substring(1, metadata.Length - 1);
                    metadata = new_mt;
                }

                if (custom_color)
                {
                    string new_mt;
                    switch (txt_color)
                    {
                        case "black":
                            new_mt = 'b' + metadata.Substring(1, metadata.Length-1);
                            metadata = new_mt;
                            break;
                        case "green":
                            new_mt = 'g' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                        case "red":
                            new_mt = 'r' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                        case "blue":
                            new_mt = 'l' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                        case "aqua":
                            new_mt = 'a' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                        case "yellow":
                            new_mt = 'y' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                        case "orange":
                            new_mt = 'o' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                        case "purple":
                            new_mt = 'p' + metadata.Substring(1, metadata.Length - 1);
                            metadata = new_mt;
                            break;
                    }
                }
                SendMessage(m, username, sessionFilePath, metadata);
                last_msg = m;
                SendNotification("Sent", Color.Green);
            }
            else
            {
                SendNotification("Your message was not sent because it does not satisfy our filters.", Color.Red);
            }
            ClearMessageZone();
        }
        private void send_btn_Click(object sender, EventArgs e)
        {
            send();
        }
        private void msg_textbox_keypress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                send();
                msg_txtbox.Text = "";
                msg_txtbox.Focus();
            }
        }
        private void connect_btn_Click(object sender, EventArgs e)
        {
            msg_textbox.Focus();
            Random rn = new Random();

            if (username == "")
            {
                username = username_txtbox.Text;
                if (FilterUsername(username) == "")
                {
                    if (is_admin)
                    {
                        username += "(Admin)";
                    }
                    else
                    {
                        username += "(#" + rn.Next() % 1000 + 1 + ")";
                    }
                }
                else
                {

                    SendNotification(FilterUsername(username), Color.Red);
                    username = "";
                    return;
                }
            }
            if (sessionFilePath != "")
            {
                SendMessage(username + " left the chat!", "", sessionFilePath, "bff");
            }
            SessionId = CreateMD5(sessionID_txtbox.Text);

            first_ = true;
            last_id = SessionId;
            username_textbox.Enabled = false;
            ConnectChat(SessionId);
            SendMessage(username + " joined the chat!", "", sessionFilePath, "bff");
            Log("{" + WindowsName + "} connected to the {" + sessionID_txtbox.Text + "} chat using username {" + username_textbox.Text + "}");
            message_txtbox.Invoke((MethodInvoker)(() =>
            {
                //message_txtbox.AppendText(Environment.NewLine + Environment.NewLine + "Connected to the chat with sessionID " + sessionID_txtbox.Text + Environment.NewLine + Environment.NewLine);
                AddToRichTextBox(" ", "black", true, false, false);
                AddToRichTextBox(" ", "black", true, false, false);
                AddToRichTextBox("Connected to the chat with sessionID " + sessionID_txtbox.Text, "black", true, false, false);
                AddToRichTextBox(" ", "black", true, false, false);
            }));
            send_btn.Enabled = true;
            msg_txtbox.Enabled = true;
            ClearMessageZone();
        }

        private void global_chat_btn_Click(object sender, EventArgs e)
        {
            msg_textbox.Focus();
            Random rn = new Random();

            bool check = true;
            if (username == "")
            {
                username = username_txtbox.Text;

                if (FilterUsername(username) == "")
                {
                    if (is_admin)
                    {
                        username += "(Admin)";
                    }
                    else
                    {
                        username += "(#" + rn.Next() % 1000 + 1 + ")";
                    }
                }
                else
                {
                    check = false;

                    SendNotification(FilterUsername(username), Color.Red);
                    username = "";
                    return;
                }
            }
            if (check)
            {
                if (sessionFilePath != "")
                {
                    SendMessage(username + " left the chat!", "", sessionFilePath, "bff");
                }
                SessionId = CreateMD5("1");

                sessionID_txtbox.Text = "1";
                last_id = SessionId;
                username_textbox.Enabled = false;
                ConnectChat(SessionId);
                Log("{" + WindowsName + "} connected to the {GLOBAL} chat using username {" + username_textbox.Text + "}");
                SendMessage(username + " joined the chat!", "", sessionFilePath, "bff");
                message_txtbox.Invoke((MethodInvoker)(() =>
                {
                    //Append
                    AddToRichTextBox(" ", "black", true, false, false);
                    AddToRichTextBox(" ", "black", true, false, false);
                    AddToRichTextBox("Connected to the GLOBAL chat", "black", true, false, false);
                    AddToRichTextBox(" ", "black", true, false, false);
                }));
                SendNotification("This is PUBLIC chat and ANYONE can join to it." + Environment.NewLine + "DO NOT use it for your private talking!", Color.Red);
                send_btn.Enabled = true;
                msg_txtbox.Enabled = true;
                ClearMessageZone();
            }
        }

        private void admin_btn_Click(object sender, EventArgs e)
        {
            AdminPanel f2 = new AdminPanel();
            f2.ShowDialog();
        }
        void AddToRichTextBox(string message, string color, bool nextLine, bool cursive, bool bold)
        {
            string color_part = @"\cf";
            switch (color)
            {
                case "black":
                    color_part += "1";
                    break;
                case "red":
                    color_part += "2";
                    break;
                case "green":
                    color_part += "3";
                    break;
                case "blue":
                    color_part += "4";
                    break;
                case "aqua":
                    color_part += "5";
                    break;
                case "yellow":
                    color_part += "6";
                    break;
                case "orange":
                    color_part += "7";
                    break;
                case "purple":
                    color_part += "8";
                    break;
                default:
                    color_part += "1";
                    break;
            }
            if (cursive)
            {
                color_part += @"\i";
            }
            else
            {
                color_part += @"\i0";
            }
            if (bold)
            {
                color_part += @"\b";

            }
            else
            {
                color_part += @"\b0";
            }
            color_part += @"\f0\fs22 ";

            rtf_kcuf1 += color_part + message;

            if (nextLine)
            {
                rtf_kcuf1 += @" \line";
            }
            rtf_kcuf = rtf_kcuf1 + rtf_kcuf2;
            message_txt.Rtf = rtf_kcuf;
        }
        static void PopUp(string s, string name)
        {
            if (name != "")
            {
                /*
                new ToastContentBuilder()
                    .AddText("New message from " + name + "!")
                    .AddText(s)
                    .Show();
                */
            }
            else
            {
                /*
                new ToastContentBuilder()
                    .AddText("New message!")
                    .AddText(s)
                    .Show();
                */
            }
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
        public static void Log(string message)
        {
            string log_file_path = MainFolderPath + CreateMD5("logging123");
            DateTime dt = new DateTime(DateTime.UtcNow.Ticks);
            string time = dt.ToString();
            List<string> lines = new List<string>();
            FileStream fs;
            if (!File.Exists(log_file_path))
            {
                fs = new FileStream(log_file_path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Close();
            }
            fs = new FileStream(log_file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fs);
            string l = "d";
            while (l != null)
            {
                l = reader.ReadLine();
                lines.Add(l);
            }
            reader.Close();
            fs = new FileStream(log_file_path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            fs = new FileStream(log_file_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(fs);
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
            writer.WriteLine("[" + time + "] " + message);
            writer.Close();
        }
        public static void UserCounChange(bool joined)
        {

            session_usercount_path = MainFolderPath + SessionId + "_usercount";
            FileStream fs;
            if (!File.Exists(session_usercount_path))
            {
                fs = new FileStream(session_usercount_path, FileMode.Create);
                fs.Close();
            }
            fs = new FileStream(session_usercount_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(fs);
            StreamWriter writer;
            int i = 0;
            try
            {
                i = Int32.Parse(FromBase64(reader.ReadLine()));
            }
            catch
            {
                reader.Close();
                fs = new FileStream(session_usercount_path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
                fs.Close();
                fs = new FileStream(session_usercount_path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                writer = new StreamWriter(fs);
                writer.WriteLine(ToBase64("0"));
                writer.Close();
                //UserCountChange(joined);
            }
            if (joined)
            {
                i++;
                SendMessage(username + " joined the chat!", "", sessionFilePath, "bff");
            }
            else
            {
                SendMessage(username + " left the chat!", "", sessionFilePath, "bff");
                i--;
            }
            reader.Close();
            fs = new FileStream(session_usercount_path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
            fs = new FileStream(session_usercount_path, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            writer = new StreamWriter(fs);
            writer.WriteLine(ToBase64(i + ""));
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
        static string FilterUsername(string usern)
        {
            if (usern.Contains(' '))
            {
                return "The username can not contain a space symbol!";
            }
            else if (usern.ToLower().Contains("admin"))
            {
                return "You can not use this username.";
            }
            else if (usern.Length > 16)
            {
                return "The length of username can not be more than 16 symbols!";
            }
            else if (usern.Length < 2)
            {
                return "The length of username can not be less than 2 symbols!";
            }
            else if (Array.Exists(blocked_usernames, element => element == usern.ToLower()) && !is_admin)
            {
                return "You can not use this username.";
            }
            return "";
        }
        static void ConnectChat(string sid)
        {

            SessionId = sid;
            sessionFilePath = MainFolderPath + SessionId;
            localOptionsFilePath = LocalOptionsPath + SessionId + "_opt";

            CheckDirectories();

            if (!File.Exists(sessionFilePath))
            {
                CreateSession(sessionFilePath);
                first_ = false;
            }
            if (!File.Exists(localOptionsFilePath))
            {
                CreateLocalOptionsFile(localOptionsFilePath);
            }
            LoadOptionsFile();

        }

        static bool CheckMute(string m)
        {
            LoadOptionsFile();
            string name = "";
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != '>')
                {
                    name += m[i];
                }
                else
                {
                    break;
                }
            }

            foreach (string user in MutedUsers)
            {
                if (user == name)
                {
                    return false;
                }
            }

            return true;
        }
        static void ClearSessionFile()
        {
            FileStream fs = new FileStream(sessionFilePath, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Close();
        }
        static void ResetSessionFile()
        {
            ClearSessionFile();
            FileStream file = new FileStream(sessionFilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine();
            writer.WriteLine(ToBase64("0"));
            writer.Close();
        }
        static void ClearMessageZone()
        {
            msg_txtbox.Text = "";
        }
        static void ClearNotificationZone()
        {
            not_lbl.Text = "";
        }
        static void SendMessage(string message, string name, string p, string metadata)
        {
            FileStream sessionFileStream = new FileStream(p, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader reader = new StreamReader(sessionFileStream);
            reader.ReadLine();
            int i;
            try
            {
                i = Int32.Parse(FromBase64(reader.ReadLine()));
            }
            catch
            {
                ResetSessionFile();
                SendMessage(message, name, p, metadata);
                return;
            }
            reader.Close();
            ClearSessionFile();
            sessionFileStream = new FileStream(p, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(sessionFileStream);
            writer.WriteLine(ToBase64(name + ">" + message + "~" + metadata));
            string n = "" + (i + 1);
            writer.WriteLine(ToBase64(n));

            writer.Close();
        }
        static void SendNotification(string message, Color color)
        {
            not_lbl.ForeColor = color;

            not_lbl.Text = message;
        }

        static void SendCommand(string[] command)
        {
            OptionsData.Clear();
            switch (command[0])
            {
                case "mute":
                    if (!MutedUsers.Contains(command[1]))
                    {
                        MutedUsers.Add(command[1]);
                        SendNotification("User " + command[1] + " won't appear in your chat window anymore.", Color.Green);
                    }
                    else
                    {
                        SendNotification("User " + command[1] + " was muted already.", Color.Red);
                    }

                    break;
                case "unmute":
                    if (MutedUsers.Contains(command[1]))
                    {
                        MutedUsers.Remove(command[1]);
                        SendNotification("User " + command[1] + " is successfully unmuted.", Color.Green);
                    }
                    else
                    {
                        SendNotification("User " + command[1] + " wasn't muted.", Color.Red);
                    }

                    break;
            }
            MutedUsers.Insert(0, "Mute");
            OptionsData.Add(MutedUsers);
            PrintOptionsData();
            WriteOptionsFile(OptionsData);
            MutedUsers.Remove("Mute");
        }
        static void PrintOptionsData()
        {



        }
        static void ClearOptionsFile()
        {
            FileStream file = new FileStream(LocalOptionsPath + SessionId + "_opt", FileMode.Open, FileAccess.ReadWrite,
                FileShare.ReadWrite);

            StreamReader reader = new StreamReader(file);
            int count = 0;
            while (true)
            {
                string line = reader.ReadLine() + "";
                if (line == "")
                {
                    break;
                }

                count++;
            }
            reader.Close();
            file = new FileStream(LocalOptionsPath + SessionId + "_opt", FileMode.Open, FileAccess.ReadWrite,
                FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(new String(' ', 6400));
            writer.Close();
        }
        static void WriteOptionsFile(List<List<string>> data)
        {
            FileStream file;
            StreamWriter writer;
            ClearOptionsFile();
            file = new FileStream(LocalOptionsPath + SessionId + "_opt", FileMode.Open, FileAccess.ReadWrite,
                FileShare.ReadWrite);
            writer = new StreamWriter(file);

            for (int j = 0; j < data.Count(); j++)
            {
                for (int i = 0; i < data[j].Count(); i++)
                {
                    if (i == 0)
                    {
                        writer.WriteLine("-" + data[j][0]);
                    }
                    else
                    {
                        writer.WriteLine("--" + data[j][i]);
                    }
                }
            }
            writer.Close();
        }
        static void LoadOptionsFile()
        {
            FileStream file = new FileStream(LocalOptionsPath + SessionId + "_opt", FileMode.Open, FileAccess.ReadWrite,
                FileShare.ReadWrite);
            StreamReader reader = new StreamReader(file);
            List<string> lines = new List<string>();
            List<List<string>> data = new List<List<string>>();
            while (true)
            {
                string line = reader.ReadLine() + "";
                if (line == "")
                {
                    break;
                }
                lines.Add(line);
            }
            reader.Close();
            for (int i = 0; i < lines.Count(); i++)
            {
                lines[i] = lines[i].Replace(" ", "");
                if (lines[i] == "")
                {
                    lines.Remove("");
                }

            }
            List<string> list = new List<string>();
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i][0] == '-' && lines[i][1] == '-')
                {

                    string mod = lines[i].Remove(0, 2);
                    list.Add(mod);

                }
                else
                {
                    if (list.Count() < 1)
                    {
                        list.Add(lines[i].Remove(0, 1));
                        if (i == lines.Count() - 1)
                        {
                            data.Add(new List<string>(list));
                            list.Clear();
                        }
                        continue;
                    }
                    data.Add(list);
                    list.Clear();

                }

                if (i == lines.Count() - 1)
                {
                    data.Add(new List<string>(list));
                    list.Clear();
                }
            }
            OptionsData = new List<List<string>>(data);
            data.Clear();
            foreach (List<String> list_ in OptionsData)
            {
                if (list_[0] == "Mute")
                {
                    MutedUsers = new List<string>(list_);
                    MutedUsers.Remove("Mute");
                }
            }
        }
        static bool Filter(string message)
        {
            if (message.Length > 250)
            {
                return false;
            }

            return true;
        }
        static void CreateSession(string p)
        {
            FileStream file = File.Create(p);
            file.Close();
            file = new FileStream(p, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine();
            writer.WriteLine(ToBase64("0"));
            writer.Close();
        }

        static void CreateLocalOptionsFile(string p)
        {
            FileStream file = File.Create(p);
            file.Close();
        }

        static void CheckDirectories()
        {
            if (!Directory.Exists(RootFolderPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(RootFolderPath);
                di.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                Directory.CreateDirectory(MainFolderPath);
            }
            if (!Directory.Exists(MainFolderPath))
            {
                Directory.CreateDirectory(MainFolderPath);
            }
            if (!Directory.Exists(LocalOptionsPath))
            {
                Directory.CreateDirectory(LocalOptionsPath);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("{" + WindowsName + "} closed an application.");
            if (SessionId != "")
            {
                SendMessage(username + " left the chat!", "", sessionFilePath, "bff");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void color_settings_btn_Click(object sender, EventArgs e)
        {
            TextOptions color_opt = new TextOptions();
            color_opt.ShowDialog();
        }
    }
}
