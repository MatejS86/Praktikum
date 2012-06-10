<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ofdAudio = New System.Windows.Forms.OpenFileDialog
        Me.rbCompressor = New System.Windows.Forms.RadioButton
        Me.rbNone = New System.Windows.Forms.RadioButton
        Me.gbEffects = New System.Windows.Forms.GroupBox
        Me.rbChorus = New System.Windows.Forms.RadioButton
        Me.rbWavesReverb = New System.Windows.Forms.RadioButton
        Me.rbDistortion = New System.Windows.Forms.RadioButton
        Me.rbParamEq = New System.Windows.Forms.RadioButton
        Me.rbEcho = New System.Windows.Forms.RadioButton
        Me.rbI3DL2Rever = New System.Windows.Forms.RadioButton
        Me.rbFlanger = New System.Windows.Forms.RadioButton
        Me.rbGargle = New System.Windows.Forms.RadioButton
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnPlay = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.gbEffects.SuspendLayout()
        Me.SuspendLayout()
        '
        'ofdAudio
        '
        Me.ofdAudio.DefaultExt = "wav"
        '
        'rbCompressor
        '
        Me.rbCompressor.AutoSize = True
        Me.rbCompressor.Location = New System.Drawing.Point(146, 30)
        Me.rbCompressor.Name = "rbCompressor"
        Me.rbCompressor.Size = New System.Drawing.Size(80, 17)
        Me.rbCompressor.TabIndex = 3
        Me.rbCompressor.TabStop = True
        Me.rbCompressor.Text = "Compressor"
        Me.rbCompressor.UseVisualStyleBackColor = True
        '
        'rbNone
        '
        Me.rbNone.AutoSize = True
        Me.rbNone.Location = New System.Drawing.Point(146, 122)
        Me.rbNone.Name = "rbNone"
        Me.rbNone.Size = New System.Drawing.Size(51, 17)
        Me.rbNone.TabIndex = 11
        Me.rbNone.TabStop = True
        Me.rbNone.Text = "None"
        Me.rbNone.UseVisualStyleBackColor = True
        '
        'gbEffects
        '
        Me.gbEffects.Controls.Add(Me.rbCompressor)
        Me.gbEffects.Controls.Add(Me.rbNone)
        Me.gbEffects.Controls.Add(Me.rbChorus)
        Me.gbEffects.Controls.Add(Me.rbWavesReverb)
        Me.gbEffects.Controls.Add(Me.rbDistortion)
        Me.gbEffects.Controls.Add(Me.rbParamEq)
        Me.gbEffects.Controls.Add(Me.rbEcho)
        Me.gbEffects.Controls.Add(Me.rbI3DL2Rever)
        Me.gbEffects.Controls.Add(Me.rbFlanger)
        Me.gbEffects.Controls.Add(Me.rbGargle)
        Me.gbEffects.Location = New System.Drawing.Point(12, 12)
        Me.gbEffects.Name = "gbEffects"
        Me.gbEffects.Size = New System.Drawing.Size(236, 153)
        Me.gbEffects.TabIndex = 15
        Me.gbEffects.TabStop = False
        Me.gbEffects.Text = "Effects"
        '
        'rbChorus
        '
        Me.rbChorus.AutoSize = True
        Me.rbChorus.Location = New System.Drawing.Point(16, 30)
        Me.rbChorus.Name = "rbChorus"
        Me.rbChorus.Size = New System.Drawing.Size(58, 17)
        Me.rbChorus.TabIndex = 2
        Me.rbChorus.TabStop = True
        Me.rbChorus.Text = "Chorus"
        Me.rbChorus.UseVisualStyleBackColor = True
        '
        'rbWavesReverb
        '
        Me.rbWavesReverb.AutoSize = True
        Me.rbWavesReverb.Location = New System.Drawing.Point(16, 122)
        Me.rbWavesReverb.Name = "rbWavesReverb"
        Me.rbWavesReverb.Size = New System.Drawing.Size(94, 17)
        Me.rbWavesReverb.TabIndex = 10
        Me.rbWavesReverb.TabStop = True
        Me.rbWavesReverb.Text = "WavesReverb"
        Me.rbWavesReverb.UseVisualStyleBackColor = True
        '
        'rbDistortion
        '
        Me.rbDistortion.AutoSize = True
        Me.rbDistortion.Location = New System.Drawing.Point(16, 53)
        Me.rbDistortion.Name = "rbDistortion"
        Me.rbDistortion.Size = New System.Drawing.Size(69, 17)
        Me.rbDistortion.TabIndex = 4
        Me.rbDistortion.TabStop = True
        Me.rbDistortion.Text = "Distortion"
        Me.rbDistortion.UseVisualStyleBackColor = True
        '
        'rbParamEq
        '
        Me.rbParamEq.AutoSize = True
        Me.rbParamEq.Location = New System.Drawing.Point(146, 99)
        Me.rbParamEq.Name = "rbParamEq"
        Me.rbParamEq.Size = New System.Drawing.Size(68, 17)
        Me.rbParamEq.TabIndex = 9
        Me.rbParamEq.TabStop = True
        Me.rbParamEq.Text = "ParamEq"
        Me.rbParamEq.UseVisualStyleBackColor = True
        '
        'rbEcho
        '
        Me.rbEcho.AutoSize = True
        Me.rbEcho.Location = New System.Drawing.Point(146, 53)
        Me.rbEcho.Name = "rbEcho"
        Me.rbEcho.Size = New System.Drawing.Size(50, 17)
        Me.rbEcho.TabIndex = 5
        Me.rbEcho.TabStop = True
        Me.rbEcho.Text = "Echo"
        Me.rbEcho.UseVisualStyleBackColor = True
        '
        'rbI3DL2Rever
        '
        Me.rbI3DL2Rever.AutoSize = True
        Me.rbI3DL2Rever.Location = New System.Drawing.Point(16, 99)
        Me.rbI3DL2Rever.Name = "rbI3DL2Rever"
        Me.rbI3DL2Rever.Size = New System.Drawing.Size(83, 17)
        Me.rbI3DL2Rever.TabIndex = 8
        Me.rbI3DL2Rever.TabStop = True
        Me.rbI3DL2Rever.Text = "I3DL2Rever"
        Me.rbI3DL2Rever.UseVisualStyleBackColor = True
        '
        'rbFlanger
        '
        Me.rbFlanger.AutoSize = True
        Me.rbFlanger.Location = New System.Drawing.Point(16, 76)
        Me.rbFlanger.Name = "rbFlanger"
        Me.rbFlanger.Size = New System.Drawing.Size(60, 17)
        Me.rbFlanger.TabIndex = 6
        Me.rbFlanger.TabStop = True
        Me.rbFlanger.Text = "Flanger"
        Me.rbFlanger.UseVisualStyleBackColor = True
        '
        'rbGargle
        '
        Me.rbGargle.AutoSize = True
        Me.rbGargle.Location = New System.Drawing.Point(146, 76)
        Me.rbGargle.Name = "rbGargle"
        Me.rbGargle.Size = New System.Drawing.Size(56, 17)
        Me.rbGargle.TabIndex = 7
        Me.rbGargle.TabStop = True
        Me.rbGargle.Text = "Gargle"
        Me.rbGargle.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(173, 183)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 17
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(92, 183)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(75, 23)
        Me.btnPlay.TabIndex = 16
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(12, 183)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 18
        Me.btnOpen.Text = "Open..."
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 219)
        Me.Controls.Add(Me.gbEffects)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.btnOpen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.Text = "Effects Sample"
        Me.gbEffects.ResumeLayout(False)
        Me.gbEffects.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ofdAudio As System.Windows.Forms.OpenFileDialog
    Private WithEvents rbCompressor As System.Windows.Forms.RadioButton
    Private WithEvents rbNone As System.Windows.Forms.RadioButton
    Private WithEvents gbEffects As System.Windows.Forms.GroupBox
    Private WithEvents rbChorus As System.Windows.Forms.RadioButton
    Private WithEvents rbWavesReverb As System.Windows.Forms.RadioButton
    Private WithEvents rbDistortion As System.Windows.Forms.RadioButton
    Private WithEvents rbParamEq As System.Windows.Forms.RadioButton
    Private WithEvents rbEcho As System.Windows.Forms.RadioButton
    Private WithEvents rbI3DL2Rever As System.Windows.Forms.RadioButton
    Private WithEvents rbFlanger As System.Windows.Forms.RadioButton
    Private WithEvents rbGargle As System.Windows.Forms.RadioButton
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents btnPlay As System.Windows.Forms.Button
    Private WithEvents btnOpen As System.Windows.Forms.Button

End Class
