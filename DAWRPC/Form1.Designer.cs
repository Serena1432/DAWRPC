namespace DAWRPC
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.DAWName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProjectOpening = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CPUUsage = new System.Windows.Forms.Label();
            this.RAMUsage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DAW Detected:";
            // 
            // DAWName
            // 
            this.DAWName.AutoSize = true;
            this.DAWName.Location = new System.Drawing.Point(101, 9);
            this.DAWName.Name = "DAWName";
            this.DAWName.Size = new System.Drawing.Size(33, 13);
            this.DAWName.TabIndex = 1;
            this.DAWName.Text = "None";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Project opening:";
            // 
            // ProjectOpening
            // 
            this.ProjectOpening.AutoSize = true;
            this.ProjectOpening.Location = new System.Drawing.Point(101, 32);
            this.ProjectOpening.Name = "ProjectOpening";
            this.ProjectOpening.Size = new System.Drawing.Size(33, 13);
            this.ProjectOpening.TabIndex = 3;
            this.ProjectOpening.Text = "None";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(213, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "(C) 2021 Nico Levianth. All rights reserved.";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current CPU Usage:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Current RAM Usage:";
            // 
            // CPUUsage
            // 
            this.CPUUsage.AutoSize = true;
            this.CPUUsage.Location = new System.Drawing.Point(120, 55);
            this.CPUUsage.Name = "CPUUsage";
            this.CPUUsage.Size = new System.Drawing.Size(56, 13);
            this.CPUUsage.TabIndex = 7;
            this.CPUUsage.Text = "Undefined";
            // 
            // RAMUsage
            // 
            this.RAMUsage.AutoSize = true;
            this.RAMUsage.Location = new System.Drawing.Point(324, 55);
            this.RAMUsage.Name = "RAMUsage";
            this.RAMUsage.Size = new System.Drawing.Size(56, 13);
            this.RAMUsage.TabIndex = 8;
            this.RAMUsage.Text = "Undefined";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 104);
            this.Controls.Add(this.RAMUsage);
            this.Controls.Add(this.CPUUsage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ProjectOpening);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DAWName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DAW Discord Rich Presence";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label DAWName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ProjectOpening;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label CPUUsage;
        private System.Windows.Forms.Label RAMUsage;
    }
}

