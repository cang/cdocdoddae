using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Security;

namespace howto_flush_clicks
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("User32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool PeekMessage(out NativeMessage message, IntPtr handle, uint filterMin, uint filterMax, uint flags);
        private const UInt32 WM_MOUSEFIRST = 0x0200;
        private const UInt32 WM_MOUSELAST = 0x020D;
        public const int PM_REMOVE = 0x0001;

        // Flush all pending mouse events.
        private void FlushMouseMessages()
        {
            NativeMessage msg;

            // Repeat until PeekMessage returns false.
            int count=0;
            while (PeekMessage(out msg, IntPtr.Zero, WM_MOUSEFIRST, WM_MOUSELAST, PM_REMOVE))
            {
                count++;
            }
            System.Diagnostics.Debug.WriteLine(count);
        }

        public Form1()
        {
            InitializeComponent();
        }

        // Wait for 5 seconds.
        private void btnWaitNow_Click(object sender, EventArgs e)
        {
            // None of these seem to work.
            //this.Enabled = false;
            //btnWaitNow.Click -= btnWaitNow_Click;
            btnWaitNow.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            lstMessages.Items.Add("Wait Now Start " + DateTime.Now.ToString());
            Refresh();
            System.Threading.Thread.Sleep(5000);
            lstMessages.Items.Add("Wait Now Stop  " + DateTime.Now.ToString());

            //this.Enabled = true;
            //btnWaitNow.Click += btnWaitNow_Click;
            btnWaitNow.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        // Wait for 5 seconds and then flush the buffer.
        private void btnWaitAndFlush_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lstMessages.Items.Add("Wait and Flush Start " + DateTime.Now.ToString());
            Refresh();

            System.Threading.Thread.Sleep(5000);

            lstMessages.Items.Add("Wait and Flush Stop  " + DateTime.Now.ToString());
            FlushMouseMessages();
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1_Click");
        }

        private void bbbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bbbToolStripMenuItem_Click");
        }
    }
}
