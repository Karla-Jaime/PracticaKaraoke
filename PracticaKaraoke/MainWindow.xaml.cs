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
        DispatcherTimer timer; //intervalos de tiempo
        //LeerArchivo
        AudioFileReader reader;
        //ComunicaciónConLaTarjetaDeAudio

        //ExclusivoParaSalida
        WaveOut output;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            Duration duration = new Duration(TimeSpan.FromSeconds(10));
            //Para añadir respuesta a eventos
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (reader.CurrentTime == TimeSpan.FromSeconds(0.19))
            {
                txtLyrics.Text = "Something in me knew that it was real Frozen in my head Pictures I'm living through for now Trying to remember all the good times";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(0.38))
            {
                txtLyrics.Text = "Our life was cutting through so loud Memories are playing in my dull mind I hate this part, paper hearts";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(48))
            {
                txtLyrics.Text = "And I'll hold a piece of yours Don't think I would just forget about it Hoping that you won't forget about it";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(59))
            {
                txtLyrics.Text = "Hoping that you won't forget about it";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(76))
            {
                txtLyrics.Text = "Everything is gray under these skies Wet mascara Hiding every cloud under a smile  When there's cameras";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(89))
            {
                txtLyrics.Text = "And I just can't reach out to tell you  That I always wonder what you're up to";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(104))
            {
                txtLyrics.Text = "Pictures I'm living through for now /n Trying to remember all the good times/n Our life was cutting through so loud /n Memories are playing in my dull mind";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(117))
            {
                txtLyrics.Text = "I hate this part, paper hearts /n And I'll hold a piece of yours /n Don't think I would just forget about it /n Hoping that you won't forget";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(134))
            {
                txtLyrics.Text = "I live through pictures as if /n I was right there by your side  /nBut you'll be good without me and if /n I could just give it some time";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(150))
            {
                txtLyrics.Text = "I'll be alright";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(165))
            {
                txtLyrics.Text = "Pictures I'm living through for now /n Trying to remember all the good times/n Our life was cutting through so loud /n Memories are playing in my dull mind";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(178))
            {
                txtLyrics.Text = "I hate this part, paper hearts /n And I'll hold a piece of yours /n Don't think I would just forget about it ";
            }
            else if (reader.CurrentTime == TimeSpan.FromSeconds(150))
            {
                txtLyrics.Text = "/n Hoping that you won't forget";
            }
        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            pbCancion.Visibility = Visibility.Visible;
            string File = @"paper-hearts-official-video.mp3";
            reader = new AudioFileReader(File);
            output.Init(reader);
            output.Play();

           

           // pbCancion.Value = 

        }

    }
}
