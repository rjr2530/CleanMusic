namespace CleanMusic
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
            this.directoryButton = new System.Windows.Forms.Button();
            this.organizeButton = new System.Windows.Forms.Button();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // directoryButton
            // 
            this.directoryButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.directoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.directoryButton.Location = new System.Drawing.Point(12, 12);
            this.directoryButton.Name = "directoryButton";
            this.directoryButton.Size = new System.Drawing.Size(107, 23);
            this.directoryButton.TabIndex = 0;
            this.directoryButton.Text = "Choose Directory";
            this.directoryButton.UseVisualStyleBackColor = false;
            this.directoryButton.Click += new System.EventHandler(this.directoryButton_Click);
            // 
            // organizeButton
            // 
            this.organizeButton.Location = new System.Drawing.Point(154, 226);
            this.organizeButton.Name = "organizeButton";
            this.organizeButton.Size = new System.Drawing.Size(75, 23);
            this.organizeButton.TabIndex = 1;
            this.organizeButton.Text = "Clean Music";
            this.organizeButton.UseVisualStyleBackColor = true;
            this.organizeButton.Click += new System.EventHandler(this.organizeButton_Click);
            // 
            // directoryLabel
            // 
            this.directoryLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.directoryLabel.Location = new System.Drawing.Point(129, 12);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(291, 23);
            this.directoryLabel.TabIndex = 2;
            this.directoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.statusTextBox.Location = new System.Drawing.Point(13, 52);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.Size = new System.Drawing.Size(407, 155);
            this.statusTextBox.TabIndex = 0;
            this.statusTextBox.TabStop = false;
            this.statusTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.organizeButton);
            this.Controls.Add(this.directoryButton);
            this.Name = "Form1";
            this.Text = "CleanMusic";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button directoryButton;
        private System.Windows.Forms.Button organizeButton;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.RichTextBox statusTextBox;
    }
}

