

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        double decremento = 5.0;


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
                this.tumba.Visibility = Visibility.Visible;
                this.muerte.Visibility = Visibility.Visible;
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

            btn_Alimentar.IsEnabled = false;
            comerLogo.Visibility = Visibility.Visible;

            DoubleAnimation comer = new DoubleAnimation();
            comer.From = 15;
            comer.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            comer.AutoReverse = true;
            comer.Completed += new EventHandler(finComer);

            pico.BeginAnimation(Ellipse.HeightProperty, comer);

            DoubleAnimation comerBracitoMoviendo = new DoubleAnimation();
            comerBracitoMoviendo.From = 20;
            comerBracitoMoviendo.Duration = new Duration(TimeSpan.FromSeconds(1));
            comerBracitoMoviendo.AutoReverse = true;
            comerBracitoMoviendo.Completed += new EventHandler(finComer);

            onomatopeyaComiendo.Visibility = Visibility.Visible;

            brazoDerecha.BeginAnimation(Ellipse.HeightProperty, comerBracitoMoviendo);
            brazoIzq.BeginAnimation(Ellipse.HeightProperty, comerBracitoMoviendo);
            pez.Visibility = Visibility.Visible;
                ;


        }

        private void btn_Descansar_Click(object sender, RoutedEventArgs e)
        {
            this.prgB_Cansancio.Value += 5;
            decremento += 2;


            btn_Descansar.IsEnabled = false;

            pataDerechaOso.Visibility = Visibility.Visible;
            cuerpoOso.Visibility = Visibility.Visible;
            manoIzqOso.Visibility = Visibility.Visible;
            barrigaOso.Visibility = Visibility.Visible;
            ocicoOso.Visibility = Visibility.Visible;
            narizOso.Visibility = Visibility.Visible;
            pupilaDechOso.Visibility = Visibility.Visible;
            PupilaIzqOso.Visibility = Visibility.Visible;
            ojoDechOso.Visibility = Visibility.Visible;
            ojoIzqOso.Visibility = Visibility.Visible;
            orejasOso.Visibility = Visibility.Visible;
            miniOrejasOso.Visibility = Visibility.Visible;
            pataIzqOso.Visibility = Visibility.Visible;
            gorroDormir.Visibility = Visibility.Visible;
            cascoAuricular.Visibility = Visibility.Hidden;
            auricularesLados.Visibility = Visibility.Hidden;

            DoubleAnimation cerrarOjoDerecho = new DoubleAnimation();
            cerrarOjoDerecho.To = 5;
            cerrarOjoDerecho.Duration = new Duration(TimeSpan.FromSeconds(1));
            cerrarOjoDerecho.AutoReverse = true;
            cerrarOjoDerecho.Completed += new EventHandler(finCerrarOjoDer);

            DoubleAnimation cerrarOjoIzquierdo = new DoubleAnimation();
            cerrarOjoIzquierdo.To = 5;
            cerrarOjoIzquierdo.Duration = new Duration(TimeSpan.FromSeconds(1));
            cerrarOjoIzquierdo.AutoReverse = true;

            DoubleAnimation cerrarPupila = new DoubleAnimation();
            cerrarPupila.To = 3;
            cerrarPupila.Duration = new Duration(TimeSpan.FromSeconds(1));
            cerrarPupila.AutoReverse = true;
            cerrarPupila.Completed += new EventHandler(finCerrarOjoDer);
            dormirLogo.Visibility = Visibility.Visible;


            FondoOjoDerecho.BeginAnimation(Ellipse.HeightProperty, cerrarOjoDerecho);
            FondoOjoIzquierdo.BeginAnimation(Ellipse.HeightProperty, cerrarOjoIzquierdo);


            pupilaDerecha.BeginAnimation(Ellipse.HeightProperty, cerrarPupila);
            pupilaIzquierda.BeginAnimation(Ellipse.HeightProperty, cerrarPupila);


        }

        private void finCerrarOjoDer(object sender , EventArgs e)
        {
            btn_Descansar.IsEnabled = true;
            dormirLogo.Visibility = Visibility.Hidden;
            pataDerechaOso.Visibility = Visibility.Hidden;
            cuerpoOso.Visibility = Visibility.Hidden;
            manoIzqOso.Visibility = Visibility.Hidden;
            barrigaOso.Visibility = Visibility.Hidden;
            ocicoOso.Visibility = Visibility.Hidden;
            narizOso.Visibility = Visibility.Hidden;
            pupilaDechOso.Visibility = Visibility.Hidden;
            PupilaIzqOso.Visibility = Visibility.Hidden;
            ojoDechOso.Visibility = Visibility.Hidden;
            ojoIzqOso.Visibility = Visibility.Hidden;
            orejasOso.Visibility = Visibility.Hidden;
            miniOrejasOso.Visibility = Visibility.Hidden;
            pataIzqOso.Visibility = Visibility.Hidden;

            gorroDormir.Visibility = Visibility.Hidden;
            cascoAuricular.Visibility = Visibility.Visible;
            auricularesLados.Visibility = Visibility.Visible;
        }

        private void finComer(object sender, EventArgs e)
        {
            btn_Alimentar.IsEnabled = true;
            onomatopeyaComiendo.Visibility = Visibility.Hidden;
            comerLogo.Visibility = Visibility.Hidden;
            pez.Visibility = Visibility.Hidden;
           
        }







        private void btn_divertir_Click(object sender, RoutedEventArgs e)
        {
            this.prgB_Diversión.Value += 5;
            decremento += 2;
        }

        private void cambiarFondo(object sender, MouseButtonEventArgs e)
        {
            this.img_bosqueNevado.Source = ((Image)sender).Source; //asignar fondo generico
        }


        Color BarColorRojo = Color.FromArgb(246,25,1,96);
        /// metodo para cambair los colores a las barras de progreso segun esten a 15,25,50 y 100
        private void Cambio_colores(object sender, EventArgs e)
         {
             if (prgBar_Alimento.Value  == 50 || prgB_Cansancio.Value == 50 || prgB_Diversión.Value == 50)
            {

                

            }
            else if (prgBar_Alimento.Value == 25 || prgB_Cansancio.Value == 25 || prgB_Diversión.Value == 25)
            {

            }
         }



        

       


    }
}

