using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Media;
using System.IO;
using System.Drawing.Drawing2D;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


namespace RazpoznavanjeMelodijePraktikum
{
   //[RunInstaller(true)]
    public partial class Form1 : Form
    {
        SoundPlayer posnetek;
        SaveFileDialog save;
        String datoteka;
        Graphics g;
        int sistem = 0;
        int st_sistemov = 1;
        int zamik = 70;
        string melodija = "";  //zapis not,pavz


        string[] ime_tona = { "G3", "A3", "H3", "C4", "D4", "E4", "F4", "G4", "A4", "H4", "C5", "D5", "E5", "F5", "G5", "A5", "H5", "C6" };
        float[] zamik_tona= {7f,6.5f,6f,5.5f,5f,4.5f,4f,3.5f,3f,2.5f,2f,1.5f,1f,0.5f,0f,-0.5f,-1f,-1.5f};
        
        //vrednosti za izpis not, pavz, crtovja
        private int _staffHght = 12;
        private int _noteHght = 12;
        private int _noteWdth = 18;
        private Pen _notePen = new Pen(Color.Black, 1);
        private Pen _notePen2 = new Pen(Color.Black, 4);
        private Brush _noteBrush = Brushes.Black;
        Bitmap bmp;
        
        
        public Form1()
        {
            InitializeComponent();
            save = new SaveFileDialog();

            bmp = new Bitmap(996, 513);
            g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);

        }

        //odpiranje datoteke
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
          
            ofd.Multiselect = true;
            ofd.Filter = "WAV Files .wav|*.wav";
            ofd.Multiselect = false;
  
            DialogResult ret = STAShowDialog(ofd);
            String pot = ofd.FileName;

            if (pot!="")
            {
                
                posnetek = new SoundPlayer(pot);
                bPredvajajP.Enabled = true;

                lImeP.Text = posnetek.SoundLocation;
                datoteka = posnetek.SoundLocation;
            }
        }

        //predvajanje datoteke
        private void button2_Click(object sender, EventArgs e)
        {
            if (posnetek!= null)
            {

                if (bPredvajajP.Text == "Predvajaj")
                {
                    posnetek.Play();
                    bPredvajajP.Text = "Stop";
                }
                else {
                    posnetek.Stop();
                    bPredvajajP.Text = "Predvajaj";
                }
            }
        }

        //za niti
        public class DialogState
        {   
            public DialogResult result;
            public FileDialog dialog;
 

            public void ThreadProcShowDialog()
            {
                result = dialog.ShowDialog();
            }
        }

        private DialogResult STAShowDialog(FileDialog dialog)
        {
            DialogState state = new DialogState();
            state.dialog = dialog;
            System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.Start();
            t.Join();
            return state.result;
        }
        
        //odpri zapis
        private void bOdpriZ_Click(object sender, EventArgs e)
        {
            brisiPrikaz();
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Zapis .rmz|*.rmz";
            open.Multiselect = false;


            DialogResult ret = STAShowDialog(open);
            if (ret == DialogResult.OK)
            {
                string file = open.FileName;
                datoteka = file;
                Form1.ActiveForm.Text = "Razpoznavanje Melodije :: " + datoteka;
                try
                {
                    string text = File.ReadAllText(file);
                    //MessageBox.Show(text);
                    melodija = text;
                    narisi();
                }
                catch (IOException)
                {
                }
            }
        }

        //shrani zapis
        private void bShraniZ_Click(object sender, EventArgs e)
        {
            if (melodija.Length != 0)
            {
                save.Filter = "Zapis .rmz|*.rmz";
                //  save.ShowDialog();
                Stream myStream;

                DialogResult ret = STAShowDialog(save);
                if (ret == DialogResult.OK)
                {
                    if ((myStream = save.OpenFile()) != null)
                    {
                        StreamWriter wText = new StreamWriter(myStream);

                        wText.Write(melodija);
                        wText.Flush();
                        myStream.Close();

                        datoteka = save.FileName;
                        Form1.ActiveForm.Text = "Razpoznavanje Melodije :: " + datoteka;
                    }
                }
            }
        }

       
        
       


        //testno risanje
        //
        //pripravim polje
        //berem iz datoteke
        //klicem funkcije za posamezne note,pavze
        
        
        // toni in pavze (celinka,polovinka,cetrtinka,osminka,sestnajstinka,32tinka)
        private void ton1(float x, float y)
        {
            y = y + sistem - 1;
            g.DrawEllipse(_notePen, x, y * _staffHght + zamik, _noteWdth, _noteHght);
        }

        private void ton2(float x, float y,bool gor)
        {
            y = y + sistem - 1;
            g.DrawEllipse(_notePen, x, y * _staffHght + zamik, _noteWdth, _noteHght);

            if (gor)
            {
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik + 8, x + 18, y * _staffHght + zamik - 48);
            }
            else
            {
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 8, x, y * _staffHght + zamik + 48);
            }
        }

        private void ton4(float x, float y, bool gor)
        {
            y = y + sistem - 1;
            g.FillEllipse(_noteBrush, x, y * _staffHght + zamik, _noteWdth, _noteHght);

            if (gor)
            {
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik + 8, x + 18, y * _staffHght + zamik - 48);
            }
            else
            {
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 8, x, y * _staffHght + zamik + 48);
            }
        }

        private void ton8(float x, float y,bool gor)
        {
            y = y + sistem - 1;
            g.FillEllipse(_noteBrush, x, y * _staffHght + zamik, _noteWdth, _noteHght);

            if (gor)
            {
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik + 8, x + 18, y * _staffHght + zamik - 40);
                g.DrawLine(_notePen, x + 16, y * _staffHght + zamik - 40, x + 30, y * _staffHght + zamik - 18);
            }
            else
            {
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 8, x, y * _staffHght + zamik + 48);
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 49, x + 14, y * _staffHght + zamik + 27);
            }
        }

        private void ton16(float x, float y, bool gor)
        {
            y = y + sistem - 1;
            g.FillEllipse(_noteBrush, x, y * _staffHght + zamik, _noteWdth, _noteHght);

            if (gor)
            {
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik + 8, x + 18, y * _staffHght + zamik - 40);
                g.DrawLine(_notePen, x + 16, y * _staffHght + zamik - 40, x + 30, y * _staffHght + zamik - 18);
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik - 30, x + 30, y * _staffHght + zamik -12);
            }
            else
            {
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 8, x, y * _staffHght + zamik + 48);
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 49, x + 14, y * _staffHght + zamik + 27);
                g.DrawLine(_notePen, x , y * _staffHght + zamik + 42, x + 14, y * _staffHght + zamik +21 );
            }
        }

        private void ton32(float x, float y, bool gor)
        {
            y = y + sistem - 1;
            g.FillEllipse(_noteBrush, x, y * _staffHght + zamik, _noteWdth, _noteHght);
            

            if (gor)
            {
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik + 8, x + 18, y * _staffHght + zamik - 40);
                g.DrawLine(_notePen, x + 16, y * _staffHght + zamik - 40, x + 30, y * _staffHght + zamik - 18);
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik - 30, x + 30, y * _staffHght + zamik - 12);
                g.DrawLine(_notePen, x + 18, y * _staffHght + zamik - 22, x + 30, y * _staffHght + zamik - 6);
            }
            else
            {
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 8, x, y * _staffHght + zamik + 48);
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 49, x + 14, y * _staffHght + zamik + 27);
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 42, x + 14, y * _staffHght + zamik + 21);
                g.DrawLine(_notePen, x, y * _staffHght + zamik + 35, x + 14, y * _staffHght + zamik + 15);
                

            }
        }


        private void pavza1(float x)
        {
            g.FillRectangle(_noteBrush, x, (2+sistem-1) * _staffHght + zamik-1, 18f, 5f);
        }

        private void pavza2(float x)
        {
            g.FillRectangle(_noteBrush, x, (2 + sistem - 1) * _staffHght + zamik + 7, 18f, 5f);
        }

        private void pavza4(float x)
        {
            g.DrawLine(_notePen, x, (2 + sistem - 1) * _staffHght + zamik - 4, x + 8,  (2 + sistem - 1) * _staffHght + zamik + 3);
            g.DrawLine(_notePen2, x + 8, (2 + sistem - 1) * _staffHght + zamik + 3, x, (2 + sistem - 1) * _staffHght + zamik + 12);
            g.DrawLine(_notePen, x, (2 + sistem - 1) * _staffHght + zamik + 12, x + 5, (2 + sistem - 1) * _staffHght + zamik + 18);
            g.DrawArc(_notePen2, x, (2 + sistem - 1) * _staffHght + zamik + 19, 8, 8, 115, 190);
        }

        private void pavza8(float x)
        {
            g.DrawArc(_notePen2, x, (2 + sistem - 1) * _staffHght + zamik + 6, 3, 3, 0, 360);
            g.DrawLine(_notePen, x + 4, (2 + sistem - 1) * _staffHght + zamik + 10, x + 18, (2 + sistem - 1) * _staffHght + zamik - 1);
            g.DrawLine(_notePen, x + 18, (2 + sistem - 1) * _staffHght + zamik - 1, x, (2 + sistem - 1) * _staffHght + zamik + 25);
        }

        private void visaj(float x,float y)
        {
            y = y + sistem-1;

            g.DrawLine(_notePen, x - 5, y * _staffHght + zamik -8, x - 5, y * _staffHght + zamik + 20);
            g.DrawLine(_notePen, x - 10, y * _staffHght + zamik -8, x - 10, y * _staffHght + zamik + 20);

            g.DrawLine(_notePen, x - 15, y * _staffHght + zamik + 5, x , y * _staffHght + zamik );
            g.DrawLine(_notePen, x - 15, y * _staffHght + zamik + 15, x , y * _staffHght + zamik +10);
        }

        private void podaljsaj(float x, float y)
        {
            y = y + sistem - 1;
            g.FillEllipse(_noteBrush, x + 25, y * _staffHght + zamik+3, 3, 3);
        }

        private void pomCrta(float x, float y)
        {
            float tmp = y;
            float ty = y;
          
            if (y >= 5.5f)
            {
                for (tmp = 6; tmp <= ty+0.5f; tmp++)
                {
                    y = tmp + sistem-1;
                    g.DrawLine(Pens.Black, x - 5, y * _staffHght + zamik, x + 23, y * _staffHght + zamik);
                }
            }



            if (y <= -0.5f)
            {
                for (tmp = 1f; tmp >= ty-0.5f;tmp--)
                {
                    y = tmp + sistem;
                    g.DrawLine(Pens.Black, x - 5, y * _staffHght + zamik , x + 23, y * _staffHght + zamik);                    
                }
            }
        }

        //notno crtovje
        private void melodijaPt()
        {
            sistem--;
            sistem = sistem * 12+1;
            for (int i = sistem; i < sistem + 5; i++)
            {
                g.DrawLine(Pens.Black, 0, i * _staffHght + zamik, melodijaP.Width, i * _staffHght + zamik);
            }
                
        }

        //narisi melodijo
        private void narisi()
        {
            try
            {
                int stTona=1;
                sistem = 1;
                melodijaPt();
                string[] toni = melodija.Split(';');

                foreach (string ton in toni)
                {
                    if (ton == "#")
                    {/* MessageBox.Show("Uspešno prebrana datoteka.", "OK");*/ }
                    else
                    {
                        string[] deliTon = ton.Split('-');
                        for (int i = 0; i < ime_tona.Length; i++)
                        {
                            if (deliTon[0] == ime_tona[i])
                            {

                                if (stTona >= 19) { st_sistemov++; sistem = st_sistemov; stTona = 1; melodijaPt(); }
                                bool gordol = false;
                                if (i > 7) { gordol = true; }

                                if (deliTon[1] == "1")
                                {
                                    ton1(stTona * 50, zamik_tona[i]); 
                                   
                                }
                                else if (deliTon[1] == "2")
                                {
                                    ton2(stTona * 50, zamik_tona[i], gordol); 
                                   
                                }
                                else if (deliTon[1] == "4")
                                {
                                    ton4(stTona * 50, zamik_tona[i], gordol); 
                                }
                                else if (deliTon[1] == "8")
                                {
                                    ton8(stTona * 50, zamik_tona[i], gordol); 
                                }
                                else if (deliTon[1] == "16")
                                {
                                    ton16(stTona * 50, zamik_tona[i], gordol); 
                                }
                                else if (deliTon[1] == "32")
                                {
                                    ton32(stTona * 50, zamik_tona[i], gordol); 
                                }

                                pomCrta(stTona * 50, zamik_tona[i]);
                                if (deliTon.Length > 2)
                                {
                                    if (deliTon[2].Contains('#'))
                                    {
                                        visaj(stTona * 50, zamik_tona[i]);
                                    }
                                    if (deliTon[2].Contains('.'))
                                    {
                                        podaljsaj(stTona * 50, zamik_tona[i]);
                                    }
                                }
                                i = 1000;
                                stTona++; 


                            }//pavze
                            else if (deliTon[0] == "p")
                            {
                                i = 1000;

                                if (stTona >= 19) { st_sistemov++; sistem = st_sistemov; stTona = 1; melodijaPt(); }

                                if (deliTon[1] == "1") { pavza1(stTona * 50); stTona++; }
                                else if (deliTon[1] == "2") { pavza2(stTona * 50); stTona++; }
                                else if (deliTon[1] == "4") { pavza4(stTona * 50); stTona++; }
                                else if (deliTon[1] == "8") { pavza8(stTona * 50); stTona++; }
                            }
                        }


                    }

                }
                melodijaP.Image = bmp;
            }
            catch (Exception e)
            {
                MessageBox.Show("Napaka v zapisu datoteke...");
            }
        }
/*
        private void button1_Click_1(object sender, EventArgs e)
        {
            brisiPrikaz();
            
            sistem = 1;
            melodijaPt();
            ton1(900, 5f);
            visaj(900, 1.5f);
            ton2(50, 2f,false);
            ton2(150, 2f, true);
            ton4(100, 3f,true);
            ton4(200, 3f, false);
            ton8(250, 3f, false);
            ton8(300, 3f, true);
            visaj(300, 3f);
            podaljsaj(300, 3f);
            ton16(350, 3f, true);
            ton16(400, 3f, false);
            ton32(450, 3f, true);
            ton32(500, 3f, false);
            pavza1(550);
            pavza2(600);
            pavza4(650);
            pavza8(700);
            ton1(750, 1.5f);
            visaj(750, 1.5f);
            pavza2(800);
            pavza2(850);
            ton1(900, 1.5f);
            visaj(900, 1.5f);

            sistem = 2;
            melodijaPt();
            ton1(900, 1.5f);
            visaj(900, 1.5f);
            pomCrta(200, -1f);
            pomCrta(200, 7f);
            ton1(200, 5.5f);
            ton2(200, -0.5f, false);
            ton2(50, -0.5f, false);
            ton2(150, 2f, true);
            ton4(100, 3f, true);
          
            ton8(250, 3f, false);
            ton8(300, 3f, true);
            visaj(300, 3f);
            ton16(350, 3f, true);
            ton16(400, 3f, false);
            pavza1(550);
            pavza2(600);
            pavza4(650);
            pavza8(700);
            

            sistem = 3;
            melodijaPt();
            visaj(550, 1f);
            ton32(550, 1f, true);
            ton1(900, 1.5f);
            visaj(900, 1.5f);
            ton2(50, 2f, false);
            ton2(150, 2f, true);
            ton4(100, 3f, true);
            ton4(200, 3f, false);
            ton8(250, 3f, false);
            ton8(300, 3f, true);
            visaj(300, 3f);
            ton16(350, 3f, true);
            ton16(400, 3f, false);
            pavza1(550);
            pavza2(600);
            pavza4(650);
            pavza8(700);

            sistem = 4;
            melodijaPt();
            ton1(900, 1.5f);
            visaj(900, 1.5f);
            ton2(50, 2f, false);
            ton2(150, 2f, true);
            ton4(100, 3f, true);
            ton4(200, 3f, false);
            ton8(250, 3f, false);
            ton8(300, 3f, true);
            visaj(300, 3f);
            ton16(350, 3f, true);
            ton16(400, 3f, false);


            melodijaP.Image = bmp;
        }*/


        //razpoznaj
        private void button2_Click_1(object sender, EventArgs e)
        {


            try
            {
                brisiPrikaz();
                Praktikium.Matlab razp = new Praktikium.Matlab();

                MWArray argin = datoteka;
                MWArray argout = new MWNumericArray();

                argout = razp.razpoznajMatlab(argin);

                //izhod
                MWNumericArray tmpArray = (MWNumericArray)argout;

                double[, ,] izhodnaMatrika = (double[, ,])tmpArray.ToArray(MWArrayComponent.Real);
                izhodnaMatrika[0, 0, 2] = izhodnaMatrika[0, 0, 2] + 1000;
                int[,] rezultat = new int[izhodnaMatrika.Length / 3, 3];
                for (int i = 0; i < izhodnaMatrika.Length / 3; i++)
                {
                    rezultat[i, 0] = Convert.ToInt32(izhodnaMatrika[i, 0, 0]);
                    rezultat[i, 1] = Convert.ToInt32(izhodnaMatrika[i, 0, 1]);
                    rezultat[i, 2] = Convert.ToInt32(izhodnaMatrika[i, 0, 2]);
                }

                String[] toni = { "A0", "Ais", "H0", "C1", "Cis1", "D1", "Dis1", "E1", "F1", "Fis1", "G1", "Gis1", "A1", "Ais1", "H1", "C2", "Cis2", "D2", "Dis2", "E2", "F2", "Fis2", "G2", "Gis2", "A2", "Ais2", "H2", "C3", "Cis3", "D3", "Dis3", "E3", "F3", "Fis3", "G3", "Gis3", "A3", "Ais3", "H3", "C4", "Cis4", "D4", "Dis4", "E4", "F4", "Fis4", "G4", "Gis4", "A4", "Ais4", "H4", "C5", "Cis5", "D5", "Dis5", "E5", "F5", "Fis5", "G5", "Gis5", "A5", "Ais5", "H5", "C6", "Cis6", "D6", "Dis6", "E6", "F6", "Fis6", "G6", "Gis6", "A6", "Ais6", "H6", "C7", "Cis7", "D7", "Dis7", "E7", "F7", "Fis7", "G7", "Gis7", "A7", "Ais7", "H7", "C8" };
                double[] frekvence = { 27.5000, 29.1352, 30.8677, 32.7032, 34.6478, 36.7081, 38.8909, 41.2034, 43.6535, 46.2493, 48.9994, 51.9131, 55.0000, 58.2705, 61.7354, 65.4064, 69.2957, 73.4162, 77.7817, 82.4069, 87.3071, 92.4986, 97.9989, 103.826, 110.000, 116.541, 123.471, 130.813, 138.591, 146.832, 155.563, 164.814, 174.614, 184.997, 195.998, 207.652, 220.000, 233.082, 246.942, 261.626, 277.183, 293.665, 311.127, 329.628, 349.228, 369.994, 391.995, 415.305, 440.000, 466.164, 493.883, 523.251, 554.365, 587.330, 622.254, 659.255, 698.456, 739.989, 783.991, 830.609, 880.000, 932.328, 987.767, 1046.50, 1108.73, 1174.66, 1244.51, 1318.51, 1396.91, 1479.98, 1567.98, 1661.22, 1760.00, 1864.66, 1975.53, 2093.00, 2217.46, 2349.32, 2489.02, 2637.02, 2793.83, 2959.96, 3135.96, 3322.44, 3520.00, 3729.31, 3951.07, 4186.01 };

                List<String> najdeniToni = new List<string>();
                List<int> dolzineTonov = new List<int>();
                int dolzinaCelotna = rezultat[0, 0];

                int najkrajsi = 1000000;
                int najdaljsi = 0;


                //polje za iskanje pavz
                int[] kjesopavze = new int[rezultat[0, 2]];
                for (int i = 0; i < kjesopavze.Length; i++)
                {
                    kjesopavze[i] = 0;
                }

                for (int i = 1; i < rezultat.Length / 3; i++)
                {

                    for (int j = rezultat[i, 1]; j < rezultat[i, 2]; j++)
                    {
                        kjesopavze[j] = 1;
                    }
                }

                List<List<double>> pavze = new List<List<double>>();

                bool zacF = false;
                int zac = 0;
                int kon = 0;
                for (int i = 0; i < kjesopavze.Length; i++)
                {
                    if (kjesopavze[i] == 0 && !zacF)
                    {
                        zac = 0;
                        kon = 0;
                        zac = i;
                        zacF = true;
                    }
                    if (kjesopavze[i] == 1 && zacF)
                    {
                        zacF = false;
                        kon = i;
                        List<double> lista = new List<double>();
                        lista.Add(zac);
                        lista.Add(kon);
                        pavze.Add(lista);
                    }
                }

                //dodam pavze - njihovo trajanje za kasnejsi rmz
                int ij = 0;
                for (int j = 1; j < rezultat.Length / 3; j++)
                {
                    if (rezultat[j, 1] > ij && j == 1)
                    {
                        najdeniToni.Add("p-");
                        dolzineTonov.Add(rezultat[j, 1]);
                        ij = rezultat[j, 1];
                    }
                    else if (rezultat[j, 1] > rezultat[j - 1, 2])
                    {
                        najdeniToni.Add("p-");
                        dolzineTonov.Add(rezultat[j, 1] - rezultat[j - 1, 2]);
                        ij = rezultat[j, 1];
                    }

                    if (rezultat[j, 1] <= ij) //smo v tonu
                    {
                        for (int k = 0; k < frekvence.Length; k++)
                        {
                            if (rezultat[j, 0] == Math.Round(frekvence[k], 0))
                            {
                                int trenutna = rezultat[j, 2] - rezultat[j, 1];
                                najdeniToni.Add(toni[k] + "-");
                                dolzineTonov.Add(trenutna);

                                if (trenutna < najkrajsi) { najkrajsi = trenutna; }
                                if (trenutna > najdaljsi) { najdaljsi = trenutna; }
                            }
                            ij = rezultat[j, 2];
                        }
                    }
                }


               
                //grem cez cel zapis in pisem tone in pavze 

                int celinka = najkrajsi * 4;

                //algoritem za postavljanje dob tonov
                List<List<double>> vseDobe = new List<List<double>>();
                for (int i = 0; i < dolzineTonov.Count; i++)
                {
                    List<double> dobe = new List<double>();
                    int dol = dolzineTonov[i];
                    int ost = 1;
                    int trenutno = celinka;
                    int tonTempo = 1;
                    for (int t = 0; t < 6; t++)
                    {
                        if (dol > 4000)
                        {
                            if (dol >= trenutno)
                            {
                                ost = dol / trenutno;

                                for (int j = 0; j < ost; j++)
                                {
                                    dobe.Add(tonTempo);
                                }
                                dol = dol - (ost * trenutno);
                            }
                            trenutno = trenutno / 2; //celinka->polovinka
                            tonTempo++;
                        }
                    }
                    vseDobe.Add(dobe);
                }

                //algoritem za izdelavo rmz zapisa
                //
                //vseDobe vsebujejo tempo
                //najdeniToni vsebujejo imena tonov
                //G3-4;A3-4;H3-4;C4-4;D4-4;G4-16;A4-1;p-4;D4-4;F4-8;p-1;

                for (int i = 0; i < najdeniToni.Count; i++)
                {
                    for (int j = 0; j < vseDobe[i].Count; j++)
                    {
                        double doba = vseDobe[i][j];
                        if (doba == 3) { doba = 4; }
                        else if (doba == 3) { doba = 4; }
                        else if (doba == 4) { doba = 8; }
                        else if (doba == 5) { doba = 16; }
                        else if (doba == 6) { doba = 32; }

                        melodija += najdeniToni[i] + doba + ";";
                    }
                }
                narisi();
            }
            catch (Exception er)
            {
                MessageBox.Show("Napaka pri iskanju frekvenc...");
            }
        }
        //brisi polje zapisov
        private void brisiPrikaz()
        {
            melodijaP.Image = null;
            g.Clear(Color.White) ;
        }      
        }
    }


