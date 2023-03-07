using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poriBot
{
    public partial class Form1 : Form
    {
        private bool minimize = true;

        //private int borderSize = 2;

        public Form1()
        {            
            InitializeComponent();
           // this.Padding = new Padding(borderSize);//border size
        }

        //Drag Form
       [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")] 
        private extern static void ReleaseCapture();

       [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DASHBOARDLableTitle_MouseHover(object sender, EventArgs e)
        {
            DASHBOARDLableTitle.ForeColor = Color.Red;
        }

        private void DASHBOARDLableTitle_MouseLeave(object sender, EventArgs e)
        {
            DASHBOARDLableTitle.ForeColor = Color.Black;
        }


        private void SUPPORTLableTitle_MouseHover(object sender, EventArgs e)
        {
            SUPPORTLableTitle.ForeColor = Color.Red;
        }

        private void SUPPORTLableTitle_MouseLeave(object sender, EventArgs e)
        {
            SUPPORTLableTitle.ForeColor = Color.Black;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[1].WorkingArea.Location;
        }

        private void panelTitleBar_DoubleClick(object sender, EventArgs e)
        {
            if (minimize)
            {
                if (WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0X0083;
            if(m.Msg==WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}
