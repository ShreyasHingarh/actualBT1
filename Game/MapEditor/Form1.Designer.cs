namespace MapEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PathPicture = new PictureBox();
            StartPath = new PictureBox();
            EndPath = new PictureBox();
            Save = new Button();
            LoadButton = new Button();
            Eraser = new Button();
            Update = new System.Windows.Forms.Timer(components);
            StartSearch = new Button();
            TheScreen = new PictureBox();
            Clear = new Button();
            ((System.ComponentModel.ISupportInitialize)PathPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)StartPath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)EndPath).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TheScreen).BeginInit();
            SuspendLayout();
            // 
            // PathPicture
            // 
            PathPicture.Image = Properties.Resources.Path;
            PathPicture.Location = new Point(1063, 860);
            PathPicture.Margin = new Padding(3, 4, 3, 4);
            PathPicture.Name = "PathPicture";
            PathPicture.Size = new Size(30, 30);
            PathPicture.SizeMode = PictureBoxSizeMode.AutoSize;
            PathPicture.TabIndex = 0;
            PathPicture.TabStop = false;
            PathPicture.Click += PathPicture_Click;
            // 
            // StartPath
            // 
            StartPath.Image = Properties.Resources.Startx;
            StartPath.Location = new Point(1063, 799);
            StartPath.Margin = new Padding(3, 4, 3, 4);
            StartPath.Name = "StartPath";
            StartPath.Size = new Size(30, 30);
            StartPath.SizeMode = PictureBoxSizeMode.AutoSize;
            StartPath.TabIndex = 1;
            StartPath.TabStop = false;
            StartPath.Click += StartPath_Click;
            // 
            // EndPath
            // 
            EndPath.Image = Properties.Resources.Endx;
            EndPath.Location = new Point(1063, 940);
            EndPath.Margin = new Padding(3, 4, 3, 4);
            EndPath.Name = "EndPath";
            EndPath.Size = new Size(30, 30);
            EndPath.SizeMode = PictureBoxSizeMode.AutoSize;
            EndPath.TabIndex = 2;
            EndPath.TabStop = false;
            EndPath.Click += EndPath_Click;
            // 
            // Save
            // 
            Save.Location = new Point(1037, 736);
            Save.Margin = new Padding(3, 4, 3, 4);
            Save.Name = "Save";
            Save.Size = new Size(86, 31);
            Save.TabIndex = 3;
            Save.Text = "SaveToFile";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(1006, 684);
            LoadButton.Margin = new Padding(3, 4, 3, 4);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(117, 31);
            LoadButton.TabIndex = 4;
            LoadButton.Text = "LoadFromFile";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // Eraser
            // 
            Eraser.Location = new Point(1037, 629);
            Eraser.Margin = new Padding(3, 4, 3, 4);
            Eraser.Name = "Eraser";
            Eraser.Size = new Size(86, 31);
            Eraser.TabIndex = 5;
            Eraser.Text = "Eraser";
            Eraser.UseVisualStyleBackColor = true;
            Eraser.Click += Eraser_Click;
            // 
            // Update
            // 
            Update.Enabled = true;
            Update.Interval = 10;
            Update.Tick += Update_Tick;
            // 
            // StartSearch
            // 
            StartSearch.Location = new Point(1017, 575);
            StartSearch.Margin = new Padding(3, 4, 3, 4);
            StartSearch.Name = "StartSearch";
            StartSearch.Size = new Size(105, 31);
            StartSearch.TabIndex = 6;
            StartSearch.Text = "StartSearch";
            StartSearch.UseVisualStyleBackColor = true;
            StartSearch.Click += StartSearch_Click;
            // 
            // TheScreen
            // 
            TheScreen.Location = new Point(0, 0);
            TheScreen.Margin = new Padding(3, 4, 3, 4);
            TheScreen.Name = "TheScreen";
            TheScreen.Size = new Size(926, 1080);
            TheScreen.TabIndex = 7;
            TheScreen.TabStop = false;
            TheScreen.Visible = false;
            // 
            // Clear
            // 
            Clear.Location = new Point(1029, 521);
            Clear.Name = "Clear";
            Clear.Size = new Size(94, 29);
            Clear.TabIndex = 8;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1136, 1055);
            Controls.Add(Clear);
            Controls.Add(TheScreen);
            Controls.Add(StartSearch);
            Controls.Add(Eraser);
            Controls.Add(LoadButton);
            Controls.Add(Save);
            Controls.Add(EndPath);
            Controls.Add(StartPath);
            Controls.Add(PathPicture);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PathPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)StartPath).EndInit();
            ((System.ComponentModel.ISupportInitialize)EndPath).EndInit();
            ((System.ComponentModel.ISupportInitialize)TheScreen).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PathPicture;
        private PictureBox StartPath;
        private PictureBox EndPath;
        private Button Save;
        private Button LoadButton;
        private Button Eraser;
        private System.Windows.Forms.Timer Update;
        private Button StartSearch;
        private PictureBox TheScreen;
        private Button Clear;
    }
}