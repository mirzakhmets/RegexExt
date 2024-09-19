
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegexExt
{
  public class MainForm : Form
  {
    private IContainer components = (IContainer) null;
    private CheckBox checkBoxDeterministic;
    private FolderBrowserDialog folderBrowserDialog;
    private RichTextBox richTextBoxHelp;
    private NumericUpDown numericUpDownThreadCount;
    private Label labelThreadCount;
    private TextBox textBoxJavaPath;
    private Button buttonJavaPath;
    private Label labelJavaPath;
    private Button buttonRun;
    private Label labelResults;
    private RichTextBox richTextBoxResults;
    private Button buttonPath;
    private Label labelPath;
    private TextBox textBoxPath;
    private Label labelPattern;
    private TextBox textBoxPattern;
    private TabPage tabPageHelp;
    private TabPage tabPageSettings;
    private TabPage tabPageMatching;
    private TabControl tabControlMain;

    public void CheckRuns() {
		try {
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\OVG-Developers", true);
			
			int runs = -1;
			
			if (key != null && key.GetValue("Runs") != null) {
				runs = (int) key.GetValue("Runs");
			} else {
				key = Registry.CurrentUser.CreateSubKey("Software\\OVG-Developers");
			}
			
			runs = runs + 1;
			
			key.SetValue("Runs", runs);
			
			if (runs > 10) {
				System.Windows.Forms.MessageBox.Show("Number of runs expired.\n"
							+ "Please register the application (visit https://ovg-developers.mystrikingly.com/ for purchase).");
				
				Environment.Exit(0);
			}
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
	}
	
	public bool IsRegistered() {
		try {
			RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\OVG-Developers");
			
			if (key != null && key.GetValue("Registered") != null) {
				return true;
			}
		} catch (Exception e) {
			Console.WriteLine(e.Message);
		}
		
		return false;
	}
    
    public MainForm() {
    	this.InitializeComponent();
    }

    private void TabPageMatchingClick(object sender, EventArgs e)
    {
    }

    private void Button1Click(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.textBoxPath.Text = this.folderBrowserDialog.SelectedPath;
    }

    private void ButtonJavaPathClick(object sender, EventArgs e)
    {
      if (this.folderBrowserDialog.ShowDialog() != DialogResult.OK)
        return;
      this.textBoxJavaPath.Text = this.folderBrowserDialog.SelectedPath;
    }

    private void Search(string path)
    {
      Application.DoEvents();
      foreach (string enumerateDirectory in Directory.EnumerateDirectories(path))
        this.Search(enumerateDirectory);
      foreach (string enumerateFile in Directory.EnumerateFiles(path))
      {
        ProcessStartInfo processStartInfo = new ProcessStartInfo((this.textBoxJavaPath.Text.Length > 0 ? this.textBoxJavaPath.Text + "\\" : "") + "java");
        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.UseShellExecute = false;
        string str = "";
        if (this.checkBoxDeterministic.Checked)
          str = " -d ";
        processStartInfo.Arguments = " -jar \"" + Environment.CurrentDirectory + "\\regexplus.jar" + str + "\" \"" + this.textBoxPattern.Text + "\" \"" + enumerateFile + "\"";
        Process process = new Process();
        process.StartInfo = processStartInfo;
        process.Start();
        process.WaitForExit();
        if (process.ExitCode == 0)
        {
          RichTextBox richTextBoxResults1 = this.richTextBoxResults;
          richTextBoxResults1.Text = richTextBoxResults1.Text + enumerateFile + ":\n";
          string end = process.StandardOutput.ReadToEnd();
          RichTextBox richTextBoxResults2 = this.richTextBoxResults;
          richTextBoxResults2.Text = richTextBoxResults2.Text + "\t" + end + "\n";
        }
      }
    }

    private void ButtonRunClick(object sender, EventArgs e)
    {
      this.richTextBoxResults.Text = "";
      this.Search(this.textBoxPath.Text);
    }

    private void MainFormLoad(object sender, EventArgs e)
    {
      this.textBoxJavaPath.Text = Environment.GetEnvironmentVariable("JAVA_PATH");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

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
    	this.checkBoxDeterministic = new System.Windows.Forms.CheckBox();
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
    	this.tabControlMain.Location = new System.Drawing.Point(0, 1);
    	this.tabControlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabControlMain.Name = "tabControlMain";
    	this.tabControlMain.SelectedIndex = 0;
    	this.tabControlMain.Size = new System.Drawing.Size(419, 409);
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
    	this.tabPageMatching.Location = new System.Drawing.Point(4, 25);
    	this.tabPageMatching.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageMatching.Name = "tabPageMatching";
    	this.tabPageMatching.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageMatching.Size = new System.Drawing.Size(411, 380);
    	this.tabPageMatching.TabIndex = 0;
    	this.tabPageMatching.Text = "Matching";
    	this.tabPageMatching.UseVisualStyleBackColor = true;
    	this.tabPageMatching.Click += new System.EventHandler(this.TabPageMatchingClick);
    	// 
    	// buttonRun
    	// 
    	this.buttonRun.Location = new System.Drawing.Point(145, 337);
    	this.buttonRun.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonRun.Name = "buttonRun";
    	this.buttonRun.Size = new System.Drawing.Size(111, 26);
    	this.buttonRun.TabIndex = 7;
    	this.buttonRun.Text = "Run";
    	this.buttonRun.UseVisualStyleBackColor = true;
    	this.buttonRun.Click += new System.EventHandler(this.ButtonRunClick);
    	// 
    	// richTextBoxResults
    	// 
    	this.richTextBoxResults.Location = new System.Drawing.Point(12, 208);
    	this.richTextBoxResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.richTextBoxResults.Name = "richTextBoxResults";
    	this.richTextBoxResults.ReadOnly = true;
    	this.richTextBoxResults.Size = new System.Drawing.Size(385, 109);
    	this.richTextBoxResults.TabIndex = 6;
    	this.richTextBoxResults.Text = "";
    	// 
    	// labelResults
    	// 
    	this.labelResults.Location = new System.Drawing.Point(12, 190);
    	this.labelResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelResults.Name = "labelResults";
    	this.labelResults.Size = new System.Drawing.Size(133, 15);
    	this.labelResults.TabIndex = 5;
    	this.labelResults.Text = "Results:";
    	// 
    	// buttonPath
    	// 
    	this.buttonPath.Location = new System.Drawing.Point(352, 145);
    	this.buttonPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonPath.Name = "buttonPath";
    	this.buttonPath.Size = new System.Drawing.Size(47, 25);
    	this.buttonPath.TabIndex = 4;
    	this.buttonPath.Text = "...";
    	this.buttonPath.UseVisualStyleBackColor = true;
    	this.buttonPath.Click += new System.EventHandler(this.Button1Click);
    	// 
    	// textBoxPath
    	// 
    	this.textBoxPath.Location = new System.Drawing.Point(12, 145);
    	this.textBoxPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.textBoxPath.Name = "textBoxPath";
    	this.textBoxPath.Size = new System.Drawing.Size(331, 22);
    	this.textBoxPath.TabIndex = 3;
    	// 
    	// labelPath
    	// 
    	this.labelPath.Location = new System.Drawing.Point(12, 117);
    	this.labelPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelPath.Name = "labelPath";
    	this.labelPath.Size = new System.Drawing.Size(133, 25);
    	this.labelPath.TabIndex = 2;
    	this.labelPath.Text = "Path:";
    	// 
    	// textBoxPattern
    	// 
    	this.textBoxPattern.Location = new System.Drawing.Point(12, 39);
    	this.textBoxPattern.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.textBoxPattern.Multiline = true;
    	this.textBoxPattern.Name = "textBoxPattern";
    	this.textBoxPattern.Size = new System.Drawing.Size(385, 59);
    	this.textBoxPattern.TabIndex = 1;
    	// 
    	// labelPattern
    	// 
    	this.labelPattern.Location = new System.Drawing.Point(12, 15);
    	this.labelPattern.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelPattern.Name = "labelPattern";
    	this.labelPattern.Size = new System.Drawing.Size(133, 21);
    	this.labelPattern.TabIndex = 0;
    	this.labelPattern.Text = "Pattern:";
    	// 
    	// tabPageSettings
    	// 
    	this.tabPageSettings.Controls.Add(this.checkBoxDeterministic);
    	this.tabPageSettings.Controls.Add(this.numericUpDownThreadCount);
    	this.tabPageSettings.Controls.Add(this.labelThreadCount);
    	this.tabPageSettings.Controls.Add(this.buttonJavaPath);
    	this.tabPageSettings.Controls.Add(this.textBoxJavaPath);
    	this.tabPageSettings.Controls.Add(this.labelJavaPath);
    	this.tabPageSettings.Location = new System.Drawing.Point(4, 25);
    	this.tabPageSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageSettings.Name = "tabPageSettings";
    	this.tabPageSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageSettings.Size = new System.Drawing.Size(411, 380);
    	this.tabPageSettings.TabIndex = 1;
    	this.tabPageSettings.Text = "Settings";
    	this.tabPageSettings.UseVisualStyleBackColor = true;
    	// 
    	// checkBoxDeterministic
    	// 
    	this.checkBoxDeterministic.Location = new System.Drawing.Point(12, 97);
    	this.checkBoxDeterministic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.checkBoxDeterministic.Name = "checkBoxDeterministic";
    	this.checkBoxDeterministic.Size = new System.Drawing.Size(181, 22);
    	this.checkBoxDeterministic.TabIndex = 5;
    	this.checkBoxDeterministic.Text = "Deterministic";
    	this.checkBoxDeterministic.UseVisualStyleBackColor = true;
    	this.checkBoxDeterministic.Visible = false;
    	// 
    	// numericUpDownThreadCount
    	// 
    	this.numericUpDownThreadCount.Location = new System.Drawing.Point(123, 148);
    	this.numericUpDownThreadCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
    	this.numericUpDownThreadCount.Size = new System.Drawing.Size(63, 22);
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
    	this.labelThreadCount.Location = new System.Drawing.Point(12, 150);
    	this.labelThreadCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelThreadCount.Name = "labelThreadCount";
    	this.labelThreadCount.Size = new System.Drawing.Size(103, 28);
    	this.labelThreadCount.TabIndex = 3;
    	this.labelThreadCount.Text = "Thread count:";
    	this.labelThreadCount.Visible = false;
    	// 
    	// buttonJavaPath
    	// 
    	this.buttonJavaPath.Location = new System.Drawing.Point(352, 49);
    	this.buttonJavaPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.buttonJavaPath.Name = "buttonJavaPath";
    	this.buttonJavaPath.Size = new System.Drawing.Size(36, 25);
    	this.buttonJavaPath.TabIndex = 2;
    	this.buttonJavaPath.Text = "...";
    	this.buttonJavaPath.UseVisualStyleBackColor = true;
    	this.buttonJavaPath.Click += new System.EventHandler(this.ButtonJavaPathClick);
    	// 
    	// textBoxJavaPath
    	// 
    	this.textBoxJavaPath.Location = new System.Drawing.Point(12, 50);
    	this.textBoxJavaPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.textBoxJavaPath.Name = "textBoxJavaPath";
    	this.textBoxJavaPath.Size = new System.Drawing.Size(331, 22);
    	this.textBoxJavaPath.TabIndex = 1;
    	// 
    	// labelJavaPath
    	// 
    	this.labelJavaPath.Location = new System.Drawing.Point(12, 21);
    	this.labelJavaPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
    	this.labelJavaPath.Name = "labelJavaPath";
    	this.labelJavaPath.Size = new System.Drawing.Size(133, 26);
    	this.labelJavaPath.TabIndex = 0;
    	this.labelJavaPath.Text = "Java path:";
    	// 
    	// tabPageHelp
    	// 
    	this.tabPageHelp.Controls.Add(this.richTextBoxHelp);
    	this.tabPageHelp.Location = new System.Drawing.Point(4, 25);
    	this.tabPageHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageHelp.Name = "tabPageHelp";
    	this.tabPageHelp.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.tabPageHelp.Size = new System.Drawing.Size(411, 380);
    	this.tabPageHelp.TabIndex = 2;
    	this.tabPageHelp.Text = "Help";
    	this.tabPageHelp.UseVisualStyleBackColor = true;
    	// 
    	// richTextBoxHelp
    	// 
    	this.richTextBoxHelp.Location = new System.Drawing.Point(12, 20);
    	this.richTextBoxHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.richTextBoxHelp.Name = "richTextBoxHelp";
    	this.richTextBoxHelp.ReadOnly = true;
    	this.richTextBoxHelp.Size = new System.Drawing.Size(385, 288);
    	this.richTextBoxHelp.TabIndex = 0;
    	this.richTextBoxHelp.Text = "\"a-z\" - Alphabet\n\n\".\" - Any character\n\n\"( )\" - Group\n\n\"[ ]\" - Character set\n\n\"|\" " +
	"- Union\n\n\"&\" - Intersection\n\n\"-\" - Subtraction\n\n\"~\" - Complement\n\n\"+\", \"*\", \"?\" " +
	"- Repetitions";
    	// 
    	// MainForm
    	// 
    	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    	this.ClientSize = new System.Drawing.Size(419, 406);
    	this.Controls.Add(this.tabControlMain);
    	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
    	this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
    	this.MaximizeBox = false;
    	this.Name = "MainForm";
    	this.Text = "RegexExt";
    	this.Load += new System.EventHandler(this.MainFormLoad);
    	this.Shown += new System.EventHandler(this.MainFormShown);
    	this.tabControlMain.ResumeLayout(false);
    	this.tabPageMatching.ResumeLayout(false);
    	this.tabPageMatching.PerformLayout();
    	this.tabPageSettings.ResumeLayout(false);
    	this.tabPageSettings.PerformLayout();
    	((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreadCount)).EndInit();
    	this.tabPageHelp.ResumeLayout(false);
    	this.ResumeLayout(false);

    }
		void MainFormShown(object sender, EventArgs e)
		{
			if (!IsRegistered()) {
				CheckRuns();
			}
		}
  }
}
