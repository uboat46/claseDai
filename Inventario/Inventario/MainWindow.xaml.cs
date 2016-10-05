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
            con.llenarComboArticulos(cb_articulo);
        }

        private void cb_idUser1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bt_agregar_Click(object sender, RoutedEventArgs e)
        {
            Class1 con = new Class1();
            con.agregaEntrada(dp_fechaDeEntrada, tb_nombreDelProveedor, tb_folioFactura, dp_fechaFactura, cb_idUser1);
            con.agregaEntradaArticulo(con.obtenIdEntrada(tb_folioFactura), cb_articulo, tb_cantidad, tb_precio);
            con.updateCantidad(con.obtenCant(cb_articulo), cb_articulo,int.Parse(tb_cantidad.Text));

        }

        private void bt_salidaDeArticulos_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            InventarioSalida1 frm1 = new InventarioSalida1(this, int.Parse(cb_idUser1.SelectedValue.ToString()));
            frm1.Show();
        }
    }
}
