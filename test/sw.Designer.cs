namespace test
{
    partial class sw
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sw));
            this.panel1 = new System.Windows.Forms.Panel();
            this.swlabel = new System.Windows.Forms.Label();
            this.swStart = new System.Windows.Forms.Button();
            this.swStop = new System.Windows.Forms.Button();
            this.swReset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.swlabel);
            this.panel1.Location = new System.Drawing.Point(12, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 163);
            this.panel1.TabIndex = 0;
            // 
            // swlabel
            // 
            this.swlabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.swlabel.AutoSize = true;
            this.swlabel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.swlabel.Font = new System.Drawing.Font("LCDMono2", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swlabel.Location = new System.Drawing.Point(210, 40);
            this.swlabel.Name = "swlabel";
            this.swlabel.Size = new System.Drawing.Size(453, 86);
            this.swlabel.TabIndex = 1;
            this.swlabel.Text = "00:00:00";
            // 
            // swStart
            // 
            this.swStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.swStart.BackColor = System.Drawing.Color.Green;
            this.swStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swStart.Location = new System.Drawing.Point(217, 382);
            this.swStart.Name = "swStart";
            this.swStart.Size = new System.Drawing.Size(104, 49);
            this.swStart.TabIndex = 1;
            this.swStart.Text = "Start";
            this.swStart.UseVisualStyleBackColor = false;
            this.swStart.Click += new System.EventHandler(this.swStart_Click);
            // 
            // swStop
            // 
            this.swStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.swStop.BackColor = System.Drawing.Color.Red;
            this.swStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swStop.Location = new System.Drawing.Point(381, 382);
            this.swStop.Name = "swStop";
            this.swStop.Size = new System.Drawing.Size(104, 49);
            this.swStop.TabIndex = 2;
            this.swStop.Text = "Stop";
            this.swStop.UseVisualStyleBackColor = false;
            this.swStop.Click += new System.EventHandler(this.swStop_Click);
            // 
            // swReset
            // 
            this.swReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.swReset.BackColor = System.Drawing.Color.SteelBlue;
            this.swReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swReset.Location = new System.Drawing.Point(545, 382);
            this.swReset.Name = "swReset";
            this.swReset.Size = new System.Drawing.Size(104, 49);
            this.swReset.TabIndex = 3;
            this.swReset.Text = "Reset";
            this.swReset.UseVisualStyleBackColor = false;
            this.swReset.Click += new System.EventHandler(this.swReset_Click);
            // 
            // sw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 527);
            this.Controls.Add(this.swReset);
            this.Controls.Add(this.swStop);
            this.Controls.Add(this.swStart);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "sw";
            this.Text = "Stop Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sw_FormClosing);
            this.Load += new System.EventHandler(this.sw_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label swlabel;
        private System.Windows.Forms.Button swStart;
        private System.Windows.Forms.Button swStop;
        private System.Windows.Forms.Button swReset;
    }
}