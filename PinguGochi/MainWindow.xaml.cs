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


namespace PinguGochi
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer t1;
        int tickComer = 0;
        int tickCagar = 0;
        int tickDormir = 0;
        int tickJugar = 0;
        
        int tiempo_vida = 0;
        double decremento = 1.0;
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
            this.lbl_tiempoVidaP.Visibility = Visibility.Hidden;
            t1.Start();

        }


        private void puntuacionTiempoVida(object sender, EventArgs e)
        {

            if (prgBar_Alimento.Value < 100 || prgB_Cansancio.Value < 100 || prgB_Diversión.Value < 100)
            {
                tiempo_vida++;
                lbl_tiempoVidaP.Content = tiempo_vida;



            }
        }

        /// <summary>
        /// crear evento
        /// </summary>

        private void reloj(object sender, EventArgs e)
        {
            //logros(sender, e);
            premios_coleccionables(sender, e);
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
                this.lbl_tiempoVidaP.Visibility = Visibility.Visible;
                this.lbl_puntuacionJugador.Visibility = Visibility.Visible;

                im_aburrido.Visibility = Visibility.Hidden;
                im_conSueño.Visibility = Visibility.Hidden;
                im_hambriento.Visibility = Visibility.Hidden;
                lbl_cuidado.Visibility = Visibility.Hidden;

                this.btn_Alimentar.IsEnabled = false;
                this.btn_Descansar.IsEnabled = false;
                this.btn_divertir.IsEnabled = false;

                this.lbl_tiempoVidaP.Content = tiempo_vida;
                this.lbl_tiempoVidaP.Visibility = Visibility.Visible;
                this.im_caca1.Visibility = Visibility.Hidden;
                this.im_caca2.Visibility = Visibility.Hidden;
                this.im_aburrido.Visibility = Visibility.Hidden;
                this.im_conSueño.Visibility = Visibility.Hidden;
                this.jugarLogo.Visibility = Visibility.Hidden;


                this.bocadilloAburrido.Visibility = Visibility.Hidden;
                this.bocadilloCansado.Visibility = Visibility.Hidden;
                this.bocadilloHambriento.Visibility = Visibility.Hidden;

                
                this.comerLogo.Visibility = Visibility.Hidden;
                this.dormirLogo.Visibility = Visibility.Hidden;
                this.jugarLogo.Visibility = Visibility.Hidden;






            }
        }
        /// <summary>
        /// Animaciones que se desarrollan con la interaccion de los botones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Alimentar_Click(object sender, RoutedEventArgs e)
        {
            this.prgBar_Alimento.Value += 15;
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
            this.prgB_Cansancio.Value += 15;
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

            tickDormir++;
            if (tickDormir == 3)
            {
                Storyboard sbDormir = (Storyboard)this.Resources["animacionLogroDormir"];
                sbDormir.Begin();
                logroDormir.Visibility = Visibility.Visible;
            }

        }

        private void btn_divertir_Click(object sender, RoutedEventArgs e)
        {
            this.prgB_Diversión.Value += 15;
            decremento += 2;

            
            btn_divertir.IsEnabled = false;

            Storyboard sbJugar = (Storyboard)this.Resources["animacionJugar"];
            sbJugar.Begin();
            Storyboard sbBailar = (Storyboard)this.Resources["animacionBailarIcon"];
            sbBailar.Begin();
            btn_divertir.IsEnabled = true;
           // bolaBlanca.Visibility = Visibility.Visible;
           // bolaClara.Visibility = Visibility.Visible;
           // bolaOscura.Visibility = Visibility.Visible;

            tickJugar++;
            if (tickJugar == 5)
            {
                Storyboard sbJugaar = (Storyboard)this.Resources["animacionLogroJugar"];
                sbJugaar.Begin();
                logroJugarMini.Visibility = Visibility.Visible;

            }
        }


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
            tickComer++;
            if (tickComer == 6)
            {
                Storyboard sbComer = (Storyboard)this.Resources["animacionLogroComer"];
                sbComer.Begin();
                logroComer.Visibility = Visibility.Visible;
            }
        }

        private void limpiarCaca(object sender, MouseButtonEventArgs e)
        {
            
            tickCagar++;
            im_caca1.Visibility = Visibility.Hidden;
            im_caca2.Visibility = Visibility.Hidden;
            if (tickCagar == 2)
            {
                Storyboard sbCaga = (Storyboard)this.Resources["animacionLogroCagar"];
                sbCaga.Begin();
                logroCagar.Visibility = Visibility.Visible;
            }
        }

        

        private void cagar(object sender, EventArgs e)
        {
            if (prgBar_Alimento.Value % 15== 0)
            {
                Random rdn = new Random();
                int random = rdn.Next(1, 4);

                switch (random)
                {
                    case 1:
                        im_caca1.Visibility = Visibility.Visible;
                        im_caca2.Visibility = Visibility.Hidden;
                        break;
                    case 2:
                        im_caca2.Visibility = Visibility.Visible;
                        im_caca1.Visibility = Visibility.Hidden;
                        break;
                    case 3:
                        im_caca1.Visibility = Visibility.Visible;
                        im_caca2.Visibility = Visibility.Hidden;
                        break;
                    case 4:
                        im_caca2.Visibility = Visibility.Visible;
                        im_caca1.Visibility = Visibility.Hidden;
                        break;

                }

            }
            
        }


        private void cambiarFondo(object sender, MouseButtonEventArgs e)
        {
            this.img_bosqueNevado.Source = ((Image)sender).Source; //asignar fondo generico
        }


        private void arrastrarMascarilla(object sender, MouseButtonEventArgs e)
        {
            DataObject data0 = new DataObject(((Image)sender));
            DragDrop.DoDragDrop((Image)sender, data0, DragDropEffects.Move);

            //mascarilla.Visibility = Visibility.Visible;
        }

        private void colocarColeccionable(object sender, DragEventArgs e)

        {
            Image aux = (Image)e.Data.GetData(typeof(Image));

            switch (aux.Name)
            {
                case "miniMascarilla":
                    miniMascarilla.Visibility = Visibility.Visible;
                    mascarilla.Visibility = Visibility.Visible;
                    miniGorro.Visibility = Visibility.Visible;
                    gorro.Visibility = Visibility.Hidden;
                    auricularesLados.Visibility = Visibility.Visible;
                    cascoAuricular.Visibility = Visibility.Visible;
                    miniPiruleta.Visibility = Visibility.Visible;
                    piruleta.Visibility = Visibility.Hidden;
                    break;
                case "miniPiruleta":
                    miniPiruleta.Visibility = Visibility.Visible;
                    piruleta.Visibility = Visibility.Visible;
                    miniGorro.Visibility = Visibility.Visible;
                    gorro.Visibility = Visibility.Hidden;
                    auricularesLados.Visibility = Visibility.Visible;
                    cascoAuricular.Visibility = Visibility.Visible;
                    iglu.Visibility = Visibility.Hidden;
                    mascarilla.Visibility = Visibility.Hidden;
                    break;
                case "miniGorro":
                    miniGorro.Visibility = Visibility.Visible;
                    gorro.Visibility = Visibility.Visible;
                    auricularesLados.Visibility = Visibility.Hidden;
                    cascoAuricular.Visibility = Visibility.Hidden;
                    iglu.Visibility = Visibility.Hidden;
                    mascarilla.Visibility = Visibility.Hidden;
                   
                    break;
                case "miniIglu":
                    iglu.Visibility = Visibility.Visible;
                    miniIglu.Visibility = Visibility.Visible;
                    miniGorro.Visibility = Visibility.Visible;
                    gorro.Visibility = Visibility.Hidden;
                    auricularesLados.Visibility = Visibility.Visible;
                    cascoAuricular.Visibility = Visibility.Visible; 
                    break;

            }
        }

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
                bocadilloAburrido.Visibility = Visibility.Hidden;
                bocadilloCansado.Visibility = Visibility.Hidden;
                bocadilloHambriento.Visibility = Visibility.Hidden;
            }
            else if ((prgBar_Alimento.Value <= 25 && prgBar_Alimento.Value > 15) || (prgB_Cansancio.Value <= 25 && prgB_Cansancio.Value > 15) || (prgB_Diversión.Value <= 25 && prgB_Diversión.Value > 15))
            {
                prgBar_Alimento.Foreground = new SolidColorBrush(Colors.Orange);
                prgB_Cansancio.Foreground = new SolidColorBrush(Colors.Orange);
                prgB_Diversión.Foreground = new SolidColorBrush(Colors.Orange);
                bocadilloAburrido.Visibility = Visibility.Hidden;
                bocadilloCansado.Visibility = Visibility.Hidden;
                bocadilloHambriento.Visibility = Visibility.Hidden;
                
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
                bocadilloAburrido.Visibility = Visibility.Visible;
                bocadilloCansado.Visibility = Visibility.Visible;
                bocadilloHambriento.Visibility = Visibility.Visible;

            }
        }

       /* private void estadoBajo(object sender, EventArgs e)
        {
            if (prgBar_Alimento.Value <= 25 && prgBar_Alimento.Value > 15)
            {
                bocadilloAburrido.Visibility = Visibility.Visible;
                bocadilloCansado.Visibility = Visibility.Visible;
                bocadilloHambriento.Visibility = Visibility.Visible;

            }
        }*/

        private void premios_coleccionables(object sender, EventArgs e)
        {
            if (tiempo_vida == 10)
            {
                Storyboard sbGorro = (Storyboard)this.Resources["premio10Seg"];
                sbGorro.Begin();
                im_logroGorro.Visibility = Visibility.Visible;
                miniGorro.Visibility = Visibility.Visible;

            }
            else if (tiempo_vida == 20)
            {
                Storyboard sbPiruleta = (Storyboard)this.Resources["premio20seg"];
                sbPiruleta.Begin();
                miniPiruleta.Visibility = Visibility.Visible;
                im_logroPiruleta.Visibility = Visibility.Visible;
                miniPiruleta.Visibility = Visibility.Visible;

            }
            else if (tiempo_vida == 30)
            {
                Storyboard sbMascarilla = (Storyboard)this.Resources["premio30seg"];
                sbMascarilla.Begin();
                miniMascarilla.Visibility = Visibility.Visible;
                im_logroMascarilla.Visibility = Visibility.Visible;
                miniMascarilla.Visibility = Visibility.Visible;

            }
            else if (tiempo_vida == 40)
            {
                Storyboard sbIglu = (Storyboard)this.Resources["premio40seg"];
                sbIglu.Begin();
                miniIglu.Visibility = Visibility.Visible;
                im_logroIglu.Visibility = Visibility.Visible;
                miniIglu.Visibility = Visibility.Visible;

            }
        }


        private void acerca_de(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult resultadoAcercaDe = MessageBox.Show("Programa realizado por: \n \n María Jesús Dueñas \n \n ¿Desea salir? ", "Acerca de", MessageBoxButton.YesNo);

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