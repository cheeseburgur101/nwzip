/*
 * Created by SharpDevelop.
 * User: binary
 * Date: 6/4/2017
 * Time: 11:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace nwzip
{
	/// <summary>
	/// error information class
	/// </summary>
	public class errorReport
	{
		public readonly uint status;
		public readonly string error;
		//default, no error (constructor)
		public errorReport(){
			status = 0;
			error = "Success";
		}
		//error status, no message
		public errorReport(uint status){
			this.status = status;
		}
		//error status, and message
		public errorReport(uint status, string error){
			this.status = status;
			this.error = error;
		}
		public void messageBoxE(){
			MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
		}
		
	}
}
