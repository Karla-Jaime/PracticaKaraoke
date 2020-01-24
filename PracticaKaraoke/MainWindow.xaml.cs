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
