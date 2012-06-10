namespace RazpoznavanjeMelodijePraktikum
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
            this.bNaloziP = new System.Windows.Forms.Button();
            this.bPredvajajP = new System.Windows.Forms.Button();
            this.bOdpriZ = new System.Windows.Forms.Button();
            this.bShraniZ = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lImeP = new System.Windows.Forms.Label();
            this.melodijaP = new System.Windows.Forms.PictureBox();
            this.bRazpoznavanje = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.melodijaP)).BeginInit();
            this.SuspendLayout();
            // 
            // bNaloziP
            // 
            this.bNaloziP.Location = new System.Drawing.Point(69, 28);
            this.bNaloziP.Name = "bNaloziP";
            this.bNaloziP.Size = new System.Drawing.Size(118, 23);
            this.bNaloziP.TabIndex = 0;
            this.bNaloziP.Text = "Naloži posnetek";
            this.bNaloziP.UseVisualStyleBackColor = true;
            this.bNaloziP.Click += new System.EventHandler(this.button1_Click);
            // 
            // bPredvajajP
            // 
            this.bPredvajajP.Enabled = false;
            this.bPredvajajP.Location = new System.Drawing.Point(193, 28);
            this.bPredvajajP.Name = "bPredvajajP";
            this.bPredvajajP.Size = new System.Drawing.Size(75, 23);
            this.bPredvajajP.TabIndex = 1;
            this.bPredvajajP.Text = "Predvajaj";
            this.bPredvajajP.UseVisualStyleBackColor = true;
            this.bPredvajajP.Click += new System.EventHandler(this.button2_Click);
            // 
            // bOdpriZ
            // 
            this.bOdpriZ.Location = new System.Drawing.Point(863, 28);
            this.bOdpriZ.Name = "bOdpriZ";
            this.bOdpriZ.Size = new System.Drawing.Size(75, 23);
            this.bOdpriZ.TabIndex = 2;
            this.bOdpriZ.Text = "Odpri";
            this.bOdpriZ.UseVisualStyleBackColor = true;
            this.bOdpriZ.Click += new System.EventHandler(this.bOdpriZ_Click);
            // 
            // bShraniZ
            // 
            this.bShraniZ.Location = new System.Drawing.Point(944, 28);
            this.bShraniZ.Name = "bShraniZ";
            this.bShraniZ.Size = new System.Drawing.Size(75, 23);
            this.bShraniZ.TabIndex = 3;
            this.bShraniZ.Text = "Shrani";
            this.bShraniZ.UseVisualStyleBackColor = true;
            this.bShraniZ.Click += new System.EventHandler(this.bShraniZ_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(819, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Zapisi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Posnetki:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ime:";
            // 
            // lImeP
            // 
            this.lImeP.AutoSize = true;
            this.lImeP.Location = new System.Drawing.Point(307, 33);
            this.lImeP.Name = "lImeP";
            this.lImeP.Size = new System.Drawing.Size(0, 13);
            this.lImeP.TabIndex = 8;
            // 
            // melodijaP
            // 
            this.melodijaP.BackColor = System.Drawing.Color.White;
            this.melodijaP.Location = new System.Drawing.Point(22, 76);
            this.melodijaP.Name = "melodijaP";
            this.melodijaP.Size = new System.Drawing.Size(996, 513);
            this.melodijaP.TabIndex = 11;
            this.melodijaP.TabStop = false;
            // 
            // bRazpoznavanje
            // 
            this.bRazpoznavanje.Location = new System.Drawing.Point(437, 595);
            this.bRazpoznavanje.Name = "bRazpoznavanje";
            this.bRazpoznavanje.Size = new System.Drawing.Size(179, 34);
            this.bRazpoznavanje.TabIndex = 12;
            this.bRazpoznavanje.Text = "Razpoznavanje";
            this.bRazpoznavanje.UseVisualStyleBackColor = true;
            this.bRazpoznavanje.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 641);
            this.Controls.Add(this.bRazpoznavanje);
            this.Controls.Add(this.melodijaP);
            this.Controls.Add(this.lImeP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bShraniZ);
            this.Controls.Add(this.bOdpriZ);
            this.Controls.Add(this.bPredvajajP);
            this.Controls.Add(this.bNaloziP);
            this.Name = "Form1";
            this.Text = "Razpoznavanje Melodije";
            ((System.ComponentModel.ISupportInitialize)(this.melodijaP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bNaloziP;
        private System.Windows.Forms.Button bPredvajajP;
        private System.Windows.Forms.Button bOdpriZ;
        private System.Windows.Forms.Button bShraniZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lImeP;
        private System.Windows.Forms.PictureBox melodijaP;
        private System.Windows.Forms.Button bRazpoznavanje;
    }
}

