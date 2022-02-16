/*
 * Created by SharpDevelop.
 * User: Mirzakhmet
 * Date: 2/16/2022
 * Time: 9:06 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace RegexExt
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageMatching = new System.Windows.Forms.TabPage();
			this.buttonRun = new System.Windows.Forms.Button();
			this.richTextBoxResults = new System.Windows.Forms.RichTextBox();
			this.labelResults = new System.Windows.Forms.Label();
			this.buttonPath = new System.Windows.Forms.Button();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.labelPath = new System.Windows.Forms.Label();
			this.textBoxPattern = new System.Windows.Forms.TextBox();
			this.labelPattern = new System.Windows.Forms.Label();
			this.tabPageSettings = new System.Windows.Forms.TabPage();
			this.numericUpDownThreadCount = new System.Windows.Forms.NumericUpDown();
			this.labelThreadCount = new System.Windows.Forms.Label();
			this.buttonJavaPath = new System.Windows.Forms.Button();
			this.textBoxJavaPath = new System.Windows.Forms.TextBox();
			this.labelJavaPath = new System.Windows.Forms.Label();
			this.tabPageHelp = new System.Windows.Forms.TabPage();
			this.richTextBoxHelp = new System.Windows.Forms.RichTextBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControlMain.SuspendLayout();
			this.tabPageMatching.SuspendLayout();
			this.tabPageSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadCount)).BeginInit();
			this.tabPageHelp.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageMatching);
			this.tabControlMain.Controls.Add(this.tabPageSettings);
			this.tabControlMain.Controls.Add(this.tabPageHelp);
			this.tabControlMain.Location = new System.Drawing.Point(-1, 1);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(314, 332);
			this.tabControlMain.TabIndex = 0;
			// 
			// tabPageMatching
			// 
			this.tabPageMatching.Controls.Add(this.buttonRun);
			this.tabPageMatching.Controls.Add(this.richTextBoxResults);
			this.tabPageMatching.Controls.Add(this.labelResults);
			this.tabPageMatching.Controls.Add(this.buttonPath);
			this.tabPageMatching.Controls.Add(this.textBoxPath);
			this.tabPageMatching.Controls.Add(this.labelPath);
			this.tabPageMatching.Controls.Add(this.textBoxPattern);
			this.tabPageMatching.Controls.Add(this.labelPattern);
			this.tabPageMatching.Location = new System.Drawing.Point(4, 22);
			this.tabPageMatching.Name = "tabPageMatching";
			this.tabPageMatching.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageMatching.Size = new System.Drawing.Size(306, 306);
			this.tabPageMatching.TabIndex = 0;
			this.tabPageMatching.Text = "Matching";
			this.tabPageMatching.UseVisualStyleBackColor = true;
			this.tabPageMatching.Click += new System.EventHandler(this.TabPageMatchingClick);
			// 
			// buttonRun
			// 
			this.buttonRun.Location = new System.Drawing.Point(109, 274);
			this.buttonRun.Name = "buttonRun";
			this.buttonRun.Size = new System.Drawing.Size(83, 21);
			this.buttonRun.TabIndex = 7;
			this.buttonRun.Text = "Run";
			this.buttonRun.UseVisualStyleBackColor = true;
			this.buttonRun.Click += new System.EventHandler(this.ButtonRunClick);
			// 
			// richTextBoxResults
			// 
			this.richTextBoxResults.Location = new System.Drawing.Point(9, 169);
			this.richTextBoxResults.Name = "richTextBoxResults";
			this.richTextBoxResults.ReadOnly = true;
			this.richTextBoxResults.Size = new System.Drawing.Size(290, 89);
			this.richTextBoxResults.TabIndex = 6;
			this.richTextBoxResults.Text = "";
			// 
			// labelResults
			// 
			this.labelResults.Location = new System.Drawing.Point(9, 154);
			this.labelResults.Name = "labelResults";
			this.labelResults.Size = new System.Drawing.Size(100, 12);
			this.labelResults.TabIndex = 5;
			this.labelResults.Text = "Results:";
			// 
			// buttonPath
			// 
			this.buttonPath.Location = new System.Drawing.Point(264, 118);
			this.buttonPath.Name = "buttonPath";
			this.buttonPath.Size = new System.Drawing.Size(35, 20);
			this.buttonPath.TabIndex = 4;
			this.buttonPath.Text = "...";
			this.buttonPath.UseVisualStyleBackColor = true;
			this.buttonPath.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(9, 118);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(249, 20);
			this.textBoxPath.TabIndex = 3;
			// 
			// labelPath
			// 
			this.labelPath.Location = new System.Drawing.Point(9, 95);
			this.labelPath.Name = "labelPath";
			this.labelPath.Size = new System.Drawing.Size(100, 20);
			this.labelPath.TabIndex = 2;
			this.labelPath.Text = "Path:";
			// 
			// textBoxPattern
			// 
			this.textBoxPattern.Location = new System.Drawing.Point(9, 32);
			this.textBoxPattern.Multiline = true;
			this.textBoxPattern.Name = "textBoxPattern";
			this.textBoxPattern.Size = new System.Drawing.Size(290, 49);
			this.textBoxPattern.TabIndex = 1;
			// 
			// labelPattern
			// 
			this.labelPattern.Location = new System.Drawing.Point(9, 12);
			this.labelPattern.Name = "labelPattern";
			this.labelPattern.Size = new System.Drawing.Size(100, 17);
			this.labelPattern.TabIndex = 0;
			this.labelPattern.Text = "Pattern:";
			// 
			// tabPageSettings
			// 
			this.tabPageSettings.Controls.Add(this.numericUpDownThreadCount);
			this.tabPageSettings.Controls.Add(this.labelThreadCount);
			this.tabPageSettings.Controls.Add(this.buttonJavaPath);
			this.tabPageSettings.Controls.Add(this.textBoxJavaPath);
			this.tabPageSettings.Controls.Add(this.labelJavaPath);
			this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
			this.tabPageSettings.Name = "tabPageSettings";
			this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSettings.Size = new System.Drawing.Size(306, 306);
			this.tabPageSettings.TabIndex = 1;
			this.tabPageSettings.Text = "Settings";
			this.tabPageSettings.UseVisualStyleBackColor = true;
			// 
			// numericUpDownThreadCount
			// 
			this.numericUpDownThreadCount.Location = new System.Drawing.Point(92, 85);
			this.numericUpDownThreadCount.Maximum = new decimal(new int[] {
									32,
									0,
									0,
									0});
			this.numericUpDownThreadCount.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.numericUpDownThreadCount.Name = "numericUpDownThreadCount";
			this.numericUpDownThreadCount.Size = new System.Drawing.Size(47, 20);
			this.numericUpDownThreadCount.TabIndex = 4;
			this.numericUpDownThreadCount.Value = new decimal(new int[] {
									4,
									0,
									0,
									0});
			this.numericUpDownThreadCount.Visible = false;
			// 
			// labelThreadCount
			// 
			this.labelThreadCount.Location = new System.Drawing.Point(9, 85);
			this.labelThreadCount.Name = "labelThreadCount";
			this.labelThreadCount.Size = new System.Drawing.Size(77, 23);
			this.labelThreadCount.TabIndex = 3;
			this.labelThreadCount.Text = "Thread count:";
			this.labelThreadCount.Visible = false;
			// 
			// buttonJavaPath
			// 
			this.buttonJavaPath.Location = new System.Drawing.Point(264, 40);
			this.buttonJavaPath.Name = "buttonJavaPath";
			this.buttonJavaPath.Size = new System.Drawing.Size(27, 20);
			this.buttonJavaPath.TabIndex = 2;
			this.buttonJavaPath.Text = "...";
			this.buttonJavaPath.UseVisualStyleBackColor = true;
			this.buttonJavaPath.Click += new System.EventHandler(this.ButtonJavaPathClick);
			// 
			// textBoxJavaPath
			// 
			this.textBoxJavaPath.Location = new System.Drawing.Point(9, 41);
			this.textBoxJavaPath.Name = "textBoxJavaPath";
			this.textBoxJavaPath.Size = new System.Drawing.Size(249, 20);
			this.textBoxJavaPath.TabIndex = 1;
			// 
			// labelJavaPath
			// 
			this.labelJavaPath.Location = new System.Drawing.Point(9, 17);
			this.labelJavaPath.Name = "labelJavaPath";
			this.labelJavaPath.Size = new System.Drawing.Size(100, 21);
			this.labelJavaPath.TabIndex = 0;
			this.labelJavaPath.Text = "Java path:";
			// 
			// tabPageHelp
			// 
			this.tabPageHelp.Controls.Add(this.richTextBoxHelp);
			this.tabPageHelp.Location = new System.Drawing.Point(4, 22);
			this.tabPageHelp.Name = "tabPageHelp";
			this.tabPageHelp.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageHelp.Size = new System.Drawing.Size(306, 306);
			this.tabPageHelp.TabIndex = 2;
			this.tabPageHelp.Text = "Help";
			this.tabPageHelp.UseVisualStyleBackColor = true;
			// 
			// richTextBoxHelp
			// 
			this.richTextBoxHelp.Location = new System.Drawing.Point(9, 16);
			this.richTextBoxHelp.Name = "richTextBoxHelp";
			this.richTextBoxHelp.ReadOnly = true;
			this.richTextBoxHelp.Size = new System.Drawing.Size(290, 235);
			this.richTextBoxHelp.TabIndex = 0;
			this.richTextBoxHelp.Text = "\"a-z\" - Alphabet\n\n\".\" - Any character\n\n\"( )\" - Group\n\n\"[ ]\" - Character set\n\n\"|\" " +
			"- Union\n\n\"&\" - Intersection\n\n\"-\" - Subtraction\n\n\"~\" - Complement\n\n\"+\", \"*\", \"?\" " +
			"- Repetitions";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(314, 330);
			this.Controls.Add(this.tabControlMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "RegexExt";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.tabControlMain.ResumeLayout(false);
			this.tabPageMatching.ResumeLayout(false);
			this.tabPageMatching.PerformLayout();
			this.tabPageSettings.ResumeLayout(false);
			this.tabPageSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadCount)).EndInit();
			this.tabPageHelp.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.RichTextBox richTextBoxHelp;
		private System.Windows.Forms.NumericUpDown numericUpDownThreadCount;
		private System.Windows.Forms.Label labelThreadCount;
		private System.Windows.Forms.TextBox textBoxJavaPath;
		private System.Windows.Forms.Button buttonJavaPath;
		private System.Windows.Forms.Label labelJavaPath;
		private System.Windows.Forms.Button buttonRun;
		private System.Windows.Forms.Label labelResults;
		private System.Windows.Forms.RichTextBox richTextBoxResults;
		private System.Windows.Forms.Button buttonPath;
		private System.Windows.Forms.Label labelPath;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.Label labelPattern;
		private System.Windows.Forms.TextBox textBoxPattern;
		private System.Windows.Forms.TabPage tabPageHelp;
		private System.Windows.Forms.TabPage tabPageSettings;
		private System.Windows.Forms.TabPage tabPageMatching;
		private System.Windows.Forms.TabControl tabControlMain;
	}
}
