namespace CyberCopy
{
    partial class FrmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboMainForm = new System.Windows.Forms.CheckBox();
            this.cboBeep = new System.Windows.Forms.CheckBox();
            this.cboClipboard = new System.Windows.Forms.CheckBox();
            this.cboStartOnStartup = new System.Windows.Forms.CheckBox();
            this.btnRevertToDefault = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cboEnglish = new System.Windows.Forms.CheckBox();
            this.cboArabic = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboArabic);
            this.groupBox1.Controls.Add(this.cboEnglish);
            this.groupBox1.Controls.Add(this.cboMainForm);
            this.groupBox1.Controls.Add(this.cboBeep);
            this.groupBox1.Controls.Add(this.cboClipboard);
            this.groupBox1.Controls.Add(this.cboStartOnStartup);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // cboMainForm
            // 
            this.cboMainForm.AutoSize = true;
            this.cboMainForm.Location = new System.Drawing.Point(23, 143);
            this.cboMainForm.Name = "cboMainForm";
            this.cboMainForm.Size = new System.Drawing.Size(247, 21);
            this.cboMainForm.TabIndex = 3;
            this.cboMainForm.Text = "Bring up main window after capture";
            this.cboMainForm.UseVisualStyleBackColor = true;
            // 
            // cboBeep
            // 
            this.cboBeep.AutoSize = true;
            this.cboBeep.Location = new System.Drawing.Point(22, 109);
            this.cboBeep.Name = "cboBeep";
            this.cboBeep.Size = new System.Drawing.Size(119, 21);
            this.cboBeep.TabIndex = 2;
            this.cboBeep.Text = "Beep on failure";
            this.cboBeep.UseVisualStyleBackColor = true;
            // 
            // cboClipboard
            // 
            this.cboClipboard.AutoSize = true;
            this.cboClipboard.Location = new System.Drawing.Point(22, 73);
            this.cboClipboard.Name = "cboClipboard";
            this.cboClipboard.Size = new System.Drawing.Size(184, 21);
            this.cboClipboard.TabIndex = 1;
            this.cboClipboard.Text = "Auto Copy into Clipboard";
            this.cboClipboard.UseVisualStyleBackColor = true;
            // 
            // cboStartOnStartup
            // 
            this.cboStartOnStartup.AutoSize = true;
            this.cboStartOnStartup.Location = new System.Drawing.Point(22, 36);
            this.cboStartOnStartup.Name = "cboStartOnStartup";
            this.cboStartOnStartup.Size = new System.Drawing.Size(198, 21);
            this.cboStartOnStartup.TabIndex = 0;
            this.cboStartOnStartup.Text = "Start CyberCopy at startup";
            this.cboStartOnStartup.UseVisualStyleBackColor = true;
            // 
            // btnRevertToDefault
            // 
            this.btnRevertToDefault.Location = new System.Drawing.Point(84, 259);
            this.btnRevertToDefault.Name = "btnRevertToDefault";
            this.btnRevertToDefault.Size = new System.Drawing.Size(135, 37);
            this.btnRevertToDefault.TabIndex = 1;
            this.btnRevertToDefault.Text = "Restore to default";
            this.btnRevertToDefault.UseVisualStyleBackColor = true;
            this.btnRevertToDefault.Click += new System.EventHandler(this.btnRevertToDefault_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(235, 259);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(106, 36);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cboEnglish
            // 
            this.cboEnglish.AutoSize = true;
            this.cboEnglish.Location = new System.Drawing.Point(115, 189);
            this.cboEnglish.Name = "cboEnglish";
            this.cboEnglish.Size = new System.Drawing.Size(72, 21);
            this.cboEnglish.TabIndex = 4;
            this.cboEnglish.Text = "English";
            this.cboEnglish.UseVisualStyleBackColor = true;
            // 
            // cboArabic
            // 
            this.cboArabic.AutoSize = true;
            this.cboArabic.Location = new System.Drawing.Point(199, 189);
            this.cboArabic.Name = "cboArabic";
            this.cboArabic.Size = new System.Drawing.Size(67, 21);
            this.cboArabic.TabIndex = 4;
            this.cboArabic.Text = "Arabic";
            this.cboArabic.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lanaguage:";
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 308);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnRevertToDefault);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOptions";
            this.Text = "Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cboBeep;
        private System.Windows.Forms.CheckBox cboClipboard;
        private System.Windows.Forms.CheckBox cboStartOnStartup;
        private System.Windows.Forms.Button btnRevertToDefault;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox cboMainForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cboArabic;
        private System.Windows.Forms.CheckBox cboEnglish;
    }
}