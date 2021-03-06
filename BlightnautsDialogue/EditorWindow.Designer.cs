
namespace BlightnautsDialogue
{
    partial class EditorWindow
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
            System.Windows.Forms.MenuStrip topBar;
            System.Windows.Forms.ToolStripMenuItem topBarFile;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripMenuItem topBarExport;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
            System.Windows.Forms.ToolStripMenuItem topBarView;
            System.Windows.Forms.ToolStripMenuItem topBarTextbox;
            System.Windows.Forms.ToolStripMenuItem topBarTextboxBackgroundColor;
            System.Windows.Forms.ToolStripMenuItem topBarTextboxForegroundColor;
            System.Windows.Forms.ToolStripMenuItem topBarProject;
            System.Windows.Forms.ToolStripMenuItem topBarSetDirectory;
            System.Windows.Forms.ToolStripMenuItem topBarSetMaps;
            System.Windows.Forms.ToolStripMenuItem topBarNewTrigger;
            System.Windows.Forms.ToolStripMenuItem topBarImportLegacy;
            System.Windows.Forms.ToolStripMenuItem topBarAbout;
            System.Windows.Forms.TableLayoutPanel generalLayout;
            System.Windows.Forms.TableLayoutPanel topLayout;
            System.Windows.Forms.GroupBox groupCharacter;
            System.Windows.Forms.GroupBox groupTrigger;
            System.Windows.Forms.GroupBox groupBoxDialogue;
            System.Windows.Forms.TableLayoutPanel dialogueLayout;
            System.Windows.Forms.GroupBox groupBoxDialogueOptions;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorWindow));
            System.Windows.Forms.Label labelDelay;
            System.Windows.Forms.Label labelDuration;
            System.Windows.Forms.Label labelTexture;
            System.Windows.Forms.Label labelPortrait;
            System.Windows.Forms.ToolTip toolTipSimple;
            System.Windows.Forms.ToolTip toolTipLong;
            this.topBarNew = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarOpenRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarSave = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarExit = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarTextboxSetFont = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarMaximize = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarCheckMissing = new System.Windows.Forms.ToolStripMenuItem();
            this.labelCharacterStatus = new System.Windows.Forms.Label();
            this.checkBoxUseDefault = new System.Windows.Forms.CheckBox();
            this.dropdownCharacters = new System.Windows.Forms.ComboBox();
            this.checkBoxInterruptable = new System.Windows.Forms.CheckBox();
            this.checkBoxRepeatable = new System.Windows.Forms.CheckBox();
            this.dropdownTriggers = new System.Windows.Forms.ComboBox();
            this.buttonSequencePrevious = new System.Windows.Forms.Button();
            this.buttonSequenceNext = new System.Windows.Forms.Button();
            this.dropdownTexture = new System.Windows.Forms.ComboBox();
            this.dropdownDialogues = new System.Windows.Forms.ComboBox();
            this.labelSequence = new System.Windows.Forms.Label();
            this.buttonSequencePlus = new System.Windows.Forms.Button();
            this.buttonSequenceMinus = new System.Windows.Forms.Button();
            this.checkBoxGenerateAnimationTemplate = new System.Windows.Forms.CheckBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.textBoxPortrait = new System.Windows.Forms.TextBox();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.colorDialogTextboxMain = new System.Windows.Forms.ColorDialog();
            this.folderBrowserDialogModDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonPaste = new System.Windows.Forms.Button();
            topBar = new System.Windows.Forms.MenuStrip();
            topBarFile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            topBarExport = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            topBarView = new System.Windows.Forms.ToolStripMenuItem();
            topBarTextbox = new System.Windows.Forms.ToolStripMenuItem();
            topBarTextboxBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
            topBarTextboxForegroundColor = new System.Windows.Forms.ToolStripMenuItem();
            topBarProject = new System.Windows.Forms.ToolStripMenuItem();
            topBarSetDirectory = new System.Windows.Forms.ToolStripMenuItem();
            topBarSetMaps = new System.Windows.Forms.ToolStripMenuItem();
            topBarNewTrigger = new System.Windows.Forms.ToolStripMenuItem();
            topBarImportLegacy = new System.Windows.Forms.ToolStripMenuItem();
            topBarAbout = new System.Windows.Forms.ToolStripMenuItem();
            generalLayout = new System.Windows.Forms.TableLayoutPanel();
            topLayout = new System.Windows.Forms.TableLayoutPanel();
            groupCharacter = new System.Windows.Forms.GroupBox();
            groupTrigger = new System.Windows.Forms.GroupBox();
            groupBoxDialogue = new System.Windows.Forms.GroupBox();
            dialogueLayout = new System.Windows.Forms.TableLayoutPanel();
            groupBoxDialogueOptions = new System.Windows.Forms.GroupBox();
            labelDelay = new System.Windows.Forms.Label();
            labelDuration = new System.Windows.Forms.Label();
            labelTexture = new System.Windows.Forms.Label();
            labelPortrait = new System.Windows.Forms.Label();
            toolTipSimple = new System.Windows.Forms.ToolTip(this.components);
            toolTipLong = new System.Windows.Forms.ToolTip(this.components);
            topBar.SuspendLayout();
            generalLayout.SuspendLayout();
            topLayout.SuspendLayout();
            groupCharacter.SuspendLayout();
            groupTrigger.SuspendLayout();
            groupBoxDialogue.SuspendLayout();
            dialogueLayout.SuspendLayout();
            groupBoxDialogueOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            topBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            topBarFile,
            topBarView,
            topBarProject,
            topBarAbout});
            topBar.Location = new System.Drawing.Point(0, 0);
            topBar.Name = "topBar";
            topBar.Size = new System.Drawing.Size(601, 24);
            topBar.TabIndex = 0;
            topBar.Text = "topBar";
            // 
            // topBarFile
            // 
            topBarFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topBarNew,
            toolStripSeparator1,
            this.topBarOpen,
            this.topBarOpenRecent,
            toolStripSeparator2,
            this.topBarSave,
            this.topBarSaveAs,
            toolStripSeparator3,
            topBarExport,
            toolStripSeparator4,
            this.topBarExit});
            topBarFile.Name = "topBarFile";
            topBarFile.Size = new System.Drawing.Size(37, 20);
            topBarFile.Text = "File";
            // 
            // topBarNew
            // 
            this.topBarNew.Name = "topBarNew";
            this.topBarNew.Size = new System.Drawing.Size(127, 22);
            this.topBarNew.Text = "New";
            this.topBarNew.Click += new System.EventHandler(this.topBarNew_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
            // 
            // topBarOpen
            // 
            this.topBarOpen.Name = "topBarOpen";
            this.topBarOpen.Size = new System.Drawing.Size(127, 22);
            this.topBarOpen.Text = "Open";
            this.topBarOpen.Click += new System.EventHandler(this.topBarOpen_Click);
            // 
            // topBarOpenRecent
            // 
            this.topBarOpenRecent.Name = "topBarOpenRecent";
            this.topBarOpenRecent.Size = new System.Drawing.Size(127, 22);
            this.topBarOpenRecent.Text = "Open Last";
            this.topBarOpenRecent.Click += new System.EventHandler(this.topBarOpenRecent_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(124, 6);
            // 
            // topBarSave
            // 
            this.topBarSave.Name = "topBarSave";
            this.topBarSave.Size = new System.Drawing.Size(127, 22);
            this.topBarSave.Text = "Save";
            this.topBarSave.Click += new System.EventHandler(this.topBarSave_Click);
            // 
            // topBarSaveAs
            // 
            this.topBarSaveAs.Name = "topBarSaveAs";
            this.topBarSaveAs.Size = new System.Drawing.Size(127, 22);
            this.topBarSaveAs.Text = "Save as";
            this.topBarSaveAs.Click += new System.EventHandler(this.topBarSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(124, 6);
            // 
            // topBarExport
            // 
            topBarExport.Name = "topBarExport";
            topBarExport.Size = new System.Drawing.Size(127, 22);
            topBarExport.Text = "Export";
            topBarExport.Click += new System.EventHandler(this.topBarExport_Click);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(124, 6);
            // 
            // topBarExit
            // 
            this.topBarExit.Name = "topBarExit";
            this.topBarExit.Size = new System.Drawing.Size(127, 22);
            this.topBarExit.Text = "Exit";
            this.topBarExit.Click += new System.EventHandler(this.topBarExit_Click);
            // 
            // topBarView
            // 
            topBarView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            topBarTextbox,
            this.topBarMaximize,
            this.topBarCheckMissing});
            topBarView.Name = "topBarView";
            topBarView.Size = new System.Drawing.Size(44, 20);
            topBarView.Text = "View";
            // 
            // topBarTextbox
            // 
            topBarTextbox.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topBarTextboxSetFont,
            topBarTextboxBackgroundColor,
            topBarTextboxForegroundColor});
            topBarTextbox.Name = "topBarTextbox";
            topBarTextbox.Size = new System.Drawing.Size(200, 22);
            topBarTextbox.Text = "Textbox";
            // 
            // topBarTextboxSetFont
            // 
            this.topBarTextboxSetFont.Name = "topBarTextboxSetFont";
            this.topBarTextboxSetFont.Size = new System.Drawing.Size(170, 22);
            this.topBarTextboxSetFont.Text = "Set Font";
            this.topBarTextboxSetFont.Click += new System.EventHandler(this.topBarTextboxSetFont_Click);
            // 
            // topBarTextboxBackgroundColor
            // 
            topBarTextboxBackgroundColor.Name = "topBarTextboxBackgroundColor";
            topBarTextboxBackgroundColor.Size = new System.Drawing.Size(170, 22);
            topBarTextboxBackgroundColor.Text = "Background Color";
            topBarTextboxBackgroundColor.Click += new System.EventHandler(this.topBarTextboxBackgroundColor_Click);
            // 
            // topBarTextboxForegroundColor
            // 
            topBarTextboxForegroundColor.Name = "topBarTextboxForegroundColor";
            topBarTextboxForegroundColor.Size = new System.Drawing.Size(170, 22);
            topBarTextboxForegroundColor.Text = "Foreground Color";
            topBarTextboxForegroundColor.Click += new System.EventHandler(this.topBarTextboxForegroundColor_Click);
            // 
            // topBarMaximize
            // 
            this.topBarMaximize.Name = "topBarMaximize";
            this.topBarMaximize.Size = new System.Drawing.Size(200, 22);
            this.topBarMaximize.Text = "Maximize";
            this.topBarMaximize.Click += new System.EventHandler(this.topBarMaximize_Click);
            // 
            // topBarCheckMissing
            // 
            this.topBarCheckMissing.Name = "topBarCheckMissing";
            this.topBarCheckMissing.Size = new System.Drawing.Size(200, 22);
            this.topBarCheckMissing.Text = "Check Invalid Dialogues";
            this.topBarCheckMissing.Click += new System.EventHandler(this.topBarCheckMissing_Click);
            // 
            // topBarProject
            // 
            topBarProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            topBarSetDirectory,
            topBarSetMaps,
            topBarNewTrigger,
            topBarImportLegacy});
            topBarProject.Name = "topBarProject";
            topBarProject.Size = new System.Drawing.Size(56, 20);
            topBarProject.Text = "Project";
            // 
            // topBarSetDirectory
            // 
            topBarSetDirectory.Name = "topBarSetDirectory";
            topBarSetDirectory.Size = new System.Drawing.Size(200, 22);
            topBarSetDirectory.Text = "Set Mod Directory";
            topBarSetDirectory.Click += new System.EventHandler(this.topBarSetDirectory_Click);
            // 
            // topBarSetMaps
            // 
            topBarSetMaps.Name = "topBarSetMaps";
            topBarSetMaps.Size = new System.Drawing.Size(200, 22);
            topBarSetMaps.Text = "Set Maps";
            topBarSetMaps.Click += new System.EventHandler(this.topBarSetMaps_Click);
            // 
            // topBarNewTrigger
            // 
            topBarNewTrigger.Name = "topBarNewTrigger";
            topBarNewTrigger.Size = new System.Drawing.Size(200, 22);
            topBarNewTrigger.Text = "New Trigger";
            topBarNewTrigger.Click += new System.EventHandler(this.topBarNewTrigger_Click);
            // 
            // topBarImportLegacy
            // 
            topBarImportLegacy.Name = "topBarImportLegacy";
            topBarImportLegacy.Size = new System.Drawing.Size(200, 22);
            topBarImportLegacy.Text = "Import Legacy Dialogue";
            topBarImportLegacy.Click += new System.EventHandler(this.topBarImportLegacy_Click);
            // 
            // topBarAbout
            // 
            topBarAbout.Name = "topBarAbout";
            topBarAbout.Size = new System.Drawing.Size(52, 20);
            topBarAbout.Text = "About";
            topBarAbout.Click += new System.EventHandler(this.topBarAbout_Click);
            // 
            // generalLayout
            // 
            generalLayout.ColumnCount = 1;
            generalLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            generalLayout.Controls.Add(topLayout, 0, 0);
            generalLayout.Controls.Add(groupBoxDialogue, 0, 1);
            generalLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            generalLayout.Location = new System.Drawing.Point(0, 24);
            generalLayout.Margin = new System.Windows.Forms.Padding(0);
            generalLayout.Name = "generalLayout";
            generalLayout.RowCount = 2;
            generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            generalLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            generalLayout.Size = new System.Drawing.Size(601, 637);
            generalLayout.TabIndex = 1;
            // 
            // topLayout
            // 
            topLayout.ColumnCount = 3;
            topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            topLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            topLayout.Controls.Add(groupCharacter, 0, 0);
            topLayout.Controls.Add(groupTrigger, 1, 0);
            topLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            topLayout.Location = new System.Drawing.Point(0, 0);
            topLayout.Margin = new System.Windows.Forms.Padding(0);
            topLayout.Name = "topLayout";
            topLayout.RowCount = 1;
            topLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            topLayout.Size = new System.Drawing.Size(601, 75);
            topLayout.TabIndex = 0;
            // 
            // groupCharacter
            // 
            groupCharacter.Controls.Add(this.labelCharacterStatus);
            groupCharacter.Controls.Add(this.checkBoxUseDefault);
            groupCharacter.Controls.Add(this.dropdownCharacters);
            groupCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            groupCharacter.Location = new System.Drawing.Point(3, 3);
            groupCharacter.Name = "groupCharacter";
            groupCharacter.Size = new System.Drawing.Size(294, 69);
            groupCharacter.TabIndex = 0;
            groupCharacter.TabStop = false;
            groupCharacter.Text = "Character";
            // 
            // labelCharacterStatus
            // 
            this.labelCharacterStatus.Location = new System.Drawing.Point(6, 47);
            this.labelCharacterStatus.Name = "labelCharacterStatus";
            this.labelCharacterStatus.Size = new System.Drawing.Size(174, 17);
            this.labelCharacterStatus.TabIndex = 2;
            this.labelCharacterStatus.Text = "Status";
            this.labelCharacterStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxUseDefault
            // 
            this.checkBoxUseDefault.AutoSize = true;
            this.checkBoxUseDefault.Location = new System.Drawing.Point(186, 47);
            this.checkBoxUseDefault.Name = "checkBoxUseDefault";
            this.checkBoxUseDefault.Size = new System.Drawing.Size(102, 17);
            this.checkBoxUseDefault.TabIndex = 1;
            this.checkBoxUseDefault.Text = "Use default skin";
            toolTipSimple.SetToolTip(this.checkBoxUseDefault, "If enabled, will not generate any dialogue and will make anyone playing\r\nwith thi" +
        "s skin use the default dialogue.");
            this.checkBoxUseDefault.UseVisualStyleBackColor = true;
            this.checkBoxUseDefault.CheckedChanged += new System.EventHandler(this.checkBoxUseDefault_CheckedChanged);
            // 
            // dropdownCharacters
            // 
            this.dropdownCharacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownCharacters.FormattingEnabled = true;
            this.dropdownCharacters.Location = new System.Drawing.Point(6, 19);
            this.dropdownCharacters.Name = "dropdownCharacters";
            this.dropdownCharacters.Size = new System.Drawing.Size(282, 21);
            this.dropdownCharacters.TabIndex = 0;
            this.dropdownCharacters.SelectedIndexChanged += new System.EventHandler(this.dropdownCharacters_SelectedIndexChanged);
            // 
            // groupTrigger
            // 
            groupTrigger.Controls.Add(this.checkBoxInterruptable);
            groupTrigger.Controls.Add(this.checkBoxRepeatable);
            groupTrigger.Controls.Add(this.dropdownTriggers);
            groupTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTrigger.Location = new System.Drawing.Point(303, 3);
            groupTrigger.Name = "groupTrigger";
            groupTrigger.Size = new System.Drawing.Size(294, 69);
            groupTrigger.TabIndex = 1;
            groupTrigger.TabStop = false;
            groupTrigger.Text = "Trigger";
            // 
            // checkBoxInterruptable
            // 
            this.checkBoxInterruptable.AutoSize = true;
            this.checkBoxInterruptable.Location = new System.Drawing.Point(116, 47);
            this.checkBoxInterruptable.Name = "checkBoxInterruptable";
            this.checkBoxInterruptable.Size = new System.Drawing.Size(85, 17);
            this.checkBoxInterruptable.TabIndex = 2;
            this.checkBoxInterruptable.Text = "Interruptable";
            toolTipSimple.SetToolTip(this.checkBoxInterruptable, "If enabled, will allow the dialogue from this trigger to be interrupted.");
            this.checkBoxInterruptable.UseVisualStyleBackColor = true;
            this.checkBoxInterruptable.CheckedChanged += new System.EventHandler(this.checkBoxInterruptable_CheckedChanged);
            // 
            // checkBoxRepeatable
            // 
            this.checkBoxRepeatable.AutoSize = true;
            this.checkBoxRepeatable.Location = new System.Drawing.Point(207, 47);
            this.checkBoxRepeatable.Name = "checkBoxRepeatable";
            this.checkBoxRepeatable.Size = new System.Drawing.Size(81, 17);
            this.checkBoxRepeatable.TabIndex = 1;
            this.checkBoxRepeatable.Text = "Repeatable";
            toolTipSimple.SetToolTip(this.checkBoxRepeatable, "If enabled, will allow this trigger to be activated more than once.");
            this.checkBoxRepeatable.UseVisualStyleBackColor = true;
            this.checkBoxRepeatable.CheckedChanged += new System.EventHandler(this.checkBoxRepeatable_CheckedChanged);
            // 
            // dropdownTriggers
            // 
            this.dropdownTriggers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownTriggers.FormattingEnabled = true;
            this.dropdownTriggers.Location = new System.Drawing.Point(7, 19);
            this.dropdownTriggers.Name = "dropdownTriggers";
            this.dropdownTriggers.Size = new System.Drawing.Size(281, 21);
            this.dropdownTriggers.TabIndex = 0;
            this.dropdownTriggers.SelectedIndexChanged += new System.EventHandler(this.dropdownTriggers_SelectedIndexChanged);
            // 
            // groupBoxDialogue
            // 
            groupBoxDialogue.Controls.Add(dialogueLayout);
            groupBoxDialogue.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxDialogue.Location = new System.Drawing.Point(3, 78);
            groupBoxDialogue.Name = "groupBoxDialogue";
            groupBoxDialogue.Size = new System.Drawing.Size(595, 556);
            groupBoxDialogue.TabIndex = 2;
            groupBoxDialogue.TabStop = false;
            groupBoxDialogue.Text = "Dialogue";
            // 
            // dialogueLayout
            // 
            dialogueLayout.ColumnCount = 1;
            dialogueLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            dialogueLayout.Controls.Add(groupBoxDialogueOptions, 0, 0);
            dialogueLayout.Controls.Add(this.textBoxMain, 0, 1);
            dialogueLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            dialogueLayout.Location = new System.Drawing.Point(3, 16);
            dialogueLayout.Name = "dialogueLayout";
            dialogueLayout.RowCount = 2;
            dialogueLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            dialogueLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            dialogueLayout.Size = new System.Drawing.Size(589, 537);
            dialogueLayout.TabIndex = 0;
            // 
            // groupBoxDialogueOptions
            // 
            groupBoxDialogueOptions.Controls.Add(this.buttonPaste);
            groupBoxDialogueOptions.Controls.Add(this.buttonCopy);
            groupBoxDialogueOptions.Controls.Add(this.buttonSequencePrevious);
            groupBoxDialogueOptions.Controls.Add(this.buttonSequenceNext);
            groupBoxDialogueOptions.Controls.Add(this.dropdownTexture);
            groupBoxDialogueOptions.Controls.Add(this.dropdownDialogues);
            groupBoxDialogueOptions.Controls.Add(this.labelSequence);
            groupBoxDialogueOptions.Controls.Add(this.buttonSequencePlus);
            groupBoxDialogueOptions.Controls.Add(this.buttonSequenceMinus);
            groupBoxDialogueOptions.Controls.Add(this.checkBoxGenerateAnimationTemplate);
            groupBoxDialogueOptions.Controls.Add(this.textBoxDelay);
            groupBoxDialogueOptions.Controls.Add(labelDelay);
            groupBoxDialogueOptions.Controls.Add(labelDuration);
            groupBoxDialogueOptions.Controls.Add(this.textBoxDuration);
            groupBoxDialogueOptions.Controls.Add(labelTexture);
            groupBoxDialogueOptions.Controls.Add(labelPortrait);
            groupBoxDialogueOptions.Controls.Add(this.textBoxPortrait);
            groupBoxDialogueOptions.Dock = System.Windows.Forms.DockStyle.Left;
            groupBoxDialogueOptions.Location = new System.Drawing.Point(3, 3);
            groupBoxDialogueOptions.Name = "groupBoxDialogueOptions";
            groupBoxDialogueOptions.Size = new System.Drawing.Size(583, 94);
            groupBoxDialogueOptions.TabIndex = 3;
            groupBoxDialogueOptions.TabStop = false;
            groupBoxDialogueOptions.Text = "Options";
            // 
            // buttonSequencePrevious
            // 
            this.buttonSequencePrevious.Location = new System.Drawing.Point(467, 68);
            this.buttonSequencePrevious.Name = "buttonSequencePrevious";
            this.buttonSequencePrevious.Size = new System.Drawing.Size(23, 23);
            this.buttonSequencePrevious.TabIndex = 13;
            this.buttonSequencePrevious.Text = "<";
            toolTipSimple.SetToolTip(this.buttonSequencePrevious, "Previous textbox in the sequence.");
            this.buttonSequencePrevious.UseVisualStyleBackColor = true;
            this.buttonSequencePrevious.Click += new System.EventHandler(this.buttonSequencePrevious_Click);
            // 
            // buttonSequenceNext
            // 
            this.buttonSequenceNext.Location = new System.Drawing.Point(496, 68);
            this.buttonSequenceNext.Name = "buttonSequenceNext";
            this.buttonSequenceNext.Size = new System.Drawing.Size(23, 23);
            this.buttonSequenceNext.TabIndex = 12;
            this.buttonSequenceNext.Text = ">";
            toolTipSimple.SetToolTip(this.buttonSequenceNext, "Next textbox in the sequence.");
            this.buttonSequenceNext.UseVisualStyleBackColor = true;
            this.buttonSequenceNext.Click += new System.EventHandler(this.buttonSequenceNext_Click);
            // 
            // dropdownTexture
            // 
            this.dropdownTexture.FormattingEnabled = true;
            this.dropdownTexture.Location = new System.Drawing.Point(6, 71);
            this.dropdownTexture.Name = "dropdownTexture";
            this.dropdownTexture.Size = new System.Drawing.Size(192, 21);
            this.dropdownTexture.TabIndex = 2;
            this.dropdownTexture.SelectedIndexChanged += new System.EventHandler(this.dropdownTexture_SelectedIndexChanged);
            this.dropdownTexture.TextUpdate += new System.EventHandler(this.dropdownTexture_TextUpdate);
            // 
            // dropdownDialogues
            // 
            this.dropdownDialogues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdownDialogues.FormattingEnabled = true;
            this.dropdownDialogues.Location = new System.Drawing.Point(360, 16);
            this.dropdownDialogues.Name = "dropdownDialogues";
            this.dropdownDialogues.Size = new System.Drawing.Size(115, 21);
            this.dropdownDialogues.TabIndex = 2;
            toolTipLong.SetToolTip(this.dropdownDialogues, resources.GetString("dropdownDialogues.ToolTip"));
            this.dropdownDialogues.SelectedIndexChanged += new System.EventHandler(this.dropdownDialogues_SelectedIndexChanged);
            // 
            // labelSequence
            // 
            this.labelSequence.Location = new System.Drawing.Point(360, 71);
            this.labelSequence.Name = "labelSequence";
            this.labelSequence.Size = new System.Drawing.Size(101, 20);
            this.labelSequence.TabIndex = 11;
            this.labelSequence.Text = "Sequence: 0 of 0";
            this.labelSequence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSequencePlus
            // 
            this.buttonSequencePlus.Location = new System.Drawing.Point(554, 68);
            this.buttonSequencePlus.Name = "buttonSequencePlus";
            this.buttonSequencePlus.Size = new System.Drawing.Size(23, 23);
            this.buttonSequencePlus.TabIndex = 7;
            this.buttonSequencePlus.Text = "+";
            toolTipSimple.SetToolTip(this.buttonSequencePlus, "Add a textbox to this sequence.");
            this.buttonSequencePlus.UseVisualStyleBackColor = true;
            this.buttonSequencePlus.Click += new System.EventHandler(this.buttonSequencePlus_Click);
            // 
            // buttonSequenceMinus
            // 
            this.buttonSequenceMinus.Location = new System.Drawing.Point(525, 68);
            this.buttonSequenceMinus.Name = "buttonSequenceMinus";
            this.buttonSequenceMinus.Size = new System.Drawing.Size(23, 23);
            this.buttonSequenceMinus.TabIndex = 6;
            this.buttonSequenceMinus.Text = "-";
            toolTipSimple.SetToolTip(this.buttonSequenceMinus, "Remove this textbox from the sequence.");
            this.buttonSequenceMinus.UseVisualStyleBackColor = true;
            this.buttonSequenceMinus.Click += new System.EventHandler(this.buttonSequenceMinus_Click);
            // 
            // checkBoxGenerateAnimationTemplate
            // 
            this.checkBoxGenerateAnimationTemplate.AutoSize = true;
            this.checkBoxGenerateAnimationTemplate.Location = new System.Drawing.Point(366, 45);
            this.checkBoxGenerateAnimationTemplate.Name = "checkBoxGenerateAnimationTemplate";
            this.checkBoxGenerateAnimationTemplate.Size = new System.Drawing.Size(163, 17);
            this.checkBoxGenerateAnimationTemplate.TabIndex = 5;
            this.checkBoxGenerateAnimationTemplate.Text = "Generate AnimationTemplate";
            toolTipLong.SetToolTip(this.checkBoxGenerateAnimationTemplate, resources.GetString("checkBoxGenerateAnimationTemplate.ToolTip"));
            this.checkBoxGenerateAnimationTemplate.UseVisualStyleBackColor = true;
            this.checkBoxGenerateAnimationTemplate.CheckedChanged += new System.EventHandler(this.checkBoxGenerateAnimationTemplate_CheckedChanged);
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(232, 71);
            this.textBoxDelay.MaxLength = 10;
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(100, 20);
            this.textBoxDelay.TabIndex = 4;
            this.textBoxDelay.Text = "0.00";
            this.textBoxDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDelay.TextChanged += new System.EventHandler(this.textBoxDelay_TextChanged);
            // 
            // labelDelay
            // 
            labelDelay.AutoSize = true;
            labelDelay.Location = new System.Drawing.Point(229, 55);
            labelDelay.Name = "labelDelay";
            labelDelay.Size = new System.Drawing.Size(34, 13);
            labelDelay.TabIndex = 6;
            labelDelay.Text = "Delay";
            toolTipSimple.SetToolTip(labelDelay, "The delay in seconds before this dialogue box is shown.");
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new System.Drawing.Point(229, 16);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new System.Drawing.Size(47, 13);
            labelDuration.TabIndex = 5;
            labelDuration.Text = "Duration";
            toolTipSimple.SetToolTip(labelDuration, "The amount of seconds this dialogue box will be shown.");
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.Location = new System.Drawing.Point(232, 32);
            this.textBoxDuration.MaxLength = 10;
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(100, 20);
            this.textBoxDuration.TabIndex = 3;
            this.textBoxDuration.Text = "0.00";
            this.textBoxDuration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDuration.TextChanged += new System.EventHandler(this.textBoxDuration_TextChanged);
            // 
            // labelTexture
            // 
            labelTexture.AutoSize = true;
            labelTexture.Location = new System.Drawing.Point(3, 55);
            labelTexture.Name = "labelTexture";
            labelTexture.Size = new System.Drawing.Size(80, 13);
            labelTexture.TabIndex = 2;
            labelTexture.Text = "Textbox texture";
            toolTipLong.SetToolTip(labelTexture, resources.GetString("labelTexture.ToolTip"));
            // 
            // labelPortrait
            // 
            labelPortrait.AutoSize = true;
            labelPortrait.Location = new System.Drawing.Point(3, 16);
            labelPortrait.Name = "labelPortrait";
            labelPortrait.Size = new System.Drawing.Size(40, 13);
            labelPortrait.TabIndex = 1;
            labelPortrait.Text = "Portrait";
            toolTipSimple.SetToolTip(labelPortrait, "The texture name used for the portrait.\r\nIf using a custom texture, remember to i" +
        "nclude \"(mod)\" before the name.\r\n");
            // 
            // textBoxPortrait
            // 
            this.textBoxPortrait.Location = new System.Drawing.Point(6, 32);
            this.textBoxPortrait.MaxLength = 200;
            this.textBoxPortrait.Name = "textBoxPortrait";
            this.textBoxPortrait.Size = new System.Drawing.Size(192, 20);
            this.textBoxPortrait.TabIndex = 1;
            this.textBoxPortrait.TextChanged += new System.EventHandler(this.textBoxPortrait_TextChanged);
            // 
            // textBoxMain
            // 
            this.textBoxMain.AcceptsReturn = true;
            this.textBoxMain.AllowDrop = true;
            this.textBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMain.Location = new System.Drawing.Point(3, 103);
            this.textBoxMain.MaxLength = 500;
            this.textBoxMain.Multiline = true;
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(583, 431);
            this.textBoxMain.TabIndex = 0;
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBoxMain_TextChanged);
            // 
            // toolTipLong
            // 
            toolTipLong.AutoPopDelay = 15000;
            toolTipLong.InitialDelay = 500;
            toolTipLong.ReshowDelay = 100;
            // 
            // folderBrowserDialogModDirectory
            // 
            this.folderBrowserDialogModDirectory.Description = "Select the folder where your mod is located.";
            this.folderBrowserDialogModDirectory.ShowNewFolderButton = false;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "bnp";
            this.saveFileDialog.Filter = "Blightnauts Project|*.bnp";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "bnp";
            this.openFileDialog.Filter = "Blightnauts Project|*.bnp";
            // 
            // fontDialog
            // 
            this.fontDialog.AllowVerticalFonts = false;
            this.fontDialog.FontMustExist = true;
            this.fontDialog.ScriptsOnly = true;
            this.fontDialog.ShowEffects = false;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(481, 16);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(48, 21);
            this.buttonCopy.TabIndex = 14;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonPaste
            // 
            this.buttonPaste.Location = new System.Drawing.Point(529, 16);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(48, 21);
            this.buttonPaste.TabIndex = 15;
            this.buttonPaste.Text = "Paste";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 661);
            this.Controls.Add(generalLayout);
            this.Controls.Add(topBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = topBar;
            this.MinimumSize = new System.Drawing.Size(617, 500);
            this.Name = "EditorWindow";
            this.Text = "Blightnauts Dialogue Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditorWindow_FormClosing);
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
            generalLayout.ResumeLayout(false);
            topLayout.ResumeLayout(false);
            groupCharacter.ResumeLayout(false);
            groupCharacter.PerformLayout();
            groupTrigger.ResumeLayout(false);
            groupTrigger.PerformLayout();
            groupBoxDialogue.ResumeLayout(false);
            dialogueLayout.ResumeLayout(false);
            dialogueLayout.PerformLayout();
            groupBoxDialogueOptions.ResumeLayout(false);
            groupBoxDialogueOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem topBarNew;
        private System.Windows.Forms.ToolStripMenuItem topBarOpen;
        private System.Windows.Forms.ToolStripMenuItem topBarSave;
        private System.Windows.Forms.ToolStripMenuItem topBarSaveAs;
        private System.Windows.Forms.ToolStripMenuItem topBarExit;
        private System.Windows.Forms.ComboBox dropdownCharacters;
        private System.Windows.Forms.ComboBox dropdownTriggers;
        private System.Windows.Forms.Label labelCharacterStatus;
        private System.Windows.Forms.CheckBox checkBoxUseDefault;
        private System.Windows.Forms.TextBox textBoxPortrait;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.CheckBox checkBoxGenerateAnimationTemplate;
        private System.Windows.Forms.Label labelSequence;
        private System.Windows.Forms.Button buttonSequencePlus;
        private System.Windows.Forms.Button buttonSequenceMinus;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.ComboBox dropdownDialogues;
        private System.Windows.Forms.ComboBox dropdownTexture;
        private System.Windows.Forms.Button buttonSequencePrevious;
        private System.Windows.Forms.Button buttonSequenceNext;
        private System.Windows.Forms.ColorDialog colorDialogTextboxMain;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogModDirectory;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox checkBoxInterruptable;
        private System.Windows.Forms.CheckBox checkBoxRepeatable;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ToolStripMenuItem topBarTextboxSetFont;
        private System.Windows.Forms.ToolStripMenuItem topBarMaximize;
        private System.Windows.Forms.ToolStripMenuItem topBarCheckMissing;
        private System.Windows.Forms.ToolStripMenuItem topBarOpenRecent;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.Button buttonCopy;
    }
}