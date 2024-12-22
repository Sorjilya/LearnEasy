using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;

namespace LearnEasy
{
	public partial class Form1 : Form
	{
		int matchTimer = 0;
		int matchPoints = 0;
		int maxmatchesPoints = 0;
		int dif = 1;
		ProgressBar MatchesBar;
		Button StartMatchesButton;
		TextBox mainwordBox;
		ComboBox mainWordLanBox;
		TextBox secondwordBox;
		ComboBox secondWordLanBox;
		ComboBox groupWordLanBox;
		ComboBox FromLanBox;
		ComboBox ToLanBox;
		ComboBox WichGraphDate;
		PictureBox ResultGraphs;
		Form AddWord;
		Form AddGroup;
		Form DeleteWord;
		Form DeleteGroup;
		Form ChangeFromTo;
		Form MatchesGameForm;
		Form endMatchesForm;
		TextBox GroupBox;
		TextBox DelWordBox;
		ComboBox DelGroupBox;
		ComboBox MatchesGroupBox;
		ComboBox MatchesDifficultyBox;
		ListBox GroupsList;
		ListBox GamesList;
		Label Gr;
		Label MatchesPoints;
		Label Difficultylabel;
		Label Grouplabel;
		DataGridView Vac;
		List<DoubleWord> WordsForMatches;
		List<ToggleButton> MatchesButtons;
		JsonWordsFile VacabularyFile = new JsonWordsFile();
		JsonScores ResultsFile = new JsonScores();
		List<Word> Vacabulary = new List<Word>();
		List<Results> Scores = new List<Results>();
		List<string> groups = new List<string>();
		string From = "ru";
		string To = "eng";
		void refreshPage()
		{
			GroupsList.Hide();	
		}
		public Form1()
		{
			VacabularyFile.SetPath("");
			VacabularyFile.SetName("words.json");
			ResultsFile.SetPath("");
			ResultsFile.SetName("res.json");
			Vacabulary = VacabularyFile.LoadFromFile();
			for(int i = 0; i < Vacabulary.Count; i++)
			{
				if (!groups.Contains(Vacabulary[i].Group))
				{
					groups.Add(Vacabulary[i].Group);
				}
			}
			Scores = ResultsFile.LoadFromFile();
			for (int i = 0; i < Scores.Count; i++)
			{
				if (Scores[i].GameName == "Matches")
				{
					if(Scores[i].score > maxmatchesPoints)
					{
						maxmatchesPoints = Scores[i].score;
					}
				}
			}
			InitializeComponent();
			menuStrip1.Renderer = new CustomToolStripRenderer();
			ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		private void addWordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddWord = new Form();
			AddWord.BackColor = Color.FromArgb(167, 193, 133);
			AddWord.Width = 600;
			AddWord.Height = 300;
			AddWord.FormBorderStyle = FormBorderStyle.FixedSingle;
			AddWord.MaximizeBox = false;
			AddWord.MinimizeBox = false;
			Label mainWordlabel = new Label();
			mainWordlabel.Text = "Enter word:";
			mainWordlabel.Font = new Font("Arial", 12);
			mainWordlabel.ForeColor = Color.Black;
			mainWordlabel.Location = new Point(20, 25);
			AddWord.Controls.Add(mainWordlabel);

			// Создание и настройка TextBox
			mainwordBox = new TextBox();
			mainwordBox.Text = "";
			mainwordBox.Font = new Font("Arial", 12);
			mainwordBox.ForeColor = Color.Black;
			mainwordBox.BackColor = Color.FromArgb(167, 193, 133);
			mainwordBox.Location = new Point(190, 20);
			mainwordBox.Size = new Size(200, 12);
			AddWord.Controls.Add(mainwordBox);

			mainWordLanBox = new ComboBox();
			mainWordLanBox.Items.Add("eng");
			mainWordLanBox.Items.Add("ru");
			mainWordLanBox.Items.Add("es");
			mainWordLanBox.Items.Add("fr");
			mainWordLanBox.BackColor = Color.FromArgb(167, 193, 133);
			mainWordLanBox.Location = new Point(400, 20);
			mainWordLanBox.Size = new Size(50, 25);
			mainWordLanBox.SelectedIndex = 1;
			mainWordLanBox.DropDownStyle = ComboBoxStyle.DropDownList;
			AddWord.Controls.Add(mainWordLanBox);

			Label secondWordlabel = new Label();
			secondWordlabel.Text = "Enter word translation:";
			secondWordlabel.Font = new Font("Arial", 12);
			secondWordlabel.ForeColor = Color.Black;
			secondWordlabel.Location = new Point(20, 75);
			secondWordlabel.Size = new Size(170, 25);
			AddWord.Controls.Add(secondWordlabel);

			// Создание и настройка TextBox
			secondwordBox = new TextBox();
			secondwordBox.Text = "";
			secondwordBox.Font = new Font("Arial", 12);
			secondwordBox.ForeColor = Color.Black;
			secondwordBox.BackColor = Color.FromArgb(167, 193, 133);
			secondwordBox.Location = new Point(190, 70);
			secondwordBox.Size = new Size(200, 12);
			AddWord.Controls.Add(secondwordBox);

			secondWordLanBox = new ComboBox();
			secondWordLanBox.Items.Add("eng");
			secondWordLanBox.Items.Add("ru");
			secondWordLanBox.Items.Add("es");
			secondWordLanBox.Items.Add("fr");
			secondWordLanBox.BackColor = Color.FromArgb(167, 193, 133);
			secondWordLanBox.Location = new Point(400, 70);
			secondWordLanBox.Size = new Size(50, 25);
			secondWordLanBox.SelectedIndex = 0;
			secondWordLanBox.DropDownStyle = ComboBoxStyle.DropDownList;
			AddWord.Controls.Add(secondWordLanBox);

			Label GroupWordlabel = new Label();
			GroupWordlabel.Text = "Choose word group:";
			GroupWordlabel.Font = new Font("Arial", 12);
			GroupWordlabel.ForeColor = Color.Black;
			GroupWordlabel.Location = new Point(20, 125);
			GroupWordlabel.Size = new Size(170, 25);
			AddWord.Controls.Add(GroupWordlabel);

			groupWordLanBox = new ComboBox();
			if (groups.Count == 0)
			{
				groupWordLanBox.Items.Add("Group1");
			}
			else
			{
				for (int i = 0; i < groups.Count; i++)
				{
					groupWordLanBox.Items.Add(groups[i]);
				}
			}
			groupWordLanBox.BackColor = Color.FromArgb(167, 193, 133);
			groupWordLanBox.Location = new Point(190, 120);
			groupWordLanBox.Size = new Size(200, 25);
			groupWordLanBox.DropDownStyle = ComboBoxStyle.DropDownList;
			AddWord.Controls.Add(groupWordLanBox);
			// Создание кнопки "Add"
			Button addButton = new Button();
			addButton.Text = "Add";
			addButton.Font = new Font("Arial", 14);
			addButton.ForeColor = Color.White;
			addButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.Location = new Point(50, 200);
			addButton.Size = new Size(100, 40);
			addButton.Click += AddWordButton_Click;
			addButton.MouseEnter += CustomButton_MouseEnter;
			addButton.MouseLeave += CustomButton_MouseLeave;
			addButton.FlatStyle = FlatStyle.Flat;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			addButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			AddWord.Controls.Add(addButton);

			// Создание кнопки "Cancel"
			Button cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Font = new Font("Arial", 14);
			cancelButton.ForeColor = Color.White;
			cancelButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			cancelButton.Location = new Point(400, 200);
			cancelButton.Size = new Size(100, 40);
			cancelButton.Click += CancelWordButton_Click;
			cancelButton.MouseEnter += CustomButton_MouseEnter;
			cancelButton.MouseLeave += CustomButton_MouseLeave;
			cancelButton.FlatStyle = FlatStyle.Flat;
			cancelButton.FlatAppearance.BorderSize = 0;
			cancelButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			AddWord.Controls.Add(cancelButton);
			AddWord.Show();
		}

		private void AddWordButton_Click(object sender, EventArgs e)
		{
			if (mainwordBox.Text != "" && mainWordLanBox.Text != "" && secondwordBox.Text != "" && secondWordLanBox.Text != "" && groupWordLanBox.Text != "")
			{
				List<Word> data = new List<Word>();
				Word w = new Word();
				List<WordWithLan> wl = new List<WordWithLan>();
				WordWithLan t1 = new WordWithLan();
				t1.Word = mainwordBox.Text;
				t1.Lan = mainWordLanBox.Text;
				wl.Add(t1);
				WordWithLan t2 = new WordWithLan();
				t2.Word = secondwordBox.Text;
				t2.Lan = secondWordLanBox.Text;
				wl.Add(t2);
				w.Group = groupWordLanBox.Text;
				w.Words = wl;
				data.Add(w);
				VacabularyFile.SaveToFile(data);
				Vacabulary.Add(w);
				AddWord.Hide();
			}
		}

		private void CancelWordButton_Click(object sender, EventArgs e)
		{
			AddWord.Hide();
		}

		private void CustomButton_MouseEnter(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			button.BackColor = ColorTranslator.FromHtml("#8BA76A");
		}

		private void CustomButton_MouseLeave(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			button.BackColor = ColorTranslator.FromHtml("#8BA76A");
		}

		private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddGroup = new Form();
			AddGroup.BackColor = Color.FromArgb(167, 193, 133);
			AddGroup.Width = 450;
			AddGroup.Height = 200;
			AddGroup.FormBorderStyle = FormBorderStyle.FixedSingle;
			AddGroup.MaximizeBox = false;
			AddGroup.MinimizeBox = false;
			Label GroupWordlabel = new Label();
			GroupWordlabel.Text = "Enter groups name:";
			GroupWordlabel.Font = new Font("Arial", 12);
			GroupWordlabel.ForeColor = Color.Black;
			GroupWordlabel.Location = new Point(20, 25);
			GroupWordlabel.Size = new Size(170, 25);
			AddGroup.Controls.Add(GroupWordlabel);

			// Создание и настройка TextBox
			GroupBox = new TextBox();
			GroupBox.Text = "";
			GroupBox.Font = new Font("Arial", 12);
			GroupBox.ForeColor = Color.Black;
			GroupBox.BackColor = Color.FromArgb(167, 193, 133);
			GroupBox.Location = new Point(190, 25);
			GroupBox.Size = new Size(200, 12);
			AddGroup.Controls.Add(GroupBox);
			// Создание кнопки "Add"
			Button addButton = new Button();
			addButton.Text = "Add";
			addButton.Font = new Font("Arial", 14);
			addButton.ForeColor = Color.White;
			addButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.Location = new Point(50, 100);
			addButton.Size = new Size(100, 40);
			addButton.Click += AddGroupButton_Click;
			addButton.MouseEnter += CustomButton_MouseEnter;
			addButton.MouseLeave += CustomButton_MouseLeave;
			addButton.FlatStyle = FlatStyle.Flat;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			addButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			AddGroup.Controls.Add(addButton);

			// Создание кнопки "Cancel"
			Button cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Font = new Font("Arial", 14);
			cancelButton.ForeColor = Color.White;
			cancelButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			cancelButton.Location = new Point(300, 100);
			cancelButton.Size = new Size(100, 40);
			cancelButton.Click += CancelGroupButton_Click;
			cancelButton.MouseEnter += CustomButton_MouseEnter;
			cancelButton.MouseLeave += CustomButton_MouseLeave;
			cancelButton.FlatStyle = FlatStyle.Flat;
			cancelButton.FlatAppearance.BorderSize = 0;
			cancelButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			AddGroup.Controls.Add(cancelButton);
			AddGroup.Show();

		}
		private void AddGroupButton_Click(object sender, EventArgs e)
		{
			if (GroupBox.Text != "")
			{
				groups.Add(GroupBox.Text);
				AddGroup.Hide();
			}
			vacabularyToolStripMenuItem_Click(sender, e);
		}

		private void CancelGroupButton_Click(object sender, EventArgs e)
		{
			AddGroup.Hide();
		}

		private void vacabularyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (ResultGraphs != null)
			{
				ResultGraphs.Hide();
			}
			if (GamesList != null && WichGraphDate != null)
			{
				WichGraphDate.Hide();
				GamesList.Hide();
			}
			if (Gr != null && GroupsList != null && Vac != null)
			{
				Gr.Hide();
				GroupsList.Hide();
				Vac.Hide();
			}
			if (Gr != null)
			{
				Gr.Hide();
			}
			if (GroupsList != null)
			{
				GroupsList.Hide();
			}
			Gr = new Label();
			Gr.Text = "Groups";
			Gr.Font = new Font("Arial", 16);
			Gr.Location = new Point(Form1.ActiveForm.Width / 20, Form1.ActiveForm.Width / 20);
			GroupsList = new ListBox();
			GroupsList.BackColor = Color.FromArgb(150, 200, 80);
			GroupsList.Location = new Point(Form1.ActiveForm.Width/40, Form1.ActiveForm.Width/10);
			GroupsList.Size = new Size(Form1.ActiveForm.Width / 5, Form1.ActiveForm.Height*7/10);
			GroupsList.ItemHeight = Form1.ActiveForm.Height / 10;
			GroupsList.SelectedIndexChanged += GroupsList_SelectedIndexChanged;
			GroupsList.Font = new Font("Arial", 14);
			for (int i = 0; i < groups.Count; i++)
			{
				GroupsList.Items.Add(groups[i]);
			}
			this.Controls.Add(GroupsList);
			this.Controls.Add(Gr);
			GroupsList_SelectedIndexChanged(sender, e);
		}

		private void GroupsList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Vac != null)
			{
				Vac.Hide();
			}
			Vac = new DataGridView();
			Vac.Location = new Point(Form1.ActiveForm.Width / 3, Form1.ActiveForm.Height / 10);
			Vac.Size = new Size(Form1.ActiveForm.Width / 12*7, Form1.ActiveForm.Height * 7 / 10);
			Vac.ColumnCount = 2;
			Vac.ReadOnly = true;
			Vac.AllowUserToDeleteRows = false;
			Vac.AllowUserToResizeRows = false;
			Vac.AllowUserToResizeColumns = false;
			Vac.Columns[0].Name = From;
			Vac.Columns[1].Name = To;
			Vac.Columns[0].Width = Vac.Width / 7*3;
			Vac.Columns[1].Width = Vac.Width / 7*3;
			for (int i = 0; i < Vacabulary.Count; i++)
			{
				if(Vacabulary[i].Group == (string)GroupsList.SelectedItem)
				{
					string f = "";
					string s = "";
					for(int j = 0; j < Vacabulary[i].Words.Count; j++)
					{
						if(Vacabulary[i].Words[j].Lan == From)
						{
							f = Vacabulary[i].Words[j].Word;
						}
						if (Vacabulary[i].Words[j].Lan == To)
						{
							s = Vacabulary[i].Words[j].Word;
						}
					}
					if (f != "" && s != "")
					{
						Vac.Rows.Add(f, s);
					}
				}
			}
			this.Controls.Add(Vac);
		}

		private void deleteWordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteWord = new Form();
			DeleteWord.BackColor = Color.FromArgb(167, 193, 133);
			DeleteWord.Width = 550;
			DeleteWord.Height = 200;
			DeleteWord.FormBorderStyle = FormBorderStyle.FixedSingle;
			DeleteWord.MaximizeBox = false;
			DeleteWord.MinimizeBox = false;
			Label DeleteWordlabel = new Label();
			DeleteWordlabel.Text = "Enter the word to delete:";
			DeleteWordlabel.Font = new Font("Arial", 12);
			DeleteWordlabel.ForeColor = Color.Black;
			DeleteWordlabel.Location = new Point(20, 25);
			DeleteWordlabel.Size = new Size(270, 25);
			DeleteWord.Controls.Add(DeleteWordlabel);

			// Создание и настройка TextBox
			DelWordBox = new TextBox();
			DelWordBox.Text = "";
			DelWordBox.Font = new Font("Arial", 12);
			DelWordBox.ForeColor = Color.Black;
			DelWordBox.BackColor = Color.FromArgb(167, 193, 133);
			DelWordBox.Location = new Point(290, 25);
			DelWordBox.Size = new Size(200, 12);
			DeleteWord.Controls.Add(DelWordBox);
			// Создание кнопки "Add"
			Button addButton = new Button();
			addButton.Text = "Delete";
			addButton.Font = new Font("Arial", 14);
			addButton.ForeColor = Color.White;
			addButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.Location = new Point(50, 100);
			addButton.Size = new Size(100, 40);
			addButton.Click += DelWordButton_Click;
			addButton.MouseEnter += CustomButton_MouseEnter;
			addButton.MouseLeave += CustomButton_MouseLeave;
			addButton.FlatStyle = FlatStyle.Flat;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			addButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			DeleteWord.Controls.Add(addButton);

			// Создание кнопки "Cancel"
			Button cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Font = new Font("Arial", 14);
			cancelButton.ForeColor = Color.White;
			cancelButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			cancelButton.Location = new Point(400, 100);
			cancelButton.Size = new Size(100, 40);
			cancelButton.Click += CancelDelWordButton_Click;
			cancelButton.MouseEnter += CustomButton_MouseEnter;
			cancelButton.MouseLeave += CustomButton_MouseLeave;
			cancelButton.FlatStyle = FlatStyle.Flat;
			cancelButton.FlatAppearance.BorderSize = 0;
			cancelButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			DeleteWord.Controls.Add(cancelButton);
			DeleteWord.Show();
		}

		private void CancelDelWordButton_Click(object sender, EventArgs e)
		{
			DeleteWord.Hide();
		}

		private void DelWordButton_Click(object sender, EventArgs e)
		{
			VacabularyFile.DeleteWord(DelWordBox.Text);
			DeleteWord.Hide();
			List<Word> data = new List<Word>();
			for (int i = 0; i < Vacabulary.Count; i++)
			{
				bool isThere = false;
				for (int j = 0; j < Vacabulary[i].Words.Count; j++)
				{
					if (Vacabulary[i].Words[j].Word == DelWordBox.Text)
					{
						isThere = true;
						break;
					}
				}
				if (!isThere)
				{
					data.Add(Vacabulary[i]);
				}
			}
			Vacabulary = data;
			vacabularyToolStripMenuItem_Click(sender, e);
		}

		private void deleteGroupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteGroup = new Form();
			DeleteGroup.BackColor = Color.FromArgb(167, 193, 133);
			DeleteGroup.Width = 550;
			DeleteGroup.Height = 200;
			DeleteGroup.FormBorderStyle = FormBorderStyle.FixedSingle;
			DeleteGroup.MaximizeBox = false;
			DeleteGroup.MinimizeBox = false;
			Label DeleteGrouplabel = new Label();
			DeleteGrouplabel.Text = "Enter the group to delete:";
			DeleteGrouplabel.Font = new Font("Arial", 12);
			DeleteGrouplabel.ForeColor = Color.Black;
			DeleteGrouplabel.Location = new Point(20, 25);
			DeleteGrouplabel.Size = new Size(270, 25);
			DeleteGroup.Controls.Add(DeleteGrouplabel);

			// Создание и настройка TextBox
			DelGroupBox = new ComboBox();
			for (int i = 0; i < groups.Count; i++)
			{
				DelGroupBox.Items.Add(groups[i]);
			}
			DelGroupBox.SelectedIndex = 0;
			DelGroupBox.Font = new Font("Arial", 12);
			DelGroupBox.ForeColor = Color.Black;
			DelGroupBox.BackColor = Color.FromArgb(167, 193, 133);
			DelGroupBox.Location = new Point(290, 25);
			DelGroupBox.Size = new Size(200, 12);
			DeleteGroup.Controls.Add(DelGroupBox);
			// Создание кнопки "Add"
			Button addButton = new Button();
			addButton.Text = "Delete";
			addButton.Font = new Font("Arial", 14);
			addButton.ForeColor = Color.White;
			addButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.Location = new Point(50, 100);
			addButton.Size = new Size(100, 40);
			addButton.Click += DelGroupButton_Click;
			addButton.MouseEnter += CustomButton_MouseEnter;
			addButton.MouseLeave += CustomButton_MouseLeave;
			addButton.FlatStyle = FlatStyle.Flat;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			addButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			DeleteGroup.Controls.Add(addButton);

			// Создание кнопки "Cancel"
			Button cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Font = new Font("Arial", 14);
			cancelButton.ForeColor = Color.White;
			cancelButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			cancelButton.Location = new Point(400, 100);
			cancelButton.Size = new Size(100, 40);
			cancelButton.Click += CancelDelGroupButton_Click;
			cancelButton.MouseEnter += CustomButton_MouseEnter;
			cancelButton.MouseLeave += CustomButton_MouseLeave;
			cancelButton.FlatStyle = FlatStyle.Flat;
			cancelButton.FlatAppearance.BorderSize = 0;
			cancelButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			DeleteGroup.Controls.Add(cancelButton);
			DeleteGroup.Show();
		}

		private void CancelDelGroupButton_Click(object sender, EventArgs e)
		{
			DeleteGroup.Hide();
		}

		private void DelGroupButton_Click(object sender, EventArgs e)
		{
			List<Word> data = new List<Word>();
			for (int i = 0; i < Vacabulary.Count; i++)
			{
				if (Vacabulary[i].Group != DelGroupBox.Text)
				{
					data.Add(Vacabulary[i]);
				}
			}
			Vacabulary = data;
			VacabularyFile.DeleteGroup(DelGroupBox.Text);
			for(int i = 0; i < groups.Count; i++)
			{
				if(groups[i] == DelGroupBox.Text)
				{
					groups.RemoveAt(i);
				}
			}
			DeleteGroup.Hide();
			vacabularyToolStripMenuItem_Click(sender, e);
		}

		private void lanFromtoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ChangeFromTo = new Form();
			ChangeFromTo.BackColor = Color.FromArgb(167, 193, 133);
			ChangeFromTo.Width = 300;
			ChangeFromTo.Height = 220;
			ChangeFromTo.FormBorderStyle = FormBorderStyle.FixedSingle;
			ChangeFromTo.MaximizeBox = false;
			ChangeFromTo.MinimizeBox = false;
			Label Fromlabel = new Label();
			Fromlabel.Text = "Choose language From:";
			Fromlabel.Font = new Font("Arial", 12);
			Fromlabel.ForeColor = Color.Black;
			Fromlabel.Location = new Point(20, 25);
			Fromlabel.Size = new Size(180, 25);
			ChangeFromTo.Controls.Add(Fromlabel);
			Label Tolabel = new Label();
			Tolabel.Text = "Choose language To:";
			Tolabel.Font = new Font("Arial", 12);
			Tolabel.ForeColor = Color.Black;
			Tolabel.Location = new Point(20, 70);
			Tolabel.Size = new Size(180, 25);
			ChangeFromTo.Controls.Add(Tolabel);
			FromLanBox = new ComboBox();
			FromLanBox.Items.Add("eng");
			FromLanBox.Items.Add("ru");
			FromLanBox.Items.Add("es");
			FromLanBox.Items.Add("fr");
			FromLanBox.BackColor = Color.FromArgb(167, 193, 133);
			FromLanBox.Location = new Point(210, 25);
			FromLanBox.Size = new Size(50, 25);
			FromLanBox.Text = From;
			FromLanBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ChangeFromTo.Controls.Add(FromLanBox);
			ToLanBox = new ComboBox();
			ToLanBox.Items.Add("eng");
			ToLanBox.Items.Add("ru");
			ToLanBox.Items.Add("es");
			ToLanBox.Items.Add("fr");
			ToLanBox.BackColor = Color.FromArgb(167, 193, 133);
			ToLanBox.Location = new Point(210, 70);
			ToLanBox.Size = new Size(50, 25);
			ToLanBox.Text = To;
			ToLanBox.DropDownStyle = ComboBoxStyle.DropDownList;
			ChangeFromTo.Controls.Add(ToLanBox);
						// Создание кнопки "Add"
			Button addButton = new Button();
			addButton.Text = "Change";
			addButton.Font = new Font("Arial", 14);
			addButton.ForeColor = Color.White;
			addButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.Location = new Point(40, 100);
			addButton.Size = new Size(100, 40);
			addButton.Click += ChangeFromToButton_Click;
			addButton.MouseEnter += CustomButton_MouseEnter;
			addButton.MouseLeave += CustomButton_MouseLeave;
			addButton.FlatStyle = FlatStyle.Flat;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			addButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			ChangeFromTo.Controls.Add(addButton);

			// Создание кнопки "Cancel"
			Button cancelButton = new Button();
			cancelButton.Text = "Cancel";
			cancelButton.Font = new Font("Arial", 14);
			cancelButton.ForeColor = Color.White;
			cancelButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			cancelButton.Location = new Point(160, 100);
			cancelButton.Size = new Size(100, 40);
			cancelButton.Click += CancelFrometoButton_Click;
			cancelButton.MouseEnter += CustomButton_MouseEnter;
			cancelButton.MouseLeave += CustomButton_MouseLeave;
			cancelButton.FlatStyle = FlatStyle.Flat;
			cancelButton.FlatAppearance.BorderSize = 0;
			cancelButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			ChangeFromTo.Controls.Add(cancelButton);
			ChangeFromTo.Show();
		}

		private void CancelFrometoButton_Click(object sender, EventArgs e)
		{
			ChangeFromTo.Hide();
		}

		private void ChangeFromToButton_Click(object sender, EventArgs e)
		{
			From = FromLanBox.Text;
			To = ToLanBox.Text;
			ChangeFromTo.Hide();
		}

		private void matchesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MatchesGameForm = new Form();
			MatchesGameForm.Size = new Size(Form1.ActiveForm.Width/10*9, Form1.ActiveForm.Height / 10 * 9);
			MatchesGameForm.BackColor = Color.FromArgb(167, 193, 133);
			MatchesGameForm.FormBorderStyle = FormBorderStyle.FixedSingle;
			MatchesGameForm.MaximizeBox = false;
			MatchesGameForm.MinimizeBox = false;
			Grouplabel = new Label();
			Grouplabel.Text = "Enter the group:";
			Grouplabel.Font = new Font("Arial", MatchesGameForm.Size.Height/36);
			Grouplabel.ForeColor = Color.White;
			Grouplabel.Location = new Point(MatchesGameForm.Size.Height / 22, MatchesGameForm.Size.Height / 22);
			Grouplabel.Size = new Size(MatchesGameForm.Size.Width/6, MatchesGameForm.Size.Height / 18);
			Grouplabel.BackColor = Color.FromArgb(84, 130, 26);
			MatchesGameForm.Controls.Add(Grouplabel);

			MatchesGroupBox = new ComboBox();
			for (int i = 0; i < groups.Count; i++)
			{
				MatchesGroupBox.Items.Add(groups[i]);
			}
			MatchesGroupBox.Location = new Point(MatchesGameForm.Size.Height / 22 + MatchesGameForm.Size.Width / 5, MatchesGameForm.Size.Height / 22);
			MatchesGroupBox.Size = new Size(MatchesGameForm.Size.Width / 5, MatchesGameForm.Size.Height / 10);
			MatchesGroupBox.Font = new Font("Arial", MatchesGameForm.Size.Height / 36);
			MatchesGroupBox.BackColor = Color.FromArgb(167, 193, 133);
			MatchesGroupBox.SelectedIndex = 0;
			MatchesGameForm.Controls.Add(MatchesGroupBox);
			Difficultylabel = new Label();
			Difficultylabel.Text = "Enter the difficulty:";
			Difficultylabel.Font = new Font("Arial", MatchesGameForm.Size.Height / 36);
			Difficultylabel.ForeColor = Color.White;
			Difficultylabel.Location = new Point(MatchesGameForm.Size.Height / 22, MatchesGameForm.Size.Height / 7);
			Difficultylabel.Size = new Size(MatchesGameForm.Size.Width / 52*10, MatchesGameForm.Size.Height / 18);
			Difficultylabel.BackColor = Color.FromArgb(84, 130, 26);
			MatchesGameForm.Controls.Add(Difficultylabel);

			MatchesDifficultyBox = new ComboBox();
			MatchesDifficultyBox.Items.Add("Easy");
			MatchesDifficultyBox.Items.Add("Normal");
			MatchesDifficultyBox.Items.Add("Hard");
			MatchesDifficultyBox.Location = new Point(MatchesGameForm.Size.Height / 22 + MatchesGameForm.Size.Width / 5, MatchesGameForm.Size.Height / 7);
			MatchesDifficultyBox.Size = new Size(MatchesGameForm.Size.Width / 5, MatchesGameForm.Size.Height / 10);
			MatchesDifficultyBox.Font = new Font("Arial", MatchesGameForm.Size.Height / 36);
			MatchesDifficultyBox.BackColor = Color.FromArgb(167, 193, 133);
			MatchesDifficultyBox.SelectedIndex = 0;
			MatchesGameForm.Controls.Add(MatchesDifficultyBox);

			StartMatchesButton = new Button();
			StartMatchesButton.Text = "Start";
			StartMatchesButton.Font = new Font("Arial", MatchesGameForm.Size.Height / 36);
			StartMatchesButton.ForeColor = Color.White;
			StartMatchesButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			StartMatchesButton.Location = new Point(MatchesGameForm.Size.Width / 2 - MatchesGameForm.Size.Width / 6, MatchesGameForm.Size.Height - MatchesGameForm.Size.Height / 2);
			StartMatchesButton.Size = new Size(MatchesGameForm.Size.Width / 3, MatchesGameForm.Size.Height/3);
			StartMatchesButton.Click += StartMatches;
			StartMatchesButton.MouseEnter += CustomButton_MouseEnter;
			StartMatchesButton.MouseLeave += CustomButton_MouseLeave;
			StartMatchesButton.FlatStyle = FlatStyle.Flat;
			StartMatchesButton.FlatAppearance.BorderSize = 0;
			StartMatchesButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			StartMatchesButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			MatchesGameForm.Controls.Add(StartMatchesButton);
			MatchesGameForm.Show();
		}

		private void StartMatches(object sender, EventArgs e)
		{
			StartMatchesButton.Hide();
			MatchesDifficultyBox.Hide();
			MatchesGroupBox.Hide();
			Difficultylabel.Hide();
			Grouplabel.Hide();

			MatchesGame(sender, e);
		}
		ToggleButton CreateToggleMatch(int x, int y, int i)
		{
			ToggleButton w = new ToggleButton();
			w.BackColor = Color.FromArgb(126, 150, 96);
			w.Size = new Size(MatchesGameForm.Width / 5, MatchesGameForm.Height / 7);
			w.Location = new Point(x, y);
			w.Click += matchesGameButton_Click;
			w.Name = i.ToString();
			w.ForeColor = Color.White;
			w.Font = new Font("Arial", MatchesGameForm.Size.Height / 36);
			return w;
		}
		void CreateMatchesList()
		{
			WordsForMatches = new List<DoubleWord>();
			for (int i = 0; i < Vacabulary.Count; i++)
			{
				if(Vacabulary[i].Group == MatchesGroupBox.Text)
				{
					string f = "";
					string s = "";
					for(int j = 0; j < Vacabulary[i].Words.Count; j++)
					{
						if(Vacabulary[i].Words[j].Lan == From)
						{
							f = Vacabulary[i].Words[j].Word;
						}
						if (Vacabulary[i].Words[j].Lan == To)
						{
							s = Vacabulary[i].Words[j].Word;
						}
					}
					if(f != "" && s != "")
					{
						DoubleWord temp = new DoubleWord();
						temp.firstWord = f;
						temp.secondWord = s;
						WordsForMatches.Add(temp);
					}
				}
			}
		}
		private void MatchesGame(object sender, EventArgs e)
		{
			dif = MatchesDifficultyBox.SelectedIndex + 1;
			ToggleButton w11 = CreateToggleMatch(MatchesGameForm.Width / 5, MatchesGameForm.Height / 7, 0);
			ToggleButton w12 = CreateToggleMatch(MatchesGameForm.Width / 5, MatchesGameForm.Height / 7*3, 100);
			ToggleButton w13 = CreateToggleMatch(MatchesGameForm.Width / 5, MatchesGameForm.Height / 7*5, 200);
			ToggleButton w21 = CreateToggleMatch(MatchesGameForm.Width / 5*3, MatchesGameForm.Height / 7, 300);
			ToggleButton w22 = CreateToggleMatch(MatchesGameForm.Width / 5*3, MatchesGameForm.Height / 7*3, 400);
			ToggleButton w23 = CreateToggleMatch(MatchesGameForm.Width / 5*3, MatchesGameForm.Height / 7*5, 500);
			MatchesPoints = new Label();
			MatchesPoints.Font = new Font("Arial", MatchesGameForm.Size.Height / 42);
			MatchesPoints.Text = "Points: " + matchPoints + "\nMaximum Points: " + maxmatchesPoints;
			MatchesPoints.Location = new Point(MatchesGameForm.Width/2-MatchesGameForm.Width/10, MatchesGameForm.Height *8 / 10);
			MatchesPoints.Size = new Size(MatchesGameForm.Width / 5, MatchesGameForm.Height / 10);
			MatchesPoints.TextAlign = ContentAlignment.MiddleCenter;
			MatchesGameForm.Controls.Add(MatchesPoints);
			MatchesButtons = new List<ToggleButton>();
			MatchesButtons.Add(w11);
			MatchesButtons.Add(w12);
			MatchesButtons.Add(w13);
			MatchesButtons.Add(w21);
			MatchesButtons.Add(w22);
			MatchesButtons.Add(w23);
			for(int i = 0; i < MatchesButtons.Count; i++)
			{
				MatchesGameForm.Controls.Add(MatchesButtons[i]);
			}
			MatchesBar = new ProgressBar();
			MatchesBar.Location = new Point(MatchesGameForm.Width / 2 - MatchesGameForm.Width / 4, MatchesGameForm.Height / 20);
			MatchesBar.Size = new Size(MatchesGameForm.Width / 2, MatchesGameForm.Height / 17);
			MatchesBar.Value = 100;
			MatchesBar.Maximum = 1000;
			MatchesGameForm.Controls.Add(MatchesBar);
			matchTimer = 0;
			timer1.Enabled = true;
			CreateMatchesList();
			MatchesGameRound();
		}
		static List<int> GetUniqueRandomNumbersCSPRNG(int count, int min, int max)
		{
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				List<int> numbers = new List<int>();
				byte[] buffer = new byte[sizeof(int)];

				while (numbers.Count < count)
				{
					rng.GetBytes(buffer);
					int randomNumber = Math.Abs(BitConverter.ToInt32(buffer, 0)) % (max - min + 1) + min;
					if (!numbers.Contains(randomNumber))
					{
						numbers.Add(randomNumber);
					}
				}

				return numbers;
			}
		}
		private void MatchesGameRound()
		{
			List<int> fColumn = GetUniqueRandomNumbersCSPRNG(3, 0, 2);
			List<int> sColumn = GetUniqueRandomNumbersCSPRNG(3, 3, 5);
			List<int> ChosenWord = GetUniqueRandomNumbersCSPRNG(3, 0, WordsForMatches.Count-1);
			for (int i = 0; i < MatchesButtons.Count; i++)
			{
				MatchesButtons[i].Enabled = true;
				MatchesButtons[i].Show();
				MatchesButtons[i].isPressed = false;
				MatchesButtons[i].UpdateButtonAppearance();
			}
			MatchesButtons[fColumn[0]].Text = WordsForMatches[ChosenWord[0]].firstWord;
			MatchesButtons[fColumn[1]].Text = WordsForMatches[ChosenWord[1]].firstWord;
			MatchesButtons[fColumn[2]].Text = WordsForMatches[ChosenWord[2]].firstWord;
			MatchesButtons[sColumn[0]].Text = WordsForMatches[ChosenWord[0]].secondWord;
			MatchesButtons[sColumn[1]].Text = WordsForMatches[ChosenWord[1]].secondWord;
			MatchesButtons[sColumn[2]].Text = WordsForMatches[ChosenWord[2]].secondWord;
			MatchesButtons[fColumn[0]].Name = (Int32.Parse(MatchesButtons[fColumn[0]].Name)/10*10).ToString();
			MatchesButtons[fColumn[1]].Name = (Int32.Parse(MatchesButtons[fColumn[1]].Name)/10 * 10 + 1).ToString();
			MatchesButtons[fColumn[2]].Name = (Int32.Parse(MatchesButtons[fColumn[2]].Name)/10 * 10 + 2).ToString();
			MatchesButtons[sColumn[0]].Name = (Int32.Parse(MatchesButtons[sColumn[0]].Name)/10 * 10 + 5).ToString();
			MatchesButtons[sColumn[1]].Name = (Int32.Parse(MatchesButtons[sColumn[1]].Name)/10 * 10 + 4).ToString();
			MatchesButtons[sColumn[2]].Name = (Int32.Parse(MatchesButtons[sColumn[2]].Name)/10 * 10 + 3).ToString();
		}
		private void matchesGameButton_Click(object sender, EventArgs e)
		{
			ToggleButton But = (ToggleButton)(sender);
			But.isPressed = !But.isPressed;
			But.UpdateButtonAppearance();
			if (But.isPressed)
			{
				int num = Int32.Parse(But.Name) / 100;
				if (num < 3)
				{
					for (int i = 0; i < 3; i++)
					{
						if (i != num)
						{
							MatchesButtons[i].isPressed = false;
							MatchesButtons[i].UpdateButtonAppearance();
						}
					}
				}
				else
				{
					for (int i = 3; i < 6; i++)
					{
						if (i != num)
						{
							MatchesButtons[i].isPressed = false;
							MatchesButtons[i].UpdateButtonAppearance();
						}
					}
				}
				int num2 = Int32.Parse(But.Name) % 100;
				int enCount = 0;
				bool correct = false;
				for (int i = 0; i < MatchesButtons.Count; i++)
				{
					if (!MatchesButtons[i].Enabled)
					{
						enCount++;
					}
					if (MatchesButtons[i].isPressed && MatchesButtons[i].Enabled && i != num)
					{
						if(num2 + Int32.Parse(MatchesButtons[i].Name) % 100 == 5)
						{
							But.Hide();
							MatchesButtons[i].Hide();
							But.Enabled = false;
							MatchesButtons[i].Enabled = false;
							But.isPressed = false;
							MatchesButtons[i].isPressed = false;
							correct = true;
						}
						else
						{
							EndGameMatches();
						}
					}
				}
				if(enCount > 4 && correct)
				{
					matchTimer = 0;
					matchPoints += 100;
					if(maxmatchesPoints < matchPoints)
					{
						maxmatchesPoints = matchPoints;
					}
					MatchesPoints.Text = "Points: " + matchPoints + "\nMaximum Points: " + maxmatchesPoints;
					MatchesGameRound();
				}
			}

		}
		void EndGameMatches()
		{
			Results res = new Results();
			res.score = matchPoints;
			res.GameName = "Matches";
			res.data = DateTime.Now;
			List<Results> r = new List<Results>();
			r.Add(res);
			ResultsFile.SaveToFile(r);
			MatchesGameForm.Hide();
			MatchesBar.Value = 0;
			timer1.Enabled = false;
			matchTimer = 0;
			endMatchesForm = new Form();
			endMatchesForm.Size = new Size(Form1.ActiveForm.Width / 10 * 4, Form1.ActiveForm.Height / 10 * 4);
			endMatchesForm.BackColor = Color.FromArgb(167, 193, 133);
			endMatchesForm.FormBorderStyle = FormBorderStyle.FixedSingle;
			endMatchesForm.MaximizeBox = false;
			endMatchesForm.MinimizeBox = false;
			Label lb = new Label();
			lb.Font = new Font("Arial", endMatchesForm.Size.Height / 15);
			lb.Text = "Your Points: " + matchPoints + "\nMaximum Points: " + maxmatchesPoints;
			lb.Location = new Point(endMatchesForm.Width / 2 - endMatchesForm.Width / 4, endMatchesForm.Height /25);
			lb.Size = new Size(endMatchesForm.Width / 2, endMatchesForm.Height / 2);
			lb.TextAlign = ContentAlignment.MiddleCenter;
			endMatchesForm.Controls.Add(lb);

			Button addButton = new Button();
			addButton.Text = "Retry";
			addButton.Font = new Font("Arial", endMatchesForm.Size.Height / 15);
			addButton.ForeColor = Color.White;
			addButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.Location = new Point(endMatchesForm.Width* 3/ 4 - endMatchesForm.Width / 8, endMatchesForm.Height * 15 / 20 - endMatchesForm.Height / 5);
			addButton.Size = new Size(endMatchesForm.Width / 4, endMatchesForm.Height / 5);
			addButton.Click += MatchesRetry;
			addButton.MouseEnter += CustomButton_MouseEnter;
			addButton.MouseLeave += CustomButton_MouseLeave;
			addButton.FlatStyle = FlatStyle.Flat;
			addButton.FlatAppearance.BorderSize = 0;
			addButton.FlatAppearance.BorderColor = ColorTranslator.FromHtml("#8BA76A");
			addButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			addButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			endMatchesForm.Controls.Add(addButton);

			// Создание кнопки "Cancel"
			Button cancelButton = new Button();
			cancelButton.Text = "Exit";
			cancelButton.Font = new Font("Arial", endMatchesForm.Size.Height / 15);
			cancelButton.ForeColor = Color.White;
			cancelButton.BackColor = ColorTranslator.FromHtml("#8BA76A");
			cancelButton.Location = new Point(endMatchesForm.Width / 4 - endMatchesForm.Width / 8, endMatchesForm.Height *15/ 20 - endMatchesForm.Height / 5);
			cancelButton.Size = new Size(endMatchesForm.Width/4, endMatchesForm.Height/5);
			cancelButton.Click += MatchesExit;
			cancelButton.MouseEnter += CustomButton_MouseEnter;
			cancelButton.MouseLeave += CustomButton_MouseLeave;
			cancelButton.FlatStyle = FlatStyle.Flat;
			cancelButton.FlatAppearance.BorderSize = 0;
			cancelButton.FlatAppearance.MouseDownBackColor = ColorTranslator.FromHtml("#7A9C5E");
			cancelButton.FlatAppearance.MouseOverBackColor = ColorTranslator.FromHtml("#8BA76A");
			endMatchesForm.Controls.Add(cancelButton);
			endMatchesForm.Show();
			matchPoints = 0;

		}

		private void MatchesExit(object sender, EventArgs e)
		{
			endMatchesForm.Hide();
		}

		private void MatchesRetry(object sender, EventArgs e)
		{
			endMatchesForm.Hide();
			matchesToolStripMenuItem_Click(sender, e);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if ((1000 - matchTimer*3 * dif) >= 0)
			{
				MatchesBar.Value = (1000 - matchTimer*3*dif);
			}
			else
			{
				EndGameMatches();
			}
			matchTimer ++;
		}

		private void statistiksToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (GamesList != null && WichGraphDate != null)
			{
				WichGraphDate.Hide();
				GamesList.Hide();
			}
			if (Gr != null && GroupsList != null && Vac != null)
			{
				Gr.Hide();
				GroupsList.Hide();
				Vac.Hide();
			}
			WichGraphDate = new ComboBox();
			WichGraphDate.Location = new Point(Form1.ActiveForm.Width / 20, 4*Form1.ActiveForm.Height / 9);
			WichGraphDate.Size = new Size(Form1.ActiveForm.Width / 5, Form1.ActiveForm.Height / 6);
			WichGraphDate.Items.Add("Last Week");
			WichGraphDate.Items.Add("Last Mounth");
			WichGraphDate.Items.Add("All Time");
			WichGraphDate.SelectedIndexChanged += GamesList_SelectedIndexChanged;
			WichGraphDate.Font = new Font("Arial", Form1.ActiveForm.Height / 30);
			WichGraphDate.BackColor = Color.FromArgb(150, 200, 80);
			WichGraphDate.SelectedIndex = 0;
			GamesList = new ListBox();
			GamesList.Location = new Point(Form1.ActiveForm.Width/20, Form1.ActiveForm.Height/9);
			GamesList.Size = new Size(Form1.ActiveForm.Width / 5, 3*Form1.ActiveForm.Height/12);
			GamesList.ItemHeight = Form1.ActiveForm.Height / 12;
			GamesList.Items.Add("Matches");
			GamesList.Items.Add("Cards");
			GamesList.Items.Add("Spelling");
			GamesList.BackColor = Color.FromArgb(150, 200, 80);
			GamesList.SelectedIndexChanged += GamesList_SelectedIndexChanged;
			GamesList.Font = new Font("Arial", Form1.ActiveForm.Height/30);
			GamesList.SelectedIndex = 0;
			this.Controls.Add(GamesList);
			this.Controls.Add(WichGraphDate);
		}

		private void GamesList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (ResultGraphs != null)
			{
				ResultGraphs.Hide();
			}
			ResultGraphs = new PictureBox();
			ResultGraphs.Size = new Size(5 * Form1.ActiveForm.Width / 9, 2 * Form1.ActiveForm.Height / 3);
			ResultGraphs.Location = new Point(Form1.ActiveForm.Width / 3, Form1.ActiveForm.Height / 9);
			ResultGraphs.Paint += DrawGraph;
			ResultGraphs.BackColor = Color.White;
			this.Controls.Add(ResultGraphs);
		}
		TimeSpan GetMaxDateDifference(List<Results> results)
		{
			TimeSpan maxDifference = TimeSpan.Zero;

			// Вычисляем разницу между соседними элементами
			for (int i = 1; i < results.Count; i++)
			{
				TimeSpan difference = results[i].data - results[i - 1].data;
				if (difference > maxDifference)
				{
					maxDifference = difference;
				}
			}

			return maxDifference;
		}

		private void DrawGraph(object sender, PaintEventArgs e)
		{
			Scores = ResultsFile.LoadFromFile();
			List<Results> Neededres = new List<Results>();
			int maxSc = 0;

			for (int i = 0; i < Scores.Count; i++)
			{
				if(Scores[i].GameName == (string)GamesList.SelectedItem)
				{
					if(WichGraphDate.SelectedIndex == 0)
					{
						if(DateTime.Now < Scores[i].data.AddDays(7))
						{
							Neededres.Add(Scores[i]);
							if(maxSc < Scores[i].score)
							{
								maxSc = Scores[i].score;
							}
						}
					}
					if (WichGraphDate.SelectedIndex == 1)
					{
						if (DateTime.Now < Scores[i].data.AddDays(31))
						{
							Neededres.Add(Scores[i]);
							if (maxSc < Scores[i].score)
							{
								maxSc = Scores[i].score;
							}
						}
					}
					else if (WichGraphDate.SelectedIndex == 2)
					{
						Neededres.Add(Scores[i]);
						if (maxSc < Scores[i].score)
						{
							maxSc = Scores[i].score;
						}
					}
				}
			}
			Pen arrowPen = new Pen(Color.Black, ResultGraphs.Width/200);
			//arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
			AdjustableArrowCap bigArrow = new AdjustableArrowCap((int)Math.Log(ResultGraphs.Width), (int)Math.Log(ResultGraphs.Width)); // ширина и высота наконечника
			arrowPen.CustomEndCap = bigArrow;
			e.Graphics.DrawLine(arrowPen, ResultGraphs.Width / 30, 29 * ResultGraphs.Height / 30, ResultGraphs.Width / 30, 0);
			e.Graphics.DrawLine(arrowPen, ResultGraphs.Width / 30, 29 * ResultGraphs.Height / 30, ResultGraphs.Width, 29 * ResultGraphs.Height / 30);
			if (Neededres.Count > 0)
			{
				Pen BPen = new Pen(Color.Black, ResultGraphs.Width / 250);
				Neededres.Sort((r1, r2) => r1.data.CompareTo(r2.data));
				double maxTimeDif = GetMaxDateDifference(Neededres).TotalMilliseconds;
				double fullDif = (Neededres[Neededres.Count - 1].data - Neededres[0].data).TotalMilliseconds;
				double promez = ResultGraphs.Width / 30.0 * 28.0 / (Neededres.Count - 1);
				int maxh = 29 * ResultGraphs.Height / 30;
				Point lastP = new Point(ResultGraphs.Width / 30, maxh - (int)(Neededres[0].score * 0.9 / maxSc * maxh));
				for (int i = 1; i < Neededres.Count; i++)
				{
					double bd = (Neededres[i].data - Neededres[i - 1].data).TotalMilliseconds;
					Point Poi = new Point((int)(lastP.X + ResultGraphs.Width / 30.0 * 28.0 * bd / fullDif), maxh - (int)(Neededres[i].score * 0.9 / maxSc * maxh));
					e.Graphics.DrawLine(BPen, lastP, Poi);
					lastP = Poi;
				}
			}
		}
	}
}
