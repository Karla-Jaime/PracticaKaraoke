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
            //Para añadir respuesta a eventos
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            pbCancion.Visibility = Visibility.Visible;
            reader = new AudioFileReader(reader.FileName();
            
            output = new WaveOut();

        }
    }
}
