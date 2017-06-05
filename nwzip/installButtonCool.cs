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
		public bool hasFailed;
		public static Color colorOutline1 = Color.FromArgb(127, 127, 255);
		public static Color colorOutline2 = Color.Blue;
		public static Color colorFill = Color.FromArgb(64, 64, 255);
		public static Color failColorOutline1 = Color.FromArgb(255, 127, 127);
		public static Color failColorOutline2 = Color.Red;
		public static Color failColorFill = Color.FromArgb(255, 64, 64);
		public installButtonCool(int width, int height, double percent)
		{
			this.Width = width;
			this.Height = height;
			this.percent = percent;
			tText = "";
			hasFailed = false;
			this.Paint += delegate(object sender, PaintEventArgs e) {
				if(this.percent >= 101) this.percent = 100;
				Graphics g = e.Graphics;
				//progress rectangle
				g.DrawLine(new Pen((hasFailed ? failColorOutline1 : colorOutline1), 1.5f), 0, 0, this.Width - 1, 0);
				g.DrawLine(new Pen((hasFailed ? failColorOutline1 : colorOutline1), 1.5f), 0, 0, 0, this.Height - 1);
				g.DrawLine(new Pen((hasFailed ? failColorOutline2 : colorOutline2), 1.5f), 0, this.Height - 1, this.Width - 1, this.Height - 1);
				g.DrawLine(new Pen((hasFailed ? failColorOutline2 : colorOutline2), 1.5f), this.Width - 1, 0, this.Width - 1, this.Height - 1);
				//background rectangle
				g.FillRectangle(new SolidBrush(SystemColors.Control), 1, 1, this.Width - 2, this.Height - 2);
				//percentage filler rectangle
				g.FillRectangle(new SolidBrush((hasFailed ? failColorFill : colorFill)), 1, 1, (this.Width - 2) * (float)(this.percent / 100.0f), this.Height - 2);
					
				//text
				string tTextM = tText + " (" + ((int)this.percent).ToString() + "%)";
				//inverted text
				Bitmap cloneArea = new Bitmap(this.Width, this.Height);
				Graphics bitg = Graphics.FromImage(cloneArea);
				float centerStringX = (this.Width - g.MeasureString(tTextM, this.Font).Width) / 2.0f;
				float centerStringY = (this.Height - g.MeasureString(tTextM, this.Font).Height) / 2.0f;
				bitg.DrawString(tTextM, this.Font, new SolidBrush(Color.Black), centerStringX, centerStringY);
				//an underline to show the control has been focused on
				if(this.Focused){
					bitg.DrawLine(new Pen(Color.Black, 3.0f), centerStringX, centerStringY + g.MeasureString(tTextM, this.Font).Height + 1.5f, centerStringX + g.MeasureString(tTextM, this.Font).Width, centerStringY + g.MeasureString(tTextM, this.Font).Height + 1.5f);
				}
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
