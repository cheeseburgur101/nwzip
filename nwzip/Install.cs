﻿/*
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
	/// windows form that installs the program.
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
			installButtonC.TabIndex = 0;
			this.Controls.Add(installButtonC);
			if(!refreshBtnT.IsBusy) refreshBtnT.RunWorkerAsync();
			installButtonC.Select();
			installButtonC.Focus();
		}
		errorReport writeFileAssociations(){
			//Write the file associations to the registry
			//to HKEY_CLASSES_ROOT
			errorReport returnValue = new errorReport();
			try{
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
			}catch(Exception ex){
				returnValue = new errorReport(1, ex.Message + "\r\nTry running the program again as administrator.");
			}
			return returnValue;
			
		}
		errorReport createDesktopShortcut(){
			//create the desktop shotrcut
			string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			return shortcutHelper.createShortcut(programPath + @"\NWZip\NWZip.exe", "NWZip Archiver Program", desktop + @"\NWZip.lnk", true);
		}
		errorReport createStartMenuShortcut(){
			//create the start menu shortcut.
			string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			return shortcutHelper.createShortcut(programPath + @"\NWZip\NWZip.exe", "NWZip Archiver Program", programPath.Split(':')[0] + @":\ProgramData\Microsoft\Windows\Start Menu\Programs\NWZip.lnk", true);
		}
		errorReport dropSelfInProgramFiles(){
			//drops items into the program files. (overwrites files)
			errorReport returnValue = new errorReport();
			try{
				string programPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
				string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				if(!Directory.Exists(programPath + @"\NWZip")) Directory.CreateDirectory(programPath + @"\NWZip");
				if(System.IO.File.Exists(programPath + @"\NWZip\NWZip.exe")) System.IO.File.Delete(programPath + @"\NWZip\NWZip.exe");
				System.IO.File.Copy(executablePath, programPath + @"\NWZip\NWZip.exe");
			}catch(Exception ex){
				returnValue = new errorReport(1, ex.Message + "\r\nTry running the program again as administrator.");
			}
			return returnValue;
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
			errorReport erpt;
			installButtonC.hasFailed = false;
			EnableDisableControls(false);
			double percentSet = 0;
			int steps = 2;
			if(ShortcutDesktop.Checked) steps += 1;
			if(ShortcutStart.Checked) steps += 1;
			double addPercentage = 100.0/steps;
			erpt = dropSelfInProgramFiles();
			percentSet = 1;
			installButtonC.setPercentage(percentSet);
			if(erpt.status != 0){
				erpt.messageBoxE();
				installButtonC.hasFailed = true;
			}else{
				percentSet += addPercentage;
				installButtonC.setPercentage(percentSet);
				if(ShortcutDesktop.Checked){
					erpt = createDesktopShortcut();
					if(erpt.status != 0){
						erpt.messageBoxE();
						installButtonC.hasFailed = true;
					}else{
						percentSet += addPercentage;
						installButtonC.setPercentage(percentSet);
					}
				}
				if((ShortcutStart.Checked) && (!installButtonC.hasFailed)){
					erpt = createStartMenuShortcut();
					if(erpt.status != 0){
						erpt.messageBoxE();
						installButtonC.hasFailed = true;
					}else{
						percentSet += addPercentage;
						installButtonC.setPercentage(percentSet);
					}
				}
				if(!installButtonC.hasFailed){
					erpt = writeFileAssociations();
					if(erpt.status != 0){
						erpt.messageBoxE();
						installButtonC.hasFailed = true;
					}else{
						percentSet = 100;
						installButtonC.setPercentage(percentSet);
					}
				}
			}
			EnableDisableControls(true);
			installButtonC.Select();
			installButtonC.Focus();
			if(!installButtonC.hasFailed) MessageBox.Show("Successfully installed 'NWZip'!", "Successful Installation", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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
