Imports Alvas.Audio
Imports System.IO
Imports System.Runtime.InteropServices

Public Class MainForm

    'Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click

    'End Sub

    'Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click

    'End Sub

    'Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click

    'End Sub

    Public Sub New()
        InitializeComponent()
        Init()
    End Sub

    Private Sub Init()
        ofdAudio.Filter = "*.wav|*.wav|*.mp3|*.mp3|*.avi|*.avi|*.wma;*.wmv;*.asf;*.mpg;*.aif;*.au;*.snd;*.mid;*.rmi;*.ogg;*.flac;*.cda;*.ac3;*.dts;*.mka;*.mkv;*.mpc;*.m4a;*.aac;*.mpa;*.mp2;*.m1a;*.m2a|*.wma;*.wmv;*.asf;*.mpg;*.aif;*.au;*.snd;*.mid;*.rmi;*.ogg;*.flac;*.cda;*.ac3;*.dts;*.mka;*.mkv;*.mpc;*.m4a;*.aac;*.mpa;*.mp2;*.m1a;*.m2a|*.*|*.*"
        btnPlay.Enabled = False
        btnStop.Enabled = False
    End Sub

    Private plex As New PlayerEx()

    Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPlay.Click
        Dim af As AudioEffect = Nothing
        For Each ctrl As Control In Me.gbEffects.Controls
            Dim rb As RadioButton = TryCast(ctrl, RadioButton)
            If rb IsNot Nothing AndAlso rb.Checked Then
                Select Case rb.Text
                    Case "Chorus"
                        af = AudioEffect.CreateChorusAudioEffect()
                        Exit Select
                    Case "Compressor"
                        af = AudioEffect.CreateCompressorAudioEffect()
                        Exit Select
                    Case "Distortion"
                        af = AudioEffect.CreateDistortionAudioEffect()
                        Exit Select
                    Case "Echo"
                        af = AudioEffect.CreateEchoAudioEffect()
                        Exit Select
                    Case "Flanger"
                        af = AudioEffect.CreateFlangerAudioEffect()
                        Exit Select
                    Case "Gargle"
                        af = AudioEffect.CreateGargleAudioEffect()
                        Exit Select
                    Case "I3DL2Reverb"
                        af = AudioEffect.CreateI3DL2ReverbAudioEffect()
                        Exit Select
                    Case "ParamEq"
                        af = AudioEffect.CreateParamEqAudioEffect()
                        Exit Select
                    Case "WavesReverb"
                        af = AudioEffect.CreateWavesReverbAudioEffect()
                        Exit Select
                    Case Else
                        'None
                        Exit Select
                End Select
                Exit For
            End If
        Next
        Play(arw, af)
        gbEffects.Enabled = False
        btnPlay.Enabled = False
        btnOpen.Enabled = False
        btnStop.Enabled = True
    End Sub

    Public Sub Play(ByVal wr As IAudioReader, ByVal af As AudioEffect)
        'string fileName = @"c:\Wint\audio\NAudio-1-3\Source Code\MixDiff\bin\Debug\Windows XP Startup.wav";//1,16,8000.wav//G:\10\mp3\2,16,44100.wav
        'WaveReader wr = new WaveReader(File.OpenRead(fileName));
        Dim format As IntPtr = wr.ReadFormat()
        Dim wf1 As WaveFormat = AudioCompressionManager.GetWaveFormat(format)
        Console.WriteLine("{0},{1},{2}-{3}", wf1.nChannels, wf1.wBitsPerSample, wf1.nSamplesPerSec, wf1.wFormatTag)
        Dim data As Byte() = wr.ReadData()
        If wf1.wFormatTag <> 1 Then
            Dim formatNew As IntPtr = IntPtr.Zero
            Dim dataNew As Byte() = Nothing
            AudioCompressionManager.ToPcm(format, data, formatNew, dataNew)
            format = formatNew
            data = dataNew
            Dim wf2 As WaveFormat = AudioCompressionManager.GetWaveFormat(format)
            Console.WriteLine("{0},{1},{2}-{3}", wf2.nChannels, wf2.wBitsPerSample, wf2.nSamplesPerSec, wf2.wFormatTag)
        ElseIf wf1.wBitsPerSample <> 16 Then
            Dim wf As WaveFormat = AudioCompressionManager.GetWaveFormat(format)
            Dim formatNew As IntPtr = AudioCompressionManager.GetPcmFormat(wf.nChannels, 16, wf.nSamplesPerSec)
            Dim dataNew As Byte() = AudioCompressionManager.Convert(format, formatNew, data, False)
            format = formatNew
            data = dataNew
            Dim wf2 As WaveFormat = AudioCompressionManager.GetWaveFormat(format)
            Console.WriteLine("{0},{1},{2}-{3}", wf2.nChannels, wf2.wBitsPerSample, wf2.nSamplesPerSec, wf2.wFormatTag)
        End If
        'wr.Close();
        If af IsNot Nothing Then
            Dim hasProcessInPlace As Boolean = af.HasProcessInPlace
            'af.GetSupportedOutputFormats();
            Dim src As GCHandle = GCHandle.Alloc(data, GCHandleType.Pinned)
            Dim formatPtr As IntPtr = src.AddrOfPinnedObject()
            Dim res As Boolean = af.ProcessInPlace(format, data)
            src.Free()
            If Not res Then
                MessageBox.Show("Unable to convert the audio data")
                Return
            End If
        End If
        If plex.State <> DeviceState.Closed Then
            plex.ClosePlayer()
        End If
        Console.WriteLine(plex.State)
        plex.OpenPlayer(format)
        plex.AddData(data)
        plex.StartPlay()
    End Sub

    Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStop.Click
        If plex.State <> DeviceState.Closed Then
            plex.ClosePlayer()
        End If
        gbEffects.Enabled = True
        btnPlay.Enabled = True
        btnOpen.Enabled = True
        btnStop.Enabled = False
        Console.WriteLine("{0} STOP", plex.State)
    End Sub

    Private arw As IAudioReader

    Private Sub btnOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOpen.Click
        If ofdAudio.ShowDialog() = DialogResult.OK Then
            If arw IsNot Nothing Then
                arw.Close()
                arw = Nothing
            End If
            Dim fileName As String = ofdAudio.FileName
            arw = Nothing
            Select Case Path.GetExtension(fileName.ToLower())
                Case ".au"
                Case ".snd"
                    arw = New AuReader(File.OpenRead(fileName))
                    Exit Select
                Case ".avi"
                    arw = New AviReader(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite))
                    If Not DirectCast(arw, AviReader).HasAudio Then
                        MessageBox.Show(String.Format("'{0}' file is not contains audio data", fileName))
                        Return
                    End If
                    Exit Select
                Case ".wav"
                    arw = New WaveReadWriter(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite))
                    Exit Select
                Case ".mp3"
                    arw = New Mp3ReadWriter(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite))
                    Exit Select
                Case Else
                    arw = New DsReader(fileName)
                    If Not DirectCast(arw, DsReader).HasAudio Then
                        arw = Nothing
                        MessageBox.Show(String.Format("'{0}' file is not contains audio data", fileName))
                    End If
                    Exit Select
            End Select
            btnPlay.Enabled = arw IsNot Nothing
        End If
    End Sub

End Class
