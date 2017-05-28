/*
 * Created by SharpDevelop.
 * User: nrgil
 * Date: 2017-05-23
 * Time: 3:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace nwzip
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			//handle arguments, treat each like a file
			//if there are multiple files, open multiple programs
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			string fileToRun = "";
			string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			for(int i = 0; i < args.Length; ++i){
				if(i == 0){
					fileToRun = args[i];
				}else{
					Process.Start(executablePath, args[i]);
				}
			}
			Application.Run(new MainForm(fileToRun));
		}
		
	}
}
