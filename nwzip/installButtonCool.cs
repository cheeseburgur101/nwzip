/*
 * Created by SharpDevelop.
 * User: binary
 * Date: 5/26/2017
 * Time: 8:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Drawing;

namespace nwzip
{
	/// <summary>
	/// Very cool button mixed with progress bar.
	/// </summary>
	public class installButtonCool : Button
	{
		public double percent;
		public string tText;
		public installButtonCool(int width, int height, double percent)
		{
			this.Width = width;
			this.Height = height;
			this.percent = percent;
			tText = "";
			this.Paint += delegate(object sender, PaintEventArgs e) {
				if(this.percent >= 101) this.percent = 100;
				Graphics g = e.Graphics;
				//progress rectangle
				g.DrawLine(new Pen(Color.FromArgb(127, 127, 255), 1.5f), 0, 0, this.Width - 1, 0);
				g.DrawLine(new Pen(Color.FromArgb(127, 127, 255), 1.5f), 0, 0, 0, this.Height - 1);
				g.DrawLine(new Pen(Color.Blue, 1.5f), 0, this.Height - 1, this.Width - 1, this.Height - 1);
				g.DrawLine(new Pen(Color.Blue, 1.5f), this.Width - 1, 0, this.Width - 1, this.Height - 1);
				//background rectangle
				g.FillRectangle(new SolidBrush(SystemColors.Control), 1, 1, this.Width - 2, this.Height - 2);
				//percentage filler rectangle
				g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 255)), 1, 1, (this.Width - 2) * (float)(this.percent / 100.0f), this.Height - 2);
					
				//text
				string tTextM = tText + " (" + ((int)this.percent).ToString() + "%)";
				//inverted text
				Bitmap cloneArea = new Bitmap(this.Width, this.Height);
				Graphics bitg = Graphics.FromImage(cloneArea);
				bitg.DrawString(tTextM, this.Font, new SolidBrush(Color.Black), (this.Width - g.MeasureString(tTextM, this.Font).Width) / 2.0f, (this.Height - g.MeasureString(tTextM, this.Font).Height) / 2.0f);
				float xtoinvert = (cloneArea.Width) * (float)(this.percent / 100.0f);
				for(int x = 0; x < cloneArea.Width; ++x){
					for(int y = 0; y < cloneArea.Height; ++y){
						if(x <= xtoinvert){
							if(cloneArea.GetPixel(x, y).A != 0){
								cloneArea.SetPixel(x, y, Color.White);
							}
						}
					}
				}
				g.DrawImageUnscaled(cloneArea, 0, 0);
			};
		}
		
		public delegate void setPercDel(double a);
		
		
		public void setPercentage(double newValue){
			if(this.InvokeRequired){
				setPercDel a;
				a = new setPercDel(setPercentage);
				this.Invoke(a, new object[]{newValue});
			}else{
				this.percent = newValue;
			}
		}

		public delegate void fr();
		
		public void forceRepaint(){
			if(this.InvokeRequired){
				fr a;
				a = new fr(forceRepaint);
				this.Invoke(a);
			}else{
				this.Invalidate();
				this.Update();
				this.Refresh();
			}
		}
		public double getPercentage(){
			return percent;
		}
	}
}
