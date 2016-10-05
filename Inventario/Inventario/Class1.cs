using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Inventario
{
    class Class1
    {

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;

        public static SqlConnection Connect()
        {
            SqlConnection cnn;
            cnn = new SqlConnection("Data Source=112SALAS27;Initial Catalog=Inventario;User ID=sa;Password=sqladmin");
            cnn.Open();
            MessageBox.Show("Conexion Exitosa");
            return cnn;
        }

        public void llenarComboUsers(ComboBox cb)
        {
            try
            {
                cmd = new SqlCommand("SELECT usuario.idUser FROM usuario", Connect());
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb.Items.Add(dr["idUser"].ToString());
                }
                cb.SelectedIndex = 0;
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                //lol
            }
        }

        public void llenarComboArticulos(ComboBox cb)
        {
            try
            {
                cmd = new SqlCommand("SELECT articulo.idArticulo FROM articulo", Connect());
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cb.Items.Add(dr["idArticulo"].ToString());
                }
                cb.SelectedIndex = 0;
                dr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                //lol
            }
        }

        public void agregaEntrada(DatePicker entr,TextBox prov,TextBox fol,DatePicker fac,ComboBox user)
        {
            try
            {
                Implementacion i = new Implementacion();
                DateTime reg = DateTime.Today;
                //Console.WriteLine("Intentando conseguir fecha de hoy");
                String strReg = i.cambiaFecha(reg.ToString("d"));
                //Console.WriteLine("Intentando conseguit prooveedor");
                String prove = prov.Text;
                //Console.WriteLine("Intentando conseguir fecha entrada");
                String fechaEnt = i.cambiaFecha(entr.SelectedDate.ToString());
                //Console.WriteLine("Intentando conseguir folio");
                String folio = fol.Text;
                //Console.WriteLine("Intentando conseguir fecha factura");
                String fechaFac = i.cambiaFecha(fac.SelectedDate.ToString());
                //Console.WriteLine("Intentando conseguir idUser");
                int id = int.Parse(user.SelectedValue.ToString());
                Console.WriteLine("Iduser: " + id);
                SqlConnection cnn;
                //Console.WriteLine("Intentando conectar");
                cnn = Connect();
                //Console.WriteLine("Conexion exitosa");
                //Console.WriteLine("Intentando agregar entrada");
                cmd = new SqlCommand(String.Format("INSERT INTO entrada(fechaRegistro,fechaEntrada,proveedor,folioFactura,fechaFactura,idUser) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", strReg, fechaEnt, prove, folio, fechaFac,id), cnn);
                int res = cmd.ExecuteNonQuery();
                cnn.Close();
                
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Fallo el agregaEntrada");
                //lol
            }

        }

        public int obtenIdEntrada(TextBox fol)
        {
            try
            {
                String folio = fol.Text;
                cmd = new SqlCommand("SELECT entrada.idEntrada FROM entrada WHERE folioFactura ="+folio, Connect());
                dr = cmd.ExecuteReader();
                String id = "-1";
                while (dr.Read())
                {
                    id = dr[0].ToString();  
                }
                dr.Close();

                return int.Parse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                return -1;
            }
        }


        public void agregaEntradaArticulo(int idEnt, ComboBox idArt, TextBox cant, TextBox precio)
        {
            try
            {
                
                int canti = int.Parse(cant.Text);
                double pre = double.Parse(precio.Text);
                int idAr = int.Parse(idArt.SelectedValue.ToString());
                SqlConnection cnn;
                cnn = Connect();
                Console.WriteLine("Intentando agregar entrada articulo");
                cmd = new SqlCommand(String.Format("INSERT INTO entArticulo(idEntrada,idArticulo,cant,precioCompra) VALUES('{0}','{1}','{2}','{3}')",idEnt,idAr,canti,pre), cnn);
                int res = cmd.ExecuteNonQuery();
                cnn.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                //lol
            }

        }

        public void updateCantidad(double cant, ComboBox idArt,int cantidad)
        {
            try
            {
                int idAr = int.Parse(idArt.SelectedValue.ToString());
                double fin = cant +cantidad;
                Console.WriteLine("Cantidad de articulos en existencia ="+ cant + "||||||   Cantidad a agregar=" + cantidad);
                SqlConnection cnn;
                cnn = Connect();
                Console.WriteLine("Intentando updetear cantidad de articulo "+idAr+ " agregando "+fin+" articulos");
                cmd = new SqlCommand("UPDATE articulo SET articulo.existencia ="+fin+ " WHERE articulo.idArticulo ="+idAr, cnn);
                int res = cmd.ExecuteNonQuery();
                cnn.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                //lol
            }

        }

        public double obtenCant(ComboBox idArt)
        {
            try
            {
                int idAr = int.Parse(idArt.SelectedValue.ToString());
                cmd = new SqlCommand("SELECT articulo.existencia FROM articulo WHERE articulo.idArticulo =" + idAr, Connect());
                dr = cmd.ExecuteReader();
                String id = "-1.00";
                while (dr.Read())
                {
                    id = dr[0].ToString();
                }
                dr.Close();

                return Convert.ToDouble(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                return -1.00;
            }
        }
        public void agregaSalida(DatePicker salida, TextBox resp,int user)
        {
            try
            {
                Implementacion i = new Implementacion();
                DateTime reg = DateTime.Today;
                //Console.WriteLine("Intentando conseguir fecha de hoy");
                String strReg = i.cambiaFecha(reg.ToString("d"));
                //Console.WriteLine("Intentando conseguit prooveedor");
                String respon = resp.Text;
                //Console.WriteLine("Intentando conseguir fecha entrada");
                String fechaSalida = i.cambiaFecha(salida.SelectedDate.ToString());
                SqlConnection cnn;
                //Console.WriteLine("Intentando conectar");
                cnn = Connect();
                //Console.WriteLine("Conexion exitosa");
                //Console.WriteLine("Intentando agregar entrada");
                cmd = new SqlCommand(String.Format("INSERT INTO salida(fechaRegistro,fechaSalida,responsable,idUser) VALUES('{0}','{1}','{2}','{3}')", strReg, fechaSalida, respon, user), cnn);
                int res = cmd.ExecuteNonQuery();
                cnn.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Fallo el agregaSalida");
                //lol
            }

        }

        public int obtenIdSalida(TextBox res,int user)
        {
            try
            {
                String respon = res.Text;
                cmd = new SqlCommand("SELECT salida.idSalida FROM salida WHERE  responsable ='" + respon + "' AND idUser =" + user, Connect());
                dr = cmd.ExecuteReader();
                String id = "-1";
                while (dr.Read())
                {
                    id = dr[0].ToString();
                }
                dr.Close();

                return int.Parse(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                return -1;
            }
        }


        public void agregaSalidaArticulo(int idSal, ComboBox idArt, TextBox cant)
        {
            try
            {

                int canti = int.Parse(cant.Text);
                int cantidadActual = (int) obtenCant(idArt);
                int idAr = int.Parse(idArt.SelectedValue.ToString());
                Console.WriteLine("Quitando " + canti + " articulos a " + cantidadActual);
                if (canti <= cantidadActual)
                {
                    Console.WriteLine("Si entre");
                    SqlConnection cnn;
                    cnn = Connect();
                    Console.WriteLine("Intentando agregar salida articulo");
                    cmd = new SqlCommand(String.Format("INSERT INTO salArticulo(idSalida,idArticulo,cant) VALUES('{0}','{1}','{2}')", idSal, idAr, canti), cnn);
                    int res = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
                else
                {
                    Console.WriteLine("No entre");
                    MessageBox.Show("Cantidad no suficiente en el inventario");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show(e.Message);
                //lol
            }

        }
    }
}
