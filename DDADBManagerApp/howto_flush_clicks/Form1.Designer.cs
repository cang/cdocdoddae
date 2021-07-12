namespace howto_flush_clicks
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWaitAndFlush = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.btnWaitNow = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bbbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWaitAndFlush
            // 
            this.btnWaitAndFlush.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWaitAndFlush.Location = new System.Drawing.Point(564, 12);
            this.btnWaitAndFlush.Name = "btnWaitAndFlush";
            this.btnWaitAndFlush.Size = new System.Drawing.Size(95, 23);
            this.btnWaitAndFlush.TabIndex = 6;
            this.btnWaitAndFlush.Text = "Wait and Flush";
            this.btnWaitAndFlush.UseVisualStyleBackColor = true;
            this.btnWaitAndFlush.Click += new System.EventHandler(this.btnWaitAndFlush_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(12, 42);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(647, 459);
            this.lstMessages.TabIndex = 5;
            // 
            // btnWaitNow
            // 
            this.btnWaitNow.Location = new System.Drawing.Point(96, 13);
            this.btnWaitNow.Name = "btnWaitNow";
            this.btnWaitNow.Size = new System.Drawing.Size(95, 23);
            this.btnWaitNow.TabIndex = 4;
            this.btnWaitNow.Text = "Wait Now";
            this.btnWaitNow.UseVisualStyleBackColor = true;
            this.btnWaitNow.Click += new System.EventHandler(this.btnWaitNow_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(671, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aaaToolStripMenuItem
            // 
            this.aaaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bbbToolStripMenuItem});
            this.aaaToolStripMenuItem.Name = "aaaToolStripMenuItem";
            this.aaaToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.aaaToolStripMenuItem.Text = "aaa";
            // 
            // bbbToolStripMenuItem
            // 
            this.bbbToolStripMenuItem.Name = "bbbToolStripMenuItem";
            this.bbbToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bbbToolStripMenuItem.Text = "bbb";
            this.bbbToolStripMenuItem.Click += new System.EventHandler(this.bbbToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 520);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnWaitAndFlush);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.btnWaitNow);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "howto_flush_clicks";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWaitAndFlush;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.Button btnWaitNow;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bbbToolStripMenuItem;
    }
}

