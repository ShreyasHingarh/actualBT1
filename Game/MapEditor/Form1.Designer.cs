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
            this.components = new System.ComponentModel.Container();
            this.PathPicture = new System.Windows.Forms.PictureBox();
            this.StartPath = new System.Windows.Forms.PictureBox();
            this.EndPath = new System.Windows.Forms.PictureBox();
            this.Save = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.Eraser = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Timer(this.components);
            this.StartSearch = new System.Windows.Forms.Button();
            this.TheScreen = new System.Windows.Forms.PictureBox();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PathPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TheScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // PathPicture
            // 
            this.PathPicture.Image = global::MapEditor.Properties.Resources.Path;
            this.PathPicture.Location = new System.Drawing.Point(930, 645);
            this.PathPicture.Name = "PathPicture";
            this.PathPicture.Size = new System.Drawing.Size(30, 30);
            this.PathPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PathPicture.TabIndex = 0;
            this.PathPicture.TabStop = false;
            // 
            // StartPath
            // 
            this.StartPath.Image = global::MapEditor.Properties.Resources.Startx;
            this.StartPath.Location = new System.Drawing.Point(930, 599);
            this.StartPath.Name = "StartPath";
            this.StartPath.Size = new System.Drawing.Size(30, 30);
            this.StartPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.StartPath.TabIndex = 1;
            this.StartPath.TabStop = false;
            // 
            // EndPath
            // 
            this.EndPath.Image = global::MapEditor.Properties.Resources.Endx;
            this.EndPath.Location = new System.Drawing.Point(930, 705);
            this.EndPath.Name = "EndPath";
            this.EndPath.Size = new System.Drawing.Size(30, 30);
            this.EndPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.EndPath.TabIndex = 2;
            this.EndPath.TabStop = false;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(907, 552);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 3;
            this.Save.Text = "SaveToFile";
            this.Save.UseVisualStyleBackColor = true;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(880, 513);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(102, 23);
            this.LoadButton.TabIndex = 4;
            this.LoadButton.Text = "LoadFromFile";
            this.LoadButton.UseVisualStyleBackColor = true;
            // 
            // Eraser
            // 
            this.Eraser.Location = new System.Drawing.Point(907, 472);
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(75, 23);
            this.Eraser.TabIndex = 5;
            this.Eraser.Text = "Eraser";
            this.Eraser.UseVisualStyleBackColor = true;
            // 
            // Update
            // 
            this.Update.Enabled = true;
            this.Update.Interval = 10;
            // 
            // StartSearch
            // 
            this.StartSearch.Location = new System.Drawing.Point(890, 431);
            this.StartSearch.Name = "StartSearch";
            this.StartSearch.Size = new System.Drawing.Size(92, 23);
            this.StartSearch.TabIndex = 6;
            this.StartSearch.Text = "StartSearch";
            this.StartSearch.UseVisualStyleBackColor = true;
            // 
            // TheScreen
            // 
            this.TheScreen.Location = new System.Drawing.Point(0, 0);
            this.TheScreen.Name = "TheScreen";
            this.TheScreen.Size = new System.Drawing.Size(810, 810);
            this.TheScreen.TabIndex = 7;
            this.TheScreen.TabStop = false;
            this.TheScreen.Visible = false;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(900, 391);
            this.Clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(82, 22);
            this.Clear.TabIndex = 8;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 811);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.TheScreen);
            this.Controls.Add(this.StartSearch);
            this.Controls.Add(this.Eraser);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.EndPath);
            this.Controls.Add(this.StartPath);
            this.Controls.Add(this.PathPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PathPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TheScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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