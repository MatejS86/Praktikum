using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Alvas.Audio;
using System.IO;
using System.Runtime.InteropServices;

namespace EffectsCs
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            ofdAudio.Filter = "*.wav|*.wav|*.mp3|*.mp3|*.avi|*.avi|*.wma;*.wmv;*.asf;*.mpg;*.aif;*.au;*.snd;*.mid;*.rmi;*.ogg;*.flac;*.cda;*.ac3;*.dts;*.mka;*.mkv;*.mpc;*.m4a;*.aac;*.mpa;*.mp2;*.m1a;*.m2a|*.wma;*.wmv;*.asf;*.mpg;*.aif;*.au;*.snd;*.mid;*.rmi;*.ogg;*.flac;*.cda;*.ac3;*.dts;*.mka;*.mkv;*.mpc;*.m4a;*.aac;*.mpa;*.mp2;*.m1a;*.m2a|*.*|*.*";
            btnPlay.Enabled = false;
            btnStop.Enabled = false;
        }

        PlayerEx plex = new PlayerEx();

        private void btnPlay_Click(object sender, EventArgs e)
        {
            AudioEffect af = null;
            foreach (Control ctrl in this.gbEffects.Controls)
            {
                RadioButton rb = ctrl as RadioButton;
                if (rb != null && rb.Checked)
                {
                    switch (rb.Text)
                    {
                        case "Chorus" :
                            af = AudioEffect.CreateChorusAudioEffect();
                            break;
                        case "Compressor":
                            af = AudioEffect.CreateCompressorAudioEffect();
                            break;
                        case "Distortion":
                            af = AudioEffect.CreateDistortionAudioEffect();
                            break;
                        case "Echo":
                            af = AudioEffect.CreateEchoAudioEffect();
                            break;
                        case "Flanger":
                            af = AudioEffect.CreateFlangerAudioEffect();
                            break;
                        case "Gargle":
                            af = AudioEffect.CreateGargleAudioEffect();
                            break;
                        case "I3DL2Reverb":
                            af = AudioEffect.CreateI3DL2ReverbAudioEffect();
                            break;
                        case "ParamEq":
                            af = AudioEffect.CreateParamEqAudioEffect();
                            break;
                        case "WavesReverb":
                            af = AudioEffect.CreateWavesReverbAudioEffect();
                            break;
                        default://None
                            break;
                    }
                    break;
                }
            }
            Play(arw, af);
            gbEffects.Enabled = false;
            btnPlay.Enabled = false;
            btnOpen.Enabled = false;
            btnStop.Enabled = true;
        }

        public void Play(IAudioReader wr, AudioEffect af)
        {
            //string fileName = @"c:\Wint\audio\NAudio-1-3\Source Code\MixDiff\bin\Debug\Windows XP Startup.wav";//1,16,8000.wav//G:\10\mp3\2,16,44100.wav
            //WaveReader wr = new WaveReader(File.OpenRead(fileName));
            IntPtr format = wr.ReadFormat();
            WaveFormat wf1 = AudioCompressionManager.GetWaveFormat(format);
            Console.WriteLine("{0},{1},{2}-{3}", wf1.nChannels, wf1.wBitsPerSample, wf1.nSamplesPerSec, wf1.wFormatTag);
            byte[] data = wr.ReadData();
            if (wf1.wFormatTag != 1)
            {
                IntPtr formatNew = IntPtr.Zero;
                byte[] dataNew = null;
                AudioCompressionManager.ToPcm(format, data, ref formatNew, ref dataNew);
                format = formatNew;
                data = dataNew;
                WaveFormat wf2 = AudioCompressionManager.GetWaveFormat(format);
                Console.WriteLine("{0},{1},{2}-{3}", wf2.nChannels, wf2.wBitsPerSample, wf2.nSamplesPerSec, wf2.wFormatTag);
            }
            else if (wf1.wBitsPerSample != 16)
            {
                WaveFormat wf = AudioCompressionManager.GetWaveFormat(format);
                IntPtr formatNew = AudioCompressionManager.GetPcmFormat(wf.nChannels, 16, wf.nSamplesPerSec);
                byte[] dataNew = AudioCompressionManager.Convert(format, formatNew, data, false);
                format = formatNew;
                data = dataNew;
                WaveFormat wf2 = AudioCompressionManager.GetWaveFormat(format);
                Console.WriteLine("{0},{1},{2}-{3}", wf2.nChannels, wf2.wBitsPerSample, wf2.nSamplesPerSec, wf2.wFormatTag);
            }
            //wr.Close();
            if (af != null)
            {
                bool hasProcessInPlace = af.HasProcessInPlace;
                //af.GetSupportedOutputFormats();
                GCHandle src = GCHandle.Alloc(data, GCHandleType.Pinned);
                IntPtr formatPtr = src.AddrOfPinnedObject();
                bool res = af.ProcessInPlace(format, data);
                src.Free();
                if (!res)
                {
                    MessageBox.Show("Unable to convert the audio data");
                    return;
                }
            }
            if (plex.State != DeviceState.Closed)
            {
                plex.ClosePlayer();
            }
            Console.WriteLine(plex.State);
            plex.OpenPlayer(format);
            plex.AddData(data);
            plex.StartPlay();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (plex.State != DeviceState.Closed)
            {
                plex.ClosePlayer();
            }
            gbEffects.Enabled = true;
            btnPlay.Enabled = true;
            btnOpen.Enabled = true;
            btnStop.Enabled = false;
            Console.WriteLine("{0} STOP", plex.State);
        }

        IAudioReader arw;

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ofdAudio.ShowDialog() == DialogResult.OK)
            {
                if (arw != null)
                {
                    arw.Close();
                    arw = null;
                }
                string fileName = ofdAudio.FileName;
                arw = null;
                switch (Path.GetExtension(fileName.ToLower()))
                {
                    case ".avi":
                        arw = new AviReader(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite));
                        if (!((AviReader)arw).HasAudio)
                        {
                            MessageBox.Show(string.Format("'{0}' file is not contains audio data", fileName));
                            return;
                        }
                        break;
                    case ".au":
                    case ".snd":
                        arw = new AuReader(File.OpenRead(fileName));
                        break;
                    case ".wav":
                        arw = new WaveReadWriter(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite));
                        break;
                    case ".mp3":
                        arw = new Mp3ReadWriter(File.Open(fileName, FileMode.Open, FileAccess.ReadWrite));
                        break;
                    default:
                        arw = new DsReader(fileName);
                        if (!((DsReader)arw).HasAudio)
                        {
                            arw = null;
                            MessageBox.Show(string.Format("'{0}' file is not contains audio data", fileName));
                        }
                        break;
                }
                btnPlay.Enabled = arw != null;
            }
        }

    }
}