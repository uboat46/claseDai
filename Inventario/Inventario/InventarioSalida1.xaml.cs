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

namespace Inventario
{
    /// <summary>
    /// Lógica de interacción para InventarioSalida1.xaml
    /// </summary>
    public partial class InventarioSalida1 : Window
    {
        private Window previous;
        private int user;
        public InventarioSalida1(Window prev,int user)
        {
            InitializeComponent();
            previous = prev;
            this.user = user;
        }

        private void bt_registrarSalida_Click(object sender, RoutedEventArgs e)
        {
            Class1 con = new Class1();
            
            int canti = int.Parse(tb_cantidad.Text);
            int cantidadActual = (int)con.obtenCant(cb_articulo);
            if (canti <= cantidadActual)
            {
                con.agregaSalida(dp_fechaDeSalida, tb_responsableDeLaSalida, user);
                con.agregaSalidaArticulo(con.obtenIdSalida(tb_responsableDeLaSalida, user), cb_articulo, tb_cantidad);
                con.updateCantidad(con.obtenCant(cb_articulo), cb_articulo, -int.Parse(tb_cantidad.Text));
            }
        }

        private void bt_registrarSalida_Loaded(object sender, RoutedEventArgs e)
        {
            Class1 con = new Class1();
            con.llenarComboArticulos(cb_articulo);
        }

        private void bt_regreso_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            previous.Show();
        }
    }
}
