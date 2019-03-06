namespace eSports_Checker
{
    partial class Notice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notice));
            this.Header = new System.Windows.Forms.PictureBox();
            this.Alert = new System.Windows.Forms.Label();
            this.Declaration = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Header)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.Transparent;
            this.Header.Image = ((System.Drawing.Image)(resources.GetObject("Header.Image")));
            this.Header.Location = new System.Drawing.Point(106, 3);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(224, 72);
            this.Header.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Header.TabIndex = 0;
            this.Header.TabStop = false;
            // 
            // Alert
            // 
            this.Alert.AutoSize = true;
            this.Alert.BackColor = System.Drawing.Color.Transparent;
            this.Alert.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Alert.ForeColor = System.Drawing.Color.White;
            this.Alert.Location = new System.Drawing.Point(23, 78);
            this.Alert.Name = "Alert";
            this.Alert.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Alert.Size = new System.Drawing.Size(381, 80);
            this.Alert.TabIndex = 1;
            this.Alert.Text = resources.GetString("Alert.Text");
            this.Alert.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Declaration
            // 
            this.Declaration.AutoSize = true;
            this.Declaration.BackColor = System.Drawing.Color.Transparent;
            this.Declaration.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Declaration.ForeColor = System.Drawing.Color.Red;
            this.Declaration.Location = new System.Drawing.Point(33, 170);
            this.Declaration.Name = "Declaration";
            this.Declaration.Size = new System.Drawing.Size(361, 36);
            this.Declaration.TabIndex = 2;
            this.Declaration.Text = "I hereby give my consent to ProLeague on processing of such data as; \r\na list of " +
    "process, information about my computer and screenshots. To\r\nprevent cheaters and" +
    " allow honest gameplay.";
            this.Declaration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Confirm
            // 
            this.Confirm.AutoSize = true;
            this.Confirm.BackColor = System.Drawing.Color.Transparent;
            this.Confirm.ForeColor = System.Drawing.Color.White;
            this.Confirm.Location = new System.Drawing.Point(128, 219);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(176, 17);
            this.Confirm.TabIndex = 3;
            this.Confirm.Text = "I accept these terms and policy.";
            this.Confirm.UseVisualStyleBackColor = false;
            this.Confirm.CheckedChanged += new System.EventHandler(this.Confirm_CheckedChanged);
            // 
            // Notice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(427, 244);
            this.Controls.Add(this.Confirm);
            this.Controls.Add(this.Declaration);
            this.Controls.Add(this.Alert);
            this.Controls.Add(this.Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Notice";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Notice";
            ((System.ComponentModel.ISupportInitialize)(this.Header)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Header;
        private System.Windows.Forms.Label Alert;
        private System.Windows.Forms.Label Declaration;
        private System.Windows.Forms.CheckBox Confirm;
    }
}