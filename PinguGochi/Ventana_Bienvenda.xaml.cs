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
using System.Windows.Shapes;

namespace PinguGochi
{
    /// <summary>
    /// Lógica de interacción para Ventana_Bienvenda.xaml
    /// </summary>
    public partial class Ventana_Bienvenda : Window
    {
        MainWindow menu_Principal;
        public Ventana_Bienvenda(MainWindow menu_Principal)
        {
            InitializeComponent();
            this.menu_Principal = menu_Principal;
            
        }

        private void btn_aceptar_Click(object sender, RoutedEventArgs e)
        {
           
                btn_aceptar.IsEnabled = true;
                menu_Principal.setNombre(txt_nombre.Text);
                this.Close();
            
            
        }
    }
}
