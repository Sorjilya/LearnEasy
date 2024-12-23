
namespace LearnEasy
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.wordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.vacabularyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.matchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statistiksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lanFromtoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.performanceCounter1 = new System.Diagnostics.PerformanceCounter();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(130)))), ((int)(((byte)(26)))));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordsToolStripMenuItem,
            this.gamesToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// wordsToolStripMenuItem
			// 
			this.wordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWordToolStripMenuItem,
            this.deleteWordToolStripMenuItem,
            this.addGroupToolStripMenuItem,
            this.deleteGroupToolStripMenuItem,
            this.vacabularyToolStripMenuItem});
			this.wordsToolStripMenuItem.Name = "wordsToolStripMenuItem";
			this.wordsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.wordsToolStripMenuItem.Text = "Words";
			// 
			// addWordToolStripMenuItem
			// 
			this.addWordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(177)))), ((int)(((byte)(71)))));
			this.addWordToolStripMenuItem.Name = "addWordToolStripMenuItem";
			this.addWordToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.addWordToolStripMenuItem.Text = "Add word";
			this.addWordToolStripMenuItem.Click += new System.EventHandler(this.addWordToolStripMenuItem_Click);
			// 
			// deleteWordToolStripMenuItem
			// 
			this.deleteWordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(177)))), ((int)(((byte)(71)))));
			this.deleteWordToolStripMenuItem.Name = "deleteWordToolStripMenuItem";
			this.deleteWordToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.deleteWordToolStripMenuItem.Text = "Delete word";
			this.deleteWordToolStripMenuItem.Click += new System.EventHandler(this.deleteWordToolStripMenuItem_Click);
			// 
			// addGroupToolStripMenuItem
			// 
			this.addGroupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(177)))), ((int)(((byte)(71)))));
			this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
			this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.addGroupToolStripMenuItem.Text = "Add group";
			this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
			// 
			// deleteGroupToolStripMenuItem
			// 
			this.deleteGroupToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(177)))), ((int)(((byte)(71)))));
			this.deleteGroupToolStripMenuItem.Name = "deleteGroupToolStripMenuItem";
			this.deleteGroupToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.deleteGroupToolStripMenuItem.Text = "Delete group";
			this.deleteGroupToolStripMenuItem.Click += new System.EventHandler(this.deleteGroupToolStripMenuItem_Click);
			// 
			// vacabularyToolStripMenuItem
			// 
			this.vacabularyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(177)))), ((int)(((byte)(71)))));
			this.vacabularyToolStripMenuItem.Name = "vacabularyToolStripMenuItem";
			this.vacabularyToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.vacabularyToolStripMenuItem.Text = "Vacabulary";
			this.vacabularyToolStripMenuItem.Click += new System.EventHandler(this.vacabularyToolStripMenuItem_Click);
			// 
			// gamesToolStripMenuItem
			// 
			this.gamesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.matchesToolStripMenuItem,
            this.cardsToolStripMenuItem});
			this.gamesToolStripMenuItem.Name = "gamesToolStripMenuItem";
			this.gamesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.gamesToolStripMenuItem.Text = "Games";
			// 
			// matchesToolStripMenuItem
			// 
			this.matchesToolStripMenuItem.Name = "matchesToolStripMenuItem";
			this.matchesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.matchesToolStripMenuItem.Text = "Matches";
			this.matchesToolStripMenuItem.Click += new System.EventHandler(this.matchesToolStripMenuItem_Click);
			// 
			// cardsToolStripMenuItem
			// 
			this.cardsToolStripMenuItem.Name = "cardsToolStripMenuItem";
			this.cardsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cardsToolStripMenuItem.Text = "Cards";
			this.cardsToolStripMenuItem.Click += new System.EventHandler(this.cardsToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languageToolStripMenuItem,
            this.statistiksToolStripMenuItem,
            this.lanFromtoToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.languageToolStripMenuItem.Text = "Language";
			// 
			// statistiksToolStripMenuItem
			// 
			this.statistiksToolStripMenuItem.Name = "statistiksToolStripMenuItem";
			this.statistiksToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.statistiksToolStripMenuItem.Text = "Statistics";
			this.statistiksToolStripMenuItem.Click += new System.EventHandler(this.statistiksToolStripMenuItem_Click);
			// 
			// lanFromtoToolStripMenuItem
			// 
			this.lanFromtoToolStripMenuItem.Name = "lanFromtoToolStripMenuItem";
			this.lanFromtoToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
			this.lanFromtoToolStripMenuItem.Text = "Lan from-to";
			this.lanFromtoToolStripMenuItem.Click += new System.EventHandler(this.lanFromtoToolStripMenuItem_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer2
			// 
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(193)))), ((int)(((byte)(133)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.menuStrip1);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			//((System.ComponentModel.ISupportInitialize)(this.performanceCounter1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem wordsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addWordToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteWordToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem vacabularyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gamesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem matchesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cardsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem statistiksToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lanFromtoToolStripMenuItem;
		private System.Diagnostics.PerformanceCounter performanceCounter1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer2;
	}
}

