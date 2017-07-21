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
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TextBox txtNavigate;
		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem addFolderToArchiveToolStripMenuItem;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Label lblDirectoryHierarchy;
		private System.Windows.Forms.Button btnAddFolder;
		private System.Windows.Forms.Button btnAddFile;
		private System.Windows.Forms.Button btnExtract;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ContextMenuStrip contextMenuTreeView;
		private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ContextMenuStrip contextMenuListView;
		private System.Windows.Forms.ToolStripMenuItem deleteFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteFolderToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem recursiveRecommendedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem onlyIfEmptyToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem sizeModifiersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bytesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem perKilobyteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem perKilobyteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem wholeArchiveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem currentDirectoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectedFileToolStripMenuItem;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.ToolStripMenuItem recursivelyRecommendedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem onlyIfEmptyToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
		private System.Windows.Forms.Button btnUpOne;
		
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("/");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
			this.openRecentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.clearRecentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveAsFile = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddFile = new System.Windows.Forms.ToolStripMenuItem();
			this.addFolderToArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ArchiveEncryption = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.ArchiveDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.nWZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.installToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.contextMenuListView = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.wholeArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.currentDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.recursiveRecommendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onlyIfEmptyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
			this.sizeModifiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bytesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.perKilobyteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.perKilobyteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.txtNavigate = new System.Windows.Forms.TextBox();
			this.btnGo = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recursivelyRecommendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.onlyIfEmptyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.lblDirectoryHierarchy = new System.Windows.Forms.Label();
			this.btnUpOne = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.btnExtract = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnAddFolder = new System.Windows.Forms.Button();
			this.btnAddFile = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.menuStrip1.SuspendLayout();
			this.contextMenuListView.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.contextMenuTreeView.SuspendLayout();
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
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// NewFile
			// 
			this.NewFile.Name = "NewFile";
			this.NewFile.ShortcutKeyDisplayString = "Ctrl+N";
			this.NewFile.Size = new System.Drawing.Size(162, 22);
			this.NewFile.Text = "&New";
			this.NewFile.Click += new System.EventHandler(this.NewFileClick);
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
			this.OpenFile.Click += new System.EventHandler(this.OpenFileClick);
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
			// noneToolStripMenuItem
			// 
			this.noneToolStripMenuItem.Enabled = false;
			this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
			this.noneToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.noneToolStripMenuItem.Text = "(none)";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(177, 6);
			// 
			// clearRecentFilesToolStripMenuItem
			// 
			this.clearRecentFilesToolStripMenuItem.Name = "clearRecentFilesToolStripMenuItem";
			this.clearRecentFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.clearRecentFilesToolStripMenuItem.Text = "Clear Recent Archives";
			this.clearRecentFilesToolStripMenuItem.Click += new System.EventHandler(this.ClearRecentFilesToolStripMenuItemClick);
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
			this.SaveFile.Click += new System.EventHandler(this.SaveFileClick);
			// 
			// SaveAsFile
			// 
			this.SaveAsFile.Name = "SaveAsFile";
			this.SaveAsFile.Size = new System.Drawing.Size(162, 22);
			this.SaveAsFile.Text = "S&ave As...";
			this.SaveAsFile.Click += new System.EventHandler(this.SaveAsFileClick);
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
			this.AddFile,
			this.addFolderToArchiveToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// AddFile
			// 
			this.AddFile.Name = "AddFile";
			this.AddFile.Size = new System.Drawing.Size(189, 22);
			this.AddFile.Text = "&Add File to archive...";
			this.AddFile.Click += new System.EventHandler(this.AddFileClick);
			// 
			// addFolderToArchiveToolStripMenuItem
			// 
			this.addFolderToArchiveToolStripMenuItem.Name = "addFolderToArchiveToolStripMenuItem";
			this.addFolderToArchiveToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
			this.addFolderToArchiveToolStripMenuItem.Text = "Add &Folder to archive...";
			this.addFolderToArchiveToolStripMenuItem.Click += new System.EventHandler(this.AddFolderToArchiveToolStripMenuItemClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// archiveToolStripMenuItem
			// 
			this.archiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ArchiveEncryption,
			this.toolStripMenuItem4,
			this.ArchiveDetails});
			this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
			this.archiveToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.archiveToolStripMenuItem.Text = "&Archive";
			// 
			// ArchiveEncryption
			// 
			this.ArchiveEncryption.Name = "ArchiveEncryption";
			this.ArchiveEncryption.Size = new System.Drawing.Size(125, 22);
			this.ArchiveEncryption.Text = "&Encryption";
			this.ArchiveEncryption.Click += new System.EventHandler(this.ArchiveEncryptionClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(122, 6);
			// 
			// ArchiveDetails
			// 
			this.ArchiveDetails.Name = "ArchiveDetails";
			this.ArchiveDetails.Size = new System.Drawing.Size(125, 22);
			this.ArchiveDetails.Text = "&Details";
			this.ArchiveDetails.Click += new System.EventHandler(this.ArchiveDetailsClick);
			// 
			// nWZipToolStripMenuItem
			// 
			this.nWZipToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.installToolStripMenuItem});
			this.nWZipToolStripMenuItem.Name = "nWZipToolStripMenuItem";
			this.nWZipToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
			this.nWZipToolStripMenuItem.Text = "&NWZip";
			// 
			// installToolStripMenuItem
			// 
			this.installToolStripMenuItem.Name = "installToolStripMenuItem";
			this.installToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.installToolStripMenuItem.Text = "&Install...";
			this.installToolStripMenuItem.Click += new System.EventHandler(this.InstallToolStripMenuItemClick);
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3});
			this.listView1.ContextMenuStrip = this.contextMenuListView;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(14, 52);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(665, 374);
			this.listView1.TabIndex = 9;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.ListView1DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 250;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 150;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Size";
			this.columnHeader3.Width = 90;
			// 
			// contextMenuListView
			// 
			this.contextMenuListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.extractToolStripMenuItem,
			this.toolStripMenuItem9,
			this.deleteFileToolStripMenuItem,
			this.deleteFolderToolStripMenuItem1,
			this.toolStripMenuItem6,
			this.renameToolStripMenuItem,
			this.toolStripMenuItem7,
			this.propertiesToolStripMenuItem,
			this.toolStripMenuItem8,
			this.sizeModifiersToolStripMenuItem});
			this.contextMenuListView.Name = "contextMenuListView";
			this.contextMenuListView.Size = new System.Drawing.Size(205, 160);
			// 
			// extractToolStripMenuItem
			// 
			this.extractToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.wholeArchiveToolStripMenuItem,
			this.currentDirectoryToolStripMenuItem,
			this.selectedFileToolStripMenuItem});
			this.extractToolStripMenuItem.Name = "extractToolStripMenuItem";
			this.extractToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.extractToolStripMenuItem.Text = "Extract";
			// 
			// wholeArchiveToolStripMenuItem
			// 
			this.wholeArchiveToolStripMenuItem.Name = "wholeArchiveToolStripMenuItem";
			this.wholeArchiveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.wholeArchiveToolStripMenuItem.Text = "Whole Archive";
			this.wholeArchiveToolStripMenuItem.Click += new System.EventHandler(this.WholeArchiveToolStripMenuItemClick);
			// 
			// currentDirectoryToolStripMenuItem
			// 
			this.currentDirectoryToolStripMenuItem.Name = "currentDirectoryToolStripMenuItem";
			this.currentDirectoryToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.currentDirectoryToolStripMenuItem.Text = "Current Directory";
			this.currentDirectoryToolStripMenuItem.Click += new System.EventHandler(this.CurrentDirectoryToolStripMenuItemClick);
			// 
			// selectedFileToolStripMenuItem
			// 
			this.selectedFileToolStripMenuItem.Name = "selectedFileToolStripMenuItem";
			this.selectedFileToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.selectedFileToolStripMenuItem.Text = "Selected File";
			this.selectedFileToolStripMenuItem.Click += new System.EventHandler(this.SelectedFileToolStripMenuItemClick);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(201, 6);
			// 
			// deleteFileToolStripMenuItem
			// 
			this.deleteFileToolStripMenuItem.Name = "deleteFileToolStripMenuItem";
			this.deleteFileToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.deleteFileToolStripMenuItem.Text = "Delete File";
			this.deleteFileToolStripMenuItem.Click += new System.EventHandler(this.DeleteFileToolStripMenuItemClick);
			// 
			// deleteFolderToolStripMenuItem1
			// 
			this.deleteFolderToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.recursiveRecommendedToolStripMenuItem,
			this.onlyIfEmptyToolStripMenuItem});
			this.deleteFolderToolStripMenuItem1.Name = "deleteFolderToolStripMenuItem1";
			this.deleteFolderToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
			this.deleteFolderToolStripMenuItem1.Text = "Delete Folder [Recursively]";
			this.deleteFolderToolStripMenuItem1.Click += new System.EventHandler(this.DeleteFolderToolStripMenuItem1Click);
			// 
			// recursiveRecommendedToolStripMenuItem
			// 
			this.recursiveRecommendedToolStripMenuItem.Name = "recursiveRecommendedToolStripMenuItem";
			this.recursiveRecommendedToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.recursiveRecommendedToolStripMenuItem.Text = "Recursively (Recommended)";
			this.recursiveRecommendedToolStripMenuItem.Click += new System.EventHandler(this.RecursiveRecommendedToolStripMenuItemClick);
			// 
			// onlyIfEmptyToolStripMenuItem
			// 
			this.onlyIfEmptyToolStripMenuItem.Name = "onlyIfEmptyToolStripMenuItem";
			this.onlyIfEmptyToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.onlyIfEmptyToolStripMenuItem.Text = "Only if Empty";
			this.onlyIfEmptyToolStripMenuItem.Click += new System.EventHandler(this.OnlyIfEmptyToolStripMenuItemClick);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(201, 6);
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			this.renameToolStripMenuItem.Click += new System.EventHandler(this.RenameToolStripMenuItemClick);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(201, 6);
			// 
			// propertiesToolStripMenuItem
			// 
			this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
			this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.propertiesToolStripMenuItem.Text = "Properties";
			this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.PropertiesToolStripMenuItemClick);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(201, 6);
			// 
			// sizeModifiersToolStripMenuItem
			// 
			this.sizeModifiersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.bytesToolStripMenuItem,
			this.perKilobyteToolStripMenuItem,
			this.perKilobyteToolStripMenuItem1});
			this.sizeModifiersToolStripMenuItem.Name = "sizeModifiersToolStripMenuItem";
			this.sizeModifiersToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.sizeModifiersToolStripMenuItem.Text = "Size Modifiers";
			// 
			// bytesToolStripMenuItem
			// 
			this.bytesToolStripMenuItem.Name = "bytesToolStripMenuItem";
			this.bytesToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.bytesToolStripMenuItem.Text = "Raw Bytes";
			this.bytesToolStripMenuItem.Click += new System.EventHandler(this.BytesToolStripMenuItemClick);
			// 
			// perKilobyteToolStripMenuItem
			// 
			this.perKilobyteToolStripMenuItem.Name = "perKilobyteToolStripMenuItem";
			this.perKilobyteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.perKilobyteToolStripMenuItem.Text = "1000b = 1Kb";
			this.perKilobyteToolStripMenuItem.Click += new System.EventHandler(this.PerKilobyteToolStripMenuItemClick);
			// 
			// perKilobyteToolStripMenuItem1
			// 
			this.perKilobyteToolStripMenuItem1.Checked = true;
			this.perKilobyteToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.perKilobyteToolStripMenuItem1.Name = "perKilobyteToolStripMenuItem1";
			this.perKilobyteToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
			this.perKilobyteToolStripMenuItem1.Text = "1024b = 1Kb";
			this.perKilobyteToolStripMenuItem1.Click += new System.EventHandler(this.PerKilobyteToolStripMenuItem1Click);
			// 
			// txtNavigate
			// 
			this.txtNavigate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtNavigate.Location = new System.Drawing.Point(61, 26);
			this.txtNavigate.Name = "txtNavigate";
			this.txtNavigate.Size = new System.Drawing.Size(535, 20);
			this.txtNavigate.TabIndex = 0;
			this.txtNavigate.Text = "/";
			this.txtNavigate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNavigateKeyPress);
			// 
			// btnGo
			// 
			this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGo.Location = new System.Drawing.Point(604, 25);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(75, 23);
			this.btnGo.TabIndex = 1;
			this.btnGo.Text = "Go";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.BtnGoClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			this.splitContainer1.Panel1.Controls.Add(this.lblDirectoryHierarchy);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btnUpOne);
			this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
			this.splitContainer1.Panel2.Controls.Add(this.btnExtract);
			this.splitContainer1.Panel2.Controls.Add(this.btnOpen);
			this.splitContainer1.Panel2.Controls.Add(this.btnSave);
			this.splitContainer1.Panel2.Controls.Add(this.btnAddFolder);
			this.splitContainer1.Panel2.Controls.Add(this.btnAddFile);
			this.splitContainer1.Panel2.Controls.Add(this.listView1);
			this.splitContainer1.Panel2.Controls.Add(this.btnGo);
			this.splitContainer1.Panel2.Controls.Add(this.txtNavigate);
			this.splitContainer1.Size = new System.Drawing.Size(900, 433);
			this.splitContainer1.SplitterDistance = 201;
			this.splitContainer1.TabIndex = 4;
			// 
			// treeView1
			// 
			this.treeView1.ContextMenuStrip = this.contextMenuTreeView;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(0, 13);
			this.treeView1.Name = "treeView1";
			treeNode1.Name = "nodeRoot";
			treeNode1.Text = "/";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
			treeNode1});
			this.treeView1.Size = new System.Drawing.Size(197, 416);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1AfterSelect);
			this.treeView1.DoubleClick += new System.EventHandler(this.TreeView1DoubleClick);
			// 
			// contextMenuTreeView
			// 
			this.contextMenuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.navigateToolStripMenuItem,
			this.toolStripMenuItem10,
			this.deleteFolderToolStripMenuItem});
			this.contextMenuTreeView.Name = "contextMenuTreeView";
			this.contextMenuTreeView.Size = new System.Drawing.Size(205, 54);
			// 
			// navigateToolStripMenuItem
			// 
			this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
			this.navigateToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.navigateToolStripMenuItem.Text = "Navigate";
			this.navigateToolStripMenuItem.Click += new System.EventHandler(this.NavigateToolStripMenuItemClick);
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new System.Drawing.Size(201, 6);
			// 
			// deleteFolderToolStripMenuItem
			// 
			this.deleteFolderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.recursivelyRecommendedToolStripMenuItem,
			this.onlyIfEmptyToolStripMenuItem1});
			this.deleteFolderToolStripMenuItem.Name = "deleteFolderToolStripMenuItem";
			this.deleteFolderToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.deleteFolderToolStripMenuItem.Text = "Delete Folder [Recursively]";
			this.deleteFolderToolStripMenuItem.Click += new System.EventHandler(this.DeleteFolderToolStripMenuItemClick);
			// 
			// recursivelyRecommendedToolStripMenuItem
			// 
			this.recursivelyRecommendedToolStripMenuItem.Name = "recursivelyRecommendedToolStripMenuItem";
			this.recursivelyRecommendedToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
			this.recursivelyRecommendedToolStripMenuItem.Text = "Recursively (Recommended)";
			this.recursivelyRecommendedToolStripMenuItem.Click += new System.EventHandler(this.RecursivelyRecommendedToolStripMenuItemClick);
			// 
			// onlyIfEmptyToolStripMenuItem1
			// 
			this.onlyIfEmptyToolStripMenuItem1.Name = "onlyIfEmptyToolStripMenuItem1";
			this.onlyIfEmptyToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
			this.onlyIfEmptyToolStripMenuItem1.Text = "Only if Empty";
			this.onlyIfEmptyToolStripMenuItem1.Click += new System.EventHandler(this.OnlyIfEmptyToolStripMenuItem1Click);
			// 
			// lblDirectoryHierarchy
			// 
			this.lblDirectoryHierarchy.AutoSize = true;
			this.lblDirectoryHierarchy.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblDirectoryHierarchy.Location = new System.Drawing.Point(0, 0);
			this.lblDirectoryHierarchy.Name = "lblDirectoryHierarchy";
			this.lblDirectoryHierarchy.Size = new System.Drawing.Size(97, 13);
			this.lblDirectoryHierarchy.TabIndex = 1;
			this.lblDirectoryHierarchy.Text = "Directory Hierarchy";
			// 
			// btnUpOne
			// 
			this.btnUpOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpOne.Location = new System.Drawing.Point(14, 26);
			this.btnUpOne.Name = "btnUpOne";
			this.btnUpOne.Size = new System.Drawing.Size(41, 23);
			this.btnUpOne.TabIndex = 8;
			this.btnUpOne.Text = "..";
			this.btnUpOne.UseVisualStyleBackColor = true;
			this.btnUpOne.Click += new System.EventHandler(this.Button1Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
			"Details",
			"Large Icon",
			"Small Icon",
			"Tile",
			"List"});
			this.comboBox1.Location = new System.Drawing.Point(558, 1);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 7;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
			// 
			// btnExtract
			// 
			this.btnExtract.Location = new System.Drawing.Point(394, 3);
			this.btnExtract.Name = "btnExtract";
			this.btnExtract.Size = new System.Drawing.Size(75, 23);
			this.btnExtract.TabIndex = 6;
			this.btnExtract.Text = "Extract...";
			this.btnExtract.UseVisualStyleBackColor = true;
			this.btnExtract.Click += new System.EventHandler(this.BtnExtractClick);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(116, 3);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(96, 23);
			this.btnOpen.TabIndex = 3;
			this.btnOpen.Text = "Open Archive...";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.BtnOpenClick);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(14, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(96, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save Archive...";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.Location = new System.Drawing.Point(299, 3);
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Size = new System.Drawing.Size(89, 23);
			this.btnAddFolder.TabIndex = 5;
			this.btnAddFolder.Text = "Add Folder...";
			this.btnAddFolder.UseVisualStyleBackColor = true;
			this.btnAddFolder.Click += new System.EventHandler(this.BtnAddFolderClick);
			// 
			// btnAddFile
			// 
			this.btnAddFile.Location = new System.Drawing.Point(218, 3);
			this.btnAddFile.Name = "btnAddFile";
			this.btnAddFile.Size = new System.Drawing.Size(75, 23);
			this.btnAddFile.TabIndex = 4;
			this.btnAddFile.Text = "Add File...";
			this.btnAddFile.UseVisualStyleBackColor = true;
			this.btnAddFile.Click += new System.EventHandler(this.BtnAddFileClick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DereferenceLinks = false;
			this.openFileDialog1.Filter = "All Files (*.*)|*.*";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(900, 457);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NWZip ";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.contextMenuListView.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.contextMenuTreeView.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
