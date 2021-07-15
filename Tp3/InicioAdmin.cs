using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tp3
{
    public partial class InicioAdmin : Form
    {
        AgenciaManager ag = new AgenciaManager();

        public InicioAdmin()
        {
            InitializeComponent();
            refreshVistaUsuario();
            refreshVistaAlojamiento();
            refreshVistaReserva();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2[0, e.RowIndex].Value.ToString();
            textBox2.Text = dataGridView2[1, e.RowIndex].Value.ToString();
            textBox3.Text = dataGridView2[2, e.RowIndex].Value.ToString();
            textBox4.Text = dataGridView2[3, e.RowIndex].Value.ToString();
            checkBox1.Checked = bool.Parse(dataGridView2[4, e.RowIndex].Value.ToString());
            checkBox2.Checked = bool.Parse(dataGridView2[5, e.RowIndex].Value.ToString());
        }
        private void refreshVistaUsuario()
        {
            dataGridView2.Rows.Clear();
            foreach (List<string> usuario in ag.obtenerUsuarios())
                dataGridView2.Rows.Add(usuario.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ag.eliminarUsuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVistaUsuario();
            }
            else
                MessageBox.Show("No se pudo eliminar el usuario");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ag.modificarUsuarioAdmin(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Modificado con éxito");
                refreshVistaUsuario();
            }
            else
                MessageBox.Show("No se pudo modificar el usuario");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox1.Text != null && textBox2 != null && textBox3.Text != null && textBox4.Text != null)
            {

                Usuario usuarioAgregado = new Usuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text);


                if (ag.AgregarUsuario(usuarioAgregado))
                {

                    MessageBox.Show("Agregado con éxito");
                    refreshVistaUsuario();

                }
                else
                {
                    MessageBox.Show("Ya existen datos con el DNI");

                }

            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView3[0, e.RowIndex].Value.ToString();
            textBox6.Text = dataGridView3[1, e.RowIndex].Value.ToString();
            textBox7.Text = dataGridView3[2, e.RowIndex].Value.ToString();
            textBox8.Text = dataGridView3[3, e.RowIndex].Value.ToString();
            textBox9.Text = dataGridView3[4, e.RowIndex].Value.ToString();
            textBox10.Text = dataGridView3[5, e.RowIndex].Value.ToString();
            textBox11.Text = dataGridView3[6, e.RowIndex].Value.ToString();
            //textBox12.Text = dataGridView3[7, e.RowIndex].Value.ToString();
            checkBox3.Checked = bool.Parse(dataGridView3[7, e.RowIndex].Value.ToString());
            textBox13.Text = dataGridView3[8, e.RowIndex].Value.ToString();
            textBox14.Text = dataGridView3[9, e.RowIndex].Value.ToString();
            textBox15.Text = dataGridView3[10, e.RowIndex].Value.ToString();
            textBox16.Text = dataGridView3[11, e.RowIndex].Value.ToString();
        

        }
        private void refreshVistaAlojamiento()
        {
            dataGridView3.Rows.Clear();
            foreach (List<string> aloj in ag.obtenerAlojamiento())
                dataGridView3.Rows.Add(aloj.ToArray());
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) ||
                string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text) ||
                string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox14.Text) || string.IsNullOrEmpty(textBox15.Text) || string.IsNullOrEmpty(textBox16.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox5.Text != null && textBox6.Text != null && textBox7.Text != null && textBox8.Text != null && textBox9.Text != null && textBox10.Text != null
                   && textBox11.Text != null && textBox13.Text != null && textBox14.Text != null && textBox15.Text != null && textBox16.Text != null)
            {

                Alojamiento aloj = new Alojamiento(int.Parse(textBox6.Text), textBox5.Text, textBox8.Text, textBox9.Text, int.Parse(textBox10.Text), int.Parse(textBox11.Text),
                                                   checkBox3.Checked, int.Parse(textBox13.Text), int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), textBox7.Text);


                if (ag.agregarAlojamiento(aloj))
                {

                    MessageBox.Show("Agregado con éxito");
                    refreshVistaAlojamiento();

                }
                else
                {
                    MessageBox.Show("Ya existen datos ese alojamiento");
                    MessageBox.Show("capacidad de lista alojamiento :" + ag.alojcont);

                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Alojamiento aloj = new Alojamiento(int.Parse(textBox6.Text), textBox5.Text, textBox8.Text, textBox9.Text, int.Parse(textBox10.Text), int.Parse(textBox11.Text),
                                                   checkBox3.Checked, int.Parse(textBox13.Text), int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), textBox7.Text);

            if (ag.modificarAlojamiento(aloj))
            {
                MessageBox.Show("Modificado con éxito");
                refreshVistaAlojamiento();
            }
            else
                MessageBox.Show("No se pudo modificar el alojamiento");
        }

        private void button6_Click(object sender, EventArgs e)


        {
            Alojamiento aloj = new Alojamiento(int.Parse(textBox6.Text), textBox5.Text, textBox8.Text, textBox9.Text, int.Parse(textBox10.Text), int.Parse(textBox11.Text),
                                                   checkBox3.Checked, int.Parse(textBox13.Text), int.Parse(textBox14.Text), int.Parse(textBox15.Text), int.Parse(textBox16.Text), textBox7.Text);

            if (ag.quitarAlojamiento(aloj))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVistaAlojamiento();
            }
            else
                MessageBox.Show("No se pudo eliminar el usuario");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox12.Text = dataGridView1[0, e.RowIndex].Value.ToString();
            textBox17.Text = dataGridView1[1, e.RowIndex].Value.ToString();
            textBox18.Text = dataGridView1[2, e.RowIndex].Value.ToString();
            textBox19.Text = dataGridView1[3, e.RowIndex].Value.ToString();
            textBox20.Text = dataGridView1[4, e.RowIndex].Value.ToString();
            textBox21.Text = dataGridView1[5, e.RowIndex].Value.ToString();
    
        }
        private void refreshVistaReserva()
        {
            dataGridView1.Rows.Clear();
            foreach (List<string> reserva in ag.obtenerReserva())
                dataGridView1.Rows.Add(reserva.ToArray());

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(textBox17.Text) || string.IsNullOrEmpty(textBox18.Text) || string.IsNullOrEmpty(textBox19.Text) || string.IsNullOrEmpty(textBox20.Text) || string.IsNullOrEmpty(textBox21.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox17 != null && textBox18.Text != null && textBox19.Text != null && textBox20.Text != null && textBox21.Text != null)
            {

                int id = ag.contadorReservas + 1;

                MessageBox.Show("contador de reservas " + id);

                Reserva reserva = new Reserva(id, DateTime.Parse(textBox17.Text),DateTime.Parse(textBox18.Text),int.Parse(textBox19.Text), int.Parse(textBox20.Text),int.Parse(textBox21.Text));


                if (ag.reservar(reserva))
                {

                    MessageBox.Show("Agregado con éxito");
                    refreshVistaReserva();

                }
                else
                {
                    MessageBox.Show("Ya existen datos con el DNI");

                }

            }
        }

        private void button9_Click(object sender, EventArgs e)

        {

            int id = ag.contadorReservas + 1;

            Reserva reserva = new Reserva(id, DateTime.Parse(textBox17.Text), DateTime.Parse(textBox18.Text), int.Parse(textBox19.Text), int.Parse(textBox20.Text), int.Parse(textBox21.Text));

            if (ag.eliminarReserva(reserva))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVistaReserva();
            }
            else
                MessageBox.Show("No se pudo eliminar la reserva");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int id = ag.contadorReservas + 1;

            Reserva reserva = new Reserva(id, DateTime.Parse(textBox17.Text), DateTime.Parse(textBox18.Text), int.Parse(textBox19.Text), int.Parse(textBox20.Text), int.Parse(textBox21.Text));

            if (ag.modificarReserva(reserva,int.Parse(textBox12.Text)))
            {
                MessageBox.Show("Modificado con éxito");
                refreshVistaReserva();
            }
            else
                MessageBox.Show("No se pudo modificar el usuario");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void InicioAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
