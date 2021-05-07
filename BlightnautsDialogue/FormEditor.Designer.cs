namespace BlightnautsDialogue
{
    partial class FormTeam
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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelTop;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelTextFields;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelPortrait;
            System.Windows.Forms.Label labelPortrait;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelTimes;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelStart;
            System.Windows.Forms.Label labelStart;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelEnd;
            System.Windows.Forms.Label labelEnd;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeam));
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelArea = new System.Windows.Forms.Label();
            this.comboBoxCharacter = new System.Windows.Forms.ComboBox();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxPortrait = new System.Windows.Forms.TextBox();
            this.buttonAddDialogue = new System.Windows.Forms.Button();
            this.buttonRemoveDialogue = new System.Windows.Forms.Button();
            this.labelCurrentDialogue = new System.Windows.Forms.Label();
            this.buttonPreviousDialogue = new System.Windows.Forms.Button();
            this.buttonNextDialogue = new System.Windows.Forms.Button();
            this.textBoxDialogue = new System.Windows.Forms.TextBox();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.labelDuration = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelButtons = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelTop = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelTextFields = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelPortrait = new System.Windows.Forms.TableLayoutPanel();
            labelPortrait = new System.Windows.Forms.Label();
            tableLayoutPanelTimes = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanelStart = new System.Windows.Forms.TableLayoutPanel();
            labelStart = new System.Windows.Forms.Label();
            tableLayoutPanelEnd = new System.Windows.Forms.TableLayoutPanel();
            labelEnd = new System.Windows.Forms.Label();
            tableLayoutPanelButtons.SuspendLayout();
            tableLayoutPanelTop.SuspendLayout();
            tableLayoutPanelTextFields.SuspendLayout();
            tableLayoutPanelPortrait.SuspendLayout();
            tableLayoutPanelTimes.SuspendLayout();
            tableLayoutPanelStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            tableLayoutPanelEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelButtons
            // 
            tableLayoutPanelButtons.ColumnCount = 3;
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            tableLayoutPanelButtons.Controls.Add(this.buttonPrevious, 0, 0);
            tableLayoutPanelButtons.Controls.Add(this.buttonNext, 2, 0);
            tableLayoutPanelButtons.Controls.Add(this.labelArea, 1, 0);
            tableLayoutPanelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelButtons.Location = new System.Drawing.Point(0, 24);
            tableLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
            tableLayoutPanelButtons.RowCount = 1;
            tableLayoutPanelButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelButtons.Size = new System.Drawing.Size(428, 24);
            tableLayoutPanelButtons.TabIndex = 1;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrevious.Location = new System.Drawing.Point(0, 0);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(100, 24);
            this.buttonPrevious.TabIndex = 0;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNext.Location = new System.Drawing.Point(328, 0);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(100, 24);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelArea
            // 
            this.labelArea.AutoSize = true;
            this.labelArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelArea.Location = new System.Drawing.Point(100, 0);
            this.labelArea.Margin = new System.Windows.Forms.Padding(0);
            this.labelArea.Name = "labelArea";
            this.labelArea.Size = new System.Drawing.Size(228, 24);
            this.labelArea.TabIndex = 2;
            this.labelArea.Text = "Intro";
            this.labelArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanelTop
            // 
            tableLayoutPanelTop.ColumnCount = 5;
            tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanelTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanelTop.Controls.Add(this.comboBoxCharacter, 0, 0);
            tableLayoutPanelTop.Controls.Add(this.buttonExport, 3, 0);
            tableLayoutPanelTop.Controls.Add(this.buttonClear, 4, 0);
            tableLayoutPanelTop.Controls.Add(this.buttonLoad, 2, 0);
            tableLayoutPanelTop.Controls.Add(this.buttonSave, 1, 0);
            tableLayoutPanelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelTop.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelTop.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelTop.Name = "tableLayoutPanelTop";
            tableLayoutPanelTop.RowCount = 1;
            tableLayoutPanelTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTop.Size = new System.Drawing.Size(428, 24);
            tableLayoutPanelTop.TabIndex = 0;
            // 
            // comboBoxCharacter
            // 
            this.comboBoxCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCharacter.FormattingEnabled = true;
            this.comboBoxCharacter.Items.AddRange(new object[] {
            "Assassin",
            "Bird",
            "Blazer",
            "Blinker",
            "Boizor",
            "Brute",
            "Butterfly",
            "Captain",
            "Chameleon",
            "Cowboy",
            "Commando",
            "Crawler",
            "Crumple",
            "Dasher",
            "Ellipto",
            "Gantlet",
            "Gladiator",
            "Heavy",
            "Hunter",
            "Hyper",
            "Jetter",
            "Maw",
            "Paladin",
            "Poacher",
            "Rascal",
            "Shaman",
            "Shifter",
            "Spy",
            "Summoner",
            "Tank",
            "Vampire",
            "Wakuwaku",
            "Warrior",
            "Wozzle"});
            this.comboBoxCharacter.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCharacter.Margin = new System.Windows.Forms.Padding(0);
            this.comboBoxCharacter.Name = "comboBoxCharacter";
            this.comboBoxCharacter.Size = new System.Drawing.Size(108, 21);
            this.comboBoxCharacter.TabIndex = 0;
            this.comboBoxCharacter.Text = "Assassin";
            // 
            // buttonExport
            // 
            this.buttonExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonExport.Location = new System.Drawing.Point(268, 0);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(80, 24);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Location = new System.Drawing.Point(348, 0);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(80, 24);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Location = new System.Drawing.Point(188, 0);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(80, 24);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Open";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(108, 0);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 24);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tableLayoutPanelTextFields
            // 
            tableLayoutPanelTextFields.ColumnCount = 1;
            tableLayoutPanelTextFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTextFields.Controls.Add(tableLayoutPanelPortrait, 0, 0);
            tableLayoutPanelTextFields.Controls.Add(this.textBoxDialogue, 0, 1);
            tableLayoutPanelTextFields.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelTextFields.Location = new System.Drawing.Point(0, 48);
            tableLayoutPanelTextFields.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelTextFields.Name = "tableLayoutPanelTextFields";
            tableLayoutPanelTextFields.RowCount = 2;
            tableLayoutPanelTextFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            tableLayoutPanelTextFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTextFields.Size = new System.Drawing.Size(428, 267);
            tableLayoutPanelTextFields.TabIndex = 2;
            // 
            // tableLayoutPanelPortrait
            // 
            tableLayoutPanelPortrait.ColumnCount = 7;
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            tableLayoutPanelPortrait.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            tableLayoutPanelPortrait.Controls.Add(this.textBoxPortrait, 1, 0);
            tableLayoutPanelPortrait.Controls.Add(labelPortrait, 0, 0);
            tableLayoutPanelPortrait.Controls.Add(this.buttonAddDialogue, 5, 0);
            tableLayoutPanelPortrait.Controls.Add(this.buttonRemoveDialogue, 6, 0);
            tableLayoutPanelPortrait.Controls.Add(this.labelCurrentDialogue, 2, 0);
            tableLayoutPanelPortrait.Controls.Add(this.buttonPreviousDialogue, 3, 0);
            tableLayoutPanelPortrait.Controls.Add(this.buttonNextDialogue, 4, 0);
            tableLayoutPanelPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelPortrait.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelPortrait.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelPortrait.Name = "tableLayoutPanelPortrait";
            tableLayoutPanelPortrait.RowCount = 1;
            tableLayoutPanelPortrait.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelPortrait.Size = new System.Drawing.Size(428, 24);
            tableLayoutPanelPortrait.TabIndex = 2;
            // 
            // textBoxPortrait
            // 
            this.textBoxPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPortrait.Location = new System.Drawing.Point(80, 0);
            this.textBoxPortrait.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPortrait.Name = "textBoxPortrait";
            this.textBoxPortrait.Size = new System.Drawing.Size(162, 20);
            this.textBoxPortrait.TabIndex = 0;
            this.textBoxPortrait.TextChanged += new System.EventHandler(this.textBoxPortrait_TextChanged);
            // 
            // labelPortrait
            // 
            labelPortrait.AutoSize = true;
            labelPortrait.Dock = System.Windows.Forms.DockStyle.Fill;
            labelPortrait.Location = new System.Drawing.Point(0, 0);
            labelPortrait.Margin = new System.Windows.Forms.Padding(0);
            labelPortrait.Name = "labelPortrait";
            labelPortrait.Size = new System.Drawing.Size(80, 24);
            labelPortrait.TabIndex = 1;
            labelPortrait.Text = "Portrait";
            labelPortrait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddDialogue
            // 
            this.buttonAddDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddDialogue.Location = new System.Drawing.Point(380, 0);
            this.buttonAddDialogue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAddDialogue.Name = "buttonAddDialogue";
            this.buttonAddDialogue.Size = new System.Drawing.Size(24, 24);
            this.buttonAddDialogue.TabIndex = 4;
            this.buttonAddDialogue.Text = "+";
            this.buttonAddDialogue.UseVisualStyleBackColor = true;
            this.buttonAddDialogue.Click += new System.EventHandler(this.buttonAddDialogue_Click);
            // 
            // buttonRemoveDialogue
            // 
            this.buttonRemoveDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveDialogue.Location = new System.Drawing.Point(404, 0);
            this.buttonRemoveDialogue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRemoveDialogue.Name = "buttonRemoveDialogue";
            this.buttonRemoveDialogue.Size = new System.Drawing.Size(24, 24);
            this.buttonRemoveDialogue.TabIndex = 5;
            this.buttonRemoveDialogue.Text = "-";
            this.buttonRemoveDialogue.UseVisualStyleBackColor = true;
            this.buttonRemoveDialogue.Click += new System.EventHandler(this.buttonRemoveDialogue_Click);
            // 
            // labelCurrentDialogue
            // 
            this.labelCurrentDialogue.AutoSize = true;
            this.labelCurrentDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentDialogue.Location = new System.Drawing.Point(242, 0);
            this.labelCurrentDialogue.Margin = new System.Windows.Forms.Padding(0);
            this.labelCurrentDialogue.Name = "labelCurrentDialogue";
            this.labelCurrentDialogue.Size = new System.Drawing.Size(90, 24);
            this.labelCurrentDialogue.TabIndex = 4;
            this.labelCurrentDialogue.Text = "Dialogue 1";
            this.labelCurrentDialogue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonPreviousDialogue
            // 
            this.buttonPreviousDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPreviousDialogue.Location = new System.Drawing.Point(332, 0);
            this.buttonPreviousDialogue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPreviousDialogue.Name = "buttonPreviousDialogue";
            this.buttonPreviousDialogue.Size = new System.Drawing.Size(24, 24);
            this.buttonPreviousDialogue.TabIndex = 2;
            this.buttonPreviousDialogue.Text = "<";
            this.buttonPreviousDialogue.UseVisualStyleBackColor = true;
            this.buttonPreviousDialogue.Click += new System.EventHandler(this.buttonPreviousDialogue_Click);
            // 
            // buttonNextDialogue
            // 
            this.buttonNextDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNextDialogue.Location = new System.Drawing.Point(356, 0);
            this.buttonNextDialogue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonNextDialogue.Name = "buttonNextDialogue";
            this.buttonNextDialogue.Size = new System.Drawing.Size(24, 24);
            this.buttonNextDialogue.TabIndex = 3;
            this.buttonNextDialogue.Text = ">";
            this.buttonNextDialogue.UseVisualStyleBackColor = true;
            this.buttonNextDialogue.Click += new System.EventHandler(this.buttonNextDialogue_Click);
            // 
            // textBoxDialogue
            // 
            this.textBoxDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDialogue.Location = new System.Drawing.Point(0, 24);
            this.textBoxDialogue.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxDialogue.Multiline = true;
            this.textBoxDialogue.Name = "textBoxDialogue";
            this.textBoxDialogue.Size = new System.Drawing.Size(428, 243);
            this.textBoxDialogue.TabIndex = 10;
            this.textBoxDialogue.TextChanged += new System.EventHandler(this.textBoxDialogue_TextChanged);
            // 
            // tableLayoutPanelTimes
            // 
            tableLayoutPanelTimes.ColumnCount = 3;
            tableLayoutPanelTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            tableLayoutPanelTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            tableLayoutPanelTimes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTimes.Controls.Add(tableLayoutPanelStart, 0, 0);
            tableLayoutPanelTimes.Controls.Add(tableLayoutPanelEnd, 1, 0);
            tableLayoutPanelTimes.Controls.Add(this.labelDuration, 2, 0);
            tableLayoutPanelTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelTimes.Location = new System.Drawing.Point(0, 315);
            tableLayoutPanelTimes.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelTimes.Name = "tableLayoutPanelTimes";
            tableLayoutPanelTimes.RowCount = 1;
            tableLayoutPanelTimes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelTimes.Size = new System.Drawing.Size(428, 80);
            tableLayoutPanelTimes.TabIndex = 3;
            // 
            // tableLayoutPanelStart
            // 
            tableLayoutPanelStart.ColumnCount = 1;
            tableLayoutPanelStart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelStart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelStart.Controls.Add(labelStart, 0, 0);
            tableLayoutPanelStart.Controls.Add(this.numericUpDownStart, 0, 1);
            tableLayoutPanelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelStart.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelStart.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelStart.Name = "tableLayoutPanelStart";
            tableLayoutPanelStart.RowCount = 2;
            tableLayoutPanelStart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelStart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelStart.Size = new System.Drawing.Size(70, 80);
            tableLayoutPanelStart.TabIndex = 2;
            // 
            // labelStart
            // 
            labelStart.AutoSize = true;
            labelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            labelStart.Location = new System.Drawing.Point(0, 0);
            labelStart.Margin = new System.Windows.Forms.Padding(0);
            labelStart.Name = "labelStart";
            labelStart.Size = new System.Drawing.Size(70, 40);
            labelStart.TabIndex = 0;
            labelStart.Text = "Starts at";
            labelStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.DecimalPlaces = 1;
            this.numericUpDownStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownStart.Location = new System.Drawing.Point(0, 40);
            this.numericUpDownStart.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownStart.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownStart.TabIndex = 1;
            this.numericUpDownStart.ValueChanged += new System.EventHandler(this.numericUpDownStart_ValueChanged);
            // 
            // tableLayoutPanelEnd
            // 
            tableLayoutPanelEnd.ColumnCount = 1;
            tableLayoutPanelEnd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelEnd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelEnd.Controls.Add(labelEnd, 0, 0);
            tableLayoutPanelEnd.Controls.Add(this.numericUpDownEnd, 0, 1);
            tableLayoutPanelEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelEnd.Location = new System.Drawing.Point(70, 0);
            tableLayoutPanelEnd.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanelEnd.Name = "tableLayoutPanelEnd";
            tableLayoutPanelEnd.RowCount = 2;
            tableLayoutPanelEnd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelEnd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelEnd.Size = new System.Drawing.Size(70, 80);
            tableLayoutPanelEnd.TabIndex = 3;
            // 
            // labelEnd
            // 
            labelEnd.AutoSize = true;
            labelEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            labelEnd.Location = new System.Drawing.Point(0, 0);
            labelEnd.Margin = new System.Windows.Forms.Padding(0);
            labelEnd.Name = "labelEnd";
            labelEnd.Size = new System.Drawing.Size(70, 40);
            labelEnd.TabIndex = 0;
            labelEnd.Text = "Ends at";
            labelEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.DecimalPlaces = 1;
            this.numericUpDownEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownEnd.Location = new System.Drawing.Point(0, 40);
            this.numericUpDownEnd.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDownEnd.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(70, 20);
            this.numericUpDownEnd.TabIndex = 1;
            this.numericUpDownEnd.ValueChanged += new System.EventHandler(this.numericUpDownEnd_ValueChanged);
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelDuration.Location = new System.Drawing.Point(150, 0);
            this.labelDuration.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(278, 80);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "Dialogue duration: 0 seconds\r\nTotal duration: 0 seconds";
            this.labelDuration.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(tableLayoutPanelButtons, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(tableLayoutPanelTop, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(tableLayoutPanelTextFields, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(tableLayoutPanelTimes, 0, 3);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(428, 395);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // FormTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 395);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTeam";
            this.Text = "Blightnauts Dialogue Editor";
            tableLayoutPanelButtons.ResumeLayout(false);
            tableLayoutPanelButtons.PerformLayout();
            tableLayoutPanelTop.ResumeLayout(false);
            tableLayoutPanelTextFields.ResumeLayout(false);
            tableLayoutPanelTextFields.PerformLayout();
            tableLayoutPanelPortrait.ResumeLayout(false);
            tableLayoutPanelPortrait.PerformLayout();
            tableLayoutPanelTimes.ResumeLayout(false);
            tableLayoutPanelTimes.PerformLayout();
            tableLayoutPanelStart.ResumeLayout(false);
            tableLayoutPanelStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            tableLayoutPanelEnd.ResumeLayout(false);
            tableLayoutPanelEnd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelArea;
        private System.Windows.Forms.ComboBox comboBoxCharacter;
        private System.Windows.Forms.TextBox textBoxPortrait;
        private System.Windows.Forms.TextBox textBoxDialogue;
        private System.Windows.Forms.Button buttonAddDialogue;
        private System.Windows.Forms.Button buttonRemoveDialogue;
        private System.Windows.Forms.Label labelCurrentDialogue;
        private System.Windows.Forms.Button buttonPreviousDialogue;
        private System.Windows.Forms.Button buttonNextDialogue;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
        private System.Windows.Forms.NumericUpDown numericUpDownEnd;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
    }
}

