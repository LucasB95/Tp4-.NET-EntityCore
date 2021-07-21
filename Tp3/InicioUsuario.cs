using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tp3
{
    public partial class InicioUsuario : Form
    {
        AgenciaManager ag = new AgenciaManager();
        int propiedad;
        int precioC;
        int precioH;
        string TipoAlojamiento = "";
        Reserva reservaEliminar;
        public InicioUsuario()
        {
            InitializeComponent();          
            //refreshVistaReserva();
        }
        private void refreshVistaReserva()
        {
            //int dni = Convert.ToInt32(label10.Text);
            //int dni = int.Parse(label10.Text);
            //int i = string.IsNullOrEmpty(label10.Text) ? 0 : int.Parse(label10.Text);
            //dataGridView1.Rows.Clear();
            //foreach (List<string> aloj in ag.obtenerReservas(i))
            //    dataGridView1.Rows.Add(aloj.ToArray());
        }


        //bton de busqueda
        private void button1_Click(object sender, EventArgs e)
        {
            //bton de busqueda
            dataGridView2.Rows.Clear();

            String Ciudad = "";
            DateTime Pdesde = DateTime.Now;
            DateTime Phasta = DateTime.Now;
            int cantPersonas = 0;
            TipoAlojamiento = "";
            int estrellas = 0;


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(dateTimePicker2.Text) ||
                string.IsNullOrEmpty(checkedListBox1.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox1.Text != null && textBox2.Text != null && dateTimePicker1.Text != null && dateTimePicker2.Text != null && checkedListBox1.Text != null && textBox3.Text != null)
            {


             Ciudad = textBox2.Text;
             Pdesde = DateTime.Parse(dateTimePicker1.Text);
             Phasta = DateTime.Parse(dateTimePicker2.Text);
             cantPersonas = int.Parse(textBox1.Text);
             TipoAlojamiento = checkedListBox1.Text;
             estrellas = int.Parse(textBox3.Text);

                dataGridView2.Rows.Clear();
                foreach(List<string> aloj in ag.buscarAlojamiento(Ciudad, Pdesde, Phasta, cantPersonas, TipoAlojamiento, estrellas))
                {
                    dataGridView2.Rows.Add(aloj.ToArray());
                }

                //ag.buscarAlojamiento(Ciudad, Pdesde, Phasta, cantPersonas, Tipo,estrellas);

                int dni = int.Parse(label10.Text);

                MessageBox.Show("Ciudad :" + Ciudad + "\nDesde :" + Pdesde + "\nHasta :" + Phasta + "\nCantPersonas :" + cantPersonas + "\nTipo :" + TipoAlojamiento + "\nEstrellas :" + estrellas+"\nDNI :"+dni);
               //refreshVista();

              }
               


            }


        //datagrid para eliminar una reserva
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int numero_reserva = int.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
            DateTime pdesde = DateTime.Parse(dataGridView1[1, e.RowIndex].Value.ToString());
            DateTime pHasta = DateTime.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
            int precio = int.Parse(dataGridView1[3, e.RowIndex].Value.ToString());
            int aloj = int.Parse(dataGridView1[4, e.RowIndex].Value.ToString());
            int dni = int.Parse(dataGridView1[5, e.RowIndex].Value.ToString());

            //int id = ag.contadorReservas + 1;
            MessageBox.Show("La Reserva a Eliminar se compone de :" +"\nNumero de Reserva : "+ numero_reserva + "\nFecha Desde :" + pdesde + "\nFecha Hasta :" + pHasta + "\nPrecio :" + precio + "\nCodigo de Alojamiento :" + aloj + "\nDNI :" + dni + "\nSi es correcto pulse Eliminar Reserva");
            reservaEliminar = new Reserva(numero_reserva,pdesde, pHasta, precio, aloj, dni);
        }
        

        //datagrid cuando elijo una opcion de busqueda
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(TipoAlojamiento == "Hotel")
            {
                propiedad = int.Parse(dataGridView2[1, e.RowIndex].Value.ToString());
               
                precioH = int.Parse(dataGridView2[9, e.RowIndex].Value.ToString());

                MessageBox.Show( "Codigo del Alojamiento Seleccionado : " + propiedad + "\nPrecio Hotel sin calculo de cantidad de personas : " + precioH );
            }else if(TipoAlojamiento == "Cabaña")
            {
                propiedad = int.Parse(dataGridView2[1, e.RowIndex].Value.ToString());
                precioC = int.Parse(dataGridView2[8, e.RowIndex].Value.ToString());


                MessageBox.Show("Codigo del Alojamiento Seleccionado : " + propiedad + "\nPrecio Cabaña sin calculo de cantidad de dias : " + precioC);
            }
            
        }

      
        //boton para refrescar la vista de reserva
        private void button2_Click(object sender, EventArgs e)
        {
            int dni = int.Parse(label10.Text);
            //MessageBox.Show("dni"+dni);
            dataGridView1.Rows.Clear();
            foreach (List<string> aloj in ag.obtenerReservas(dni))
                dataGridView1.Rows.Add(aloj.ToArray());
        }

        //boton para reservar
        private void button3_Click(object sender, EventArgs e)
        {

            DateTime Pdesde = DateTime.Parse(dateTimePicker1.Text);
            DateTime Phasta = DateTime.Parse(dateTimePicker2.Text);
            int cantPersonas = int.Parse(textBox1.Text);
            int dni = int.Parse(label10.Text);
            int id = ag.contadorReservas + 1;

            ag.calculoReserva(Pdesde, Phasta, cantPersonas,precioC,precioH);      

            MessageBox.Show("Datos de la reserva :" + "\nTiempo de reserva en dias :" + ag.ts + "\nPrecio :" + ag.Total + "\nDNI :" + dni);

            Reserva reserva = new Reserva(id,Pdesde, Phasta, ag.Total, propiedad, dni);

            if (ag.reservar(reserva)){
                MessageBox.Show("Se ha generado una nueva reserva para el Usuario :" + dni);
            }
            else
            {
                MessageBox.Show("No se pudo generar la reserva contacte con un administrador");
            }


        }
        //buton para eliminar reserva
        private void button6_Click(object sender, EventArgs e)
        {
           

            if (ag.eliminarReserva(reservaEliminar))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVistaReserva();
            }
            else
                MessageBox.Show("No se pudo eliminar la reserva");

        }
        //boton de cerrar sesion
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }
        //boton para limpiar la vista de alojamiento
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

    }
    }
      

    

