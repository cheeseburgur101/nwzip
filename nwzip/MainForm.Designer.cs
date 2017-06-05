/*
 * Created by SharpDevelop.
 * User: nrgil
 * Date: 2017-05-23
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nwzip
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewFile;
		private System.Windows.Forms.ToolStripMenuItem OpenFile;
		private System.Windows.Forms.ToolStripMenuItem SaveFile;
		private System.Windows.Forms.ToolStripMenuItem SaveAsFile;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem archiveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddFile;
		private System.Windows.Forms.ToolStripMenuItem ArchiveEncryption;
		private System.Windows.Forms.ToolStripMenuItem ArchiveDetails;
		private System.Windows.Forms.ToolStripMenuItem nWZipToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem installToolStripMenuItem;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openRecentToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem clearRecentFilesToolStripMenuItem;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
			this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddFile = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ArchiveEncryption = new System.Windows.Forms.ToolStripMenuItem();
			this.ArchiveDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.nWZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.clearRecentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.editToolStripMenuItem,
			this.viewToolStripMenuItem,
			this.archiveToolStripMenuItem,
			this.nWZipToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(900, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.NewFile,
			this.toolStripMenuItem1,
			this.OpenFile,
			this.openRecentToolStripMenuItem,
			this.toolStripMenuItem2,
			this.SaveFile,
			this.SaveAsFile,
			this.toolStripMenuItem3,
			this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// NewFile
			// 
			this.NewFile.Name = "NewFile";
			this.NewFile.ShortcutKeyDisplayString = "Ctrl+N";
			this.NewFile.Size = new System.Drawing.Size(162, 22);
			this.NewFile.Text = "&New";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(159, 6);
			// 
			// OpenFile
			// 
			this.OpenFile.Name = "OpenFile";
			this.OpenFile.ShortcutKeyDisplayString = "Ctrl+O";
			this.OpenFile.Size = new System.Drawing.Size(162, 22);
			this.OpenFile.Text = "&Open";
			// 
			// openRecentToolStripMenuItem
			// 
			this.openRecentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.noneToolStripMenuItem,
			this.toolStripMenuItem5,
			this.clearRecentFilesToolStripMenuItem});
			this.openRecentToolStripMenuItem.Name = "openRecentToolStripMenuItem";
			this.openRecentToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.openRecentToolStripMenuItem.Text = "O&pen Recent";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(159, 6);
			// 
			// SaveFile
			// 
			this.SaveFile.Name = "SaveFile";
			this.SaveFile.ShortcutKeyDisplayString = "Ctrl+S";
			this.SaveFile.Size = new System.Drawing.Size(162, 22);
			this.SaveFile.Text = "&Save";
			// 
			// SaveAsFile
			// 
			this.SaveAsFile.Name = "SaveAsFile";
			this.SaveAsFile.Size = new System.Drawing.Size(162, 22);
			this.SaveAsFile.Text = "S&ave As...";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(159, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+Q";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.AddFile});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.editToolStripMenuItem.Text = "Edit";
			// 
			// AddFile
			// 
			this.AddFile.Name = "AddFile";
			this.AddFile.Size = new System.Drawing.Size(175, 22);
			this.AddFile.Text = "&Add File to archive...";
			this.AddFile.Click += new System.EventHandler(this.AddFileClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// archiveToolStripMenuItem
			// 
			this.archiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ArchiveEncryption,
			this.toolStripMenuItem4,
			this.ArchiveDetails});
			this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
			this.archiveToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.archiveToolStripMenuItem.Text = "Archive";
			// 
			// ArchiveEncryption
			// 
			this.ArchiveEncryption.Name = "ArchiveEncryption";
			this.ArchiveEncryption.Size = new System.Drawing.Size(152, 22);
			this.ArchiveEncryption.Text = "&Encryption";
			this.ArchiveEncryption.Click += new System.EventHandler(this.ArchiveEncryptionClick);
			// 
			// ArchiveDetails
			// 
			this.ArchiveDetails.Name = "ArchiveDetails";
			this.ArchiveDetails.Size = new System.Drawing.Size(152, 22);
			this.ArchiveDetails.Text = "&Details";
			this.ArchiveDetails.Click += new System.EventHandler(this.ArchiveDetailsClick);
			// 
			// nWZipToolStripMenuItem
			// 
			this.nWZipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.installToolStripMenuItem});
			this.nWZipToolStripMenuItem.Name = "nWZipToolStripMenuItem";
			this.nWZipToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.nWZipToolStripMenuItem.Text = "NWZip";
			// 
			// installToolStripMenuItem
			// 
			this.installToolStripMenuItem.Name = "installToolStripMenuItem";
			this.installToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.installToolStripMenuItem.Text = "&Install...";
			this.installToolStripMenuItem.Click += new System.EventHandler(this.InstallToolStripMenuItemClick);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
			// 
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Enabled = false;
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.noneToolStripMenuItem.Text = "(none)";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(157, 6);
			// 
			// clearRecentFilesToolStripMenuItem
			// 
			this.clearRecentFilesToolStripMenuItem.Name = "clearRecentFilesToolStripMenuItem";
			this.clearRecentFilesToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.clearRecentFilesToolStripMenuItem.Text = "Clear Recent Files";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 457);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NWZip Version 0.0.3";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
