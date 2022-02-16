/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/16/2022
 * Time: 9:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace RegexExt
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
		}
		
		void TabPageMatchingClick(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				textBoxPath.Text = folderBrowserDialog.SelectedPath;
			}
		}
		
		void ButtonJavaPathClick(object sender, EventArgs e)
		{
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
				textBoxJavaPath.Text = folderBrowserDialog.SelectedPath;
			}
		}
		
		void Search(string path) {
			Application.DoEvents();
			
			IEnumerable<string> directories = Directory.EnumerateDirectories(path);
			
			foreach (string s in directories) {
				Search(s);
			}
			
			IEnumerable<string> files = Directory.EnumerateFiles(path);
			
			foreach (string s in files) {
				ProcessStartInfo psi = new ProcessStartInfo(
					(textBoxJavaPath.Text.Length > 0 ? textBoxJavaPath.Text + "\\" : "")
						+ "java");
				
				psi.WindowStyle = ProcessWindowStyle.Hidden;
				
				psi.RedirectStandardOutput = true;
				
				psi.UseShellExecute = false;
				
				psi.Arguments =  " -jar \"" + Environment.CurrentDirectory + "\\" + "regexplus.jar" + "\""
						+ " \"" + textBoxPattern.Text + "\" \"" + s + "\"";
				
				Process prc = new Process();
				
				prc.StartInfo = psi;
				
				//prc.StartInfo.FileName = ;
				
				prc.Start();
				
				//while (!prc.HasExited) {
				//	Application.DoEvents();
				//}
				
				prc.WaitForExit();
				
				if (prc.ExitCode == 0) {
					richTextBoxResults.Text += s + ":\n";
					
					//string st = "";
					
					//int i;
					
					string st = prc.StandardOutput.ReadToEnd();
					
					//while ((i = prc.StandardOutput.Read()) != -1) {
					//	st += (char) i;
					//}
					
					richTextBoxResults.Text += "\t" + st + "\n";
				}
			}
		}
		
		void ButtonRunClick(object sender, EventArgs e)
		{
			richTextBoxResults.Text = "";
			
			Search(textBoxPath.Text);
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			textBoxJavaPath.Text = Environment.GetEnvironmentVariable("JAVA_PATH");
			
			//System.Windows.Forms.MessageBox.Show(Environment.CurrentDirectory);
		}
	}
}
