

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
        String nombre;


        //public object TimeMeasure { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Ventana_Bienvenda pantalla_Inicio = new Ventana_Bienvenda(this);
            pantalla_Inicio.ShowDialog();

           

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
            Cambio_colores(sender, e);
            cagar(sender, e); 


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



                im_aburrido.Visibility = Visibility.Hidden;
                im_conSueño.Visibility = Visibility.Hidden;
                im_hambriento.Visibility = Visibility.Hidden;
                lbl_cuidado.Visibility = Visibility.Hidden;

                this.btn_Alimentar.IsEnabled = false;
                this.btn_Descansar.IsEnabled = false;
                this.btn_divertir.IsEnabled = false;

                this.lbl_tiempoVida.Content = tiempo_vida;
                this.lbl_tiempoVida.Visibility = Visibility.Visible;





            }
        }
        /// <summary>
        /// Animaciones que se desarrollan con la interaccion de los botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btn_divertir_Click(object sender, RoutedEventArgs e)
        {
            this.prgB_Diversión.Value += 5;
            decremento += 2;

            Storyboard sbJugar = (Storyboard)this.Resources["animacionJugar"];
            sbJugar.Begin();
            Storyboard sbBailar = (Storyboard)this.Resources["animacionBailarIcon"];
            sbBailar.Begin();

        }



        /// <summary>
        /// Fin de animaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void finCerrarOjoDer(object sender, EventArgs e)
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

        private void limpiarCaca(object sender, MouseButtonEventArgs e)
        {
            im_caca.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// animaciones con el tiempo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        
        private void cagar(object sender, EventArgs e)
        {
            if (prgBar_Alimento.Value % 30 == 0 )
            {
                im_caca.Visibility = Visibility.Visible;
            }
        }



      
       /// <summary>
       /// Cambiar fondo
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        private void cambiarFondo(object sender, MouseButtonEventArgs e)
        {
            this.img_bosqueNevado.Source = ((Image)sender).Source; //asignar fondo generico
        }


        private void arrastrarMascarilla(object sender, MouseButtonEventArgs e)
        {
            DataObject data0 = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, data0, DragDropEffects.Move);

            mascarilla.Visibility = Visibility.Visible;
        }

        private void colocarColeccionable(object sender, DragEventArgs e)

        {
            Image aux = (Image)e.Data.GetData(typeof(Image));

            switch (aux.Name)
            {
                case "miniMascarillaPingu":
                    miniMascarilla.Visibility = Visibility.Visible;
                    break;

            }
        }




        /// <summary>
        /// Metodo para cambiar de color las barras de progreso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cambio_colores(object sender, EventArgs e)
        {
          
            if ((prgBar_Alimento.Value <= 50 && prgBar_Alimento.Value > 25) || (prgB_Cansancio.Value <= 50 && prgB_Cansancio.Value > 25) || (prgB_Diversión.Value <= 50 && prgB_Diversión.Value > 25))
            {

                prgBar_Alimento.Foreground = new SolidColorBrush(Colors.Yellow);
                prgB_Cansancio.Foreground = new SolidColorBrush(Colors.Yellow);
                prgB_Diversión.Foreground = new SolidColorBrush(Colors.Yellow);
                im_aburrido.Visibility = Visibility.Hidden;
                im_conSueño.Visibility = Visibility.Hidden;
                im_hambriento.Visibility = Visibility.Hidden;
                lbl_cuidado.Visibility = Visibility.Hidden;


            }
            else if ((prgBar_Alimento.Value <= 25 && prgBar_Alimento.Value > 15) || (prgB_Cansancio.Value <= 25 && prgB_Cansancio.Value > 15) || (prgB_Diversión.Value <= 25 && prgB_Diversión.Value > 15))
            {
                prgBar_Alimento.Foreground = new SolidColorBrush(Colors.Orange);
                prgB_Cansancio.Foreground = new SolidColorBrush(Colors.Orange);
                prgB_Diversión.Foreground = new SolidColorBrush(Colors.Orange);
                im_aburrido.Visibility = Visibility.Visible;
                im_conSueño.Visibility = Visibility.Visible;
                im_hambriento.Visibility = Visibility.Visible;
                lbl_cuidado.Visibility = Visibility.Visible;
            }
            else if (prgBar_Alimento.Value <= 15 || prgB_Cansancio.Value <= 15 || prgB_Diversión.Value <= 15)
            {
                prgBar_Alimento.Foreground = new SolidColorBrush(Colors.Red);
                prgB_Cansancio.Foreground = new SolidColorBrush(Colors.Red);
                prgB_Diversión.Foreground = new SolidColorBrush(Colors.Red);
                im_aburrido.Visibility = Visibility.Visible;
                im_conSueño.Visibility = Visibility.Visible;
                im_hambriento.Visibility = Visibility.Visible;
                lbl_cuidado.Visibility = Visibility.Visible;

            }
        }




        /// <summary>
        /// Metodos de interaccion con el usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acerca_de(object sender, MouseButtonEventArgs e)
        {
           MessageBoxResult resultadoAcercaDe= MessageBox.Show("Programa realizado por: \n \n María Jesús Dueñas \n \n ¿Desea salir? ","Acerca de",MessageBoxButton.YesNo);

            switch (resultadoAcercaDe)
            {
                case MessageBoxResult.Yes:
                    this.Close(); //el this es de la ventana no del mensaje.
                    break;
            }
        }
         public void setNombre(string nombre)
        {
            this.nombre = nombre;
            tbMensaje.Text = "Bienvenido/a " + nombre;
            

        }

        
        
    }
}

