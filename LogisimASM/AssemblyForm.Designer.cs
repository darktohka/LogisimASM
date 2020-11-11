namespace LogisimASM
{
    partial class AssemblyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AssemblyForm));
            this.downloadLabel = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.filenameBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.assembleButton = new System.Windows.Forms.Button();
            this.fileAssemblyBox = new System.Windows.Forms.TextBox();
            this.separatorLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputAssemblyBox = new System.Windows.Forms.TextBox();
            this.outputAssemblyBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.assembleTextButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.githubLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // downloadLabel
            // 
            this.downloadLabel.AutoSize = true;
            this.downloadLabel.Location = new System.Drawing.Point(12, 251);
            this.downloadLabel.Name = "downloadLabel";
            this.downloadLabel.Size = new System.Drawing.Size(139, 13);
            this.downloadLabel.TabIndex = 0;
            this.downloadLabel.TabStop = true;
            this.downloadLabel.Text = "Download CPU from GitHub";
            this.downloadLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.downloadLabel_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assemble/Disassemble file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Input filename:";
            // 
            // filenameBox
            // 
            this.filenameBox.Location = new System.Drawing.Point(15, 54);
            this.filenameBox.Name = "filenameBox";
            this.filenameBox.Size = new System.Drawing.Size(284, 20);
            this.filenameBox.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(305, 54);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(84, 20);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // assembleButton
            // 
            this.assembleButton.Enabled = false;
            this.assembleButton.Location = new System.Drawing.Point(15, 205);
            this.assembleButton.Name = "assembleButton";
            this.assembleButton.Size = new System.Drawing.Size(374, 28);
            this.assembleButton.TabIndex = 5;
            this.assembleButton.Text = "Assemble";
            this.assembleButton.UseVisualStyleBackColor = true;
            this.assembleButton.Click += new System.EventHandler(this.assembleButton_Click);
            // 
            // fileAssemblyBox
            // 
            this.fileAssemblyBox.Location = new System.Drawing.Point(15, 80);
            this.fileAssemblyBox.Multiline = true;
            this.fileAssemblyBox.Name = "fileAssemblyBox";
            this.fileAssemblyBox.ReadOnly = true;
            this.fileAssemblyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.fileAssemblyBox.Size = new System.Drawing.Size(374, 119);
            this.fileAssemblyBox.TabIndex = 6;
            // 
            // separatorLabel
            // 
            this.separatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separatorLabel.Location = new System.Drawing.Point(401, 0);
            this.separatorLabel.Name = "separatorLabel";
            this.separatorLabel.Size = new System.Drawing.Size(2, 242);
            this.separatorLabel.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(409, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Assemble/Disassemble text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Input:";
            // 
            // inputAssemblyBox
            // 
            this.inputAssemblyBox.Location = new System.Drawing.Point(414, 54);
            this.inputAssemblyBox.Multiline = true;
            this.inputAssemblyBox.Name = "inputAssemblyBox";
            this.inputAssemblyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputAssemblyBox.Size = new System.Drawing.Size(374, 145);
            this.inputAssemblyBox.TabIndex = 10;
            // 
            // outputAssemblyBox
            // 
            this.outputAssemblyBox.Location = new System.Drawing.Point(794, 54);
            this.outputAssemblyBox.Multiline = true;
            this.outputAssemblyBox.Name = "outputAssemblyBox";
            this.outputAssemblyBox.ReadOnly = true;
            this.outputAssemblyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputAssemblyBox.Size = new System.Drawing.Size(264, 179);
            this.outputAssemblyBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(791, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Output:";
            // 
            // assembleTextButton
            // 
            this.assembleTextButton.Location = new System.Drawing.Point(414, 205);
            this.assembleTextButton.Name = "assembleTextButton";
            this.assembleTextButton.Size = new System.Drawing.Size(374, 28);
            this.assembleTextButton.TabIndex = 13;
            this.assembleTextButton.Text = "Assemble";
            this.assembleTextButton.UseVisualStyleBackColor = true;
            this.assembleTextButton.Click += new System.EventHandler(this.assembleTextButton_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(0, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1080, 2);
            this.label6.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(876, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Written for Sapientia by";
            // 
            // githubLabel
            // 
            this.githubLabel.AutoSize = true;
            this.githubLabel.Location = new System.Drawing.Point(989, 251);
            this.githubLabel.Name = "githubLabel";
            this.githubLabel.Size = new System.Drawing.Size(69, 13);
            this.githubLabel.TabIndex = 16;
            this.githubLabel.TabStop = true;
            this.githubLabel.Text = "Derzsi Dániel";
            this.githubLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLabel_LinkClicked);
            // 
            // AssemblyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 274);
            this.Controls.Add(this.githubLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.assembleTextButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outputAssemblyBox);
            this.Controls.Add(this.inputAssemblyBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.separatorLabel);
            this.Controls.Add(this.fileAssemblyBox);
            this.Controls.Add(this.assembleButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.filenameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AssemblyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logisim 8-bit CPU Assembler";
            this.Load += new System.EventHandler(this.AssemblyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel downloadLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filenameBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button assembleButton;
        private System.Windows.Forms.TextBox fileAssemblyBox;
        private System.Windows.Forms.Label separatorLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputAssemblyBox;
        private System.Windows.Forms.TextBox outputAssemblyBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button assembleTextButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel githubLabel;
    }
}

