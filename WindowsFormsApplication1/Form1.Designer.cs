namespace WindowsFormsApplication1
{
    partial class mainForm
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
            this.openNewFile = new System.Windows.Forms.Button();
            this.actionButton = new System.Windows.Forms.Button();
            this.lableFileName = new System.Windows.Forms.Label();
            this.lableSizeFile = new System.Windows.Forms.Label();
            this.lablelFileNameText = new System.Windows.Forms.Label();
            this.lableFileNameSize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openNewFile
            // 
            this.openNewFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openNewFile.Location = new System.Drawing.Point(121, 120);
            this.openNewFile.Margin = new System.Windows.Forms.Padding(4);
            this.openNewFile.Name = "openNewFile";
            this.openNewFile.Size = new System.Drawing.Size(431, 96);
            this.openNewFile.TabIndex = 0;
            this.openNewFile.Text = "Open a file";
            this.openNewFile.UseVisualStyleBackColor = true;
            this.openNewFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // actionButton
            // 
            this.actionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionButton.Enabled = false;
            this.actionButton.Location = new System.Drawing.Point(175, 95);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(317, 94);
            this.actionButton.TabIndex = 1;
            this.actionButton.Text = "Start packing";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Visible = false;
            this.actionButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lableFileName
            // 
            this.lableFileName.AutoSize = true;
            this.lableFileName.Location = new System.Drawing.Point(126, 243);
            this.lableFileName.Name = "lableFileName";
            this.lableFileName.Size = new System.Drawing.Size(76, 37);
            this.lableFileName.TabIndex = 2;
            this.lableFileName.Text = "File:";
            // 
            // lableSizeFile
            // 
            this.lableSizeFile.AutoSize = true;
            this.lableSizeFile.Location = new System.Drawing.Point(126, 309);
            this.lableSizeFile.Name = "lableSizeFile";
            this.lableSizeFile.Size = new System.Drawing.Size(81, 37);
            this.lableSizeFile.TabIndex = 3;
            this.lableSizeFile.Text = "Size:";
            // 
            // lablelFileNameText
            // 
            this.lablelFileNameText.AutoSize = true;
            this.lablelFileNameText.Location = new System.Drawing.Point(208, 243);
            this.lablelFileNameText.Name = "lablelFileNameText";
            this.lablelFileNameText.Size = new System.Drawing.Size(76, 37);
            this.lablelFileNameText.TabIndex = 4;
            this.lablelFileNameText.Text = "File:";
            // 
            // lableFileNameSize
            // 
            this.lableFileNameSize.AutoSize = true;
            this.lableFileNameSize.Location = new System.Drawing.Point(208, 309);
            this.lableFileNameSize.Name = "lableFileNameSize";
            this.lableFileNameSize.Size = new System.Drawing.Size(76, 37);
            this.lableFileNameSize.TabIndex = 5;
            this.lableFileNameSize.Text = "File:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 429);
            this.Controls.Add(this.lableFileNameSize);
            this.Controls.Add(this.lablelFileNameText);
            this.Controls.Add(this.lableSizeFile);
            this.Controls.Add(this.lableFileName);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.openNewFile);
            this.Font = new System.Drawing.Font("Times New Roman", 12.06283F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(700, 500);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "mainForm";
            this.Text = "Archiver T1000";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openNewFile;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Label lableFileName;
        private System.Windows.Forms.Label lableSizeFile;
        private System.Windows.Forms.Label lablelFileNameText;
        private System.Windows.Forms.Label lableFileNameSize;
    }
}

