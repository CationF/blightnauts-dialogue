﻿
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
            System.Windows.Forms.MenuStrip topBar;
            System.Windows.Forms.ToolStripMenuItem topBarFile;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripMenuItem topBarProject;
            System.Windows.Forms.ToolStripMenuItem topBarInfo;
            System.Windows.Forms.TableLayoutPanel generalLayout;
            System.Windows.Forms.TableLayoutPanel topLayout;
            System.Windows.Forms.GroupBox groupCharacter;
            System.Windows.Forms.GroupBox groupTrigger;
            System.Windows.Forms.GroupBox groupBoxDialogue;
            System.Windows.Forms.TableLayoutPanel dialogueLayout;
            System.Windows.Forms.GroupBox groupBoxDialogueOptions;
            System.Windows.Forms.Label labelPortrait;
            System.Windows.Forms.Label labelDialogueBox;
            System.Windows.Forms.Label labelDuration;
            System.Windows.Forms.Label labelDelay;
            this.topBarNew = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarSave = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarExit = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarNewTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarLoadTrigger = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.topBarAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.characterDropdown = new System.Windows.Forms.ComboBox();
            this.triggerDropdown = new System.Windows.Forms.ComboBox();
            this.checkBoxUseDefault = new System.Windows.Forms.CheckBox();
            this.labelCharacterStatus = new System.Windows.Forms.Label();
            this.labelTriggerStatus = new System.Windows.Forms.Label();
            this.textBoxPortrait = new System.Windows.Forms.TextBox();
            this.textBoxDialogueBox = new System.Windows.Forms.TextBox();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.checkBoxGenerateAnimationTemplate = new System.Windows.Forms.CheckBox();
            this.buttonSequenceMinus = new System.Windows.Forms.Button();
            this.buttonSequencePlus = new System.Windows.Forms.Button();
            this.labelSequence = new System.Windows.Forms.Label();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            topBar = new System.Windows.Forms.MenuStrip();
            topBarFile = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            topBarProject = new System.Windows.Forms.ToolStripMenuItem();
            topBarInfo = new System.Windows.Forms.ToolStripMenuItem();
            generalLayout = new System.Windows.Forms.TableLayoutPanel();
            topLayout = new System.Windows.Forms.TableLayoutPanel();
            groupCharacter = new System.Windows.Forms.GroupBox();
            groupTrigger = new System.Windows.Forms.GroupBox();
            groupBoxDialogue = new System.Windows.Forms.GroupBox();
            dialogueLayout = new System.Windows.Forms.TableLayoutPanel();
            groupBoxDialogueOptions = new System.Windows.Forms.GroupBox();
            labelPortrait = new System.Windows.Forms.Label();
            labelDialogueBox = new System.Windows.Forms.Label();
            labelDuration = new System.Windows.Forms.Label();
            labelDelay = new System.Windows.Forms.Label();
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
            topBarProject,
            topBarInfo});
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
            toolStripSeparator2,
            this.topBarSave,
            this.topBarSaveAs,
            toolStripSeparator3,
            this.topBarExit});
            topBarFile.Name = "topBarFile";
            topBarFile.Size = new System.Drawing.Size(37, 20);
            topBarFile.Text = "File";
            // 
            // topBarNew
            // 
            this.topBarNew.Name = "topBarNew";
            this.topBarNew.Size = new System.Drawing.Size(112, 22);
            this.topBarNew.Text = "New";
            this.topBarNew.Click += new System.EventHandler(this.topBarNew_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // topBarOpen
            // 
            this.topBarOpen.Name = "topBarOpen";
            this.topBarOpen.Size = new System.Drawing.Size(112, 22);
            this.topBarOpen.Text = "Open";
            this.topBarOpen.Click += new System.EventHandler(this.topBarOpen_Click);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(109, 6);
            // 
            // topBarSave
            // 
            this.topBarSave.Name = "topBarSave";
            this.topBarSave.Size = new System.Drawing.Size(112, 22);
            this.topBarSave.Text = "Save";
            this.topBarSave.Click += new System.EventHandler(this.topBarSave_Click);
            // 
            // topBarSaveAs
            // 
            this.topBarSaveAs.Name = "topBarSaveAs";
            this.topBarSaveAs.Size = new System.Drawing.Size(112, 22);
            this.topBarSaveAs.Text = "Save as";
            this.topBarSaveAs.Click += new System.EventHandler(this.topBarSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(109, 6);
            // 
            // topBarExit
            // 
            this.topBarExit.Name = "topBarExit";
            this.topBarExit.Size = new System.Drawing.Size(112, 22);
            this.topBarExit.Text = "Exit";
            this.topBarExit.Click += new System.EventHandler(this.topBarExit_Click);
            // 
            // topBarProject
            // 
            topBarProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topBarNewTrigger,
            this.topBarLoadTrigger});
            topBarProject.Name = "topBarProject";
            topBarProject.Size = new System.Drawing.Size(56, 20);
            topBarProject.Text = "Project";
            // 
            // topBarNewTrigger
            // 
            this.topBarNewTrigger.Name = "topBarNewTrigger";
            this.topBarNewTrigger.Size = new System.Drawing.Size(139, 22);
            this.topBarNewTrigger.Text = "New Trigger";
            this.topBarNewTrigger.Click += new System.EventHandler(this.topBarNewTrigger_Click);
            // 
            // topBarLoadTrigger
            // 
            this.topBarLoadTrigger.Name = "topBarLoadTrigger";
            this.topBarLoadTrigger.Size = new System.Drawing.Size(139, 22);
            this.topBarLoadTrigger.Text = "Load Trigger";
            this.topBarLoadTrigger.Click += new System.EventHandler(this.topBarLoadTrigger_Click);
            // 
            // topBarInfo
            // 
            topBarInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topBarHelp,
            this.topBarAbout});
            topBarInfo.Name = "topBarInfo";
            topBarInfo.Size = new System.Drawing.Size(40, 20);
            topBarInfo.Text = "Info";
            // 
            // topBarHelp
            // 
            this.topBarHelp.Name = "topBarHelp";
            this.topBarHelp.Size = new System.Drawing.Size(107, 22);
            this.topBarHelp.Text = "Help";
            // 
            // topBarAbout
            // 
            this.topBarAbout.Name = "topBarAbout";
            this.topBarAbout.Size = new System.Drawing.Size(107, 22);
            this.topBarAbout.Text = "About";
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
            groupCharacter.Controls.Add(this.characterDropdown);
            groupCharacter.Dock = System.Windows.Forms.DockStyle.Fill;
            groupCharacter.Location = new System.Drawing.Point(3, 3);
            groupCharacter.Name = "groupCharacter";
            groupCharacter.Size = new System.Drawing.Size(294, 69);
            groupCharacter.TabIndex = 0;
            groupCharacter.TabStop = false;
            groupCharacter.Text = "Character";
            // 
            // characterDropdown
            // 
            this.characterDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.characterDropdown.FormattingEnabled = true;
            this.characterDropdown.Location = new System.Drawing.Point(6, 19);
            this.characterDropdown.Name = "characterDropdown";
            this.characterDropdown.Size = new System.Drawing.Size(282, 21);
            this.characterDropdown.TabIndex = 0;
            // 
            // groupTrigger
            // 
            groupTrigger.Controls.Add(this.labelTriggerStatus);
            groupTrigger.Controls.Add(this.triggerDropdown);
            groupTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            groupTrigger.Location = new System.Drawing.Point(303, 3);
            groupTrigger.Name = "groupTrigger";
            groupTrigger.Size = new System.Drawing.Size(294, 69);
            groupTrigger.TabIndex = 1;
            groupTrigger.TabStop = false;
            groupTrigger.Text = "Trigger";
            // 
            // triggerDropdown
            // 
            this.triggerDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.triggerDropdown.FormattingEnabled = true;
            this.triggerDropdown.Location = new System.Drawing.Point(7, 19);
            this.triggerDropdown.Name = "triggerDropdown";
            this.triggerDropdown.Size = new System.Drawing.Size(281, 21);
            this.triggerDropdown.TabIndex = 0;
            // 
            // checkBoxUseDefault
            // 
            this.checkBoxUseDefault.AutoSize = true;
            this.checkBoxUseDefault.Location = new System.Drawing.Point(186, 47);
            this.checkBoxUseDefault.Name = "checkBoxUseDefault";
            this.checkBoxUseDefault.Size = new System.Drawing.Size(102, 17);
            this.checkBoxUseDefault.TabIndex = 1;
            this.checkBoxUseDefault.Text = "Use default skin";
            this.checkBoxUseDefault.UseVisualStyleBackColor = true;
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
            // labelTriggerStatus
            // 
            this.labelTriggerStatus.Location = new System.Drawing.Point(7, 47);
            this.labelTriggerStatus.Name = "labelTriggerStatus";
            this.labelTriggerStatus.Size = new System.Drawing.Size(281, 17);
            this.labelTriggerStatus.TabIndex = 1;
            this.labelTriggerStatus.Text = "Status";
            this.labelTriggerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            groupBoxDialogueOptions.Controls.Add(this.labelSequence);
            groupBoxDialogueOptions.Controls.Add(this.buttonSequencePlus);
            groupBoxDialogueOptions.Controls.Add(this.buttonSequenceMinus);
            groupBoxDialogueOptions.Controls.Add(this.checkBoxGenerateAnimationTemplate);
            groupBoxDialogueOptions.Controls.Add(this.textBoxDelay);
            groupBoxDialogueOptions.Controls.Add(labelDelay);
            groupBoxDialogueOptions.Controls.Add(labelDuration);
            groupBoxDialogueOptions.Controls.Add(this.textBoxDuration);
            groupBoxDialogueOptions.Controls.Add(this.textBoxDialogueBox);
            groupBoxDialogueOptions.Controls.Add(labelDialogueBox);
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
            // textBoxPortrait
            // 
            this.textBoxPortrait.Location = new System.Drawing.Point(6, 32);
            this.textBoxPortrait.MaxLength = 200;
            this.textBoxPortrait.Name = "textBoxPortrait";
            this.textBoxPortrait.Size = new System.Drawing.Size(192, 20);
            this.textBoxPortrait.TabIndex = 1;
            // 
            // labelPortrait
            // 
            labelPortrait.AutoSize = true;
            labelPortrait.Location = new System.Drawing.Point(3, 16);
            labelPortrait.Name = "labelPortrait";
            labelPortrait.Size = new System.Drawing.Size(40, 13);
            labelPortrait.TabIndex = 1;
            labelPortrait.Text = "Portrait";
            // 
            // labelDialogueBox
            // 
            labelDialogueBox.AutoSize = true;
            labelDialogueBox.Location = new System.Drawing.Point(3, 55);
            labelDialogueBox.Name = "labelDialogueBox";
            labelDialogueBox.Size = new System.Drawing.Size(70, 13);
            labelDialogueBox.TabIndex = 2;
            labelDialogueBox.Text = "Dialogue Box";
            // 
            // textBoxDialogueBox
            // 
            this.textBoxDialogueBox.Location = new System.Drawing.Point(6, 71);
            this.textBoxDialogueBox.MaxLength = 200;
            this.textBoxDialogueBox.Name = "textBoxDialogueBox";
            this.textBoxDialogueBox.Size = new System.Drawing.Size(192, 20);
            this.textBoxDialogueBox.TabIndex = 2;
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
            // 
            // labelDuration
            // 
            labelDuration.AutoSize = true;
            labelDuration.Location = new System.Drawing.Point(229, 16);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new System.Drawing.Size(47, 13);
            labelDuration.TabIndex = 5;
            labelDuration.Text = "Duration";
            // 
            // labelDelay
            // 
            labelDelay.AutoSize = true;
            labelDelay.Location = new System.Drawing.Point(229, 55);
            labelDelay.Name = "labelDelay";
            labelDelay.Size = new System.Drawing.Size(34, 13);
            labelDelay.TabIndex = 6;
            labelDelay.Text = "Delay";
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
            // 
            // checkBoxGenerateAnimationTemplate
            // 
            this.checkBoxGenerateAnimationTemplate.AutoSize = true;
            this.checkBoxGenerateAnimationTemplate.Location = new System.Drawing.Point(366, 34);
            this.checkBoxGenerateAnimationTemplate.Name = "checkBoxGenerateAnimationTemplate";
            this.checkBoxGenerateAnimationTemplate.Size = new System.Drawing.Size(163, 17);
            this.checkBoxGenerateAnimationTemplate.TabIndex = 5;
            this.checkBoxGenerateAnimationTemplate.Text = "Generate AnimationTemplate";
            this.checkBoxGenerateAnimationTemplate.UseVisualStyleBackColor = true;
            // 
            // buttonSequenceMinus
            // 
            this.buttonSequenceMinus.Location = new System.Drawing.Point(525, 68);
            this.buttonSequenceMinus.Name = "buttonSequenceMinus";
            this.buttonSequenceMinus.Size = new System.Drawing.Size(23, 23);
            this.buttonSequenceMinus.TabIndex = 6;
            this.buttonSequenceMinus.Text = "-";
            this.buttonSequenceMinus.UseVisualStyleBackColor = true;
            // 
            // buttonSequencePlus
            // 
            this.buttonSequencePlus.Location = new System.Drawing.Point(554, 68);
            this.buttonSequencePlus.Name = "buttonSequencePlus";
            this.buttonSequencePlus.Size = new System.Drawing.Size(23, 23);
            this.buttonSequencePlus.TabIndex = 7;
            this.buttonSequencePlus.Text = "+";
            this.buttonSequencePlus.UseVisualStyleBackColor = true;
            // 
            // labelSequence
            // 
            this.labelSequence.Location = new System.Drawing.Point(363, 71);
            this.labelSequence.Name = "labelSequence";
            this.labelSequence.Size = new System.Drawing.Size(156, 20);
            this.labelSequence.TabIndex = 11;
            this.labelSequence.Text = "Sequence: 0 of 0";
            this.labelSequence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 661);
            this.Controls.Add(generalLayout);
            this.Controls.Add(topBar);
            this.MainMenuStrip = topBar;
            this.MinimumSize = new System.Drawing.Size(617, 500);
            this.Name = "EditorWindow";
            this.Text = "EditorWindow";
            topBar.ResumeLayout(false);
            topBar.PerformLayout();
            generalLayout.ResumeLayout(false);
            topLayout.ResumeLayout(false);
            groupCharacter.ResumeLayout(false);
            groupCharacter.PerformLayout();
            groupTrigger.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem topBarNewTrigger;
        private System.Windows.Forms.ToolStripMenuItem topBarLoadTrigger;
        private System.Windows.Forms.ToolStripMenuItem topBarHelp;
        private System.Windows.Forms.ToolStripMenuItem topBarAbout;
        private System.Windows.Forms.ComboBox characterDropdown;
        private System.Windows.Forms.ComboBox triggerDropdown;
        private System.Windows.Forms.Label labelCharacterStatus;
        private System.Windows.Forms.CheckBox checkBoxUseDefault;
        private System.Windows.Forms.Label labelTriggerStatus;
        private System.Windows.Forms.TextBox textBoxDialogueBox;
        private System.Windows.Forms.TextBox textBoxPortrait;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.CheckBox checkBoxGenerateAnimationTemplate;
        private System.Windows.Forms.Label labelSequence;
        private System.Windows.Forms.Button buttonSequencePlus;
        private System.Windows.Forms.Button buttonSequenceMinus;
        private System.Windows.Forms.TextBox textBoxMain;
    }
}