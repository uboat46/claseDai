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

namespace Inventario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cb_articulo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            Class1 con = new Class1();
            con.llenarComboUsers(cb_idUser1);
        }

        private void cb_idUser1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
