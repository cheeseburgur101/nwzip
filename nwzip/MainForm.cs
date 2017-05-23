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
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			ViewFilesizes.DropDown.Closing += PreventDropDownClosing;
		}
		void PreventDropDownClosing(object sender, ToolStripDropDownClosingEventArgs e)
		{
			e.Cancel = true;
		}
		
		// When clicked change viewable filesize from bits to bytes
		void ViewFilesizesBytesCheckedChanged(object sender, EventArgs e) 
		{
			ViewFilesizesBits.Checked = !ViewFilesizesBytes.Checked;
		}
		
		// When clicked change viewable filesize from bytes to bits
		void ViewFilesizesBitsCheckedChanged(object sender, EventArgs e)
		{
			ViewFilesizesBytes.Checked = !ViewFilesizesBits.Checked;
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
		
		
	}
}
