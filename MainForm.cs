
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

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
      ComponentResourceManager resources = new ComponentResourceManager(typeof (MainForm));
      this.tabControlMain = new TabControl();
      this.tabPageMatching = new TabPage();
      this.buttonRun = new Button();
      this.richTextBoxResults = new RichTextBox();
      this.labelResults = new Label();
      this.buttonPath = new Button();
      this.textBoxPath = new TextBox();
      this.labelPath = new Label();
      this.textBoxPattern = new TextBox();
      this.labelPattern = new Label();
      this.tabPageSettings = new TabPage();
      this.checkBoxDeterministic = new CheckBox();
      this.numericUpDownThreadCount = new NumericUpDown();
      this.labelThreadCount = new Label();
      this.buttonJavaPath = new Button();
      this.textBoxJavaPath = new TextBox();
      this.labelJavaPath = new Label();
      this.tabPageHelp = new TabPage();
      this.richTextBoxHelp = new RichTextBox();
      this.folderBrowserDialog = new FolderBrowserDialog();
      this.tabControlMain.SuspendLayout();
      this.tabPageMatching.SuspendLayout();
      this.tabPageSettings.SuspendLayout();
      this.numericUpDownThreadCount.BeginInit();
      this.tabPageHelp.SuspendLayout();
      this.SuspendLayout();
      this.tabControlMain.Controls.Add((Control) this.tabPageMatching);
      this.tabControlMain.Controls.Add((Control) this.tabPageSettings);
      this.tabControlMain.Controls.Add((Control) this.tabPageHelp);
      this.tabControlMain.Location = new Point(-1, 1);
      this.tabControlMain.Name = "tabControlMain";
      this.tabControlMain.SelectedIndex = 0;
      this.tabControlMain.Size = new Size(314, 332);
      this.tabControlMain.TabIndex = 0;
      this.tabPageMatching.Controls.Add((Control) this.buttonRun);
      this.tabPageMatching.Controls.Add((Control) this.richTextBoxResults);
      this.tabPageMatching.Controls.Add((Control) this.labelResults);
      this.tabPageMatching.Controls.Add((Control) this.buttonPath);
      this.tabPageMatching.Controls.Add((Control) this.textBoxPath);
      this.tabPageMatching.Controls.Add((Control) this.labelPath);
      this.tabPageMatching.Controls.Add((Control) this.textBoxPattern);
      this.tabPageMatching.Controls.Add((Control) this.labelPattern);
      this.tabPageMatching.Location = new Point(4, 22);
      this.tabPageMatching.Name = "tabPageMatching";
      this.tabPageMatching.Padding = new Padding(3);
      this.tabPageMatching.Size = new Size(306, 306);
      this.tabPageMatching.TabIndex = 0;
      this.tabPageMatching.Text = "Matching";
      this.tabPageMatching.UseVisualStyleBackColor = true;
      this.tabPageMatching.Click += new EventHandler(this.TabPageMatchingClick);
      this.buttonRun.Location = new Point(109, 274);
      this.buttonRun.Name = "buttonRun";
      this.buttonRun.Size = new Size(83, 21);
      this.buttonRun.TabIndex = 7;
      this.buttonRun.Text = "Run";
      this.buttonRun.UseVisualStyleBackColor = true;
      this.buttonRun.Click += new EventHandler(this.ButtonRunClick);
      this.richTextBoxResults.Location = new Point(9, 169);
      this.richTextBoxResults.Name = "richTextBoxResults";
      this.richTextBoxResults.ReadOnly = true;
      this.richTextBoxResults.Size = new Size(290, 89);
      this.richTextBoxResults.TabIndex = 6;
      this.richTextBoxResults.Text = "";
      this.labelResults.Location = new Point(9, 154);
      this.labelResults.Name = "labelResults";
      this.labelResults.Size = new Size(100, 12);
      this.labelResults.TabIndex = 5;
      this.labelResults.Text = "Results:";
      this.buttonPath.Location = new Point(264, 118);
      this.buttonPath.Name = "buttonPath";
      this.buttonPath.Size = new Size(35, 20);
      this.buttonPath.TabIndex = 4;
      this.buttonPath.Text = "...";
      this.buttonPath.UseVisualStyleBackColor = true;
      this.buttonPath.Click += new EventHandler(this.Button1Click);
      this.textBoxPath.Location = new Point(9, 118);
      this.textBoxPath.Name = "textBoxPath";
      this.textBoxPath.Size = new Size(249, 20);
      this.textBoxPath.TabIndex = 3;
      this.labelPath.Location = new Point(9, 95);
      this.labelPath.Name = "labelPath";
      this.labelPath.Size = new Size(100, 20);
      this.labelPath.TabIndex = 2;
      this.labelPath.Text = "Path:";
      this.textBoxPattern.Location = new Point(9, 32);
      this.textBoxPattern.Multiline = true;
      this.textBoxPattern.Name = "textBoxPattern";
      this.textBoxPattern.Size = new Size(290, 49);
      this.textBoxPattern.TabIndex = 1;
      this.labelPattern.Location = new Point(9, 12);
      this.labelPattern.Name = "labelPattern";
      this.labelPattern.Size = new Size(100, 17);
      this.labelPattern.TabIndex = 0;
      this.labelPattern.Text = "Pattern:";
      this.tabPageSettings.Controls.Add((Control) this.checkBoxDeterministic);
      this.tabPageSettings.Controls.Add((Control) this.numericUpDownThreadCount);
      this.tabPageSettings.Controls.Add((Control) this.labelThreadCount);
      this.tabPageSettings.Controls.Add((Control) this.buttonJavaPath);
      this.tabPageSettings.Controls.Add((Control) this.textBoxJavaPath);
      this.tabPageSettings.Controls.Add((Control) this.labelJavaPath);
      this.tabPageSettings.Location = new Point(4, 22);
      this.tabPageSettings.Name = "tabPageSettings";
      this.tabPageSettings.Padding = new Padding(3);
      this.tabPageSettings.Size = new Size(306, 306);
      this.tabPageSettings.TabIndex = 1;
      this.tabPageSettings.Text = "Settings";
      this.tabPageSettings.UseVisualStyleBackColor = true;
      this.checkBoxDeterministic.Location = new Point(9, 79);
      this.checkBoxDeterministic.Name = "checkBoxDeterministic";
      this.checkBoxDeterministic.Size = new Size(136, 18);
      this.checkBoxDeterministic.TabIndex = 5;
      this.checkBoxDeterministic.Text = "Deterministic";
      this.checkBoxDeterministic.UseVisualStyleBackColor = true;
      this.checkBoxDeterministic.Visible = false;
      this.numericUpDownThreadCount.Location = new Point(92, 120);
      this.numericUpDownThreadCount.Maximum = new Decimal(new int[4]
      {
        32,
        0,
        0,
        0
      });
      this.numericUpDownThreadCount.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDownThreadCount.Name = "numericUpDownThreadCount";
      this.numericUpDownThreadCount.Size = new Size(47, 20);
      this.numericUpDownThreadCount.TabIndex = 4;
      this.numericUpDownThreadCount.Value = new Decimal(new int[4]
      {
        4,
        0,
        0,
        0
      });
      this.numericUpDownThreadCount.Visible = false;
      this.labelThreadCount.Location = new Point(9, 122);
      this.labelThreadCount.Name = "labelThreadCount";
      this.labelThreadCount.Size = new Size(77, 23);
      this.labelThreadCount.TabIndex = 3;
      this.labelThreadCount.Text = "Thread count:";
      this.labelThreadCount.Visible = false;
      this.buttonJavaPath.Location = new Point(264, 40);
      this.buttonJavaPath.Name = "buttonJavaPath";
      this.buttonJavaPath.Size = new Size(27, 20);
      this.buttonJavaPath.TabIndex = 2;
      this.buttonJavaPath.Text = "...";
      this.buttonJavaPath.UseVisualStyleBackColor = true;
      this.buttonJavaPath.Click += new EventHandler(this.ButtonJavaPathClick);
      this.textBoxJavaPath.Location = new Point(9, 41);
      this.textBoxJavaPath.Name = "textBoxJavaPath";
      this.textBoxJavaPath.Size = new Size(249, 20);
      this.textBoxJavaPath.TabIndex = 1;
      this.labelJavaPath.Location = new Point(9, 17);
      this.labelJavaPath.Name = "labelJavaPath";
      this.labelJavaPath.Size = new Size(100, 21);
      this.labelJavaPath.TabIndex = 0;
      this.labelJavaPath.Text = "Java path:";
      this.tabPageHelp.Controls.Add((Control) this.richTextBoxHelp);
      this.tabPageHelp.Location = new Point(4, 22);
      this.tabPageHelp.Name = "tabPageHelp";
      this.tabPageHelp.Padding = new Padding(3);
      this.tabPageHelp.Size = new Size(306, 306);
      this.tabPageHelp.TabIndex = 2;
      this.tabPageHelp.Text = "Help";
      this.tabPageHelp.UseVisualStyleBackColor = true;
      this.richTextBoxHelp.Location = new Point(9, 16);
      this.richTextBoxHelp.Name = "richTextBoxHelp";
      this.richTextBoxHelp.ReadOnly = true;
      this.richTextBoxHelp.Size = new Size(290, 235);
      this.richTextBoxHelp.TabIndex = 0;
      this.richTextBoxHelp.Text = "\"a-z\" - Alphabet\n\n\".\" - Any character\n\n\"( )\" - Group\n\n\"[ ]\" - Character set\n\n\"|\" - Union\n\n\"&\" - Intersection\n\n\"-\" - Subtraction\n\n\"~\" - Complement\n\n\"+\", \"*\", \"?\" - Repetitions";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(314, 330);
      this.Controls.Add((Control) this.tabControlMain);
      this.Icon = (Icon) resources.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.Text = "RegexExt";
      this.Load += new EventHandler(this.MainFormLoad);
      this.tabControlMain.ResumeLayout(false);
      this.tabPageMatching.ResumeLayout(false);
      this.tabPageMatching.PerformLayout();
      this.tabPageSettings.ResumeLayout(false);
      this.tabPageSettings.PerformLayout();
      this.numericUpDownThreadCount.EndInit();
      this.tabPageHelp.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
