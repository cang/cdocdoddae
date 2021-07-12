using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestCtrl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.listBar1.Click += new EventHandler(listBar1_Click);
            this.listBar1.ItemClicked += new SiGlaz.Windows.ItemClickedEventHandler(listBar1_ItemClicked);
            this.listBar1.AllowDragGroups = true;
            this.listBar1.AllowDragItems = true;
            this.listBar1.AutoScroll = true;
            this.listBar1.BackColor = System.Drawing.SystemColors.Menu;
            this.listBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.listBar1.DrawStyle = SiGlaz.Windows.ListBarDrawStyle.ListBarDrawStyleOfficeXP;
            this.listBar1.GradientColorEnd = SystemColors.ActiveCaption;// System.Drawing.Color.SkyBlue;
            this.listBar1.GradientColorStart = SystemColors.ControlLight ;//System.Drawing.Color.AliceBlue;
            this.listBar1.HoveredBackground = null;
            this.listBar1.LargeImageList = null;
            this.listBar1.Location = new System.Drawing.Point(0, 36);
            this.listBar1.Name = "listBar1";
            this.listBar1.NormalBackground = null;
            this.listBar1.SelectedBackground = null;
            this.listBar1.SelectedItem = null;
            this.listBar1.SelectOnMouseDown = true;
            this.listBar1.Size = new System.Drawing.Size(156, 458);
            this.listBar1.SmallImageList = null;
            this.listBar1.TabIndex = 0;
            this.listBar1.ToolTip = this.toolTip1;

            ilListbar = new ImageList();
            ilListbar.ColorDepth = ColorDepth.Depth16Bit;
            ilListbar.ImageSize = new Size(32, 32);

            foreach (Image img in i1.Images)
            {
                ilListbar.Images.Add(img);
            }

            //Init group
            listBar1.LargeImageList = this.ilListbar;
            SiGlaz.Windows.ListBarGroup gitem;
            SiGlaz.Windows.ListBarItem item;

            #region Control Block
            gitem = new SiGlaz.Windows.ListBarGroup("Control Block");
            listBar1.Groups.Add(gitem);

            item = new SiGlaz.Windows.ListBarItem("Begin asdjfasjkdgahdf     ddddd", 0, "Begin", null);
            gitem.Items.Add(item);

            item = new SiGlaz.Windows.ListBarItem("End", 1, "End", null);
            gitem.Items.Add(item);

            item = new SiGlaz.Windows.ListBarItem("Decision", 2, "Decision", null);
            gitem.Items.Add(item);
            #endregion Control Block


            //SaveAs(i1, "D:\\gif\\i1");
            //SaveAs(i2, "D:\\gif\\i2");
            //SaveAs(i3, "D:\\gif\\i3");
            //SaveAs(i4, "D:\\gif\\i4");
            //SaveAs(i5, "D:\\gif\\i5");
            //SaveAs(i6, "D:\\gif\\i6");
            //SaveAs(i7, "D:\\gif\\i7");
            //SaveAs(i8, "D:\\gif\\i8");
            //SaveAs(i9, "D:\\gif\\i9");

        }

        void listBar1_ItemClicked(object sender, SiGlaz.Windows.ItemClickedEventArgs e)
        {
            MessageBox.Show(e.Item.Caption);
        }

        void listBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveAs(ImageList il,string path)
        {
            System.IO.Directory.CreateDirectory(path);

            int i =1;
            foreach (Bitmap img in il.Images)
            {
                img.Save(path + "\\" + i++ + ".gif");//, System.Drawing.Imaging.ImageFormat.Gif);
            }
        }


        private void listBar1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            this.listBar1.Dock = DockStyle.Fill;
        }

    }
}
