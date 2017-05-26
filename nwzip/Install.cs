/*
 * Created by SharpDevelop.
 * User: nrgil
 * Date: 2017-05-24
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace nwzip
{
	/// <summary>
	/// Description of Install.
	/// </summary>
	public partial class Install : Form
	{
		public Install()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			dropSelfInProgramFiles();
		}
		void writeFileAssociations(){
			//Write the file associations to the registry
		}
		void createDesktopShortcut(){
			//create the desktop shotrcut
		}
		void createStartMenuShortcut(){
			//create the start menu shortcut.
		}
		void dropSelfInProgramFiles(){
			//drops the executable into the program files.
			string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			File.Copy(executablePath, programPath + @"\NWZip\NWZip.exe");
		}
	}
}
