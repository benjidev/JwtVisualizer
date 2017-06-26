namespace JwtVisualizer
{
    partial class JwtForm
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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRaw = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtUnEncoded = new System.Windows.Forms.TextBox();
            this.chkPretty = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.results = new System.Windows.Forms.TextBox();
            this.txtCert = new System.Windows.Forms.TextBox();
            this.Tabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.tabPage1);
            this.Tabs.Controls.Add(this.tabPage2);
            this.Tabs.Controls.Add(this.tabPage3);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1173, 809);
            this.Tabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRaw);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage1.Size = new System.Drawing.Size(1165, 765);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Raw";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRaw
            // 
            this.txtRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRaw.Location = new System.Drawing.Point(10, 10);
            this.txtRaw.Multiline = true;
            this.txtRaw.Name = "txtRaw";
            this.txtRaw.ReadOnly = true;
            this.txtRaw.Size = new System.Drawing.Size(1145, 745);
            this.txtRaw.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtUnEncoded);
            this.tabPage2.Controls.Add(this.chkPretty);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1165, 765);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Decoded";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtUnEncoded
            // 
            this.txtUnEncoded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnEncoded.Location = new System.Drawing.Point(8, 48);
            this.txtUnEncoded.Multiline = true;
            this.txtUnEncoded.Name = "txtUnEncoded";
            this.txtUnEncoded.ReadOnly = true;
            this.txtUnEncoded.Size = new System.Drawing.Size(1149, 709);
            this.txtUnEncoded.TabIndex = 1;
            // 
            // chkPretty
            // 
            this.chkPretty.AutoSize = true;
            this.chkPretty.Checked = true;
            this.chkPretty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPretty.Location = new System.Drawing.Point(8, 6);
            this.chkPretty.Name = "chkPretty";
            this.chkPretty.Size = new System.Drawing.Size(128, 36);
            this.chkPretty.TabIndex = 0;
            this.chkPretty.Text = "Pretty";
            this.chkPretty.UseVisualStyleBackColor = true;
            this.chkPretty.CheckedChanged += new System.EventHandler(this.chkPretty_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.results);
            this.tabPage3.Controls.Add(this.txtCert);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1165, 765);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Signature Verify";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // results
            // 
            this.results.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.results.Location = new System.Drawing.Point(6, 386);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(1151, 371);
            this.results.TabIndex = 1;
            this.results.Text = "Results";
            // 
            // txtCert
            // 
            this.txtCert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCert.Location = new System.Drawing.Point(8, 15);
            this.txtCert.Multiline = true;
            this.txtCert.Name = "txtCert";
            this.txtCert.Size = new System.Drawing.Size(1149, 365);
            this.txtCert.TabIndex = 0;
            this.txtCert.Text = "Enter certificate here";
            this.txtCert.TextChanged += new System.EventHandler(this.txtCert_TextChanged);
            // 
            // JwtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 809);
            this.Controls.Add(this.Tabs);
            this.Name = "JwtForm";
            this.Text = "JWT Visualizer";
            this.Load += new System.EventHandler(this.JwtForm_Load_1);
            this.Tabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtRaw;
        private System.Windows.Forms.CheckBox chkPretty;
        private System.Windows.Forms.TextBox txtUnEncoded;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.TextBox txtCert;
    }
}