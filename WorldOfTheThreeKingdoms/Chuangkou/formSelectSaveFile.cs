﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

using		GameObjects;

using		System.Data;
using		System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;
using System.Data.OleDb;




namespace WorldOfTheThreeKingdoms.GameForms

{
    public class formSelectSaveFile : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private ContextMenuStrip cmsDelete;
        private IContainer components = null;
        private ListBox lbSaveFiles;
        public string SaveFilePath;
        private List<string> SaveFilePaths = new List<string>();
        private ToolStripMenuItem 删除存档ToolStripMenuItem;
        private PictureBox pictureBox1;
        private ToolStripMenuItem 删除所有存档ToolStripMenuItem;

        public formSelectSaveFile()
        {
            this.InitializeComponent();
        }

        private void btnOK_MouseEnter(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/SaveSelect/Select.wav");
            player.Play();
            this.btnOK.BackgroundImage = Image.FromFile("Resources/SaveSelect/OKButtonSelected.png");
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            this.btnOK.BackgroundImage = Image.FromFile("Resources/SaveSelect/OKButton.png");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/SaveSelect/Open.wav");
            player.Play();
            if (this.lbSaveFiles.SelectedIndex >= 0)
            {
                this.SaveFilePath = this.SaveFilePaths[this.lbSaveFiles.SelectedIndex];
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择存档。");
            }
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void formSelectSaveFile_MouseClick(object sender, MouseEventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/SaveSelect/OK.wav");
            player.Play();
            if (e.Button == MouseButtons.Right)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_MouseEnter(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/SaveSelect/Select.wav");
            player.Play();
            this.btnCancel.BackgroundImage = Image.FromFile("Resources/SaveSelect/CancelButtonSelected.png");
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            this.btnCancel.BackgroundImage = Image.FromFile("Resources/SaveSelect/CancelButton.png");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("Resources/SaveSelect/NO.wav");
            player.Play();
            base.DialogResult = DialogResult.No;
        }

        private void frmSelectSaveFile_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = Image.FromFile("Resources/SaveSelect/LOGO.png");
            this.btnOK.BackgroundImage = Image.FromFile("Resources/SaveSelect/OKButton.png");
            this.btnCancel.BackgroundImage = Image.FromFile("Resources/SaveSelect/CancelButton.png");
            this.BackgroundImage = Image.FromFile("Resources/SaveSelect/Background.jpg");
            this.RefreshSaveFiles();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbSaveFiles = new System.Windows.Forms.ListBox();
            this.cmsDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除存档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除所有存档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(518, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.btnCancel_MouseEnter);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(399, 382);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 30);
            this.btnOK.TabIndex = 4;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseEnter += new System.EventHandler(this.btnOK_MouseEnter);
            // 
            // lbSaveFiles
            // 
            this.lbSaveFiles.ContextMenuStrip = this.cmsDelete;
            this.lbSaveFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbSaveFiles.Font = new System.Drawing.Font("宋体", 9F);
            this.lbSaveFiles.FormattingEnabled = true;
            this.lbSaveFiles.ItemHeight = 16;
            this.lbSaveFiles.Location = new System.Drawing.Point(12, 12);
            this.lbSaveFiles.Name = "lbSaveFiles";
            this.lbSaveFiles.Size = new System.Drawing.Size(606, 364);
            this.lbSaveFiles.TabIndex = 6;
            this.lbSaveFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSaveFiles_MouseDoubleClick);
            this.lbSaveFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbSaveFiles_DrawItem);
            this.lbSaveFiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formSelectSaveFile_MouseClick);
            // 
            // cmsDelete
            // 
            this.cmsDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除存档ToolStripMenuItem,
            this.删除所有存档ToolStripMenuItem});
            this.cmsDelete.Name = "cmsDelete";
            this.cmsDelete.Size = new System.Drawing.Size(149, 48);
            // 
            // 删除存档ToolStripMenuItem
            // 
            this.删除存档ToolStripMenuItem.Name = "删除存档ToolStripMenuItem";
            this.删除存档ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除存档ToolStripMenuItem.Text = "删除存档";
            this.删除存档ToolStripMenuItem.Click += new System.EventHandler(this.删除存档ToolStripMenuItem_Click);
            // 
            // 删除所有存档ToolStripMenuItem
            // 
            this.删除所有存档ToolStripMenuItem.Name = "删除所有存档ToolStripMenuItem";
            this.删除所有存档ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除所有存档ToolStripMenuItem.Text = "删除所有存档";
            this.删除所有存档ToolStripMenuItem.Click += new System.EventHandler(this.删除所有存档ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 382);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(355, 30);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // formSelectSaveFile
            // 
            this.ClientSize = new System.Drawing.Size(630, 425);
            this.Controls.Add(this.lbSaveFiles);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSelectSaveFile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择存档";
            this.Load += new System.EventHandler(this.frmSelectSaveFile_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.formSelectSaveFile_MouseClick);
            this.cmsDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void lbSaveFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lbSaveFiles.SelectedIndex >= 0)
            {
                this.SaveFilePath = this.SaveFilePaths[this.lbSaveFiles.SelectedIndex];
                base.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择存档。");
            }
        }

        private void ReadSaveFile(string fileName)
        {
            string str = "GameData/Save/";
            if (File.Exists(str + fileName))
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = str + fileName,
                    Provider = "Microsoft.Jet.OLEDB.4.0"
                };
                this.lbSaveFiles.Items.Add(fileName+"  "+GameScenario.GetGameSaveFileSurveyText(builder.ConnectionString));
                this.SaveFilePaths.Add(fileName);
            }
        }

        private void RefreshSaveFiles()
        {
            this.SaveFilePaths.Clear();
            this.lbSaveFiles.Items.Clear();

            this.ReadSaveFile("Save01.mdb");
            this.ReadSaveFile("Save02.mdb");
            this.ReadSaveFile("Save03.mdb");
            this.ReadSaveFile("Save04.mdb");
            this.ReadSaveFile("Save05.mdb");
            this.ReadSaveFile("Save06.mdb");
            this.ReadSaveFile("Save07.mdb");
            this.ReadSaveFile("Save08.mdb");
            this.ReadSaveFile("Save09.mdb");
            this.ReadSaveFile("Save10.mdb");
            this.ReadSaveFile("AutoSave.mdb");
            this.ReadSaveFile("QuitSave.mdb");

            this.ReadSaveFile("Save01.zhs");
            this.ReadSaveFile("Save02.zhs");
            this.ReadSaveFile("Save03.zhs");
            this.ReadSaveFile("Save04.zhs");
            this.ReadSaveFile("Save05.zhs");
            this.ReadSaveFile("Save06.zhs");
            this.ReadSaveFile("Save07.zhs");
            this.ReadSaveFile("Save08.zhs");
            this.ReadSaveFile("Save09.zhs");
            this.ReadSaveFile("Save10.zhs");
            this.ReadSaveFile("AutoSave.zhs");
            this.ReadSaveFile("QuitSave.zhs");
        }

        private void 删除存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lbSaveFiles.SelectedIndex >= 0)
            {
                File.Delete("GameData/Save/" + this.SaveFilePaths[this.lbSaveFiles.SelectedIndex]);
                this.RefreshSaveFiles();
            }
        }

        private void 删除所有存档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.lbSaveFiles.Items.Count != 0) && (MessageBox.Show("删除所有存档？", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK))
            {
                foreach (string str in this.SaveFilePaths)
                {
                    File.Delete("GameData/Save/" + str);
                }
                this.RefreshSaveFiles();
            }
        }

        private void lbSaveFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            // 临时修复，e.Index返回-1的具体原因不明
            if (e.Index != -1)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                StringFormat strFmt = new System.Drawing.StringFormat();
                strFmt.Alignment = StringAlignment.Near ; //文本垂直居中
                strFmt.LineAlignment = StringAlignment.Center ; //文本水平居中
                e.Graphics.DrawString(lbSaveFiles.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds, strFmt);
            }
        }
    }

 

}
