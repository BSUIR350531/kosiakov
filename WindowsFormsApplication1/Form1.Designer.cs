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
            this.SuspendLayout();
            // 
            // openNewFile
            // 
            this.openNewFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openNewFile.Location = new System.Drawing.Point(108, 98);
            this.openNewFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openNewFile.Name = "openNewFile";
            this.openNewFile.Size = new System.Drawing.Size(549, 96);
            this.openNewFile.TabIndex = 0;
            this.openNewFile.Text = "Open a file";
            this.openNewFile.UseVisualStyleBackColor = true;
            this.openNewFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 429);
            this.Controls.Add(this.openNewFile);
            this.Font = new System.Drawing.Font("Times New Roman", 12.06283F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "mainForm";
            this.Text = "Archiver T1000";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openNewFile;
    }
}

