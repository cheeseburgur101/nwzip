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

namespace nwzip
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int WindowToOpen = 0;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
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
		}
		
		
	}
}
