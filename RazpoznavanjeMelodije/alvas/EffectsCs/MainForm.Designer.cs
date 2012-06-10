namespace EffectsCs
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rbChorus = new System.Windows.Forms.RadioButton();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.rbDistortion = new System.Windows.Forms.RadioButton();
            this.rbCompressor = new System.Windows.Forms.RadioButton();
            this.rbEcho = new System.Windows.Forms.RadioButton();
            this.rbFlanger = new System.Windows.Forms.RadioButton();
            this.rbGargle = new System.Windows.Forms.RadioButton();
            this.rbI3DL2Rever = new System.Windows.Forms.RadioButton();
            this.rbParamEq = new System.Windows.Forms.RadioButton();
            this.rbWavesReverb = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.gbEffects = new System.Windows.Forms.GroupBox();
            this.ofdAudio = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.gbEffects.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbChorus
            // 
            this.rbChorus.AutoSize = true;
            this.rbChorus.Location = new System.Drawing.Point(16, 30);
            this.rbChorus.Name = "rbChorus";
            this.rbChorus.Size = new System.Drawing.Size(58, 17);
            this.rbChorus.TabIndex = 2;
            this.rbChorus.TabStop = true;
            this.rbChorus.Text = "Chorus";
            this.rbChorus.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(92, 183);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 12;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(173, 183);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // rbDistortion
            // 
            this.rbDistortion.AutoSize = true;
            this.rbDistortion.Location = new System.Drawing.Point(16, 53);
            this.rbDistortion.Name = "rbDistortion";
            this.rbDistortion.Size = new System.Drawing.Size(69, 17);
            this.rbDistortion.TabIndex = 4;
            this.rbDistortion.TabStop = true;
            this.rbDistortion.Text = "Distortion";
            this.rbDistortion.UseVisualStyleBackColor = true;
            // 
            // rbCompressor
            // 
            this.rbCompressor.AutoSize = true;
            this.rbCompressor.Location = new System.Drawing.Point(146, 30);
            this.rbCompressor.Name = "rbCompressor";
            this.rbCompressor.Size = new System.Drawing.Size(80, 17);
            this.rbCompressor.TabIndex = 3;
            this.rbCompressor.TabStop = true;
            this.rbCompressor.Text = "Compressor";
            this.rbCompressor.UseVisualStyleBackColor = true;
            // 
            // rbEcho
            // 
            this.rbEcho.AutoSize = true;
            this.rbEcho.Location = new System.Drawing.Point(146, 53);
            this.rbEcho.Name = "rbEcho";
            this.rbEcho.Size = new System.Drawing.Size(50, 17);
            this.rbEcho.TabIndex = 5;
            this.rbEcho.TabStop = true;
            this.rbEcho.Text = "Echo";
            this.rbEcho.UseVisualStyleBackColor = true;
            // 
            // rbFlanger
            // 
            this.rbFlanger.AutoSize = true;
            this.rbFlanger.Location = new System.Drawing.Point(16, 76);
            this.rbFlanger.Name = "rbFlanger";
            this.rbFlanger.Size = new System.Drawing.Size(60, 17);
            this.rbFlanger.TabIndex = 6;
            this.rbFlanger.TabStop = true;
            this.rbFlanger.Text = "Flanger";
            this.rbFlanger.UseVisualStyleBackColor = true;
            // 
            // rbGargle
            // 
            this.rbGargle.AutoSize = true;
            this.rbGargle.Location = new System.Drawing.Point(146, 76);
            this.rbGargle.Name = "rbGargle";
            this.rbGargle.Size = new System.Drawing.Size(56, 17);
            this.rbGargle.TabIndex = 7;
            this.rbGargle.TabStop = true;
            this.rbGargle.Text = "Gargle";
            this.rbGargle.UseVisualStyleBackColor = true;
            // 
            // rbI3DL2Rever
            // 
            this.rbI3DL2Rever.AutoSize = true;
            this.rbI3DL2Rever.Location = new System.Drawing.Point(16, 99);
            this.rbI3DL2Rever.Name = "rbI3DL2Rever";
            this.rbI3DL2Rever.Size = new System.Drawing.Size(83, 17);
            this.rbI3DL2Rever.TabIndex = 8;
            this.rbI3DL2Rever.TabStop = true;
            this.rbI3DL2Rever.Text = "I3DL2Rever";
            this.rbI3DL2Rever.UseVisualStyleBackColor = true;
            // 
            // rbParamEq
            // 
            this.rbParamEq.AutoSize = true;
            this.rbParamEq.Location = new System.Drawing.Point(146, 99);
            this.rbParamEq.Name = "rbParamEq";
            this.rbParamEq.Size = new System.Drawing.Size(68, 17);
            this.rbParamEq.TabIndex = 9;
            this.rbParamEq.TabStop = true;
            this.rbParamEq.Text = "ParamEq";
            this.rbParamEq.UseVisualStyleBackColor = true;
            // 
            // rbWavesReverb
            // 
            this.rbWavesReverb.AutoSize = true;
            this.rbWavesReverb.Location = new System.Drawing.Point(16, 122);
            this.rbWavesReverb.Name = "rbWavesReverb";
            this.rbWavesReverb.Size = new System.Drawing.Size(94, 17);
            this.rbWavesReverb.TabIndex = 10;
            this.rbWavesReverb.TabStop = true;
            this.rbWavesReverb.Text = "WavesReverb";
            this.rbWavesReverb.UseVisualStyleBackColor = true;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(146, 122);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 11;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // gbEffects
            // 
            this.gbEffects.Controls.Add(this.rbCompressor);
            this.gbEffects.Controls.Add(this.rbNone);
            this.gbEffects.Controls.Add(this.rbChorus);
            this.gbEffects.Controls.Add(this.rbWavesReverb);
            this.gbEffects.Controls.Add(this.rbDistortion);
            this.gbEffects.Controls.Add(this.rbParamEq);
            this.gbEffects.Controls.Add(this.rbEcho);
            this.gbEffects.Controls.Add(this.rbI3DL2Rever);
            this.gbEffects.Controls.Add(this.rbFlanger);
            this.gbEffects.Controls.Add(this.rbGargle);
            this.gbEffects.Location = new System.Drawing.Point(12, 12);
            this.gbEffects.Name = "gbEffects";
            this.gbEffects.Size = new System.Drawing.Size(236, 153);
            this.gbEffects.TabIndex = 0;
            this.gbEffects.TabStop = false;
            this.gbEffects.Text = "Effects";
            // 
            // ofdAudio
            // 
            this.ofdAudio.DefaultExt = "wav";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 183);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 14;
            this.btnOpen.Text = "Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 219);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.gbEffects);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Effects Sample";
            this.gbEffects.ResumeLayout(false);
            this.gbEffects.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbChorus;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RadioButton rbDistortion;
        private System.Windows.Forms.RadioButton rbCompressor;
        private System.Windows.Forms.RadioButton rbEcho;
        private System.Windows.Forms.RadioButton rbFlanger;
        private System.Windows.Forms.RadioButton rbGargle;
        private System.Windows.Forms.RadioButton rbI3DL2Rever;
        private System.Windows.Forms.RadioButton rbParamEq;
        private System.Windows.Forms.RadioButton rbWavesReverb;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.GroupBox gbEffects;
        private System.Windows.Forms.OpenFileDialog ofdAudio;
        private System.Windows.Forms.Button btnOpen;
    }
}

