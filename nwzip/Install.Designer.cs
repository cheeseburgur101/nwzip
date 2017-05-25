/*
 * Created by SharpDevelop.
 * User: nrgil
 * Date: 2017-05-24
 * Time: 5:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace nwzip
{
	partial class Install
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox ShortcutDesktop;
		private System.Windows.Forms.CheckBox ShortcutStart;
		private System.Windows.Forms.Button InstallButton;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install));
			this.label1 = new System.Windows.Forms.Label();
			this.ShortcutDesktop = new System.Windows.Forms.CheckBox();
			this.ShortcutStart = new System.Windows.Forms.CheckBox();
			this.InstallButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(346, 32);
			this.label1.TabIndex = 0;
			this.label1.Text = "Installing NWZip to your computer will associate *.nwz files with this program, a" +
	"nd place a copy of the program in your Program Files folder.";
			// 
			// ShortcutDesktop
			// 
			this.ShortcutDesktop.Location = new System.Drawing.Point(2, 27);
			this.ShortcutDesktop.Name = "ShortcutDesktop";
			this.ShortcutDesktop.Size = new System.Drawing.Size(188, 24);
			this.ShortcutDesktop.TabIndex = 1;
			this.ShortcutDesktop.Text = "Place a shortcut on your desktop";
			this.ShortcutDesktop.UseVisualStyleBackColor = true;
			// 
			// ShortcutStart
			// 
			this.ShortcutStart.Location = new System.Drawing.Point(2, 45);
			this.ShortcutStart.Name = "ShortcutStart";
			this.ShortcutStart.Size = new System.Drawing.Size(188, 24);
			this.ShortcutStart.TabIndex = 2;
			this.ShortcutStart.Text = "Place a shortcut in the Start menu";
			this.ShortcutStart.UseVisualStyleBackColor = true;
			// 
			// InstallButton
			// 
			this.InstallButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InstallButton.Location = new System.Drawing.Point(2, 76);
			this.InstallButton.Name = "InstallButton";
			this.InstallButton.Size = new System.Drawing.Size(344, 44);
			this.InstallButton.TabIndex = 3;
			this.InstallButton.Text = "Install";
			this.InstallButton.UseVisualStyleBackColor = true;
			// 
			// Install
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 123);
			this.Controls.Add(this.InstallButton);
			this.Controls.Add(this.ShortcutStart);
			this.Controls.Add(this.ShortcutDesktop);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Install";
			this.Text = "Install NWZip to your computer";
			this.ResumeLayout(false);

		}
	}
}
