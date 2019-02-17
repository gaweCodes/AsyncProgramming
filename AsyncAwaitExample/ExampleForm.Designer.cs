namespace AsyncAwaitExample
{
    partial class ExampleForm
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
            this.LstSpeakers = new System.Windows.Forms.ListBox();
            this.BtnLoadData = new System.Windows.Forms.Button();
            this.LstSessions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LstSpeakers
            // 
            this.LstSpeakers.FormattingEnabled = true;
            this.LstSpeakers.Location = new System.Drawing.Point(13, 13);
            this.LstSpeakers.Name = "LstSpeakers";
            this.LstSpeakers.Size = new System.Drawing.Size(384, 394);
            this.LstSpeakers.TabIndex = 0;
            // 
            // BtnLoadData
            // 
            this.BtnLoadData.Location = new System.Drawing.Point(13, 413);
            this.BtnLoadData.Name = "BtnLoadData";
            this.BtnLoadData.Size = new System.Drawing.Size(775, 23);
            this.BtnLoadData.TabIndex = 1;
            this.BtnLoadData.Text = "Load Data";
            this.BtnLoadData.UseVisualStyleBackColor = true;
            this.BtnLoadData.Click += new System.EventHandler(this.BtnLoadData_Click);
            // 
            // LstSessions
            // 
            this.LstSessions.FormattingEnabled = true;
            this.LstSessions.Location = new System.Drawing.Point(403, 13);
            this.LstSessions.Name = "LstSessions";
            this.LstSessions.Size = new System.Drawing.Size(385, 394);
            this.LstSessions.TabIndex = 2;
            // 
            // ExampleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LstSessions);
            this.Controls.Add(this.BtnLoadData);
            this.Controls.Add(this.LstSpeakers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExampleForm";
            this.ShowIcon = false;
            this.Text = "Example Async Await";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstSpeakers;
        private System.Windows.Forms.Button BtnLoadData;
        private System.Windows.Forms.ListBox LstSessions;
    }
}

