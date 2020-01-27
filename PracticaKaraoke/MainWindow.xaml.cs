using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using System.Windows.Threading;

namespace PracticaKaraoke
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        AudioFileReader reader;
        WaveOut output;

        bool dragging = false;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            //para que recorra el slider
            if (!dragging)
            {
                pbCancion.Value = reader.CurrentTime.TotalSeconds;
            }


            if (pbCancion.Value >= 19 && pbCancion.Value <= 20)
            {
                txtLyrics.Text = "Something in me knew that it was real \nFrozen in my head \n Pictures I'm living through for now \nTrying to remember all the good times";
            }
            else if (pbCancion.Value >= 38 && pbCancion.Value <= 39)
            {
                txtLyrics.Text = "Our life was cutting through so loud\n Memories are playing in my dull mind\n I hate this part, paper hearts";
            }
            else if (pbCancion.Value >= 48 && pbCancion.Value <= 49)
            {
                txtLyrics.Text = "And I'll hold a piece of yours\n Don't think I would just forget about it\n Hoping that you won't forget about it";
            }
            else if (pbCancion.Value >= 59 && pbCancion.Value <= 60)
            {
                txtLyrics.Text = "Hoping that you won't forget about it";
            }
            else if (pbCancion.Value >= 76 && pbCancion.Value <= 77)
            {
                txtLyrics.Text = "Everything is gray under these skies\n Wet mascara Hiding every cloud under a smile  When there's cameras";
            }
            else if (pbCancion.Value >= 88 && pbCancion.Value <= 89)
            {
                txtLyrics.Text = "And I just can't reach out to tell you  \nThat I always wonder what you're up to";
            }
            else if (pbCancion.Value >= 104 && pbCancion.Value <=  105)
            {
                txtLyrics.Text = "Pictures I'm living through for now \n Trying to remember all the good times\n Our life was cutting through so loud \n Memories are playing in my dull mind";
            }
            else if (pbCancion.Value >= 117 && pbCancion.Value <= 118)
            {
                txtLyrics.Text = "I hate this part, paper hearts \n And I'll hold a piece of yours \n Don't think I would just forget about it \n Hoping that you won't forget";
            }
            else if (pbCancion.Value >= 134 && pbCancion.Value <= 135)
            {
                txtLyrics.Text = "I live through pictures as if \n I was right there by your side  \n But you'll be good without me and if \n I could just give it some time";
            }
            else if (pbCancion.Value >= 150 && pbCancion.Value <= 151)
            {
                txtLyrics.Text = "I'll be alright";
            }
            else if (pbCancion.Value >= 165 && pbCancion.Value <= 166)
            {
                txtLyrics.Text = "Pictures I'm living through for now \n Trying to remember all the good times\n Our life was cutting through so loud \n Memories are playing in my dull mind";
            }
            else if (pbCancion.Value >= 177 && pbCancion.Value <= 178)
            {
                txtLyrics.Text = "I hate this part, paper hearts \n And I'll hold a piece of yours \n Don't think I would just forget about it ";
            }
            else if (pbCancion.Value >= 181 && pbCancion.Value <= 182)
            {
                txtLyrics.Text = "\nn Hoping that you won't forget";
            }

        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            string File = @"Archivo/paper-hearts-official-video.mp3";
            reader = new AudioFileReader(File);
            output = new WaveOut();

            output.PlaybackStopped += Output_PlaybackStopped;
            output.Init(reader);
            output.Play();

            pbCancion.Maximum = reader.TotalTime.TotalSeconds;
            pbCancion.Value = reader.CurrentTime.TotalSeconds;
                        
            timer.Start();

        }

        private void Output_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            timer.Stop();

            reader.Dispose();
            output.Dispose();
        }

        private void PbCancion_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            dragging = true;
        }

        private void PbCancion_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            dragging = false;
            if (reader != null && output != null && output.PlaybackState != PlaybackState.Stopped)
            {
                reader.CurrentTime = TimeSpan.FromSeconds(pbCancion.Value);
            }
        }
    }  
}