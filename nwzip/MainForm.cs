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

namespace nwzip
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int WindowToOpen = 0;
		string file;
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.file = "";
			this.Text += " - New Archive";
		}
		public MainForm(string file){
			InitializeComponent();
			if(File.Exists(file)){
				this.file = file;
				//TODO: load file
				this.Text += " - " + file;
			}else{
				if(file != "") MessageBox.Show("Error loading file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				this.Text += " - New Archive";
			}
		}

		// Add a file to the archive
		void AddFileClick(object sender, EventArgs e)
		{
			
		}
		
		// open the archive encryption window
		void ArchiveEncryptionClick(object sender, EventArgs e)
		{
	
		}
		
		// open the archive details window
		void ArchiveDetailsClick(object sender, EventArgs e)
		{
	
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
		
		
	}
}
