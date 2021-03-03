

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace PinguGochi { 
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        int tiempo_vida = 0;
        double decremento = 10.0;


        //public object TimeMeasure { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            t1 = new DispatcherTimer();
            t1.Interval = TimeSpan.FromMilliseconds(1000.0);
            t1.Tick += new EventHandler(reloj);
            t1.Start();




        }

        private void puntuacionTiempoVida(object sender, EventArgs e)
        {
            if (prgBar_Alimento.Value < 100 || prgB_Cansancio.Value < 100 || prgB_Diversión.Value < 100)
            {

                tiempo_vida++;


            }
        }

        /// <summary>
        /// crear evento
        /// </summary>
        private void reloj(object sender, EventArgs e)
        {
            puntuacionTiempoVida(sender, e);
            this.prgBar_Alimento.Value -= decremento;
            this.prgB_Cansancio.Value -= decremento;
            this.prgB_Diversión.Value -= decremento;


            if (prgBar_Alimento.Value <= 0.0 || prgB_Cansancio.Value <= 0.0 || prgB_Diversión.Value <= 0.0)
            {

                t1.Stop();
                this.lbl_GameOver.Visibility = Visibility.Visible;
                this.lbl_tiempoVida.Visibility = Visibility.Visible;
                this.lbl_puntuacionJugador.Visibility = Visibility.Visible;

                this.btn_Alimentar.IsEnabled = false;
                this.btn_Descansar.IsEnabled = false;
                this.btn_divertir.IsEnabled = false;

                this.lbl_tiempoVida.Content = tiempo_vida;
                this.lbl_tiempoVida.Visibility = Visibility.Visible;





            }
        }

        private void btn_Alimentar_Click(object sender, RoutedEventArgs e)
        {
            this.prgBar_Alimento.Value += 5;
            decremento += 2;
        }

        private void btn_Descansar_Click(object sender, RoutedEventArgs e)
        {
            this.prgB_Cansancio.Value += 5;
            decremento += 2;
        }

        private void btn_divertir_Click(object sender, RoutedEventArgs e)
        {
            this.prgB_Diversión.Value += 5;
            decremento += 2;
        }

        /// metodo para cambair los colores a las barras de progreso segun esten a 15,25,50 y 100
        /* private void Cambio_colores(object sender, EventArgs e)
         {
             if (prgBar_Alimento.Value  == 50)
             {
                 //prgBar_Alimento.Foreground.

             }
         }*/
        /// <summary>
        /// instalar las 3 barras y calcular el tiempo que se juega : varieble q suma 
        /// </summary>








    }
}
