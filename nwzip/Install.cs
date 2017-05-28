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
using System.Threading;
using Microsoft.Win32;

namespace nwzip
{
	/// <summary>
	/// Description of Install.
	/// </summary>
	public partial class Install : Form
	{
		private installButtonCool installButtonC;
		public Install()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			installButtonC = new installButtonCool(344, 44, 0);
			installButtonC.Font = new Font("Microsoft Sans Serif" , 15.75F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
			installButtonC.Left = 2;
			installButtonC.Top = 76;
			installButtonC.Visible = true;
			installButtonC.tText = "Install";
			installButtonC.Click += InstallButtonClick;
			this.Controls.Add(installButtonC);
			try{
				refreshBtnT.RunWorkerAsync();
			}catch(Exception ex){
				
			}
		}
		void writeFileAssociations(){
			//Write the file associations to the registry
			//to HKEY_CLASSES_ROOT
			string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			RegistryKey rk = Registry.ClassesRoot.CreateSubKey(".nwz");
			if(rk != null){
				rk.SetValue("", "nwzfiletype", RegistryValueKind.String);
				rk.Close();
			}
			rk = Registry.ClassesRoot.CreateSubKey("nwzfiletype");
			if(rk != null){
				rk.SetValue("", "NWZip Archive", RegistryValueKind.String); //file description
				rk.Close();
			}
			rk = Registry.ClassesRoot.CreateSubKey(@"nwzfiletype\DefaultIcon");
			if(rk != null){
				rk.SetValue("", "\"" + programPath + "\\NWZip\\NWZip.exe\",0", RegistryValueKind.String); //icon
				rk.Close();
			}
			rk = Registry.ClassesRoot.CreateSubKey(@"nwzfiletype\shell");
			if(rk != null){
				rk.Close();
				rk = Registry.ClassesRoot.CreateSubKey(@"nwzfiletype\shell\open");
				if(rk != null){
					rk.Close();
					rk = Registry.ClassesRoot.CreateSubKey(@"nwzfiletype\shell\open\command");
					if(rk != null){
						rk.SetValue("", "\"" + programPath + "\\NWZip\\NWZip.exe\" \"%1\"", RegistryValueKind.String);
						rk.Close();
					}
				}
			}
			//to HKEY_LOCAL_MACHINE
			rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\.nwz");
			if(rk != null){
				rk.SetValue("", "nwzfiletype", RegistryValueKind.String);
				rk.Close();
			}
			rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\nwzfiletype");
			if(rk != null){
				rk.SetValue("", "NWZip Archive", RegistryValueKind.String); //file description
				rk.Close();
			}
			rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\nwzfiletype\DefaultIcon");
			if(rk != null){
				rk.SetValue("", "\"" + programPath + "\\NWZip\\NWZip.exe\",0", RegistryValueKind.String); //icon
				rk.Close();
			}
			rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\nwzfiletype\shell");
			if(rk != null){
				rk.Close();
				rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\nwzfiletype\shell\open");
				if(rk != null){
					rk.Close();
					rk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Classes\nwzfiletype\shell\open\command");
					if(rk != null){
						rk.SetValue("", "\"" + programPath + "\\NWZip\\NWZip.exe\" \"%1\"", RegistryValueKind.String);
						rk.Close();
					}
				}
			}
			
		}
		void createDesktopShortcut(){
			//create the desktop shotrcut
		}
		void createStartMenuShortcut(){
			//create the start menu shortcut.
		}
		void dropSelfInProgramFiles(){
			//drops items into the program files. (overwrites files)
			string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			if(!Directory.Exists(programPath + @"\NWZip")) Directory.CreateDirectory(programPath + @"\NWZip");
			if(File.Exists(programPath + @"\NWZip\NWZip.exe")) File.Delete(programPath + @"\NWZip\NWZip.exe");
			File.Copy(executablePath, programPath + @"\NWZip\NWZip.exe");
		}
		void EnableDisableControls(bool state){
			//Enables/Disables the Controls, true in state means all enabled, false in state means all disabled.
			//Does not change labels.
			for(int i = 0; i < this.Controls.Count; ++i){
				if(this.Controls[i] is Label){
				}else{
					this.Controls[i].Enabled = state;
				}
			}
		}
		void InstallButtonClick(object sender, EventArgs e)
		{
			//Handles calling the installation functions based on the checkboxes
			//Also sets percentage of the button
			EnableDisableControls(false);
			double percentSet = 0;
			int steps = 2;
			if(ShortcutDesktop.Checked) steps += 1;
			if(ShortcutStart.Checked) steps += 1;
			double addPercentage = 100.0/steps;
			dropSelfInProgramFiles();
			percentSet += addPercentage;
			installButtonC.setPercentage(percentSet);
			if(ShortcutDesktop.Checked){
				createDesktopShortcut();
				percentSet += addPercentage;
				installButtonC.setPercentage(percentSet);
			}
			if(ShortcutStart.Checked){
				createStartMenuShortcut();
				percentSet += addPercentage;
				installButtonC.setPercentage(percentSet);
			}
			writeFileAssociations();
			percentSet = 100;
			installButtonC.setPercentage(percentSet);
			EnableDisableControls(true);
			MessageBox.Show("Successfully installed 'NWZip'!", "Successful Installation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
		}
		void InstallFormClosing(object sender, FormClosingEventArgs e)
		{
			//Prompts the user for confirmation to cancel the installation.
			if(installButtonC.Enabled == false){
				if(MessageBox.Show("Closing this window will stop the installation. The installation will be left in an incomplete state. Are you sure you want to stop the installation?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.Yes){
					e.Cancel = true;
				}
			}
		}
		void RefreshBtnTDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			//repaints the button for the animation
			while(true){
				Thread.Sleep(100);
				installButtonC.forceRepaint();
			}
		}

	}
}
