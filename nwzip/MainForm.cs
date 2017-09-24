/*
 * Created by SharpDevelop.
 * User: nrgil
 * Date: 2017-05-23
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace nwzip
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int WindowToOpen = 0;
		string file;
		
		string currentDirInArchive;
		bool hasArchiveChanged; //Use this variable when showing a warning for clicking the 'New Archive' or 'Open Archive' button (or when doing any other action that would close the archive, such as clicking the 'X' button). Set it to false when archive gets saved by some function. Set it to true when the archive got changed in any way, shape, or form.
		
		string[] directories; //probably temporary arrays
		string[] files;
		
		Dictionary<string, string> filesTypes;
		
		sizeModifier szMod;
		
		ImageList imagesSmall; //image lists for icons in listview
		ImageList imagesLarge;
		
		//imports for icon getting
		[DllImport("shell32.dll", EntryPoint="SHGetFileInfo")]
		public unsafe extern static void* SHGetFileInfo(string pszPath, UInt32 dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
		[DllImport("user32.dll", EntryPoint="DestroyIcon")]
		public unsafe extern static bool DestroyIcon(void* hIcon);
		
		public unsafe struct SHFILEINFO {
			public void* hIcon;
			public int iIcon;
			public UInt32 dwAttributes;
			public fixed char szDisplayName[260];
			public fixed char szTypeName[80];
		}
		
		public enum sizeModifier {
			Bytes,
			Thousand,
			Thousand24
		}
		
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.file = "";
			this.Text += Program.versionString();
			this.Text += " - New Archive";
			
			initialInit();
		}
		public MainForm(string file){
			InitializeComponent();
			this.Text += Program.versionString();
			if(File.Exists(file)){
				this.file = file;
				//TODO: load file
				this.Text += " - " + file;
			}else{
				if(file != "") MessageBox.Show("Error loading file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				this.Text += " - New Archive";
			}
			
			initialInit();
		}
		public string stripSlashes(string oldStr){ //get the file name from a complete file path
			string newStr = oldStr;
			newStr = newStr.Replace("/", "\\");
			while(newStr.Contains("\\")){
				newStr = newStr.Substring(1);
			}
			return newStr;
		}
		public string stripSlashes(string oldStr, int num){ //strip X slashes from the string
			string newStr = oldStr;
			int numO = 0;
			newStr = newStr.Replace("/", "\\");
			while(newStr.Contains("\\")){
				if(newStr[0] == '\\') ++numO;
				newStr = newStr.Substring(1);
				if(numO >= num) break;
			}
			return newStr;
		}
		void updateMainWindowTitle(){ //completely reset the mainWindow title
			this.Text = "NWZip ";
			this.Text += Program.versionString();
			if(File.Exists(this.file)){
				this.Text += " - " + this.file;
			}else{
				this.Text += " - New Archive";
			}
			if(hasArchiveChanged){
				this.Text += "*";
			}
		}
		void initialInit(){ //initialization process
			currentDirInArchive = "/";
			
			try{
				comboBox1.SelectedIndex = 0;
			}catch(Exception ex){
				//if it fails somehow, do not call MessageBox.Show
			}
			
			hasArchiveChanged = false;
			
			files = new string[]{};
			directories = new string[]{};
			
			szMod = sizeModifier.Thousand24;
			
			imagesSmall = new ImageList();
			imagesLarge = new ImageList();
			
			ResourceManager rm = new ResourceManager("nwzip.MainForm", typeof(MainForm).Assembly);
			
			imagesSmall.Images.Add("binary-unknown", (Bitmap)rm.GetObject("binary-unknown16"));
			imagesSmall.Images.Add("folder", (Bitmap)rm.GetObject("folder16"));
			
			imagesLarge.Images.Add("binary-unknown", (Bitmap)rm.GetObject("binary-unknown64"));
			imagesLarge.Images.Add("folder", (Bitmap)rm.GetObject("folder64"));
			
			imagesSmall.ImageSize = new Size(16, 16);
			imagesLarge.ImageSize = new Size(64, 64);
			
			listView1.SmallImageList = imagesSmall;
			listView1.LargeImageList = imagesLarge;
			
			filesTypes = new Dictionary<string, string>();
		}
		int numSlashes(string a){ //returns the number of forward slashes
			int b = 0;
			for(int i = 0; i < a.Length; ++i){
				if(a[i] == '/') b += 1;
			}
			return b;
		}
		void getFileAndFolderList(string dir, ref string[] fileList, ref string[] folderList){ //recursively gets all folders and files into a list
			string[] filesIO = Directory.GetFiles(dir);
			string[] dirsIO = Directory.GetDirectories(dir);
			
			for(int i = 0; i < filesIO.Length; ++i){
				Array.Resize(ref fileList, fileList.Length + 1);
				fileList[fileList.Length - 1] = filesIO[i];
			}
			
			for(int i = 0; i < dirsIO.Length; ++i){
				Array.Resize(ref folderList, folderList.Length + 1);
				folderList[folderList.Length - 1] = dirsIO[i];
				getFileAndFolderList(dirsIO[i], ref fileList, ref folderList);
			}
		}
		void updateTreeView(){ //completely resets the treeView for all directories
			treeView1.Nodes.Clear();
			updateTreeView2(treeView1.Nodes, 0);
		}
		void updateTreeView2(TreeNodeCollection tnc, int level){
			if(level == 0){
				tnc.Clear();
				tnc.Add("/");
				updateTreeView2(tnc, level + 1);
			}else{
				for(int j = 0; j < tnc.Count; ++j){
					for(int i = 0; i < directories.Length; ++i){
						if(numSlashes(directories[i]) == level){
							if(directories[i].StartsWith(tnc[j].Text, StringComparison.CurrentCulture)){
								//if(!tnc[j].Nodes.Contains(new TreeNode(directories[i]))){
								if(!nodesContains(tnc[j].Nodes, directories[i], true)){
									tnc[j].Nodes.Add(directories[i]);
									updateTreeView2(tnc[j].Nodes, level + 1);
								}
							}
						}
					}
				}
			}
		}
		bool nodesContains(TreeNodeCollection tnc, string cmpstr, bool caseSensitive){
			bool f = false;
			for(int i = 0; i < tnc.Count; ++i){
				if(caseSensitive){
					if(tnc[i].Text == cmpstr){
						f = true;
					}
				}else{
					if(tnc[i].Text.ToLower() == cmpstr.ToLower()){
						f = true;
					}
				}
			}
			return f;
		}
		void updateListView(){ //completely resets the listView for the currentDirectory in the Archive
			//TODO display alphabetically, and icons with different views
			
			listView1.Items.Clear();
			
			string currentDirInArchiveSE = currentDirInArchive;
			currentDirInArchiveSE = currentDirInArchiveSE.Replace("\\", "/");
			if(!currentDirInArchiveSE.EndsWith("/", StringComparison.CurrentCulture)) currentDirInArchiveSE += "/";
			//list directories
			for(int i = 0; i < directories.Length; ++i){
				//check if the directory is in the same directory
				string ndirectory = directories[i];
				ndirectory = ndirectory.Replace("\\", "/");
				if(ndirectory.EndsWith("/", StringComparison.CurrentCulture)) ndirectory = ndirectory.Substring(0, ndirectory.Length - 1);
				if(ndirectory.StartsWith(currentDirInArchiveSE, StringComparison.CurrentCulture)){
					if((numSlashes(currentDirInArchiveSE)) == (numSlashes(ndirectory))){
						ListViewItem lvi = new ListViewItem();
						lvi.Text = stripSlashes(ndirectory);
						lvi.SubItems.Add("Folder");
						lvi.SubItems.Add("");
						lvi.ImageKey = "folder";
						listView1.Items.Add(lvi);
					}
				}
			}
			
			
			//list files
			for(int i = 0; i < files.Length; ++i){
				//check if file is in the same directory
				if(files[i].StartsWith(currentDirInArchiveSE, StringComparison.CurrentCulture)){
					//check if file is in the same "depth" of directory. (completeFilename;numberOfSlashes) /a.txt;1 /a/b.txt;2, both start with "/", but have a different number of slashes
					if((numSlashes(currentDirInArchiveSE)) == (numSlashes(files[i]))){
						ListViewItem lvi = new ListViewItem();
						lvi.Text = stripSlashes(files[i]);
						lvi.SubItems.Add(fileTypeFromRegistry(stripSlashes(files[i]))); //get file type from registry
						lvi.SubItems.Add("Unimplemented feature"); //TODO szMod (Bytes: display size in bytes (eg 134568645 bytes displayed as "134568645"); Thousand: 1000 bytes = 1 kilobyte, 1000 kilobytes = 1 megabyte, etc (eg 4 bytes: display "4 bytes", 4000 bytes: display "4Kb", 4000000 bytes: display "4Mb"); Thousand24: 1024 bytes = 1 kilobyte, 1024 kilobytes = 1 megabyte, etc (eg 4 bytes: display "4 bytes", 4096 bytes: display "4Kb", 4194304 bytes: display "4Mb")
						lvi.ImageKey = resolveFileIconFromExtension(stripSlashes(files[i]));
						listView1.Items.Add(lvi);
					}
				}
			}
		}

		string fileExtensionFromFileName(string filename){
			string retVal = filename;
			while(retVal.Contains(".")){
				retVal = retVal.Substring(1);
		 	}
			return "." + retVal;
		}
		
		unsafe string resolveFileIconFromExtension(string filename){
			string retVal = "binary-unknown"; //default value (if error)
			string dfiletype = "-" + fileExtensionFromFileName(filename);
			if(iconListsContains(dfiletype)) return dfiletype; //already exists in icon lists, no need to get it again
			//get icon from file from shgetfileinfo
			if(filename.Contains(".")){
				try{
					string fext = fileExtensionFromFileName(filename);
					SHFILEINFO shfi = new SHFILEINFO(); //define a SHFILEINFO
					shfi.dwAttributes = 0; //clear structure
					shfi.hIcon = (void*)0;
					shfi.iIcon = 0;
					for(int i = 0; i < 260; ++i){
						shfi.szDisplayName[i] = (char)0;
					}
					for(int i = 0; i < 80; ++i){
						shfi.szTypeName[i] = (char)0;
					}
					//get large icon
					if(SHGetFileInfo(fext, 0x80 /*FILE_ATTRIBUTE_NORMAL*/, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 /*SHGFI_ICON*/ | 0x10 /*SHGFI_USEFILEATTRIBUTES*/)) != (void*)0){
						Icon icoGet = (Icon)Icon.FromHandle((IntPtr)shfi.hIcon).Clone(); //copy into new object
						imagesLarge.Images.Add(dfiletype, icoGet.ToBitmap()); //add for future reference
						retVal = dfiletype; //change return value
						DestroyIcon(shfi.hIcon); //free memory
					}
					shfi = new SHFILEINFO();
					shfi.dwAttributes = 0; //reset SHFILEINFO structure
					shfi.hIcon = (void*)0;
					shfi.iIcon = 0;
					for(int i = 0; i < 260; ++i){
						shfi.szDisplayName[i] = (char)0;
					}
					for(int i = 0; i < 80; ++i){
						shfi.szTypeName[i] = (char)0;
					}
					//get small icon
					if(SHGetFileInfo(fext, 0x80 /*FILE_ATTRIBUTE_NORMAL*/, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)(0x100 /*SHGFI_ICON*/ | 0x10 /*SHGFI_USEFILEATTRIBUTES*/ | 0x01 /*SHGFI_SMALLICON*/)) != (void*)0){
						Icon icoGet = (Icon)Icon.FromHandle((IntPtr)shfi.hIcon).Clone(); //copy into new object
						imagesSmall.Images.Add(dfiletype, icoGet.ToBitmap()); //add for future reference
						retVal = dfiletype; //change return value
						DestroyIcon(shfi.hIcon); //free memory
					}
				}catch(Exception ex){
					//do nothing
			   	}
			}
			return retVal;
		}
		
		bool iconListsContains(string imageKey){
			if(imagesSmall.Images.ContainsKey(imageKey)) return true;
			if(imagesLarge.Images.ContainsKey(imageKey)) return true;
			
			return false;
		}
		
		string fileTypeFromRegistry(string filename){
			string retVal = "Binary Data/Unknown"; //default value (if error)
			if(filename.Contains(".")){
				if(filesTypes.ContainsKey(fileExtensionFromFileName(filename))){ //if already resolved
					retVal = filesTypes[fileExtensionFromFileName(filename)]; //return result
				}else{
				   	//search in registry HKEY_CLASSES_ROOT
				   	//get file type
				   	try{	
				   		string newPointer = "";
				   		bool worked = false;
				   		RegistryKey rk = Registry.ClassesRoot.OpenSubKey(fileExtensionFromFileName(filename), false);
						if(rk != null){
				   			newPointer = (string)rk.GetValue("");
							rk.Close();
							worked = true;
						}
				   		if(worked){
				   			rk = Registry.ClassesRoot.OpenSubKey(newPointer, false);
				   			if(rk != null){
				   				retVal = (string)rk.GetValue("");
				   				filesTypes[fileExtensionFromFileName(filename)] = retVal; //save for later
				   				rk.Close();
				   			}
				   		}
					}catch(Exception ex){
						//do nothing
					}
				}
			}
			return retVal;
		}
		
		// Add a file to the archive
		void AddFileClick(object sender, EventArgs e) //Edit > Add File to archive...
		{
			btnAddFile.PerformClick();
		}
		
		// open the archive encryption window
		void ArchiveEncryptionClick(object sender, EventArgs e) //Archive > Encryption
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		
		// open the archive details window
		void ArchiveDetailsClick(object sender, EventArgs e) //Archive > Details
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void BackgroundWorker1DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			if(WindowToOpen==0){
				
			}
		}
		void InstallToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form install  = new Install();
			install.ShowDialog();
			install.Dispose();
		}
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		void BtnSaveClick(object sender, EventArgs e)
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void BtnOpenClick(object sender, EventArgs e)
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void BtnGoClick(object sender, EventArgs e)
		{
			//check if dir exists in archive
			bool dirExists = false;
			for(int i = 0; i < directories.Length; ++i){
				string navEnh = txtNavigate.Text;
				string dirEnh = directories[i];
				navEnh = navEnh.Replace("\\", "/");
				dirEnh = dirEnh.Replace("\\", "/");
				if(!navEnh.EndsWith("/", StringComparison.CurrentCulture)) navEnh += "/";
				if(!dirEnh.EndsWith("/", StringComparison.CurrentCulture)) dirEnh += "/";
				if((navEnh == dirEnh) || (navEnh == "/")) dirExists = true;
			}
			//set current directory in archive, and update listview if it does
			if(dirExists){
				currentDirInArchive = txtNavigate.Text;
				updateListView();
			}
		}
		void BtnAddFolderClick(object sender, EventArgs e)
		{
			if(folderBrowserDialog1.ShowDialog() == DialogResult.OK){
				string folderToAdd = folderBrowserDialog1.SelectedPath;
				int stripSlashCount = 0;
				string tempFTA = folderToAdd;
				tempFTA = tempFTA.Replace("/", "\\");
				while(tempFTA.Contains("\\")){
					if(tempFTA[0] == '\\') ++stripSlashCount;
					tempFTA = tempFTA.Substring(1);
				}
				if(folderToAdd.EndsWith("/", StringComparison.CurrentCulture)) folderToAdd = folderToAdd.Substring(0, folderToAdd.Length - 1);
				if(folderToAdd.EndsWith("\\", StringComparison.CurrentCulture)) folderToAdd = folderToAdd.Substring(0, folderToAdd.Length - 1);
				//recursively add the folder and all of its contents to the current directory in the archive, update listView, and update treeView
				
				string[] listOfFilesToAdd = new string[]{};
				string[] listOfFoldersToAdd = new string[]{};
				getFileAndFolderList(folderToAdd, ref listOfFilesToAdd, ref listOfFoldersToAdd);
				
				//add the folder's dir
				bool folderExistsInCD = false;
				string filteredFTA = currentDirInArchive;
				if(!filteredFTA.EndsWith("/", StringComparison.CurrentCulture)) filteredFTA += "/";
				filteredFTA += stripSlashes(folderToAdd);
				for(int i = 0; i < directories.Length; ++i){
					if(directories[i] == filteredFTA) folderExistsInCD = true;
				}
				if(!folderExistsInCD){
					hasArchiveChanged = true;
					Array.Resize(ref directories, directories.Length + 1);
					directories[directories.Length - 1] = filteredFTA;
				}
				
				//add all files
				for(int i = 0; i < listOfFilesToAdd.Length; ++i){
					//check if the file already exists in all directories
					string orgFile = stripSlashes(listOfFilesToAdd[i], stripSlashCount+1);
					string caOrgFile = currentDirInArchive;
					if(!caOrgFile.EndsWith("/", StringComparison.CurrentCulture)) caOrgFile += "/";
					caOrgFile += stripSlashes(folderToAdd);
					if(!caOrgFile.EndsWith("/", StringComparison.CurrentCulture)) caOrgFile += "/";
					caOrgFile += orgFile;
					caOrgFile = caOrgFile.Replace("\\", "/");
					bool existsInCD = false;
							
					for(int j = 0; j < files.Length; ++j){
						if(files[j] == caOrgFile) existsInCD = true;
					}
					//if it doesn't, add it
					if(!existsInCD){
						hasArchiveChanged = true;
						Array.Resize(ref files, files.Length + 1);
						files[files.Length - 1] = caOrgFile;
					}
				}
				
				//add all dirs
				for(int i = 0; i < listOfFoldersToAdd.Length; ++i){
					//check if the directory already exists in all directories
					string orgDir = stripSlashes(listOfFoldersToAdd[i], stripSlashCount+1);
					string caOrgDir = currentDirInArchive;
					if(!caOrgDir.EndsWith("/", StringComparison.CurrentCulture)) caOrgDir += "/";
					caOrgDir += stripSlashes(folderToAdd);
					if(!caOrgDir.EndsWith("/", StringComparison.CurrentCulture)) caOrgDir += "/";
					caOrgDir += orgDir;
					caOrgDir = caOrgDir.Replace("\\", "/");
					bool existsInCD = false;
					
					for(int j = 0; j < directories.Length; ++j){
						if(directories[j] == caOrgDir) existsInCD = true;
					}
					
					//if it doesn't, add it
					if(!existsInCD){
						hasArchiveChanged = true;
						Array.Resize(ref directories, directories.Length + 1);
						directories[directories.Length - 1] = caOrgDir;
					}
				}
				
				//update
				updateListView();
				updateTreeView();
				updateMainWindowTitle();
			}
		}
		void BtnAddFileClick(object sender, EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK){
				//add the file to the current directory in the archive, and update listView
				string filenameToAdd = currentDirInArchive;
				if(!currentDirInArchive.EndsWith("/", StringComparison.CurrentCulture)) filenameToAdd += "/";
				filenameToAdd = filenameToAdd.Replace("\\", "/");
				filenameToAdd += stripSlashes(openFileDialog1.FileName);
				
				bool filesContains = false;
				for(int i = 0; i < files.Length; ++i){
					if(files[i] == filenameToAdd) filesContains = true;
				}
				
				if(!filesContains){
					Array.Resize(ref files, files.Length + 1);
					files[files.Length - 1] = filenameToAdd;
					
					updateListView();
					hasArchiveChanged = true;
					updateMainWindowTitle();
				}else{
					errorReport err = new errorReport(1, "File already exists in this directory.");
					err.messageBoxE();
				}
			}
		}
		void AddFolderToArchiveToolStripMenuItemClick(object sender, EventArgs e) //Edit > Add Folder to archive...
		{
			btnAddFolder.PerformClick();
		}
		void TreeView1DoubleClick(object sender, EventArgs e)
		{
			
		}
		void DeleteFolderToolStripMenuItemClick(object sender, EventArgs e) //treeView > DeleteFolder[]
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == 0){
				listView1.View = View.Details;
			}else if(comboBox1.SelectedIndex == 1){
				listView1.View = View.LargeIcon;
			}else if(comboBox1.SelectedIndex == 2){
				listView1.View = View.SmallIcon;
			}else if(comboBox1.SelectedIndex == 3){
				listView1.View = View.Tile;
			}else if(comboBox1.SelectedIndex == 4){
				listView1.View = View.List;
			}else{
				errorReport a = new errorReport(1, "Unimplemented feature.");
				a.messageBoxE();
			}
		}
		void SaveFileClick(object sender, EventArgs e) //File > Save
		{
			btnSave.PerformClick();
		}
		void ClearRecentFilesToolStripMenuItemClick(object sender, EventArgs e) //File > Open Recent > Clear Recent Archives
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void NewFileClick(object sender, EventArgs e) //File > New
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void OpenFileClick(object sender, EventArgs e) //File > Open
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void SaveAsFileClick(object sender, EventArgs e) //File > Save As
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void TreeView1AfterSelect(object sender, TreeViewEventArgs e)
		{
			try{
				txtNavigate.Text = treeView1.SelectedNode.Text;
				currentDirInArchive = txtNavigate.Text;
				btnGo.PerformClick();
			}catch(Exception ex){
				//if it fails somehow, do not call MessageBox.Show
			}
		}
		void BtnExtractClick(object sender, EventArgs e)
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void RecursivelyRecommendedToolStripMenuItemClick(object sender, EventArgs e) //treeView > DeleteFolder > Recursively
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void OnlyIfEmptyToolStripMenuItem1Click(object sender, EventArgs e) //treeview > DeleteFolder > OnlyIfEmpty
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void WholeArchiveToolStripMenuItemClick(object sender, EventArgs e) //listView > Extract > Whole Archive
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void CurrentDirectoryToolStripMenuItemClick(object sender, EventArgs e) //listView > Extract > CurrentDir
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void SelectedFileToolStripMenuItemClick(object sender, EventArgs e) //listView > Extract > SelectedFile
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void DeleteFileToolStripMenuItemClick(object sender, EventArgs e) //listView > DeleteFile
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void DeleteFolderToolStripMenuItem1Click(object sender, EventArgs e) //listView > DeleteFolder[]
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void RecursiveRecommendedToolStripMenuItemClick(object sender, EventArgs e) //listView > DeleteFolder > Recursively
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void OnlyIfEmptyToolStripMenuItemClick(object sender, EventArgs e) //listView > DeleteFolder > OnlyIfEmpty
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void RenameToolStripMenuItemClick(object sender, EventArgs e) //listView > Rename
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void PropertiesToolStripMenuItemClick(object sender, EventArgs e) //listView > Properties
		{
			errorReport a = new errorReport(1, "Unimplemented feature.");
			a.messageBoxE();
		}
		void BytesToolStripMenuItemClick(object sender, EventArgs e) //listView > Sizes > Bytes
		{
			bytesToolStripMenuItem.Checked = true;
			perKilobyteToolStripMenuItem.Checked = false;
			perKilobyteToolStripMenuItem1.Checked = false;
			szMod = sizeModifier.Bytes;
		}
		void PerKilobyteToolStripMenuItemClick(object sender, EventArgs e) //listView > Sizes > 1000b
		{
			bytesToolStripMenuItem.Checked = false;
			perKilobyteToolStripMenuItem.Checked = true;
			perKilobyteToolStripMenuItem1.Checked = false;
			szMod = sizeModifier.Thousand;
		}
		void PerKilobyteToolStripMenuItem1Click(object sender, EventArgs e) //listView > Sizes > 1024b
		{
			bytesToolStripMenuItem.Checked = false;
			perKilobyteToolStripMenuItem.Checked = false;
			perKilobyteToolStripMenuItem1.Checked = true;
			szMod = sizeModifier.Thousand24;
		}
		void TxtNavigateKeyPress(object sender, KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)0x0a){
				e.Handled = true;
				btnGo.PerformClick();
			}
			if(e.KeyChar == (char)0x0d){
				e.Handled = true;
				btnGo.PerformClick();
			}
		}
		void ListView1DoubleClick(object sender, EventArgs e)
		{
			try{
				if(listView1.SelectedItems[0].SubItems[1].Text == "Folder"){
					txtNavigate.Text = currentDirInArchive;
					if(!txtNavigate.Text.EndsWith("/", StringComparison.CurrentCulture)) txtNavigate.Text += "/";
					txtNavigate.Text += listView1.SelectedItems[0].Text;
					
					btnGo.PerformClick();
				}
			}catch(Exception ex){
				//do nothing
			}
		}
		void NavigateToolStripMenuItemClick(object sender, EventArgs e) //treeview > navigate
		{
			try{
				txtNavigate.Text = treeView1.SelectedNode.Text;
				
				btnGo.PerformClick();
			}catch(Exception ex){
				//do nothing
			}
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if(hasArchiveChanged){
				DialogResult dr = MessageBox.Show("Would you like to save the archive?", "Closing Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button3);
				if(dr == DialogResult.Cancel) e.Cancel = true;
				if(dr == DialogResult.Yes){
					//TODO call save method (line below is probably temporary)
					btnSave.PerformClick();
				}
			}
		}
		void Button1Click(object sender, EventArgs e) //up one level (navigate)
		{
			try{
				string newCD = currentDirInArchive;
				newCD = newCD.Replace("\\", "/");
				if(newCD.EndsWith("/", StringComparison.CurrentCulture)) newCD = newCD.Substring(0, newCD.Length - 1);
				if(newCD.Length != 0){
					while(!newCD.EndsWith("/", StringComparison.CurrentCulture)){
						newCD = newCD.Substring(0, newCD.Length - 1);
					}
					txtNavigate.Text = newCD;
					btnGo.PerformClick();
				}
			}catch(Exception ex){
				//no messagebox
			}
		}
		
		
	}
}
